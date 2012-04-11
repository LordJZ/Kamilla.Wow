using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Lfg
{
    [WowPacketParser(WowOpcodes.SMSG_LFG_PLAYER_INFO)]
    internal sealed class LfgPlayerInfoParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.LookingForGroup; } }

        protected override void InternalParse()
        {
            byte count = Reader.ReadByte();
            Output.AppendLine("Total Dungeons: " + count);
            for (byte i = 0; i < count; ++i)
            {
                Output.AppendLine();
                Output.AppendLine("  Dungeon: " + new DungeonEntry(Reader.ReadUInt32()) + "   Done: " + Reader.ReadByte());
                Output.AppendLine("  Money: " + new Money(Reader.ReadUInt32()) + " XP: " + Reader.ReadUInt32()
                    + " VarMoney: " + new Money(Reader.ReadUInt32()) + " VarXP: " + Reader.ReadUInt32());
                Output.AppendLine("  Money: " + new Money(Reader.ReadUInt32()) + " XP: " + Reader.ReadUInt32()
                    + " VarMoney: " + new Money(Reader.ReadUInt32()) + " VarXP: " + Reader.ReadUInt32());
                Output.AppendLine("  Money: " + new Money(Reader.ReadUInt32()) + " XP: " + Reader.ReadUInt32()
                    + " VarMoney: " + new Money(Reader.ReadUInt32()) + " VarXP: " + Reader.ReadUInt32());
                Output.AppendLine("  Unk: " + Reader.ReadByte());

                for (byte j = 0; j < 3; ++j)
                {
                    uint role = Reader.ReadUInt32();
                    Output.AppendLine("  Role: " + (GroupRoles)role);
                    if (role != 0)
                    {
                        Output.AppendLine("    Money Reward: " + new Money(Reader.ReadUInt32()));
                        Output.AppendLine("    Xp Reward: " + Reader.ReadUInt32());
                        byte count2;
                        Output.AppendLine("    Rewards: " + (count2 = Reader.ReadByte()));
                        for (byte k = 0; k < count2; ++k)
                        {
                            Output.AppendFormatLine("     Item: {0}  DisplayId: {1}  Count: {2} IsCurrency (Cata): {3}",
                                Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadByte());
                        }
                    }
                }

                Output.AppendLine("  Basic Money Reward: " + new Money(Reader.ReadUInt32()));
                Output.AppendLine("  Basic XP Reward: " + Reader.ReadUInt32());
                byte count3 = Reader.ReadByte();
                Output.AppendLine("  Basic Rewards: " + count3);
                for (byte j = 0; j < count3; ++j)
                {
                    Output.AppendFormatLine("     Item: {0}  DisplayId: {1}  Count: {2} IsCurrency (Cata): {3}",
                        Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadByte());
                }
            }

            uint locks = Reader.ReadUInt32();
            Output.AppendLine("Total Locks: " + locks);
            for (uint j = 0; j < locks; ++j)
            {
                Output.AppendLine("  Dungeon: " + new DungeonEntry(Reader.ReadUInt32()));
                Output.AppendLine("  Lock: " + (LFGLockStatusType)Reader.ReadUInt32());
                Output.AppendFormatLine("  Additional: Entrance Area Id: {0} {1}", Reader.ReadUInt32(), Reader.ReadUInt32());
                Output.AppendLine();
            }
        }
    }
}
