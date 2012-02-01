using System.ComponentModel;

namespace Kamilla.Network.Protocols.Wow
{
    public enum WowOpcodes : uint
    {
        UNKNOWN_OPCODE                                  = SpecialWowOpcodes.UnknownOpcode,
        [Description("Special opcode, does not have real id. Specifies special no-opcode packet containing hello string sent when a connection is initialized on both directions. Server sends first: 'WORLD OF WARCRAFT CONNECTION - SERVER TO CLIENT'. And client replies: 'WORLD OF WARCRAFT CONNECTION - CLIENT TO SERVER'. SMSG_AUTH_CHALLENGE is sent after by server after receiving client's 'hello'. This opcodes exists since patch 4.1.0.")]
        HELLO                                           = SpecialWowOpcodes.HelloOpcode,
        CMSG_BOOTME                                     = UNKNOWN_OPCODE, /* old 0x001, */
        CMSG_DBLOOKUP                                   = UNKNOWN_OPCODE, /* old 0x002, */
        SMSG_DBLOOKUP                                   = UNKNOWN_OPCODE, /* old 0x003, */
        CMSG_QUERY_OBJECT_POSITION                      = UNKNOWN_OPCODE, /* old 0x004, */
        SMSG_QUERY_OBJECT_POSITION                      = UNKNOWN_OPCODE, /* old 0x005, */
        CMSG_QUERY_OBJECT_ROTATION                      = UNKNOWN_OPCODE, /* old 0x006, */
        SMSG_QUERY_OBJECT_ROTATION                      = UNKNOWN_OPCODE, /* old 0x007, */
        CMSG_WORLD_TELEPORT                             = UNKNOWN_OPCODE, /* old 0x008, */
        CMSG_TELEPORT_TO_UNIT                           = UNKNOWN_OPCODE, /* old 0x009, */
        CMSG_ZONE_MAP                                   = UNKNOWN_OPCODE, /* old 0x00A, */
        SMSG_ZONE_MAP                                   = UNKNOWN_OPCODE, /* old 0x00B, */
        CMSG_DEBUG_CHANGECELLZONE                       = UNKNOWN_OPCODE, /* old 0x00C, */
        CMSG_MOVE_CHARACTER_CHEAT                       = UNKNOWN_OPCODE, /* old 0x00D, */
        SMSG_MOVE_CHARACTER_CHEAT                       = UNKNOWN_OPCODE, /* old 0x00E, */
        CMSG_RECHARGE                                   = UNKNOWN_OPCODE, /* old 0x00F, */
        CMSG_LEARN_SPELL                                = UNKNOWN_OPCODE, /* old 0x010, */
        CMSG_CREATEMONSTER                              = UNKNOWN_OPCODE, /* old 0x011, */
        CMSG_DESTROYMONSTER                             = UNKNOWN_OPCODE, /* old 0x012, */
        CMSG_CREATEITEM                                 = UNKNOWN_OPCODE, /* old 0x013, */
        CMSG_CREATEGAMEOBJECT                           = UNKNOWN_OPCODE, /* old 0x014, */
        SMSG_CHECK_FOR_BOTS                             = UNKNOWN_OPCODE, /* old 0x015, */
        CMSG_MAKEMONSTERATTACKGUID                      = UNKNOWN_OPCODE, /* old 0x016, */
        CMSG_BOT_DETECTED2                              = UNKNOWN_OPCODE, /* old 0x017, */
        CMSG_FORCEACTION                                = UNKNOWN_OPCODE, /* old 0x018, */
        CMSG_FORCEACTIONONOTHER                         = UNKNOWN_OPCODE, /* old 0x019, */
        CMSG_FORCEACTIONSHOW                            = UNKNOWN_OPCODE, /* old 0x01A, */
        SMSG_FORCEACTIONSHOW                            = UNKNOWN_OPCODE, /* old 0x01B, */
        CMSG_PETGODMODE                                 = UNKNOWN_OPCODE, /* old 0x01C, */
        SMSG_PETGODMODE                                 = UNKNOWN_OPCODE, /* old 0x01D, */
        SMSG_REFER_A_FRIEND_EXPIRED                     = UNKNOWN_OPCODE, /* old 0x01E, */
        CMSG_WEATHER_SPEED_CHEAT                        = UNKNOWN_OPCODE, /* old 0x01F, */
        CMSG_UNDRESSPLAYER                              = UNKNOWN_OPCODE, /* old 0x020, */
        CMSG_BEASTMASTER                                = UNKNOWN_OPCODE, /* old 0x021, */
        CMSG_GODMODE                                    = UNKNOWN_OPCODE, /* old 0x022, */
        SMSG_GODMODE                                    = UNKNOWN_OPCODE, /* old 0x023, */
        CMSG_CHEAT_SETMONEY                             = UNKNOWN_OPCODE, /* old 0x024, */
        CMSG_LEVEL_CHEAT                                = UNKNOWN_OPCODE, /* old 0x025, */
        CMSG_PET_LEVEL_CHEAT                            = UNKNOWN_OPCODE, /* old 0x026, */
        CMSG_SET_WORLDSTATE                             = UNKNOWN_OPCODE, /* old 0x027, */
        CMSG_COOLDOWN_CHEAT                             = UNKNOWN_OPCODE, /* old 0x028, */
        CMSG_USE_SKILL_CHEAT                            = UNKNOWN_OPCODE, /* old 0x029, */
        CMSG_FLAG_QUEST                                 = UNKNOWN_OPCODE, /* old 0x02A, */
        CMSG_FLAG_QUEST_FINISH                          = UNKNOWN_OPCODE, /* old 0x02B, */
        CMSG_CLEAR_QUEST                                = UNKNOWN_OPCODE, /* old 0x02C, */
        CMSG_SEND_EVENT                                 = UNKNOWN_OPCODE, /* old 0x02D, */
        CMSG_DEBUG_AISTATE                              = UNKNOWN_OPCODE, /* old 0x02E, */
        SMSG_DEBUG_AISTATE                              = UNKNOWN_OPCODE, /* old 0x02F, */
        CMSG_DISABLE_PVP_CHEAT                          = UNKNOWN_OPCODE, /* old 0x030, */
        CMSG_ADVANCE_SPAWN_TIME                         = UNKNOWN_OPCODE, /* old 0x031, */
        SMSG_DESTRUCTIBLE_BUILDING_DAMAGE               = UNKNOWN_OPCODE, /* old 0x032, */
        CMSG_AUTH_SRP6_BEGIN                            = UNKNOWN_OPCODE, /* old 0x033, */
        CMSG_AUTH_SRP6_PROOF                            = UNKNOWN_OPCODE, /* old 0x034, */
        CMSG_AUTH_SRP6_RECODE                           = UNKNOWN_OPCODE, /* old 0x035, */
        CMSG_CHAR_CREATE                                = UNKNOWN_OPCODE, /* old 0x036, */
        CMSG_ENUM_CHARACTERS                            = 16465, /* old 0x037, */
        CMSG_CHAR_DELETE                                = UNKNOWN_OPCODE, /* old 0x038, */
        SMSG_AUTH_SRP6_RESPONSE                         = UNKNOWN_OPCODE, /* old 0x039, */
        SMSG_CHAR_CREATE                                = UNKNOWN_OPCODE, /* old 0x03A, */
        SMSG_ENUM_CHARACTERS_RESULT                     = 3317, /* old 0x03B, */
        SMSG_CHAR_DELETE                                = UNKNOWN_OPCODE, /* old 0x03C, */
        CMSG_PLAYER_LOGIN                               = UNKNOWN_OPCODE, /* old 0x03D, */
        SMSG_NEW_WORLD                                  = UNKNOWN_OPCODE, /* old 0x03E, */
        SMSG_ABORT_NEW_WORLD                            = UNKNOWN_OPCODE,
        SMSG_TRANSFER_PENDING                           = UNKNOWN_OPCODE, /* old 0x03F, */
        SMSG_TRANSFER_ABORTED                           = UNKNOWN_OPCODE, /* old 0x040, */
        SMSG_CHARACTER_LOGIN_FAILED                     = UNKNOWN_OPCODE, /* old 0x041, */
        SMSG_LOGIN_SETTIMESPEED                         = UNKNOWN_OPCODE, /* old 0x042, */
        SMSG_GAMETIME_UPDATE                            = UNKNOWN_OPCODE, /* old 0x043, */
        CMSG_GAMETIME_SET                               = UNKNOWN_OPCODE, /* old 0x044, */
        SMSG_GAMETIME_SET                               = UNKNOWN_OPCODE, /* old 0x045, */
        CMSG_GAMESPEED_SET                              = UNKNOWN_OPCODE, /* old 0x046, */
        SMSG_GAMESPEED_SET                              = UNKNOWN_OPCODE, /* old 0x047, */
        CMSG_SERVERTIME                                 = UNKNOWN_OPCODE, /* old 0x048, */
        SMSG_SERVERTIME                                 = UNKNOWN_OPCODE, /* old 0x049, */
        CMSG_PLAYER_LOGOUT                              = UNKNOWN_OPCODE, /* old 0x04A, */
        CMSG_LOGOUT_REQUEST                             = UNKNOWN_OPCODE, /* old 0x04B, */
        SMSG_LOGOUT_RESPONSE                            = UNKNOWN_OPCODE, /* old 0x04C, */
        SMSG_LOGOUT_COMPLETE                            = UNKNOWN_OPCODE, /* old 0x04D, */
        CMSG_LOGOUT_CANCEL                              = UNKNOWN_OPCODE, /* old 0x04E, */
        SMSG_LOGOUT_CANCEL_ACK                          = UNKNOWN_OPCODE, /* old 0x04F, */
        CMSG_NAME_QUERY                                 = UNKNOWN_OPCODE, /* old 0x050, */
        SMSG_NAME_QUERY_RESPONSE                        = UNKNOWN_OPCODE, /* old 0x051, */
        CMSG_PET_NAME_QUERY                             = UNKNOWN_OPCODE, /* old 0x052, */
        SMSG_PET_NAME_QUERY_RESPONSE                    = UNKNOWN_OPCODE, /* old 0x053, */
        CMSG_GUILD_QUERY                                = UNKNOWN_OPCODE, /* old 0x054, */
        SMSG_GUILD_QUERY_RESPONSE                       = UNKNOWN_OPCODE, /* old 0x055, */
        CMSG_PAGE_TEXT_QUERY                            = UNKNOWN_OPCODE, /* old 0x05A, */
        SMSG_PAGE_TEXT_QUERY_RESPONSE                   = UNKNOWN_OPCODE, /* old 0x05B, */
        CMSG_QUEST_QUERY                                = UNKNOWN_OPCODE, /* old 0x05C, */
        SMSG_QUEST_QUERY_RESPONSE                       = UNKNOWN_OPCODE, /* old 0x05D, */
        CMSG_GAMEOBJECT_QUERY                           = UNKNOWN_OPCODE, /* old 0x05E, */
        SMSG_GAMEOBJECT_QUERY_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x05F, */
        CMSG_CREATURE_QUERY                             = UNKNOWN_OPCODE, /* old 0x060, */
        SMSG_CREATURE_QUERY_RESPONSE                    = UNKNOWN_OPCODE, /* old 0x061, */
        CMSG_WHO                                        = UNKNOWN_OPCODE, /* old 0x062, */
        SMSG_WHO                                        = UNKNOWN_OPCODE, /* old 0x063, */
        CMSG_WHOIS                                      = UNKNOWN_OPCODE, /* old 0x064, */
        SMSG_WHOIS                                      = UNKNOWN_OPCODE, /* old 0x065, */
        CMSG_CONTACT_LIST                               = UNKNOWN_OPCODE, /* old 0x066, */
        SMSG_CONTACT_LIST                               = UNKNOWN_OPCODE, /* old 0x067, */
        SMSG_FRIEND_STATUS                              = UNKNOWN_OPCODE, /* old 0x068, */
        CMSG_ADD_FRIEND                                 = UNKNOWN_OPCODE, /* old 0x069, */
        CMSG_DEL_FRIEND                                 = UNKNOWN_OPCODE, /* old 0x06A, */
        CMSG_SET_CONTACT_NOTES                          = UNKNOWN_OPCODE, /* old 0x06B, */
        CMSG_ADD_IGNORE                                 = UNKNOWN_OPCODE, /* old 0x06C, */
        CMSG_DEL_IGNORE                                 = UNKNOWN_OPCODE, /* old 0x06D, */
        CMSG_PARTY_INVITE                               = UNKNOWN_OPCODE, /* old 0x06E, */
        SMSG_PARTY_INVITE                               = UNKNOWN_OPCODE, /* old 0x06F, */
        CMSG_GROUP_CANCEL                               = UNKNOWN_OPCODE, /* old 0x070, */
        SMSG_GROUP_CANCEL                               = UNKNOWN_OPCODE, /* old 0x071, */
        CMSG_PARTY_INVITE_RESPONSE                      = UNKNOWN_OPCODE,
        CMSG_GROUP_ACCEPT                               = UNKNOWN_OPCODE, /* old 0x072, */ // exists?
        CMSG_GROUP_DECLINE                              = UNKNOWN_OPCODE, /* old 0x073, */ // exists?
        SMSG_GROUP_DECLINE                              = UNKNOWN_OPCODE, /* old 0x074, */
        CMSG_GROUP_UNINVITE                             = UNKNOWN_OPCODE, /* old 0x075, */
        CMSG_GROUP_UNINVITE_GUID                        = UNKNOWN_OPCODE, /* old 0x076, */
        SMSG_GROUP_UNINVITE                             = UNKNOWN_OPCODE, /* old 0x077, */
        CMSG_GROUP_SET_LEADER                           = UNKNOWN_OPCODE, /* old 0x078, */
        SMSG_GROUP_SET_LEADER                           = UNKNOWN_OPCODE, /* old 0x079, */
        CMSG_LOOT_METHOD                                = UNKNOWN_OPCODE, /* old 0x07A, */
        CMSG_GROUP_DISBAND                              = UNKNOWN_OPCODE, /* old 0x07B, */
        SMSG_GROUP_DESTROYED                            = UNKNOWN_OPCODE, /* old 0x07C, */
        SMSG_GROUP_LIST                                 = UNKNOWN_OPCODE, /* old 0x07D, */
        SMSG_PARTY_MEMBER_STATS                         = UNKNOWN_OPCODE, /* old 0x07E, */
        SMSG_PARTY_COMMAND_RESULT                       = UNKNOWN_OPCODE, /* old 0x07F, */
        UMSG_UPDATE_GROUP_MEMBERS                       = UNKNOWN_OPCODE, /* old 0x080, */
        CMSG_GUILD_CREATE                               = UNKNOWN_OPCODE, /* old 0x081, */
        CMSG_GUILD_INVITE                               = UNKNOWN_OPCODE, /* old 0x082, */
        SMSG_GUILD_INVITE                               = UNKNOWN_OPCODE, /* old 0x083, */
        CMSG_GUILD_DECLINE_INVITATION                   = UNKNOWN_OPCODE, /* old 0x085, */
        CMSG_ACCEPT_GUILD_INVITE                        = UNKNOWN_OPCODE, /* old 0x084, */
        SMSG_GUILD_DECLINE                              = UNKNOWN_OPCODE, /* old 0x086, */
        CMSG_GUILD_INFO                                 = UNKNOWN_OPCODE, /* old 0x087, */
        SMSG_GUILD_INFO                                 = UNKNOWN_OPCODE, /* old 0x088, */
        SMSG_GUILD_NAME_CHANGED                         = UNKNOWN_OPCODE,
        CMSG_GUILD_SHIFT_RANK                           = UNKNOWN_OPCODE,
        CMSG_GUILD_ASSIGN_MEMBER_RANK                   = UNKNOWN_OPCODE,
        SMSG_GUILD_SEND_RANK_CHANGE                     = UNKNOWN_OPCODE,
        CMSG_GUILD_PROMOTE_MEMBER                       = UNKNOWN_OPCODE, /* old 0x08B, */
        CMSG_GUILD_DEMOTE_MEMBER                        = UNKNOWN_OPCODE, /* old 0x08C, */
        CMSG_GUILD_LEAVE                                = UNKNOWN_OPCODE, /* old 0x08D, */
        CMSG_GUILD_OFFICER_REMOVE_MEMBER                = UNKNOWN_OPCODE, /* old 0x08E, */
        CMSG_GUILD_DELETE                               = UNKNOWN_OPCODE, /* old 0x08F, */
        CMSG_GUILD_SET_GUILD_MASTER                     = UNKNOWN_OPCODE, /* old 0x090, */
        CMSG_GUILD_UPDATE_MOTD_TEXT                     = UNKNOWN_OPCODE, /* old 0x091, */
        SMSG_GUILD_EVENT                                = UNKNOWN_OPCODE, /* old 0x092, */
        SMSG_GUILD_COMMAND_RESULT                       = UNKNOWN_OPCODE, /* old 0x093, */
        UMSG_UPDATE_GUILD                               = UNKNOWN_OPCODE, /* old 0x094, */
        CMSG_JOIN_CHANNEL                               = UNKNOWN_OPCODE, /* old 0x097, */
        CMSG_LEAVE_CHANNEL                              = UNKNOWN_OPCODE, /* old 0x098, */
        SMSG_CHANNEL_NOTIFY                             = UNKNOWN_OPCODE, /* old 0x099, */
        CMSG_CHANNEL_LIST                               = UNKNOWN_OPCODE, /* old 0x09A, */
        SMSG_CHANNEL_LIST                               = UNKNOWN_OPCODE, /* old 0x09B, */
        CMSG_CHANNEL_PASSWORD                           = UNKNOWN_OPCODE, /* old 0x09C, */
        CMSG_CHANNEL_SET_OWNER                          = UNKNOWN_OPCODE, /* old 0x09D, */
        CMSG_CHANNEL_OWNER                              = UNKNOWN_OPCODE, /* old 0x09E, */
        CMSG_CHANNEL_MODERATOR                          = UNKNOWN_OPCODE, /* old 0x09F, */
        CMSG_CHANNEL_UNMODERATOR                        = UNKNOWN_OPCODE, /* old 0x0A0, */
        CMSG_CHANNEL_MUTE                               = UNKNOWN_OPCODE, /* old 0x0A1, */
        CMSG_CHANNEL_UNMUTE                             = UNKNOWN_OPCODE, /* old 0x0A2, */
        CMSG_CHANNEL_INVITE                             = UNKNOWN_OPCODE, /* old 0x0A3, */
        CMSG_CHANNEL_KICK                               = UNKNOWN_OPCODE, /* old 0x0A4, */
        CMSG_CHANNEL_BAN                                = UNKNOWN_OPCODE, /* old 0x0A5, */
        CMSG_CHANNEL_UNBAN                              = UNKNOWN_OPCODE, /* old 0x0A6, */
        CMSG_CHANNEL_ANNOUNCEMENTS                      = UNKNOWN_OPCODE, /* old 0x0A7, */
        CMSG_CHANNEL_MODERATE                           = UNKNOWN_OPCODE, /* old 0x0A8, */
        SMSG_UPDATE_OBJECT                              = UNKNOWN_OPCODE, /* old 0x0A9, */
        SMSG_DESTROY_OBJECT                             = UNKNOWN_OPCODE, /* old 0x0AA, */
        CMSG_USE_ITEM                                   = UNKNOWN_OPCODE, /* old 0x0AB, */
        CMSG_OPEN_ITEM                                  = UNKNOWN_OPCODE, /* old 0x0AC, */
        CMSG_READ_ITEM                                  = UNKNOWN_OPCODE, /* old 0x0AD, */
        SMSG_READ_ITEM_OK                               = UNKNOWN_OPCODE, /* old 0x0AE, */
        SMSG_READ_ITEM_FAILED                           = UNKNOWN_OPCODE, /* old 0x0AF, */
        SMSG_ITEM_COOLDOWN                              = UNKNOWN_OPCODE, /* old 0x0B0, */
        CMSG_GAMEOBJ_USE                                = UNKNOWN_OPCODE, /* old 0x0B1, */
        CMSG_DESTROY_ITEMS                              = UNKNOWN_OPCODE, /* old 0x0B2, */
        SMSG_GAMEOBJECT_CUSTOM_ANIM                     = UNKNOWN_OPCODE, /* old 0x0B3, */
        CMSG_AREATRIGGER                                = UNKNOWN_OPCODE, /* old 0x0B4, */
        SMSG_MONSTER_MOVE                               = UNKNOWN_OPCODE, /* old 0x0DD, */
        CMSG_TRIGGER_CINEMATIC_CHEAT                    = UNKNOWN_OPCODE, /* old 0x0F8, */
        CMSG_OPENING_CINEMATIC                          = UNKNOWN_OPCODE, /* old 0x0F9, */
        SMSG_TRIGGER_CINEMATIC                          = UNKNOWN_OPCODE, /* old 0x0FA, */
        [Description("empty")]
        CMSG_NEXT_CINEMATIC_CAMERA                      = UNKNOWN_OPCODE, /* old 0x0FB, */
        CMSG_COMPLETE_CINEMATIC                         = UNKNOWN_OPCODE, /* old 0x0FC, */
        [Description("Sent after SMSG_CLIENTCACHE_VERSION")]
        SMSG_TUTORIAL_FLAGS                             = UNKNOWN_OPCODE, /* old 0x0FD, */
        CMSG_TUTORIAL_FLAG                              = UNKNOWN_OPCODE, /* old 0x0FE, */
        CMSG_TUTORIAL_CLEAR                             = UNKNOWN_OPCODE, /* old 0x0FF, */
        CMSG_TUTORIAL_RESET                             = UNKNOWN_OPCODE, /* old 0x100, */
        CMSG_STANDSTATECHANGE                           = UNKNOWN_OPCODE, /* old 0x101, */
        CMSG_EMOTE                                      = UNKNOWN_OPCODE, /* old 0x102, */
        SMSG_EMOTE                                      = UNKNOWN_OPCODE, /* old 0x103, */
        CMSG_TEXT_EMOTE                                 = UNKNOWN_OPCODE, /* old 0x104, */
        SMSG_TEXT_EMOTE                                 = UNKNOWN_OPCODE, /* old 0x105, */
        CMSG_AUTOEQUIP_GROUND_ITEM                      = UNKNOWN_OPCODE, /* old 0x106, */
        CMSG_AUTOSTORE_GROUND_ITEM                      = UNKNOWN_OPCODE, /* old 0x107, */
        CMSG_AUTOSTORE_LOOT_ITEM                        = UNKNOWN_OPCODE, /* old 0x108, */
        CMSG_STORE_LOOT_IN_SLOT                         = UNKNOWN_OPCODE, /* old 0x109, */
        CMSG_AUTOEQUIP_ITEM                             = UNKNOWN_OPCODE, /* old 0x10A, */
        CMSG_AUTOSTORE_BAG_ITEM                         = UNKNOWN_OPCODE, /* old 0x10B, */
        CMSG_SWAP_ITEM                                  = UNKNOWN_OPCODE, /* old 0x10C, */
        CMSG_SWAP_INV_ITEM                              = UNKNOWN_OPCODE, /* old 0x10D, */
        CMSG_SPLIT_ITEM                                 = UNKNOWN_OPCODE, /* old 0x10E, */
        CMSG_AUTOEQUIP_ITEM_SLOT                        = UNKNOWN_OPCODE, /* old 0x10F, */
        CMSG_UNCLAIM_LICENSE                            = UNKNOWN_OPCODE, /* old 0x110, */
        CMSG_DESTROYITEM                                = UNKNOWN_OPCODE, /* old 0x111, */
        SMSG_INVENTORY_CHANGE_FAILURE                   = UNKNOWN_OPCODE, /* old 0x112, */
        [Description("EVENT_BAG_OPEN")]
        SMSG_OPEN_CONTAINER                             = UNKNOWN_OPCODE, /* old 0x113, */
        CMSG_INSPECT                                    = UNKNOWN_OPCODE, /* old 0x114, */
        SMSG_INSPECT_RESULTS_UPDATE                     = UNKNOWN_OPCODE, /* old 0x115, */
        CMSG_INITIATE_TRADE                             = UNKNOWN_OPCODE, /* old 0x116, */
        CMSG_BEGIN_TRADE                                = UNKNOWN_OPCODE, /* old 0x117, */
        CMSG_BUSY_TRADE                                 = UNKNOWN_OPCODE, /* old 0x118, */
        CMSG_IGNORE_TRADE                               = UNKNOWN_OPCODE, /* old 0x119, */
        CMSG_ACCEPT_TRADE                               = UNKNOWN_OPCODE, /* old 0x11A, */
        CMSG_UNACCEPT_TRADE                             = UNKNOWN_OPCODE, /* old 0x11B, */
        CMSG_CANCEL_TRADE                               = UNKNOWN_OPCODE, /* old 0x11C, */
        CMSG_SET_TRADE_ITEM                             = UNKNOWN_OPCODE, /* old 0x11D, */
        CMSG_CLEAR_TRADE_ITEM                           = UNKNOWN_OPCODE, /* old 0x11E, */
        CMSG_SET_TRADE_GOLD                             = UNKNOWN_OPCODE, /* old 0x11F, */
        CMSG_SET_TRADE_CURRENCY                         = UNKNOWN_OPCODE,
        SMSG_TRADE_STATUS                               = UNKNOWN_OPCODE, /* old 0x120, */
        SMSG_TRADE_UPDATED                              = UNKNOWN_OPCODE, /* old 0x121, */
        SMSG_INITIALIZE_FACTIONS                        = UNKNOWN_OPCODE, /* old 0x122, */
        SMSG_SET_FACTION_VISIBLE                        = UNKNOWN_OPCODE, /* old 0x123, */
        SMSG_SET_FACTION_STANDING                       = UNKNOWN_OPCODE, /* old 0x124, */
        CMSG_SET_FACTION_ATWAR                          = UNKNOWN_OPCODE, /* old 0x125, */
        CMSG_SET_FACTION_CHEAT                          = UNKNOWN_OPCODE, /* old 0x126, */
        SMSG_SET_PROFICIENCY                            = UNKNOWN_OPCODE, /* old 0x127, */
        CMSG_SET_ACTION_BUTTON                          = UNKNOWN_OPCODE, /* old 0x128, */
        SMSG_ACTION_BUTTONS                             = UNKNOWN_OPCODE, /* old 0x129, */
        SMSG_INITIAL_SPELLS                             = UNKNOWN_OPCODE, /* old 0x12A, */
        SMSG_LEARNED_SPELL                              = UNKNOWN_OPCODE, /* old 0x12B, */
        SMSG_SUPERCEDED_SPELL                           = UNKNOWN_OPCODE, /* old 0x12C, */
        CMSG_NEW_SPELL_SLOT                             = UNKNOWN_OPCODE, /* old 0x12D, */
        CMSG_CAST_SPELL                                 = UNKNOWN_OPCODE, /* old 0x12E, */
        CMSG_CANCEL_CAST                                = UNKNOWN_OPCODE, /* old 0x12F, */
        SMSG_CAST_FAILED                                = UNKNOWN_OPCODE, /* old 0x130, */
        SMSG_SPELL_START                                = UNKNOWN_OPCODE, /* old 0x131, */
        SMSG_SPELL_GO                                   = UNKNOWN_OPCODE, /* old 0x132, */
        SMSG_SPELL_FAILURE                              = UNKNOWN_OPCODE, /* old 0x133, */
        SMSG_SPELL_COOLDOWN                             = UNKNOWN_OPCODE, /* old 0x134, */
        SMSG_COOLDOWN_EVENT                             = UNKNOWN_OPCODE, /* old 0x135, */
        CMSG_CANCEL_AURA                                = UNKNOWN_OPCODE, /* old 0x136, */
        SMSG_EQUIPMENT_SET_ID                           = UNKNOWN_OPCODE, /* old 0x137, */
        SMSG_PET_CAST_FAILED                            = UNKNOWN_OPCODE, /* old 0x138, */
        MSG_CHANNEL_START                               = UNKNOWN_OPCODE, /* old 0x139, */
        MSG_CHANNEL_UPDATE                              = UNKNOWN_OPCODE, /* old 0x13A, */
        CMSG_CANCEL_CHANNELLING                         = UNKNOWN_OPCODE, /* old 0x13B, */
        SMSG_AI_REACTION                                = UNKNOWN_OPCODE, /* old 0x13C, */
        CMSG_SET_SELECTION                              = UNKNOWN_OPCODE, /* old 0x13D, */
        CMSG_DELETEEQUIPMENT_SET                        = UNKNOWN_OPCODE, /* old 0x13E, */
        CMSG_INSTANCE_LOCK_RESPONSE                     = UNKNOWN_OPCODE, /* old 0x13F, */
        CMSG_DEBUG_PASSIVE_AURA                         = UNKNOWN_OPCODE, /* old 0x140, */
        CMSG_ATTACKSWING                                = UNKNOWN_OPCODE, /* old 0x141, */
        CMSG_ATTACKSTOP                                 = UNKNOWN_OPCODE, /* old 0x142, */
        [Description("uint64 guid, uint64 victim. if (CGUnit_C* unit = ClntObjMgrObjectPtr(guid, TYPEMASK_UNIT)) { unit->something = 0; unit->SetAttacking(victim, 85); if (unit->IsActivePlayer()) { raiseevent(EVENT_PLAYER_ENTER_COMBAT); CGGameUI::UpdateCombatMode(); } }")]
        SMSG_ATTACKSTART                                = UNKNOWN_OPCODE, /* old 0x143, */
        SMSG_ATTACKSTOP                                 = UNKNOWN_OPCODE, /* old 0x144, */
        SMSG_ATTACKSWING_NOTINRANGE                     = UNKNOWN_OPCODE, /* old 0x145, */
        SMSG_ATTACKSWING_BADFACING                      = UNKNOWN_OPCODE, /* old 0x146, */
        SMSG_PENDING_RAID_LOCK                          = UNKNOWN_OPCODE, /* old 0x147, */
        [Description("4.1.0 possibly swapped with SMSG_ATTACKSWING_CANT_ATTACK")]
        SMSG_ATTACKSWING_DEADTARGET                     = UNKNOWN_OPCODE, /* old 0x148, */
        [Description("4.1.0 possibly swapped with SMSG_ATTACKSWING_DEADTARGET")]
        SMSG_ATTACKSWING_CANT_ATTACK                    = UNKNOWN_OPCODE, /* old 0x149, */
        SMSG_ATTACKERSTATEUPDATE                        = UNKNOWN_OPCODE, /* old 0x14A, */
        SMSG_BATTLEFIELD_PORT_DENIED                    = UNKNOWN_OPCODE, /* old 0x14B, */
        CMSG_PERFORM_ACTION_SET                         = UNKNOWN_OPCODE, /* old 0x14C, */
        SMSG_RESUME_CAST_BAR                            = UNKNOWN_OPCODE, /* old 0x14D, */
        SMSG_CANCEL_COMBAT                              = UNKNOWN_OPCODE, /* old 0x14E, */
        SMSG_SPELLBREAKLOG                              = UNKNOWN_OPCODE, /* old 0x14F, */
        SMSG_SPELLHEALLOG                               = UNKNOWN_OPCODE, /* old 0x150, */
        SMSG_SPELLENERGIZELOG                           = UNKNOWN_OPCODE, /* old 0x151, */
        SMSG_BREAK_TARGET                               = UNKNOWN_OPCODE, /* old 0x152, */
        CMSG_SAVE_PLAYER                                = UNKNOWN_OPCODE, /* old 0x153, */
        CMSG_SETDEATHBINDPOINT                          = UNKNOWN_OPCODE, /* old 0x154, */
        SMSG_BINDPOINTUPDATE                            = UNKNOWN_OPCODE, /* old 0x155, */
        CMSG_GETDEATHBINDZONE                           = UNKNOWN_OPCODE, /* old 0x156, */
        SMSG_BINDZONEREPLY                              = UNKNOWN_OPCODE, /* old 0x157, */
        SMSG_PLAYERBOUND                                = UNKNOWN_OPCODE, /* old 0x158, */
        SMSG_CLIENT_CONTROL_UPDATE                      = UNKNOWN_OPCODE, /* old 0x159, */
        CMSG_REPOP_REQUEST                              = UNKNOWN_OPCODE, /* old 0x15A, */
        SMSG_RESURRECT_REQUEST                          = UNKNOWN_OPCODE, /* old 0x15B, */
        CMSG_RESURRECT_RESPONSE                         = UNKNOWN_OPCODE, /* old 0x15C, */
        CMSG_LOOT                                       = UNKNOWN_OPCODE, /* old 0x15D, */
        CMSG_LOOT_MONEY                                 = UNKNOWN_OPCODE, /* old 0x15E, */
        CMSG_LOOT_RELEASE                               = UNKNOWN_OPCODE, /* old 0x15F, */
        SMSG_LOOT_RESPONSE                              = UNKNOWN_OPCODE, /* old 0x160, */
        SMSG_LOOT_RELEASE_RESPONSE                      = UNKNOWN_OPCODE, /* old 0x161, */
        SMSG_LOOT_REMOVED                               = UNKNOWN_OPCODE, /* old 0x162, */
        SMSG_LOOT_MONEY_NOTIFY                          = UNKNOWN_OPCODE, /* old 0x163, */
        SMSG_LOOT_ITEM_NOTIFY                           = UNKNOWN_OPCODE, /* old 0x164, */
        SMSG_LOOT_CLEAR_MONEY                           = UNKNOWN_OPCODE, /* old 0x165, */
        SMSG_ITEM_PUSH_RESULT                           = UNKNOWN_OPCODE, /* old 0x166, */
        SMSG_DUEL_REQUESTED                             = UNKNOWN_OPCODE, /* old 0x167, */
        SMSG_DUEL_OUTOFBOUNDS                           = UNKNOWN_OPCODE, /* old 0x168, */
        SMSG_DUEL_INBOUNDS                              = UNKNOWN_OPCODE, /* old 0x169, */
        SMSG_DUEL_COMPLETE                              = UNKNOWN_OPCODE, /* old 0x16A, */
        SMSG_DUEL_WINNER                                = UNKNOWN_OPCODE, /* old 0x16B, */
        CMSG_DUEL_ACCEPTED                              = UNKNOWN_OPCODE, /* old 0x16C, */
        CMSG_DUEL_CANCELLED                             = UNKNOWN_OPCODE, /* old 0x16D, */
        [Description("11 error cases, ERR_MOUNT_INVALIDMOUNTEE")]
        SMSG_MOUNTRESULT                                = UNKNOWN_OPCODE, /* old 0x16E, */
        [Description("4 error cases, ERR_DISMOUNT_NOPET")]
        SMSG_DISMOUNTRESULT                             = UNKNOWN_OPCODE, /* old 0x16F, */
        SMSG_REMOVED_FROM_PVP_QUEUE                     = UNKNOWN_OPCODE, /* old 0x170, */  // ERR_REMOVE_FROM_PVP_QUEUE_* events
        CMSG_MOUNTSPECIAL_ANIM                          = UNKNOWN_OPCODE, /* old 0x171, */
        SMSG_MOUNTSPECIAL_ANIM                          = UNKNOWN_OPCODE, /* old 0x172, */
        SMSG_PET_TAME_FAILURE                           = UNKNOWN_OPCODE, /* old 0x173, */
        CMSG_PET_SET_ACTION                             = UNKNOWN_OPCODE, /* old 0x174, */
        CMSG_PET_ACTION                                 = UNKNOWN_OPCODE, /* old 0x175, */
        CMSG_PET_ABANDON                                = UNKNOWN_OPCODE, /* old 0x176, */
        CMSG_PET_RENAME                                 = UNKNOWN_OPCODE, /* old 0x177, */
        SMSG_PET_NAME_INVALID                           = UNKNOWN_OPCODE, /* old 0x178, */
        SMSG_PET_SPELLS                                 = UNKNOWN_OPCODE, /* old 0x179, */
        SMSG_PET_MODE                                   = UNKNOWN_OPCODE, /* old 0x17A, */
        CMSG_SET_PET_SLOT                               = UNKNOWN_OPCODE,
        SMSG_PET_SLOT_UPDATED                           = UNKNOWN_OPCODE,
        SMSG_PET_ADDED                                  = UNKNOWN_OPCODE,
        [Description("uint64 guid")]
        CMSG_GOSSIP_HELLO                               = UNKNOWN_OPCODE, /* old 0x17B, */
        CMSG_GOSSIP_SELECT_OPTION                       = UNKNOWN_OPCODE, /* old 0x17C, */
        SMSG_GOSSIP_MESSAGE                             = UNKNOWN_OPCODE, /* old 0x17D, */
        SMSG_GOSSIP_COMPLETE                            = UNKNOWN_OPCODE, /* old 0x17E, */
        CMSG_NPC_TEXT_QUERY                             = UNKNOWN_OPCODE, /* old 0x17F, */
        SMSG_NPC_TEXT_UPDATE                            = UNKNOWN_OPCODE, /* old 0x180, */
        SMSG_NPC_WONT_TALK                              = UNKNOWN_OPCODE, /* old 0x181, */
        CMSG_QUESTGIVER_STATUS_QUERY                    = UNKNOWN_OPCODE, /* old 0x182, */
        SMSG_QUESTGIVER_STATUS                          = UNKNOWN_OPCODE, /* old 0x183, */
        CMSG_QUESTGIVER_HELLO                           = UNKNOWN_OPCODE, /* old 0x184, */
        SMSG_QUESTGIVER_QUEST_LIST                      = UNKNOWN_OPCODE, /* old 0x185, */
        CMSG_QUESTGIVER_QUERY_QUEST                     = UNKNOWN_OPCODE, /* old 0x186, */
        CMSG_QUESTGIVER_QUEST_AUTOLAUNCH                = UNKNOWN_OPCODE, /* old 0x187, */
        SMSG_QUESTGIVER_QUEST_DETAILS                   = UNKNOWN_OPCODE, /* old 0x188, */
        CMSG_QUESTGIVER_ACCEPT_QUEST                    = UNKNOWN_OPCODE, /* old 0x189, */
        CMSG_QUESTGIVER_COMPLETE_QUEST                  = UNKNOWN_OPCODE, /* old 0x18A, */
        SMSG_QUESTGIVER_REQUEST_ITEMS                   = UNKNOWN_OPCODE, /* old 0x18B, */
        CMSG_QUESTGIVER_REQUEST_REWARD                  = UNKNOWN_OPCODE, /* old 0x18C, */
        SMSG_QUESTGIVER_OFFER_REWARD                    = UNKNOWN_OPCODE, /* old 0x18D, */
        CMSG_QUESTGIVER_CHOOSE_REWARD                   = UNKNOWN_OPCODE, /* old 0x18E, */
        SMSG_QUESTGIVER_QUEST_INVALID                   = UNKNOWN_OPCODE, /* old 0x18F, */
        CMSG_QUESTGIVER_CANCEL                          = UNKNOWN_OPCODE, /* old 0x190, */
        SMSG_QUEST_GIVER_QUEST_COMPLETE                  = UNKNOWN_OPCODE, /* old 0x191, */
        SMSG_QUESTGIVER_QUEST_FAILED                    = UNKNOWN_OPCODE, /* old 0x192, */
        CMSG_QUESTLOG_SWAP_QUEST                        = UNKNOWN_OPCODE, /* old 0x193, */
        CMSG_QUESTLOG_REMOVE_QUEST                      = UNKNOWN_OPCODE, /* old 0x194, */
        SMSG_QUESTLOG_FULL                              = UNKNOWN_OPCODE, /* old 0x195, */
        SMSG_QUESTUPDATE_FAILED                         = UNKNOWN_OPCODE, /* old 0x196, */
        SMSG_QUESTUPDATE_FAILEDTIMER                    = UNKNOWN_OPCODE, /* old 0x197, */
        SMSG_QUESTUPDATE_COMPLETE                       = UNKNOWN_OPCODE, /* old 0x198, */
        SMSG_QUESTUPDATE_ADD_KILL                       = UNKNOWN_OPCODE, /* old 0x199, */
        SMSG_QUESTUPDATE_ADD_ITEM_OBOSLETE              = UNKNOWN_OPCODE, /* old 0x19A, */
        CMSG_QUEST_CONFIRM_ACCEPT                       = UNKNOWN_OPCODE, /* old 0x19B, */
        SMSG_QUEST_CONFIRM_ACCEPT                       = UNKNOWN_OPCODE, /* old 0x19C, */
        CMSG_PUSHQUESTTOPARTY                           = UNKNOWN_OPCODE, /* old 0x19D, */
        CMSG_LIST_INVENTORY                             = UNKNOWN_OPCODE, /* old 0x19E, */
        SMSG_VENDOR_INVENTORY                             = UNKNOWN_OPCODE, /* old 0x19F, */
        CMSG_SELL_ITEM                                  = UNKNOWN_OPCODE, /* old 0x1A0, */
        SMSG_SELL_ITEM                                  = UNKNOWN_OPCODE, /* old 0x1A1, */
        CMSG_BUY_ITEM                                   = UNKNOWN_OPCODE, /* old 0x1A2, */
        CMSG_BUY_ITEM_IN_SLOT                           = UNKNOWN_OPCODE, /* old 0x1A3, */
        SMSG_BUY_ITEM                                   = UNKNOWN_OPCODE, /* old 0x1A4, */
        SMSG_BUY_FAILED                                 = UNKNOWN_OPCODE, /* old 0x1A5, */
        CMSG_TAXICLEARALLNODES                          = UNKNOWN_OPCODE, /* old 0x1A6, */
        CMSG_TAXIENABLEALLNODES                         = UNKNOWN_OPCODE, /* old 0x1A7, */
        CMSG_TAXISHOWNODES                              = UNKNOWN_OPCODE, /* old 0x1A8, */
        SMSG_SHOWTAXINODES                              = UNKNOWN_OPCODE, /* old 0x1A9, */
        CMSG_TAXINODE_STATUS_QUERY                      = UNKNOWN_OPCODE, /* old 0x1AA, */
        SMSG_TAXINODE_STATUS                            = UNKNOWN_OPCODE, /* old 0x1AB, */
        CMSG_TAXIQUERYAVAILABLENODES                    = UNKNOWN_OPCODE, /* old 0x1AC, */
        CMSG_ACTIVATETAXI                               = UNKNOWN_OPCODE, /* old 0x1AD, */
        SMSG_ACTIVATETAXIREPLY                          = UNKNOWN_OPCODE, /* old 0x1AE, */
        [Description("ERR_NEWTAXIPATH, empty")]
        SMSG_NEW_TAXI_PATH                              = UNKNOWN_OPCODE, /* old 0x1AF, */
        CMSG_TRAINER_LIST                               = UNKNOWN_OPCODE, /* old 0x1B0, */
        SMSG_TRAINER_LIST                               = UNKNOWN_OPCODE, /* old 0x1B1, */
        CMSG_TRAINER_BUY_SPELL                          = UNKNOWN_OPCODE, /* old 0x1B2, */
        SMSG_TRAINER_BUY_SUCCEEDED                      = UNKNOWN_OPCODE, /* old 0x1B3, */
        [Description("uint64, uint32, uint32 (0...2)")]
        SMSG_TRAINER_BUY_FAILED                         = UNKNOWN_OPCODE, /* old 0x1B4, */
        CMSG_BINDER_ACTIVATE                            = UNKNOWN_OPCODE, /* old 0x1B5, */
        [Description("ERR_DEATHBINDALREADYBOUND")]
        SMSG_PLAYERBINDERROR                            = UNKNOWN_OPCODE, /* old 0x1B6, */
        CMSG_BANKER_ACTIVATE                            = UNKNOWN_OPCODE, /* old 0x1B7, */
        [Description("uint64 guid. EVENT_BANKFRAME_OPENED, EVENT_BANKFRAME_CLOSED")]
        SMSG_SHOW_BANK                                  = UNKNOWN_OPCODE, /* old 0x1B8, */
        CMSG_BUY_BANK_SLOT                              = UNKNOWN_OPCODE, /* old 0x1B9, */
        SMSG_BUY_BANK_SLOT_RESULT                       = UNKNOWN_OPCODE, /* old 0x1BA, */
        CMSG_PETITION_SHOWLIST                          = UNKNOWN_OPCODE, /* old 0x1BB, */
        SMSG_PETITION_SHOWLIST                          = UNKNOWN_OPCODE, /* old 0x1BC, */
        CMSG_PETITION_BUY                               = UNKNOWN_OPCODE, /* old 0x1BD, */
        CMSG_PETITION_SHOW_SIGNATURES                   = UNKNOWN_OPCODE, /* old 0x1BE, */
        SMSG_PETITION_SHOW_SIGNATURES                   = UNKNOWN_OPCODE, /* old 0x1BF, */
        CMSG_PETITION_SIGN                              = UNKNOWN_OPCODE, /* old 0x1C0, */
        SMSG_PETITION_SIGN_RESULTS                      = UNKNOWN_OPCODE, /* old 0x1C1, */
        MSG_PETITION_DECLINE                            = UNKNOWN_OPCODE, /* old 0x1C2, */
        CMSG_OFFER_PETITION                             = UNKNOWN_OPCODE, /* old 0x1C3, */
        CMSG_TURN_IN_PETITION                           = UNKNOWN_OPCODE, /* old 0x1C4, */
        SMSG_TURN_IN_PETITION_RESULTS                   = UNKNOWN_OPCODE, /* old 0x1C5, */
        CMSG_PETITION_QUERY                             = UNKNOWN_OPCODE, /* old 0x1C6, */
        SMSG_PETITION_QUERY_RESPONSE                    = UNKNOWN_OPCODE, /* old 0x1C7, */
        SMSG_FISH_NOT_HOOKED                            = UNKNOWN_OPCODE, /* old 0x1C8, */
        SMSG_FISH_ESCAPED                               = UNKNOWN_OPCODE, /* old 0x1C9, */
        CMSG_BUG                                        = UNKNOWN_OPCODE, /* old 0x1CA, */
        SMSG_NOTIFICATION                               = UNKNOWN_OPCODE, /* old 0x1CB, */
        CMSG_PLAYED_TIME                                = UNKNOWN_OPCODE, /* old 0x1CC, */
        SMSG_PLAYED_TIME                                = UNKNOWN_OPCODE, /* old 0x1CD, */
        CMSG_QUERY_TIME                                 = UNKNOWN_OPCODE, /* old 0x1CE, */
        SMSG_QUERY_TIME_RESPONSE                        = UNKNOWN_OPCODE, /* old 0x1CF, */
        SMSG_LOG_XPGAIN                                 = UNKNOWN_OPCODE, /* old 0x1D0, */
        SMSG_AURACASTLOG                                = UNKNOWN_OPCODE, /* old 0x1D1, */
        CMSG_RECLAIM_CORPSE                             = UNKNOWN_OPCODE, /* old 0x1D2, */
        CMSG_WRAP_ITEM                                  = UNKNOWN_OPCODE, /* old 0x1D3, */
        SMSG_LEVELUP_INFO                               = UNKNOWN_OPCODE, /* old 0x1D4, */
        MSG_MINIMAP_PING                                = UNKNOWN_OPCODE, /* old 0x1D5, */
        SMSG_RESISTLOG                                  = UNKNOWN_OPCODE, /* old 0x1D6, */  
        SMSG_ENCHANTMENTLOG                             = UNKNOWN_OPCODE, /* old 0x1D7, */
        CMSG_SET_SKILL_CHEAT                            = UNKNOWN_OPCODE, /* old 0x1D8, */
        SMSG_START_MIRROR_TIMER                         = UNKNOWN_OPCODE, /* old 0x1D9, */
        SMSG_PAUSE_MIRROR_TIMER                         = UNKNOWN_OPCODE, /* old 0x1DA, */
        SMSG_STOP_MIRROR_TIMER                          = UNKNOWN_OPCODE, /* old 0x1DB, */
        [Description("Sent periodically. uint32 latency, uint32 sequence")]
        CMSG_PING                                       = UNKNOWN_OPCODE, /* old 0x1DC, */
        [Description("Response to CMSG_PING. Auth opcode. uint32 sequence")]
        SMSG_PONG                                       = UNKNOWN_OPCODE, /* old 0x1DD, */
        SMSG_CLEAR_COOLDOWN                             = UNKNOWN_OPCODE, /* old 0x1DE, */
        SMSG_GAMEOBJECT_PAGETEXT                        = UNKNOWN_OPCODE, /* old 0x1DF, */
        CMSG_SETSHEATHED                                = UNKNOWN_OPCODE, /* old 0x1E0, */
        SMSG_COOLDOWN_CHEAT                             = UNKNOWN_OPCODE, /* old 0x1E1, */
        SMSG_SPELL_DELAYED                              = UNKNOWN_OPCODE, /* old 0x1E2, */
        CMSG_QUEST_POI_QUERY                            = UNKNOWN_OPCODE, /* old 0x1E3, */
        CMSG_QUERY_QUEST_COMPLETION_NP_CS                          = UNKNOWN_OPCODE,
        SMSG_QUEST_POI_QUERY_RESPONSE                   = UNKNOWN_OPCODE, /* old 0x1E4, */
        CMSG_GHOST                                      = UNKNOWN_OPCODE, /* old 0x1E5, */
        CMSG_GM_INVIS                                   = UNKNOWN_OPCODE, /* old 0x1E6, */
        SMSG_INVALID_PROMOTION_CODE                     = UNKNOWN_OPCODE, /* old 0x1E7, */
        MSG_GM_BIND_OTHER                               = UNKNOWN_OPCODE, /* old 0x1E8, */
        MSG_GM_SUMMON                                   = UNKNOWN_OPCODE, /* old 0x1E9, */
        SMSG_ITEM_TIME_UPDATE                           = UNKNOWN_OPCODE, /* old 0x1EA, */
        SMSG_ITEM_ENCHANT_TIME_UPDATE                   = UNKNOWN_OPCODE, /* old 0x1EB, */
        [Description("Sent by server when a connection is initialized (after HELLO packet since 4.1.0). Contains 8-bit count, 32-bit seed, two 128 bit encryption seeds. Exact structure is version-dependent since Cataclysm. This packet is not encrypted.")]
        SMSG_AUTH_CHALLENGE                             = 297, /* old 0x1EC, */
        [Description("Client's reply to SMSG_AUTH_CHALLENGE on first connection. Contains client build value, account name, compressed addon data, etc. This packet is not encrypted.")]
        CMSG_AUTH_SESSION                               = UNKNOWN_OPCODE, /* old 0x1ED, */
        [Description("Server's reply to CMSG_AUTH_SESSION. Contains billing time, billing flags, account expansion, server expansion (since Cataclysm).")]
        SMSG_AUTH_RESPONSE                              = 3668, /* old 0x1EE, */
        MSG_GM_SHOWLABEL                                = UNKNOWN_OPCODE, /* old 0x1EF, */
        CMSG_PET_CAST_SPELL                             = UNKNOWN_OPCODE, /* old 0x1F0, */
        MSG_SAVE_GUILD_EMBLEM                           = UNKNOWN_OPCODE, /* old 0x1F1, */
        MSG_TABARDVENDOR_ACTIVATE                       = UNKNOWN_OPCODE, /* old 0x1F2, */
        SMSG_PLAY_SPELL_VISUAL                          = UNKNOWN_OPCODE, /* old 0x1F3, */
        CMSG_ZONEUPDATE                                 = UNKNOWN_OPCODE, /* old 0x1F4, */
        SMSG_PARTYKILLLOG                               = UNKNOWN_OPCODE, /* old 0x1F5, */
        SMSG_PLAY_SPELL_VISUAL_KIT                          = UNKNOWN_OPCODE, /* old 0x1F7, */
        SMSG_EXPLORATION_EXPERIENCE                     = UNKNOWN_OPCODE, /* old 0x1F8, */
        CMSG_GM_SET_SECURITY_GROUP                      = UNKNOWN_OPCODE, /* old 0x1F9, */
        CMSG_GM_NUKE                                    = UNKNOWN_OPCODE, /* old 0x1FA, */
        MSG_RANDOM_ROLL                                 = UNKNOWN_OPCODE, /* old 0x1FB, */
        SMSG_ENVIRONMENTALDAMAGELOG                     = UNKNOWN_OPCODE, /* old 0x1FC, */
        CMSG_CHANGEPLAYER_DIFFICULTY                    = UNKNOWN_OPCODE, /* old 0x1FD, */
        SMSG_RWHOIS                                     = UNKNOWN_OPCODE, /* old 0x1FE, */
        [Description("uint32, uint8, uint32, uint32, uint32, uint32, uint32, uint8, for(uint8) {uint32,uint32,uint32}")]
        SMSG_LFG_PLAYER_REWARD                          = UNKNOWN_OPCODE, /* old 0x1FF, */
        [Description("uint32 (1,2,4,6;0,5,7)")]
        SMSG_LFG_TELEPORT_DENIED                        = UNKNOWN_OPCODE, /* old 0x200, */
        CMSG_UNLEARN_SPELL                              = UNKNOWN_OPCODE, /* old 0x201, */
        CMSG_UNLEARN_SKILL                              = UNKNOWN_OPCODE, /* old 0x202, */
        SMSG_REMOVED_SPELL                              = UNKNOWN_OPCODE, /* old 0x203, */
        CMSG_DECHARGE                                   = UNKNOWN_OPCODE, /* old 0x204, */
        CMSG_GMTICKET_CREATE                            = UNKNOWN_OPCODE, /* old 0x205, */
        SMSG_GMTICKET_CREATE                            = UNKNOWN_OPCODE, /* old 0x206, */
        CMSG_GMTICKET_UPDATETEXT                        = UNKNOWN_OPCODE, /* old 0x207, */
        SMSG_GMTICKET_UPDATETEXT                        = UNKNOWN_OPCODE, /* old 0x208, */
        SMSG_ACCOUNT_DATA_TIMES                         = UNKNOWN_OPCODE, /* old 0x209, */
        CMSG_REQUEST_ACCOUNT_DATA                       = UNKNOWN_OPCODE, /* old 0x20A, */
        CMSG_UPDATE_ACCOUNT_DATA                        = UNKNOWN_OPCODE, /* old 0x20B, */
        SMSG_UPDATE_ACCOUNT_DATA                        = UNKNOWN_OPCODE, /* old 0x20C, */
        [Description("Sends CMSG_FAR_SIGHT")]
        SMSG_CLEAR_FAR_SIGHT_IMMEDIATE                  = UNKNOWN_OPCODE, /* old 0x20D, */
        SMSG_CHANGEPLAYER_DIFFICULTY_RESULT             = UNKNOWN_OPCODE, /* old 0x20E, */
        CMSG_GM_TEACH                                   = UNKNOWN_OPCODE, /* old 0x20F, */
        CMSG_GM_CREATE_ITEM_TARGET                      = UNKNOWN_OPCODE, /* old 0x210, */
        CMSG_GMTICKET_GETTICKET                         = UNKNOWN_OPCODE, /* old 0x211, */
        SMSG_GMTICKET_GETTICKET                         = UNKNOWN_OPCODE, /* old 0x212, */
        CMSG_UNLEARN_TALENTS                            = UNKNOWN_OPCODE, /* old 0x213, */
        SMSG_INSTANCE_ENCOUNTER                         = UNKNOWN_OPCODE, /* old 0x214, */
        SMSG_GAMEOBJECT_DESPAWN_ANIM                    = UNKNOWN_OPCODE, /* old 0x215, */
        MSG_CORPSE_QUERY                                = UNKNOWN_OPCODE, /* old 0x216, */
        CMSG_GMTICKET_DELETETICKET                      = UNKNOWN_OPCODE, /* old 0x217, */
        SMSG_GMTICKET_DELETETICKET                      = UNKNOWN_OPCODE, /* old 0x218, */
        [Description("ERR_CHAT_WRONG_FACTION, empty")]
        SMSG_CHAT_WRONG_FACTION                         = UNKNOWN_OPCODE, /* old 0x219, */
        CMSG_GMTICKET_SYSTEMSTATUS                      = UNKNOWN_OPCODE, /* old 0x21A, */
        [Description("uint32 status. EVENT_UPDATE_GM_STATUS")]
        SMSG_GMTICKET_SYSTEMSTATUS                      = UNKNOWN_OPCODE, /* old 0x21B, */
        CMSG_SPIRIT_HEALER_ACTIVATE                     = UNKNOWN_OPCODE, /* old 0x21C, */
        CMSG_SET_STAT_CHEAT                             = UNKNOWN_OPCODE, /* old 0x21D, */
        [Description("uint32 questid")]
        SMSG_QUEST_FORCE_REMOVED                        = UNKNOWN_OPCODE, /* old 0x21E, */
        CMSG_SKILL_BUY_STEP                             = UNKNOWN_OPCODE, /* old 0x21F, */
        CMSG_SKILL_BUY_RANK                             = UNKNOWN_OPCODE, /* old 0x220, */
        CMSG_XP_CHEAT                                   = UNKNOWN_OPCODE, /* old 0x221, */
        SMSG_SPIRIT_HEALER_CONFIRM                      = UNKNOWN_OPCODE, /* old 0x222, */
        CMSG_CHARACTER_POINT_CHEAT                      = UNKNOWN_OPCODE, /* old 0x223, */
        SMSG_GOSSIP_POI                                 = UNKNOWN_OPCODE, /* old 0x224, */
        CMSG_CHAT_IGNORED                               = UNKNOWN_OPCODE, /* old 0x225, */
        CMSG_GM_VISION                                  = UNKNOWN_OPCODE, /* old 0x226, */
        CMSG_SERVER_COMMAND                             = UNKNOWN_OPCODE, /* old 0x227, */
        CMSG_GM_SILENCE                                 = UNKNOWN_OPCODE, /* old 0x228, */
        CMSG_GM_REVEALTO                                = UNKNOWN_OPCODE, /* old 0x229, */
        CMSG_GM_RESURRECT                               = UNKNOWN_OPCODE, /* old 0x22A, */
        CMSG_GM_SUMMONMOB                               = UNKNOWN_OPCODE, /* old 0x22B, */
        CMSG_GM_MOVECORPSE                              = UNKNOWN_OPCODE, /* old 0x22C, */
        CMSG_GM_FREEZE                                  = UNKNOWN_OPCODE, /* old 0x22D, */
        CMSG_GM_UBERINVIS                               = UNKNOWN_OPCODE, /* old 0x22E, */
        CMSG_GM_REQUEST_PLAYER_INFO                     = UNKNOWN_OPCODE, /* old 0x22F, */
        SMSG_GM_PLAYER_INFO                             = UNKNOWN_OPCODE, /* old 0x230, */
        CMSG_GUILD_SET_RANK_PERMISSIONS                 = UNKNOWN_OPCODE, /* old 0x231, */
        CMSG_GUILD_ADD_RANK                             = UNKNOWN_OPCODE, /* old 0x232, */
        CMSG_GUILD_DELETE_RANK                          = UNKNOWN_OPCODE, /* old 0x233, */
        CMSG_GUILD_SET_MEMBER_NOTE                      = UNKNOWN_OPCODE, /* old 0x234, */
        CMSG_GUILD_SET_OFFICER_NOTE                     = UNKNOWN_OPCODE, /* old 0x235, */
        SMSG_LOGIN_VERIFY_WORLD                         = UNKNOWN_OPCODE, /* old 0x236, */
        CMSG_CLEAR_EXPLORATION                          = UNKNOWN_OPCODE, /* old 0x237, */
        CMSG_SEND_MAIL                                  = UNKNOWN_OPCODE, /* old 0x238, */
        SMSG_SEND_MAIL_RESULT                           = UNKNOWN_OPCODE, /* old 0x239, */
        CMSG_GET_MAIL_LIST                              = UNKNOWN_OPCODE, /* old 0x23A, */
        SMSG_MAIL_LIST_RESULT                           = UNKNOWN_OPCODE, /* old 0x23B, */
        CMSG_BATTLEFIELD_LIST                           = UNKNOWN_OPCODE, /* old 0x23C, */
        SMSG_BATTLEFIELD_LIST                           = UNKNOWN_OPCODE, /* old 0x23D, */
        CMSG_BATTLEFIELD_JOIN                           = UNKNOWN_OPCODE, /* old 0x23E, */
        CMSG_TAXICLEARNODE                              = UNKNOWN_OPCODE, /* old 0x241, */
        CMSG_TAXIENABLENODE                             = UNKNOWN_OPCODE, /* old 0x242, */
        CMSG_ITEM_TEXT_QUERY                            = UNKNOWN_OPCODE, /* old 0x243, */
        SMSG_ITEM_TEXT_QUERY_RESPONSE                   = UNKNOWN_OPCODE, /* old 0x244, */
        CMSG_MAIL_TAKE_MONEY                            = UNKNOWN_OPCODE, /* old 0x245, */
        CMSG_MAIL_TAKE_ITEM                             = UNKNOWN_OPCODE, /* old 0x246, */
        CMSG_MAIL_MARK_AS_READ                          = UNKNOWN_OPCODE, /* old 0x247, */
        CMSG_MAIL_RETURN_TO_SENDER                      = UNKNOWN_OPCODE, /* old 0x248, */
        CMSG_MAIL_DELETE                                = UNKNOWN_OPCODE, /* old 0x249, */
        CMSG_MAIL_CREATE_TEXT_ITEM                      = UNKNOWN_OPCODE, /* old 0x24A, */
        SMSG_SPELLLOGMISS                               = UNKNOWN_OPCODE, /* old 0x24B, */
        SMSG_SPELLLOGEXECUTE                            = UNKNOWN_OPCODE, /* old 0x24C, */
        SMSG_DEBUGAURAPROC                              = UNKNOWN_OPCODE, /* old 0x24D, */
        SMSG_PERIODICAURALOG                            = UNKNOWN_OPCODE, /* old 0x24E, */
        SMSG_SPELLDAMAGESHIELD                          = UNKNOWN_OPCODE, /* old 0x24F, */
        SMSG_SPELLNONMELEEDAMAGELOG                     = UNKNOWN_OPCODE, /* old 0x250, */
        CMSG_LEARN_TALENT                               = UNKNOWN_OPCODE, /* old 0x251, */
        SMSG_RESURRECT_FAILED                           = UNKNOWN_OPCODE, /* old 0x252, */
        CMSG_TOGGLE_PVP                                 = UNKNOWN_OPCODE, /* old 0x253, */
        SMSG_ZONE_UNDER_ATTACK                          = UNKNOWN_OPCODE, /* old 0x254, */
        MSG_AUCTION_HELLO                               = UNKNOWN_OPCODE, /* old 0x255, */
        CMSG_AUCTION_SELL_ITEM                          = UNKNOWN_OPCODE, /* old 0x256, */
        CMSG_AUCTION_REMOVE_ITEM                        = UNKNOWN_OPCODE, /* old 0x257, */
        CMSG_AUCTION_LIST_ITEMS                         = UNKNOWN_OPCODE, /* old 0x258, */
        CMSG_AUCTION_LIST_OWNER_ITEMS                   = UNKNOWN_OPCODE, /* old 0x259, */
        CMSG_AUCTION_PLACE_BID                          = UNKNOWN_OPCODE, /* old 0x25A, */
        SMSG_AUCTION_COMMAND_RESULT                     = UNKNOWN_OPCODE, /* old 0x25B, */
        SMSG_AUCTION_OWNER_LIST_RESULT                  = UNKNOWN_OPCODE, /* old 0x25D, */
        SMSG_AUCTION_BIDDER_NOTIFICATION                = UNKNOWN_OPCODE, /* old 0x25E, */
        SMSG_AUCTION_OWNER_NOTIFICATION                 = UNKNOWN_OPCODE, /* old 0x25F, */
        SMSG_PROCRESIST                                 = UNKNOWN_OPCODE, /* old 0x260, */
        SMSG_COMBAT_EVENT_FAILED                        = UNKNOWN_OPCODE, /* old 0x261, */
        SMSG_DISPEL_FAILED                              = UNKNOWN_OPCODE, /* old 0x262, */
        SMSG_SPELLORDAMAGE_IMMUNE                       = UNKNOWN_OPCODE, /* old 0x263, */
        CMSG_AUCTION_LIST_BIDDER_ITEMS                  = UNKNOWN_OPCODE, /* old 0x264, */
        SMSG_AUCTION_BIDDER_LIST_RESULT                 = UNKNOWN_OPCODE, /* old 0x265, */
        SMSG_SET_FLAT_SPELL_MODIFIER                    = UNKNOWN_OPCODE, /* old 0x266, */
        SMSG_SET_PCT_SPELL_MODIFIER                     = UNKNOWN_OPCODE, /* old 0x267, */
        CMSG_SET_AMMO                                   = UNKNOWN_OPCODE, /* old 0x268, */
        [Description("uint32 delay_ms")]
        SMSG_CORPSE_RECLAIM_DELAY                       = UNKNOWN_OPCODE, /* old 0x269, */
        CMSG_SET_ACTIVE_MOVER                           = UNKNOWN_OPCODE, /* old 0x26A, */
        CMSG_PET_CANCEL_AURA                            = UNKNOWN_OPCODE, /* old 0x26B, */
        CMSG_PLAYER_AI_CHEAT                            = UNKNOWN_OPCODE, /* old 0x26C, */
        CMSG_CANCEL_AUTO_REPEAT_SPELL                   = UNKNOWN_OPCODE, /* old 0x26D, */
        MSG_GM_ACCOUNT_ONLINE                           = UNKNOWN_OPCODE, /* old 0x26E, */
        MSG_LIST_STABLED_PETS                           = UNKNOWN_OPCODE, /* old 0x26F, */
        CMSG_STABLE_PET                                 = UNKNOWN_OPCODE, /* old 0x270, */
        CMSG_UNSTABLE_PET                               = UNKNOWN_OPCODE, /* old 0x271, */
        CMSG_BUY_STABLE_SLOT                            = UNKNOWN_OPCODE, /* old 0x272, */
        SMSG_STABLE_RESULT                              = UNKNOWN_OPCODE, /* old 0x273, */
        CMSG_STABLE_REVIVE_PET                          = UNKNOWN_OPCODE, /* old 0x274, */
        CMSG_STABLE_SWAP_PET                            = UNKNOWN_OPCODE, /* old 0x275, */
        MSG_QUEST_PUSH_RESULT                           = UNKNOWN_OPCODE, /* old 0x276, */
        [Description("uint32 sound_id")]
        SMSG_PLAY_MUSIC                                 = UNKNOWN_OPCODE, /* old 0x277, */
        SMSG_PLAY_OBJECT_SOUND                          = UNKNOWN_OPCODE, /* old 0x278, */
        CMSG_REQUEST_PET_INFO                           = UNKNOWN_OPCODE, /* old 0x279, */
        CMSG_FAR_SIGHT                                  = UNKNOWN_OPCODE, /* old 0x27A, */
        SMSG_SPELLDISPELLOG                             = UNKNOWN_OPCODE, /* old 0x27B, */
        SMSG_DAMAGE_CALC_LOG                            = UNKNOWN_OPCODE, /* old 0x27C, */
        CMSG_ENABLE_DAMAGE_LOG                          = UNKNOWN_OPCODE, /* old 0x27D, */
        CMSG_GROUP_CHANGE_SUB_GROUP                     = UNKNOWN_OPCODE, /* old 0x27E, */
        CMSG_REQUEST_PARTY_MEMBER_STATS                 = UNKNOWN_OPCODE, /* old 0x27F, */
        CMSG_GROUP_SWAP_SUB_GROUP                       = UNKNOWN_OPCODE, /* old 0x280, */
        CMSG_RESET_FACTION_CHEAT                        = UNKNOWN_OPCODE, /* old 0x281, */
        CMSG_AUTOSTORE_BANK_ITEM                        = UNKNOWN_OPCODE, /* old 0x282, */
        CMSG_AUTOBANK_ITEM                              = UNKNOWN_OPCODE, /* old 0x283, */
        MSG_QUERY_NEXT_MAIL_TIME                        = UNKNOWN_OPCODE, /* old 0x284, */
        SMSG_RECEIVED_MAIL                              = UNKNOWN_OPCODE, /* old 0x285, */
        SMSG_RAID_GROUP_ONLY                            = UNKNOWN_OPCODE, /* old 0x286, */
        CMSG_SET_DURABILITY_CHEAT                       = UNKNOWN_OPCODE, /* old 0x287, */
        CMSG_SET_PVP_RANK_CHEAT                         = UNKNOWN_OPCODE, /* old 0x288, */
        CMSG_ADD_PVP_MEDAL_CHEAT                        = UNKNOWN_OPCODE, /* old 0x289, */
        CMSG_DEL_PVP_MEDAL_CHEAT                        = UNKNOWN_OPCODE, /* old 0x28A, */
        CMSG_SET_PVP_TITLE                              = UNKNOWN_OPCODE, /* old 0x28B, */
        SMSG_PVP_CREDIT                                 = UNKNOWN_OPCODE, /* old 0x28C, */
        SMSG_AUCTION_REMOVED_NOTIFICATION               = UNKNOWN_OPCODE, /* old 0x28D, */
        CMSG_GROUP_RAID_CONVERT                         = UNKNOWN_OPCODE, /* old 0x28E, */
        CMSG_GROUP_ASSISTANT_LEADER                     = UNKNOWN_OPCODE, /* old 0x28F, */
        CMSG_BUYBACK_ITEM                               = UNKNOWN_OPCODE, /* old 0x290, */
        SMSG_SERVER_MESSAGE                             = UNKNOWN_OPCODE, /* old 0x291, */
        CMSG_SET_SAVED_INSTANCE_EXTEND                  = UNKNOWN_OPCODE, /* old 0x292, */ // lua: SetSavedInstanceExtend
        SMSG_LFG_OFFER_CONTINUE                         = UNKNOWN_OPCODE, /* old 0x293, */
        CMSG_TEST_DROP_RATE                             = UNKNOWN_OPCODE, /* old 0x294, */ // not found 3.3
        SMSG_TEST_DROP_RATE_RESULT                      = UNKNOWN_OPCODE, /* old 0x295, */ // string, showed in console
        CMSG_LFG_GET_STATUS                             = UNKNOWN_OPCODE, /* old 0x296, */ // EVENT_LFG_UPDATE
        SMSG_SHOW_MAILBOX                               = UNKNOWN_OPCODE, /* old 0x297, */ // mail open from gossip?, EVENT_MAIL_SHOW
        SMSG_RESET_RANGED_COMBAT_TIMER                  = UNKNOWN_OPCODE, /* old 0x298, */ // uint32, some UPDATE_COOLDOWN events
        SMSG_CHAT_NOT_IN_PARTY                          = UNKNOWN_OPCODE, /* old 0x299, */ // uint32, errors: ERR_NOT_IN_GROUP (2,51) and ERR_NOT_IN_RAID (3,39,40)
        CMSG_GMTICKETSYSTEM_TOGGLE                      = UNKNOWN_OPCODE, /* old 0x29A, */
        CMSG_CANCEL_GROWTH_AURA                         = UNKNOWN_OPCODE, /* old 0x29B, */
        SMSG_CANCEL_AUTO_REPEAT                         = UNKNOWN_OPCODE, /* old 0x29C, */
        SMSG_STANDSTATE_UPDATE                          = UNKNOWN_OPCODE, /* old 0x29D, */
        SMSG_LOOT_ALL_PASSED                            = UNKNOWN_OPCODE, /* old 0x29E, */
        SMSG_LOOT_ROLL_WON                              = UNKNOWN_OPCODE, /* old 0x29F, */
        CMSG_LOOT_ROLL                                  = UNKNOWN_OPCODE, /* old 0x2A0, */
        SMSG_LOOT_START_ROLL                            = UNKNOWN_OPCODE, /* old 0x2A1, */
        SMSG_LOOT_ROLL                                  = UNKNOWN_OPCODE, /* old 0x2A2, */
        CMSG_LOOT_MASTER_GIVE                           = UNKNOWN_OPCODE, /* old 0x2A3, */
        SMSG_LOOT_MASTER_LIST                           = UNKNOWN_OPCODE, /* old 0x2A4, */
        SMSG_SET_FORCED_REACTIONS                       = UNKNOWN_OPCODE, /* old 0x2A5, */
        SMSG_SPELL_FAILED_OTHER                         = UNKNOWN_OPCODE, /* old 0x2A6, */
        SMSG_GAMEOBJECT_RESET_STATE                     = UNKNOWN_OPCODE, /* old 0x2A7, */
        CMSG_REPAIR_ITEM                                = UNKNOWN_OPCODE, /* old 0x2A8, */
        SMSG_CHAT_PLAYER_NOT_FOUND                      = UNKNOWN_OPCODE, /* old 0x2A9, */
        MSG_TALENT_WIPE_CONFIRM                         = UNKNOWN_OPCODE, /* old 0x2AA, */
        SMSG_SUMMON_REQUEST                             = UNKNOWN_OPCODE, /* old 0x2AB, */
        CMSG_SUMMON_RESPONSE                            = UNKNOWN_OPCODE, /* old 0x2AC, */
        MSG_DEV_SHOWLABEL                               = UNKNOWN_OPCODE, /* old 0x2AD, */
        SMSG_MONSTER_MOVE_TRANSPORT                     = UNKNOWN_OPCODE, /* old 0x2AE, */
        SMSG_PET_BROKEN                                 = UNKNOWN_OPCODE, /* old 0x2AF, */
        CMSG_SERVER_BROADCAST                           = UNKNOWN_OPCODE, /* old 0x2B2, */
        CMSG_SELF_RES                                   = UNKNOWN_OPCODE, /* old 0x2B3, */
        SMSG_FEIGN_DEATH_RESISTED                       = UNKNOWN_OPCODE, /* old 0x2B4, */
        CMSG_RUN_SCRIPT                                 = UNKNOWN_OPCODE, /* old 0x2B5, */
        SMSG_SCRIPT_MESSAGE                             = UNKNOWN_OPCODE, /* old 0x2B6, */
        SMSG_DUEL_COUNTDOWN                             = UNKNOWN_OPCODE, /* old 0x2B7, */
        [Description("EVENT_UI_INFO_MESSAGE")]
        SMSG_AREA_TRIGGER_MESSAGE                       = UNKNOWN_OPCODE, /* old 0x2B8, */
        CMSG_SHOWING_HELM                               = UNKNOWN_OPCODE, /* old 0x2B9, */
        CMSG_SHOWING_CLOAK                              = UNKNOWN_OPCODE, /* old 0x2BA, */
        SMSG_ROLE_CHOSEN                                = UNKNOWN_OPCODE, /* old 0x2BB, */
        SMSG_PLAYER_SKINNED                             = UNKNOWN_OPCODE, /* old 0x2BC, */
        SMSG_DURABILITY_DAMAGE_DEATH                    = UNKNOWN_OPCODE, /* old 0x2BD, */
        CMSG_SET_EXPLORATION                            = UNKNOWN_OPCODE, /* old 0x2BE, */
        CMSG_SET_ACTIONBAR_TOGGLES                      = UNKNOWN_OPCODE, /* old 0x2BF, */
        UMSG_DELETE_GUILD_CHARTER                       = UNKNOWN_OPCODE, /* old 0x2C0, */
        MSG_PETITION_RENAME                             = UNKNOWN_OPCODE, /* old 0x2C1, */
        SMSG_INIT_WORLD_STATES                          = UNKNOWN_OPCODE, /* old 0x2C2, */
        [Description("uint32 key, uint32 value, uint8 unk_bool_410")]
        SMSG_UPDATE_WORLD_STATE                         = UNKNOWN_OPCODE, /* old 0x2C3, */
        CMSG_ITEM_NAME_QUERY                            = UNKNOWN_OPCODE, /* old 0x2C4, */
        SMSG_ITEM_NAME_QUERY_RESPONSE                   = UNKNOWN_OPCODE, /* old 0x2C5, */
        SMSG_PET_ACTION_FEEDBACK                        = UNKNOWN_OPCODE, /* old 0x2C6, */
        CMSG_CHAR_RENAME                                = UNKNOWN_OPCODE, /* old 0x2C7, */
        SMSG_CHAR_RENAME                                = UNKNOWN_OPCODE, /* old 0x2C8, */
        CMSG_MOVE_SPLINE_DONE                           = UNKNOWN_OPCODE, /* old 0x2C9, */
        CMSG_MOVE_FALL_RESET                            = UNKNOWN_OPCODE, /* old 0x2CA, */
        SMSG_INSTANCE_SAVE_CREATED                      = UNKNOWN_OPCODE, /* old 0x2CB, */
        [Description("EVENT_UPDATE_INSTANCE_INFO")]
        SMSG_RAID_INSTANCE_INFO                         = UNKNOWN_OPCODE, /* old 0x2CC, */
        CMSG_REQUEST_RAID_INFO                          = UNKNOWN_OPCODE, /* old 0x2CD, */
        CMSG_MOVE_NOT_ACTIVE_MOVER                      = UNKNOWN_OPCODE, /* old 0x2D1, */
        SMSG_PLAY_SOUND                                 = UNKNOWN_OPCODE, /* old 0x2D2, */
        CMSG_QUERY_BATTLEFIELD_STATE                    = UNKNOWN_OPCODE, /* old 0x2D3, */
        SMSG_BATTLEFIELD_STATUS_NONE                    = UNKNOWN_OPCODE, /* old 0x2D4, */
        CMSG_BATTLEFIELD_PORT                           = UNKNOWN_OPCODE, /* old 0x2D5, */
        CMSG_BATTLEMASTER_HELLO                         = UNKNOWN_OPCODE, /* old 0x2D7, */
        SMSG_PVP_LOG_DATA                               = UNKNOWN_OPCODE, /* old 0x2E0, */
        CMSG_PVP_LOG_DATA                               = UNKNOWN_OPCODE,
        CMSG_LEAVE_BATTLEFIELD                          = UNKNOWN_OPCODE, /* old 0x2E1, */
        CMSG_AREA_SPIRIT_HEALER_QUERY                   = UNKNOWN_OPCODE, /* old 0x2E2, */
        CMSG_AREA_SPIRIT_HEALER_QUEUE                   = UNKNOWN_OPCODE, /* old 0x2E3, */
        [Description("EVENT_AREA_SPIRIT_HEALER_IN_RANGE")]
        SMSG_AREA_SPIRIT_HEALER_TIME                    = UNKNOWN_OPCODE, /* old 0x2E4, */
        CMSG_GM_UNTEACH                                 = UNKNOWN_OPCODE, /* old 0x2E5, */
        SMSG_WARDEN_DATA                                = UNKNOWN_OPCODE, /* old 0x2E6, */
        CMSG_WARDEN_DATA                                = UNKNOWN_OPCODE, /* old 0x2E7, */
        SMSG_BATTLEFIELD_STATUS_QUEUED                  = UNKNOWN_OPCODE, /* old 0x2E8, */
        CMSG_REQUEST_BATTLEFIELD_PLAYER_POSITIONS       = UNKNOWN_OPCODE,
        SMSG_BATTLEGROUND_PLAYER_POSITIONS              = UNKNOWN_OPCODE,
        CMSG_PET_STOP_ATTACK                            = UNKNOWN_OPCODE, /* old 0x2EA, */
        SMSG_BINDER_CONFIRM                             = UNKNOWN_OPCODE, /* old 0x2EB, */
        SMSG_BATTLEGROUND_PLAYER_JOINED                 = UNKNOWN_OPCODE, /* old 0x2EC, */
        SMSG_BATTLEGROUND_PLAYER_LEFT                   = UNKNOWN_OPCODE, /* old 0x2ED, */
        CMSG_BATTLEMASTER_JOIN                          = UNKNOWN_OPCODE, /* old 0x2EE, */
        [Description("Sent after SMSG_ITEM_UPDATED_MULTIPLE")]
        SMSG_ADDON_INFO                                 = UNKNOWN_OPCODE, /* old 0x2EF, */
        CMSG_PET_UNLEARN                                = UNKNOWN_OPCODE, /* old 0x2F0, */
        SMSG_PET_UNLEARN_CONFIRM                        = UNKNOWN_OPCODE, /* old 0x2F1, */
        SMSG_PARTY_MEMBER_STATS_FULL                    = UNKNOWN_OPCODE, /* old 0x2F2, */
        CMSG_PET_SPELL_AUTOCAST                         = UNKNOWN_OPCODE, /* old 0x2F3, */
        SMSG_WEATHER                                    = UNKNOWN_OPCODE, /* old 0x2F4, */
        SMSG_PLAY_TIME_WARNING                          = UNKNOWN_OPCODE, /* old 0x2F5, */
        SMSG_MINIGAME_SETUP                             = UNKNOWN_OPCODE, /* old 0x2F6, */
        SMSG_MINIGAME_STATE                             = UNKNOWN_OPCODE, /* old 0x2F7, */
        CMSG_MINIGAME_MOVE                              = UNKNOWN_OPCODE, /* old 0x2F8, */
        SMSG_MINIGAME_MOVE_FAILED                       = UNKNOWN_OPCODE, /* old 0x2F9, */
        SMSG_RAID_INSTANCE_MESSAGE                      = UNKNOWN_OPCODE, /* old 0x2FA, */
        CMSG_GUILD_UPDATE_INFO_TEXT                            = UNKNOWN_OPCODE, /* old 0x2FC, */
        SMSG_CHAT_RESTRICTED                            = UNKNOWN_OPCODE, /* old 0x2FD, */
        CMSG_GM_NUKE_ACCOUNT                            = UNKNOWN_OPCODE, /* old 0x30F, */
        MSG_GM_DESTROY_CORPSE                           = UNKNOWN_OPCODE, /* old 0x310, */
        CMSG_GM_DESTROY_ONLINE_CORPSE                   = UNKNOWN_OPCODE, /* old 0x311, */
        CMSG_ACTIVATETAXIEXPRESS                        = UNKNOWN_OPCODE, /* old 0x312, */
        SMSG_SET_FACTION_ATWAR                          = UNKNOWN_OPCODE, /* old 0x313, */
        SMSG_GAMETIMEBIAS_SET                           = UNKNOWN_OPCODE, /* old 0x314, */
        CMSG_DEBUG_ACTIONS_START                        = UNKNOWN_OPCODE, /* old 0x315, */
        CMSG_DEBUG_ACTIONS_STOP                         = UNKNOWN_OPCODE, /* old 0x316, */
        CMSG_SET_FACTION_INACTIVE                       = UNKNOWN_OPCODE, /* old 0x317, */
        CMSG_SET_WATCHED_FACTION                        = UNKNOWN_OPCODE, /* old 0x318, */
        CMSG_SET_EXPLORATION_ALL                        = UNKNOWN_OPCODE, /* old 0x31B, */
        SMSG_INVALIDATE_PLAYER                          = UNKNOWN_OPCODE, /* old 0x31C, */
        CMSG_RESET_INSTANCES                            = UNKNOWN_OPCODE, /* old 0x31D, */
        SMSG_INSTANCE_RESET                             = UNKNOWN_OPCODE, /* old 0x31E, */
        SMSG_INSTANCE_RESET_FAILED                      = UNKNOWN_OPCODE, /* old 0x31F, */
        SMSG_UPDATE_LAST_INSTANCE                       = UNKNOWN_OPCODE, /* old 0x320, */
        MSG_RAID_TARGET_UPDATE                          = UNKNOWN_OPCODE, /* old 0x321, */
        MSG_RAID_READY_CHECK                            = UNKNOWN_OPCODE, /* old 0x322, */
        CMSG_LUA_USAGE                                  = UNKNOWN_OPCODE, /* old 0x323, */
        SMSG_PET_ACTION_SOUND                           = UNKNOWN_OPCODE, /* old 0x324, */
        SMSG_PET_DISMISS_SOUND                          = UNKNOWN_OPCODE, /* old 0x325, */
        SMSG_GHOSTEE_GONE                               = UNKNOWN_OPCODE, /* old 0x326, */
        CMSG_GM_UPDATE_TICKET_STATUS                    = UNKNOWN_OPCODE, /* old 0x327, */
        SMSG_GM_TICKET_STATUS_UPDATE                    = UNKNOWN_OPCODE, /* old 0x328, */
        MSG_SET_DUNGEON_DIFFICULTY                      = UNKNOWN_OPCODE, /* old 0x329, */
        CMSG_GMSURVEY_SUBMIT                            = UNKNOWN_OPCODE, /* old 0x32A, */
        SMSG_UPDATE_INSTANCE_OWNERSHIP                  = UNKNOWN_OPCODE, /* old 0x32B, */
        SMSG_CHAT_PLAYER_AMBIGUOUS                      = UNKNOWN_OPCODE, /* old 0x32D, */
        MSG_DELAY_GHOST_TELEPORT                        = UNKNOWN_OPCODE, /* old 0x32E, */
        SMSG_SPELLINSTAKILLLOG                          = UNKNOWN_OPCODE, /* old 0x32F, */
        SMSG_SPELL_UPDATE_CHAIN_TARGETS                 = UNKNOWN_OPCODE, /* old 0x330, */
        CMSG_CHAT_FILTERED                              = UNKNOWN_OPCODE, /* old 0x331, */
        SMSG_EXPECTED_SPAM_RECORDS                      = UNKNOWN_OPCODE, /* old 0x332, */
        SMSG_SPELLSTEALLOG                              = UNKNOWN_OPCODE, /* old 0x333, */
        CMSG_LOTTERY_QUERY_OBSOLETE                     = UNKNOWN_OPCODE, /* old 0x334, */
        SMSG_LOTTERY_QUERY_RESULT_OBSOLETE              = UNKNOWN_OPCODE, /* old 0x335, */
        CMSG_BUY_LOTTERY_TICKET_OBSOLETE                = UNKNOWN_OPCODE, /* old 0x336, */
        SMSG_LOTTERY_RESULT_OBSOLETE                    = UNKNOWN_OPCODE, /* old 0x337, */
        SMSG_CHARACTER_PROFILE                          = UNKNOWN_OPCODE, /* old 0x338, */
        SMSG_CHARACTER_PROFILE_REALM_CONNECTED          = UNKNOWN_OPCODE, /* old 0x339, */
        SMSG_DEFENSE_MESSAGE                            = UNKNOWN_OPCODE, /* old 0x33A, */
        SMSG_INSTANCE_DIFFICULTY                        = UNKNOWN_OPCODE, /* old 0x33B, */
        MSG_GM_RESETINSTANCELIMIT                       = UNKNOWN_OPCODE, /* old 0x33C, */
        SMSG_MOTD                                       = UNKNOWN_OPCODE, /* old 0x33D, */
        CMSG_SOCKET_GEMS                                = UNKNOWN_OPCODE, /* old 0x347, */
        CMSG_CREATE_ARENA_TEAM                          = UNKNOWN_OPCODE, /* old 0x348, */
        SMSG_ARENA_TEAM_COMMAND_RESULT                  = UNKNOWN_OPCODE, /* old 0x349, */
        CMSG_ARENA_TEAM_QUERY                           = UNKNOWN_OPCODE, /* old 0x34B, */
        SMSG_ARENA_TEAM_QUERY_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x34C, */
        CMSG_ARENA_TEAM_ROSTER                          = UNKNOWN_OPCODE, /* old 0x34D, */
        SMSG_ARENA_TEAM_ROSTER                          = UNKNOWN_OPCODE, /* old 0x34E, */
        CMSG_ARENA_TEAM_INVITE                          = UNKNOWN_OPCODE, /* old 0x34F, */
        SMSG_ARENA_TEAM_INVITE                          = UNKNOWN_OPCODE, /* old 0x350, */
        CMSG_ARENA_TEAM_ACCEPT                          = UNKNOWN_OPCODE, /* old 0x351, */
        CMSG_ARENA_TEAM_DECLINE                         = UNKNOWN_OPCODE, /* old 0x352, */
        CMSG_ARENA_TEAM_LEAVE                           = UNKNOWN_OPCODE, /* old 0x353, */
        CMSG_ARENA_TEAM_REMOVE                          = UNKNOWN_OPCODE, /* old 0x354, */
        CMSG_ARENA_TEAM_DISBAND                         = UNKNOWN_OPCODE, /* old 0x355, */
        CMSG_ARENA_TEAM_LEADER                          = UNKNOWN_OPCODE, /* old 0x356, */
        SMSG_ARENA_TEAM_EVENT                           = UNKNOWN_OPCODE, /* old 0x357, */
        CMSG_BATTLEMASTER_JOIN_ARENA                    = UNKNOWN_OPCODE, /* old 0x358, */
        SMSG_ARENA_TEAM_STATS                           = UNKNOWN_OPCODE, /* old 0x35B, */
        CMSG_LFG_JOIN                                   = UNKNOWN_OPCODE, /* old 0x35C, */    // CMSG JoinLFG
        CMSG_LFG_LEAVE                                  = UNKNOWN_OPCODE, /* old 0x35D, */    // CMSG LeaveLFG
        CMSG_LFG_SEARCH_JOIN                            = UNKNOWN_OPCODE, /* old 0x35E, */    // CMSG SearchLFGJoin
        CMSG_LFG_SEARCH_LEAVE                           = UNKNOWN_OPCODE, /* old 0x35F, */    // CMSG SearchLFGLeave
        SMSG_LFG_SEARCH_RESULTS                         = UNKNOWN_OPCODE, /* old 0x360, */    // SMSG uint32, uint32, if(uint8) { uint32 count, for(count) { uint64} }, uint32 count2, uint32, for(count2) { uint64, uint32 flags, if(flags & 0x2) {string}, if(flags & 0x10) {for(3) uint8}, if(flags & 0x80) {uint64, uint32}}, uint32 count3, uint32, for(count3) {uint64, uint32 flags, if(flags & 0x1) {uint8, uint8, uint8, for(3) uint8, uint32, uint32, uint32, uint32, uint32, uint32, float, float, uint32, uint32, uint32, uint32, uint32, float, uint32, uint32, uint32, uint32, uint32, uint32}, if(flags&0x2) string, if(flags&0x4) uint8, if(flags&0x8) uint64, if(flags&0x10) uint8, if(flags&0x20) uint32, if(flags&0x40) uint8, if(flags& 0x80) {uint64, uint32}}
        SMSG_LFG_PROPOSAL_UPDATE                        = UNKNOWN_OPCODE, /* old 0x361, */    // SMSG uint32, uint8, uint32, uint32, uint8, for(uint8) {uint32,uint8,uint8,uint8,uint8}
        CMSG_LFG_PROPOSAL_RESULT                        = UNKNOWN_OPCODE, /* old 0x362, */    // CMSG AcceptProposal, RejectProposal
        SMSG_LFG_ROLE_CHECK_UPDATE                      = UNKNOWN_OPCODE, /* old 0x363, */    // SMSG uint32, uint8, for(uint8) uint32, uint8, for(uint8) { uint64, uint8, uint32, uint8, }
        SMSG_LFG_JOIN_RESULT                            = UNKNOWN_OPCODE, /* old 0x364, */    // SMSG uint32 unk, uint32, if(unk==6) { uint8 count, for(count) uint64 }
        SMSG_LFG_QUEUE_STATUS                           = UNKNOWN_OPCODE, /* old 0x365, */    // SMSG uint32 dungeon, uint32 lfgtype, uint32, uint32, uint32, uint32, uint8, uint8, uint8, uint8
        CMSG_SET_LFG_COMMENT                            = UNKNOWN_OPCODE, /* old 0x366, */    // CMSG SetLFGComment
        SMSG_LFG_UPDATE_PLAYER                          = UNKNOWN_OPCODE, /* old 0x367, */    // SMSG uint8, if(uint8) { uint8, uint8, uint8, uint8, if(uint8) for(uint8) uint32, string}
        SMSG_LFG_UPDATE_PARTY                           = UNKNOWN_OPCODE, /* old 0x368, */    // SMSG uint8, if(uint8) { uint8, uint8, uint8, for(3) uint8, uint8, if(uint8) for(uint8) uint32, string}
        SMSG_LFG_UPDATE_SEARCH                          = UNKNOWN_OPCODE, /* old 0x369, */    // SMSG uint8
        CMSG_LFG_SET_ROLES                              = UNKNOWN_OPCODE, /* old 0x36A, */    // CMSG SetLFGRoles
        CMSG_LFG_SET_NEEDS                              = UNKNOWN_OPCODE, /* old 0x36B, */    // CMSG SetLFGNeeds
        CMSG_LFG_BOOT_PLAYER_VOTE                       = UNKNOWN_OPCODE, /* old 0x36C, */    // CMSG SetLFGBootVote
        SMSG_LFG_BOOT_PLAYER                            = UNKNOWN_OPCODE, /* old 0x36D, */    // SMSG uint8, uint8, uint8, uint64, uint32, uint32, uint32, uint32
        CMSG_LFG_GET_PLAYER_INFO                        = UNKNOWN_OPCODE, /* old 0x36E, */    // CMSG RequestLFDPlayerLockInfo
        SMSG_LFG_PLAYER_INFO                            = UNKNOWN_OPCODE, /* old 0x36F, */    // SMSG uint8, for(uint8) { uint32, uint8, uint32, uint32, uint32, uint32, uint8, for(uint8) {uint32,uint32, uint32}}, uint32, for(uint32) {uint32,uint32}
        CMSG_LFG_TELEPORT                               = UNKNOWN_OPCODE, /* old 0x370, */    // CMSG LFGTeleport
        CMSG_LFG_GET_PARTY_INFO                         = UNKNOWN_OPCODE, /* old 0x371, */    // CMSG RequestLFDPartyLockInfo
        SMSG_LFG_PARTY_INFO                             = UNKNOWN_OPCODE, /* old 0x372, */    // SMSG uint8, for(uint8) uint64
        SMSG_TITLE_EARNED                               = UNKNOWN_OPCODE, /* old 0x373, */
        CMSG_SET_TITLE                                  = UNKNOWN_OPCODE, /* old 0x374, */
        CMSG_CANCEL_MOUNT_AURA                          = UNKNOWN_OPCODE, /* old 0x375, */
        SMSG_ARENA_ERROR                                = UNKNOWN_OPCODE, /* old 0x376, */
        MSG_INSPECT_ARENA_TEAMS                         = UNKNOWN_OPCODE, /* old 0x377, */
        SMSG_DEATH_RELEASE_LOC                          = UNKNOWN_OPCODE, /* old 0x378, */
        CMSG_CANCEL_TEMP_ENCHANTMENT                    = UNKNOWN_OPCODE, /* old 0x379, */
        SMSG_FORCED_DEATH_UPDATE                        = UNKNOWN_OPCODE, /* old 0x37A, */
        CMSG_CHEAT_SET_HONOR_CURRENCY                   = UNKNOWN_OPCODE, /* old 0x37B, */
        CMSG_CHEAT_SET_ARENA_CURRENCY                   = UNKNOWN_OPCODE, /* old 0x37C, */
        CMSG_MAELSTROM_INVALIDATE_CACHE                 = UNKNOWN_OPCODE, /* old 0x387, */
        SMSG_FLIGHT_SPLINE_SYNC                         = UNKNOWN_OPCODE, /* old 0x388, */
        CMSG_SET_TAXI_BENCHMARK_MODE                    = UNKNOWN_OPCODE, /* old 0x389, */
        SMSG_BATTLEFIELD_STATUS_FAILED                  = UNKNOWN_OPCODE, /* old 0x38A, */
        SMSG_REALM_SPLIT                                = UNKNOWN_OPCODE, /* old 0x38B, */
        CMSG_REALM_SPLIT                                = UNKNOWN_OPCODE, /* old 0x38C, */
        CMSG_MOVE_CHANGE_TRANSPORT                      = UNKNOWN_OPCODE, /* old 0x38D, */
        MSG_PARTY_ASSIGNMENT                            = UNKNOWN_OPCODE, /* old 0x38E, */
        SMSG_OFFER_PETITION_ERROR                       = UNKNOWN_OPCODE, /* old 0x38F, */
        SMSG_PETITION_ALREADY_SIGNED                    = UNKNOWN_OPCODE,
        [Description("Jam Opcode")]
        SMSG_TIME_SYNC_REQUEST                          = UNKNOWN_OPCODE, /* old 0x390, */
        CMSG_TIME_SYNC_RESPONSE                         = UNKNOWN_OPCODE, /* old 0x391, */
        CMSG_TIME_SYNC_RESPONSE_FAILED                  = UNKNOWN_OPCODE,
        CMSG_SEND_LOCAL_EVENT                           = UNKNOWN_OPCODE, /* old 0x392, */
        CMSG_SEND_GENERAL_TRIGGER                       = UNKNOWN_OPCODE, /* old 0x393, */
        CMSG_SEND_COMBAT_TRIGGER                        = UNKNOWN_OPCODE, /* old 0x394, */
        CMSG_MAELSTROM_GM_SENT_MAIL                     = UNKNOWN_OPCODE, /* old 0x395, */
        SMSG_RESET_FAILED_NOTIFY                        = UNKNOWN_OPCODE, /* old 0x396, */
        SMSG_REAL_GROUP_UPDATE                          = UNKNOWN_OPCODE, /* old 0x397, */
        SMSG_LFG_DISABLED                               = UNKNOWN_OPCODE, /* old 0x398, */
        CMSG_ACTIVE_PVP_CHEAT                           = UNKNOWN_OPCODE, /* old 0x399, */
        CMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY                = UNKNOWN_OPCODE, /* old 0x39A, */
        SMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY_RESPONSE       = UNKNOWN_OPCODE, /* old 0x39B, */
        SMSG_CHEAT_DUMP_ITEMS_DEBUG_ONLY_RESPONSE_WRITE_FILE = UNKNOWN_OPCODE, /* old 0x39C, */
        SMSG_UPDATE_COMBO_POINTS                        = UNKNOWN_OPCODE, /* old 0x39D, */
        SMSG_VOICE_SESSION_ROSTER_UPDATE                = UNKNOWN_OPCODE, /* old 0x39E, */
        SMSG_VOICE_SESSION_LEAVE                        = UNKNOWN_OPCODE, /* old 0x39F, */
        SMSG_VOICE_SESSION_ADJUST_PRIORITY              = UNKNOWN_OPCODE, /* old 0x3A0, */
        CMSG_VOICE_SET_TALKER_MUTED_REQUEST             = UNKNOWN_OPCODE, /* old 0x3A1, */
        SMSG_VOICE_SET_TALKER_MUTED                     = UNKNOWN_OPCODE, /* old 0x3A2, */
        SMSG_INIT_EXTRA_AURA_INFO_OBSOLETE              = UNKNOWN_OPCODE, /* old 0x3A3, */
        SMSG_SET_EXTRA_AURA_INFO_OBSOLETE               = UNKNOWN_OPCODE, /* old 0x3A4, */
        SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE_OBSOLETE   = UNKNOWN_OPCODE, /* old 0x3A5, */
        SMSG_CLEAR_EXTRA_AURA_INFO_OBSOLETE             = UNKNOWN_OPCODE, /* old 0x3A6, */
        CMSG_IGNORE_REQUIREMENTS_CHEAT                  = UNKNOWN_OPCODE, /* old 0x3A8, */
        SMSG_IGNORE_REQUIREMENTS_CHEAT                  = UNKNOWN_OPCODE, /* old 0x3A9, */
        SMSG_SPELL_CHANCE_PROC_LOG                      = UNKNOWN_OPCODE, /* old 0x3AA, */
        CMSG_MOVE_SET_RUN_SPEED                         = UNKNOWN_OPCODE, /* old 0x3AB, */
        SMSG_DISMOUNT                                   = UNKNOWN_OPCODE, /* old 0x3AC, */
        MSG_RAID_READY_CHECK_CONFIRM                    = UNKNOWN_OPCODE, /* old 0x3AE, */
        CMSG_VOICE_SESSION_ENABLE                       = UNKNOWN_OPCODE, /* old 0x3AF, */
        SMSG_VOICE_SESSION_ENABLE                       = UNKNOWN_OPCODE, /* old 0x3B0, */
        SMSG_VOICE_PARENTAL_CONTROLS                    = UNKNOWN_OPCODE, /* old 0x3B1, */
        CMSG_GM_WHISPER                                 = UNKNOWN_OPCODE, /* old 0x3B2, */
        SMSG_GM_MESSAGECHAT                             = UNKNOWN_OPCODE, /* old 0x3B3, */
        MSG_GM_GEARRATING                               = UNKNOWN_OPCODE, /* old 0x3B4, */
        CMSG_COMMENTATOR_ENABLE                         = UNKNOWN_OPCODE, /* old 0x3B5, */
        SMSG_COMMENTATOR_STATE_CHANGED                  = UNKNOWN_OPCODE, /* old 0x3B6, */
        CMSG_COMMENTATOR_GET_MAP_INFO                   = UNKNOWN_OPCODE, /* old 0x3B7, */
        SMSG_COMMENTATOR_MAP_INFO                       = UNKNOWN_OPCODE, /* old 0x3B8, */
        CMSG_COMMENTATOR_GET_PLAYER_INFO                = UNKNOWN_OPCODE, /* old 0x3B9, */
        SMSG_COMMENTATOR_GET_PLAYER_INFO                = UNKNOWN_OPCODE, /* old 0x3BA, */
        SMSG_COMMENTATOR_PLAYER_INFO                    = UNKNOWN_OPCODE, /* old 0x3BB, */
        CMSG_COMMENTATOR_ENTER_INSTANCE                 = UNKNOWN_OPCODE, /* old 0x3BC, */
        CMSG_COMMENTATOR_EXIT_INSTANCE                  = UNKNOWN_OPCODE, /* old 0x3BD, */
        CMSG_COMMENTATOR_INSTANCE_COMMAND               = UNKNOWN_OPCODE, /* old 0x3BE, */
        CMSG_COMMENTATOR_GET_PARTY_INFO                 = UNKNOWN_OPCODE,
        [Description("uint64 target. CGGameUI::ClearTarget(target, true);. Sends CMSG_SET_SELECTION")]
        SMSG_CLEAR_TARGET                               = UNKNOWN_OPCODE, /* old 0x3BF, */
        CMSG_BOT_DETECTED                               = UNKNOWN_OPCODE, /* old 0x3C0, */
        SMSG_CROSSED_INEBRIATION_THRESHOLD              = UNKNOWN_OPCODE, /* old 0x3C1, */
        CMSG_CHEAT_PLAYER_LOGIN                         = UNKNOWN_OPCODE, /* old 0x3C2, */
        CMSG_CHEAT_PLAYER_LOOKUP                        = UNKNOWN_OPCODE, /* old 0x3C3, */
        SMSG_CHEAT_PLAYER_LOOKUP                        = UNKNOWN_OPCODE, /* old 0x3C4, */
        SMSG_KICK_REASON                                = UNKNOWN_OPCODE, /* old 0x3C5, */
        MSG_RAID_READY_CHECK_FINISHED                   = UNKNOWN_OPCODE, /* old 0x3C6, */
        CMSG_COMPLAIN                                   = UNKNOWN_OPCODE, /* old 0x3C7, */
        SMSG_COMPLAIN_RESULT                            = UNKNOWN_OPCODE, /* old 0x3C8, */
        SMSG_FEATURE_SYSTEM_STATUS                      = UNKNOWN_OPCODE, /* old 0x3C9, */
        CMSG_GM_SHOW_COMPLAINTS                         = UNKNOWN_OPCODE, /* old 0x3CA, */
        CMSG_GM_UNSQUELCH                               = UNKNOWN_OPCODE, /* old 0x3CB, */
        CMSG_CHANNEL_SILENCE_VOICE                      = UNKNOWN_OPCODE, /* old 0x3CC, */
        CMSG_CHANNEL_SILENCE_ALL                        = UNKNOWN_OPCODE, /* old 0x3CD, */
        CMSG_CHANNEL_UNSILENCE_VOICE                    = UNKNOWN_OPCODE, /* old 0x3CE, */
        CMSG_CHANNEL_UNSILENCE_ALL                      = UNKNOWN_OPCODE, /* old 0x3CF, */
        CMSG_TARGET_CAST                                = UNKNOWN_OPCODE, /* old 0x3D0, */
        CMSG_TARGET_SCRIPT_CAST                         = UNKNOWN_OPCODE, /* old 0x3D1, */
        CMSG_CHANNEL_DISPLAY_LIST                       = UNKNOWN_OPCODE, /* old 0x3D2, */
        CMSG_SET_ACTIVE_VOICE_CHANNEL                   = UNKNOWN_OPCODE, /* old 0x3D3, */
        CMSG_CHANNEL_MEMBER_COUNT                       = UNKNOWN_OPCODE, /* old 0x3D4, */
        SMSG_CHANNEL_MEMBER_COUNT                       = UNKNOWN_OPCODE, /* old 0x3D5, */
        CMSG_CHANNEL_VOICE_ON                           = UNKNOWN_OPCODE, /* old 0x3D6, */
        CMSG_CHANNEL_VOICE_OFF                          = UNKNOWN_OPCODE, /* old 0x3D7, */
        CMSG_DEBUG_LIST_TARGETS                         = UNKNOWN_OPCODE, /* old 0x3D8, */
        SMSG_DEBUG_LIST_TARGETS                         = UNKNOWN_OPCODE, /* old 0x3D9, */
        SMSG_AVAILABLE_VOICE_CHANNEL                    = UNKNOWN_OPCODE, /* old 0x3DA, */
        CMSG_ADD_VOICE_IGNORE                           = UNKNOWN_OPCODE, /* old 0x3DB, */
        CMSG_DEL_VOICE_IGNORE                           = UNKNOWN_OPCODE, /* old 0x3DC, */
        CMSG_PARTY_SILENCE                              = UNKNOWN_OPCODE, /* old 0x3DD, */
        CMSG_PARTY_UNSILENCE                            = UNKNOWN_OPCODE, /* old 0x3DE, */
        MSG_NOTIFY_PARTY_SQUELCH                        = UNKNOWN_OPCODE, /* old 0x3DF, */
        SMSG_COMSAT_RECONNECT_TRY                       = UNKNOWN_OPCODE, /* old 0x3E0, */
        SMSG_COMSAT_DISCONNECT                          = UNKNOWN_OPCODE, /* old 0x3E1, */
        SMSG_COMSAT_CONNECT_FAIL                        = UNKNOWN_OPCODE, /* old 0x3E2, */
        SMSG_VOICE_CHAT_STATUS                          = UNKNOWN_OPCODE, /* old 0x3E3, */
        CMSG_REPORT_PVP_AFK                             = UNKNOWN_OPCODE, /* old 0x3E4, */
        SMSG_REPORT_PVP_AFK_RESULT                      = UNKNOWN_OPCODE, /* old 0x3E5, */ // SMSG?
        CMSG_REPORT_FILTERED                            = UNKNOWN_OPCODE,
        CMSG_REPORT_IGNORED                             = UNKNOWN_OPCODE,
        CMSG_GUILD_BANKER_ACTIVATE                      = UNKNOWN_OPCODE, /* old 0x3E6, */
        CMSG_GUILD_BANK_QUERY_TAB                       = UNKNOWN_OPCODE, /* old 0x3E7, */
        [Description("EVENT_GUILDBANKBAGSLOTS_CHANGED")]
        SMSG_GUILD_BANK_LIST                            = UNKNOWN_OPCODE, /* old 0x3E8, */
        CMSG_GUILD_BANK_SWAP_ITEMS                      = UNKNOWN_OPCODE, /* old 0x3E9, */
        CMSG_GUILD_BANK_BUY_TAB                         = UNKNOWN_OPCODE, /* old 0x3EA, */
        CMSG_GUILD_BANK_UPDATE_TAB                      = UNKNOWN_OPCODE, /* old 0x3EB, */
        CMSG_GUILD_BANK_DEPOSIT_MONEY                   = UNKNOWN_OPCODE, /* old 0x3EC, */
        CMSG_GUILD_BANK_WITHDRAW_MONEY                  = UNKNOWN_OPCODE, /* old 0x3ED, */
        CMSG_GUILD_BANK_LOG_QUERY                       = UNKNOWN_OPCODE, /* old 0x3EE, */
        SMSG_GUILD_BANK_LOG_QUERY_RESULTS               = UNKNOWN_OPCODE,
        CMSG_SET_CHANNEL_WATCH                          = UNKNOWN_OPCODE, /* old 0x3EF, */
        SMSG_USERLIST_ADD                               = UNKNOWN_OPCODE, /* old 0x3F0, */
        SMSG_USERLIST_REMOVE                            = UNKNOWN_OPCODE, /* old 0x3F1, */
        SMSG_USERLIST_UPDATE                            = UNKNOWN_OPCODE, /* old 0x3F2, */
        CMSG_CLEAR_CHANNEL_WATCH                        = UNKNOWN_OPCODE, /* old 0x3F3, */
        SMSG_INSPECT_RESULTS                            = UNKNOWN_OPCODE, /* old 0x3F4, */
        SMSG_GOGOGO_OBSOLETE                            = UNKNOWN_OPCODE, /* old 0x3F5, */
        SMSG_ECHO_PARTY_SQUELCH                         = UNKNOWN_OPCODE, /* old 0x3F6, */
        CMSG_SET_TITLE_SUFFIX                           = UNKNOWN_OPCODE, /* old 0x3F7, */
        CMSG_SPELLCLICK                                 = UNKNOWN_OPCODE, /* old 0x3F8, */
        SMSG_LOOT_LIST                                  = UNKNOWN_OPCODE, /* old 0x3F9, */
        CMSG_GM_CHARACTER_RESTORE                       = UNKNOWN_OPCODE, /* old 0x3FA, */
        CMSG_GM_CHARACTER_SAVE                          = UNKNOWN_OPCODE, /* old 0x3FB, */
        SMSG_VOICESESSION_FULL                          = UNKNOWN_OPCODE, /* old 0x3FC, */
        CMSG_GUILD_PERMISSIONS_QUERY                    = UNKNOWN_OPCODE, /* old 0x3FD, */
        SMSG_GUILD_PERMISSIONS_QUERY_RESULTS            = UNKNOWN_OPCODE,
        CMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY_QUERY  = UNKNOWN_OPCODE, /* old 0x3FE, */
        SMSG_GUILD_BANK_REMAINING_WITHDRAW_MONEY        = UNKNOWN_OPCODE,
        CMSG_GUILD_EVENT_LOG_QUERY                      = UNKNOWN_OPCODE, /* old 0x3FF, */
        SMSG_GUILD_EVENT_LOG_QUERY_RESULTS              = UNKNOWN_OPCODE,
        CMSG_MAELSTROM_RENAME_GUILD                     = UNKNOWN_OPCODE, /* old 0x400, */
        CMSG_GET_MIRRORIMAGE_DATA                       = UNKNOWN_OPCODE, /* old 0x401, */
        SMSG_MIRRORIMAGE_DATA                           = UNKNOWN_OPCODE, /* old 0x402, */
        SMSG_MOVE_DISPLAY_UPDATE                        = UNKNOWN_OPCODE, /* old 0x403, */
        SMSG_SPELL_CHANCE_RESIST_PUSHBACK               = UNKNOWN_OPCODE, /* old 0x404, */
        CMSG_IGNORE_DIMINISHING_RETURNS_CHEAT           = UNKNOWN_OPCODE, /* old 0x405, */
        SMSG_IGNORE_DIMINISHING_RETURNS_CHEAT           = UNKNOWN_OPCODE, /* old 0x406, */
        CMSG_KEEP_ALIVE                                 = UNKNOWN_OPCODE, /* old 0x407, */
        SMSG_RAID_READY_CHECK_ERROR                     = UNKNOWN_OPCODE, /* old 0x408, */
        CMSG_OPT_OUT_OF_LOOT                            = UNKNOWN_OPCODE,  /* old 0x409, */
        CMSG_GUILD_BANK_TEXT_QUERY                      = UNKNOWN_OPCODE, /* old 0x40A, */
        SMSG_GUILD_BANK_TEXT_QUERY_RESULT               = UNKNOWN_OPCODE,
        CMSG_GUILD_BANK_SET_TAB_TEXT                    = UNKNOWN_OPCODE, /* old 0x40B, */
        CMSG_SET_GRANTABLE_LEVELS                       = UNKNOWN_OPCODE, /* old 0x40C, */
        CMSG_GRANT_LEVEL                                = UNKNOWN_OPCODE, /* old 0x40D, */
        CMSG_REFER_A_FRIEND                             = UNKNOWN_OPCODE, /* old 0x40E, */
        MSG_GM_CHANGE_ARENA_RATING                      = UNKNOWN_OPCODE, /* old 0x40F, */
        CMSG_DECLINE_CHANNEL_INVITE                     = UNKNOWN_OPCODE, /* old 0x410, */
        [Description("ERR_GROUP_ACTION_THROTTLED")]
        SMSG_GROUPACTION_THROTTLED                      = UNKNOWN_OPCODE, /* old 0x411, */ // SMSG?
        SMSG_OVERRIDE_LIGHT                             = UNKNOWN_OPCODE, /* old 0x412, */
        [Description("uint8 slot, uint64 guid, uint32 duration, uint32 spellId")]
        SMSG_TOTEM_CREATED                              = UNKNOWN_OPCODE, /* old 0x413, */
        CMSG_TOTEM_DESTROYED                            = UNKNOWN_OPCODE, /* old 0x414, */
        CMSG_EXPIRE_RAID_INSTANCE                       = UNKNOWN_OPCODE, /* old 0x415, */
        CMSG_NO_SPELL_VARIANCE                          = UNKNOWN_OPCODE, /* old 0x416, */
        CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY           = UNKNOWN_OPCODE, /* old 0x417, */
        SMSG_QUESTGIVER_STATUS_MULTIPLE                 = UNKNOWN_OPCODE, /* old 0x418, */
        CMSG_SET_PLAYER_DECLINED_NAMES                  = UNKNOWN_OPCODE, /* old 0x419, */
        SMSG_SET_PLAYER_DECLINED_NAMES_RESULT           = UNKNOWN_OPCODE, /* old 0x41A, */
        CMSG_QUERY_SERVER_BUCK_DATA                     = UNKNOWN_OPCODE, /* old 0x41B, */
        CMSG_CLEAR_SERVER_BUCK_DATA                     = UNKNOWN_OPCODE, /* old 0x41C, */
        SMSG_SERVER_BUCK_DATA                           = UNKNOWN_OPCODE, /* old 0x41D, */
        SMSG_SEND_UNLEARN_SPELLS                        = UNKNOWN_OPCODE, /* old 0x41E, */
        SMSG_PROPOSE_LEVEL_GRANT                        = UNKNOWN_OPCODE, /* old 0x41F, */
        CMSG_ACCEPT_LEVEL_GRANT                         = UNKNOWN_OPCODE, /* old 0x420, */
        [Description("uint32 err, if (err==9) cstring")]
        SMSG_REFER_A_FRIEND_FAILURE                     = UNKNOWN_OPCODE, /* old 0x421, */
        SMSG_SUMMON_CANCEL                              = UNKNOWN_OPCODE, /* old 0x424, */
        CMSG_CHANGE_PERSONAL_ARENA_RATING               = UNKNOWN_OPCODE, /* old 0x425, */
        CMSG_ALTER_APPEARANCE                           = UNKNOWN_OPCODE, /* old 0x426, */
        SMSG_ENABLE_BARBER_SHOP                         = UNKNOWN_OPCODE, /* old 0x427, */
        SMSG_BARBER_SHOP_RESULT                         = UNKNOWN_OPCODE, /* old 0x428, */
        CMSG_CALENDAR_GET_CALENDAR                      = UNKNOWN_OPCODE, /* old 0x429, */
        CMSG_CALENDAR_GET_EVENT                         = UNKNOWN_OPCODE, /* old 0x42A, */
        CMSG_CALENDAR_GUILD_FILTER                      = UNKNOWN_OPCODE, /* old 0x42B, */
        CMSG_CALENDAR_ARENA_TEAM                        = UNKNOWN_OPCODE, /* old 0x42C, */
        CMSG_CALENDAR_ADD_EVENT                         = UNKNOWN_OPCODE, /* old 0x42D, */
        CMSG_CALENDAR_UPDATE_EVENT                      = UNKNOWN_OPCODE, /* old 0x42E, */
        CMSG_CALENDAR_REMOVE_EVENT                      = UNKNOWN_OPCODE, /* old 0x42F, */
        CMSG_CALENDAR_COPY_EVENT                        = UNKNOWN_OPCODE, /* old 0x430, */
        CMSG_CALENDAR_EVENT_INVITE                      = UNKNOWN_OPCODE, /* old 0x431, */
        CMSG_CALENDAR_EVENT_RSVP                        = UNKNOWN_OPCODE, /* old 0x432, */
        CMSG_CALENDAR_EVENT_REMOVE_INVITE               = UNKNOWN_OPCODE, /* old 0x433, */
        CMSG_CALENDAR_EVENT_STATUS                      = UNKNOWN_OPCODE, /* old 0x434, */
        CMSG_CALENDAR_EVENT_MODERATOR_STATUS            = UNKNOWN_OPCODE, /* old 0x435, */
        SMSG_CALENDAR_SEND_CALENDAR                     = UNKNOWN_OPCODE, /* old 0x436, */
        SMSG_CALENDAR_SEND_EVENT                        = UNKNOWN_OPCODE, /* old 0x437, */
        SMSG_CALENDAR_FILTER_GUILD                      = UNKNOWN_OPCODE, /* old 0x438, */
        SMSG_CALENDAR_ARENA_TEAM                        = UNKNOWN_OPCODE, /* old 0x439, */
        SMSG_CALENDAR_EVENT_INVITE                      = UNKNOWN_OPCODE, /* old 0x43A, */
        SMSG_CALENDAR_EVENT_INVITE_REMOVED              = UNKNOWN_OPCODE, /* old 0x43B, */
        SMSG_CALENDAR_EVENT_STATUS                      = UNKNOWN_OPCODE, /* old 0x43C, */
        SMSG_CALENDAR_COMMAND_RESULT                    = UNKNOWN_OPCODE, /* old 0x43D, */
        SMSG_CALENDAR_RAID_LOCKOUT_ADDED                = UNKNOWN_OPCODE, /* old 0x43E, */
        SMSG_CALENDAR_RAID_LOCKOUT_REMOVED              = UNKNOWN_OPCODE, /* old 0x43F, */
        SMSG_CALENDAR_EVENT_INVITE_ALERT                = UNKNOWN_OPCODE, /* old 0x440, */
        SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT        = UNKNOWN_OPCODE, /* old 0x441, */
        SMSG_CALENDAR_EVENT_INVITE_STATUS_ALERT         = UNKNOWN_OPCODE, /* old 0x442, */
        SMSG_CALENDAR_EVENT_REMOVED_ALERT               = UNKNOWN_OPCODE, /* old 0x443, */
        SMSG_CALENDAR_EVENT_UPDATED_ALERT               = UNKNOWN_OPCODE, /* old 0x444, */
        SMSG_CALENDAR_EVENT_MODERATOR_STATUS_ALERT      = UNKNOWN_OPCODE, /* old 0x445, */
        CMSG_CALENDAR_COMPLAIN                          = UNKNOWN_OPCODE, /* old 0x446, */
        CMSG_CALENDAR_GET_NUM_PENDING                   = UNKNOWN_OPCODE, /* old 0x447, */
        SMSG_CALENDAR_SEND_NUM_PENDING                  = UNKNOWN_OPCODE, /* old 0x448, */
        CMSG_SAVE_DANCE                                 = UNKNOWN_OPCODE, /* old 0x449, */
        SMSG_NOTIFY_DANCE                               = UNKNOWN_OPCODE, /* old 0x44A, */
        CMSG_PLAY_DANCE                                 = UNKNOWN_OPCODE, /* old 0x44B, */
        SMSG_PLAY_DANCE                                 = UNKNOWN_OPCODE, /* old 0x44C, */
        CMSG_LOAD_DANCES                                = UNKNOWN_OPCODE, /* old 0x44D, */
        CMSG_STOP_DANCE                                 = UNKNOWN_OPCODE, /* old 0x44E, */
        SMSG_STOP_DANCE                                 = UNKNOWN_OPCODE, /* old 0x44F, */
        CMSG_SYNC_DANCE                                 = UNKNOWN_OPCODE, /* old 0x450, */
        CMSG_DANCE_QUERY                                = UNKNOWN_OPCODE, /* old 0x451, */
        SMSG_DANCE_QUERY_RESPONSE                       = UNKNOWN_OPCODE, /* old 0x452, */
        SMSG_INVALIDATE_DANCE                           = UNKNOWN_OPCODE, /* old 0x453, */
        CMSG_DELETE_DANCE                               = UNKNOWN_OPCODE, /* old 0x454, */
        SMSG_LEARNED_DANCE_MOVES                        = UNKNOWN_OPCODE, /* old 0x455, */
        CMSG_LEARN_DANCE_MOVE                           = UNKNOWN_OPCODE, /* old 0x456, */
        CMSG_UNLEARN_DANCE_MOVE                         = UNKNOWN_OPCODE, /* old 0x457, */
        CMSG_SET_RUNE_COUNT                             = UNKNOWN_OPCODE, /* old 0x458, */
        CMSG_SET_RUNE_COOLDOWN                          = UNKNOWN_OPCODE, /* old 0x459, */
        CMSG_CALENDAR_EVENT_INVITE_NOTES                = UNKNOWN_OPCODE, /* old 0x45F, */
        SMSG_CALENDAR_EVENT_INVITE_NOTES                = UNKNOWN_OPCODE, /* old 0x460, */
        SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT          = UNKNOWN_OPCODE, /* old 0x461, */
        CMSG_UPDATE_MISSILE_TRAJECTORY                  = UNKNOWN_OPCODE, /* old 0x462, */
        SMSG_UPDATE_ACCOUNT_DATA_COMPLETE               = UNKNOWN_OPCODE, /* old 0x463, */
        [Description("EVENT_PLAY_MOVIE. uint32 movie_id (Movie.dbc)")]
        SMSG_TRIGGER_MOVIE                              = UNKNOWN_OPCODE, /* old 0x464, */
        CMSG_COMPLETE_MOVIE                             = UNKNOWN_OPCODE, /* old 0x465, */
        CMSG_SET_GLYPH_SLOT                             = UNKNOWN_OPCODE, /* old 0x466, */
        CMSG_SET_GLYPH                                  = UNKNOWN_OPCODE, /* old 0x467, */
        SMSG_ACHIEVEMENT_EARNED                         = UNKNOWN_OPCODE, /* old 0x468, */
        SMSG_DYNAMIC_DROP_ROLL_RESULT                   = UNKNOWN_OPCODE, /* old 0x469, */
        SMSG_CRITERIA_UPDATE                            = UNKNOWN_OPCODE, /* old 0x46A, */
        CMSG_QUERY_INSPECT_ACHIEVEMENTS                 = UNKNOWN_OPCODE, /* old 0x46B, */
        CMSG_MOVE_DISMISS_VEHICLE                       = UNKNOWN_OPCODE, /* old 0x46D, */
        CMSG_COMPLETE_ACHIEVEMENT_CHEAT                 = UNKNOWN_OPCODE, /* old 0x46E, */
        SMSG_QUESTUPDATE_ADD_PVP_KILL                   = UNKNOWN_OPCODE, /* old 0x46F, */
        CMSG_SET_CRITERIA_CHEAT                         = UNKNOWN_OPCODE, /* old 0x470, */
        SMSG_CALENDAR_RAID_LOCKOUT_UPDATED              = UNKNOWN_OPCODE, /* old 0x471, */
        CMSG_UNITANIMTIER_CHEAT                         = UNKNOWN_OPCODE, /* old 0x472, */
        CMSG_CHAR_CUSTOMIZE                             = UNKNOWN_OPCODE, /* old 0x473, */
        SMSG_CHAR_CUSTOMIZE                             = UNKNOWN_OPCODE, /* old 0x474, */
        SMSG_PET_RENAMEABLE                             = UNKNOWN_OPCODE, /* old 0x475, */
        CMSG_REQUEST_VEHICLE_EXIT                       = UNKNOWN_OPCODE, /* old 0x476, */
        CMSG_REQUEST_VEHICLE_PREV_SEAT                  = UNKNOWN_OPCODE, /* old 0x477, */
        CMSG_REQUEST_VEHICLE_NEXT_SEAT                  = UNKNOWN_OPCODE, /* old 0x478, */
        CMSG_REQUEST_VEHICLE_SWITCH_SEAT                = UNKNOWN_OPCODE, /* old 0x479, */
        CMSG_PET_LEARN_TALENT                           = UNKNOWN_OPCODE, /* old 0x47A, */
        CMSG_PET_UNLEARN_TALENTS                        = UNKNOWN_OPCODE, /* old 0x47B, */
        CMSG_MOVE_SAY_CHEAT                            = UNKNOWN_OPCODE, /* old 0x47E, */
        SMSG_HEALTH_UPDATE                              = UNKNOWN_OPCODE, /* old 0x47F, */
        SMSG_POWER_UPDATE                               = UNKNOWN_OPCODE, /* old 0x480, */
        CMSG_GAMEOBJ_REPORT_USE                         = UNKNOWN_OPCODE, /* old 0x481, */
        SMSG_HIGHEST_THREAT_UPDATE                      = UNKNOWN_OPCODE, /* old 0x482, */
        SMSG_THREAT_UPDATE                              = UNKNOWN_OPCODE, /* old 0x483, */
        SMSG_THREAT_REMOVE                              = UNKNOWN_OPCODE, /* old 0x484, */
        SMSG_THREAT_CLEAR                               = UNKNOWN_OPCODE, /* old 0x485, */
        SMSG_CONVERT_RUNE                               = UNKNOWN_OPCODE, /* old 0x486, */
        SMSG_RESYNC_RUNES                               = UNKNOWN_OPCODE, /* old 0x487, */
        SMSG_ADD_RUNE_POWER                             = UNKNOWN_OPCODE, /* old 0x488, */
        CMSG_START_QUEST                                = UNKNOWN_OPCODE, /* old 0x489, */
        CMSG_REMOVE_GLYPH                               = UNKNOWN_OPCODE, /* old 0x48A, */
        CMSG_DUMP_OBJECTS                               = UNKNOWN_OPCODE, /* old 0x48B, */
        SMSG_DUMP_OBJECTS_DATA                          = UNKNOWN_OPCODE, /* old 0x48C, */
        CMSG_DISMISS_CRITTER                            = UNKNOWN_OPCODE, /* old 0x48D, */
        SMSG_NOTIFY_DEST_LOC_SPELL_CAST                 = UNKNOWN_OPCODE, /* old 0x48E, */
        CMSG_AUCTION_LIST_PENDING_SALES                 = UNKNOWN_OPCODE, /* old 0x48F, */
        SMSG_AUCTION_LIST_PENDING_SALES                 = UNKNOWN_OPCODE, /* old 0x490, */
        SMSG_MODIFY_COOLDOWN                            = UNKNOWN_OPCODE, /* old 0x491, */
        SMSG_PET_UPDATE_COMBO_POINTS                    = UNKNOWN_OPCODE, /* old 0x492, */
        CMSG_ENABLETAXI                                 = UNKNOWN_OPCODE, /* old 0x493, */
        SMSG_PRE_RESURRECT                              = UNKNOWN_OPCODE, /* old 0x494, */
        SMSG_AURA_UPDATE_ALL                            = UNKNOWN_OPCODE, /* old 0x495, */
        SMSG_AURA_UPDATE                                = UNKNOWN_OPCODE, /* old 0x496, */
        CMSG_FLOOD_GRACE_CHEAT                          = UNKNOWN_OPCODE, /* old 0x497, */
        SMSG_SERVER_FIRST_ACHIEVEMENT                   = UNKNOWN_OPCODE, /* old 0x498, */
        SMSG_PET_LEARNED_SPELL                          = UNKNOWN_OPCODE, /* old 0x499, */
        SMSG_PET_REMOVED_SPELL                          = UNKNOWN_OPCODE, /* old 0x49A, */
        CMSG_MOVE_CHANGE_VEHICLE_SEATS         = UNKNOWN_OPCODE, /* old 0x49B, */
        CMSG_HEARTH_AND_RESURRECT                       = UNKNOWN_OPCODE, /* old 0x49C, */ // not changed in 3.1
        SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA       = UNKNOWN_OPCODE, /* old 0x49D, */ // not changed 9626
        SMSG_CRITERIA_DELETED                           = UNKNOWN_OPCODE, /* old 0x49E, */ // not changed 9626
        SMSG_ACHIEVEMENT_DELETED                        = UNKNOWN_OPCODE, /* old 0x49F, */ // not changed 9626
        CMSG_SERVER_INFO_QUERY                          = UNKNOWN_OPCODE, /* old 0x4A0, */ // not found
        SMSG_SERVER_INFO_RESPONSE                       = UNKNOWN_OPCODE, /* old 0x4A1, */ // not found
        CMSG_CHECK_LOGIN_CRITERIA                       = UNKNOWN_OPCODE, /* old 0x4A2, */ // not found
        SMSG_SERVER_BUCK_DATA_START                     = UNKNOWN_OPCODE, /* old 0x4A3, */ // not found
        CMSG_SET_BREATH                                 = UNKNOWN_OPCODE, /* old 0x4A4, */ // not found
        CMSG_QUERY_VEHICLE_STATUS                       = UNKNOWN_OPCODE, /* old 0x4A5, */ // not found, old SMSG_PET_GUIDS
        [Description("Jam Opcode. ERR_BATTLEGROUND_INFO_THROTTLED")]
        SMSG_BATTLEGROUND_INFO_THROTTLED                = UNKNOWN_OPCODE, /* old 0x4A6, */ // empty, "You can't do that yet"
        SMSG_UPDATE_VEHICLE_REC_ID                      = UNKNOWN_OPCODE, /* old 0x4A7, */ // smsg guid+uint32 (vehicle) EVENT_PLAYER_GAINS_VEHICLE_DATA/EVENT_PLAYER_LOSES_VEHICLE_DATA
        CMSG_RIDE_VEHICLE_INTERACT                      = UNKNOWN_OPCODE, /* old 0x4A8, */ // cmsg uint64
        CMSG_CONTROLLER_EJECT_PASSENGER                 = UNKNOWN_OPCODE, /* old 0x4A9, */ // cmsg uint64
        SMSG_PET_GUIDS                                  = UNKNOWN_OPCODE, /* old 0x4AA, */ // shifted+5
        [Description("Sent after SMSG_ADDON_INFO")]
        SMSG_CLIENTCACHE_VERSION                        = UNKNOWN_OPCODE, /* old 0x4AB, */
        CMSG_CHANGE_GDF_ARENA_RATING                    = UNKNOWN_OPCODE, /* old 0x4AC, */ // not found
        CMSG_SET_ARENA_TEAM_RATING_BY_INDEX             = UNKNOWN_OPCODE, /* old 0x4AD, */ // not found
        CMSG_SET_ARENA_TEAM_WEEKLY_GAMES                = UNKNOWN_OPCODE, /* old 0x4AE, */ // not found
        CMSG_SET_ARENA_TEAM_SEASON_GAMES                = UNKNOWN_OPCODE, /* old 0x4AF, */ // not found
        CMSG_SET_ARENA_MEMBER_WEEKLY_GAMES              = UNKNOWN_OPCODE, /* old 0x4B0, */ // not found
        CMSG_SET_ARENA_MEMBER_SEASON_GAMES              = UNKNOWN_OPCODE, /* old 0x4B1, */ // not found
        [Description("Jam Opcode")]
        SMSG_SET_ITEM_PURCHASE_DATA                     = UNKNOWN_OPCODE, /* old 0x4B2, */ // refund item info
        CMSG_GET_ITEM_PURCHASE_DATA                     = UNKNOWN_OPCODE, /* old 0x4B3, */ // refund request?
        CMSG_ITEM_PURCHASE_REFUND                       = UNKNOWN_OPCODE, /* old 0x4B4, */ // lua: ContainerRefundItemPurchase
        [Description("Jam Opcode")]
        SMSG_ITEM_PURCHASE_REFUND_RESULT                = UNKNOWN_OPCODE, /* old 0x4B5, */ // refund item result
        CMSG_CORPSE_TRANSPORT_QUERY                     = UNKNOWN_OPCODE, /* old 0x4B6, */ // CMSG, uint32
        SMSG_CORPSE_TRANSPORT_QUERY                     = UNKNOWN_OPCODE, /* old 0x4B7, */ // SMSG, 3*float+float
        CMSG_UNUSED5                                    = UNKNOWN_OPCODE, /* old 0x4B8, */ // not found
        CMSG_UNUSED6                                    = UNKNOWN_OPCODE, /* old 0x4B9, */ // not found
        CMSG_CALENDAR_EVENT_SIGNUP                      = UNKNOWN_OPCODE, /* old 0x4BA, */ // CMSG, uint64, lua: CalendarContextEventSignUp
        SMSG_CALENDAR_CLEAR_PENDING_ACTION              = UNKNOWN_OPCODE, /* old 0x4BB, */ // SMSG, calendar related EVENT_CALENDAR_ACTION_PENDING
        [Description("Sent on loading after SMSG_INIT_CURRENCY")]
        SMSG_LOAD_EQUIPMENT_SET                         = UNKNOWN_OPCODE, /* old 0x4BC, */ // SMSG, equipment manager list?
        CMSG_SAVE_EQUIPMENT_SET                         = UNKNOWN_OPCODE, /* old 0x4BD, */ // CMSG, lua: SaveEquipmentSet
        CMSG_ON_MISSILE_TRAJECTORY_COLLISION            = UNKNOWN_OPCODE, /* old 0x4BE, */ // CMSG, uint64 caster, uint32 spellId, uint8 castId, vector3 position
        SMSG_NOTIFY_MISSILE_TRAJECTORY_COLLISION        = UNKNOWN_OPCODE, /* old 0x4BF, */ // SMSG, uint64 caster, uint8 castId, vector3 position
        SMSG_TALENT_UPDATE                              = UNKNOWN_OPCODE, /* old 0x4C0, */ // SMSG, talents related
        CMSG_LEARN_TALENT_GROUP                         = UNKNOWN_OPCODE, /* old 0x4C1, */ // CMSG, lua: LearnPreviewTalents (for player?)
        CMSG_PET_LEARN_TALENT_GROUP                     = UNKNOWN_OPCODE, /* old 0x4C2, */ // CMSG, lua: LearnPreviewTalents (for pet?)
        CMSG_SET_ACTIVE_TALENT_GROUP_OBSOLETE           = UNKNOWN_OPCODE, /* old 0x4C3, */ // not found 3.2
        CMSG_GM_GRANT_ACHIEVEMENT                       = UNKNOWN_OPCODE, /* old 0x4C4, */ // not found 3.2
        CMSG_GM_REMOVE_ACHIEVEMENT                      = UNKNOWN_OPCODE, /* old 0x4C5, */ // not found 3.2
        CMSG_GM_SET_CRITERIA_FOR_PLAYER                 = UNKNOWN_OPCODE, /* old 0x4C6, */ // not found 3.2
        SMSG_DESTROY_ARENA_UNIT                         = UNKNOWN_OPCODE, /* old 0x4C7, */ // uint64, EVENT_ARENA_OPPONENT_UPDATE
        [Description("ERR_ARENA_TEAM_CHANGE_FAILED_QUEUED. Added in 3.2. uint32 unused?. Message 'Can't modify arena team while queued or in a match.'")]
        SMSG_ARENA_TEAM_CHANGE_FAILED                   = UNKNOWN_OPCODE, /* old 0x4C8, */
        CMSG_PROFILEDATA_REQUEST                        = UNKNOWN_OPCODE, /* old 0x4C9, */ // not found 3.2
        SMSG_PROFILEDATA_RESPONSE                       = UNKNOWN_OPCODE, /* old 0x4CA, */ // not found 3.2
        CMSG_START_BATTLEFIELD_CHEAT                    = UNKNOWN_OPCODE, /* old 0x4CB, */ // not found 3.2
        CMSG_END_BATTLEFIELD_CHEAT                      = UNKNOWN_OPCODE, /* old 0x4CC, */ // not found 3.2
        SMSG_COMPOUND_MOVE                              = UNKNOWN_OPCODE, /* old 0x4CD, */ // SMSG, handles any opcode
        CMSG_USE_EQUIPMENT_SET                          = UNKNOWN_OPCODE, /* old 0x4D5, */ // CMSG, lua: UseEquipmentSet
        SMSG_USE_EQUIPMENT_SET_RESULT                   = UNKNOWN_OPCODE, /* old 0x4D6, */ // SMSG, UseEquipmentSetResult?
        CMSG_MOVE_ANIM                                  = UNKNOWN_OPCODE, /* old 0x4D7, */ // not found 3.2
        SMSG_MOVE_ANIM                                  = UNKNOWN_OPCODE, /* old 0x4D8, */ // SMSG, uint64, string, doing nothing
        CMSG_CHAR_FACTION_CHANGE                        = UNKNOWN_OPCODE, /* old 0x4D9, */ // lua: CreateCharacter (PFC client response)
        SMSG_CHAR_FACTION_CHANGE                        = UNKNOWN_OPCODE, /* old 0x4DA, */ // response to 1241 (PFC server response)
        CMSG_PVP_QUEUE_STATS_REQUEST                    = UNKNOWN_OPCODE, /* old 0x4DB, */ // not found 3.2
        SMSG_PVP_QUEUE_STATS                            = UNKNOWN_OPCODE, /* old 0x4DC, */ // not found 3.2
        CMSG_SET_PAID_SERVICE_CHEAT                     = UNKNOWN_OPCODE, /* old 0x4DD, */ // not found 3.2
        SMSG_BF_MGR_ENTRY_INVITE                        = UNKNOWN_OPCODE, /* old 0x4DE, */ // uint32, EVENT_BATTLEFIELD_MGR_ENTRY_INVITE
        CMSG_BF_MGR_ENTRY_INVITE_RESPONSE               = UNKNOWN_OPCODE, /* old 0x4DF, */ // lua: BattlefieldMgrEntryInviteResponse
        SMSG_BF_MGR_ENTERING                            = UNKNOWN_OPCODE, /* old 0x4E0, */ // uint32, uint8, uint8 EVENT_BATTLEFIELD_MGR_ENTERED
        SMSG_BF_MGR_QUEUE_INVITE                        = UNKNOWN_OPCODE, /* old 0x4E1, */ // uint32 EVENT_BATTLEFIELD_MGR_QUEUE_INVITE
        CMSG_BF_MGR_QUEUE_INVITE_RESPONSE               = UNKNOWN_OPCODE, /* old 0x4E2, */ // lua: BattlefieldMgrQueueInviteResponse
        CMSG_BF_MGR_QUEUE_REQUEST                       = UNKNOWN_OPCODE, /* old 0x4E3, */ // lua: BattlefieldMgrQueueRequest
        SMSG_BF_MGR_QUEUE_REQUEST_RESPONSE              = UNKNOWN_OPCODE, /* old 0x4E4, */ // uint32, uint8 EVENT_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE
        SMSG_BF_MGR_EJECT_PENDING                       = UNKNOWN_OPCODE, /* old 0x4E5, */ // uint32 EVENT_BATTLEFIELD_MGR_EJECT_PENDING
        SMSG_BF_MGR_EJECTED                             = UNKNOWN_OPCODE, /* old 0x4E6, */ // uint32, uint32, uint8 EVENT_BATTLEFIELD_MGR_EJECTED
        CMSG_BF_MGR_QUEUE_EXIT_REQUEST                  = UNKNOWN_OPCODE, /* old 0x4E7, */ // lua: BattlefieldMgrExitRequest
        SMSG_BF_MGR_STATE_CHANGED                       = UNKNOWN_OPCODE, /* old 0x4E8, */ // uint32, uint32 EVENT_BATTLEFIELD_MGR_STATE_CHANGE
        SMSG_BF_MGR_EXIT_REQUEST                        = UNKNOWN_OPCODE,
        CMSG_BF_MGR_ADVANCE_STATE                       = UNKNOWN_OPCODE, /* old 0x4E9, */ // not found 3.2
        CMSG_BF_MGR_SET_NEXT_TRANSITION_TIME            = UNKNOWN_OPCODE, /* old 0x4EA, */ // not found 3.2
        [Description("Script_SetRaidDifficulty")]
        MSG_SET_RAID_DIFFICULTY                         = UNKNOWN_OPCODE, /* old 0x4EB, */
        [Description("not found")]
        CMSG_XPGAIN                                     = UNKNOWN_OPCODE, /* old 0x4EC, */
        [Description("enable/disable XP gain console message")]
        SMSG_XPGAIN                                     = UNKNOWN_OPCODE, /* old 0x4ED, */
        [Description("empty")]
        SMSG_GMTICKET_RESPONSE_ERROR                    = UNKNOWN_OPCODE, /* old 0x4EE, */
        [Description("uint32, uint32, string[2000], string[4000][4]")]
        SMSG_GMTICKET_GET_RESPONSE                      = UNKNOWN_OPCODE, /* old 0x4EF, */
        [Description("lua: GMResponseResolve")]
        CMSG_GMTICKET_RESOLVE_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x4F0, */
        [Description("uint8 (1 - EVENT_GMSURVEY_DISPLAY, 0 - EVENT_UPDATE_TICKET)")]
        SMSG_GMTICKET_RESOLVE_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x4F1, */
        [Description("not found")]
        SMSG_GMTICKET_CREATE_RESPONSE_TICKET = UNKNOWN_OPCODE, /* old 0x4F2, */
        [Description("not found")]
        CMSG_GM_CREATE_TICKET_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x4F3, */
        [Description("not found")]
        CMSG_SERVERINFO                                 = UNKNOWN_OPCODE, /* old 0x4F4, */
        [Description("not found")]
        SMSG_SERVERINFO                                 = UNKNOWN_OPCODE, /* old 0x4F5, */
        CMSG_UI_TIME_REQUEST                            = UNKNOWN_OPCODE, /* old 0x4F6, */
        SMSG_UI_TIME                                    = UNKNOWN_OPCODE, /* old 0x4F7, */
        [Description("Paid Race Change. lua: CreateCharacter")]
        CMSG_CHAR_RACE_CHANGE                           = UNKNOWN_OPCODE, /* old 0x4F8, */
        MSG_VIEW_PHASE_SHIFT                            = UNKNOWN_OPCODE, /* old 0x4F9, */
        [Description("EVENT_TALENTS_INVOLUNTARILY_RESET. uint8 isPet (?)")]
        SMSG_TALENTS_INVOLUNTARILY_RESET                = UNKNOWN_OPCODE, /* old 0x4FA, */
        [Description("not found")]
        CMSG_DEBUG_SERVER_GEO                           = UNKNOWN_OPCODE, /* old 0x4FB, */
        [Description("not found")]
        SMSG_DEBUG_SERVER_GEO                           = UNKNOWN_OPCODE, /* old 0x4FC, */
        [Description("EVENT_LOOT_SLOT_CHANGED")]
        SMSG_LOOT_UPDATE                                = UNKNOWN_OPCODE, /* old 0x4FD, */
        UMSG_UPDATE_GROUP_INFO                          = UNKNOWN_OPCODE, /* old 0x4FE, */
        [Description("Sent after SMSG_AUTH_RESPONSE.")]
        CMSG_READY_FOR_ACCOUNT_DATA_TIMES               = 17707, /* old 0x4FF, */
        [Description("lua: QueryQuestsCompleted")]
        CMSG_QUERY_GET_ALL_QUESTS                       = UNKNOWN_OPCODE, /* old 0x500, */
        [Description("response to CMSG_QUERY_GET_ALL_QUESTS")]
        SMSG_ALL_QUESTS_COMPLETED                       = UNKNOWN_OPCODE, /* old 0x501, */
        [Description("lua: GMReportLag")]
        CMSG_GMLAGREPORT_SUBMIT                         = UNKNOWN_OPCODE, /* old 0x502, */
        [Description("not found")]
        CMSG_AFK_MONITOR_INFO_REQUEST                   = UNKNOWN_OPCODE, /* old 0x503, */
        [Description("not found")]
        SMSG_AFK_MONITOR_INFO_RESPONSE                  = UNKNOWN_OPCODE, /* old 0x504, */
        [Description("not found")]
        CMSG_AFK_MONITOR_INFO_CLEAR                     = UNKNOWN_OPCODE, /* old 0x505, */
        [Description("ERR_CORPSE_IS_NOT_IN_INSTANCE")]
        SMSG_AREA_TRIGGER_NO_CORPSE                     = UNKNOWN_OPCODE, /* old 0x506, */
        [Description("not found")]
        CMSG_GM_NUKE_CHARACTER                          = UNKNOWN_OPCODE, /* old 0x507, */
        [Description("lua: SetAllowLowLevelRaid")]
        CMSG_LOW_LEVEL_RAID                             = UNKNOWN_OPCODE, /* old 0x508, */
        [Description("lua: SetAllowLowLevelRaid")]
        CMSG_LOW_LEVEL_RAID_USER                        = UNKNOWN_OPCODE, /* old 0x509, */
        [Description("uint32 SpellEffectCameraShakes.dbc index, uint32 sound")]
        SMSG_CAMERA_SHAKE                               = UNKNOWN_OPCODE, /* old 0x50A, */
        SMSG_SOCKET_GEMS                                = UNKNOWN_OPCODE, /* old 0x50B, SMSG_UPDATE_ITEM_ENCHANTMENTS */
        [Description("not found")]
        CMSG_SET_CHARACTER_MODEL                        = UNKNOWN_OPCODE, /* old 0x50C, */
        SMSG_CONNECT_TO                                 = UNKNOWN_OPCODE,
        CMSG_CONNECT_TO_FAILED                          = UNKNOWN_OPCODE, /* old 0x50E, */ // something with networking
        SMSG_SUSPEND_COMMS                              = UNKNOWN_OPCODE,
        CMSG_SUSPEND_COMMS_ACK                          = UNKNOWN_OPCODE,
        SMSG_RESUME_COMMS                               = UNKNOWN_OPCODE, /* old 0x511, */
        CMSG_AUTH_CONTINUED_SESSION                     = UNKNOWN_OPCODE, /* old 0x512, */ // something with networking
        [Description("not found")]
        CMSG_DROP_NEW_CONNECTION                        = UNKNOWN_OPCODE, /* old 0x513, */
        SMSG_DROP_NEW_CONNECTION                        = UNKNOWN_OPCODE,
        [Description("multi combatlog")]
        SMSG_SEND_ALL_COMBAT_LOG                        = UNKNOWN_OPCODE, /* old 0x514, */
        [Description("event EVENT_LFG_OPEN_FROM_GOSSIP (opens dungeon finder, probably for outdoor bosses)")]
        SMSG_OPEN_LFG_DUNGEON_FINDER                    = UNKNOWN_OPCODE, /* old 0x515, */
        [Description("not found")]
        CMSG_CLEAR_RANDOM_BG_WIN_TIME                   = UNKNOWN_OPCODE, /* old 0x519, */
        [Description("not found")]
        CMSG_CLEAR_HOLIDAY_BG_WIN_TIME                  = UNKNOWN_OPCODE, /* old 0x51A, */
        [Description("lua: CommentatorSetSkirmishMatchmakingMode/CommentatorRequestSkirmishQueueData/CommentatorRequestSkirmishMode/CommentatorStartSkirmishMatch")]
        CMSG_COMMENTATOR_SKIRMISH_QUEUE_COMMAND         = UNKNOWN_OPCODE, /* old 0x51B, */
        [Description("event EVENT_COMMENTATOR_SKIRMISH_QUEUE_REQUEST, CGCommentator::QueueNode")]
        SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT1         = UNKNOWN_OPCODE, /* old 0x51C, */
        [Description("event EVENT_COMMENTATOR_SKIRMISH_QUEUE_REQUEST")]
        SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT2         = UNKNOWN_OPCODE, /* old 0x51D, */

