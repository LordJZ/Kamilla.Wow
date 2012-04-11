using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Lfg
{
    [WowPacketParser(WowOpcodes.SMSG_LFG_SEARCH_RESULTS)]
    internal sealed class SMSG_LFG_SEARCH_RESULTS : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.LookingForGroup; } }

        protected override void InternalParse()
        {
            Output.AppendLine("LFG Type: " + (LFGType)Reader.ReadInt32());
            Output.AppendLine("Dungeon: " + new DungeonEntry(Reader.ReadUInt32()));

            var isGuidsPresent = Reader.ReadBoolean();
            Output.AppendLine("isGuidsPresent: " + isGuidsPresent);

            if (isGuidsPresent)
            {
                uint guids = Reader.ReadUInt32();
                Output.AppendLine(" Guids: " + guids);

                for (var i = 0; i < guids; i++)
                    Output.AppendFormatLine("  [{0}] {1}", i, Reader.ReadGuid());
            }

            uint groups = Reader.ReadUInt32();
            Output.AppendFormatLine("Groups: " + groups);

            var groups2 = Reader.ReadUInt32();
            Output.AppendLine("Groups2: " + groups2);

            for (var i = 0; i < groups; i++)
            {
                Output.AppendLine("______________________");
                Output.AppendFormatLine(" Group {0}:", i);

                Output.AppendLine("  Leader: " + Reader.ReadGuid());

                var flags = (LFGMemberFlags)Reader.ReadInt32();
                Output.AppendLine("  Update Flags: " + flags);

                if ((flags & LFGMemberFlags.Comment) != 0)
                    Output.AppendLine("  Comment: " + Reader.ReadCString());

                if ((flags & LFGMemberFlags.Roles) != 0)
                {
                    for (var j = 0; j < 3; j++)
                        Output.AppendFormatLine("  Needed {0}: {1}", (GroupRoles)(1 << (j + 1)), Reader.ReadByte());
                }

                if ((flags & LFGMemberFlags.Unknown4) != 0)
                {
                    var guid3 = Reader.ReadGuid();
                    Output.AppendLine("  Unk GUID 3 " + i + ": " + guid3);

                    var unk80 = Reader.ReadInt32();
                    Output.AppendLine("  Unk Int32 4 " + i + ": " + unk80);
                }
            }

            uint players = Reader.ReadUInt32();
            Output.AppendLine("Players: " + players);

            Output.AppendLine("Players2: " + Reader.ReadUInt32());

            for (var i = 0; i < players; ++i)
            {
                Output.AppendLine("______________________");
                Output.AppendFormatLine(" Player {0}:", i);
                Output.AppendLine("  GUID: " + Reader.ReadGuid());

                var updateFlags = (LFGMemberFlags)Reader.ReadInt32();
                Output.AppendLine("  UpdateFlags: " + updateFlags);

                if ((updateFlags & LFGMemberFlags.CharacterInfo) != 0)
                {
                    Output.AppendLine("  Level: " + Reader.ReadByte());
                    Output.AppendLine("  Class: " + (Classes)Reader.ReadByte());
                    Output.AppendLine("  Race: " + (Races)Reader.ReadByte());
                    Output.AppendFormatLine("  Spec: {0}/{1}/{2}",
                        Reader.ReadByte(), Reader.ReadByte(), Reader.ReadByte());

                    Output.AppendLine("  Armor: " + Reader.ReadUInt32());

                    Output.AppendFormatLine("  Spell Damage: {0} Heal: {1}", Reader.ReadUInt32(), Reader.ReadUInt32());
                    Output.AppendFormatLine("  Haste rating: melee {0}, ranged {1}, spell {2}",
                        Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32());

                    Output.AppendFormatLine("  MP5: {0} (interrupted {1})", Reader.ReadSingle(), Reader.ReadSingle());
                    Output.AppendLine("  Attack Power: " + Reader.ReadUInt32());
                    Output.AppendLine("  Agility: " + Reader.ReadUInt32());
                    Output.AppendLine("  Health: " + Reader.ReadUInt32());
                    Output.AppendLine("  Mana: " + Reader.ReadUInt32());
                    Output.AppendLine("  Unk 1: " + Reader.ReadInt32());
                    Output.AppendLine("  Unk Float: " + Reader.ReadSingle());
                    Output.AppendLine("  Average Item Level: " + Reader.ReadSingle());
                    Output.AppendLine("  Defence Rating: " + Reader.ReadInt32());
                    Output.AppendLine("  Dodge Rating: " + Reader.ReadInt32());
                    Output.AppendLine("  Block Rating: " + Reader.ReadInt32());
                    Output.AppendLine("  Parry Rating: " + Reader.ReadInt32());
                    Output.AppendLine("  Crit Rating (?): " + Reader.ReadInt32());
                    Output.AppendLine("  Expertise: " + Reader.ReadInt32());
                }

                if ((updateFlags & LFGMemberFlags.Comment) != 0)
                    Output.AppendLine("  Comment: " + Reader.ReadCString());

                if ((updateFlags & LFGMemberFlags.Unknown1) != 0)
                {
                    var int8 = Reader.ReadByte();
                    Output.AppendFormatLine("  Unk Byte 6 " + i + ": " + int8);
                }

                if ((updateFlags & LFGMemberFlags.Guid) != 0)
                    Output.AppendLine("  Guid: " + Reader.ReadGuid());

                if ((updateFlags & LFGMemberFlags.Roles) != 0)
                    Output.AppendLine("  Roles: " + (GroupRoles)Reader.ReadByte());

                if ((updateFlags & LFGMemberFlags.Unknown2) != 0)
                {
                    var int20 = Reader.ReadInt32();
                    Output.AppendFormatLine("  Unk Int32 23 " + i + ": " + int20);
                }

                if ((updateFlags & LFGMemberFlags.Unknown3) != 0)
                {
                    var byte40 = Reader.ReadByte();
                    Output.AppendFormatLine("  Unk Byte 8 " + i + ": " + byte40);
                }

                if ((updateFlags & LFGMemberFlags.Unknown4) != 0)
                {
                    var guid6 = Reader.ReadGuid();
                    Output.AppendFormatLine("  Unk GUID 6 " + i + ": " + guid6);

                    var intUnk = Reader.ReadInt32();
                    Output.AppendFormatLine("  Unk Int32 24 " + i + ": " + intUnk);
                }
            }
        }
    }
}
