using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Kamilla;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Generic.Xml
{
    public enum XmlTypes
    {
        None        = 0,

        Byte,
        UInt8 = Byte,

        SByte,
        Int8 = SByte,

        Short,
        Int16 = Short,

        UShort,
        UInt16 = UShort,

        Int,
        Int32 = Int,

        UInt,
        UInt32 = UInt,

        ULong,
        UInt64 = ULong,

        Long,
        Int64 = Long,

        Float,
        Single = Float,

        Money64,
        Money32,

        Vector3,

        Guid,
        GUID = Guid,
        PackedGuid,
        PackedValue,
        CString,

        UnalignedBool,
        UnalignedBoolean = UnalignedBool,

        PascalStringByte,
        PascalStringUShort,
        PascalStringUInt,

        PackedDate,
        TimeBitFields = PackedDate,
        UnixTime,
        TimeSpan,
        TimeSpanMinutes,
        TimeSpanUntil,
        TimeSpanMinutesUntil,

        ObjectPacket,
    }

    static class XmlTypeReader
    {
        static Dictionary<XmlTypes, Func<StreamHandler, String>> Readers
            = new Dictionary<XmlTypes, Func<StreamHandler, String>>();

        static void RegisterReader(XmlTypes type, Func<StreamHandler, String> reader)
        {
            if (Readers.ContainsKey(type))
                throw new Exception("XmlTypeReader multiple time registered reader: " + type);

            Readers.Add(type, reader);
        }

        static XmlTypeReader()
        {
            RegisterReader(XmlTypes.Byte,   (x) => x.ReadByte().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.SByte,  (x) => x.ReadSByte().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.Short,  (x) => x.ReadInt16().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.UShort, (x) => x.ReadUInt16().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.Int,    (x) => x.ReadInt32().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.UInt,   (x) => x.ReadUInt32().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.Long,   (x) => x.ReadInt64().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.ULong,  (x) => x.ReadUInt64().ToString(CultureInfo.InvariantCulture));
            RegisterReader(XmlTypes.Float,  (x) => x.ReadSingle().ToString(CultureInfo.InvariantCulture));

            RegisterReader(XmlTypes.Vector3, (x) => x.ReadVector3().ToString());

            RegisterReader(XmlTypes.Money32, (x) => new Money(x.ReadUInt32()).ToString());
            RegisterReader(XmlTypes.Money64, (x) => new Money(x.ReadUInt64()).ToString());

            RegisterReader(XmlTypes.Guid,       (x) => x.ReadGuid().ToString());
            RegisterReader(XmlTypes.PackedGuid, (x) => x.ReadPackedGuid().ToString());
            RegisterReader(XmlTypes.PackedValue,(x) => x.ReadPackedGuid().Raw.ToString());
            RegisterReader(XmlTypes.CString,    (x) => x.ReadCString().ToString(CultureInfo.InvariantCulture));

            RegisterReader(XmlTypes.UnalignedBool, x => x.UnalignedReadBit().ToString());

            Func<StreamHandler, int, String> LengthedStringReader = (x, y) => Encoding.UTF8.GetString(x.ReadBytes(y));
            RegisterReader(XmlTypes.PascalStringByte,   (x) => LengthedStringReader(x, x.ReadByte()));
            RegisterReader(XmlTypes.PascalStringUShort, (x) => LengthedStringReader(x, x.ReadUInt16()));
            RegisterReader(XmlTypes.PascalStringUInt,   (x) => LengthedStringReader(x, (int)x.ReadUInt32()));

            RegisterReader(XmlTypes.PackedDate, (x) => x.ReadUInt32().AsTimeBitFields().ToString());
            RegisterReader(XmlTypes.UnixTime,   (x) => x.ReadUInt32().AsUnixTime().ToString());

            Func<uint, String> TimeSpanFormatter = seconds => TimeSpan.FromSeconds(seconds).ToString() + " (total " + seconds + " seconds)";
            Func<uint, String> UntilFormatter = seconds => DateTime.Now.AddSeconds((double)seconds).ToString();
            Func<uint, String> TimeSpanUntilFormatter = secs => TimeSpanFormatter(secs) + " (until " + UntilFormatter(secs) + ")";

            RegisterReader(XmlTypes.TimeSpan, (x) => TimeSpanFormatter(x.ReadUInt32()));
            RegisterReader(XmlTypes.TimeSpanMinutes, (x) => TimeSpanFormatter(x.ReadUInt32()*60));
            RegisterReader(XmlTypes.TimeSpanUntil, (x) => TimeSpanUntilFormatter(x.ReadUInt32()));
            RegisterReader(XmlTypes.TimeSpanMinutesUntil, (x) => TimeSpanUntilFormatter(x.ReadUInt32()*60));

            RegisterReader(XmlTypes.ObjectPacket, (x) => { throw new Exception(); });
        }

        public static string Read(StreamHandler reader, XmlTypes type)
        {
            if (!Readers.ContainsKey(type))
                throw new Exception("XmlTypeReader tried to read unhandled type: " + type);

            return Readers[type](reader);
        }
    }
}
