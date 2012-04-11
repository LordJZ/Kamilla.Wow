
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCanFly : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 1, 7, 2, 3, 5, 6, 4, 0 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 0, -1, 7, 6, 3, 1, 2, 5, 4 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_SET_CAN_FLY, TransferDirection.ToClient);
        }
    }
}
