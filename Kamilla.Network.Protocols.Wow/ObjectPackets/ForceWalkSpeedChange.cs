
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceWalkSpeedChange : ForceChangePacket
    {
        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 5, 1, 6, 0, 7, 2, 4 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { -2, 1, 4, 5, 6, 0, 7, 3, -1, 2 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_WALK_SPEED; }
        }
    }
}
