
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceUnroot : ForcePacket
    {
        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 6, 1, 0, 2, 7, 3, 5 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 1, 3, 6, 2, 5, 0, 4, 7, -1 }; }
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MOVE_UNROOT, TransferDirection.ToClient);
        }
    }
}
