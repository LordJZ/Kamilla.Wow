
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class MovePitchStop : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_STOP_PITCH; }
        }

        protected override TransferDirection Direction
        {
            get { return TransferDirection.ToServer; }
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
