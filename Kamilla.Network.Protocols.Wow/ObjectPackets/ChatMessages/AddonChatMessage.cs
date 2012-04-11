using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    /// <summary>
    /// Represents an addon message.
    /// </summary>
    public abstract class AddonChatMessage : ClientChatMessage, IAddonMessage
    {
        protected string m_prefix = string.Empty;

        /// <summary>
        /// Gets or sets the prefix of the chat message.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// The accessor is set and value is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// The accessor is set and value is too long.
        /// </exception>
        public string Prefix
        {
            get
            {
                return m_prefix;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (s_encoding.GetByteCount(value) > s_maxPrefixLength)
                    throw new ArgumentException("value is too long.", "value");

                m_prefix = value;
            }
        }

        /// <summary>
        /// Gets the <see href="Kamilla.Network.Protocols.Wow.Language.Addon"/> language.
        /// </summary>
        public sealed override Language MessageLanguage
        {
            get { return Language.Addon; }
            set { throw new NotSupportedException(); }
        }
    }
}
