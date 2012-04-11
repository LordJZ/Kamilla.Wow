using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <remarks>
    /// Updated for client build 14007.
    /// </remarks>
    public sealed class GuildQueryNews : PackedData
    {
        public WowGuid GuildGuid { get; set; }

        private static int[] s_maskSeq = { 2, 5, 4, 1, 3, 0, 6, 7 };
        private static int[] s_byteSeq = { 3, 7, 4, 0, 1, 6, 2, 5 };
        private static int s_byteXor = 1;

        protected override int[] MaskSequence
        {
            get { return s_maskSeq; }
        }

        protected override int[] ByteSequence
        {
            get { return s_byteSeq; }
        }

        protected override int ByteXorValue
        {
            get { return s_byteXor; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_GUILD_QUERY_NEWS, TransferDirection.ToServer);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            GuildGuid = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(GuildGuid);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Guild: " + GuildGuid);
        }
    }
}