        SMSG_MESSAGECHAT                                = UNKNOWN_OPCODE, /* old 0x096, */
        // regular structure: uint32 language, szMessage
        CMSG_MESSAGE_SAY                            = UNKNOWN_OPCODE,
        CMSG_MESSAGE_YELL                           = UNKNOWN_OPCODE,
        [Description("uint32 language, CString channel, CString message")]
        CMSG_MESSAGE_CHANNEL                        = UNKNOWN_OPCODE,
        [Description("uint32 language, CString whisperTarget, CString message. Was 0 in 4.0.6")]
        CMSG_MESSAGE_WHISPER                        = UNKNOWN_OPCODE,
        CMSG_MESSAGE_GUILD                          = UNKNOWN_OPCODE,
        CMSG_MESSAGE_OFFICER                        = UNKNOWN_OPCODE,
        [Description("CString message")]
        CMSG_MESSAGE_AFK                            = UNKNOWN_OPCODE,
        [Description("CString message")]
        CMSG_MESSAGE_DND                            = UNKNOWN_OPCODE,
        [Description("CString message")]
        CMSG_MESSAGE_EMOTE                          = UNKNOWN_OPCODE,
        CMSG_MESSAGE_PARTY                          = UNKNOWN_OPCODE,
        CMSG_MESSAGE_RAID                           = UNKNOWN_OPCODE,
        CMSG_MESSAGE_RAID_WARNING                   = UNKNOWN_OPCODE,
        CMSG_MESSAGE_BATTLEGROUND                   = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_WHISPER                  = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_GUILD                    = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_OFFICER                  = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_PARTY                    = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_RAID                     = UNKNOWN_OPCODE,
        CMSG_ADDON_MESSAGE_BATTLEGROUND             = UNKNOWN_OPCODE,

