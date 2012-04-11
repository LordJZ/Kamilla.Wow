
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetCanTransitionBetweenSwimAndFlyAck : ForceAckPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK; }
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
