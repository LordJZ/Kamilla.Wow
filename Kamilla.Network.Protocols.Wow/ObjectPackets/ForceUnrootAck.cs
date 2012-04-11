
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceUnrootAck : ForceAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_FORCE_UNROOT_ACK; }
        }

        protected override MovementStatusElements[] Elements
        {
            get
            {
                return new MovementStatusElements[]
                {
                };
            }
        }
    }
}