        // MOVEMENT OPCODES
        SMSG_MOVES                                  = UNKNOWN_OPCODE,
        // Movement Speed Opcodes
        SMSG_MOVE_UPDATE_RUN_SPEED                         = UNKNOWN_OPCODE, /* old 0x0CD, */
        SMSG_MOVE_UPDATE_RUN_BACK_SPEED                    = UNKNOWN_OPCODE, /* old 0x0CF, */
        SMSG_MOVE_UPDATE_FLIGHT_SPEED                      = UNKNOWN_OPCODE, /* old 0x37E, */
        SMSG_MOVE_UPDATE_FLIGHT_BACK_SPEED                 = UNKNOWN_OPCODE, /* old 0x380, */
        SMSG_MOVE_UPDATE_WALK_SPEED                        = UNKNOWN_OPCODE, /* old 0x0D1, */
        SMSG_MOVE_UPDATE_SWIM_SPEED                        = UNKNOWN_OPCODE, /* old 0x0D3, */
        SMSG_MOVE_UPDATE_SWIM_BACK_SPEED                   = UNKNOWN_OPCODE, /* old 0x0D5, */
        SMSG_MOVE_UPDATE_TURN_RATE                         = UNKNOWN_OPCODE, /* old 0x0D8, */
        SMSG_MOVE_UPDATE_PITCH_RATE                        = UNKNOWN_OPCODE, /* old 0x45B, */
        SMSG_MOVE_UPDATE_COLLISION_HEIGHT                  = UNKNOWN_OPCODE, /* old 0x518, */
        // Movement Opcodes
        CMSG_MOVE_START_FORWARD                         = UNKNOWN_OPCODE, /* old 0x0B5, */
        CMSG_MOVE_START_BACKWARD                        = UNKNOWN_OPCODE, /* old 0x0B6, */
        CMSG_MOVE_STOP                                  = UNKNOWN_OPCODE, /* old 0x0B7, */
        CMSG_MOVE_START_STRAFE_LEFT                     = UNKNOWN_OPCODE, /* old 0x0B8, */
        CMSG_MOVE_START_STRAFE_RIGHT                    = UNKNOWN_OPCODE, /* old 0x0B9, */
        CMSG_MOVE_STOP_STRAFE                           = UNKNOWN_OPCODE, /* old 0x0BA, */
        CMSG_MOVE_START_ASCEND                          = UNKNOWN_OPCODE, /* old 0x359, */
        CMSG_MOVE_START_DESCEND                         = UNKNOWN_OPCODE, /* old 0x3A7, */
        CMSG_MOVE_STOP_ASCEND                           = UNKNOWN_OPCODE, /* old 0x35A, */
        CMSG_MOVE_JUMP                                  = UNKNOWN_OPCODE, /* old 0x0BB, */
        CMSG_MOVE_START_TURN_LEFT                       = UNKNOWN_OPCODE, /* old 0x0BC, */
        CMSG_MOVE_START_TURN_RIGHT                      = UNKNOWN_OPCODE, /* old 0x0BD, */
        CMSG_MOVE_STOP_TURN                             = UNKNOWN_OPCODE, /* old 0x0BE, */
        CMSG_MOVE_START_PITCH_UP                        = UNKNOWN_OPCODE, /* old 0x0BF, */
        CMSG_MOVE_START_PITCH_DOWN                      = UNKNOWN_OPCODE, /* old 0x0C0, */
        CMSG_MOVE_STOP_PITCH                            = UNKNOWN_OPCODE, /* old 0x0C1, */
        CMSG_MOVE_SET_RUN_MODE                          = UNKNOWN_OPCODE, /* old 0x0C2, */
        CMSG_MOVE_SET_WALK_MODE                         = UNKNOWN_OPCODE, /* old 0x0C3, */
        CMSG_MOVE_SET_PITCH                             = UNKNOWN_OPCODE, /* old 0x0DB, */
        CMSG_MOVE_START_SWIM                            = UNKNOWN_OPCODE, /* old 0x0CA, */
        CMSG_MOVE_STOP_SWIM                             = UNKNOWN_OPCODE, /* old 0x0CB, */
        //MSG_MOVE_TOGGLE_GRAVITY                         = UNKNOWN_OPCODE, /* old 0x4D2, */
        //MSG_MOVE_TOGGLE_COLLISION                       = UNKNOWN_OPCODE,
        //MSG_MOVE_TOGGLE_WATER_WALK                      = UNKNOWN_OPCODE, /* old 0x2B1, */
        //MSG_MOVE_TOGGLE_CAN_FLY                         = UNKNOWN_OPCODE, /* old 0x3AD, */
        //MSG_MOVE_TOGGLE_FEATHER_FALL                    = UNKNOWN_OPCODE, /* old 0x2B0, */
        //MSG_MOVE_TOGGLE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY = UNKNOWN_OPCODE, /* old 0x34A, */
        //MSG_MOVE_HOVER                                  = UNKNOWN_OPCODE, /* old 0x0F7, */
        //MSG_MOVE_ROOT                                   = UNKNOWN_OPCODE, /* old 0x0EC, */
        //MSG_MOVE_UNROOT                                 = UNKNOWN_OPCODE, /* old 0x0ED, */
        CMSG_MOVE_HEARTBEAT                             = UNKNOWN_OPCODE, /* old 0x0EE, */
        CMSG_MOVE_FALL_LAND                             = UNKNOWN_OPCODE, /* old 0x0C9, */
        CMSG_MOVE_SET_FACING                            = UNKNOWN_OPCODE, /* old 0x0DA, */
        //MSG_MOVE_STOP_FLIGHT                            = UNKNOWN_OPCODE,
        //MSG_MOVE_START_FLIGHT                           = UNKNOWN_OPCODE,
        CMSG_MOVE_SET_FLY                               = UNKNOWN_OPCODE, /* old 0x346, */

