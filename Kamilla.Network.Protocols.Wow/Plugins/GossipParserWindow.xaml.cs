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

namespace Kamilla.Network.Protocols.Wow.Plugins
{
    public partial class GossipParserWindow
    {
        static HighlightingProfile s_sqlHighlightingInfo = null;
        static Brush[] s_tokenBrushes;

        NetworkLogViewerBase m_viewer;

        BackgroundWorker m_parsingItemsWorker;
        BackgroundWorker m_creatingMenuDataWorker;

        MouseButtonEventHandler m_optItem_MouseDoubleClickHandler;
        SelectionChangedEventHandler m_lvMenus_SelectionChangedHandler;
        SelectionChangedEventHandler m_lvObjects_SelectionChangedHandler;
        RoutedEventHandler m_cbAllMenus_CheckedChangedHandler;
        RoutedEventHandler m_cbAllObjects_CheckedChangedHandler;

        public GossipParserWindow(NetworkLogViewerBase viewer)
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

            // Must create this in UI thread
            if (s_sqlHighlightingInfo == null)
            {
                s_sqlHighlightingInfo = new HighlightingProfile()
                {
                    Keywords = new[] { "insert", "update", "replace", "into", "values", "where", "set" },
                    KeywordsCaseSensitive = false,
                    MultilineCommentsEndWith = "*/",
                    MultilineCommentsStartWith = "/*",
                    OneLineCommentsStartWith = "--",
                };
            }

            if (s_tokenBrushes == null)
            {
                s_tokenBrushes = new Brush[5];
                s_tokenBrushes[(int)CodeTokens.Keyword] = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                s_tokenBrushes[(int)CodeTokens.MultilineComment] = new SolidColorBrush(Color.FromRgb(0, 128, 0));
                s_tokenBrushes[(int)CodeTokens.Number] = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                s_tokenBrushes[(int)CodeTokens.OneLineComment] = new SolidColorBrush(Color.FromRgb(0, 128, 0));
                s_tokenBrushes[(int)CodeTokens.String] = new SolidColorBrush(Color.FromRgb(163, 21, 21));
            }

            this.CommandBindings.AddRange(new[]
            {
                new CommandBinding(ApplicationCommands.Close, ApplicationCommands_CloseExecuted),
                new CommandBinding(ApplicationCommands.Save, ApplicationCommands_SaveExecuted),
                new CommandBinding(ApplicationCommands.SaveAs, ApplicationCommands_SaveAsExecuted),
                new CommandBinding(GossipParserCommands.ShowObjectEntries, ApplicationCommands_ShowObjectEntriesExecuted),
                new CommandBinding(GossipParserCommands.ShowMenuEntries, ApplicationCommands_ShowMenuEntriesExecuted),
                new CommandBinding(GossipParserCommands.ShowTextEntries, ApplicationCommands_ShowTextEntriesExecuted),
            });

            this.InputBindings.AddRange(new[]
            {
                new KeyBinding(ApplicationCommands.Close, Key.X, ModifierKeys.Alt),
                new KeyBinding(ApplicationCommands.Close, Key.Escape, ModifierKeys.None),
                new KeyBinding(ApplicationCommands.Save, Key.S, ModifierKeys.Control),
                new KeyBinding(ApplicationCommands.SaveAs, Key.S, ModifierKeys.Control | ModifierKeys.Shift),
            });

            m_optItem_MouseDoubleClickHandler = new MouseButtonEventHandler(optItem_MouseDoubleClick);
            m_lvMenus_SelectionChangedHandler = new SelectionChangedEventHandler(ui_lvMenus_SelectionChanged);
            m_lvObjects_SelectionChangedHandler = new SelectionChangedEventHandler(ui_lvObjects_SelectionChanged);
            m_cbAllMenus_CheckedChangedHandler = new RoutedEventHandler(ui_cbAllMenus_CheckedChanged);
            m_cbAllObjects_CheckedChangedHandler = new RoutedEventHandler(ui_cbAllObjects_CheckedChanged);

            SetProgressBarVisible(false);

            m_parsingItemsWorker = new BackgroundWorker();
            m_parsingItemsWorker.DoWork += new DoWorkEventHandler(m_parsingItemsWorker_DoWork);
            m_parsingItemsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_parsingItemsWorker_RunWorkerCompleted);
            m_parsingItemsWorker.WorkerReportsProgress = true;
            m_parsingItemsWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            m_parsingItemsWorker.WorkerSupportsCancellation = true;

