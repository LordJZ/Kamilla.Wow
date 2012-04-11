
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceLandWalk : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 7, 1, 5, 6, 4, 2, 0 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 7, 2, 5, -1, 4, 6, 3, 1, 0 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_SET_LAND_WALK, TransferDirection.ToClient);
        }
    }
}
