
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceRoot : ForcePacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 7, 4, 5, 6, 0, 1, 2, 3 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 3, 6, 1, 4, 0, 7, 2, 5, -1 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_ROOT, TransferDirection.ToClient);
        }
    }
}
