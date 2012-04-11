using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCollisionHeight : ForceChangePacket
    {
        public byte UnkByte { get; set; }

        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 6, 3, 5, -3, 3, 1, 2, 0, 7 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 1, 3, 2, 0, -1, -2, 4, 6, 5, 7 }; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            if (index == -3)
                this.UnkByte = reader.UnalignedReadTinyInt(2);
            else
                base.ElementRead(reader, index);
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            if (index == -3)
                writer.UnalignedWriteInt(this.UnkByte, 2);
            else
                base.ElementWrite(writer, index);
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_COLLISION_HEIGHT; }
        }

        public override void ToString(System.Text.StringBuilder builder)
        {
            base.ToString(builder);

            builder.AppendLine("Unk Byte: " + this.UnkByte);
        }
    }
}