        SMSG_MOVE_TELEPORT                              = UNKNOWN_OPCODE, /* old 0x0C5, */
        SMSG_MOVE_UPDATE                                = UNKNOWN_OPCODE,
        SMSG_MOVE_UPDATE_TELEPORT                       = UNKNOWN_OPCODE,
        SMSG_MOVE_UPDATE_KNOCK_BACK                     = UNKNOWN_OPCODE, /* old 0x0F1, */
        // Spline Speed Opcodes
        SMSG_MOVE_SPLINE_SET_RUN_SPEED                  = UNKNOWN_OPCODE, /* old 0x2FE, */
        SMSG_MOVE_SPLINE_SET_RUN_BACK_SPEED             = UNKNOWN_OPCODE, /* old 0x2FF, */
        SMSG_MOVE_SPLINE_SET_SWIM_SPEED                 = UNKNOWN_OPCODE, /* old 0x300, */
        SMSG_MOVE_SPLINE_SET_SWIM_BACK_SPEED            = UNKNOWN_OPCODE, /* old 0x302, */
        SMSG_MOVE_SPLINE_SET_FLIGHT_SPEED               = UNKNOWN_OPCODE, /* old 0x385, */
        SMSG_MOVE_SPLINE_SET_FLIGHT_BACK_SPEED          = UNKNOWN_OPCODE, /* old 0x386, */
        SMSG_MOVE_SPLINE_SET_WALK_SPEED                 = UNKNOWN_OPCODE, /* old 0x301, */
        SMSG_MOVE_SPLINE_SET_TURN_RATE                  = UNKNOWN_OPCODE, /* old 0x303, */
        SMSG_MOVE_SPLINE_SET_PITCH_RATE                 = UNKNOWN_OPCODE, /* old 0x45E, */
        // Spline Opcodes
        SMSG_MOVE_SPLINE_START_SWIM                     = UNKNOWN_OPCODE, /* old 0x30B, */
        SMSG_MOVE_SPLINE_STOP_SWIM                      = UNKNOWN_OPCODE, /* old 0x30C, */
        SMSG_MOVE_SPLINE_SET_FLYING                     = UNKNOWN_OPCODE, /* old 0x422, */
        SMSG_MOVE_SPLINE_UNSET_FLYING                   = UNKNOWN_OPCODE, /* old 0x423, */
        SMSG_MOVE_SPLINE_SET_FEATHER_FALL               = UNKNOWN_OPCODE, /* old 0x305, */
        SMSG_MOVE_SPLINE_SET_NORMAL_FALL                = UNKNOWN_OPCODE, /* old 0x306, */
        SMSG_MOVE_SPLINE_ROOT                           = UNKNOWN_OPCODE, /* old 0x31A, */
        SMSG_MOVE_SPLINE_UNROOT                         = UNKNOWN_OPCODE, /* old 0x304, */
        SMSG_MOVE_SPLINE_SET_WALK_MODE                  = UNKNOWN_OPCODE, /* old 0x30E, */
        SMSG_MOVE_SPLINE_SET_RUN_MODE                   = UNKNOWN_OPCODE, /* old 0x30D, */
        SMSG_MOVE_SPLINE_DISABLE_GRAVITY                = UNKNOWN_OPCODE, /* old 0x4D3, */
        SMSG_MOVE_SPLINE_ENABLE_GRAVITY                 = UNKNOWN_OPCODE, /* old 0x4D4, */
        SMSG_MOVE_SPLINE_SET_HOVER                      = UNKNOWN_OPCODE, /* old 0x307, */
        SMSG_MOVE_SPLINE_UNSET_HOVER                    = UNKNOWN_OPCODE, /* old 0x308, */
        SMSG_MOVE_SPLINE_ENABLE_COLLISION               = UNKNOWN_OPCODE,
        SMSG_MOVE_SPLINE_DISABLE_COLLISION              = UNKNOWN_OPCODE,
        SMSG_MOVE_SPLINE_SET_WATER_WALK                 = UNKNOWN_OPCODE, /* old 0x309, */
        SMSG_MOVE_SPLINE_SET_LAND_WALK                  = UNKNOWN_OPCODE, /* old 0x30A, */
        // Force Opcodes
        SMSG_MOVE_DISABLE_GRAVITY                       = UNKNOWN_OPCODE, /* old 0x4CE, */
        SMSG_MOVE_ENABLE_GRAVITY                        = UNKNOWN_OPCODE, /* old 0x4D0, */
        SMSG_MOVE_SET_COLLISION_HEIGHT                  = UNKNOWN_OPCODE, /* old 0x516, */ // float, byte
        SMSG_MOVE_ENABLE_TRANSITION_BETWEEN_SWIM_AND_FLY = UNKNOWN_OPCODE, /* old 0x33E, */
        SMSG_MOVE_DISABLE_TRANSITION_BETWEEN_SWIM_AND_FLY = UNKNOWN_OPCODE, /* old 0x33F, */
        SMSG_MOVE_SET_CAN_FLY                           = UNKNOWN_OPCODE, /* old 0x343, */
        SMSG_MOVE_UNSET_CAN_FLY                         = UNKNOWN_OPCODE, /* old 0x344, */
        SMSG_MOVE_SET_VEHICLE_REC_ID                    = UNKNOWN_OPCODE, /* old 0x23F, */ // uint32
        SMSG_MOVE_SET_FEATHER_FALL                      = UNKNOWN_OPCODE, /* old 0x0F2, */
        SMSG_MOVE_SET_NORMAL_FALL                       = UNKNOWN_OPCODE, /* old 0x0F3, */
        SMSG_MOVE_SET_WATER_WALK                        = UNKNOWN_OPCODE, /* old 0x0DE, */
        SMSG_MOVE_SET_LAND_WALK                         = UNKNOWN_OPCODE, /* old 0x0DF, */
        SMSG_MOVE_ENABLE_COLLISION                      = UNKNOWN_OPCODE,
        SMSG_MOVE_DISABLE_COLLISION                     = UNKNOWN_OPCODE,
        SMSG_MOVE_SET_HOVERING                          = UNKNOWN_OPCODE, /* old 0x0F4, */
        SMSG_MOVE_UNSET_HOVERING                        = UNKNOWN_OPCODE, /* old 0x0F5, */
        SMSG_MOVE_ROOT                                  = UNKNOWN_OPCODE, /* old 0x0E8, */
        SMSG_MOVE_UNROOT                                = UNKNOWN_OPCODE, /* old 0x0EA, */
        SMSG_MOVE_SET_WALK_SPEED                        = UNKNOWN_OPCODE, /* old 0x2DA, */ // float
        SMSG_MOVE_SET_SWIM_BACK_SPEED                   = UNKNOWN_OPCODE, /* old 0x2DC, */ // float
        SMSG_MOVE_SET_RUN_SPEED                         = UNKNOWN_OPCODE, /* old 0x0E2, */ // float
        SMSG_MOVE_SET_RUN_BACK_SPEED                    = UNKNOWN_OPCODE, /* old 0x0E4, */ // float
        SMSG_MOVE_SET_SWIM_SPEED                        = UNKNOWN_OPCODE, /* old 0x0E6, */ // float
        SMSG_MOVE_SET_FLIGHT_SPEED                      = UNKNOWN_OPCODE, /* old 0x381, */ // float
        SMSG_MOVE_SET_FLIGHT_BACK_SPEED                 = UNKNOWN_OPCODE, /* old 0x383, */ // float
        SMSG_MOVE_SET_PITCH_RATE                        = UNKNOWN_OPCODE, /* old 0x45C, */ // float
        SMSG_MOVE_SET_TURN_RATE                         = UNKNOWN_OPCODE, /* old 0x2DE, */ // float
        SMSG_MOVE_KNOCK_BACK                            = UNKNOWN_OPCODE, /* old 0x0EF, */ // float x4
        SMSG_SET_PLAY_HOVER_ANIM                        = UNKNOWN_OPCODE,
        // Ack Opcodes
        CMSG_MOVE_GRAVITY_DISABLE_ACK                   = UNKNOWN_OPCODE, /* old 0x4CF, */
        CMSG_MOVE_GRAVITY_ENABLE_ACK                    = UNKNOWN_OPCODE, /* old 0x4D1, */
        CMSG_MOVE_SET_COLLISION_HEIGHT_ACK              = UNKNOWN_OPCODE, /* old 0x517, */
        CMSG_MOVE_ENABLE_SWIM_TO_FLY_TRANS_ACK          = UNKNOWN_OPCODE, /* old 0x340, */
        CMSG_MOVE_SET_CAN_FLY_ACK                       = UNKNOWN_OPCODE, /* old 0x345, */
        CMSG_MOVE_SET_VEHICLE_REC_ID_ACK                = UNKNOWN_OPCODE, /* old 0x240, */
        CMSG_MOVE_FEATHER_FALL_ACK                      = UNKNOWN_OPCODE, /* old 0x2CF, */
        CMSG_MOVE_WATER_WALK_ACK                        = UNKNOWN_OPCODE, /* old 0x2D0, */
        CMSG_MOVE_FORCE_ROOT_ACK                        = UNKNOWN_OPCODE, /* old 0x0E9, */
        CMSG_MOVE_FORCE_UNROOT_ACK                      = UNKNOWN_OPCODE, /* old 0x0EB, */
        CMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK            = UNKNOWN_OPCODE, /* old 0x0E3, */
        CMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK       = UNKNOWN_OPCODE, /* old 0x0E5, */
        CMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK           = UNKNOWN_OPCODE, /* old 0x2DB, */
        CMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK           = UNKNOWN_OPCODE, /* old 0x0E7, */
        CMSG_MOVE_FORCE_SWIM_BACK_SPEED_CHANGE_ACK      = UNKNOWN_OPCODE, /* old 0x2DD, */
        CMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK         = UNKNOWN_OPCODE, /* old 0x382, */
        CMSG_MOVE_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK    = UNKNOWN_OPCODE, /* old 0x384, */
        CMSG_MOVE_FORCE_PITCH_RATE_CHANGE_ACK           = UNKNOWN_OPCODE, /* old 0x45D, */
        CMSG_MOVE_FORCE_TURN_RATE_CHANGE_ACK            = UNKNOWN_OPCODE, /* old 0x2DF, */
        CMSG_MOVE_KNOCK_BACK_ACK                        = UNKNOWN_OPCODE, /* old 0x0F0, */
        CMSG_MOVE_TELEPORT_ACK                          = UNKNOWN_OPCODE, /* old 0x0C7, */
        CMSG_MOVE_HOVER_ACK                             = UNKNOWN_OPCODE, /* old 0x0F6, */
        CMSG_MOVE_TOGGLE_COLLISION_ACK                  = UNKNOWN_OPCODE, // unsure CMSG_MOVE_TOGGLE_COLLISION_CHEAT

