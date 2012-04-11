
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceWaterWalkAck : ForceAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_WATER_WALK_ACK; }
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
