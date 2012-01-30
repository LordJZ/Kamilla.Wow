using System;
using Kamilla.Network.Protocols.Wow.Latest.Game;

namespace Kamilla.Network.Protocols.Wow.Latest.Parsers.Misc
{
    [WowPacketParser(WowOpcodes.SMSG_GENERATE_RANDOM_CHARACTER_NAME_RESULT)]
    internal sealed class RandomizeNameResultParser : WowPacketParser
    {
        protected override void InternalParse()
        {
            int length = (int)this.Reader.ReadByte() / 2;
            Output.AppendLine("Generated Name: " + this.Reader.ReadString(length));
        }
    }
}
