using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class SplineSetPacket : PackedData, IValueChange
    {
        public WowGuid Unit { get; set; }
        public float NewValue { get; set; }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        protected override bool IsMaskSequenceSwapped
        {
            get
            {
                return false;
            }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            this.NewValue = reader.ReadSingle();
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            writer.WriteSingle(this.NewValue);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            this.Unit = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(this.Unit);
        }

        public override void ToString(StringBuilder builder)
        {
            builder
                .Append("Unit: ").AppendLine(this.Unit.ToString())
                .Append("New Value: ").AppendLine(this.NewValue.ToString(CultureInfo.InvariantCulture));
        }

        public abstract WowOpcodes Opcode { get; }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(this.Opcode, TransferDirection.ToClient);
        }
    }
}
