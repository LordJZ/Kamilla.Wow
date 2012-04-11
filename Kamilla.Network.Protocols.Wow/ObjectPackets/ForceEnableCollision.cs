
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceEnableCollision : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 2, 7, 3, 1, 4, 5, 6, 0 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 3, 0, 6, -1, 1, 5, 2, 4, 7 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_ENABLE_COLLISION, TransferDirection.ToClient);
        }
    }
}
