using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <remarks>
    /// Updated for client build 14007.
    /// </remarks>
    public sealed class GuildRanksRequest : PackedData
    {
        public WowGuid Guid { get; set; }

        protected override int[] MaskSequence { get { return new int[] { 3, 4, 5, 7, 2, 1, 6, 0, }; } }
        protected override int[] ByteSequence { get { return new int[] { 2, 7, 5, 4, 3, 6, 1, 0, }; } }

        protected override int ByteXorValue
        {
            get { return 1; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_GUILD_GET_RANKS, TransferDirection.ToServer);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            Guid = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(Guid);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Player: " + Guid);
        }
    }
}
