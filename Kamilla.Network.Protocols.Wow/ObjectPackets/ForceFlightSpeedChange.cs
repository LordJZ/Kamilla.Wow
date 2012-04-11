
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceFlightSpeedChange : ForceChangePacket
    {
        protected override bool IsMaskSequenceSwapped
        {
            get
            {
                return false;
            }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 0, 2, 5, 7, 3, 6, 1, 4 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 2, 4, 5, 3, -1, 1, -2, 0, 6, 7 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_FLIGHT_SPEED; }
        }
    }
}
