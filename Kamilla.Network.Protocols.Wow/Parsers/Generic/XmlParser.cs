using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Kamilla.Network.Protocols.Wow.Parsers.Generic.Xml;

namespace Kamilla.Network.Protocols.Wow.Parsers.Generic
{
    /// <summary>
    /// Represents a generic parser that uses XML packet definitions.
    /// </summary>
    public sealed class XmlParser : WowPacketParser
    {
        static readonly Dictionary<PacketSender, SortedDictionary<WowOpcodes, XmlPacketDefinition>> Definitions
            = new Dictionary<PacketSender, SortedDictionary<WowOpcodes, XmlPacketDefinition>>();

        static bool s_initialized = false;
        static object s_lock = new object();

        internal static void Initialize()
        {
            foreach (PacketSender type in Enum.GetValues(typeof(PacketSender)))
                Definitions.Add(type, new SortedDictionary<WowOpcodes, XmlPacketDefinition>());

            var streams = new List<Stream>(100);
            var filenames = new List<string>(100);

            var exec = Assembly.GetExecutingAssembly();
            Console.WriteLine("Debug: Loading embedded xmls from {0}", exec.GetType().Name);
            var resources = exec.GetManifestResourceNames();
            foreach (var file in resources)
            {
                if (file.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase) &&
                    file.IndexOf("parsers", StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    streams.Add(exec.GetManifestResourceStream(file));
                    filenames.Add(file);
                }
            }

            string path = Path.Combine(exec.Location, "Packets", Disassembly.ClientBuild.ToString());
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    streams.Add(new FileStream(file, FileMode.Open));
                    filenames.Add(file);
                }
            }

            var deserializer = new XmlSerializer(typeof(XmlPacketDefinitions));
            for (int i = 0; i < streams.Count; ++i)
            {
                var stream = streams[i];

                XmlPacketDefinitions defs;
                try
                {
                    using (TextReader textReader = new StreamReader(stream))
                        defs = (XmlPacketDefinitions)deserializer.Deserialize(textReader);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: Failed to load {0}: {1}", filenames[i], e);
                    continue;
                }

                if (stream is FileStream)
                    stream.Close();

                if (defs == null || defs.Definitions == null || defs.Definitions.Length == 0)
                {
                    Console.WriteLine("Error: XML: error in file: {0}", filenames[i]);
                    continue;
                }

                foreach (XmlPacketDefinition def in defs.Definitions)
                {
                    // actually, opcode can be 0, but if <Opcodes><Opcode/><Opcode/></Opcodes> used
                    // then def.Opcode will be 0, we need to parse the opcode ourselves.
                    // workaround meanwhile
                    if (def.Opcode != WowOpcodes.UNKNOWN_OPCODE && def.Opcode != 0)
                    {
                        if (Definitions[def.Sender].ContainsKey(def.Opcode))
                            Console.WriteLine("Error: XML: duplicate opcode definition for (sender={0},opcode={1},{2})",
                                def.Sender, def.Opcode, filenames[i]);
                        else
                            Definitions[def.Sender].Add(def.Opcode, def);
                    }

                    if (def.Opcodes != null)
                    {
                        foreach (WowOpcodes opcode in def.Opcodes)
                        {
                            if (opcode != WowOpcodes.UNKNOWN_OPCODE)
                            {
                                if (!Definitions[def.Sender].ContainsKey(opcode))
                                    Definitions[def.Sender].Add(opcode, def);
                            }
                        }
                    }
                }
            }

            s_initialized = true;
        }

        /// <summary>
        /// Creates a new instance of XmlParser specifically for the given <c>packet</c>.
        /// </summary>
        /// <param name="packet">
        /// The packet, that the new instance of XmlParser is created for.
        /// </param>
        /// <returns>
        /// A new instance of XmlParser specifically for the given <c>packet</c>. Can be null.
        /// </returns>
        public static XmlParser GetParser(WowPacket packet)
        {
            if (!s_initialized)
            {
                lock (s_lock)
                {
                    if (!s_initialized)
                        Initialize();
                }
            }

            if (Definitions[PacketSender.Any].ContainsKey((WowOpcodes)packet.Opcode))
                return new XmlParser(Definitions[PacketSender.Any][(WowOpcodes)packet.Opcode]);

            var sender = packet.Direction == TransferDirection.ToClient ? PacketSender.Server : PacketSender.Client;
            if (Definitions[sender].ContainsKey((WowOpcodes)packet.Opcode))
                return new XmlParser(Definitions[sender][(WowOpcodes)packet.Opcode]);

            return null;
        }

        XmlPacketDefinition Definition;

        private XmlParser(XmlPacketDefinition def)
            : base()
        {
            this.Definition = def;
        }

        /// <summary>
        /// Specifies the group the underlying packet belongs to.
        /// </summary>
        protected override PacketGroups WowGroup
        {
            get { return Definition.Group; }
        }

        /// <summary>
        /// Parses the packet associated with the current instance of XmlParser.
        /// </summary>
        protected override void InternalParse()
        {
            foreach (var segment in this.Definition.Structure)
                Output.AppendLine(segment.Parse(this, Reader, this.Definition));
        }
    }
}