        CMSG_MOVE_SET_RELATIVE_POSITION                 = UNKNOWN_OPCODE, /* old 0x0E1, */
        CMSG_WORLD_PORT_RESPONSE                        = UNKNOWN_OPCODE, /* old 0x0DC, */
        SMSG_MOVE_SKIP_TIME                             = UNKNOWN_OPCODE, /* old 0x319, */
        CMSG_MOVE_TIME_SKIPPED                          = UNKNOWN_OPCODE, /* old 0x2CE, */
        SMSG_MOVE_SET_ACTIVE_MOVER                      = UNKNOWN_OPCODE,
        CMSG_MOVE_TELEPORT_CHEAT                        = UNKNOWN_OPCODE,
        CMSG_MOVE_CHARM_TELEPORT_CHEAT                  = UNKNOWN_OPCODE,
        SMSG_MOVE_SET_COMPOUND_STATE                    = UNKNOWN_OPCODE,

        [Description("Jam Opcode. RAID_SUMMON_FAILED_*")]
        SMSG_SUMMON_RAID_MEMBER_VALIDATE_FAILED         = UNKNOWN_OPCODE,
        [Description("EVENT_CHAT_SERVER_RECONNECTED. handler: CGChat* this; m_chatServerDown = 0; RejoinChannels(); ReregisterAddonMessagePrefixes();")]
        SMSG_CHAT_SERVER_RECONNECTED                    = UNKNOWN_OPCODE,
        [Description("Script_RegisterAddonPrefix. Introduced in patch 4.1.0.")]
        CMSG_REGISTER_ADDON_PREFIXES                    = UNKNOWN_OPCODE,
        [Description("Sent in CGChat::ReregisterAddonMessagePrefixes. Introduced in patch 4.1.0.")]
        CMSG_UNREGISTER_ALL_ADDON_PREFIXES              = UNKNOWN_OPCODE,

