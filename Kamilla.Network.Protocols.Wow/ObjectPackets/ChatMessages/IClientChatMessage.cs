using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    /// <summary>
    /// Represents a chat message.
    /// </summary>
    public interface IClientChatMessage
    {
        /// <summary>
        /// Gets or sets the text of the chat message.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets the language of the chat message.
        /// </summary>
        Language MessageLanguage { get; set; }

        /// <summary>
        /// Gets the type of the chat message.
        /// </summary>
        ChatMessageType MessageType { get; }
    }
}
