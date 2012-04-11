
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceRunSpeedChange : ForceChangePacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 3, 5, 1, 7, 0, 6, 4, 2 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 0, 1, -1, 4, 5, 7, -2, 3, 2, 6 }; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_RUN_SPEED; }
        }
    }
}
