using System;
using System.Globalization;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class ForcePacket : PackedData, IChange
    {
        public WowGuid Player { get; set; }
        public uint ChangeCounter { get; set; }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            if (index == -1)
                this.ChangeCounter = reader.ReadUInt32();
            else
                throw new InvalidOperationException("Unknown read element: " + index);
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            if (index == -1)
            {
                writer.FlushUnalignedBits();
                writer.WriteUInt32(this.ChangeCounter);
            }
            else
                throw new InvalidOperationException("Unknown write element: " + index);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            this.Player = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(this.Player);
        }

        public override void ToString(StringBuilder builder)
        {
            builder
                .Append("Player: ").AppendLine(this.Player.ToString())
                .Append("Change Counter: ").AppendLine(this.ChangeCounter.ToString(CultureInfo.InvariantCulture));
        }
    }
}
