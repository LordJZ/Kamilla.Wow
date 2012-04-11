using System;
using System.Collections.Generic;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <summary>
    /// Contains all data related to spell targeting.
    /// </summary>
    public struct SpellTargetData
    {
        public SpellCastTargetFlags Flags;
        public WowGuid TargetUnit;
        public WowGuid TargetItem;
        public WowGuid SourceTransportGuid;
        public Vector3 SourceLocation;
        public WowGuid DestTransportGuid;
        public Vector3 DestLocation;
        public String StringTarget;

        public void Read(StreamHandler Reader)
        {
            Flags = (SpellCastTargetFlags)Reader.ReadUInt32();

            if ((Flags & (
                SpellCastTargetFlags.Unit   | SpellCastTargetFlags.Unk2 |
                SpellCastTargetFlags.Object |
                SpellCastTargetFlags.Corpse | SpellCastTargetFlags.PvPCorpse
                )) != 0)
                TargetUnit = Reader.ReadPackedGuid();

            if ((Flags & (SpellCastTargetFlags.Item | SpellCastTargetFlags.TradeItem)) != 0)
                TargetItem = Reader.ReadPackedGuid();

            if ((Flags & SpellCastTargetFlags.SourceLocation) != 0)
            {
                SourceTransportGuid = Reader.ReadPackedGuid();
                SourceLocation = Reader.ReadVector3();
            }

            if ((Flags & SpellCastTargetFlags.DestLocation) != 0)
            {
                DestTransportGuid = Reader.ReadPackedGuid();
                DestLocation = Reader.ReadVector3();
            }

            if ((Flags & SpellCastTargetFlags.String) != 0)
                StringTarget = Reader.ReadCString();
        }

        public void Write(StreamHandler Writer)
        {
            Writer.WriteUInt32((uint)Flags);

            if ((Flags & (
                SpellCastTargetFlags.Unit | SpellCastTargetFlags.Unk2 |
                SpellCastTargetFlags.Object |
                SpellCastTargetFlags.Corpse | SpellCastTargetFlags.PvPCorpse
                )) != 0)
                Writer.WritePackedGuid(TargetUnit);

            if ((Flags & (SpellCastTargetFlags.Item | SpellCastTargetFlags.TradeItem)) != 0)
                Writer.WritePackedGuid(TargetItem);

            if ((Flags & SpellCastTargetFlags.SourceLocation) != 0)
            {
                Writer.WritePackedGuid(SourceTransportGuid);
                Writer.WriteStruct<Vector3>(SourceLocation);
            }

            if ((Flags & SpellCastTargetFlags.DestLocation) != 0)
            {
                Writer.WritePackedGuid(DestTransportGuid);
                Writer.WriteStruct<Vector3>(DestLocation);
            }

            if ((Flags & SpellCastTargetFlags.String) != 0)
                Writer.WriteCString(StringTarget);
        }

        public void ToString(StringBuilder builder)
        {
            builder.AppendLine("Target Flags: " + Flags);
            if ((Flags & (
                SpellCastTargetFlags.Unit | SpellCastTargetFlags.Unk2 |
                SpellCastTargetFlags.Object |
                SpellCastTargetFlags.Corpse | SpellCastTargetFlags.PvPCorpse
                )) != 0)
                builder.AppendLine("Target Unit: " + TargetUnit);

            if ((Flags & (SpellCastTargetFlags.Item | SpellCastTargetFlags.TradeItem)) != 0)
                builder.AppendLine("Target Item: " + TargetItem);

            if ((Flags & SpellCastTargetFlags.SourceLocation) != 0)
            {
                builder.AppendLine("Source Transport: " + SourceTransportGuid);
                builder.AppendLine("Source Location: " + SourceLocation);
            }

            if ((Flags & SpellCastTargetFlags.DestLocation) != 0)
            {
                builder.AppendLine("Dest Transport: " + DestTransportGuid);
                builder.AppendLine("Dest Location: " + DestLocation);
            }

            if ((Flags & SpellCastTargetFlags.String) != 0)
                builder.AppendLine("String Target: " + StringTarget);
        }
    }

    /// <summary>
    /// Represents a single spell cast action, sent by the client to the server.
    /// </summary>
    public sealed class SpellCast : LazyObjectPacket
    {
        // LEVEL 1
        public byte CastId
        {
            get { EnsureRead(1); return m_castId; }
            set { m_castId = value; }
        }
        public uint SpellId
        {
            get { EnsureRead(1); return m_spellId; }
            set { m_spellId = value; }
        }
        public uint UnknownId
        {
            get { EnsureRead(1); return m_unkId; }
            set { m_unkId = value; }
        }
        public byte UnknownFlags
        {
            get { EnsureRead(1); return m_unkFlags; }
            set { m_unkFlags = value; }
        }

        // LEVEL 2
        public SpellTargetData TargetData
        {
            get { EnsureRead(2); return m_targetData; }
            set { m_targetData = value; }
        }

        private byte m_castId;
        private uint m_spellId;
        private uint m_unkId;
        /* f & 2 => float, float, movementStatus
         * f & 8 => uint32 x,
         *          if (x >= 1) { uint8 2, uint32 ResearchBranch+20, uint32 count? },
         *          if (x >= 2) { uint8 1, uint32 ResearchBranch+12, uint32 count? }
         */
        private byte m_unkFlags;

        private SpellTargetData m_targetData;

        /// <summary>
        /// Initializes a new instance of SpellCast class.
        /// </summary>
        /// <param name="spellId">The spell id to use.</param>
        public SpellCast(uint spellId)
        {
            m_castId = 1;
            m_spellId = spellId;

            m_targetData = new SpellTargetData();

            SetRead();
        }

        /// <summary>
        /// Initializes a new instance of SpellCast class,
        /// reading all the needed information from a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="Reader">The StreamHandler used to read data from.</param>
        /// <param name="LazyReading">Indicates whether lazy reading should be used or not.</param>
        public SpellCast(StreamHandler Reader, bool LazyReading)
        {
            this.Reader = Reader;

            m_readers = new Action[]
                {
                    ReadBase,
                    ReadTargetData,
                };

            if (!LazyReading)
                EnsureRead();
        }

        private void ReadBase()
        {
            m_castId = Reader.ReadByte();
            m_spellId = Reader.ReadUInt32();
            m_unkId = Reader.ReadUInt32();
            m_unkFlags = Reader.ReadByte();
        }

        private void ReadTargetData()
        {
            m_targetData.Read(Reader);
        }

        /// <summary>
        /// Saves the current instance of SpellCast class to a StreamHandler, using the provided target flags.
        /// </summary>
        /// <param name="writer">The StreamHandler to use.</param>
        public override void Save(StreamHandler writer)
        {
            writer.WriteByte(CastId);
            writer.WriteUInt32(SpellId);
            writer.WriteUInt32(UnknownId);
            writer.WriteByte(UnknownFlags);

            TargetData.Write(writer);
        }

        /// <summary>
        /// Creates a packet representing the current spell cast, regenerating TargetFlags using provided data.
        /// </summary>
        /// <returns>
        /// An instance of CustomPacket class that contains the data of current SpellCast.
        /// </returns>
        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_CAST_SPELL, TransferDirection.ToServer);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Cast Id: " + CastId);
            builder.AppendLine("Spell Id: " + SpellId);
            builder.AppendLine("Unk Id: " + UnknownId);
            builder.AppendFormatLine("Unk Flags: {0:X2}", UnknownFlags);

            TargetData.ToString(builder);
        }
    }


    /// <summary>
    /// Represents a single spell go action, sent by the server to the client.
    /// </summary>
    public sealed class SpellGo : ObjectPacket
    {
        public struct MissData
        {
            public WowGuid TargetGuid;
            public CastMissReason MissCondition;
            public byte ReflectResult;

            public void Write(StreamHandler Writer)
            {
                Writer.WriteGuid(TargetGuid);
                Writer.WriteByte((byte)MissCondition);
                if (MissCondition == CastMissReason.Reflect)
                    Writer.WriteByte(ReflectResult);
            }

            public void Read(StreamHandler Reader)
            {
                TargetGuid = Reader.ReadGuid();
                MissCondition = (CastMissReason)Reader.ReadByte();
                if (MissCondition == CastMissReason.Reflect)
                    ReflectResult = Reader.ReadByte();
            }

            public override string ToString()
            {
                return "Guid: " + TargetGuid + " Reason: " + MissCondition
                    + (MissCondition == CastMissReason.Reflect ? " Reflected: " + ReflectResult : "");
            }
        }

        // LEVEL 1
        public WowGuid Caster;
        public WowGuid CastInvoker;
        public byte CastId;
        public uint SpellId;
        public CastFlags Flags;
        public uint CastTime;
        public uint Unk43;

        public List<WowGuid> Hits = new List<WowGuid>();
        public List<MissData> Misses = new List<MissData>();

        public SpellTargetData TargetData = new SpellTargetData();

        public uint PredictedPower;
        public RuneStates RunesBefore;
        public RuneStates RunesAfter;
        public uint[] RuneCooldowns = new uint[6];

        public float Unk0x20000_Float;
        public uint Unk0x20000_UInt32;

        public uint ProjectileDisplayId;
        public InventorySlotType ProjectileInventoryType;

        public uint Unk0x80000_UInt32_1;
        public uint Unk0x80000_UInt32_2;

        public byte DestLocationCounter;

        public uint Unk4_Count;
        public List<KeyValuePair<WowGuid, Vector3>> Unk4_List = new List<KeyValuePair<WowGuid, Vector3>>();

        /// <summary>
        /// Initializes a new instance of SpellGo class.
        /// </summary>
        /// <param name="caster">
        /// Guid of the caster unit.
        /// </param>
        /// <param name="spellId">
        /// The spell id to use.
        /// </param>
        public SpellGo(WowGuid caster, uint spellId)
        {
            Caster = caster;
            CastInvoker = caster;
            CastId = 1;
            SpellId = spellId;
            Flags = CastFlags.None;
            CastTime = (uint)Environment.TickCount;
        }

        /// <summary>
        /// Initializes a new instance of SpellGo class,
        /// reading all the needed information from a <see cref="StreamHandler"/>.
        /// </summary>
        /// <param name="Reader">The StreamHandler used to read data from.</param>
        public SpellGo(StreamHandler Reader)
        {
            Read(Reader);
        }

        public override void Read(StreamHandler Reader)
        {
            Caster = Reader.ReadPackedGuid();
            CastInvoker = Reader.ReadPackedGuid();
            CastId = Reader.ReadByte();
            SpellId = Reader.ReadUInt32();
            Flags = (CastFlags)Reader.ReadUInt32();
            Unk43 = Reader.ReadUInt32();
            CastTime = Reader.ReadUInt32();

            byte hits = Reader.ReadByte();
            Hits.Capacity = hits;
            for (byte i = 0; i < hits; ++i)
                Hits.Add(Reader.ReadGuid());

            byte misses = Reader.ReadByte();
            Misses.Capacity = misses;
            for (byte i = 0; i < misses; ++i)
            {
                var miss = new MissData();
                miss.Read(Reader);
                Misses.Add(miss);
            }

            TargetData.Read(Reader);

            if ((Flags & CastFlags.PredictedPower) != 0)
                PredictedPower = Reader.ReadUInt32();

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                RunesBefore = (RuneStates)Reader.ReadByte();
                RunesAfter = (RuneStates)Reader.ReadByte();
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    RuneCooldowns[i] = Reader.ReadByte();
            }

            if ((Flags & CastFlags.Unk0x00020000) != 0)
            {
                Unk0x20000_Float = Reader.ReadSingle();
                Unk0x20000_UInt32 = Reader.ReadUInt32();
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                ProjectileDisplayId = Reader.ReadUInt32();
                ProjectileInventoryType = (InventorySlotType)Reader.ReadUInt32();
            }

            if ((Flags & CastFlags.Unk0x00080000) != 0)
            {
                Unk0x80000_UInt32_1 = Reader.ReadUInt32();
                Unk0x80000_UInt32_2 = Reader.ReadUInt32();
            }

            if ((TargetData.Flags & SpellCastTargetFlags.DestLocation) != 0)
                DestLocationCounter = Reader.ReadByte();

            if ((TargetData.Flags & SpellCastTargetFlags.Unk4) != 0)
            {
                uint count = Reader.ReadUInt32();
                Unk4_Count = count;
                Unk4_List.Capacity = (int)count;

                for (uint i = 0; i < count; ++i)
                {
                    Vector3 v3 = Reader.ReadVector3();
                    WowGuid guid = Reader.ReadGuid();
                    Unk4_List.Add(new KeyValuePair<WowGuid, Vector3>(guid, v3));
                    if (guid.IsEmpty)
                        break;
                }
            }
        }

        /// <summary>
        /// Saves the current instance of SpellGo class to a StreamHandler.
        /// </summary>
        /// <param name="Writer">The StreamHandler to use.</param>
        public override void Save(StreamHandler Writer)
        {
            Writer.WritePackedGuid(Caster);
            Writer.WritePackedGuid(CastInvoker);
            Writer.WriteByte(CastId);
            Writer.WriteUInt32(SpellId);
            Writer.WriteUInt32((uint)Flags);
            Writer.WriteUInt32(Unk43);
            Writer.WriteUInt32(CastTime);

            Writer.WriteByte((byte)Hits.Count);
            foreach (WowGuid guid in Hits)
                Writer.WriteGuid(guid);

            Writer.WriteByte((byte)Misses.Count);
            foreach (MissData miss in Misses)
                miss.Write(Writer);

            TargetData.Write(Writer);

            if ((Flags & CastFlags.PredictedPower) != 0)
                Writer.WriteUInt32(PredictedPower);

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                Writer.WriteByte((byte)RunesBefore);
                Writer.WriteByte((byte)RunesAfter);
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    Writer.WriteByte((byte)RuneCooldowns[i]);
            }

            if ((Flags & CastFlags.Unk0x00020000) != 0)
            {
                Writer.WriteSingle(Unk0x20000_Float);
                Writer.WriteUInt32(Unk0x20000_UInt32);
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                Writer.WriteUInt32(ProjectileDisplayId);
                Writer.WriteUInt32((uint)ProjectileInventoryType);
            }

            if ((Flags & CastFlags.Unk0x00080000) != 0)
            {
                Writer.WriteUInt32(Unk0x80000_UInt32_1);
                Writer.WriteUInt32(Unk0x80000_UInt32_2);
            }

            if ((TargetData.Flags & SpellCastTargetFlags.DestLocation) != 0)
            {
                Writer.WriteByte(DestLocationCounter);
            }

            if ((TargetData.Flags & SpellCastTargetFlags.Unk4) != 0)
            {
                Writer.WriteUInt32(Unk4_Count);
                foreach (var pair in Unk4_List)
                {
                    Writer.WriteStruct(pair.Value);
                    Writer.WriteGuid(pair.Key);
                    if (pair.Key.IsEmpty)
                        break;
                }
            }
        }

        /// <summary>
        /// Creates a packet representing the current spell cast, regenerating TargetFlags using provided data.
        /// </summary>
        /// <returns>
        /// An instance of CustomPacket class that contains the data of current SpellCast.
        /// </returns>
        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_SPELL_GO, TransferDirection.ToClient);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Caster: " + Caster);
            builder.AppendLine("Cast Invoker: " + CastInvoker);
            builder.AppendLine("Cast Id: " + CastId);
            builder.AppendLine("Spell Id: " + SpellId);
            builder.AppendLine("Flags: " + Flags);
            builder.AppendLine("Cast Time: " + CastTime);
            builder.AppendLine("Unk 4.3: " + Unk43);
            builder.AppendLine();

            builder.AppendLine("Total Hits: " + Hits.Count);
            foreach (WowGuid guid in Hits)
                builder.AppendLine("    " + guid);

            builder.AppendLine("Total Misses: " + Misses.Count);
            foreach (MissData miss in Misses)
                builder.AppendLine("    " + miss);

            builder.AppendLine();
            TargetData.ToString(builder);

            if ((Flags & CastFlags.PredictedPower) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Predicted Power: " + PredictedPower);
            }

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Runes Before: " + RunesBefore);
                builder.AppendLine("Runes After: " + RunesAfter);
                builder.Append("Rune Cooldowns: ");
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    builder.Append(RuneCooldowns[i] + " ");
                builder.AppendLine();
            }

            if ((Flags & CastFlags.Unk0x00020000) != 0)
            {
                builder.AppendLine();
                builder.AppendFormatLine("Flags 0x20000: float={0}, uint32={1}", Unk0x20000_Float, Unk0x20000_UInt32);
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                builder.AppendLine();
                builder.AppendFormatLine("Projectile: DisplayId {0}, Inventory Type {1}",
                    ProjectileDisplayId, ProjectileInventoryType);
            }

            if ((Flags & CastFlags.Unk0x00080000) != 0)
            {
                builder.AppendLine();
                builder.AppendFormatLine("Flags 0x80000: uint32={0}, uint32={1}", Unk0x80000_UInt32_1, Unk0x80000_UInt32_2);
            }

            if ((TargetData.Flags & SpellCastTargetFlags.DestLocation) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Dest Location Counter: " + DestLocationCounter);
            }

            if ((TargetData.Flags & SpellCastTargetFlags.Unk4) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Unk4_Count: " + Unk4_Count);
                foreach (var pair in Unk4_List)
                {
                    builder.AppendFormatLine("  Vector3: {0}   Guid: {1}", pair.Value, pair.Key);
                    if (pair.Key.IsEmpty)
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Represents a single spell start action, sent by the server to the client.
    /// </summary>
    public sealed class SpellStart : ObjectPacket
    {
        public WowGuid Caster;
        public WowGuid CastInvoker;
        public byte CastId;
        public uint SpellId;
        public CastFlags Flags;
        public uint Unk43_2;
        public uint Unk43;

        public SpellTargetData TargetData = new SpellTargetData();

        public uint PredictedPower;
        public RuneStates RunesBefore;
        public RuneStates RunesAfter;
        public uint[] RuneCooldowns = new uint[6];

        public uint ProjectileDisplayId;
        public InventorySlotType ProjectileInventoryType;

        public uint Unk0x04000000_UInt32_1;
        public uint Unk0x04000000_UInt32_2;

        public override void Read(StreamHandler Reader)
        {
            Caster = Reader.ReadPackedGuid();
            CastInvoker = Reader.ReadPackedGuid();
            CastId = Reader.ReadByte();
            SpellId = Reader.ReadUInt32();
            Flags = (CastFlags)Reader.ReadUInt32();
            Unk43 = Reader.ReadUInt32();
            Unk43_2 = Reader.ReadUInt32();

            TargetData.Read(Reader);

            if ((Flags & CastFlags.PredictedPower) != 0)
                PredictedPower = Reader.ReadUInt32();

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                RunesBefore = (RuneStates)Reader.ReadByte();
                RunesAfter = (RuneStates)Reader.ReadByte();
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    RuneCooldowns[i] = Reader.ReadByte();
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                ProjectileDisplayId = Reader.ReadUInt32();
                ProjectileInventoryType = (InventorySlotType)Reader.ReadUInt32();
            }

            if ((Flags & CastFlags.Unk0x04000000) != 0)
            {
                Unk0x04000000_UInt32_1 = Reader.ReadUInt32();
                Unk0x04000000_UInt32_2 = Reader.ReadUInt32();
            }
        }

        public override void Save(StreamHandler Writer)
        {
            Writer.WritePackedGuid(Caster);
            Writer.WritePackedGuid(CastInvoker);
            Writer.WriteByte(CastId);
            Writer.WriteUInt32(SpellId);
            Writer.WriteUInt32((uint)Flags);
            Writer.WriteUInt32(Unk43);
            Writer.WriteUInt32(Unk43_2);

            TargetData.Write(Writer);

            if ((Flags & CastFlags.PredictedPower) != 0)
                Writer.WriteUInt32(PredictedPower);

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                Writer.WriteByte((byte)RunesBefore);
                Writer.WriteByte((byte)RunesAfter);
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    Writer.WriteByte((byte)RuneCooldowns[i]);
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                Writer.WriteUInt32(ProjectileDisplayId);
                Writer.WriteUInt32((uint)ProjectileInventoryType);
            }

            if ((Flags & CastFlags.Unk0x04000000) != 0)
            {
                Writer.WriteUInt32(Unk0x04000000_UInt32_1);
                Writer.WriteUInt32(Unk0x04000000_UInt32_2);
            }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_SPELL_START, TransferDirection.ToClient);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Caster: " + Caster);
            builder.AppendLine("Cast Invoker: " + CastInvoker);
            builder.AppendLine("Cast Id: " + CastId);
            builder.AppendLine("Spell Id: " + SpellId);
            builder.AppendLine("Flags: " + Flags);
            builder.AppendLine("Unk 4.3 2: " + Unk43_2);
            builder.AppendLine("Unk 4.3: " + Unk43);
            builder.AppendLine();

            TargetData.ToString(builder);

            if ((Flags & CastFlags.PredictedPower) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Predicted Power: " + PredictedPower);
            }

            if ((Flags & CastFlags.RuneStates) != 0)
            {
                builder.AppendLine();
                builder.AppendLine("Runes Before: " + RunesBefore);
                builder.AppendLine("Runes After: " + RunesAfter);
                builder.Append("Rune Cooldowns: ");
                for (int i = 0; i < RuneCooldowns.Length; ++i)
                    builder.Append(RuneCooldowns[i] + " ");
                builder.AppendLine();
            }

            if ((Flags & CastFlags.Ammo) != 0)
            {
                builder.AppendLine();
                builder.AppendFormatLine("Projectile: DisplayId {0}, Inventory Type {1}",
                    ProjectileDisplayId, ProjectileInventoryType);
            }

            if ((Flags & CastFlags.Unk0x04000000) != 0)
            {
                builder.AppendLine();
                builder.AppendFormatLine("Flags 0x04000000: uint32={0}, uint32={1}", Unk0x04000000_UInt32_1, Unk0x04000000_UInt32_2);
            }
        }
    }
}
