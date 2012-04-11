using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.Network.Protocols.Wow;
using System.IO;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ChannelStart : ObjectPacket
    {
        public WowGuid Caster;
        public uint SpellId;
        public int Duration;

        public bool HaveFlags;
        public uint TargetFlags1;
        public uint TargetFlags2;

        public bool Unk_HaveData2;
        public WowGuid Unk_Guid1;
        public uint Unk_UInt3;
        public byte Unk_Byte;
        public WowGuid Unk_Guid2;

        public override void Read(StreamHandler reader)
        {
            Caster = reader.ReadPackedGuid();
            SpellId = reader.ReadUInt32();
            Duration = reader.ReadInt32();

            HaveFlags = reader.ReadBoolean();
            if (HaveFlags)
            {
                TargetFlags1 = reader.ReadUInt32();
                TargetFlags2 = reader.ReadUInt32();
            }

            Unk_HaveData2 = reader.ReadBoolean();
            if (Unk_HaveData2)
            {
                Unk_Guid1 = reader.ReadPackedGuid();
                Unk_UInt3 = reader.ReadUInt32();
                Unk_Byte = reader.ReadByte();
                if (Unk_Byte == 2)
                    Unk_Guid2 = reader.ReadPackedGuid();
            }
        }

        public override void Save(StreamHandler writer)
        {
            throw new NotImplementedException();
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Caster: " + Caster);
            builder.AppendLine("Spell Id: " + SpellId);
            builder.AppendLine("Duration: " + Duration);

            builder.AppendLine("Have Flags: " + HaveFlags);
            if (HaveFlags)
            {
                builder.AppendLine("  Flags 1: 0x" + TargetFlags1.ToString("X"));
                builder.AppendLine("  Flags 2: 0x" + TargetFlags2.ToString("X"));
                builder.AppendLine();
            }

            builder.AppendLine("Have Data 2: " + Unk_HaveData2);
            if (Unk_HaveData2)
            {
                builder.AppendLine("  Target: " + Unk_Guid1);
                builder.AppendLine("  UInt3: " + Unk_UInt3);
                builder.AppendLine("  Unk Byte: " + Unk_Byte);
                if (Unk_Byte == 2)
                    builder.AppendLine("    Target2?: " + Unk_Guid2);
            }
        }

        public override CustomPacket CreatePacket()
        {
            throw new NotImplementedException();
        }
    }
}
