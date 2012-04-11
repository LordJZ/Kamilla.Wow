
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineSetRunBackSpeed : SplineSetPacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 5, 4, 1, 6, 7, 0, 2 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 7, 6, 5, 2, 0, -1, 3, 4, 1 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_SET_RUN_BACK_SPEED; }
        }
    }
}
