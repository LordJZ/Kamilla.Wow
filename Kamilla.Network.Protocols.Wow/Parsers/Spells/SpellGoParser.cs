using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Spells
{
    [WowPacketParser(WowOpcodes.SMSG_SPELL_GO)]
    internal sealed class SpellGoParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Spells; } }

        protected override void InternalParse()
        {
            var go = new SpellGo(Reader);

            go.ToString(Output);
        }
    }
}
