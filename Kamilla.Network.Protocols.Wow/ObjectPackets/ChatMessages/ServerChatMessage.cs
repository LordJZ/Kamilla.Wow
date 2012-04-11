using System;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    internal static class StreamHandlerExtensions
    {
        public static void WriteChatString(this StreamHandler Writer, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Writer.WriteInt32(bytes.Length + 1);
            Writer.WriteBytes(bytes);
            Writer.WriteByte(0);
        }
    }

    /// <summary>
    /// Represents a single chat message sent to the client by the server.
    /// </summary>
    public sealed class ServerChatMessage : ObjectPacket
    {
        public WowOpcodes Opcode
        {
            get
            {
                return this.GameMasterMessage ? WowOpcodes.SMSG_GM_MESSAGECHAT : WowOpcodes.SMSG_MESSAGECHAT;
            }
        }

        /// <summary>
        /// Indicates whether a ChatMessageType is supposed to be used by NPCs.
        /// </summary>
        /// <returns>
        /// true, if the type is supposed to be used by NPCs; otherwise, false.
        /// </returns>
        public static bool IsNPCMessageType(ChatMessageType type)
        {
            switch (type)
            {
                case ChatMessageType.MonsterSay:
                case ChatMessageType.MonsterParty:
                case ChatMessageType.MonsterYell:
                case ChatMessageType.MonsterWhisper:
                case ChatMessageType.MonsterEmote:
                case ChatMessageType.RaidBossWhisper:
                case ChatMessageType.RaidBossEmote:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets of sets the current message type.
        /// </summary>
        public ChatMessageType Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        /// <summary>
        /// Gets or sets the current message language.
        /// </summary>
        public Language Language
        {
            get { return m_language; }
            set { m_language = value; }
        }

        /// <summary>
        /// Gets or sets the chat message's sender's GUID.
        /// </summary>
        public WowGuid SenderGUID
        {
            get { return m_senderGUID; }
            set { m_senderGUID = value; }
        }

        /// <summary>
        /// Gets or sets the chat message's sender's name.
        /// 
        /// This value can be null.
        /// </summary>
        public String SenderName
        {
            get { return m_senderName; }
            set { m_senderName = value; }
        }

        /// <summary>
        /// Gets or sets the chat message's target's GUID.
        /// </summary>
        public WowGuid TargetGUID
        {
            get { return m_targetGUID; }
            set { m_targetGUID = value; }
        }

        /// <summary>
        /// Gets or sets the chat message's target's name.
        /// 
        /// This value can be null.
        /// </summary>
        public String TargetName
        {
            get { return m_targetName; }
            set { m_targetName = value; }
        }

        /// <summary>
        /// Gets or sets the chat tag, associated with the current message.
        /// </summary>
        public ChatMessageFlags Flags
        {
            get { return m_flags; }
            set { m_flags = value; }
        }

        public String AddonPrefix
        {
            get { return m_addonPrefix; }
            set { m_addonPrefix = value; }
        }

        /// <summary>
        /// Gets or sets the actual message text.
        /// </summary>
        public String Text
        {
            get { return m_text; }
            set { m_text = value; }
        }

        /// <summary>
        /// Gets or sets the achievement id associated with the current chat message.
        /// 
        /// Only valid for ChatMessageType.Achievement and GuildAchievement.
        /// </summary>
        public uint AchievementId
        {
            get { return m_achievementId; }
            set { m_achievementId = value; }
        }

        /// <summary>
        /// Gets or sets the channel name associated with the current chat message.
        /// 
        /// Only valid for ChatMessageType.Channel.
        /// </summary>
        public String Channel
        {
            get { return m_channel; }
            set { m_channel = value; }
        }

        public float DisplayTime
        {
            get { return m_displayTime; }
            set { m_displayTime = value; }
        }

        public bool SuspendEvent
        {
            get { return m_suspendEvent; }
            set { m_suspendEvent = value; }
        }

        /// <summary>
        /// Indicates whether the messege was composed by a GM (SMSG_GM_MESSAGECHAT).
        /// </summary>
        public bool GameMasterMessage { get; private set; }

        private ChatMessageType m_type;
        private Language m_language;
        private uint m_unknownUInt32;

        private WowGuid m_senderGUID;
        private String m_senderName;
        private WowGuid m_targetGUID;
        private String m_targetName;

        private String m_addonPrefix;
        private String m_text;
        private ChatMessageFlags m_flags;
        private uint m_achievementId;
        private String m_channel;

        private float m_displayTime;
        private bool m_suspendEvent;

        /// <summary>
        /// Initializes a new instance of ChatMessage.
        /// </summary>
        /// <param name="type">Type of the current ChatMessage.</param>
        /// <param name="lang">Language of the current ChatMessage.</param>
        /// <param name="sender">Current ChatMessage's sender's GUID.</param>
        /// <param name="target">Current ChatMessage's target's GUID.</param>
        /// <param name="text">The actual text of the current ChatMessage.</param>
        public ServerChatMessage(ChatMessageType type, Language lang, WowGuid sender, WowGuid target, String text)
        {
            m_type = type;
            m_language = lang;
            m_senderGUID = sender;
            m_targetGUID = target;
            m_text = text;
        }

        /// <summary>
        /// Initializes a new instance of ChatMessage, reading all the needed data from a byte array.
        /// </summary>
        /// <param name="data">
        /// The byte array that contains all needed data for the ChatMessage.
        /// </param>
        /// <param name="opcode">
        /// The opcode of a packet that contains the current message.
        /// 
        /// Specify 0 opcode if you want basic parsing implementation.
        /// </param>
        public ServerChatMessage(byte[] data, WowOpcodes opcode)
        {
            StreamHandler Reader = new StreamHandler(data);

            ReadFromStreamHandler(Reader, opcode);

            Reader.Close();
        }

        /// <summary>
        /// Initializes a new instance of ChatMessage, reading all the needed data using a StreamHandler.
        /// </summary>
        /// <param name="Reader">
        /// The StreamHandler used to read all data for the ChatMessage.
        /// </param>
        /// <param name="opcode">
        /// The opcode of a packet that contains the current message.
        /// 
        /// Specify 0 opcode if you want basic parsing implementation.
        /// </param>
        public ServerChatMessage(StreamHandler Reader, WowOpcodes opcode)
        {
            ReadFromStreamHandler(Reader, opcode);
        }

        public override void Read(StreamHandler reader)
        {
            ReadFromStreamHandler(reader, WowOpcodes.UNKNOWN_OPCODE);
        }

        private void ReadFromStreamHandler(StreamHandler Reader, WowOpcodes opcode)
        {
            GameMasterMessage = (opcode == WowOpcodes.SMSG_GM_MESSAGECHAT);

            m_type = (ChatMessageType)Reader.ReadByte();
            if (m_type == ChatMessageType.Addon2)
                m_type = ChatMessageType.Addon;

            m_language = (Language)Reader.ReadUInt32();
            m_senderGUID = Reader.ReadGuid();
            m_unknownUInt32 = Reader.ReadUInt32();

            switch (m_type)
            {
                case ChatMessageType.MonsterSay:
                case ChatMessageType.MonsterParty:
                case ChatMessageType.MonsterYell:
                case ChatMessageType.MonsterWhisper:
                case ChatMessageType.MonsterEmote:
                case ChatMessageType.BattleNet:
                case ChatMessageType.RaidBossEmote:
                case ChatMessageType.RaidBossWhisper:
                    Reader.Skip(4);
                    m_senderName = Reader.ReadCString();
                    m_targetGUID = Reader.ReadGuid();
                    if (!m_targetGUID.IsEmpty
                        && !m_targetGUID.IsPlayer
                        && !m_targetGUID.IsPet)
                    {
                        Reader.Skip(4);
                        m_targetName = Reader.ReadCString();
                    }
                    if (m_language == Language.Addon)
                        m_addonPrefix = Reader.ReadCString();
                    Reader.Skip(4);
                    m_text = Reader.ReadCString();
                    m_flags = (ChatMessageFlags)Reader.ReadByte();
                    if (m_type == ChatMessageType.RaidBossEmote || m_type == ChatMessageType.RaidBossWhisper)
                    {
                        m_displayTime = Reader.ReadSingle();
                        m_suspendEvent = Reader.ReadBoolean();
                    }
                    break;
                case ChatMessageType.BGSystemNeutral:
                case ChatMessageType.BGSystemAlliance:
                case ChatMessageType.BGSystemHorde:
                    m_targetGUID = Reader.ReadGuid();
                    if (!m_targetGUID.IsEmpty
                        && !m_targetGUID.IsPlayer)
                    {
                        Reader.Skip(4);
                        m_targetName = Reader.ReadCString();
                    }
                    if (m_language == Language.Addon)
                        m_addonPrefix = Reader.ReadCString();
                    Reader.Skip(4);
                    m_text = Reader.ReadCString();
                    m_flags = (ChatMessageFlags)Reader.ReadByte();
                    break;
                case ChatMessageType.Achievement:
                case ChatMessageType.GuildAchievement:
                    m_targetGUID = Reader.ReadGuid();
                    if (m_language == Language.Addon)
                        m_addonPrefix = Reader.ReadCString();
                    Reader.Skip(4);
                    m_text = Reader.ReadCString();
                    m_flags = (ChatMessageFlags)Reader.ReadByte();
                    m_achievementId = Reader.ReadUInt32();
                    break;
                case ChatMessageType.WhisperForeign:
                    Reader.Skip(4);
                    m_senderName = Reader.ReadCString();
                    m_targetGUID = Reader.ReadGuid();
                    if (m_language == Language.Addon)
                        m_addonPrefix = Reader.ReadCString();
                    Reader.Skip(4);
                    m_text = Reader.ReadCString();
                    m_flags = (ChatMessageFlags)Reader.ReadByte();
                    break;
                default:
                    if (GameMasterMessage)
                    {
                        Reader.Skip(4);
                        m_senderName = Reader.ReadCString();
                    }
                    if (m_type == ChatMessageType.Channel)
                        m_channel = Reader.ReadCString();
                    m_targetGUID = Reader.ReadGuid();
                    if (m_language == Language.Addon)
                        m_addonPrefix = Reader.ReadCString();
                    Reader.Skip(4);
                    m_text = Reader.ReadCString();
                    m_flags = (ChatMessageFlags)Reader.ReadByte();
                    break;
            }
        }

        /// <summary>
        /// Saves the current ChatMessage to a stream using a StreamHandler.
        /// </summary>
        /// <param name="Writer">
        /// Instance of StreamHandler used to save the current ChatMessage to a stream.
        /// </param>
        public override void Save(StreamHandler Writer)
        {
            Writer.WriteByte((byte)m_type);
            Writer.WriteUInt32((uint)m_language);
            Writer.WriteGuid(m_senderGUID);
            Writer.WriteUInt32(m_unknownUInt32);

            switch (m_type)
            {
                case ChatMessageType.MonsterSay:
                case ChatMessageType.MonsterParty:
                case ChatMessageType.MonsterYell:
                case ChatMessageType.MonsterWhisper:
                case ChatMessageType.MonsterEmote:
                case ChatMessageType.RaidBossEmote:
                case ChatMessageType.RaidBossWhisper:
                case ChatMessageType.BattleNet:
                    Writer.WriteChatString(m_senderName ?? "<sender>");
                    Writer.WriteGuid(m_targetGUID);
                    if (!m_targetGUID.IsEmpty
                        && !m_targetGUID.IsPlayer
                        && !m_targetGUID.IsPet)
                    {
                        Writer.WriteChatString(m_targetName ?? "<target>");
                    }
                    if (m_language == Language.Addon)
                        Writer.WriteCString(m_addonPrefix ?? "<prefix>");
                    Writer.WriteChatString(m_text ?? "<text>");
                    Writer.WriteByte((byte)m_flags);
                    if (m_type == ChatMessageType.RaidBossEmote || m_type == ChatMessageType.RaidBossWhisper)
                    {
                        Writer.WriteSingle(m_displayTime);
                        Writer.WriteBoolean(m_suspendEvent);
                    }
                    break;
                case ChatMessageType.BGSystemNeutral:
                case ChatMessageType.BGSystemAlliance:
                case ChatMessageType.BGSystemHorde:
                    Writer.WriteGuid(m_targetGUID);
                    if (!m_targetGUID.IsEmpty
                        && !m_targetGUID.IsPlayer)
                    {
                        Writer.WriteChatString(m_targetName);
                    }
                    if (m_language == Language.Addon)
                        Writer.WriteCString(m_addonPrefix ?? "<prefix>");
                    Writer.WriteChatString(m_text ?? "<text>");
                    Writer.WriteByte((byte)m_flags);
                    break;
                case ChatMessageType.Achievement:
                case ChatMessageType.GuildAchievement:
                    Writer.WriteGuid(m_targetGUID);
                    if (m_language == Language.Addon)
                        Writer.WriteCString(m_addonPrefix ?? "<prefix>");
                    Writer.WriteChatString(m_text ?? "<text>");
                    Writer.WriteByte((byte)m_flags);
                    Writer.WriteUInt32(m_achievementId);
                    break;
                case ChatMessageType.WhisperForeign:
                    Writer.WriteChatString(m_senderName ?? "<sender>");
                    Writer.WriteGuid(m_targetGUID);
                    if (m_language == Language.Addon)
                        Writer.WriteCString(m_addonPrefix ?? "<prefix>");
                    Writer.WriteChatString(m_text ?? "<text>");
                    Writer.WriteByte((byte)m_flags);
                    break;
                default:
                    if (GameMasterMessage)
                        Writer.WriteChatString(m_senderName ?? "<sender>");
                    if (m_type == ChatMessageType.Channel)
                        Writer.WriteCString(m_channel ?? "<channel>");
                    Writer.WriteGuid(m_targetGUID);
                    if (m_language == Language.Addon)
                        Writer.WriteCString(m_addonPrefix ?? "<prefix>");
                    Writer.WriteChatString(m_text ?? "<text>");
                    Writer.WriteByte((byte)m_flags);
                    break;
            }
        }

        /// <summary>
        /// Creates a packet representing the current chat message.
        /// </summary>
        /// <returns>
        /// An instance of CustomPacket class that contains the data of current ChatMessage.
        /// </returns>
        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(this.Opcode, TransferDirection.ToClient);
        }

        /// <summary>
        /// Indicates whether the type of the current ChatMessage is supposed to be used by NPCs.
        /// </summary>
        /// <returns>
        /// true, if the type of the current ChatMessage is supposed to be used by NPCs; otherwise, false.
        /// </returns>
        public bool IsNPCMessageType()
        {
            return IsNPCMessageType(m_type);
        }

        public override void ToString(StringBuilder builder)
        {
            builder.AppendLine("Type: " + m_type);
            builder.AppendLine("Language: " + m_language);
            builder.AppendFormatLine("Unknown uint32: {0} (0x{0:X8})", m_unknownUInt32);
            builder.AppendFormatLine("Sender: {0} '{1}'", m_senderGUID, m_senderName ?? "<null>");
            builder.AppendFormatLine("Target: {0} '{1}'", m_targetGUID, m_targetName ?? "<null>");

            builder.AppendLine("Chat Tag: " + m_flags);

            if (!String.IsNullOrEmpty(m_channel))
                builder.AppendLine("Channel: " + m_channel);

            if (m_achievementId != 0)
                builder.AppendLine("Achievement Id: " + m_achievementId);

            builder.AppendLine();

            if (!String.IsNullOrEmpty(m_addonPrefix))
                builder.AppendLine("Addon Prefix: " + m_addonPrefix);

            builder.AppendLine("Text: " + m_text);

            if (m_type == ChatMessageType.RaidBossEmote || m_type == ChatMessageType.RaidBossWhisper)
            {
                builder.AppendLine("Display Time: " + m_displayTime);
                builder.AppendLine("Suspend Event: " + m_suspendEvent);
            }
        }
    }
}
