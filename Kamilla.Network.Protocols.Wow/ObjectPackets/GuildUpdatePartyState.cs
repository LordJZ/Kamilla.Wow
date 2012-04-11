using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <summary>
    /// Updated for patch 4.1.0.
    /// </summary>
    public class GuildUpdatePartyState : PackedData
    {
        public WowGuid PlayerGuid { get; set; }
        public WowGuid GuildGuid { get; set; }

        protected override int[] MaskSequence { get { return new int[] { 9, 8, 1, 0, 12, 14, 11, 10, 3, 13, 5, 15, 2, 4, 6, 7, }; } }
        protected override int[] ByteSequence { get { return new int[] { 9, 7, 5, 14, 4, 8, 3, 11, 15, 1, 12, 0, 6, 10, 2, 13, }; } }
        private static int s_byteXor = 1;

        protected override int ByteXorValue
        {
            get { return s_byteXor; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_REQUEST_GUILD_PARTY_STATE, TransferDirection.ToServer);
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
