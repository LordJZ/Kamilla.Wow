
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineRoot : PackedGuidPacket
    {
        public override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_ROOT; }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 1, 2, 7, 5, 0, 3, 6 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 4, 0, 6, 7, 5, 2, 3, 1 }; }
        }
    }
}
