
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class MoveSetFacing : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_SET_FACING; }
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
