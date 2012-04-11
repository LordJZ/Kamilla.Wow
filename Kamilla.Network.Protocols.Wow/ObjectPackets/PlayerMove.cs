
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
MovementStatusElements.HaveTransportData, // 6CECB3
MovementStatusElements.TransportGuidByte1, // 6CECC4
MovementStatusElements.TransportGuidByte3, // 6CECCF
MovementStatusElements.TransportGuidByte7, // 6CECDC
MovementStatusElements.TransportHaveTime2, // 6CECEC
MovementStatusElements.TransportGuidByte4, // 6CECF7
MovementStatusElements.TransportGuidByte2, // 6CED08
MovementStatusElements.TransportGuidByte6, // 6CED11
MovementStatusElements.TransportHaveTime3, // 6CED2C
MovementStatusElements.TransportGuidByte0, // 6CED3D
MovementStatusElements.TransportGuidByte5, // 6CED44
MovementStatusElements.GuidByte1, // 6CED51
MovementStatusElements.Pitch, // 6CED87
MovementStatusElements.Flags2, // 6CEDB5
MovementStatusElements.GuidByte4, // 6CEDDD
MovementStatusElements.GuidByte5, // 6CEE02
MovementStatusElements.GuidByte7, // 6CEE27
MovementStatusElements.HaveFallData, // 6CEE51
MovementStatusElements.HaveFallDirection, // 6CEE7F
MovementStatusElements.GuidByte3, // 6CEEA7
MovementStatusElements.HaveSpline, // 6CEED7
MovementStatusElements.Flags2_2, // 6CEEDD
MovementStatusElements.Timestamp, // 6CEF26
MovementStatusElements.SplineElev, // 6CEF5E
MovementStatusElements.Flags, // 6CEF9B
MovementStatusElements.Flags_2, // 6CEFB4
MovementStatusElements.GuidByte0, // 6CEFDD
MovementStatusElements.GuidByte2, // 6CF003
MovementStatusElements.PositionO, // 6CF03A
MovementStatusElements.GuidByte6, // 6CF062
MovementStatusElements.HaveSpline2, // 6CF07F
MovementStatusElements.FallSinAngle, // 6CF0B1
MovementStatusElements.FallHorizontalSpeed, // 6CF0D1
MovementStatusElements.FallCosAngle, // 6CF0EE
MovementStatusElements.FallVerticalSpeed, // 6CF114
MovementStatusElements.FallTime, // 6CF124
MovementStatusElements.PositionZ, // 6CF13F
MovementStatusElements.GuidByte7_2, // 6CF144
MovementStatusElements.PositionX, // 6CF175
MovementStatusElements.TransportPositionY, // 6CF19B
MovementStatusElements.TransportGuidByte2_2, // 6CF1A0
MovementStatusElements.TransportGuidByte3_2, // 6CF1B9
MovementStatusElements.TransportTime, // 6CF1E3
MovementStatusElements.TransportGuidByte1_2, // 6CF1E6
MovementStatusElements.TransportGuidByte5_2, // 6CF1FF
MovementStatusElements.TransportPositionO, // 6CF230
MovementStatusElements.TransportGuidByte7_2, // 6CF235
MovementStatusElements.TransportGuidByte0_2, // 6CF24E
MovementStatusElements.TransportSeat, // 6CF278
MovementStatusElements.TransportGuidByte4_2, // 6CF27B
MovementStatusElements.TransportTime2, // 6CF2AA
MovementStatusElements.TransportTime3, // 6CF2C3
MovementStatusElements.TransportPositionZ, // 6CF2DE
MovementStatusElements.TransportGuidByte6_2, // 6CF2E3
MovementStatusElements.TransportPositionX, // 6CF314
MovementStatusElements.GuidByte4_2, // 6CF319
MovementStatusElements.Timestamp_2, // 6CF332
MovementStatusElements.PositionY, // 6CF363
MovementStatusElements.GuidByte3_2, // 6CF368
MovementStatusElements.GuidByte0_2, // 6CF381
MovementStatusElements.GuidByte6_2, // 6CF39A
MovementStatusElements.GuidByte1_2, // 6CF3B3
MovementStatusElements.PositionO_2, // 6CF3F2
MovementStatusElements.GuidByte5_2, // 6CF3FA
MovementStatusElements.GuidByte2_2, // 6CF416
MovementStatusElements.SplineElev_2, // 6CF458
MovementStatusElements.Pitch_2, // 6CF486
                };
            }
        }
    }
}
