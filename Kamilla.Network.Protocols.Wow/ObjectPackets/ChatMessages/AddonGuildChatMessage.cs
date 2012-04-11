using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    public sealed class AddonGuildChatMessage : AddonChatMessage, IAddonMessage
    {
        protected override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_ADDON_MESSAGE_GUILD; }
        }

        static Elements[] s_elements = new[] { Elements.PrefixLength, Elements.TextLength, Elements.Prefix, Elements.Text };

        protected override Elements[] PacketElements
        {
            get { return s_elements; }
        }

        public sealed override ChatMessageType MessageType
        {
            get { return ChatMessageType.Guild; }
        }
    }
}
