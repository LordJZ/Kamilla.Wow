
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceRunBackSpeedChange : ForceChangePacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 5, 4, 3, 6, 0, 2, 7, 1 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 4, 6, 0, 1, -2, 3, 7, 5, 2, -1 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_RUN_BACK_SPEED; }
        }
    }
}
