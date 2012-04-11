using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Spells
{
    [WowPacketParser(WowOpcodes.SMSG_SPELL_START)]
    internal sealed class SpellStartParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Spells; } }

        protected override void InternalParse()
        {
            var start = new SpellStart();
            start.Read(Reader);

            start.ToString(Output);
        }
    }
}
