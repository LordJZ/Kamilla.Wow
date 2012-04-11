using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    /// <summary>
    /// Represents a whisper chat message
    /// </summary>
    public interface IWhisper : IClientChatMessage
    {
        /// <summary>
        /// Gets or sets the name of the target of the whisper.
        /// </summary>
        string TargetName { get; set; }
    }
}
