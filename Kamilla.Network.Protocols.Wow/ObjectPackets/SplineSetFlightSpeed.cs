
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineSetFlightSpeed : SplineSetPacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 2, 7, 5, 3, 0, 6, 4, 1 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 7, 5, 6, 1, 2, 4, 3, -1, 0 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_SET_FLIGHT_SPEED; }
        }
    }
}
