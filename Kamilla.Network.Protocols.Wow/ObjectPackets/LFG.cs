using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public class DungeonEntry
    {
        public uint Entry { get { return (uint)this.Id | (this.Type << 24); } }

        public DungeonEntry(uint entry)
        {
            this.Id = (LFGDungeons)(entry & ((1 << 24) - 1));
            this.Type = entry >> 24;
        }

        public DungeonEntry(uint id, uint type)
        {
            this.Id = (LFGDungeons)id;
            this.Type = type;
        }

        public LFGDungeons Id { get; private set; }
        public uint Type { get; private set; }

        public override string ToString()
        {
            return string.Concat("Id: ", Id.GetLocalizedName(), " (", (uint)Id, ") Type: ", Type);
        }
    }

    public sealed class LFGJoin : ObjectPacket
    {
        public GroupRoles Roles { get; set; }
        public DungeonEntry[] Dungeons { get; set; }
        public string Comment { get; set; }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Roles: " + Roles.GetLocalizedName());

            builder.AppendLine("Dungeons:");
            foreach (var entry in Dungeons)
                builder.AppendLine(" - " + entry.ToString());

            builder.AppendLine("Comment: " + Comment);
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteUInt32((uint)Roles);

            writer.WriteUInt16(0);

            writer.WriteByte((byte)Dungeons.Length);
            foreach (var entry in Dungeons)
                writer.WriteUInt32(entry.Entry);

            writer.WriteByte(3);
            writer.WriteUInt16(0);
            writer.WriteByte(0);

            writer.WriteCString(Comment);
        }

        public override void Read(StreamHandler reader)
        {
            this.Roles = (GroupRoles)reader.ReadUInt32();

            reader.Skip(2); // 2 bools

            uint count = reader.ReadByte();
            Dungeons = new DungeonEntry[count];
            for (uint i = 0; i < count; ++i)
                Dungeons[i] = new DungeonEntry(reader.ReadUInt32());

            reader.Skip(4);

            this.Comment = reader.ReadCString();
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.CMSG_DF_JOIN, TransferDirection.ToServer);
        }
    }

    public class LFGUpdatePlayer : ObjectPacket
    {
        public LFGUpdateType UpdateType { get; set; }
        public bool Queued { get; set; }
        public bool ExtraData { get; set; }
        public DungeonEntry[] Dungeons { get; set; }
        public string Comment { get; set; }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Update Type: " + UpdateType.GetLocalizedName());
            builder.AppendLine("Extra Data: " + ExtraData);

            if (ExtraData)
            {
                builder.AppendLine("Queued: " + Queued);

                builder.AppendLine("Dungeons:");
                foreach (var entry in Dungeons)
                    builder.AppendLine(" - " + entry.ToString());

                builder.AppendLine("Comment: " + Comment);
            }
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteByte((byte)UpdateType);
            writer.WriteBoolean(ExtraData);
            if (ExtraData)
            {
                writer.WriteBoolean(Queued);

                writer.WriteUInt16(0);

                writer.WriteByte((byte)Dungeons.Length);
                foreach (var entry in Dungeons)
                    writer.WriteUInt32(entry.Entry);

                writer.WriteCString(Comment);
            }
        }

        public override void Read(StreamHandler reader)
        {
            this.UpdateType = (LFGUpdateType)reader.ReadByte();
            this.ExtraData = reader.ReadBoolean();
            if (ExtraData)
            {
                this.Queued = reader.ReadBoolean();

                reader.Skip(2); // 2 bools

                uint count = reader.ReadByte();
                Dungeons = new DungeonEntry[count];
                for (uint i = 0; i < count; ++i)
                    Dungeons[i] = new DungeonEntry(reader.ReadUInt32());

                this.Comment = reader.ReadCString();
            }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_LFG_UPDATE_PLAYER, TransferDirection.ToClient);
        }
    }

    public class LFGProposalUpdate : ObjectPacket
    {
        public struct PlayerInfo
        {
            public GroupRoles Role;
            public bool SelfPlayer;
            public bool InDungeon;
            public bool SameGroup;
            public bool Answered;
            public bool Accepted;

            public override string ToString()
            {
                return string.Concat("Role: ", Role, "   Self: ", SelfPlayer ? '1' : '0',
                    " InDungeon: ", InDungeon ? '1' : '0', " SameGroup: ", SameGroup ? '1' : '0',
                    " Answered: ", Answered ? '1' : '0', " Accepted: ", Accepted ? '1' : '0');
            }
        }

        public DungeonEntry Dungeon { get; set; }
        public PlayerInfo[] Players { get; set; }
        public LFGState State { get; set; }
        public uint ProposalId { get; set; }
        public uint BossesKilled { get; set; }
        public bool SameDungeon { get; set; }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Dungeon: " + Dungeon.ToString());
            builder.AppendLine("State: " + State.GetLocalizedName());
            builder.AppendLine("Proposal Id: " + ProposalId);
            builder.AppendLine("Bosses Killed: " + BossesKilled);
            builder.AppendLine("Same Dungeon: " + SameDungeon);
            builder.AppendLine("Players:");
            foreach (var info in Players)
                builder.AppendLine(" - " + info);
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteUInt32(Dungeon.Entry);
            writer.WriteByte((byte)State);
            writer.WriteUInt32(ProposalId);
            writer.WriteUInt32(BossesKilled);
            writer.WriteBoolean(SameDungeon);
            writer.WriteByte((byte)Players.Length);
            foreach (var info in Players)
            {
                writer.WriteUInt32((uint)info.Role);
                writer.WriteBoolean(info.SelfPlayer);
                writer.WriteBoolean(info.InDungeon);
                writer.WriteBoolean(info.SameGroup);
                writer.WriteBoolean(info.Answered);
                writer.WriteBoolean(info.Accepted);
            }
        }

        public override void Read(StreamHandler reader)
        {
            Dungeon = new DungeonEntry(reader.ReadUInt32());
            State = (LFGState)reader.ReadByte();
            ProposalId = reader.ReadUInt32();
            BossesKilled = reader.ReadUInt32();
            SameDungeon = reader.ReadBoolean();

            byte count = reader.ReadByte();
            this.Players = new PlayerInfo[count];
            for (byte i = 0; i < count; ++i)
            {
                this.Players[i].Role = (GroupRoles)reader.ReadUInt32();
                this.Players[i].SelfPlayer = reader.ReadBoolean();
                this.Players[i].InDungeon = reader.ReadBoolean();
                this.Players[i].SameGroup = reader.ReadBoolean();
                this.Players[i].Answered = reader.ReadBoolean();
                this.Players[i].Accepted = reader.ReadBoolean();
            }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_LFG_PROPOSAL_UPDATE, TransferDirection.ToClient);
        }
    }
}
