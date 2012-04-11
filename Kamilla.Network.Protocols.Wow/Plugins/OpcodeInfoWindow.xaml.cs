using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Kamilla.CodeHighlighting;
using Kamilla.IO;
using Kamilla.Network.Logging;
using Kamilla.Network.Protocols.Wow.Game;
using Kamilla.Network.Protocols.Wow.ObjectPackets;
using Kamilla.Network.Protocols.Wow.Parsers.Gossip;
using Kamilla.Network.Protocols.Wow.Parsers.Queries;
using Kamilla.Network.Viewing;
using Kamilla.WPF;
using Microsoft.Win32;
using System.Reflection;

namespace Kamilla.Network.Protocols.Wow.Plugins
{
    public partial class OpcodeInfoWindow
    {
        NetworkLogViewerBase m_viewer;

        public OpcodeInfoWindow(NetworkLogViewerBase viewer)
        {
            InitializeComponent();

            m_viewer = viewer;
            var window = viewer.InterfaceObject as Window;
            if (window != null)
            {
                this.Owner = window;
                this.Style = window.Style;

                var styler = window as INotifyStyleChanged;
                if (styler != null)
                    styler.StyleChanged += (o, e) => this.Style = ((Window)m_viewer.InterfaceObject).Style;
            }

            var fields = typeof(WowOpcodes).GetFields(BindingFlags.Static | BindingFlags.Public);

            var list = new List<string>(fields.Length);
            foreach (var field in fields)
            {
                var value = (uint)field.GetRawConstantValue();
                if (value != SpecialOpcodes.UnknownOpcode)
                    list.Add(field.Name);
            }
            list.Sort();

            var items = ui_cbInput.Items;
            foreach (var item in list)
                items.Add(item);

            this.Prepare(WowOpcodes.UNKNOWN_OPCODE);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void ui_btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Prepare(WowOpcodes opcode)
        {
            ui_tbError.Text = string.Empty;

            if (opcode != WowOpcodes.UNKNOWN_OPCODE)
            {
                ui_cbInput.Text = opcode.ToString();
                Analyze(opcode);
            }
            else
            {
                ui_tbResult.Text =
                    "Enter an opcode name (case-insensitive), an opcode id, a " +
                    "jam opcode id (prefixed with '-j'), or an auth opcode " +
                    "id (prefixed with '-a'), in decimal or hexadecimal representation, " +
                    "then press Submit to view summary on the opcode." +
                    Environment.NewLine +
                    "Special and auth opcodes are decondensed automatically." +
                    Environment.NewLine + Environment.NewLine +
                    "Example:" +
                    Environment.NewLine +
                    "'-j 1' or '-j 0x1' will produce summary for jam opcode that condences into 1." +
                    Environment.NewLine +
                    "'0x76CD' will procude summary for opcode #30413." +
                    Environment.NewLine +
                    "'CMSG_PING' will produce summary for client's ping opcode." +
                    Environment.NewLine + Environment.NewLine +
                    "Press Reset when you need to read this text again.";
            }
        }

        private void ui_btnOK_Click(object sender, RoutedEventArgs e)
        {
            WowOpcodes opcode = WowOpcodes.UNKNOWN_OPCODE;

            string text = ui_cbInput.Text;
            if (string.IsNullOrEmpty(text))
            {
                ui_tbError.Text = "Enter opcode id or name into the text box.";
                return;
            }

            Func<uint, uint> transformer = null;
            if (text.StartsWith("-j"))
            {
                transformer = x => Disassembly.UncondenseJam(x);
                text = text.Substring(2).Trim();
            }
            else if (text.StartsWith("-ctor"))
            {
                transformer = x =>
                {
                    var info = OpcodeInfoPlugin.OpcodeInfos.FirstOrDefault(m => m.Constructor == x);
                    if (info != null)
                        return info.Opcode;

                    return uint.MaxValue;
                };
                text = text.Substring(5).Trim();
            }
            else if (text.StartsWith("-dtor"))
            {
                transformer = x =>
                {
                    var info = OpcodeInfoPlugin.OpcodeInfos.FirstOrDefault(m => m.Destructor == x);
                    if (info != null)
                        return info.Opcode;

                    return uint.MaxValue;
                };
                text = text.Substring(5).Trim();
            }
            else if (text.StartsWith("-a"))
            {
                transformer = x => Disassembly.UncondenseAuth(x);
                text = text.Substring(2).Trim();
            }
            else if (text.StartsWith("-c"))
            {
                transformer = x => Disassembly.UncondenseRegular(x);
                text = text.Substring(2).Trim();
            }
            else if (text.StartsWith("-h"))
            {
                transformer = x =>
                {
                    var info = OpcodeInfoPlugin.OpcodeInfos.FirstOrDefault(m => m.Handler == x);
                    if (info != null)
                        return info.Opcode;

                    return uint.MaxValue;
                };
                text = text.Substring(2).Trim();
            }

            uint value;
            try { value = text.ParseUInt32(); }
            catch { value = uint.MaxValue; }

            if (value != uint.MaxValue)
            {
                if (transformer != null)
                    opcode = (WowOpcodes)transformer(value);
                else
                    opcode = (WowOpcodes)value;
            }
            else if (!Enum.TryParse<WowOpcodes>(text.ToUpper(), out opcode))
                opcode = WowOpcodes.UNKNOWN_OPCODE;

            if (opcode == WowOpcodes.UNKNOWN_OPCODE)
            {
                ui_tbError.Text = "Cannot convert '" + text + "' to opcode.";
                return;
            }

            Analyze(opcode);
        }

        internal void Analyze(WowOpcodes opcode)
        {
            ui_tbError.Text = string.Empty;

            var builder = new StringBuilder();

            builder.AppendLine("Name: " + opcode);
            builder.AppendFormatLine("Values: {0} 0x{0:X4}", (uint)opcode);
            builder.AppendLine(Enum.IsDefined(typeof(WowOpcodes), (uint)opcode) ? "Found in enum." : "Not found in enum.");
            builder.AppendLine();

            if (opcode.IsJamOpcode())
                builder.AppendFormatLine("JAM opcode: {0} 0x{0:X2}", opcode.CondenseJamOpcode());
            if (opcode.IsAuthOpcode())
                builder.AppendFormatLine("Auth opcode: {0} 0x{0:X2}", opcode.CondenseAuthOpcode());
            else if (opcode.IsRegularOpcode())
            {
                var cond = opcode.CondenseOpcode();

                builder.AppendFormatLine("Condensed opcode: {0} 0x{0:X3}", cond);

                //if (CondensedOpcodes.Storage.ContainsKey(cond))
                //    builder.AppendLine("Cond Name: " + CondensedOpcodes.Storage[cond]);
                //else
                //    builder.AppendLine("Cond Name not found.");
            }

            var info = OpcodeInfoPlugin.OpcodeInfos.FirstOrDefault(x => x.Opcode == (uint)opcode);
            if (info != null)
            {
                builder.AppendLine();
                builder.AppendLine("Opcode Info Found:");

                if (info.Index != 0)
                    builder.AppendLine(" Index: " + info.Index);
                if (info.Constructor != 0)
                    builder.AppendLine(" Constructor: 0x" + info.Constructor.ToString("X6"));
                if (info.Handler != 0)
                    builder.AppendLine(" Handler: 0x" + info.Handler.ToString("X6"));
                if (info.Destructor != 0)
                    builder.AppendLine(" Destructor: 0x" + info.Destructor.ToString("X6"));

                if (!string.IsNullOrEmpty(info.Comment))
                    builder.AppendLine(" Comment: " + info.Comment);

                if (info.Senders != null && info.Senders.Length > 0)
                {
                    builder.AppendLine(" Senders:");
                    foreach (var sender in info.Senders)
                    {
                        if (string.IsNullOrEmpty(sender.Name))
                            builder.AppendFormatLine("  Function at 0x{0:X6} (code at 0x{1:X6})",
                                sender.Function, sender.Address);
                        else
                            builder.AppendFormatLine("  '{2}' at 0x{0:X6} (code at 0x{1:X6})",
                                sender.Function, sender.Address, sender.Name);
                    }
                }
            }

            builder.AppendLine();

            //string desc = opcode.GetDescription();
            //if (desc != string.Empty)
            //{
            //    builder.AppendLine();
            //    builder.Append(desc);
            //}

            if (opcode.IsCompressedOpcode())
            {
                builder.AppendLine("Compressed Packet, uncompressed version:");
                Analyze(opcode.MakeUncompressed());
                builder.AppendLine(ui_tbResult.Text.PadMultiline(2));
            }

            ui_tbResult.Text = builder.ToString();
        }
    }
}
