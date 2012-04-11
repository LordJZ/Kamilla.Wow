
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCollisionHeightAck : ForceChangeAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_SET_COLLISION_HEIGHT_ACK; }
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
