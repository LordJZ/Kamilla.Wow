
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class SplineUnroot : PackedGuidPacket
    {
        public override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SPLINE_UNROOT; }
        }

        protected override int[] MaskSequence
        {
            get { return new int[] { 0, 6, 7, 4, 5, 1, 2, 3 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 7, 6, 2, 5, 0, 4, 1, 3 }; }
        }
    }
}
