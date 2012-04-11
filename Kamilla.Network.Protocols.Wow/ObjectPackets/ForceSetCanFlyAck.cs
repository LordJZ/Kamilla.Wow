
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCanFlyAck : ForceAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_SET_CAN_FLY_ACK; }
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
