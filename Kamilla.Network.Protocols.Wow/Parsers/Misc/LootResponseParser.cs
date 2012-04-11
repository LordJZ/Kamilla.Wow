using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Misc
{
    [WowPacketParser(WowOpcodes.SMSG_LOOT_RESPONSE)]
    internal sealed class LootResponseParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Loot; } }

        protected override void InternalParse()
        {
            var loot = new Loot(Reader);
            loot.ToString(Output);
        }
    }
}