        [Description("packed: uint64 guild, uint64 player")]
        CMSG_GUILD_GET_ROSTER                           = UNKNOWN_OPCODE, /* old 0x089, */
        SMSG_GUILD_ROSTER                               = UNKNOWN_OPCODE, /* old 0x08A, */

        SMSG_ALL_ACHIEVEMENT_DATA                       = UNKNOWN_OPCODE,
        SMSG_RESPOND_INSPECT_ACHIEVEMENTS               = UNKNOWN_OPCODE,

        SMSG_AUCTION_LIST_RESULT                        = UNKNOWN_OPCODE, /* old 0x25C, */

        [Description("packed: uint64 guild")]
        CMSG_GUILD_GET_RANKS                            = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_LOAD_EQUIPMENT_SET on init. Sent after SMSG[_COMPRESSED]_GUILD_ROSTER during playtime")]
        SMSG_GUILD_RANKS                                = UNKNOWN_OPCODE,

        [Description("Sent in lua RequestGuildPartyState. packed: uint64 player, uint64 guild")]
        CMSG_REQUEST_GUILD_PARTY_STATE                  = UNKNOWN_OPCODE,
        [Description("triggers event GUILD_PARTY_STATE_UPDATED. local inGuildParty, numGuildPresent, numGuildRequired, xpMultiplier = InGuildParty();. uint8 InGuildParty (fulfill), uint32 numGuildPresent, uint32 numGuildRequired, float xpMultiplier")]
        SMSG_GUILD_PARTY_STATE                          = UNKNOWN_OPCODE,

