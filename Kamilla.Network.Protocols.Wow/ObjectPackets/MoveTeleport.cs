
namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class MoveTeleport : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_UPDATE_TELEPORT; }
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
