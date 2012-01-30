using System;
using Kamilla.Network.Protocols.Wow.Latest.Game;

namespace Kamilla.Network.Protocols.Wow.Latest.Parsers.Misc
{
    [WowPacketParser(WowOpcodes.CMSG_GENERATE_RANDOM_CHARACTER_NAME)]
    internal sealed class RandomizeNameParser : WowPacketParser
    {
        protected override void InternalParse()
        {
            var race = (Races)this.Reader.ReadByte();
            var gender = (Genders)this.Reader.ReadByte();

            Output.AppendLine("Race: " + race);
            Output.AppendLine("Gender: " + gender);
        }
    }
}
