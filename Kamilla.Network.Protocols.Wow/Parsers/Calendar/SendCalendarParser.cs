using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Calendar
{
    [WowPacketParser(WowOpcodes.SMSG_CALENDAR_SEND_CALENDAR)]
    internal sealed class SendCalendarParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Calendar; } }

        protected override void InternalParse()
        {
            uint nInviteNodes = Reader.ReadUInt32();
            Output.AppendLine("Total Invite Nodes: " + nInviteNodes);
            for (uint i = 0; i < nInviteNodes; ++i)
            {
                Output.AppendFormatLine("____________________________________________");

                Output.AppendFormatLine("Event Id: {0:N0}  Invite Id: {1:N0}", Reader.ReadUInt64(), Reader.ReadUInt64());
                Output.AppendFormatLine("Invite Status: {0} ({0:D})", (CalendarInviteStatus)Reader.ReadByte());
                Output.AppendFormatLine("Mod Type: {0} ({0:D})", (CalendarModType)Reader.ReadByte());
                Output.AppendFormatLine("Invite Type: {0} ({0:D})", (CalendarInviteType)Reader.ReadByte());
                Output.AppendLine("InvitedBy: " + Reader.ReadPackedGuid());
            }
            Output.AppendLine();

            uint nEventNodes = Reader.ReadUInt32();
            Output.AppendLine("Total Event Nodes: " + nEventNodes);
            for (uint i = 0; i < nEventNodes; ++i)
            {
                Output.AppendFormatLine("____________________________________________");

                Output.AppendFormatLine("Event Id: {0:N0} '{1}'", Reader.ReadUInt64(), Reader.ReadCString());
                Output.AppendFormatLine("Mod Flags: {0} ({0:D})", (CalendarEventModFlags)Reader.ReadUInt32());
                Output.AppendLine("Date: " + Reader.ReadUInt32().AsTimeBitFields());
                Output.AppendFormatLine("Event Flags: {0} ({0:D})", (CalendarEventFlags)Reader.ReadUInt32());
                Output.AppendLine("Dungeon Id: " + Reader.ReadInt32());
                Output.AppendLine("InvitedBy: " + Reader.ReadPackedGuid());
            }

            Output.AppendLine();
            Output.AppendFormatLine("Current Time: Unix: {0} BitFields: {1}", Reader.ReadUInt32().AsUnixTime(), Reader.ReadUInt32().AsTimeBitFields());
            Output.AppendLine();

            uint nSaveNodes = Reader.ReadUInt32();
            Output.AppendLine("Total Save Nodes: " + nSaveNodes);
            for (uint i = 0; i < nSaveNodes; ++i)
            {
                Maps map = (Maps)Reader.ReadUInt32();
                Output.AppendFormatLine("Map: {0,-40} ({0,-3:D}) Difficulty: {1} Instance Id: {4,-8:D} Remaining Time: {3}",
                    map.GetLocalizedName(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt64());
            }
            Output.AppendLine();

            Output.AppendLine("Calendar Start Date: " + Reader.ReadUInt32().AsUnixTime());

            uint nLockoutNodes = Reader.ReadUInt32();
            Output.AppendLine("Total Lockout Nodes: " + nLockoutNodes);
            for (uint i = 0; i < nLockoutNodes; ++i)
            {
                Maps map = (Maps)Reader.ReadUInt32();
                Output.AppendFormatLine("Map: {0,-40} ({0,-3:D}) Period: {1} Offset: {2}",
                    map.GetLocalizedName(), Reader.ReadUInt32(), Reader.ReadUInt32());
            }

            uint nOverwriteNodes = Reader.ReadUInt32();
            Output.AppendLine("Total Overwrite Nodes: " + nOverwriteNodes);
            for (uint i = 0; i < nOverwriteNodes; ++i)
            {
                Output.AppendFormatLine("____________________________________________");

                Output.AppendLine("Holiday Id: " + Reader.ReadUInt32());
                Output.AppendFormatLine("Unk values: {0}, {1}, {2}, {3}", Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32());
                byte[] nValuesArr = new byte[] { 26, 10, 10 };
                foreach (byte nValues in nValuesArr)
                {
                    Output.AppendFormat("{0} values: ", nValues);
                    for (int j = 0; j < nValues; ++j)
                    {
                        uint val = Reader.ReadUInt32();
                        if (val == 0)
                            Output.AppendFormat("0, ");
                        else
                            Output.AppendFormat("{0}, ", val.AsTimeBitFields());
                    }
                    Output.AppendLine();
                }

                Output.AppendLine("Icon: " + Reader.ReadCString());
            }
        }
    }
}
