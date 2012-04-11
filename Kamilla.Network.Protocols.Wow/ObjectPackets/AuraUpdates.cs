using System;
using System.Collections.Generic;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class AuraUpdate : ObjectPacket
    {
        public List<Aura> Auras { get; private set; }
        public WowGuid Unit { get; private set; }
        public bool Full { get; set; }

        public AuraUpdate()
        {
            this.Auras = new List<Aura>();
        }

        public AuraUpdate(WowGuid unit)
            : this()
        {
            this.Unit = unit;
        }

        public override void Read(StreamHandler reader)
        {
            Unit = reader.ReadPackedGuid();

            while (!reader.IsRead)
            {
                var update = new Aura();
                update.Unit = Unit;

                update.Read(reader);

                this.Auras.Add(update);
            }
        }

        public override CustomPacket CreatePacket()
        {
            return this.CreatePacket(Full ? WowOpcodes.SMSG_AURA_UPDATE_ALL : WowOpcodes.SMSG_AURA_UPDATE,
                TransferDirection.ToClient);
        }

        public override void Save(StreamHandler writer)
        {
            writer.WritePackedGuid(this.Unit);

            foreach (var update in this.Auras)
                update.Save(writer);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Unit: " + Unit);
            builder.AppendLine("Total Aura Updates: " + Auras.Count);

            foreach (var update in this.Auras)
            {
                builder.AppendLine();
                update.ToString(builder);
            }
        }
    }
}
