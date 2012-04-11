using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public sealed class ForceSetVehicleId : ForceChangePacket
    {
        uint m_newValue;
        public new uint NewValue
        {
            get
            {
                return m_newValue;
            }
            set
            {
                m_newValue = value;
                base.NewValue = value;
            }
        }

        protected override bool IsMaskSequenceSwapped { get { return false; } }

        protected override int[] MaskSequence
        {
            get { return new int[] { 4, 6, 5, 3, 1, 7, 2, 0 }; }
        }

        protected override int[] ByteSequence
        {
            get { return new int[] { 3, 6, -2, 4, 2, 1, -1, 7, 0, 5 }; }
        }

        protected override void ElementRead(StreamHandler reader, int index)
        {
            if (index == -2)
                this.NewValue = reader.ReadUInt32();
            else
                base.ElementRead(reader, index);
        }

        protected override void ElementWrite(StreamHandler writer, int index)
        {
            if (index == -2)
            {
                writer.FlushUnalignedBits();
                writer.WriteUInt32(this.NewValue);
            }
            else
                base.ElementWrite(writer, index);
        }

        public override WowOpcodes Opcode
        {
            get { return WowOpcodes.SMSG_MOVE_SET_VEHICLE_REC_ID; }
        }
    }
}
