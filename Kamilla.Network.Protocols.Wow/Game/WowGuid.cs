using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Kamilla.IO;

namespace Kamilla.Network.Protocols.Wow.Game
{
    public enum WowGuidKind : int
    {
        Player,
        GameObject,
        Unit,
        Item,
        DynamicObject,
        Group,
        Guild,
        BattlefieldQueue,
        //Instance,
        Unknown
    }

    public enum WowGuidType : int
    {
        Item,
        Player,
        GameObject,
        Transport,
        Creature,
        Pet,
        Vehicle,
        DynamicObject,
        Corpse,
        TransportMo,
        Group,
        Guild,
        BattlefieldQueue,
        //Instance,
        Unknown
    }

    /// <summary>
    /// Represents a globally-unique identifier of a World of Warcraft entity.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct WowGuid : IEquatable<WowGuid>, IEquatable<ulong>
    {
        class HighInfo
        {
            public HighInfo(WowGuidType type, WowGuidKind kind,
                int mask, int value, int defaultValue)
            {
                this.Type = type;
                this.Kind = kind;
                this.Mask = mask;
                this.Value = value;
                this.DefaultValue = defaultValue;
            }

            public readonly WowGuidType Type;
            public readonly WowGuidKind Kind;
            public readonly int Mask;
            public readonly int Value;
            public readonly int DefaultValue;
        }

        // HIGH GUID: 0xXYZ
        // X = GUID_TYPE
        // GUID_TYPE_EXTENDED = 1
        // if (GUID_TYPE_EXTENDED) YZ = EXTENDED_GUID_TYPE
        // EXTENDED_GUID_TYPE_BFQUEUE == 0xF1

        static readonly HighInfo[] s_typeValuePairs = new HighInfo[]
        {
            new HighInfo(WowGuidType.Item,          WowGuidKind.Item,           0xF00, 0x400, 0x400),   // Confirmed check: 0xF0F&a == 0x400
            new HighInfo(WowGuidType.Player,        WowGuidKind.Player,         0xF00, 0x000, 0x000),   // Confirmed check (also checks for lesser 55 bits to be non-zero)
            new HighInfo(WowGuidType.GameObject,    WowGuidKind.GameObject,     0xF0F, 0xF01, 0xF11),
            new HighInfo(WowGuidType.Transport,     WowGuidKind.GameObject,     0xF0F, 0xF02, 0xF12),
            new HighInfo(WowGuidType.TransportMo,   WowGuidKind.GameObject,     0xFFF, 0x1FC, 0x1FC),   // Confirmed check
            new HighInfo(WowGuidType.Creature,      WowGuidKind.Unit,           0xF0F, 0xF03, 0xF13),
            new HighInfo(WowGuidType.Pet,           WowGuidKind.Unit,           0xF0F, 0xF04, 0xF14),   // Confirmed check
            new HighInfo(WowGuidType.Vehicle,       WowGuidKind.Unit,           0xF0F, 0xF05, 0xF15),
            new HighInfo(WowGuidType.DynamicObject, WowGuidKind.DynamicObject,  0xFFF, 0xF10, 0xF10),
            new HighInfo(WowGuidType.Corpse,        WowGuidKind.DynamicObject,  0xFFF, 0xF50, 0xF50),
            new HighInfo(WowGuidType.Group,         WowGuidKind.Group,          0xFFF, 0x1F5, 0x1F5),
            new HighInfo(WowGuidType.Guild,         WowGuidKind.Guild,          0xFFF, 0x1FF, 0x1FF),
            // Battlefield Type: (guid >> 16) & 0xF
            //  BATTLEFIELD_TYPE_WORLD_PVP == 2
            //  BATTLEFIELD_TYPE_WARGAME == 3
            new HighInfo(WowGuidType.BattlefieldQueue,WowGuidKind.BattlefieldQueue,0xFFF,0x1F1,0x1F1),  // Confirmed check
        };

        /// <summary>
        /// Represents an empty WowGuid.
        /// </summary>
        public static readonly WowGuid Empty = new WowGuid();

        /// <summary>
        /// Initializes a new instance of <see cref="Kamilla.Network.Protocols.Wow.WowGuid"/> structure
        /// using the specified <see cref="System.UInt64"/> value.
        /// </summary>
        /// <param name="guid">
        /// The underlying <see cref="System.UInt64"/> value.
        /// </param>
        public WowGuid(ulong guid)
        {
            m_raw = guid;
        }

        public WowGuid(byte[] bytes)
        {
            m_raw = BitConverter.ToUInt64(bytes, 0);
        }

        public WowGuid(byte[] bytes, int startIndex)
        {
            m_raw = BitConverter.ToUInt64(bytes, startIndex);
        }

        public WowGuid(WowGuidType type, ulong counter)
            : this(type, 0, counter)
        {
        }

        public WowGuid(WowGuidType type, uint entry, ulong counter)
        {
            m_raw = 0;

            var info = s_typeValuePairs.FirstOrDefault(_ => _.Type == type);
            if (info == null)
                throw new ArgumentException("type");

            this.High = info.DefaultValue;
            this.Entry = entry;
            this.Counter = counter;
        }

        /// <summary>
        /// Gets the underlying <see cref="System.UInt64"/> value.
        /// </summary>
        public ulong Raw
        {
            get { return m_raw; }
        }

        [FieldOffset(0)]
        private ulong m_raw;

        /// <summary>
        /// Exposes access to raw guid bytes.
        /// </summary>
        [FieldOffset(0)]
        public unsafe fixed byte Bytes[sizeof(ulong)];

        uint LoPart { get { return (uint)((m_raw      ) & uint.MaxValue); } }
        uint HiPart { get { return (uint)((m_raw >> 32) & uint.MaxValue); } }

        bool Is24bitCounter { get { return this.IsPet; } }

        public int High
        {
            get { return (int)(m_raw >> (64 - HighBits)); }
            private set { m_raw &= ~HighBitsMask; m_raw |= (ulong)value << (64 - HighBits); }
        }

        public uint Entry
        {
            get { return (uint)((m_raw >> CounterBits) & EntryBitsMask); }
            private set { m_raw &= ~(EntryBitsMask << CounterBits); m_raw |= ((ulong)value & EntryBitsMask) << CounterBits; }
        }

        public ulong Counter
        {
            get { return m_raw & CounterBitsMask; }
            private set { m_raw &= ~CounterBitsMask; m_raw |= value & CounterBitsMask; }
        }

        public WowGuidKind Kind
        {
            get
            {
                var high = this.High;

                var info = s_typeValuePairs.FirstOrDefault(_ => (high & _.Mask) == _.Value);
                if (info != null)
                    return info.Kind;

                return WowGuidKind.Unknown;
            }
        }

        public WowGuidType Type
        {
            get
            {
                var high = this.High;

                var info = s_typeValuePairs.FirstOrDefault(_ => (high & _.Mask) == _.Value);
                if (info != null)
                    return info.Type;

                return WowGuidType.Unknown;
            }
        }

        int HighBits { get { return 12; } }
        int EntryBits
        {
            get
            {
                if (this.IsGameObject || this.IsCreature || this.IsVehicle || this.IsTransport)
                    return 20;

                if (this.IsPet)
                    return 28;

                if (this.IsGroup || this.IsGuild)
                    return 4;

                return 0;
            }
        }
        int CounterBits { get { return 64 - HighBits - EntryBits; } }

        ulong HighBitsMask { get { return (1UL << HighBits) - 1; } }
        ulong EntryBitsMask { get { return (1UL << EntryBits) - 1; } }
        ulong CounterBitsMask { get { return (1UL << CounterBits) - 1; } }

        public bool IsPlayer { get { return (this.High & 0xF00) == 0x000; } }
        public bool IsDynamicObject { get { return this.High == 0xF10; } }
        public bool IsCorpse { get { return this.High == 0xF50; } }
        public bool IsGameObject { get { return (this.High & 0xF0F) == 0xF01; } }
        public bool IsTransport { get { return (this.High & 0xF0F) == 0xF02; } }
        public bool IsCreature { get { return (this.High & 0xF0F) == 0xF03; } }
        public bool IsPet { get { return (this.High & 0xF0F) == 0xF04; } }
        public bool IsVehicle { get { return (this.High & 0xF0F) == 0xF05; } }
        public bool IsTransportMo { get { return this.High == 0x1FC; } }
        public bool IsItem { get { return (this.High & 0xF0F) == 0x400; } }
        public bool IsGroup { get { return this.High == 0x1F5; } }
        public bool IsGuild { get { return this.High == 0x1FF; } }

        public bool IsAnyDynamicObject { get { return (this.High & 0xF0F) == 0xF00; } }
        public bool IsAnyUnit { get { return this.IsCreature || this.IsPet || this.IsVehicle; } }
        public bool IsAnyGameObject { get { return this.IsGameObject || this.IsTransport || this.IsTransportMo; } }

        public bool HasEntry { get { return this.EntryBits > 0; } }

        public bool IsEmpty { get { return m_raw == 0UL; } }

        private static readonly string[,] formats = new string[2, 2]
        {
            // Without entry
            { "({2}, Counter: {0})", "({2}, Counter: {0}, Raw: {3:X16})" },

            // With entry
            { "({2}, {4}: {1}, Counter: {0})", "({2}, {4}: {1}, Counter: {0}, Raw: {3:X16})" },
        };

        public override string ToString()
        {
            if (this.IsEmpty)
                return "(No Guid)";

            return string.Format(CultureInfo.InvariantCulture,
                formats[this.HasEntry ? 1 : 0, PrintRaw ? 1 : 0],
                Counter, Entry,
                Type == WowGuidType.Unknown ? Type.ToString() + this.High.ToString("X3") : Type.ToString(),
                Raw, this.IsPet ? "Pet Number" : "Entry");
        }

        static WowGuid()
        {
            PrintRaw = Configuration.GetValue("Print Raw Value", false);
        }

        public static bool PrintRaw { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() == typeof(WowGuid))
                return this == (WowGuid)obj;

            if (obj.GetType() == typeof(ulong))
                return this == (ulong)obj;

            return false;
        }

