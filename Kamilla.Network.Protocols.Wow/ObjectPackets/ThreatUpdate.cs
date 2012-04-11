using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public class ThreatUpdate : ObjectPacket
    {
        public struct ThreatUpdatePair
        {
            public WowGuid Unit;
            public uint Threat;
        }

        public WowGuid Unit { get; set; }
        public ThreatUpdatePair[] ThreatList { get; set; }

        public ThreatUpdate()
        {
            this.ThreatList = new ThreatUpdatePair[0];
        }

        public override void Read(StreamHandler reader)
        {
            this.Unit = reader.ReadPackedGuid();

            var count = reader.ReadInt32();
            this.ThreatList = new ThreatUpdatePair[count];
            for (int i = 0; i < count; ++i)
                this.ThreatList[i] = new ThreatUpdatePair { Unit = reader.ReadPackedGuid(), Threat = reader.ReadUInt32() };
        }

        public override void Save(StreamHandler writer)
        {
            writer.WritePackedGuid(this.Unit);
            writer.WriteInt32(ThreatList.Length);
            for (int i = 0; i < ThreatList.Length; ++i)
            {
                writer.WritePackedGuid(ThreatList[i].Unit);
                writer.WriteUInt32(ThreatList[i].Threat);
            }
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Aggressor: " + this.Unit);

            for (int i = 0; i < ThreatList.Length;++i)
                builder.AppendFormatLine("Threat: {0}   Unit: {1}", ThreatList[i].Threat, ThreatList[i].Unit);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_THREAT_UPDATE, TransferDirection.ToClient);
        }
    }
}
