using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    public sealed class AddonPartyChatMessage : AddonChatMessage, IAddonMessage
    {
        protected override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_ADDON_MESSAGE_PARTY; }
        }

        static Elements[] s_elements = new[] { Elements.TextLength, Elements.PrefixLength, Elements.Text, Elements.Prefix };

        protected override Elements[] PacketElements
        {
            get { return s_elements; }
        }

        public sealed override ChatMessageType MessageType
        {
            get { return ChatMessageType.Party; }
        }
    }
}
