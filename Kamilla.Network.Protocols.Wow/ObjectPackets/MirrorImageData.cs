using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class MirrorImageData : ObjectPacket
    {
        public WowGuid Entity { get; set; }
        public uint Model { get; set; }
        public Races Race { get; set; }
        public Genders Gender { get; set; }
        public Classes Class { get; set; }
        public byte Skin { get; set; }
        public byte Face { get; set; }
        public byte Hair { get; set; }
        public byte HairColor { get; set; }
        public byte FaceFeatures { get; set; }
        public WowGuid Guild { get; set; }
        public uint Head { get; set; }
        public uint Shoulders { get; set; }
        public uint Body { get; set; }
        public uint Chest { get; set; }
        public uint Waist { get; set; }
        public uint Legs { get; set; }
        public uint Feet { get; set; }
        public uint Wrists { get; set; }
        public uint Hands { get; set; }
        public uint Back { get; set; }
        public uint Tabard { get; set; }

        public MirrorImageData()
        {
        }

        public MirrorImageData(WowPlayer source, WowGuid destination)
        {
            this.Entity = destination;
            this.Model = source.Model;
            this.Race = source.Race;
            this.Gender = source.Gender;
            this.Class = source.Class;
            this.Skin = source.Skin;
            this.Face = source.Face;
            this.Hair = source.HairStyle;
            this.HairColor = source.HairColor;
            this.FaceFeatures = source.FaceFeatures;
            this.Guild = new WowGuid(source.GetULong(ObjectUpdateFields.OBJECT_FIELD_DATA));

            this.Head = source.GetVisibleItemEntry(InventorySlot.Head);
            this.Shoulders = source.GetVisibleItemEntry(InventorySlot.Shoulders);
            this.Body = source.GetVisibleItemEntry(InventorySlot.Body);
            this.Chest = source.GetVisibleItemEntry(InventorySlot.Chest);
            this.Waist = source.GetVisibleItemEntry(InventorySlot.Waist);
            this.Legs = source.GetVisibleItemEntry(InventorySlot.Legs);
            this.Feet = source.GetVisibleItemEntry(InventorySlot.Feet);
            this.Wrists = source.GetVisibleItemEntry(InventorySlot.Wrists);
            this.Hands = source.GetVisibleItemEntry(InventorySlot.Hands);
            this.Back = source.GetVisibleItemEntry(InventorySlot.Back);
            this.Tabard = source.GetVisibleItemEntry(InventorySlot.Tabard);
        }

        public override void Read(StreamHandler reader)
        {
            Entity = reader.ReadGuid();
            Model = reader.ReadUInt32();
            Race = (Races)reader.ReadByte();
            Gender = (Genders)reader.ReadByte();
            Class = (Classes)reader.ReadByte();
            Skin = reader.ReadByte();
            Face = reader.ReadByte();
            Hair = reader.ReadByte();
            HairColor = reader.ReadByte();
            FaceFeatures = reader.ReadByte();
            Guild = reader.ReadGuid();
            Head = reader.ReadUInt32();
            Shoulders = reader.ReadUInt32();
            Body = reader.ReadUInt32();
            Chest = reader.ReadUInt32();
            Waist = reader.ReadUInt32();
            Legs = reader.ReadUInt32();
            Feet = reader.ReadUInt32();
            Wrists = reader.ReadUInt32();
            Hands = reader.ReadUInt32();
            Back = reader.ReadUInt32();
            Tabard = reader.ReadUInt32();
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteGuid(Entity);
            writer.WriteUInt32(Model);
            writer.WriteByte((byte)Race);
            writer.WriteByte((byte)Gender);
            writer.WriteByte((byte)Class);
            writer.WriteByte(Skin);
            writer.WriteByte(Face);
            writer.WriteByte(Hair);
            writer.WriteByte(HairColor);
            writer.WriteByte(FaceFeatures);
            writer.WriteGuid(Guild);
            writer.WriteUInt32(Head);
            writer.WriteUInt32(Shoulders);
            writer.WriteUInt32(Body);
            writer.WriteUInt32(Chest);
            writer.WriteUInt32(Waist);
            writer.WriteUInt32(Legs);
            writer.WriteUInt32(Feet);
            writer.WriteUInt32(Wrists);
            writer.WriteUInt32(Hands);
            writer.WriteUInt32(Back);
            writer.WriteUInt32(Tabard);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Entity: " + Entity);
            builder.AppendLine("Model: " + Model);
            builder.AppendLine();
            builder.AppendLine("Race: " + Race);
            builder.AppendLine("Gender: " + Gender);
            builder.AppendLine("Class: " + Class);
            builder.AppendLine();
            builder.AppendLine("Skin: " + Skin);
            builder.AppendLine("Face: " + Face);
            builder.AppendLine("Hair: " + Hair);
            builder.AppendLine("HairColor: " + HairColor);
            builder.AppendLine("FaceFeatures: " + FaceFeatures);
            builder.AppendLine();
            builder.AppendLine("Guild: " + Guild);
            builder.AppendLine();
            builder.AppendLine("Head: " + Head);
            builder.AppendLine("Shoulders: " + Shoulders);
            builder.AppendLine("Body: " + Body);
            builder.AppendLine("Chest: " + Chest);
            builder.AppendLine("Waist: " + Waist);
            builder.AppendLine("Legs: " + Legs);
            builder.AppendLine("Feet: " + Feet);
            builder.AppendLine("Wrists: " + Wrists);
            builder.AppendLine("Hands: " + Hands);
            builder.AppendLine("Back: " + Back);
            builder.AppendLine("Tabard: " + Tabard);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MIRRORIMAGE_DATA, TransferDirection.ToClient);
        }
    }
}
