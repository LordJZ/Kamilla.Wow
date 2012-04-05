using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Queries
{
    [WowPacketParser(WowOpcodes.SMSG_QUEST_POI_QUERY_RESPONSE)]
    internal sealed class QuestPoiQueryResponseParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Queries; } }

        QuestPoiData[] m_data;
        public QuestPoiData[] Data
        {
            get
            {
                if (!IsParsed)
                    Parse();

                return m_data;
            }
        }

        protected override void InternalParse()
        {
            m_data = new QuestPoiData[Reader.ReadInt32()];

            for (int i = 0; i < m_data.Length; ++i)
            {
                var data = m_data[i] = new QuestPoiData();

                data.QuestId = Reader.ReadUInt32();
                data.PoiCount = Reader.ReadInt32();
                data.Poi = new QuestPoi[data.PoiCount];

                for (int j = 0; j < data.PoiCount; ++j)
                {
                    var poi = new QuestPoi();

                    poi.Index = Reader.ReadInt32();
                    poi.ObjectiveIndex = Reader.ReadInt32();
                    poi.MapId = Reader.ReadUInt32();
                    poi.MapAreaId = Reader.ReadUInt32();
                    poi.FloorId = Reader.ReadUInt32();
                    poi.Unk3 = Reader.ReadUInt32();
                    poi.Unk4 = Reader.ReadUInt32();
                    poi.PoiCount = Reader.ReadInt32();
                    poi.Points = new QuestPoiPoint[poi.PoiCount];

                    for (int p = 0; p < poi.Points.Length; ++p)
                    {
                        poi.Points[p].X = Reader.ReadInt32();
                        poi.Points[p].Y = Reader.ReadInt32();
                    }

                    data.Poi[j] = poi;
                }
            }

            foreach (var pois in m_data)
            {
                Output.AppendLine("Quest Id: " + pois.QuestId);
                foreach (var poi in pois.Poi)
                {
                    Output.AppendFormatLine("  Objective: {0}, Map: {1} ({1:D}), Area: {2} ({2:D}), Floor: {3}, Unk3: {4}, Unk4: {5}", 
                        poi.ObjectiveIndex, ((Maps)poi.MapId).GetLocalizedName(), (Zones)poi.MapAreaId, poi.FloorId, poi.Unk3, poi.Unk4);

                    foreach (var point in poi.Points)
                        Output.AppendFormatLine("    X: {0} Y: {1}", point.X, point.Y);
                }
            }
        }
    }

    internal class QuestPoiData
    {
        public uint  QuestId;
        public int   PoiCount;
        public QuestPoi[] Poi;
    }

    internal class QuestPoi
    {
        public int Index;
        public int ObjectiveIndex;
        public uint MapId;
        public uint MapAreaId;
        public uint FloorId;
        public uint Unk3;
        public uint Unk4;
        public int PoiCount;

        public QuestPoiPoint[] Points;
    }

    internal struct QuestPoiPoint
    {
        public int X;
        public int Y;
    }
}
