using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class UseItem : ObjectPacket
    {
        public InventorySlot ContainerSlot;
        public InventorySlot Slot;
        public byte CastId;
        public uint SpellId;
        public WowGuid ItemGuid;
        public uint GlyphSlot;
        public byte UnkFlags;
        public SpellTargetData TargetData = new SpellTargetData();

        public override void Read(StreamHandler reader)
        {
            ContainerSlot = (InventorySlot)reader.ReadByte();
            Slot = (InventorySlot)reader.ReadByte();
            CastId = reader.ReadByte();
            SpellId = reader.ReadUInt32();
            ItemGuid = reader.ReadGuid();
            GlyphSlot = reader.ReadUInt32();
            UnkFlags = reader.ReadByte();

            TargetData.Read(reader);
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteByte((byte)ContainerSlot);
            writer.WriteByte((byte)Slot);
            writer.WriteByte(CastId);
            writer.WriteUInt32(SpellId);
            writer.WriteGuid(ItemGuid);
            writer.WriteUInt32(GlyphSlot);
            writer.WriteByte(UnkFlags);

            TargetData.Write(writer);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_USE_ITEM, TransferDirection.ToServer);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendFormatLine("Container Slot: {0}, Slot: {1}", ContainerSlot, Slot);
            builder.AppendLine("Cast Id: " + CastId);
            builder.AppendLine("Spell Id: " + SpellId);
            builder.AppendLine("Item: "  + ItemGuid);
            builder.AppendLine("Glyph Index: " + GlyphSlot);
            builder.AppendLine("Unk Flags: " + UnkFlags);
            builder.AppendLine();
            TargetData.ToString(builder);
        }
    }
}
