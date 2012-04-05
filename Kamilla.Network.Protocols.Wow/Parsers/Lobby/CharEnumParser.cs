using System;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Lobby
{
    [WowPacketParser(WowOpcodes.SMSG_ENUM_CHARACTERS_RESULT)]
    internal sealed class CharEnumParser : WowPacketParser
    {
        protected unsafe override void InternalParse()
        {
            var reader = this.Reader;

            uint nCharacters = reader.UnalignedReadInt(17);

            var guids = new Tuple<byte[], byte[]>[nCharacters];
            var firstLogin = new bool[nCharacters];
            var nameLengths = new uint[nCharacters];
            for (byte i = 0; i < nCharacters; ++i)
            {
                var guid1 = new byte[8];
                var guid2 = new byte[8];
                guids[i] = new Tuple<byte[], byte[]>(guid1, guid2);

                guid2[2] = reader.UnalignedReadTinyInt(1);
                guid1[2] = reader.UnalignedReadTinyInt(1);
                guid1[6] = reader.UnalignedReadTinyInt(1);
                guid1[5] = reader.UnalignedReadTinyInt(1);
                guid1[4] = reader.UnalignedReadTinyInt(1);
                guid2[4] = reader.UnalignedReadTinyInt(1);
                guid2[3] = reader.UnalignedReadTinyInt(1);
                guid2[7] = reader.UnalignedReadTinyInt(1);
                nameLengths[i] = reader.UnalignedReadInt(7);
                guid2[0] = reader.UnalignedReadTinyInt(1);
                guid1[0] = reader.UnalignedReadTinyInt(1);
                guid1[3] = reader.UnalignedReadTinyInt(1);
                guid1[1] = reader.UnalignedReadTinyInt(1);
                firstLogin[i] = reader.UnalignedReadBit();
                guid2[5] = reader.UnalignedReadTinyInt(1);
                guid1[7] = reader.UnalignedReadTinyInt(1);
                guid2[6] = reader.UnalignedReadTinyInt(1);
                guid2[1] = reader.UnalignedReadTinyInt(1);
            }

            uint counter = reader.UnalignedReadInt(23);
            Output
                .Append("Not drop character info: ").AppendLine(reader.UnalignedReadBit().ToString())
                .Append("Total Characters: ").AppendLine(nCharacters.ToString());

            for (byte i = 0; i < nCharacters; ++i)
            {
                var chrguids = guids[i];
                var guid1 = new WowGuid(chrguids.Item1);
                var guid2 = new WowGuid(chrguids.Item2);

                reader.Skip(23 * (4 + 4 + 1)); // item data

                Vector3 position;
                reader.ReadXorByte(ref guid2.Bytes[0]);
                reader.ReadXorByte(ref guid2.Bytes[1]);
                var face = reader.ReadByte();
                var petDisplayId = reader.ReadUInt32();
                reader.ReadXorByte(ref guid2.Bytes[7]);
                var gender = (Genders)reader.ReadByte();
                var level = reader.ReadByte();
                var petLevel = reader.ReadUInt32();
                var zone = (Zones)reader.ReadUInt32();
                position.Y = reader.ReadSingle();
                var petFamily = (CreatureFamilies)reader.ReadUInt32();
                var hairStyle = reader.ReadByte();
                reader.ReadXorByte(ref guid1.Bytes[1]);
                var name = reader.ReadString((int)nameLengths[i]);
                reader.ReadXorByte(ref guid1.Bytes[0]);
                var race = (Races)reader.ReadByte();
                var order = reader.ReadByte();
                reader.ReadXorByte(ref guid1.Bytes[7]);
                position.Z = reader.ReadSingle();
                var map = (Maps)reader.ReadUInt32();
                reader.ReadXorByte(ref guid2.Bytes[4]);
                var hairColor = reader.ReadByte();
                reader.ReadXorByte(ref guid1.Bytes[3]);
                var charFlags = (CharacterFlags)reader.ReadUInt32();
                var skin = reader.ReadByte();
                reader.ReadXorByte(ref guid1.Bytes[4]);
                reader.ReadXorByte(ref guid1.Bytes[5]);
                reader.ReadXorByte(ref guid2.Bytes[5]);
                var customizeFlags = (CharacterCustomizeFlags)reader.ReadUInt32();
                position.X = reader.ReadSingle();
                var facialHair = reader.ReadByte();
                reader.ReadXorByte(ref guid1.Bytes[6]);
                reader.ReadXorByte(ref guid2.Bytes[3]);
                reader.ReadXorByte(ref guid1.Bytes[2]);
                var classs = (Classes)reader.ReadByte();
                reader.ReadXorByte(ref guid2.Bytes[6]);
                reader.ReadXorByte(ref guid2.Bytes[2]);

                this.Output
                    .AppendLine("___________________________________________________________")
                    .AppendLine("GUID: " + guid1)
                    // Charname - Female Undead Warrior
                    .AppendFormatLine("{0} - {3} {1} {2} (#{4})", name, race.GetLocalizedName(), classs.GetLocalizedName(), gender.GetLocalizedName(), order)
                    .AppendFormatLine("Skin: {0} Face: {1} Hair Style: {2} Hair Color: {3} Facial Hair: {4}",
                    skin, face, hairStyle, hairColor, facialHair)
                    .AppendFormatLine("Character level: {0} Zone: {1} ({1:D}) Map: {2} ({2:D})", level, zone, map.GetLocalizedName())
                    .AppendLine("Position: " + position)
                    .AppendLine("Guild: " + guid2)
                    .AppendLine("Char Flags: " + charFlags)
                    .AppendLine("Customize Flags: " + customizeFlags)
                    .AppendLine("First login: " + firstLogin[i])
                    .AppendFormatLine("Pet: DisplayId {0}, Level {1}, Family {2} ({2:D})", petDisplayId, petLevel, petFamily);
            }

            Output
                .AppendLine()
                .AppendLine()
                .AppendLine("Unk Counter: " + counter);

            for (uint i = 0; i < counter; ++i)
            {
                Output.AppendFormatLine("   Unk: {0}, {1}", reader.ReadUInt32(), reader.ReadByte());
            }
        }
    }
}