            m_creatingMenuDataWorker = new BackgroundWorker();
            m_creatingMenuDataWorker.DoWork += new DoWorkEventHandler(m_creatingMenuDataWorker_DoWork);
            m_creatingMenuDataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_creatingMenuDataWorker_RunWorkerCompleted);
            m_creatingMenuDataWorker.WorkerReportsProgress = true;
            m_creatingMenuDataWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            m_creatingMenuDataWorker.WorkerSupportsCancellation = true;

            ui_rtbSqlOutput.Document.PageWidth = 2000.0;

            this.NewItems(viewer.Items);
            RestoreSelectionHandlers();
        }

        void ApplicationCommands_ShowObjectEntriesExecuted(object sender, RoutedEventArgs e)
        {
            var text = m_objects
                .GroupBy(pair => pair.Key.Kind)
                .Select(group => group.Key.ToString() + ": " + group.Select(pair => pair.Value.ObjectEntry).ToStringJoin(", "))
                .ToStringJoin(Environment.NewLine + Environment.NewLine);

            MessageWindow.Show(this, Strings.Gossip_ObjectEntries, text);
        }

        void ApplicationCommands_ShowMenuEntriesExecuted(object sender, RoutedEventArgs e)
        {
            var text = m_menus.Select(pair => pair.Key).ToStringJoin(", ");

            MessageWindow.Show(this, Strings.Gossip_MenuEntries, text);
        }

        void ApplicationCommands_ShowTextEntriesExecuted(object sender, RoutedEventArgs e)
        {
            var text = m_menus.Select(pair => pair.Value.Menu.TextId).ToStringJoin(", ");

            MessageWindow.Show(this, Strings.Gossip_TextEntries, text);
        }

        void RestoreSelectionHandlers()
        {
            ui_lvMenus.SelectionChanged += m_lvMenus_SelectionChangedHandler;
            ui_lvObjects.SelectionChanged += m_lvObjects_SelectionChangedHandler;
            ui_cbAllMenus.Checked += m_cbAllMenus_CheckedChangedHandler;
            ui_cbAllMenus.Unchecked += m_cbAllMenus_CheckedChangedHandler;
            ui_cbAllObjects.Checked += m_cbAllObjects_CheckedChangedHandler;
            ui_cbAllObjects.Unchecked += m_cbAllObjects_CheckedChangedHandler;
        }

        void RemoveSelectionHandlers()
        {
            ui_lvMenus.SelectionChanged -= m_lvMenus_SelectionChangedHandler;
            ui_lvObjects.SelectionChanged -= m_lvObjects_SelectionChangedHandler;
            ui_cbAllMenus.Checked -= m_cbAllMenus_CheckedChangedHandler;
            ui_cbAllMenus.Unchecked -= m_cbAllMenus_CheckedChangedHandler;
            ui_cbAllObjects.Checked -= m_cbAllObjects_CheckedChangedHandler;
            ui_cbAllObjects.Unchecked -= m_cbAllObjects_CheckedChangedHandler;
        }

        void SetProgressBarVisible(bool value)
        {
            //ui_cbAllMenus.IsEnabled = !value;
            //ui_cbAllObjects.IsEnabled = !value;

            if (!value)
                ui_progressBar.Value = 0;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ui_progressBar.Value = e.ProgressPercentage;
        }

        class ObjectGossip
        {
            public WowGuidKind ObjectType;
            public uint ObjectEntry;
            public string ObjectName;

            public readonly SortedSet<uint> InitialMenus = new SortedSet<uint>();
            public readonly List<ExtGossipMenu> Menus = new List<ExtGossipMenu>();
        }

        class ExtGossipMenu
        {
            public GossipMenu Menu;
            public uint[] GossipOptionMenus;
            public readonly HashSet<WowGuid> Objects
                = new HashSet<WowGuid>(new WowGuidKindEntryComparer());
        }

        struct ExtGossipMenuComparer : IEqualityComparer<ExtGossipMenu>
        {
            public bool Equals(ExtGossipMenu x, ExtGossipMenu y)
            {
                return x.Menu.MenuId == y.Menu.MenuId;
            }

            public int GetHashCode(ExtGossipMenu menu)
            {
                return (int)menu.Menu.MenuId;
            }
        }

        class GossipSelectOption
        {
            public WowGuid Object;
            public uint MenuId;
            public uint OptionId;
        }

        readonly SortedDictionary<uint, GameObjectTemplate> m_goTemplates
            = new SortedDictionary<uint, GameObjectTemplate>();
        readonly SortedDictionary<uint, CreatureTemplate> m_creatureTemplates
            = new SortedDictionary<uint, CreatureTemplate>();

        KeyValuePair<WowGuid, ObjectGossip>[] m_objects;
        KeyValuePair<uint, ExtGossipMenu>[] m_menus;

        public void NewItems(IList<ViewerItem> items)
        {
            this.ThreadSafeBegin(_ =>
            {
                if (m_parsingItemsWorker.IsBusy)
                    m_parsingItemsWorker.CancelAsync();

                if (m_creatingMenuDataWorker.IsBusy)
                    m_creatingMenuDataWorker.CancelAsync();

                ui_lvObjects.Items.Clear();
                ui_lvMenus.Items.Clear();
                m_creatureTemplates.Clear();

                SetProgressBarVisible(true);
                m_parsingItemsWorker.RunWorkerAsync(items);
            });
        }

        void m_parsingItemsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetProgressBarVisible(false);

            if (e.Error != null)
            {
                MessageWindow.Show(this, Strings.Error, "Error occured while parsing items:\n\n" + e.Error);
                return;
            }

            foreach (var pair in m_objects)
            {
                var item = new ListViewItem()
                {
                    Content = pair.Value.ObjectName,
                    Tag = pair.Value
                };
                ui_lvObjects.Items.Add(item);
            }

            foreach (var pair in m_menus)
            {
                var item = new ListViewItem()
                {
                    Content = Strings.Gossip_MenuN.LocalizedFormat(pair.Value.Menu.MenuId),
                    Tag = pair.Value
                };
                ui_lvMenus.Items.Add(item);
            }

            ui_cbAllMenus.IsChecked = true;
        }

        void m_parsingItemsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var items = (IList<ViewerItem>)e.Argument;
            var nitems = items.Count;
            int progress = 0;
            var protocol = m_viewer.CurrentProtocol;

            var objects = new SortedDictionary<WowGuid, ObjectGossip>(new WowGuidKindEntryComparer());
            var menus = new SortedDictionary<uint, ExtGossipMenu>();

            ExtGossipMenu currentMenu = null;
            WowGuid currentObject = WowGuid.Empty;
            Action resetCurrent = () =>
            {
                currentMenu = null;
                currentObject = WowGuid.Empty;
            };

            var optSelectQueue = new Queue<GossipSelectOption>();

            for (int i = 0; i < nitems && !worker.CancellationPending; i++)
            {
                var item = items[i];
                var packet = item.Packet;
                var opcodePacket = packet as IPacketWithOpcode;
                if (opcodePacket == null)
                    continue;

                var opcode = (WowOpcodes)opcodePacket.Opcode;

                switch (opcode)
                {
                    case WowOpcodes.CMSG_GOSSIP_HELLO:
                    case WowOpcodes.CMSG_GAMEOBJ_USE:
                    case WowOpcodes.CMSG_LIST_INVENTORY:
                    case WowOpcodes.CMSG_TRAINER_LIST:
                    {
                        using (var reader = new StreamHandler(packet.Data))
                        {
                            optSelectQueue.Enqueue(new GossipSelectOption()
                            {
                                Object = reader.ReadGuid(),
                                MenuId = uint.MaxValue,
                                OptionId = uint.MaxValue
                            });
                        }
                        break;
                    }
                    case WowOpcodes.CMSG_GOSSIP_SELECT_OPTION:
                    {
                        if (currentMenu != null)
                        {
                            using (var reader = new StreamHandler(packet.Data))
                            {
                                var obj = reader.ReadGuid();
                                var menuId = reader.ReadUInt32();
                                var optionId = reader.ReadUInt32();
                                if (currentMenu.Menu.MenuId == menuId)
                                {
                                    optSelectQueue.Enqueue(new GossipSelectOption()
                                    {
                                        Object = obj,
                                        MenuId = menuId,
                                        OptionId = optionId
                                    });
                                }
                                else
                                    Console.WriteLine("Error: Gossip Menu: currentMenuId != selectedMenuId ({0} != {1})",
                                        currentMenu.Menu.MenuId, menuId);
                            }
                        }
                        else
                            Console.WriteLine("Error: Gossip Parser: Unexpected CMSG_GOSSIP_SELECT_OPTION (inner)");
                        break;
                    }
                    case WowOpcodes.SMSG_DESTROY_OBJECT:
                    {
                        var guid = new WowGuid(BitConverter.ToUInt64(packet.Data, 0));
                        if (currentObject == guid)
                            resetCurrent();
                        break;
                    }
                    case WowOpcodes.SMSG_UPDATE_OBJECT:
                    {
                        using (var reader = new StreamHandler(packet.Data))
                        {
                            var updateData = new UpdateData(reader, true);
                            foreach (var guid in updateData.DestroyedObjects)
                            {
                                if (currentObject == guid)
                                    resetCurrent();
                            }
                        }
                        break;
                    }
                    case WowOpcodes.CMSG_QUESTGIVER_ACCEPT_QUEST:
                    {
                        var guid = new WowGuid(BitConverter.ToUInt64(packet.Data, 0));
                        if (optSelectQueue.Count > 0)
                        {
                            if (optSelectQueue.Peek().Object == guid)
                                optSelectQueue.Dequeue();
                            else
                                Console.WriteLine("Error: Gossip Parser: Unexpected {0} (packet #{1})", opcode, i);
                        }
                        break;
                    }
                    case WowOpcodes.SMSG_TRAINER_LIST:
                    case WowOpcodes.SMSG_VENDOR_INVENTORY:
                    case WowOpcodes.SMSG_INVALID_PROMOTION_CODE:
                    {
                        if (optSelectQueue.Count > 0)
                            optSelectQueue.Dequeue();
                        else
                            Console.WriteLine("Error: Gossip Parser: Unexpected {0} (packet #{1})", opcode, i);
                        break;
                    }
                    case WowOpcodes.SMSG_GOSSIP_COMPLETE:
                    {
                        while (optSelectQueue.Count > 0 &&
                            optSelectQueue.Peek().Object == currentObject &&
                            optSelectQueue.Peek().MenuId == currentMenu.Menu.MenuId)
                            optSelectQueue.Dequeue();
                        resetCurrent();
                        break;
                    }
                    case WowOpcodes.CMSG_LOADING_SCREEN_NOTIFY:
                    case WowOpcodes.SMSG_NEW_WORLD:
                    case WowOpcodes.SMSG_LOGIN_VERIFY_WORLD:
                    {
                        resetCurrent();
                        optSelectQueue.Clear();
                        break;
                    }
                    default:
                    {
                        var parser = item.Parser;
                        if (parser == null)
                        {
                            protocol.CreateParser(item);
                            parser = item.Parser;
                        }

                        if (parser is GossipMessageParser)
                        {
                            var gossip = (GossipMessageParser)parser;
                            if (!gossip.IsParsed)
                                gossip.Parse();

                            var menu = gossip.Menu;
                            ExtGossipMenu extMenu;
                            if (!menus.TryGetValue(menu.MenuId, out extMenu))
                            {
                                menus[menu.MenuId] = extMenu = new ExtGossipMenu()
                                {
                                    Menu = menu,
                                    GossipOptionMenus = new uint[menu.GossipOptions.Length]
                                };
                            }
                            else
                            {
                                var existingMenu = extMenu.Menu;
                                if (!existingMenu.Equals(menu))
                                {
                                    Console.WriteLine("Error: Gossip Parser: New menu with same id {0}",
                                        menu.MenuId);
                                    break;
                                }
                            }

                            var guid = gossip.Object;

                            extMenu.Objects.Add(guid);

                            ObjectGossip gossipObject;

                            if (!objects.TryGetValue(guid, out gossipObject))
                            {
                                objects[guid] = gossipObject = new ObjectGossip()
                                {
                                    ObjectType = guid.Kind,
                                    ObjectEntry = guid.Entry
                                };
                            }

                            GossipSelectOption opt = null;

                            while (optSelectQueue.Count > 0)
                            {
                                var optSelect = optSelectQueue.Dequeue();

                                if (optSelect.Object != guid && optSelect.Object.IsGameObject)
                                    continue;

                                opt = optSelect;
                                break;
                            }

                            if (opt == null)
                            {
                                Console.WriteLine("Error: Gossip Parser: Unexpected Gossip Message");
                                break;
                            }

                            if ((opt.MenuId == uint.MaxValue) != (currentMenu == null))
                                Console.WriteLine("Error: Gossip Parser: unexpected state of gossip parser, packet = {0}", i);

                            if (currentMenu == null)
                            {
                                // Just interacted with the object
                                gossipObject.InitialMenus.Add(menu.MenuId);
                                currentObject = guid;
                            }
                            else
                            {
                                if (guid != currentObject)
                                {
                                    Console.WriteLine("Error: Gossip Parser: unexpected object");
                                    break;
                                }

                                // Got a gossip message after an option was selected
                                int idx = currentMenu.Menu.GossipOptions.IndexOf(_ => _.OptionId == opt.OptionId);
                                if (idx != -1)
                                {
                                    currentMenu.GossipOptionMenus[idx] = menu.MenuId;
                                }
                                else
                                    Console.WriteLine("Error: Gossip Parser: Unable to find option {0} in menu {1}",
                                        opt.OptionId, opt.MenuId);
                            }

                            if (gossipObject.Menus.IndexOf(extMenu) < 0)
                                gossipObject.Menus.Add(extMenu);
                            currentMenu = extMenu;
                        }
                        else if (parser is CreatureQueryResponseParser)
                        {
                            var query = (CreatureQueryResponseParser)parser;
                            if (!query.IsParsed)
                                query.Parse();

                            var id = query.Template.Entry;
                            if (id < 0)
                                continue;

                            m_creatureTemplates[(uint)id] = query.Template;
                        }
                        else if (parser is GameObjectQueryResponseParser)
                        {
                            var query = (GameObjectQueryResponseParser)parser;
                            if (!query.IsParsed)
                                query.Parse();

                            var id = query.Template.Entry;
                            if (id < 0)
                                continue;

                            m_goTemplates[(uint)id] = query.Template;
                        }
                        break;
                    }
                }

                int newProgress = 100 * i / nitems;
                if (newProgress != progress)
                    worker.ReportProgress(progress = newProgress);
            }

            if (worker.CancellationPending)
            {
                m_objects = new KeyValuePair<WowGuid, ObjectGossip>[0];
                m_menus = new KeyValuePair<uint, ExtGossipMenu>[0];
                return;
            }

            // Setup names.
            foreach (var pair in objects)
            {
                var obj = pair.Value;
                var s = obj.ObjectType.ToString() + " #" + obj.ObjectEntry.ToString();

                if (obj.ObjectType == WowGuidKind.GameObject)
                {
                    GameObjectTemplate go;
                    if (m_goTemplates.TryGetValue(obj.ObjectEntry, out go))
                        s += " - " + go.Name[0];
                }
                else if (obj.ObjectType == WowGuidKind.Unit)
                {
                    CreatureTemplate npc;
                    if (m_creatureTemplates.TryGetValue(obj.ObjectEntry, out npc))
                        s += " - " + npc.Name[0] + (string.IsNullOrEmpty(npc.SubName) ? "" : " <" + npc.SubName + ">");
                }

                obj.ObjectName = s;
            }

            m_objects = objects.ToArray();
            m_menus = menus.ToArray();
        }

        private void ApplicationCommands_CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Hide();
        }

        SaveFileDialog m_saveFileDialog;

        private void ApplicationCommands_SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ShowFileDialogAndSaveOrAppend(true);
        }

        private void ApplicationCommands_SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ShowFileDialogAndSaveOrAppend(false);
        }

        void ShowFileDialogAndSaveOrAppend(bool append)
        {
            if (m_saveFileDialog == null)
            {
                m_saveFileDialog = new SaveFileDialog();
                m_saveFileDialog.AddExtension = true;
                m_saveFileDialog.Filter = Strings.Gossip_SaveFileFilter;
                m_saveFileDialog.InitialDirectory = Configuration.GetValue("Save File Dialog Initial Dir", string.Empty);
                m_saveFileDialog.ValidateNames = true;
            }

            m_saveFileDialog.Title = append ? Strings.Gossip_AppendSQLOutputTitle : Strings.Gossip_SaveSQLOutputTitle;

            var res = m_saveFileDialog.ShowDialog(this);
            if (res == true)
            {
                var file = m_saveFileDialog.FileName;
                var dir = Path.GetDirectoryName(file);
                Configuration.SetValue("Save File Dialog Initial Dir", dir);

                SaveToFile(file, append);
            }
        }

        void SaveToFile(string file, bool append)
        {
            try
            {
                var dir = Path.GetDirectoryName(file);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                if (append)
                    File.AppendAllText(file, m_sql);
                else
                    File.WriteAllText(file, m_sql);
            }
            catch (IOException)
            {
                var res = MessageBox.Show(this, Strings.Gossip_ErrorSavingSQLOutput,
                    Strings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ui_lvObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_creatingMenuDataWorker.IsBusy)
                m_creatingMenuDataWorker.CancelAsync();

            var listview = (ListView)sender;
            var itemList = listview.SelectedItems;
            var nitems = itemList.Count;
            if (nitems == 0)
                return;

            var arr = itemList
                .Cast<FrameworkElement>()
                .Select(el => (ObjectGossip)el.Tag)
                .SelectMany(obj => obj.Menus)
                .ToArray();

            SetProgressBarVisible(true);
            m_creatingMenuDataWorker.RunWorkerAsync(arr);
        }

        private void ui_lvMenus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_creatingMenuDataWorker.IsBusy)
                m_creatingMenuDataWorker.CancelAsync();

            var listview = (ListView)sender;
            var itemList = listview.SelectedItems;
            var nitems = itemList.Count;
            if (nitems == 0)
                return;

            var arr = itemList
                .Cast<FrameworkElement>()
                .Select(el => (ExtGossipMenu)el.Tag)
                .ToArray();

            SetProgressBarVisible(true);
            m_creatingMenuDataWorker.RunWorkerAsync(arr);
        }

        private void ui_cbAllObjects_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ExtGossipMenu[] arr;

            if ((bool)ui_cbAllObjects.IsChecked)
            {
                arr = m_objects.SelectMany(obj => obj.Value.Menus).ToArray();
            }
            else
            {
                arr = new ExtGossipMenu[0];
            }

            SetProgressBarVisible(true);
            m_creatingMenuDataWorker.RunWorkerAsync(arr);
        }

        private void ui_cbAllMenus_CheckedChanged(object sender, RoutedEventArgs e)
        {
            ExtGossipMenu[] arr;

            if ((bool)ui_cbAllMenus.IsChecked)
            {
                arr = m_menus.Select(pair => pair.Value).ToArray();
            }
            else
            {
                arr = new ExtGossipMenu[0];
            }

            SetProgressBarVisible(true);
            m_creatingMenuDataWorker.RunWorkerAsync(arr);
        }

        /// <summary>
        /// Data proxy class
        /// </summary>
        class MenuData
        {
            public struct MenuInstance
            {
                public struct MenuOptionInstance
                {
                    public string Header;
                    public uint Id;
                }

                public string Header;
                public ExtGossipMenu Menu;
                public MenuOptionInstance[] Options;
            }

            public struct SqlPart
            {
                public string Text;
                public Brush SpecialBrush;
            }

            public SqlPart[] SqlParts;
            public MenuInstance[] Menus;
            public BitArray SelectedObjects;
            public BitArray SelectedMenus;
        }

        void CreateSqlForMenu(ExtGossipMenu menu, StringBuilder builder)
        {
            builder.Append("-- ").AppendLine(Strings.Gossip_SqlStructure.LocalizedFormat(menu.Menu.MenuId));

            foreach (var guid in menu.Objects)
            {
                var obj = m_objects.First(_ => _.Key == guid).Value;

                if (obj.ObjectType == WowGuidKind.Unit)
                {
                    if (obj.InitialMenus.Count == 1 && obj.InitialMenus.First() == menu.Menu.MenuId)
                    {
                        builder.AppendFormatLine(
                            "UPDATE creature_template SET gossip_menu_id = {0} WHERE entry = {1}; -- {2}",
                            menu.Menu.MenuId, obj.ObjectEntry, obj.ObjectName);
                    }
                    else
                    {
                        builder.Append("-- ").AppendLine(Strings.Gossip_SqlInitialMenus
                            .LocalizedFormat(obj.ObjectName, obj.InitialMenus.ToStringJoin(", ")));
                    }
                }
                else
                {
                    builder.Append("-- ").AppendLine(Strings.Gossip_SqlUnsupportedObject
                        .LocalizedFormat(obj.ObjectType, obj.ObjectName));
                }
            }

            CultureInfo culture = null;
            if (m_viewer.CurrentLog is IHasCultureInfo)
                culture = ((IHasCultureInfo)m_viewer.CurrentLog).Culture;

            var locale = WowLocales.enUS;

            if (culture != null && culture.IsWowCompatibleCulture())
                locale = culture.GetWowLocale();

            bool defaultLocale = locale == WowLocales.enUS;

            builder.AppendFormatLine("REPLACE INTO gossip_menu (entry, text_id) VALUES ({0}, {1});",
                menu.Menu.MenuId, menu.Menu.TextId);

            var length = menu.Menu.GossipOptions.Length;
            if (length > 0)
            {
                builder.AppendLine("REPLACE INTO gossip_menu_option (menu_id, id, option_icon, option_text, npc_option_npcflag, action_menu_id, action_poi_id, box_coded, box_money, box_text) VALUES");

                for (int i = 0; i < length; i++)
                {
                    var opt = menu.Menu.GossipOptions[i];

                    builder.AppendFormat(
                        "({0}, {1}, {2}, '{3}', {4}, {5}, {6}, {7}, {8}, '{9}')",
                        menu.Menu.MenuId, opt.OptionId, opt.Icon,
                        (defaultLocale ? "" : "[PH] ") + opt.Text.EscapeQuotes(), 0,
                        menu.GossipOptionMenus[i], 0, opt.IsPasswordRequired ? 1 : 0, opt.MoneyRequired,
                        (!defaultLocale && opt.BoxText != string.Empty ? "[PH] " : "") + opt.BoxText.EscapeQuotes());

                    if (i + 1 == length)
                        builder.AppendLine(";");
                    else
                        builder.AppendLine(",");
                }

                if (!defaultLocale)
                {
                    builder.AppendFormatLine(
                        "REPLACE INTO locales_gossip_menu_option " +
                        "(menu_id, id, option_text_loc{0}, box_text_loc{0}) VALUES",
                        (int)locale);

                    for (int i = 0; i < length; i++)
                    {
                        var opt = menu.Menu.GossipOptions[i];

                        builder.AppendFormat(
                            "({0}, {1}, '{2}', '{3}')",
                            menu.Menu.MenuId, opt.OptionId, opt.Text.EscapeQuotes(), opt.BoxText.EscapeQuotes());

                        if (i + 1 == length)
                            builder.AppendLine(";");
                        else
                            builder.AppendLine(",");
                    }
                }
            }
        }

        string m_sql = string.Empty;

        void m_creatingMenuDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var menus = (ExtGossipMenu[])e.Argument;
            var nMenus = menus.Length;

            var data = new MenuData();
            data.Menus = new MenuData.MenuInstance[nMenus];
            data.SelectedMenus = new BitArray(m_menus.Length);
            data.SelectedObjects = new BitArray(m_objects.Length);

            var builder = new StringBuilder(16 * 1024);
            int progress = 0;

            for (int i = 0; i < nMenus && !worker.CancellationPending; i++)
            {
                var menu = menus[i];
                var menuId = menu.Menu.MenuId;

                data.SelectedMenus[m_menus.BinaryIndexOf(pair => pair.Key.CompareTo(menuId))] = true;
                foreach (var obj in menu.Objects)
                {
                    data.SelectedObjects[
                        m_objects.ToArray().BinaryIndexOf(pair => WowGuidKindEntryComparer.Compare(pair.Key, obj))
                        ] = true;
                }

                data.Menus[i].Header = Strings.Gossip_MenuN.LocalizedFormat(menuId);
                data.Menus[i].Menu = menu;

                var options = menu.Menu.GossipOptions;
                var nOptions = options.Length;
                var optionsData = data.Menus[i].Options = new MenuData.MenuInstance.MenuOptionInstance[nOptions];

                for (int j = 0; j < nOptions; j++)
                {
                    var option = options[j];
                    optionsData[j].Header = "[" + option.OptionId + "] " + option.Text;
                    optionsData[j].Id = option.OptionId;
                }

                CreateSqlForMenu(menu, builder);
                builder.AppendLine();

                int newProgress = 100 * i / nMenus;
                if (newProgress != progress)
                    worker.ReportProgress(progress = newProgress);
            }

            if (worker.CancellationPending)
            {
                m_sql = string.Empty;
                return;
            }

            var text = builder.ToString();
            m_sql = text;
            var highlights = SimpleCodeHighlighter.Highlight(text, s_sqlHighlightingInfo);
            var nHighlights = highlights.Length;
            var nl = Environment.NewLine;
            var sqlParts = new List<MenuData.SqlPart>(nHighlights  * 3 / 2);

            Func<int, int, Brush, int> addText = (_start, _end, _b) =>
            {
                int idx;
                while (_start < _end && (idx = text.IndexOf(nl, _start)) >= 0 && idx < _end)
                {
                    sqlParts.Add(new MenuData.SqlPart()
                    {
                        Text = text.Substring(_start, idx - _start),
                        SpecialBrush = _b
                    });
                    // newline marker
                    sqlParts.Add(new MenuData.SqlPart());
                    _start = idx + nl.Length;
                }

                if (_start < _end)
                {
                    sqlParts.Add(new MenuData.SqlPart()
                    {
                        Text = text.Substring(_start, _end - _start),
                        SpecialBrush = _b
                    });
                    _start = _end;
                }

                return _start;
            };

            int lastEnd = 0;
            for (int i = 0; i < nHighlights; ++i)
            {
                var start = highlights[i].Start;
                var end = highlights[i].End;

                if (lastEnd < start)
                    addText(lastEnd, start, null);

                lastEnd = addText(start, end, s_tokenBrushes[(int)highlights[i].Token]);
            }

            if (lastEnd < text.Length)
                addText(lastEnd, text.Length, null);

            data.SqlParts = sqlParts.ToArray();

            e.Result = data;
        }

        void m_creatingMenuDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetProgressBarVisible(false);

            var result = e.Result as MenuData;
            if (result == null)
                return;

            ui_gbSelection.Header = Strings.Gossip_NMenus.LocalizedFormat(result.Menus.Length);

            RemoveSelectionHandlers();

            int len = result.SelectedObjects.Length;
            int count = 0;
            for (int i = 0; i < len; ++i)
            {
                var value = result.SelectedObjects[i];
                ((ListViewItem)ui_lvObjects.Items[i]).IsSelected = value;
                if (value)
                    ++count;
            }
            ui_lblSelectedObjects.Content = Strings.Gossip_ObjectsSelected.LocalizedFormat(count);
            bool? val;
            if (count == m_objects.Length)
                val = true;
            else if (count > 0)
                val = null;
            else
                val = false;
            if (ui_cbAllObjects.IsChecked != val)
                ui_cbAllObjects.IsChecked = val;

            len = result.SelectedMenus.Length;
            count = 0;
            for (int i = 0; i < len; ++i)
            {
                var value = result.SelectedMenus[i];
                ((ListViewItem)ui_lvMenus.Items[i]).IsSelected = value;
                if (value)
                    ++count;
            }
            ui_lblSelectedMenus.Content = Strings.Gossip_MenusSelected.LocalizedFormat(count);
            if (count == m_menus.Length)
                val = true;
            else if (count > 0)
                val = null;
            else
                val = false;
            if (ui_cbAllMenus.IsChecked != val)
                ui_cbAllMenus.IsChecked = val;

            RestoreSelectionHandlers();

            ui_tvObject.Items.Clear();

            var menus = result.Menus;
            var nMenus = menus.Length;
            for (int i = 0; i < nMenus; i++)
            {
                var item = new TreeViewItem()
                {
                    Header = menus[i].Header,
                    Tag = menus[i].Menu
                };

                var options = menus[i].Options;
                var nOptions = options.Length;
                for (int j = 0; j < nOptions; j++)
                {
                    var optItem = new TreeViewItem()
                    {
                        Header = options[j].Header,
                        Tag = options[j].Id
                    };

                    optItem.MouseDoubleClick += m_optItem_MouseDoubleClickHandler;

                    item.Items.Add(optItem);
                }

                ui_tvObject.Items.Add(item);

                if (nMenus <= 3)
                    item.ExpandSubtree();
            }

            var doc = ui_rtbSqlOutput.Document;
            doc.Blocks.Clear();
            var para = new Paragraph();
            para.BeginInit();

            var parts = result.SqlParts;
            var nParts = parts.Length;
            for (int i = 0; i < nParts; i++)
            {
                var brush = parts[i].SpecialBrush;
                var text = parts[i].Text;

                if (text == null)
                    para.Inlines.Add(new LineBreak());
                else
                {
                    var run = new Run(text);

                    if (brush != null)
                        run.Foreground = brush;

                    para.Inlines.Add(run);
                }
            }

            para.EndInit();
            doc.Blocks.Add(para);
        }

        void optItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (TreeViewItem)sender;
            var optionId = (uint)item.Tag;
            var parent = (TreeViewItem)item.Parent;
            var menu = (ExtGossipMenu)parent.Tag;
            var menuId = menu.GossipOptionMenus[menu.Menu.GossipOptions.IndexOf(opt => opt.OptionId == optionId)];
            if (menuId != 0)
            {
                var targetMenu = m_menus.First(pair => pair.Key == menuId).Value;

                SetProgressBarVisible(true);
                m_creatingMenuDataWorker.RunWorkerAsync(new[] { targetMenu });
            }
        }

        private void ui_tvObject_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var item = (TreeViewItem)e.NewValue;
            if (item == null)
            {
                ui_tbNotes.Text = string.Empty;
                return;
            }

            var text = new StringBuilder(256);

            if (item.Tag is ExtGossipMenu)
            {
                var menu = (ExtGossipMenu)item.Tag;

                text.AppendLine(Strings.Gossip_MenuDesc
                    .LocalizedFormat(menu.Menu.MenuId, menu.Menu.TextId, menu.Menu.GossipOptions.Length));
            }
            else if (item.Tag is uint)
            {
                var optionId = (uint)item.Tag;
                var parent = (TreeViewItem)item.Parent;
                var menu = (ExtGossipMenu)parent.Tag;
                var option = menu.Menu.GossipOptions.First(opt => opt.OptionId == optionId);

                text.AppendLine(Strings.Gossip_MenuDesc
                        .LocalizedFormat(menu.Menu.MenuId, menu.Menu.TextId, menu.Menu.GossipOptions.Length))
                    .AppendLine(Strings.Gossip_OptionDesc
                        .LocalizedFormat(optionId, option.Icon, option.Text));

                if (option.IsPasswordRequired)
                    text.AppendLine(Strings.Gossip_OptionHasPassword);

                if (option.MoneyRequired != 0)
                    text.AppendLine(Strings.Gossip_OptionMoneyRequired.LocalizedFormat(new Money(option.MoneyRequired)));

                if (option.BoxText != string.Empty)
                    text.AppendLine(Strings.Gossip_OptionBoxText.LocalizedFormat(option.BoxText));

                var onClickMenu = menu.GossipOptionMenus[menu.Menu.GossipOptions.IndexOf(option)];
                if (onClickMenu != 0)
                    text.AppendLine(Strings.Gossip_OptionTargetMenu.LocalizedFormat(onClickMenu));
            }

            ui_tbNotes.Text = text.ToString();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }

    public static class GossipParserCommands
    {
        static GossipParserCommands()
        {
            ShowObjectEntries = new RoutedUICommand("Show Object Entries", "Show Object Entries", typeof(GossipParserCommands));
            ShowMenuEntries = new RoutedUICommand("Show Menu Entries", "Show Menu Entries", typeof(GossipParserCommands));
            ShowTextEntries = new RoutedUICommand("Show Text Entries", "Show Text Entries", typeof(GossipParserCommands));
        }

        public static RoutedUICommand ShowObjectEntries { get; private set; }
        public static RoutedUICommand ShowMenuEntries { get; private set; }
        public static RoutedUICommand ShowTextEntries { get; private set; }
    }
}
