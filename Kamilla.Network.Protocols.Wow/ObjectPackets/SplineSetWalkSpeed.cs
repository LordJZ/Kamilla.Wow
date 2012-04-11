
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineSetWalkSpeed : SplineSetPacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 0, 2, 3, 5, 7, 1, 6, 4 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 1, 7, 6, 3, -1, 4, 2, 0, 5 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_SET_WALK_SPEED; }
        }
    }
}
