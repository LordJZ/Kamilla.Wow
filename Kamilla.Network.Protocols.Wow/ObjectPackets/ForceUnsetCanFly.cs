
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceUnsetCanFly : ForcePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 5, 7, 0, 3, 2, 6, 4, 1 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 2, 5, 1, 4, 0, 6, 7, -1, 3 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_UNSET_CAN_FLY, TransferDirection.ToClient);
        }
    }
}
