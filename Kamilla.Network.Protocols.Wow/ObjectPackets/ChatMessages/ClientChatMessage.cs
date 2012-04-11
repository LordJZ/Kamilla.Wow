using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    /// <summary>
    /// Represents a client-to-server chat message.
    /// </summary>
    public abstract class ClientChatMessage : ObjectPacket, IClientChatMessage
    {
        #region Elements
        protected enum Elements
        {
            /// <summary>
            /// 9 bits
            /// </summary>
            TextLength,
            Text,
            /// <summary>
            /// 5 bits
            /// </summary>
            PrefixLength,
            Prefix,
            /// <summary>
            /// 10 bits
            /// </summary>
            TargetLength,
            Target,
            /// <summary>
            /// 10 bits
            /// </summary>
            ChannelLength,
            Channel,
            Language,
        }

        static Action<IClientChatMessage, ReadingContext>[] s_reading = new Action<IClientChatMessage, ReadingContext>[]
        {
            (msg, ctx) => ctx.TextLength = ctx.Reader.UnalignedReadSmallInt(s_textBits),
            (msg, ctx) => msg.Text = ctx.Reader.ReadString(ctx.TextLength),
            (msg, ctx) => ctx.PrefixLength = ctx.Reader.UnalignedReadSmallInt(s_prefixBits),
            (msg, ctx) => ((IAddonMessage)msg).Prefix = ctx.Reader.ReadString(ctx.PrefixLength),
            (msg, ctx) => ctx.TargetNameLength = ctx.Reader.UnalignedReadSmallInt(s_targetNameBits),
            (msg, ctx) => ((IWhisper)msg).TargetName = ctx.Reader.ReadString(ctx.TargetNameLength),
            (msg, ctx) => ctx.ChannelNameLength = ctx.Reader.UnalignedReadSmallInt(s_channelNameBits),
            (msg, ctx) => ((IChannelMessage)msg).ChannelName = ctx.Reader.ReadString(ctx.ChannelNameLength),
            (msg, ctx) => msg.MessageLanguage = (Language)ctx.Reader.ReadUInt32(),
        };

        static Action<IClientChatMessage, WritingContext>[] s_writing = new Action<IClientChatMessage, WritingContext>[]
        {
            (msg, ctx) => ctx.Writer.UnalignedWriteInt((ushort)(ctx.Text = s_encoding.GetBytes(msg.Text)).Length, s_textBits),
            (msg, ctx) => ctx.Writer.FlushUnalignedBits().WriteBytes(ctx.Text),
            (msg, ctx) => ctx.Writer.UnalignedWriteInt((ushort)(ctx.Prefix = s_encoding.GetBytes(((IAddonMessage)msg).Prefix)).Length, s_prefixBits),
            (msg, ctx) => ctx.Writer.FlushUnalignedBits().WriteBytes(ctx.Prefix),
            (msg, ctx) => ctx.Writer.UnalignedWriteInt((ushort)(ctx.TargetName = s_encoding.GetBytes(((IWhisper)msg).TargetName)).Length, s_targetNameBits),
            (msg, ctx) => ctx.Writer.FlushUnalignedBits().WriteBytes(ctx.TargetName),
            (msg, ctx) => ctx.Writer.UnalignedWriteInt((ushort)(ctx.ChannelName = s_encoding.GetBytes(((IChannelMessage)msg).ChannelName)).Length, s_channelNameBits),
            (msg, ctx) => ctx.Writer.FlushUnalignedBits().WriteBytes(ctx.ChannelName),
            (msg, ctx) => ctx.Writer.FlushUnalignedBits().WriteUInt32((uint)msg.MessageLanguage),
        };

        class ReadingContext
        {
            public ReadingContext(StreamHandler reader)
            {
                this.Reader = reader;
            }

            public int TextLength = -1;
            public int PrefixLength = -1;
            public int TargetNameLength = -1;
            public int ChannelNameLength = -1;

            public readonly StreamHandler Reader;
        }

        class WritingContext
        {
            public WritingContext(StreamHandler writer)
            {
                this.Writer = writer;
            }

            public byte[] Text = null;
            public byte[] Prefix = null;
            public byte[] TargetName = null;
            public byte[] ChannelName = null;

            public readonly StreamHandler Writer;
        }
        #endregion

        protected static readonly Encoding s_encoding = Encoding.UTF8;

        protected const int s_textBits = 9;
        protected const int s_maxTextLength = (1 << s_textBits) - 1;
        protected const int s_prefixBits = 5;
        protected const int s_maxPrefixLength = (1 << s_prefixBits) - 1;
        protected const int s_targetNameBits = 10;
        protected const int s_maxTargetNameLength = (1 << s_targetNameBits) - 1;
        protected const int s_channelNameBits = 10;
        protected const int s_maxChannelNameLength = (1 << s_channelNameBits) - 1;

        protected string m_text = string.Empty;

        /// <summary>
        /// Gets or sets the text of the chat message.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// The accessor is set and value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The accessor is set and value is too long.
        /// </exception>
        public string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (s_encoding.GetByteCount(value) > s_maxTextLength)
                    throw new ArgumentException("value is too long.", "value");

                m_text = value;
            }
        }

        /// <summary>
        /// Gets the message type.
        /// </summary>
        public abstract ChatMessageType MessageType { get; }

        /// <summary>
        /// Gets or sets the language of the message.
        /// </summary>
        public abstract Language MessageLanguage { get; set; }

        /// <summary>
        /// Gets the opcode of the current chat message.
        /// </summary>
        protected abstract WowOpcodes Opcode { get; }

        public override CustomPacket CreatePacket()
        {
            return base.CreatePacket(this.Opcode, TransferDirection.ToClient);
        }

        protected abstract Elements[] PacketElements { get; }

        public sealed override void Read(StreamHandler reader)
        {
            var elements = this.PacketElements;
            var ctx = new ReadingContext(reader);

            for (int i = 0; i < elements.Length; i++)
                s_reading[(int)elements[i]](this, ctx);
        }

        public sealed override void Save(StreamHandler writer)
        {
            var elements = this.PacketElements;
            var ctx = new WritingContext(writer);

            for (int i = 0; i < elements.Length; i++)
                s_writing[(int)elements[i]](this, ctx);
        }

        public sealed override void ToString(StringBuilder builder)
        {
            bool hasLang = true;

            if (this is IAddonMessage && !(hasLang = false))
                builder.Append("Prefix: ").AppendLine(((IAddonMessage)this).Prefix);

            if (this is IWhisper && !(hasLang = false))
                builder.Append("Whisper Target: ").AppendLine(((IWhisper)this).TargetName);

            if (this is IChannelMessage)
                builder.Append("Channel: ").AppendLine(((IChannelMessage)this).ChannelName);

            if (hasLang)
                builder.Append("Language: ").AppendLine(this.MessageLanguage.ToString());

            builder.Append("Text: ").AppendLine(this.Text);
        }

        static Dictionary<WowOpcodes, Type> s_opcode2type = new Dictionary<WowOpcodes, Type>()
        {
            { WowOpcodes.CMSG_ADDON_MESSAGE_WHISPER, typeof(AddonWhisperChatMessage) },
            { WowOpcodes.CMSG_ADDON_MESSAGE_GUILD, typeof(AddonGuildChatMessage) },
            { WowOpcodes.CMSG_ADDON_MESSAGE_PARTY, typeof(AddonPartyChatMessage) },
            { WowOpcodes.CMSG_MESSAGE_PARTY, typeof(PartyChatMessage) },
            { WowOpcodes.CMSG_MESSAGE_SAY, typeof(SayChatMessage) },
            { WowOpcodes.CMSG_MESSAGE_AFK, typeof(AfkChatMessage) },
            { WowOpcodes.CMSG_MESSAGE_DND, typeof(DndChatMessage) },
        };

        public static IEnumerable<WowOpcodes> Opcodes { get { return s_opcode2type.Keys; } }

        public static Type GetTypeByOpcode(WowOpcodes opcode)
        {
            Type type;
            if (!s_opcode2type.TryGetValue(opcode, out type))
                throw new ArgumentException();

            return type;
        }
    }
}
