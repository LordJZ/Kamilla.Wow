using System;
using System.Collections;
using System.Linq;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets
{
    public abstract class PackedData : ObjectPacket
    {
        protected virtual bool IsMaskSequenceSwapped { get { return true; } }
        protected abstract int[] MaskSequence { get; }
        protected abstract int[] ByteSequence { get; }
        protected abstract int ByteXorValue { get; }

        void CheckSequences(int[] seq_b, int[] seq_m)
        {
            int size = seq_b.Count(element => element >= 0);

            if (size != seq_m.Count(x => x >= 0))
                throw new InvalidOperationException("Length of Mask Sequence must be equal to length of Byte Sequence.");
            if (size / 8 * 8 != size)
                throw new InvalidOperationException("Size of PackedData in bytes must be a multiple of 8.");
        }

        public sealed override void Read(StreamHandler reader)
        {
            var seq_b = ByteSequence;
            var seq_m = MaskSequence;
            var b_xor = ByteXorValue;

            int size = seq_m.Count(x => x >= 0);
            if (size != seq_m.Length && this.IsMaskSequenceSwapped)
                throw new InvalidOperationException("Cannot have elements in swapped MaskSequence.");
            CheckSequences(seq_b, seq_m);

            if (this.IsMaskSequenceSwapped)
            {
                var seq_m_copy = new int[seq_m.Length];
                for (int i = 0; i < seq_m.Length; )
                {
                    var t = i;
                    for (int j = t + 8 - 1; j >= t; --j, ++i)
                        seq_m_copy[j] = seq_m[i];
                }
                seq_m = seq_m_copy;
            }

            //byte[] data = new byte[size];
            //var src = new BitArray(reader.ReadBytes(size / 8));
            //var dst = new BitArray(size);

            //for (int i = 0; i < size; ++i)
            //    dst[seq_m[i]] = src[i];

            //for (int i = 0; i < seq_b.Length; ++i)
            //{
            //    var el = seq_b[i];
            //    if (el < 0)
            //        ElementRead(reader, el);
            //    else if (dst[el])
            //        data[el] = (byte)(reader.ReadByte() ^ b_xor);
            //}

            byte[] data = new byte[size];
            var dst = new BitArray(size);

            for (int i = 0; i < seq_m.Length; ++i)
            {
                var el = seq_m[i];
                if (el < 0)
                    ElementRead(reader, el);
                else
                    dst[el] = reader.UnalignedReadBit();
            }

            for (int i = 0; i < seq_b.Length; ++i)
            {
                var el = seq_b[i];
                if (el < 0)
                    ElementRead(reader, el);
                else if (dst[el])
                    data[el] = (byte)(reader.ReadByte() ^ b_xor);
            }

            PackedRead(data);
        }

        protected virtual void PackedRead(StreamHandler reader)
        {
            throw new NotImplementedException("Reading " + this.GetType().Name + " is not implemented.");
        }

        protected virtual void PackedRead(byte[] data)
        {
            using (var reader = new StreamHandler(data))
                PackedRead(reader);
        }

        /// <summary>
        /// When overriden, reads the element at specified negative, -1 based index from the provided stream.
        /// </summary>
        /// <param name="reader">
        /// Stream to read element from.
        /// </param>
        /// <param name="index">
        /// The negative, -1 based index of the element to read.
        /// </param>
        protected virtual void ElementRead(StreamHandler reader, int index)
        {
            throw new NotImplementedException("Reading specific elements is not implemented.");
        }

        public sealed override void Save(StreamHandler writer)
        {
            var seq_b = ByteSequence;
            var seq_m = MaskSequence;
            var b_xor = ByteXorValue;

            int size = seq_m.Count(x => x >= 0);
            if (size != seq_m.Length && this.IsMaskSequenceSwapped)
                throw new InvalidOperationException("Cannot have elements in swapped MaskSequence.");
            CheckSequences(seq_b, seq_m);

            if (this.IsMaskSequenceSwapped)
            {
                var seq_m_copy = new int[seq_m.Length];
                for (int i = 0; i < seq_m.Length; )
                {
                    var t = i;
                    for (int j = t + 8 - 1; j >= t; --j, ++i)
                        seq_m_copy[j] = seq_m[i];
                }
                seq_m = seq_m_copy;
            }

            byte[] data = new byte[size];
            PackedSave(data);

            var mask = new BitArray(size);

            for (int i = 0; i < size; ++i)
            {
                var el = seq_m[i];
                if (el < 0)
                    ElementWrite(writer, el);
                else
                    writer.UnalignedWriteBit(data[el] != 0);
            }

            writer.FlushUnalignedBits();

            for (int i = 0; i < seq_b.Length; ++i)
            {
                var el = seq_b[i];

                if (el < 0)
                    ElementWrite(writer, el);
                else if (data[el] != 0)
                    writer.WriteByte((byte)(data[el] ^ b_xor));
            }
        }

        protected virtual void PackedSave(StreamHandler writer)
        {
            throw new NotImplementedException("Saving " + this.GetType().Name + " is not implemented.");
        }

        protected virtual void PackedSave(byte[] data)
        {
            using (var writer = new StreamHandler(data))
                PackedSave(writer);
        }

        /// <summary>
        /// When overriden, writes the element at specified negative, -1 based index to the provided stream.
        /// </summary>
        /// <param name="writer">
        /// Stream to write element to.
        /// </param>
        /// <param name="index">
        /// The negative, -1 based index of the element to write.
        /// </param>
        protected virtual void ElementWrite(StreamHandler writer, int index)
        {
            throw new NotImplementedException("Writing specific elements is not implemented.");
        }
    }
}
