using System;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public class MonsterMove : LazyObjectPacket
    {
        public WowGuid Unit { get; set; }
        public byte UnkByte { get; set; }

        public Vector3 CurrentPosition
        {
            get { EnsureRead(1); return m_currentPosition; }
            set { m_currentPosition = value; }
        }
        protected Vector3 m_currentPosition;

        public uint TickCount
        {
            get { EnsureRead(1); return m_tickCount; }
            set { m_tickCount = value; }
        }
        protected uint m_tickCount;

        public SplineType SplineType
        {
            get { EnsureRead(1); return m_splineType; }
            set { m_splineType = value; }
        }
        protected SplineType m_splineType;

        public Vector3 FacingSpot
        {
            get { EnsureRead(1); return m_facingSpot; }
            set { m_facingSpot = value; }
        }
        protected Vector3 m_facingSpot;

        public WowGuid FacingTarget
        {
            get { EnsureRead(1); return m_facingTarget; }
            set { m_facingTarget = value; }
        }
        protected WowGuid m_facingTarget;

        public float FacingAngle
        {
            get { EnsureRead(1); return m_facingAngle; }
            set { m_facingAngle = value; }
        }
        protected float m_facingAngle;

        public SplineFlags SplineFlags
        {
            get { EnsureRead(1); return m_splineFlags; }
            set { m_splineFlags = value; }
        }
        protected SplineFlags m_splineFlags;

        public byte AnimEmote
        {
            get { EnsureRead(1); return m_animEmote; }
            set { m_animEmote = value; }
        }
        protected byte m_animEmote;

        public uint AnimTime
        {
            get { EnsureRead(1); return m_animTime; }
            set { m_animTime = value; }
        }
        protected uint m_animTime;

        public uint MoveTime
        {
            get { EnsureRead(1); return m_moveTime; }
            set { m_moveTime = value; }
        }
        protected uint m_moveTime;

        public float TrajectorySingle
        {
            get { EnsureRead(1); return m_trajectorySingle; }
            set { m_trajectorySingle = value; }
        }
        protected float m_trajectorySingle;

        public uint TrajectoryUInt32
        {
            get { EnsureRead(1); return m_trajectoryUInt32; }
            set { m_trajectoryUInt32 = value; }
        }
        protected uint m_trajectoryUInt32;

        public Vector3[] Points
        {
            get { EnsureRead(1); return m_points; }
            set { m_points = value; }
        }
        protected Vector3[] m_points;

        public MonsterMove(StreamHandler Reader, bool LazyReading)
        {
            this.Unit = Reader.ReadPackedGuid();

            this.Reader = Reader;

            m_readers = new Action[]
                {
                    ReadMovementData
                };

            if (!LazyReading)
                EnsureRead();
        }

        protected virtual void ReadMovementData()
        {
            this.UnkByte = Reader.ReadByte();
            m_currentPosition = Reader.ReadVector3();
            m_tickCount = Reader.ReadUInt32();
            m_splineType = (SplineType)Reader.ReadByte();

            switch (m_splineType)
            {
                case SplineType.Normal:
                    break;
                case SplineType.Stop:
                    // client sets following values to:
                    // movementFlags = 0x1000;
                    // moveTime = 0;
                    // splinesCount = 1;
                    m_points = new Vector3[0];
                    return;
                case SplineType.FacingSpot:
                    m_facingSpot = Reader.ReadVector3();
                    break;
                case SplineType.FacingTarget:
                    m_facingTarget = Reader.ReadGuid();
                    break;
                case SplineType.FacingAngle:
                    m_facingAngle = Reader.ReadSingle();
                    break;
                default:
                    throw new Exception("Not updated SplineType switch in MonsterMove (Read)");
            }

            m_splineFlags = (SplineFlags)Reader.ReadUInt32();

            if ((m_splineFlags & SplineFlags.Animation) != 0)
            {
                m_animEmote = Reader.ReadByte();
                m_animTime = Reader.ReadUInt32();
            }

            m_moveTime = Reader.ReadUInt32();

            if ((m_splineFlags & SplineFlags.Parabolic) != 0)
            {
                m_trajectorySingle = Reader.ReadSingle();
                m_trajectoryUInt32 = Reader.ReadUInt32();
            }

            uint pointCount = Reader.ReadUInt32();
            m_points = new Vector3[pointCount];

            if ((m_splineFlags & (SplineFlags.Flying | SplineFlags.CatMullRom)) != 0)
            {
                for (uint i = 0; i < pointCount; ++i)
                    m_points[i] = Reader.ReadVector3();
            }
            else
            {
                m_points[0] = Reader.ReadVector3();

                var packedAgainst = new Vector3();
                packedAgainst.X = (m_currentPosition.X + m_points[0].X) * 0.5f;
                packedAgainst.Y = (m_currentPosition.Y + m_points[0].Y) * 0.5f;
                packedAgainst.Z = (m_currentPosition.Z + m_points[0].Z) * 0.5f;

                for (uint i = 1; i < pointCount; ++i)
                    m_points[i] = Reader.ReadUInt32().UnpackAgainst(ref packedAgainst);
            }
        }

        public override void Save(StreamHandler writer)
        {
            throw new NotImplementedException();
        }

        public override void ToString(StringBuilder builder)
        {
            EnsureRead();

            builder.AppendLine("Unit: " + Unit);
            builder.AppendLine("Unk byte: " + UnkByte);

            MovementDataToString(builder);
        }

        protected virtual void MovementDataToString(StringBuilder builder)
        {
            builder.AppendLine("Current Position: " + m_currentPosition);
            builder.AppendLine("Tick Count: " + m_tickCount);
            builder.AppendLine("Spline Type: " + m_splineType);

            switch (m_splineType)
            {
                case SplineType.Normal:
                    break;
                case SplineType.Stop:
                    // client sets following values to:
                    // movementFlags = 0x1000;
                    // moveTime = 0;
                    // splinesCount = 1;
                    return;
                case SplineType.FacingSpot:
                    builder.AppendLine("Facing Spot: " + m_facingSpot);
                    break;
                case SplineType.FacingTarget:
                    builder.AppendLine("Facing Target: " + m_facingTarget);
                    break;
                case SplineType.FacingAngle:
                    builder.AppendLine("Facing Angle: " + m_facingAngle);
                    break;
                default:
                    throw new Exception("Not updated SplineType switch in MonsterMove (ToString)");
            }

            builder.AppendLine("Spline Flags: " + m_splineFlags);

            if ((m_splineFlags & SplineFlags.Animation) != 0)
            {
                builder.AppendLine("Anim Emote: " + m_animEmote);
                builder.AppendLine("Anim Time: " + m_animTime);
            }

            builder.AppendLine("Move Time: " + m_moveTime);

            if ((m_splineFlags & SplineFlags.Parabolic) != 0)
            {
                builder.AppendLine("Trajectory Vertical Speed: " + m_trajectorySingle);
                builder.AppendLine("Trajectory UInt32: " + m_trajectoryUInt32);
            }

            builder.AppendLine();

            foreach (var point in m_points)
                builder.AppendLine("Point: " + point);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MONSTER_MOVE, TransferDirection.ToClient);
        }
    }

    public sealed class MonsterMoveTransport : MonsterMove
    {
        public MonsterMoveTransport(StreamHandler Reader, bool LazyReading)
            : base(Reader, LazyReading)
        {
        }

        public WowGuid TransportGuid
        {
            get { EnsureRead(1); return m_transportGuid; }
            set { m_transportGuid = value; }
        }
        private WowGuid m_transportGuid;

        public sbyte TransportSeat
        {
            get { EnsureRead(1); return m_transportSeat; }
            set { m_transportSeat = value; }
        }
        private sbyte m_transportSeat;

        protected override void ReadMovementData()
        {
            m_transportGuid = Reader.ReadPackedGuid();
            m_transportSeat = Reader.ReadSByte();

            base.ReadMovementData();
        }

        protected override void MovementDataToString(StringBuilder builder)
        {
            builder.AppendLine("Transport Guid: " + m_transportGuid);
            builder.AppendLine("Transport Seat: " + m_transportSeat);

            base.MovementDataToString(builder);
        }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(WowOpcodes.SMSG_MONSTER_MOVE_TRANSPORT, TransferDirection.ToClient);
        }
    }
}
