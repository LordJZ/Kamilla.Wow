
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceWaterWalk : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 0, 2, 3, 6, 5, 1, 7 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 5, 0, -1, 3, 7, 1, 4, 6, 2 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_SET_WATER_WALK, TransferDirection.ToClient);
        }
    }
}