        public bool Equals(ulong value)
        {
            return m_raw == value;
        }

        public bool Equals(WowGuid guid)
        {
            return guid.Raw == this.Raw;
        }

        public override int GetHashCode()
        {
            return (int)(this.LoPart ^ this.HiPart);
        }

        public static bool operator ==(WowGuid guid1, WowGuid guid2)
        {
            return guid1.Raw == guid2.Raw;
        }

        public static bool operator !=(WowGuid guid1, WowGuid guid2)
        {
            return !(guid1 == guid2);
        }

        public static bool operator ==(WowGuid guid, ulong guid_uint64)
        {
            return guid.Raw == guid_uint64;
        }

        public static bool operator !=(WowGuid guid, ulong guid_uint64)
        {
            return !(guid == guid_uint64);
        }

        public static explicit operator ulong(WowGuid value)
        {
            return value.Raw;
        }

        public static explicit operator WowGuid(ulong value)
        {
            return new WowGuid(value);
        }
    }

    public static partial class StreamHandlerWriterExtensions
    {
        /// <summary>
        /// Reads the packed Guid from the current stream and advances
        /// the current position of the stream by packed Guid size.
        /// </summary>
        public static WowGuid ReadPackedGuid(this StreamHandler reader)
        {
            byte mask = reader.ReadByte();

            if (mask == 0)
                return new WowGuid();

            ulong res = 0;

            for (int i = 0; i < 8; ++i)
            {
                if ((mask & 1) != 0)
                    res |= (ulong)reader.ReadByte() << (i << 3);

                mask >>= 1;
            }

            return new WowGuid(res);
        }

        /// <summary>
        /// Writes the packed Guid into the current stream and advances
        /// the current position of the stream by packed Guid size.
        /// </summary>
        public static void WritePackedGuid(this StreamHandler Writer, WowGuid objGuid)
        {
            Writer.WritePackedValue(objGuid.Raw);
        }

        /// <summary>
        /// Writes the packed value into the current stream and advances
        /// the current position of the stream by packed value size.
        /// </summary>
        public static void WritePackedValue(this StreamHandler Writer, ulong value)
        {
            long pos = Writer.BaseStream.Position;
            byte mask = 0;
            Writer.WriteByte(mask);

            if (value == 0)
                return;

            for (byte bit = 1; value != 0; bit <<= 1, value >>= 8)
            {
                if ((value & 0xFF) != 0)
                {
                    mask |= bit;
                    Writer.WriteByte((byte)(value & 0xFF));
                }
            }

            long cpos = Writer.BaseStream.Position;
            Writer.BaseStream.Position = pos;
            Writer.WriteByte(mask);
            Writer.BaseStream.Position = cpos;
        }

        /// <summary>
        /// Reads Wow Object Guid from the current stream and advances
        /// the current position of the stream by 8 bytes.
        /// </summary>
        public static WowGuid ReadGuid(this StreamHandler reader)
        {
            return new WowGuid(reader.ReadUInt64());
        }

        /// <summary>
        /// Writes Wow Object Guid into the current stream and advances
        /// the current position of the stream by 8 bytes.
        /// </summary>
        public static void WriteGuid(this StreamHandler Writer, WowGuid guid)
        {
            Writer.WriteUInt64(guid.Raw);
        }
    }

    /// <summary>
    /// Provides an implementation of <see cref="System.Collections.Generic.IComparer&lt;T&gt;"/>
    /// that compares instance of <see cref="Kamilla.Network.Protocols.Wow.WowGuid"/>
    /// based on their kind and entry only.
    /// </summary>
    public struct WowGuidKindEntryComparer : IComparer<WowGuid>, IEqualityComparer<WowGuid>
    {
        int IComparer<WowGuid>.Compare(WowGuid x, WowGuid y)
        {
            int result = ((int)x.Type).CompareTo((int)y.Type);
            if (result != 0)
                return result;

            return x.Entry.CompareTo(y.Entry);
        }

        public static int Compare(WowGuid x, WowGuid y)
        {
            int result = ((int)x.Type).CompareTo((int)y.Type);
            if (result != 0)
                return result;

            return x.Entry.CompareTo(y.Entry);
        }

        bool IEqualityComparer<WowGuid>.Equals(WowGuid x, WowGuid y)
        {
            return x.Kind == y.Kind && x.Entry == y.Entry;
        }

        public static bool Equals(WowGuid x, WowGuid y)
        {
            return x.Kind == y.Kind && x.Entry == y.Entry;
        }

        int IEqualityComparer<WowGuid>.GetHashCode(WowGuid guid)
        {
            return guid.Kind.GetHashCode() ^ guid.Entry.GetHashCode();
        }

        public static int GetHashCode(WowGuid guid)
        {
            return guid.Kind.GetHashCode() ^ guid.Entry.GetHashCode();
        }
    }
}
