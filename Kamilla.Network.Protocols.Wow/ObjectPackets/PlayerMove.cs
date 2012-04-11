
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class PlayerMove : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_UPDATE; }
        }

        protected override TransferDirection Direction
        {
            get { return TransferDirection.ToClient; }
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
