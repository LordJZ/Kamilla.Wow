﻿using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Kamilla.Network.Parsing;
using Kamilla.Network.Protocols.Wow.Parsers.Generic;
using Kamilla.Network.Viewing;

namespace Kamilla.Network.Protocols.Wow
{
    public sealed class WowLatestProtocol : Protocol
    {
        sealed class ItemData : DefaultProtocol.BaseItemData
        {
            internal ItemData(ViewerItem item)
                : base(item)
            {
            }

            internal void ParserChanged()
            {
                this.Changed("ParsingError");
                this.Changed("Preview");
                this.Changed("IsUndefinedParser");
            }

            string m_connId;
            string m_preview;

            public string ConnectionId
            {
                get
                {
                    if (m_connId == null)
                    {
                        var packet = m_item.Packet as WowPacket;
                        if (packet != null)
                            m_connId = packet.ConnectionId.ToString();
                        else
                            m_connId = string.Empty;
                    }
                    return m_connId;
                }
            }

            public string Preview
            {
                get
                {
                    if (m_preview == null)
                    {
                        var parser = m_item.Parser;
                        if (parser != null && parser.IsParsed)
                            m_preview = CreateAnnot(parser.ParsedText);
                    }

                    return m_preview;
                }
            }

            public override string C2sStr
            {
                get
                {
                    if (m_c2sStr == null)
                    {
                        var packet = m_item.Packet as WowPacket;
                        if (packet == null)
                            m_c2sStr = base.C2sStr;
                        else if (packet.Direction != TransferDirection.ToServer)
                            m_c2sStr = string.Empty;
                        else
                        {
                            var opcStr = ((WowOpcodes)packet.Opcode).ToString();
                            if (opcStr.StartsWith("CMSG_"))
                                opcStr = opcStr.Substring(5);

                            m_c2sStr = opcStr;
                        }
                    }

                    return m_c2sStr;
                }
            }

            public override string S2cStr
            {
                get
                {
                    if (m_s2cStr == null)
                    {
                        var packet = m_item.Packet as WowPacket;
                        if (packet == null)
                            m_s2cStr = base.S2cStr;
                        else if (packet.Direction != TransferDirection.ToClient)
                            m_s2cStr = string.Empty;
                        else
                        {
                            var opcStr = ((WowOpcodes)packet.Opcode).ToString();
                            if (opcStr.StartsWith("SMSG_"))
                                opcStr = opcStr.Substring(5);

                            m_s2cStr = opcStr;
                        }
                    }

                    return m_s2cStr;
                }
            }

            public bool ParsingError
            {
                get
                {
                    var parser = m_item.Parser;
                    if (parser != null)
                        return parser.ParsingError;

                    return false;
                }
            }

            public bool IsFreezed { get { return (m_item.Packet.Flags & PacketFlags.Freezed) != 0; } }
            public bool IsCustom { get { return (m_item.Packet.Flags & PacketFlags.Custom) != 0; } }
            public bool IsUndefinedParser { get { return m_item.Parser is UndefinedPacketParser; } }
        }

        static string CreateAnnot(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            int idx1 = text.IndexOf("_____");
            int idx2 = text.IndexOf("=====");

            int idx;
            if (idx1 >= 0)
            {
                if (idx2 >= 0)
                    idx = Math.Min(idx1, idx2);
                else
                    idx = idx1;
            }
            else if (idx2 >= 0)
                idx = idx2;
            else
                idx = -1;

            if (idx >= 0)
                text = text.Substring(0, idx);

            return text.TrimWhiteSpace(200, ' ');
        }

        NetworkLogViewerBase m_viewer;
        GridView m_view;
        ViewerItemEventHandler m_itemQueriedHandler;
        ViewerItemEventHandler m_itemParsingDoneHandler;

        public WowLatestProtocol()
        {
            m_itemQueriedHandler = new ViewerItemEventHandler(viewer_ItemQueried);
            m_itemParsingDoneHandler = new ViewerItemEventHandler(viewer_ItemParsingDone);
        }

        public override string Name
        {
            get { return Strings.ProtocolName; }
        }

        public override Type OpcodesEnumType
        {
            get { return typeof(WowOpcodes); }
        }

        public override ViewBase View
        {
            get { return m_view; }
        }

        class GridViewColumnWithId : GridViewColumn
        {
            public int ColumnId;
        }

        static readonly double[] s_columnWidths = new double[]
        {
            64,
            85,
            69,
            19,
            170,
            170,
            59,
            200
        };

        static readonly string[] s_columnBindings = new string[]
        {
            ".Index",
            ".Data.ArrivalTime",
            ".Data.ArrivalTicks",
            ".Packet.ConnectionId",
            ".Data.C2sStr",
            ".Data.S2cStr",
            ".Packet.Data.Length",
            ".Data.Preview",
        };

        static Brush s_freezedBrush;
        static Brush s_customBrush;

