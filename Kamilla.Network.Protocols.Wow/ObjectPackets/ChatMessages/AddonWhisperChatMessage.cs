using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    public sealed class AddonWhisperChatMessage : AddonChatMessage, IWhisper
    {
        string m_targetName = string.Empty;

        /// <summary>
        /// Gets or sets the targetName of the chat message.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// The accessor is set and value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The accessor is set and value is too long.
        /// </exception>
        public string TargetName
        {
            get
            {
                return m_targetName;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (s_encoding.GetByteCount(value) > s_maxTargetNameLength)
                    throw new ArgumentException("value is too long.", "value");

                m_targetName = value;
            }
        }

        protected override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_ADDON_MESSAGE_WHISPER; }
        }

        static Elements[] s_elements = new[] { Elements.TextLength, Elements.TargetLength, Elements.PrefixLength, Elements.Prefix, Elements.Text, Elements.Target };

        protected override Elements[] PacketElements
        {
            get { return s_elements; }
        }

        public sealed override ChatMessageType MessageType
        {
            get { return ChatMessageType.Whisper; }
        }
    }
}
