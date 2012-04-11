
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceKnockBackAck : ForceChangeAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_KNOCK_BACK_ACK; }
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
