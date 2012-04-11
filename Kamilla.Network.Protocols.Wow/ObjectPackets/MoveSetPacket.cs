using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class MoveSetPacket : RegularMovementPacket, IValueChange
    {
        public float NewValue { get; set; }

        protected override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
        }

        protected override void ReadElement(StreamHandler reader, MovementStatusElements element, MovementStatus status, byte[] guid, byte[] tguid)
        {
            if (element == MovementStatusElements.GenericDword0)
                this.NewValue = reader.ReadSingle();
            else
                base.ReadElement(reader, element, status, guid, tguid);
        }

        protected override void WriteElement(StreamHandler writer, RegularMovementPacket.MovementStatusElements element, MovementStatus status, byte[] guid, byte[] tguid)
        {
            if (element == MovementStatusElements.GenericDword0)
            {
                writer.FlushUnalignedBits();
                writer.WriteSingle(this.NewValue);
            }
            else
                base.WriteElement(writer, element, status, guid, tguid);
        }

        public override void ToString(StringBuilder builder)
        {
            base.ToString(builder);

            builder
                .AppendLine()
                .Append("New Value: ").AppendLine(this.NewValue.ToString(CultureInfo.InvariantCulture));
        }
    }
}
