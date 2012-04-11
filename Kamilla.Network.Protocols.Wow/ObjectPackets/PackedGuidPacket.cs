using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class PackedGuidPacket : PackedData
    {
        public WowGuid Guid { get; set; }

        public abstract WowOpcodes Opcode { get; }
        public abstract TransferDirection Direction { get; }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        protected sealed override void ElementRead(StreamHandler reader, int index)
        {
            base.ElementRead(reader, index);
        }

        protected sealed override void ElementWrite(StreamHandler writer, int index)
        {
            base.ElementWrite(writer, index);
        }

        protected sealed override void PackedRead(StreamHandler reader)
        {
            this.Guid = reader.ReadGuid();
        }

        protected sealed override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(this.Guid);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.Append("Guid: ").AppendLine(this.Guid.ToString());
        }

        public sealed override CustomPacket CreatePacket()
        {
            return base.CreatePacket(this.Opcode, this.Direction);
        }
    }
}
