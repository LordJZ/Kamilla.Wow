
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineGravityDisable : PackedGuidPacket
    {
        public override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_DISABLE_GRAVITY; }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 0, 7, 1, 3, 5, 6, 2 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 7, 0, 1, 4, 2, 3, 6, 5 }; }
        }
    }
}
