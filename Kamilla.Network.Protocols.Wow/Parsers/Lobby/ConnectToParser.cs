using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Lobby
{
    [WowPacketParser(WowOpcodes.SMSG_CONNECT_TO)]
    internal sealed class ConnectToParser : WowPacketParser
    {
        protected override void InternalParse()
        {
            var redirect = new ConnectToPacket(Reader);

            redirect.ToString(this.Output);

            this.ContainedData.Add(redirect.FixedBlob);
        }
    }
}
