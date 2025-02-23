﻿namespace CommanderCSLibrary.Shared
{
    public class RemoteObjectManager
    {
        public static RemoteObjectManager instance
        {
            get
            {
                RemoteObjectManager remoteObjectManager = new()
                {
                    regulation = Regulation.Regulation.Create(),
                };

                return remoteObjectManager;
            }
        }

        public Regulation.Regulation regulation;

        public static class CommandIdsForChatting
        {
            public const string CheckChattingMsg = "checkMsg";
            public const string SendChatMsgChatting = "sendMsg";
            public const string SendGuildMsgChatting = "sendGuildMsg";
            public const string SendWaitChannelMsg = "waitChannel";
            public const string SendWaitChatMsg = "waitChat";
            public const string SendWaitGuildMsg = "waitGuild";
            public const string SendWhisperMsgChatting = "sendWhisperMsg";
        }

        public static class DefineDataTable
        {
            public const int ANNIHILATE_END_TURN = 8;
            public const int ANNIHILATE_HELL_OPEN = 1;
            public const int ANNIHILATE_PILOT_CLASS_LIMIT = 3;
            public const int ARENA_3WAVE_END_TURN = 58;
            public const int ARENA_3WAVE_MATCHING_REFRESH_COOL_TIME = 10;
            public const int ARENA_3WAVE_OPEN_LEVEL = 35;
            public const int ARENA_END_TURN = 24;
            public const int ARENA_NONPERCENT = 30;
            public const int ARENA_PLACEMENT_MATCH = 5;
            public const int ARENA_POINT_LOSE = 1;
            public const int ARENA_POINT_WIN = 2;
            public const int ARENA_RANK_LOSING = -1;
            public const int ARENA_RANK_LOSING_MAX = -3;
            public const int ARENA_RANK_WINNING = 1;
            public const int ARENA_RANK_WINNING_MAX = 5;
            public const int BASE_DECK_COUNT = 5;
            public const int BATTLEEVENT_CLOSE_DELAY = 0;
            public const int BATTLE_CLEAR_MAX_COUNT = 50;
            public const int BATTLE_ENTRY_BULLET_PERCENT = 25;
            public const int BATTLE_EVENT_OIL_DEFAULT = 10;
            public const int BATTLE_EVENT_RAID_DEFAULT = 10;
            public const int BATTLE_EVENT_RAID_LIST_OUT_TIME = 86400;
            public const int BATTLE_EVENT_RAID_MAX_LEVEL = 30;
            public const int BATTLE_MAX_PROCESS_TIME = 300;
            public const int BATTLE_RAID_TURN = 18;
            public const int BATTLE_SHARE_DELAY = 60;
            public const string BATTLE_STRUGGLE_END_TIME = "19:00";
            public const string BATTLE_STRUGGLE_START_TIME = "15:00";
            public const int CASH_CONSUME_SORT = 0;
            public const int CHAT_BLOCK_USER_MAX_COUNT = 100;
            public const int COMMANDER_EMPLOY_TRANSMISSION_MEDAL_PERCENT = 70;
            public const int COOPERATE_BATTLE_COUNT = 1;
            public const string COOPERATE_BATTLE_COUNT_RESET_TIME = "24:00:00";
            public const string COOPERATE_BATTLE_END_TIME = "23:00:00";
            public const int COOPERATE_BATTLE_OPEN_GUILD_LEVEL = 1;
            public const int COOPERATE_BATTLE_STEP = 3;
            public const int DAILYBATTLE_END_TURN = 5;
            public const int DAILYMISSION_MIN_VIP = 10;
            public const int DATE_FAVOR_UP = 10;
            public const int DATE_PRESENT_COUNT = 600;
            public const int DECK_PLUS_CASH = 1200;
            public const int DECK_PLUS_CASH_VALUE = 200;
            public const int DORMITORY_BASE_COSTUME = 1;
            public const int DORMITORY_BASE_WALLPAPER = 1;
            public const int DORMITORY_COMMODITY_INDIVIDUAL_LIMIT = 99;
            public const int DORMITORY_INVENTORY_ADD = 10;
            public const int DORMITORY_INVENTORY_BASE = 50;
            public const int DORMITORY_INVENTORY_CASH = 100;
            public const int DORMITORY_INVENTORY_LIMIT = 100;
            public const int DORMITORY_ITEM_LIMIT = 999;
            public const int DORMITORY_MARK_MAX = 50;
            public const int DORMITORY_NAME_CHANGE_CASH = 50;
            public const int DORMITORY_PEOPLE_MAX = 5;
            public const int DORMITORY_POINT_BASE = 1;
            public const int DORMITORY_POINT_RATE = 5;
            public const int DORMITORY_UPGRADE_MAX = 10;
            public const int DORMITORY_USER_POINT_BASE = 5000;
            public const int ENEMY_DIFFICULTY = 35;
            public const int EQUIPITEM_1SLOT_OPEN_CLASS_LIMIT = 9;
            public const int EQUIPITEM_2SLOT_OPEN_CLASS_LIMIT = 11;
            public const int EQUIPITEM_3SLOT_OPEN_CLASS_LIMIT = 13;
            public const int EQUIPITEM_4SLOT_OPEN_CLASS_LIMIT = 15;
            public const int EQUIPITEM_LEVEL_LIMIT = 99;
            public const int EVENTBATTLE_GACHA_MAX_COUNT = 30;
            public const int EVENTBATTLE_GACHA_MIN_COUNT = 10;
            public const int FIRST_PAYMENT_OPEN = 1;
            public const int FIRST_START_BULLET = 60;
            public const int FIRST_START_CASH = 0;
            public const int FIRST_START_GET_COMMANDER_ID = 1;
            public const int FIRST_START_GOLD = 5000;
            public const int FIRST_START_SKILL_POINT = 100;
            public const int FIRST_START_TRAINING_TICKET = 0;
            public const string FREE_GACHA_RECHARGE_TIME = "6:00";
            public const int GOLD_CONSUME_SORT = 0;
            public const int GUILD_BOARD_PAGE_COUNT = 3;
            public const int GUILD_BOARD_PAGE_DELAY = 5;
            public const int GUILD_BOARD_REFRESH_DELAY = 3;
            public const int GUILD_BOARD_SEND_DELAY = 3;
            public const int GUILD_CHAT_COUNT = 1;
            public const int GUILD_CHAT_DELAY = 1;
            public const int GUILD_CREATION_PRICE = 300;
            public const int GUILD_DISPATCH_LIMIT = 1;
            public const int GUILD_EMBLEM_CHANGE_PRICE = 100;
            public const int GUILD_EMBLEM_COUNT = 6;
            public const int GUILD_EMPLOY_LIMIT = 5;
            public const int GUILD_EXPIRE_COUNT = 5;
            public const int GUILD_LIST_COUNT = 20;
            public const int GUILD_MAILBOX_REWARD_TIME = 86400;
            public const int GUILD_MAX_AIDE = 2;
            public const int GUILD_NAME_CHANGE_PRICE = 500;
            public const int GUILD_OCCUPY_BATTLE_END_TURN = 18;
            public const int GUILD_OCCUPY_DEFEAT_REWARD = 103;
            public const int GUILD_OCCUPY_DEFEAT_SCORE = -50;
            public const int GUILD_OCCUPY_GAPSCORE_MAX = 50;
            public const int GUILD_OCCUPY_LEVEL = 2;
            public const int GUILD_OCCUPY_PREMIUM_TEAM = 2;
            public const int GUILD_OCCUPY_PREMIUM_TEAM_PRICE = 5;
            public const int GUILD_OCCUPY_QUICKMOVE = 50;
            public const int GUILD_OCCUPY_QUICKMOVE_PRICE = 10;
            public const int GUILD_OCCUPY_RADAR_DELAY = 60;
            public const int GUILD_OCCUPY_RADAR_PRICE = 5;
            public const int GUILD_OCCUPY_RADAR_REFRESH_DELAY = 3;
            public const int GUILD_OCCUPY_REFRESH_DELAY = 3;
            public const int GUILD_OCCUPY_TEAM = 2;
            public const int GUILD_OCCUPY_TELEPORT_PRICE = 50;
            public const int GUILD_OCCUPY_TIE_REWARD = 102;
            public const int GUILD_OCCUPY_TIE_SCORE = 50;
            public const int GUILD_OCCUPY_VICTORY_REWARD = 101;
            public const int GUILD_OCCUPY_VICTORY_SCORE = 100;
            public const int GUILD_POINT_DAILY_MAX = 800;
            public const int GUILD_PREMIUM_EMPLOY = 10;
            public const int GUILD_REQUEST_COUNT_LIMIT = 20;
            public const int GUILD_SECESSION_COUNT = 3;
            public const int GUILD_SECESSION_INSTANTLY_COUNT = 1;
            public const int GUILD_SECESSION_INSTANTLY_TIME = 3600;
            public const int GUILD_SECESSION_SAME_GUILD_COUNT = 1;
            public const int GUILD_SECESSION_SAME_GUILD_TIME = 172800;
            public const int GUILD_SECESSION_TIME = 604800;
            public const int GUILD_STRUGGLE_LIST_RANGE = 2;
            public const int MATCHING_REFRESH_CASH = 10;
            public const int MATCHING_REFRESH_COOL_TIME = 900;
            public const int NONPERCENT_ARENA = 30;
            public const int NONPERCENT_RAID = 30;
            public const int NO_GET_COMMANDER_GRADE = 23;
            public const int NO_GET_COMMANDER_LEVEL = 140;
            public const int NO_GET_COMMANDER_SKILL01 = 140;
            public const int NO_GET_COMMANDER_SKILL02 = 140;
            public const int NO_GET_COMMANDER_SKILL03 = 139;
            public const int NO_GET_COMMANDER_SKILL04 = 131;
            public const int NO_GET_COMMANDER_STAR = 5;
            public const int NPC_START_UNO = 3000000;
            public const int NPC_THUMBNAIL = 1;
            public const string NPC_USER_NAME = "npc";
            public const int PRE_DECK_COUNT = 20;
            public const int RAID_NONPERCENT = 30;
            public const int RANK_LIST_MAX_LENGTH = 30;
            public const int RETURNUSER_DATE = 28;
            public const int SENDBOX_LIST_LIMIT_TIME = 604800;
            public const int SKY_SHOP_CREATE_CASH = 900;
            public const int SKY_SHOP_OPEN_LOSE_PERCENT = 300;
            public const int SKY_SHOP_OPEN_WIN_PERCENT = 100;
            public const int SKY_SHOP_RESET_TIME = 3600;
            public const int STRONGEST_REWARD = 88002;
            public const int SUPPLEMENT_LAND_OPEN_LEVEL = 1;
            public const int TREASURE_COSTUME_RATE = 3;
            public const int TREASURE_PILOT_RATE = 10;
            public const int TUTORIAL_CASH_GACHA_COMMANDER_IDX = 2;
            public const int USER_CHANGE_NICKNAME_CASH = 100;
            public const int VIPGRADE_ANNIHILATE_RESET = 11;
            public const int VIPGRADE_BATTLESHOP_REFRESH = 13;
            public const int VIPGRADE_DISPATCH_GOLD = 7;
            public const int VIPGRADE_GACHA_DELAY_FREE = 3;
            public const int VIPGRADE_GACHA_FREE_PREMIUM = 2;
            public const string VIP_GACHA_STATS_TIME = "16:00:00";
            public const int VIP_GACHA_CASH = 800;
            public const int VIP_GACHA_COUNT = 10;
            public const int VIP_GACHA_RESET_TIME = 7;
            public const string VIPGRADE_GACHA_FREE_PREMIUM_TIME = "86400";
            public const int WARROOM_CLEAR_MAX_COUNT = 5;
            public const int TRANSCRNDENCE_MEDALS_VALUE = 10;
            public const int TRANSCRNDENCE_MEDALS_VALUE_VIP = 2;
            public const int WEAPON_ECHANT_TICKET_ARMOR = 60005;
            public const int WEAPON_ECHANT_TICKET_CORE = 60002;
            public const int WEAPON_ECHANT_TICKET_DEFAULT = 60001;
            public const int WEAPON_ECHANT_TICKET_SHIELD = 60004;
            public const int WEAPON_ECHANT_TICKET_SPECIAL = 60006;
            public const int WEAPON_ECHANT_TICKET_WEAPON = 60003;
            public const int WEAPON_INVENTORY_ADD = 10;
            public const int WEAPON_INVENTORY_ADDCASH = 100;
            public const int WEAPON_INVENTORY_MAX = 400;
            public const int WEAPON_INVENTORY_START = 200;
            public const int WEAPON_MAKE_IMMEDIATE_TICKET_CASH = 100;
            public const int WEAPON_MAKE_IMMEDIATE_TICKET_COUNT = 1;
            public const int WEAPON_MAKE_MATERIAL_MAX = 500;
            public const int WEAPON_MAKE_MATERIAL_MIN = 50;
            public const int WEAPON_MAKE_SLOT_ADD = 1;
            public const int WEAPON_MAKE_SLOT_ADDCASH = 1500;
            public const int WEAPON_MAKE_SLOT_MAX = 4;
            public const int WEAPON_MAKE_SLOT_START = 2;
            public const int WEAPON_MAKE_TICKET_COUNT = 1;
            public const int WEAPON_OPEN_CLASS_BODY = 2;
            public const int WEAPON_OPEN_CLASS_HEAD = 1;
            public const int WEAPON_OPEN_CLASS_LEFTHAND = 1;
            public const int WEAPON_OPEN_CLASS_RIGHTHAND = 1;
            public const int WEAPON_OPEN_CLASS_SPECIAL = 5;
            public const int WEAPON_WEIGHT_CONVERSION_VALUE = 10000;
            public const int INFINITY_TOWER_MAX_FIELD = 78;
            public const int INFINITY_TOWER_PAGE_COUNT = 25;
        }
    }
}