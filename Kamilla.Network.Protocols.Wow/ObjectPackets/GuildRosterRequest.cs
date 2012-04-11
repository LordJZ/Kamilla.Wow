using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public class GuildRosterRequest : PackedData
    {
        public WowGuid PlayerGuid { get; set; }
        public WowGuid GuildGuid { get; set; }

        protected override int[] MaskSequence { get { return new int[] { 12, 11, 1, 6, 3, 7, 5, 9, 0, 14, 15, 10, 4, 8, 2, 13, }; } }
        protected override int[] ByteSequence { get { return new int[] { 1, 13, 11, 8, 6, 3, 9, 4, 0, 2, 10, 15, 7, 12, 14, 5, }; } }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_GUILD_GET_ROSTER, TransferDirection.ToServer);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            PlayerGuid = reader.ReadGuid();
            GuildGuid = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(PlayerGuid);
            writer.WriteGuid(GuildGuid);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Player: " + PlayerGuid);
            builder.AppendLine("Guild: " + GuildGuid);
        }
    }
}
