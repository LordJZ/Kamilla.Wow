using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ThreatClear : ObjectPacket
    {
        public WowGuid Unit { get; set; }

        public ThreatClear()
        {
        }

        public ThreatClear(WowGuid guid)
        {
            this.Unit = guid;
        }

        public override void Read(StreamHandler reader)
        {
            this.Unit = reader.ReadPackedGuid();
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteGuid(this.Unit);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.Append("Unit: ").Append(Unit.ToString());
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_THREAT_CLEAR, TransferDirection.ToClient);
        }
    }
}
