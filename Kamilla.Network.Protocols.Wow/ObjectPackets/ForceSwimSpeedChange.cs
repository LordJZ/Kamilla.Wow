
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSwimSpeedChange : ForceChangePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 4, 2, 7, 5, 1, 6, 0 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 2, 1, -1, -2, 4, 3, 7, 5, 6, 0 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_SWIM_SPEED; }
        }
    }
}