        [Description("Sent on connection termination. Introduced somewhere between 4.0.3 and 4.0.6.")]
        CMSG_LOG_DISCONNECT                             = UNKNOWN_OPCODE,

        [Description("uint64 guild")]
        CMSG_GUILD_REQUEST_GUILD_XP                     = UNKNOWN_OPCODE,
        SMSG_GUILD_SEND_GUILD_XP                        = UNKNOWN_OPCODE,
        [Description("uint64 value. COMBATLOG_GUILD_XPGAIN, Jam Opcode")]
        SMSG_GUILD_XP_EARNED                            = UNKNOWN_OPCODE,
        [Description("uint64 guild")]
        CMSG_GUILD_QUERY_NEWS                           = UNKNOWN_OPCODE,
        SMSG_GUILD_NEWS                                 = UNKNOWN_OPCODE,
        SMSG_GUILD_NEWS_DELETED                         = UNKNOWN_OPCODE,
        [Description("uint64 guild")]
        CMSG_GUILD_REQUEST_MAX_DAILY_XP                 = UNKNOWN_OPCODE,
        [Description("uint64 limit")]
        SMSG_GUILD_SEND_MAX_DAILY_XP                    = UNKNOWN_OPCODE,
        CMSG_GUILD_QUERY_RECIPES                        = UNKNOWN_OPCODE,
        CMSG_GUILD_QUERY_MEMBER_RECIPES                 = UNKNOWN_OPCODE,
        SMSG_GUILD_MEMBER_RECIPES                       = UNKNOWN_OPCODE,
        SMSG_GUILD_KNOWN_RECIPES                        = UNKNOWN_OPCODE,
        CMSG_GUILD_QUERY_MEMBERS_FOR_RECIPE             = UNKNOWN_OPCODE,
        SMSG_GUILD_MEMBERS_WITH_RECIPE                  = UNKNOWN_OPCODE,
        CMSG_GUILD_CHALLENGE_UPDATE_REQUEST             = UNKNOWN_OPCODE,
        SMSG_GUILD_CHALLENGE_UPDATE                     = UNKNOWN_OPCODE,
        SMSG_GUILD_CHALLENGE_COMPLETED                  = UNKNOWN_OPCODE,
        SMSG_GUILD_MEMBER_UPDATE_NOTE                   = UNKNOWN_OPCODE,
        SMSG_GUILD_MOVED                                = UNKNOWN_OPCODE,
        SMSG_GUILD_MOVE_STARTING                        = UNKNOWN_OPCODE,
        SMSG_GUILD_RESET                                = UNKNOWN_OPCODE,
        SMSG_GUILD_CRITERIA_DELETED                     = UNKNOWN_OPCODE,
        SMSG_GUILD_CRITERIA_UPDATE                      = UNKNOWN_OPCODE,
        CMSG_GUILD_SET_FOCUSED_ACHIEVEMENT              = UNKNOWN_OPCODE,
        SMSG_GUILD_REPUTATION_WEEKLY_CAP                = UNKNOWN_OPCODE,
        CMSG_GUILD_NEWS_UPDATE_STICKY                   = UNKNOWN_OPCODE,
        SMSG_GUILD_REPUTATION_REACTION_CHANGED          = UNKNOWN_OPCODE,
        SMSG_GUILD_ACHIEVEMENT_DELETED                  = UNKNOWN_OPCODE,
        CMSG_GUILD_GET_ACHIEVEMENT_MEMBERS              = UNKNOWN_OPCODE,
        SMSG_GUILD_ACHIEVEMENT_MEMBERS                  = UNKNOWN_OPCODE,
        CMSG_REQUEST_GUILD_REWARDS_LIST                 = UNKNOWN_OPCODE,
        SMSG_GUILD_REWARD_LIST                          = UNKNOWN_OPCODE,
        CMSG_GUILD_SET_ACHIEVEMENT_TRACKING             = UNKNOWN_OPCODE,
        CMSG_GUILD_AUTO_DECLINE_INVITATION              = UNKNOWN_OPCODE,

