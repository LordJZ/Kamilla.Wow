using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ThreatRemove : ObjectPacket
    {
        public WowGuid Unit { get; set; }
        public WowGuid Victim { get; set; }

        public ThreatRemove()
        {
        }

        public ThreatRemove(WowGuid guid, WowGuid victim)
        {
            this.Unit = guid;
            this.Victim = victim;
        }

        public override void Read(StreamHandler reader)
        {
            this.Unit = reader.ReadPackedGuid();
            this.Victim = reader.ReadPackedGuid();
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteGuid(this.Unit);
            writer.WriteGuid(this.Victim);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.Append("Unit: ").AppendLine(Unit.ToString());
            builder.Append("Victim: ").AppendLine(Victim.ToString());
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_THREAT_REMOVE, TransferDirection.ToClient);
        }
    }
}
