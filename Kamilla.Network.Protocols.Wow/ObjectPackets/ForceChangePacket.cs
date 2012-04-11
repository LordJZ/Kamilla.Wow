using System.Globalization;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class ForceChangePacket : ForcePacket, IChange, IValueChange
    {
        public float NewValue { get; set; }

        public abstract WowOpcodes Opcode { get; }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(this.Opcode, TransferDirection.ToClient);
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            if (index == -2)
                this.NewValue = reader.ReadSingle();
            else
                base.ElementRead(reader, index);
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            if (index == -2)
            {
                writer.FlushUnalignedBits();
                writer.WriteSingle(this.NewValue);
            }
            else
                base.ElementWrite(writer, index);
        }

        public override void ToString(StringBuilder builder)
        {
            base.ToString(builder);

            builder
                .Append("New Value: ").AppendLine(this.NewValue.ToString(CultureInfo.InvariantCulture));
        }
    }
}
