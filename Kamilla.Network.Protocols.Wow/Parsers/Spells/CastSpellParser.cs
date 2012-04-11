using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Spells
{
    [WowPacketParser(WowOpcodes.CMSG_CAST_SPELL)]
    internal sealed class SpellCastParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Spells; } }

        protected override void InternalParse()
        {
            var cast = new SpellCast(Reader, false);

            cast.ToString(Output);
        }
    }
}
