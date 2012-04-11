using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    /// <summary>
    /// Represents an addon chat message.
    /// </summary>
    public interface IAddonMessage : IClientChatMessage
    {
        /// <summary>
        /// Gets or sets the addon prefix of the current message.
        /// </summary>
        string Prefix { get; set; }
    }
}
