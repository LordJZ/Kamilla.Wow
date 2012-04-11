
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceWalkSpeedChangeAck : ForceChangeAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK; }
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
