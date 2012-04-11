
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceDisableCollision : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 7, 1, 2, 6, 0, 4, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 3, -1, 7, 4, 0, 6, 1, 5, 2 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_DISABLE_COLLISION, TransferDirection.ToClient);
        }
    }
}
