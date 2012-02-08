﻿
namespace Kamilla.Network.Protocols.Wow.OpcodeDatas
{
    public sealed class MoveTurnStartRight : RegularMovementPacket
    {
        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MOVE_START_TURN_RIGHT; }
        }

        protected override TransferDirection TransferDirection
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