        public override void Load(NetworkLogViewerBase viewer)
        {
            if (m_viewer != null)
                throw new InvalidOperationException();

            m_viewer = viewer;
            viewer.ItemQueried += m_itemQueriedHandler;
            viewer.ItemParsingDone += m_itemParsingDoneHandler;

            var view = m_view = new GridView();

            var nColumns = s_columnWidths.Length;
            var headers = new string[]
            {
                NetworkStrings.CH_Number,
                NetworkStrings.CH_Time,
                NetworkStrings.CH_Ticks,
                Strings.CH_ConnId,
                NetworkStrings.CH_C2S,
                NetworkStrings.CH_S2C,
                NetworkStrings.CH_Length,
                Strings.CH_Preview,
            };
            if (headers.Length != nColumns)
                throw new InvalidOperationException();

            double[] widths = Configuration.GetValue("Column Widths", (double[])null);
            if (widths == null || widths.Length != nColumns)
                widths = s_columnWidths;

            int[] columnOrder = Configuration.GetValue("Column Order", (int[])null);
            if (columnOrder == null || columnOrder.Length != nColumns
                || columnOrder.Any(val => val >= nColumns || val < 0))
                columnOrder = Enumerable.Range(0, nColumns).ToArray();

            if (s_customBrush == null)
                s_customBrush = new SolidColorBrush(Color.FromRgb(132, 22, 35));

            if (s_freezedBrush == null)
                s_freezedBrush = new SolidColorBrush(Color.FromRgb(36, 176, 185));

            for (int i = 0; i < nColumns; i++)
            {
                int col = columnOrder[i];

                var item = new GridViewColumnWithId();
                item.ColumnId = col;
                item.Header = headers[col];
                item.Width = widths[col];

                var dataTemplate = new DataTemplate();
                dataTemplate.DataType = typeof(ItemData);

                var block = new FrameworkElementFactory(typeof(TextBlock));
                block.Name = "tb";
                block.SetValue(TextBlock.TextProperty, new Binding(s_columnBindings[col]));

                // Opcode
                if (col == 4 || col == 5)
                {
                    block.SetValue(TextBlock.FontFamilyProperty, new FontFamily("Lucida Console"));

                    DataTrigger trigger;

                    trigger = new DataTrigger();
                    trigger.Binding = new Binding(".Data.IsCustom");
                    trigger.Value = true;
                    trigger.Setters.Add(new Setter(TextBlock.ForegroundProperty, s_customBrush, "tb"));
                    dataTemplate.Triggers.Add(trigger);

                    trigger = new DataTrigger();
                    trigger.Binding = new Binding(".Data.IsFreezed");
                    trigger.Value = true;
                    trigger.Setters.Add(new Setter(TextBlock.ForegroundProperty, s_freezedBrush, "tb"));
                    dataTemplate.Triggers.Add(trigger);

                    trigger = new DataTrigger();
                    trigger.Binding = new Binding(".Data.IsUndefinedParser");
                    trigger.Value = true;
                    trigger.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.Gray, "tb"));
                    dataTemplate.Triggers.Add(trigger);
                }
                // Preview
                else if (col == 7)
                {
                    var trigger = new DataTrigger();
                    trigger.Binding = new Binding(".Data.ParsingError");
                    trigger.Value = true;
                    trigger.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.Red, "tb"));
                    dataTemplate.Triggers.Add(trigger);
                }

                dataTemplate.VisualTree = block;
                item.CellTemplate = dataTemplate;

                view.Columns.Add(item);
            }
        }

        public override void Unload()
        {
            if (m_viewer == null)
                throw new InvalidOperationException();

            var view = m_view;
            var columns = view.Columns;
            var nColumns = columns.Count;

            var widths = new double[nColumns];
            var order = new int[nColumns];

            for (int i = 0; i < nColumns; i++)
            {
                var column = (GridViewColumnWithId)columns[i];

                order[i] = column.ColumnId;
                widths[column.ColumnId] = column.Width;
            }

            Configuration.SetValue("Column Widths", widths);
            Configuration.SetValue("Column Order", order);
            m_view = null;

            m_viewer.ItemQueried -= m_itemQueriedHandler;
            m_viewer.ItemParsingDone -= m_itemParsingDoneHandler;

            m_viewer = null;
        }

        void viewer_ItemQueried(object sender, ViewerItemEventArgs e)
        {
            var item = e.Item;
            if (item.Data == null)
                item.Data = CreateDataForItem(item);
        }

        ItemData CreateDataForItem(ViewerItem item)
        {
            return new ItemData(item);
        }

        void viewer_ItemParsingDone(object sender, ViewerItemEventArgs e)
        {
            var item = e.Item;
            if (item.Data == null)
                item.Data = this.CreateDataForItem(item);

            ((ItemData)item.Data).ParserChanged();
        }

        protected override PacketParser InternalCreateParser(ViewerItem item)
        {
            var packet = item.Packet as WowPacket;
            if (packet == null)
                return null;

            return XmlParser.GetParser(packet) ?? base.InternalCreateParser(item);
        }

        public override string PacketContentsViewHeader(ViewerItem item)
        {
            var parser = item.Parser;
            var packet = item.Packet;
            var wowPacket = packet as WowPacket;
            var opcodePacket = packet as IPacketWithOpcode;

            int dataLength = packet.Data.Length;
            var builder = new StringBuilder(128);

            builder
                .Append("Packet ")
                .Append((packet.Direction == TransferDirection.ToServer) ? "C->S" : "S->C");

            if (opcodePacket != null)
            {
                var intOpcode = opcodePacket.Opcode;
                var opcode = (WowOpcodes)intOpcode;
                builder
                    .Append(", ").Append(opcode.ToString())
                    .Append(" (").Append(intOpcode)
                    .Append(", 0x").Append(intOpcode.ToString("X4"))
                    .Append(", ").Append(
                        (opcode.IsJamOpcode() ? "jam " + opcode.CondenseJamOpcode() :
                        (opcode.IsAuthOpcode() ? "auth " + opcode.CondenseAuthOpcode() :
                        (opcode.IsRegularOpcode() ? "cond " + opcode.CondenseOpcode() : "other")))
                        )
                    .Append(")");
            }

            builder
                .Append(", ").Append(dataLength)
                .Append(" bytes").Append(", Flags: ").Append(packet.Flags.ToString());

            return builder.ToString();
        }
    }
}