        // guild recruiting
        [Description("EVENT_LF_GUILD_POST_UPDATED. uint8 flags, if (0x80) { uint32s, string, uint32s }. Script_GetLookingForGuildSettings. You are in a guild, and your guild is recruiting.")]
        SMSG_LF_GUILD_POST = UNKNOWN_OPCODE,
        [Description("Script_SetLookingForGuildSettings. You are in a guild, and your guild is recruiting.")]
        CMSG_LF_GUILD_SET_GUILD_POST = UNKNOWN_OPCODE,
        [Description("Script_RequestLookingForGuildSettings. You are in a guild, and your guild is recruiting.")]
        CMSG_LF_GUILD_GET_GUILD_POST = UNKNOWN_OPCODE,
        [Description("Script_RequestGuildApplicantsList. uint32 recruitUpdateTime. You are in a guild, and your guild is recruiting.")]
        CMSG_LF_GUILD_GET_RECRUITS = UNKNOWN_OPCODE,
        [Description("EVENT_LF_GUILD_RECRUITS_UPDATED. You are in a guild, and your guild is recruiting.")]
        SMSG_LF_GUILD_RECRUITS = UNKNOWN_OPCODE,
        [Description("You are in a guild, and your guild is recruiting.")]
        SMSG_LF_GUILD_APPLICANT_LIST_CHANGED = UNKNOWN_OPCODE,
        [Description("Script_RequestGuildMembership. You are not in a guild, and you are willing to join one.")]
        CMSG_LF_GUILD_ADD_RECRUIT = UNKNOWN_OPCODE,
        [Description("Script_CancelGuildMembershipRequest. You are not in a guild, and you are willing to join one.")]
        CMSG_LF_GUILD_REMOVE_RECRUIT = UNKNOWN_OPCODE,
        [Description("Script_SetLookingForGuildSettings, Script_RequestRecruitingGuildsList. You are not in a guild, and you are willing to join one.")]
        CMSG_LF_GUILD_BROWSE = UNKNOWN_OPCODE,
        [Description("EVENT_LF_GUILD_BROWSE_UPDATED. You are not in a guild, and you are willing to join one.")]
        SMSG_LF_GUILD_BROWSE = UNKNOWN_OPCODE,
        [Description("EVENT_LF_GUILD_MEMBERSHIP_LIST_CHANGED sends CMSG_LF_GUILD_GET_REQUEST_MEMBERSHIP_LIST. You are not in a guild, and you are willing to join one.")]
        SMSG_LF_GUILD_APPLICATIONS_LIST_CHANGED = UNKNOWN_OPCODE,
        [Description("Script_RequestGuildMembershipList. You are not in a guild, and you are willing to join one.")]
        CMSG_LF_GUILD_GET_APPLICATIONS = UNKNOWN_OPCODE,
        [Description("EVENT_LF_GUILD_MEMBERSHIP_LIST_UPDATED. You are not in a guild, and you are willing to join one.")]
        SMSG_LF_GUILD_APPLICATIONS = UNKNOWN_OPCODE,
        SMSG_LF_GUILD_COMMAND_RESULT = UNKNOWN_OPCODE,
        CMSG_LF_GUILD_DECLINE_RECRUIT = UNKNOWN_OPCODE,

        // archaeology
        [Description("Script_RequestArtifactCompletionHistory")]
        CMSG_REQUEST_RESEARCH_HISTORY = UNKNOWN_OPCODE,
        SMSG_SETUP_RESEARCH_HISTORY = UNKNOWN_OPCODE,
        SMSG_RESEARCH_COMPLETE = UNKNOWN_OPCODE,

        [Description("Script_InitiateRolePoll")]
        CMSG_INITIATE_ROLE_POLL = UNKNOWN_OPCODE,
        [Description("Script_UnitSetRole")]
        CMSG_SET_ROLE = UNKNOWN_OPCODE,
        SMSG_ROLE_POLL_INFORM = UNKNOWN_OPCODE,
        SMSG_ROLE_CHANGED_INFORM = UNKNOWN_OPCODE,
        [Description("Script_SpellCancelQueuedSpell")]
        CMSG_CANCEL_QUEUED_SPELL = UNKNOWN_OPCODE,
        [Description("Script_SetCemeteryPreference")]
        CMSG_SET_PREFERRED_CEMETERY = UNKNOWN_OPCODE,
        [Description("Script_PortGraveyard")]
        CMSG_PORT_GRAVEYARD = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_AUTH_RESPONSE.")]
        SMSG_HOTFIX_NOTIFY_BLOB = UNKNOWN_OPCODE,
        SMSG_HOTFIX_NOTIFY = UNKNOWN_OPCODE,
        CMSG_DB_QUERY_BULK = UNKNOWN_OPCODE,
        SMSG_DB_REPLY = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_INIT_WORLD_STATES")]
        SMSG_PHASE_SHIFT_CHANGE = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_PHASE_SHIFT_CHANGE. Jam opcode")]
        SMSG_SETUP_CURRENCY = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_PVP_CREDIT. Jam opcode")]
        SMSG_SET_CURRENCY = UNKNOWN_OPCODE,
        [Description("Sometimes sent after SMSG_SET_CURRENCY on loading")]
        SMSG_SET_MAX_WEEKLY_QUANTITY = UNKNOWN_OPCODE,
        CMSG_LOOT_CURRENCY = UNKNOWN_OPCODE,
        SMSG_CURRENCY_LOOT_REMOVED = UNKNOWN_OPCODE,
        SMSG_CURRENCY_LOOT_RESTORED = UNKNOWN_OPCODE,
        CMSG_SET_CURRENCY_FLAGS = UNKNOWN_OPCODE,
        [Description("Sent on zone switch soon after CMSG_ZONEUPDATE. Sent on timer in CGGameUI::Idle")]
        CMSG_REQUEST_CEMETERY_LIST = UNKNOWN_OPCODE,
        [Description("response to CMSG_REQUEST_CEMETERY_LIST")]
        SMSG_REQUEST_CEMETERY_LIST_RESPONSE = UNKNOWN_OPCODE,
        CMSG_REQUEST_HONOR_STATS = UNKNOWN_OPCODE,
        [Description("EVENT_INSPECT_HONOR_UPDATE. uint16 todayHK, uint16 yesterdayHK, uint8 rank, uint32 lifetimeHK")]
        SMSG_INSPECT_HONOR_STATS = UNKNOWN_OPCODE,
        [Description("uint32 achievement_id, uint64 guild, uint32 time")]
        SMSG_GUILD_ACHIEVEMENT_EARNED = UNKNOWN_OPCODE,
        [Description("Sent after SMSG_GUILD_RANKS on loading. uint32 x, for(x) uint32 time, for (x) uint32 id")]
        SMSG_ALL_GUILD_ACHIEVEMENTS = UNKNOWN_OPCODE,
        CMSG_LOADING_SCREEN_NOTIFY = UNKNOWN_OPCODE,
        [Description("CGGameUI::m_isOnTournamentRealm, CGGameUI::m_instanceDifficulty, CGGameUI::m_lastWeeklyReset, TrialLevelCap, TrialMoneyCap. Script_isOnTournamentRealm")]
        SMSG_WORLD_SERVER_INFO = UNKNOWN_OPCODE,
        [Description("uint32 for() { uint8, uint32 }")]
        SMSG_WEEKLY_SPELL_USAGE = UNKNOWN_OPCODE,
        SMSG_LAST_WEEKLY_RESET = UNKNOWN_OPCODE,
        SMSG_UPDATE_WEEKLY_SPELL_USAGE = UNKNOWN_OPCODE,
        SMSG_RESET_WEEKLY_CURRENCY = UNKNOWN_OPCODE,

        CMSG_GET_PVP_OPTIONS_ENABLED = UNKNOWN_OPCODE,
        [Description("EVENT_PVP_TYPES_ENABLED")]
        SMSG_PVP_OPTIONS_ENABLED = UNKNOWN_OPCODE,
        SMSG_RATED_BG_STATS = UNKNOWN_OPCODE,
        CMSG_REQUEST_RATED_BATTLEFIELD_INFO = UNKNOWN_OPCODE,
        CMSG_START_WAR_GAME = UNKNOWN_OPCODE,
        SMSG_BATTLEFIELD_STATUS_WAIT_FOR_GROUPS = UNKNOWN_OPCODE,
        SMSG_BATTLEFIELD_STATUS_ACTIVE = UNKNOWN_OPCODE,
        SMSG_BATTLEFIELD_STATUS_NEED_CONFIRMATION = UNKNOWN_OPCODE,
        CMSG_REQUEST_BATTLEFIELD_STATUS = UNKNOWN_OPCODE,
        SMSG_CHECK_WARGAME_ENTRY = UNKNOWN_OPCODE,
        CMSG_ACCEPT_WARGAME_INVITE = UNKNOWN_OPCODE,
        CMSG_COMMENTATOR_START_WARGAME = UNKNOWN_OPCODE,
        SMSG_COMMENTATOR_PARTY_INFO = UNKNOWN_OPCODE,
        SMSG_INSPECT_RATED_BG_STATS = UNKNOWN_OPCODE,
        SMSG_WARGAME_REQUEST_SUCCESSFULLY_SENT_TO_OPPONENT = UNKNOWN_OPCODE,
        CMSG_JOIN_RATED_BATTLEGROUND = UNKNOWN_OPCODE,
        SMSG_RATED_BATTLEFIELD_INFO = UNKNOWN_OPCODE,
        CMSG_REQUEST_RATED_BG_STATS = UNKNOWN_OPCODE,
        CMSG_REQUEST_INSPECT_RATED_BG_STATS = UNKNOWN_OPCODE,
        SMSG_RATED_BATTLEGROUND_RATING = UNKNOWN_OPCODE,
        SMSG_REQUEST_PVP_REWARDS_RESPONSE = UNKNOWN_OPCODE,
        CMSG_REQUEST_PVP_REWARDS = UNKNOWN_OPCODE,
        SMSG_SHOW_RATINGS = UNKNOWN_OPCODE,

        [Description("Sent after CMSG_AUTH_CONTINUED_SESSION or CMSG_AUTH_SESSION. Enables Nagle algorithm at server-side. Client's Jam opcode. Introduced in patch 4.1.0.")]
        CMSG_ENABLE_NAGLE = UNKNOWN_OPCODE,
        [Description("Sent on new connection after CMSG_PLAYER_LOGIN, after SMSG_RESUME_COMMS. Sent in update function of violenceLevel CVar")]
        CMSG_VIOLENCE_LEVEL = UNKNOWN_OPCODE,

        [Description("Changes character order. Introduced in patch 4.2.0.")]
        CMSG_REORDER_CHARACTERS = UNKNOWN_OPCODE,
        [Description("Introduced in patch 4.2.0. It's handler is called just before JamClientConnectionDispatch check. Handles any opcode. Possibly automatically created on server side.")]
        SMSG_COMPOUND_PACKET = UNKNOWN_OPCODE,

        [Description("Introduced in patch 4.2.0. EVENT_COMPACT_UNIT_FRAME_PROFILES_LOADED")]
        SMSG_LOAD_CUF_PROFILES = UNKNOWN_OPCODE,
        [Description("Introduced in patch 4.2.0. Script_SaveRaidProfileCopy")]
        CMSG_SAVE_CUF_PROFILES = UNKNOWN_OPCODE,

        [Description("Sent in later CGPlayer_C::PostInit")]
        CMSG_REQUEST_CATEGORY_COOLDOWNS = UNKNOWN_OPCODE,
        SMSG_CATEGORY_COOLDOWN = UNKNOWN_OPCODE,

        [Description("Clears UNIT_NPC_EMOTESTATE. Sent for example when you close in-game map. Introduced in patch 4.2")]
        CMSG_CLEAR_EMOTESTATE = UNKNOWN_OPCODE,

        SMSG_SUSPEND_TOKEN = UNKNOWN_OPCODE,
        CMSG_SUSPEND_TOKEN_RESPONSE = UNKNOWN_OPCODE,
        CMSG_REQUEST_PARTY_JOIN_UPDATES = UNKNOWN_OPCODE,
        SMSG_SPELL_INTERRUPT_LOG = UNKNOWN_OPCODE,
        SMSG_MESSAGE_BOX = UNKNOWN_OPCODE,
        SMSG_DISPLAY_GAME_ERROR = UNKNOWN_OPCODE,
        SMSG_AURA_POINTS_DEPLETED = UNKNOWN_OPCODE,
        SMSG_AVERAGE_ITEM_LEVEL_INFORM = UNKNOWN_OPCODE,
        CMSG_OBJECT_UPDATE_RESCUED = UNKNOWN_OPCODE,
        CMSG_OBJECT_UPDATE_FAILED = UNKNOWN_OPCODE,
        SMSG_SUPPRESS_NPC_GREETINGS = UNKNOWN_OPCODE,
        CMSG_GENERATE_RANDOM_CHARACTER_NAME = UNKNOWN_OPCODE,
        SMSG_GENERATE_RANDOM_CHARACTER_NAME_RESULT = UNKNOWN_OPCODE,
        SMSG_SET_FORGE_MASTER = UNKNOWN_OPCODE,
        CMSG_CLEAR_RAID_MARKER = UNKNOWN_OPCODE,
        SMSG_RAID_MARKERS_CHANGED = UNKNOWN_OPCODE,
        SMSG_RUNE_REGEN_DEBUG = UNKNOWN_OPCODE,
        SMSG_RESTRICTED_ACCOUNT_WARNING = UNKNOWN_OPCODE,
        SMSG_DISENCHANT_CREDIT = UNKNOWN_OPCODE,
        SMSG_ADD_ITEM_PASSIVE = UNKNOWN_OPCODE,
        SMSG_REMOVE_ITEM_PASSIVE = UNKNOWN_OPCODE,
        SMSG_SEND_ITEM_PASSIVES = UNKNOWN_OPCODE,
        CMSG_REFORGE_ITEM = UNKNOWN_OPCODE,
        SMSG_REFORGE_RESULT = UNKNOWN_OPCODE,
        SMSG_NOTIFY_MONEY = UNKNOWN_OPCODE,
        SMSG_STREAMING_MOVIES = UNKNOWN_OPCODE,
        SMSG_START_TIMER = UNKNOWN_OPCODE,
        SMSG_DIFFERENT_INSTANCE_FROM_PARTY = UNKNOWN_OPCODE,
        SMSG_TIME_ADJUSTMENT = UNKNOWN_OPCODE,
        CMSG_TIME_ADJUSTMENT_RESPONSE = UNKNOWN_OPCODE,
        CMSG_USED_FOLLOW = UNKNOWN_OPCODE,
        SMSG_CLEAR_BOSS_EMOTES = UNKNOWN_OPCODE,
        SMSG_QUEST_COMPLETION_NPC_RESPONSE = UNKNOWN_OPCODE,

        // 4.3 jam new
        SMSG_GUILD_FLAGGED_FOR_RENAME = UNKNOWN_OPCODE,
        CMSG_GUILD_CHANGE_NAME_REQUEST = UNKNOWN_OPCODE,
        SMSG_GUILD_CHANGE_NAME_RESULT = UNKNOWN_OPCODE,
        SMSG_GUILD_MEMBER_DAILY_RESET = UNKNOWN_OPCODE,
        CMSG_GUILD_REPLACE_GUILD_MASTER = UNKNOWN_OPCODE,
        CMSG_GUILD_INVITE_BY_NAME = UNKNOWN_OPCODE,
        SMSG_GUILD_BANK_QUERY_RESULTS = UNKNOWN_OPCODE, // ???
        SMSG_GUILD_ROSTER_UPDATE = UNKNOWN_OPCODE, // ???

        // DF
        CMSG_DF_PROPOSAL_RESPONSE = UNKNOWN_OPCODE,
        CMSG_DF_JOIN = UNKNOWN_OPCODE,
        CMSG_DF_SET_ROLES = UNKNOWN_OPCODE,
        CMSG_DF_TELEPORT = UNKNOWN_OPCODE,
        CMSG_DF_BOOT_PLAYER_VOTE = UNKNOWN_OPCODE,
        CMSG_DF_GET_SYSTEM_INFO = UNKNOWN_OPCODE,
        CMSG_DF_SET_COMMENT = UNKNOWN_OPCODE,
        CMSG_DF_GET_JOIN_STATUS = UNKNOWN_OPCODE,
        CMSG_DF_LEAVE = UNKNOWN_OPCODE,
        CMSG_DF_SEARCH_JOIN = UNKNOWN_OPCODE,
        CMSG_DF_SEARCH_LEAVE = UNKNOWN_OPCODE,
        SMSG_SET_DF_FAST_LAUNCH_RESULT = UNKNOWN_OPCODE,

        SMSG_LFG_UPDATE_STATUS = UNKNOWN_OPCODE,
        CMSG_SET_EVERYONE_IS_ASSISTANT = UNKNOWN_OPCODE,
        SMSG_RESET_COMPRESSION_CONTEXT = UNKNOWN_OPCODE,
        SMSG_CUSTOM_LOAD_SCREEN = UNKNOWN_OPCODE, // ???
        SMSG_GAME_EVENT_DEBUG_LOG = UNKNOWN_OPCODE,
        SMSG_SERVER_PERF = UNKNOWN_OPCODE, // ???
        SMSG_FLOOD_DETECTED = UNKNOWN_OPCODE,
        SMSG_AREA_TRIGGER_MOVEMENT_UPDATE = UNKNOWN_OPCODE,
        SMSG_LFG_SLOT_INVALID = UNKNOWN_OPCODE,
        SMSG_XP_GAIN_ABORTED = UNKNOWN_OPCODE,
        SMSG_CHAT_IGNORED_ACCOUNT_MUTED = UNKNOWN_OPCODE,
        SMSG_MAP_OBJ_EVENTS = UNKNOWN_OPCODE,
        SMSG_DUMP_RIDE_TICKETS_RESPONSE = UNKNOWN_OPCODE,
        SMSG_UPDATE_SERVER_PLAYER_POSITION = UNKNOWN_OPCODE,
        CMSG_BATTLEFIELD_LEAVE = UNKNOWN_OPCODE,
        SMSG_CLEAR_COOLDOWNS = UNKNOWN_OPCODE,
        SMSG_LOOT_CONTENTS = UNKNOWN_OPCODE,
        SMSG_PRINT_NOTIFICATION = UNKNOWN_OPCODE,
        SMSG_GAME_OBJECT_ACTIVATE_ANIM_KIT = UNKNOWN_OPCODE,
        SMSG_LFG_UPDATE_STATUS_NONE = UNKNOWN_OPCODE,
        SMSG_ACCOUNT_INFO_RESPONSE = UNKNOWN_OPCODE,
        CMSG_UNLEARN_SPECIALIZATION = UNKNOWN_OPCODE,
        SMSG_FAILED_PLAYER_CONDITION = UNKNOWN_OPCODE,
        SMSG_DONT_AUTO_PUSH_SPELLS_TO_ACTION_BAR = UNKNOWN_OPCODE,
        SMSG_UPDATE_DUNGEON_ENCOUNTER_FOR_LOOT = UNKNOWN_OPCODE,
        SMSG_UPDATE_ACTION_BUTTONS = UNKNOWN_OPCODE,
        SMSG_MISSILE_CANCEL = UNKNOWN_OPCODE,
        SMSG_ITEM_EXPIRE_PURCHASE_REFUND = UNKNOWN_OPCODE,

        SMSG_VOID_ITEM_SWAP_RESPONSE = UNKNOWN_OPCODE,
        CMSG_VOID_STORAGE_TRANSFER = UNKNOWN_OPCODE,
        SMSG_VOID_TRANSFER_RESULT = UNKNOWN_OPCODE,
        CMSG_UNLOCK_VOID_STORAGE = UNKNOWN_OPCODE,
        CMSG_SWAP_VOID_ITEM = UNKNOWN_OPCODE,
        CMSG_QUERY_VOID_STORAGE = UNKNOWN_OPCODE,
        SMSG_VOID_STORAGE_FAILED = UNKNOWN_OPCODE,
        SMSG_VOID_STORAGE_CONTENTS = UNKNOWN_OPCODE,
        SMSG_VOID_STORAGE_TRANSFER_CHANGES = UNKNOWN_OPCODE,

        CMSG_TRANSMOGRIFY_ITEMS = UNKNOWN_OPCODE,

        CMSG_GUILD_MEMBER_SEND_SOR_REQUEST = UNKNOWN_OPCODE,
        CMSG_SEND_SOR_REQUEST_VIA_BNET_ACCOUNT_ID = UNKNOWN_OPCODE,
        CMSG_SEND_SOR_REQUEST_VIA_ADDRESS = UNKNOWN_OPCODE,
        SMSG_SOR_START_EXPERIENCE_INCOMPLETE = UNKNOWN_OPCODE,
    }
/*
        [Description("")]
*/
}
