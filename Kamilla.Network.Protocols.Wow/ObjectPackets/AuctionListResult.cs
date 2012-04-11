using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class AuctionListResult : ObjectPacket
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AuctionListItem
        {
            public uint AuctionId;
            public uint ItemEntry;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItemEnchantmentInfo.MaxItemEnchantments)]
            public ItemEnchantmentInfo[] Enchantments;
            public uint PropertyId;
            public uint SuffixFactor;
            public uint Count;
            public int SpellCharges;
            public uint Unknown;
            public WowGuid Owner;
            public Money StartBid;
            public Money MinimumBid;
            public Money BuyOut;
            public uint TimeLeftMs;
            public WowGuid CurrentBidder;
            public Money CurrentBid;
        }

        public uint TotalItemCount { get; set; }
        public uint NextSearchDelayMs { get; set; }

        public AuctionListItem[] Items { get; set; }

        public override void Read(StreamHandler reader)
        {
            uint DisplayedItemCount = reader.ReadUInt32();

            Items = new AuctionListItem[DisplayedItemCount];
            for (uint i = 0; i < DisplayedItemCount; ++i)
                Items[i] = reader.ReadStruct<AuctionListItem>();

            TotalItemCount = reader.ReadUInt32();
            NextSearchDelayMs = reader.ReadUInt32();
        }

        public override void Save(StreamHandler writer)
        {
            writer.WriteInt32(Items.Length);

            foreach (var item in Items)
                writer.WriteStruct(item);

            writer.WriteUInt32(TotalItemCount);
            writer.WriteUInt32(NextSearchDelayMs);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendFormatLine("Items: {0} (displayed: {1})", TotalItemCount, Items.Length);
            builder.AppendLine();

            foreach (var item in Items)
            {
                builder.AppendFormatLine("Auction Id: {0}  Item Entry: {1}", item.AuctionId, item.ItemEntry);

                for (uint i = 0; i < item.Enchantments.Length; ++i)
                {
                    var ench = item.Enchantments[i];
                    if (ench.Id != 0)
                        builder.AppendFormatLine("  Enchantment {0}: {1}", i, ench);
                }

                builder.AppendFormatLine("Property: {0}  RandomSuffix: {1}  Unknown: {2}",
                    item.PropertyId, item.SuffixFactor, item.Unknown);
                builder.AppendFormatLine("Stack Count: {0}  Charges: {1}", item.Count, item.SpellCharges);
                builder.AppendLine("Owner: " + item.Owner);
                builder.AppendFormatLine("Start Bid: {0}  Minimum Bid: {1}  BuyOut: {2}",
                    item.StartBid, item.MinimumBid, item.BuyOut);
                builder.AppendLine("Time Left: " + item.TimeLeftMs);
                builder.AppendFormatLine("Current Bid: {0}  Bidder: {1}", item.CurrentBid, item.CurrentBidder);

                builder.AppendLine();
            }

            builder.AppendLine("Delay: " + NextSearchDelayMs);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_AUCTION_LIST_RESULT, TransferDirection.ToClient);
        }
    }
}
