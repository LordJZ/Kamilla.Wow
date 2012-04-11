
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineSetSwimBackSpeed : SplineSetPacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 2, 0, 3, 6, 4, 1, 5, 7 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 0, 7, 4, 3, -1, 2, 6, 5, 1 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_SET_SWIM_BACK_SPEED; }
        }
    }
}
