
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineGravityEnable : PackedGuidPacket
    {
        public override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_ENABLE_GRAVITY; }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 0, 6, 4, 1, 3, 7, 2, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 4, 1, 3, 0, 2, 6, 7, 5 }; }
        }
    }
}
