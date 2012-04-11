using System.Globalization;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class ForceAckPacket : RegularMovementPacket, IChange
    {
        /// <summary>
        /// Gets or sets the change counter.
        /// </summary>
        public uint ChangeCounter { get; set; }

        protected sealed override TransferDirection Direction
        {
            get { return TransferDirection.ToServer; }
        }

        protected override void ReadElement(StreamHandler reader, MovementStatusElements element, MovementStatus status, byte[] guid, byte[] tguid)
        {
            if (element == MovementStatusElements.GenericDword0)
                this.ChangeCounter = reader.ReadUInt32();
            else
                base.ReadElement(reader, element, status, guid, tguid);
        }

        protected override void WriteElement(StreamHandler writer, RegularMovementPacket.MovementStatusElements element, MovementStatus status, byte[] guid, byte[] tguid)
        {
            if (element == MovementStatusElements.GenericDword0)
            {
                writer.FlushUnalignedBits();
                writer.WriteUInt32(this.ChangeCounter);
            }
            else
                base.WriteElement(writer, element, status, guid, tguid);
        }

        public override void ToString(StringBuilder builder)
        {
            base.ToString(builder);

            builder
                .AppendLine()
                .Append("Change Counter: ").AppendLine(this.ChangeCounter.ToString(CultureInfo.InvariantCulture));
        }
    }
}
