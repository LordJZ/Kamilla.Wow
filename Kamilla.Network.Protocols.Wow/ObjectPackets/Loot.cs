using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class Loot : ObjectPacket
    {
        public WowGuid Guid { get; private set; }
        public Money Gold { get; private set; }
        public LootType Type { get; private set; }
        public List<Item> Items { get; private set; }
        public List<Currency> Currencies { get; private set; }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Item
        {
            public byte Index;
            public uint Entry;
            public uint Count;
            public uint DisplayId;
            public int RandomSuffix;
            public uint RandomPropertyId;
            public LootItemPermission Perm;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Currency
        {
            public byte Index;
            public uint Entry;
            public uint Count;
        }

        public Loot()
        {
            this.Items = new List<Item>();
            this.Currencies = new List<Currency>();
        }

        public Loot(StreamHandler reader)
            : this()
        {
            this.Read(reader);
        }

        public override void Read(StreamHandler reader)
        {
            this.Guid = reader.ReadGuid();
            this.Type = (LootType)reader.ReadByte();
            this.Gold = new Money(reader.ReadUInt32());
            byte itemCount = reader.ReadByte();
            byte currencyCount = reader.ReadByte();

            for (int i = 0; i < itemCount; ++i)
            {
                Item item = reader.ReadStruct<Item>();
                Items.Add(item);
            }

            for (int i = 0; i < currencyCount; ++i)
            {
                Currency currency = reader.ReadStruct<Currency>();
                Currencies.Add(currency);
            }
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendFormatLine("{0} ({0:D}) loot contains {1} and {2} items",
                this.Type, this.Gold, this.Items.Count);
            builder.AppendLine("Object: " + this.Guid);

            builder.AppendLine();
            builder.AppendLine("Items: " + this.Items.Count);

            foreach (Item item in this.Items)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, " [{0}] (Permission: {1}) {2} x {3} (DisplayId: {4})",
                    item.Index, item.Perm, item.Count, item.Entry, item.DisplayId);

                if (item.RandomPropertyId != 0 || item.RandomSuffix != 0)
                    builder.AppendFormatLine(" (Random: Suffix {0}, PropertyId {1})",
                        item.RandomSuffix, item.RandomPropertyId);
                else
                    builder.AppendLine();
            }

            builder.AppendLine();
            builder.AppendLine("Currencies: " + this.Currencies.Count);

            foreach (Currency currency in this.Currencies)
                builder.AppendFormat(CultureInfo.InvariantCulture, " [{0}] {1} x {2}",
                    currency.Index, currency.Count, currency.Entry);
        }

        public override void Save(StreamHandler writer)
        {
            throw new System.NotImplementedException();
        }

        public override CustomPacket CreatePacket()
        {
            throw new System.NotImplementedException();
        }
    }
}
