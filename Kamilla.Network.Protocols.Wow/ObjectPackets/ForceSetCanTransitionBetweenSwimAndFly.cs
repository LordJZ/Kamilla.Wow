
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCanTransitionBetweenSwimAndFly : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 7, 3, 2, 6, 4, 0, 1, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 3, 0, 5, -1, 6, 2, 1, 4, 7 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_ENABLE_TRANSITION_BETWEEN_SWIM_AND_FLY, TransferDirection.ToClient);
        }
    }
}
