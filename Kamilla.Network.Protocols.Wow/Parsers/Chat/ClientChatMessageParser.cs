using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamilla.Network.Protocols.Wow.ObjectPackets.ChatMessages;
using Kamilla.Network.Protocols.Wow.Game;

namespace Kamilla.Network.Protocols.Wow.Parsers.Chat
{
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_AFK)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_DND)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_BATTLEGROUND)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_PARTY)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_GUILD)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_OFFICER)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_SAY)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_YELL)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_WHISPER)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_CHANNEL)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_EMOTE)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_RAID)]
    [WowPacketParser(WowOpcodes.CMSG_MESSAGE_RAID_WARNING)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_WHISPER)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_GUILD)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_OFFICER)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_PARTY)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_RAID)]
    [WowPacketParser(WowOpcodes.CMSG_ADDON_MESSAGE_BATTLEGROUND)]
    internal sealed class ClientChatMessageParser : WowPacketParser
    {
        protected override PacketGroups WowGroup { get { return PacketGroups.Chat; } }

        protected override void InternalParse()
        {
            var type = ClientChatMessage.GetTypeByOpcode((WowOpcodes)this.Packet.Opcode);
            var message = Activator.CreateInstance(type) as ClientChatMessage;
            message.Read(this.Reader);
            message.ToString(this.Output);
        }
    }
}
