
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceRootAck : ForceAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_FORCE_ROOT_ACK; }
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
