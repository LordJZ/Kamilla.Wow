using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.IO;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages
{
    public sealed class AfkChatMessage : ClientChatMessage
    {
        protected override WowOpcodes Opcode
        {
            get { return WowOpcodes.CMSG_MESSAGE_AFK; }
        }

        static Elements[] s_elements = new[] { Elements.TextLength, Elements.Text };

        protected override Elements[] PacketElements
        {
            get { return s_elements; }
        }

        public sealed override ChatMessageType MessageType
        {
            get { return ChatMessageType.AFK; }
        }

        public sealed override Language MessageLanguage
        {
            get { return Language.Universal; }
            set { throw new NotSupportedException(); }
        }
    }
}
