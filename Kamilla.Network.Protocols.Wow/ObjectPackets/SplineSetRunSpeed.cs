
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineSetRunSpeed : SplineSetPacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 7, 6, 0, 3, 4, 2, 1, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 6, 5, 1, 7, 3, 2, 4, -1, 0 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_SET_RUN_SPEED; }
        }
    }
}
