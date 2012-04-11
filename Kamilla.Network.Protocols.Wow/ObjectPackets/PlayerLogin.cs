using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    /// <remarks>
    /// Updated for client build 15050.
    /// </remarks>
    public sealed class PlayerLogin : PackedData
    {
        public WowGuid PlayerGuid { get; set; }

        private static int s_byteXor = 1;

        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence { get { return new int[] { 1, 5, 6, 2, 7, 4, 3, 0, }; } }
        protected override int[] ByteSequence { get { return new int[] { 4, 6, 2, 5, 7, 1, 0, 3, }; } }

        protected override int ByteXorValue
        {
            get { return s_byteXor; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_PLAYER_LOGIN, TransferDirection.ToServer);
        }

        protected override void PackedRead(StreamHandler reader)
        {
            PlayerGuid = reader.ReadGuid();
        }

        protected override void PackedSave(StreamHandler writer)
        {
            writer.WriteGuid(PlayerGuid);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Player: " + PlayerGuid);
        }
    }
}
