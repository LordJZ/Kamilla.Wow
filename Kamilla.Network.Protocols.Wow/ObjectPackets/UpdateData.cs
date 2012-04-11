using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class UpdateData : LazyObjectPacket
    {
        public Maps Map
        {
            get { return m_map; }
            set { m_map = value; }
        }

        public List<WowGuid> DestroyedObjects { get { EnsureRead(1); return this.m_destroyedObjects; } }
        public Dictionary<WowGuid, UpdateFields> ValuesUpdates { get { EnsureRead(1); return this.m_valuesUpdates; } }
        public Dictionary<WowGuid, WowObject> CreatedObjects { get { EnsureRead(1); return this.m_createdObjects; } }

        private Maps m_map;
        private List<WowGuid> m_destroyedObjects = new List<WowGuid>();
        private Dictionary<WowGuid, UpdateFields> m_valuesUpdates = new Dictionary<WowGuid, UpdateFields>();
        private Dictionary<WowGuid, WowObject> m_createdObjects = new Dictionary<WowGuid, WowObject>();

        public UpdateData(Maps map)
        {
            this.m_map = map;
            SetRead();
        }

        public UpdateData(StreamHandler Reader, bool LazyReading)
        {
            this.m_map = (Maps)Reader.ReadUInt16();

            this.Reader = Reader;

            m_readers = new Action[]
                {
                    ReadUpdates,
                };

            if (!LazyReading)
                EnsureRead();
        }

        private void ReadUpdates()
        {
            uint nUpdates = Reader.ReadUInt32();
            for (uint i = 0; i < nUpdates; ++i)
            {
                var updateType = (UpdateTypes)Reader.ReadByte();
                switch (updateType)
                {
                    case UpdateTypes.UpdateValues:
                        ReadObjectValuesUpdate(Reader);
                        break;
                    case UpdateTypes.CreateObjects:
                    case UpdateTypes.CreateObjects2:
                        ReadObjectCreateUpdate(Reader);
                        break;
                    case UpdateTypes.DestroyObjects:
                        ReadObjectDestroyUpdate(Reader);
                        break;
                    default:
                        throw new NotImplementedException(
                            String.Format("Processing Update Type {0} ({0:D}) is not implemented.", updateType)
                            );
                }
            }
        }

        private void ReadObjectValuesUpdate(StreamHandler Reader)
        {
            var guid = Reader.ReadPackedGuid();
            var values = ReadValues(Reader);
            if (!m_valuesUpdates.ContainsKey(guid))
                m_valuesUpdates.Add(guid, values);
            else
                Console.WriteLine("Error: Updated object duplicate guid {0}", guid);
        }

        private void ReadObjectCreateUpdate(StreamHandler Reader)
        {
            var guid = Reader.ReadPackedGuid();
            var type = (ObjectTypeId)Reader.ReadByte();

            WowObject obj;

            switch (type)
            {
                case ObjectTypeId.Container:
                    obj = new WowContainer();
                    break;
                case ObjectTypeId.Corpse:
                    obj = new WowCorpse();
                    break;
                case ObjectTypeId.DynamicObject:
                    obj = new WowDynamicObject();
                    break;
                case ObjectTypeId.GameObject:
                    obj = new WowGameObject();
                    break;
                case ObjectTypeId.Item:
                    obj = new WowItem();
                    break;
                case ObjectTypeId.Object:
                default:
                    throw new Exception("Cannot instantiate an object with TypeId=" + type);
                case ObjectTypeId.Player:
                    obj = new WowPlayer();
                    break;
                case ObjectTypeId.Unit:
                    obj = new WowUnit();
                    break;
                case ObjectTypeId.AreaTrigger:
                    obj = new WowAreaTrigger();
                    break;
            }

            obj.Guid = guid;
            obj.MovementData = new MovementInfo(Reader);
            obj.SetValues(ReadValues(Reader));
            obj.ResetUpdatedFields();

            if (!m_createdObjects.ContainsKey(guid))
                m_createdObjects.Add(guid, obj);
            else
                Console.WriteLine("Error: Created object duplicate guid {0}", guid);
        }

        private void ReadObjectDestroyUpdate(StreamHandler Reader)
        {
            uint nObjects = Reader.ReadUInt32();
            for (var i = 0; i < nObjects; ++i)
                m_destroyedObjects.Add(Reader.ReadPackedGuid());
        }

        private UpdateFields ReadValues(StreamHandler Reader)
        {
            var values = new UpdateFields();

            byte blocksCount = Reader.ReadByte();
            int[] updatemask = new int[blocksCount];

            for (int i = 0; i < updatemask.Length; ++i)
                updatemask[i] = Reader.ReadInt32();

            var mask = new BitArray(updatemask);

            for (uint i = 0; i < mask.Count; ++i)
                if (mask[(int)i])
                    values[i] = Reader.ReadUInt32();

            return values;
        }

        public override void Save(StreamHandler Writer)
        {
            Writer.WriteUInt16((ushort)this.Map);

            EnsureRead();

            long nUpdatesPos = Writer.BaseStream.Position;
            uint nUpdates = 0;
            Writer.WriteUInt32(nUpdates);

            if (this.DestroyedObjects.Count > 0)
            {
                ++nUpdates;
                Writer.WriteByte((byte)UpdateTypes.DestroyObjects);

                Writer.WriteInt32(this.DestroyedObjects.Count);
                foreach (WowGuid guid in this.DestroyedObjects)
                    Writer.WritePackedGuid(guid);
            }

            foreach (var pair in this.ValuesUpdates)
            {
                ++nUpdates;
                Writer.WriteByte((byte)UpdateTypes.UpdateValues);

                Writer.WritePackedGuid(pair.Key);
                WriteValues(Writer, pair.Value, WowObject.GetTypeId(pair.Key.Type));
            }

            foreach (var pair in this.CreatedObjects)
            {
                ++nUpdates;
                var type = UpdateTypes.CreateObjects;

                var obj = pair.Value;

                if (obj.MovementData.HavePosition)
                {
                    if (obj.TypeId == ObjectTypeId.DynamicObject
                        || obj.TypeId == ObjectTypeId.Corpse
                        || obj.TypeId == ObjectTypeId.Player)
                    {
                        type = UpdateTypes.CreateObjects2;
                    }

                    if (obj.TypeId == ObjectTypeId.GameObject && obj is WowGameObject)
                    {
                        switch ((obj as WowGameObject).GameObjectType)
                        {
                            case GameObjectTypes.Trap:
                            case GameObjectTypes.DuelArbiter:
                            case GameObjectTypes.FlagStand:
                            case GameObjectTypes.FlagDrop:
                                type = UpdateTypes.CreateObjects2;
                                break;
                        }
                    }
                }

                var guid = obj.Guid;

                Writer.WriteByte((byte)type);
                Writer.WritePackedGuid(guid);
                Writer.WriteByte((byte)obj.TypeId);
                obj.MovementData.Save(Writer);
                WriteValues(Writer, obj.GetValues(), obj.TypeId);
            }

            long pos = Writer.BaseStream.Position;
            Writer.BaseStream.Position = nUpdatesPos;
            Writer.WriteUInt32(nUpdates);
            Writer.BaseStream.Position = pos;
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_UPDATE_OBJECT, TransferDirection.ToClient);
        }

        private void WriteValues(StreamHandler Writer, UpdateFields values, ObjectTypeId type)
        {
            uint nValueUpdates = UpdateFields.GetCount(type, values.Last().Key);
            byte nBlocks = (byte)((nValueUpdates + 31) / 32);
            BitArray mask = new BitArray(nBlocks * 32);

            foreach (int key in values.Keys)
                mask[key] = true;

            // Write block count
            Writer.WriteByte(nBlocks);

            // Write all blocks
            int index = 0;
            for (byte i = 0; i < nBlocks; ++i)
            {
                uint block = 0;
                uint bit = 1;

                for (int j = 0; j < 32; ++j)
                {
                    if (mask[index])
                        block |= bit;

                    ++index;
                    bit <<= 1;
                }

                Writer.WriteUInt32(block);
            }

            // Write all values
            foreach (uint value in values.Values)
                Writer.WriteUInt32(value);
        }

        private void PrintValues(System.Text.StringBuilder builder, UpdateFields values, ObjectTypeId type)
        {
            foreach (var pair in values)
            {
                var uf = UpdateFields.GetUpdateField(pair.Key, type);

                if (uf.Type == UpdateFieldType.Long && uf.Id.ToString().EndsWith("_HIPART"))
                    continue;

                builder.Append("    ");
                builder.Append(uf.Id);
                builder.Append(" = ");

                if (uf.Type == UpdateFieldType.Long && values.ContainsKey(pair.Key + 1))
                    builder.Append(uf.Print(((ulong)values[pair.Key + 1] << 32) | (ulong)pair.Value));
                else
                    builder.Append(uf.Print(pair.Value));

                builder.AppendLine();
            }
        }

        //private void PrintValues(System.Text.StringBuilder builder, UpdateFields values, HighGuid high)
        //{
        //    PrintValues(builder, values, WowObject.GetTypeId(high));
        //}

        public override void ToString(System.Text.StringBuilder builder)
        {
            builder.AppendLine("Map: " + this.Map.GetLocalizedName());

            builder.AppendLine();
            builder.AppendLine("Destroyed Objects: " + this.DestroyedObjects.Count);
            foreach (var guid in this.m_destroyedObjects)
                builder.AppendLine("  " + guid);

            builder.AppendLine();
            builder.AppendLine("Created Objects: " + this.m_createdObjects.Count);
            foreach (var obj in this.m_createdObjects.Values)
            {
                builder.AppendLine("  ________________________________________");
                builder.AppendLine("  " + obj.Guid + "   Type: " + obj.TypeId);
                builder.AppendLine("    Movement: " + obj.MovementData.ToString().PadMultiline(4));
                PrintValues(builder, obj.GetValues(), obj.TypeId);
            }

            builder.AppendLine("Updated Objects: " + this.m_valuesUpdates.Count);
            foreach (var pair in this.m_valuesUpdates)
            {
                builder.AppendLine("  " + pair.Key);
                PrintValues(builder, pair.Value, WowObject.GetTypeId(pair.Key.Type));
                builder.AppendLine();
            }
        }
    }
}
