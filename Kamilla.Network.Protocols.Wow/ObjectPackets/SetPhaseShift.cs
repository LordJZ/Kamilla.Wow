using System;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SetPhaseShift : PackedData
    {
        public readonly byte[][] Data = new byte[4][];
        public WowGuid Guid;
        public uint Unk;

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 6, 3, 4, 1, 2, 0, 7 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 6, 5, -1, 3, 7, -2, -3, 2, 4, -5, 0, 1, -4 }; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            if (index == -5)
                this.Unk = reader.ReadUInt32();
            else
                this.Data[-index - 1] = reader.ReadBytes(reader.ReadInt32());
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            if (index == -5)
            {
                writer.WriteUInt32(this.Unk);
            }
            else
            {
                index = -index - 1;
                writer.WriteInt32(this.Data[index].Length);
                writer.WriteBytes(this.Data[index]);
            }
        }

        protected override void PackedRead(StreamHandler reader)
        {
            this.Guid = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(this.Guid);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_PHASE_SHIFT_CHANGE, TransferDirection.ToClient);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Guid: " + this.Guid);
            builder.AppendLine("Unk: " + this.Unk);

            for (int i = 0; i < this.Data.Length; ++i)
            {
                var arr = this.Data[i];
                if ((arr.Length & 1) == 0)
                {
                    builder.Append("Maps: ");
                    for (int j = 0; j < arr.Length; j += 2)
                        builder.Append(((Maps)BitConverter.ToUInt16(arr, j)).GetLocalizedName()).Append(j == arr.Length - 2 ? "" : ", ");
                    builder.AppendLine();
                }
                else
                    builder.AppendLine("Bytes: " + arr.ToHexString());
            }
        }
    }
}
