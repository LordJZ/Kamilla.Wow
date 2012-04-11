
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceUnsetCanTransitionBetweenSwimAndFly : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 5, 0, 3, 2, 7, 1, 6, 4 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 2, 7, 5, 0, -1, 6, 1, 4, 3 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_DISABLE_TRANSITION_BETWEEN_SWIM_AND_FLY, TransferDirection.ToClient);
        }
    }
}
