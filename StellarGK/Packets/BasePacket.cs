﻿using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Database.Schemes;
using StellarGK.Logic.Protocols;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace StellarGK.Host
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CommandAttribute : Attribute
    {
        public CommandId Id { get; set; }
    }

    public class RawPacket : BasePacket
    {
        [JsonPropertyName("params")]
        public JsonNode Params { get; set; }
    }

    public class BasePacket
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("method")]
        public int Method { get; set; }

        [JsonPropertyName("sess")]
        public string Session { get; set; }
    }

    public abstract class BaseCommandHandler<TParams>
    {
        public BasePacket BasePacket { get; set; }
        public abstract object Handle(TParams @params);

        // This is a example
        // THis could be reused in all command handlers
        public string GetSession()
        {
            return BasePacket.Session;
        }

        public AccountScheme? GetAccount(int memberId)
        {
            return DatabaseManager.Account.FindByUid(memberId);
        }

        public AccountScheme? GetAccount()
        {
            return DatabaseManager.Account.FindBySession(GetSession());
        }

        public GameProfileScheme? GetGameProfile()
        {
            return DatabaseManager.GameProfile.FindBySession(GetSession());
        }

        public DormitoryScheme? GetDormitory()
        {
            return DatabaseManager.Dormitory.FindBySession(GetSession());
        }

    }

    public enum CommandId : int
    {
        GetRegion = 1000,
        GetTutorialStep = 1100,
        GuildInfo = 1101,
        GetUserInformation = 1102,
        GetVipBuyCount = 1103,
        Mission = 1104,
        ServerStatus = 1116,
        Login = 1201,
        Logout = 1202,
        GoogleSignIn = 1209,
        GuestSignUp = 1210,
        SignUp = 1211,
        ChangeMembership = 1212,
        ChangeMembershipOpenPlatform = 1213,
        FBSignIn = 1214,
        GuestSignIn = 1215,
        SignIn = 1216,
        BulletCharge = 1217,
        UpdateTutorialStep = 1218,
        LoginTutorialSkip = 1219,
        ChangeLanguage = 1229,
        GetChangeDeviceCode = 1230,
        CheckChangeDeviceCode = 1231,
        CheckOpenPlatformExist = 1232,
        ChangeDevice = 1233,
        ChangeDeviceDbros = 1234,
        GetChatIgnoreList = 1300,
        AddChatIgnore = 1301,
        DelChatIgnore = 1302,
        ChangeNickname = 1408,
        SetNickNameFromTutorial = 1409,
        BankRoulletStart = 1501,
        ChangeUserThumbnail = 1502,
        ResourceRecharge = 1503,
        CheckBadge = 1504,
        CheckAlarm = 1505,
        SetPushOnOff = 1506,
        WorldMapInformation = 2201,
        UseTimeMachine = 2208,
        WorldMapReward = 2209,
        GetEventBattleList = 2301,
        GetEventBattleData = 2302,
        EventRaidSummon = 2303,
        EventRaidShare = 2304,
        EventRaidList = 2305,
        EventRaidData = 2306,
        EventRaidRankingData = 2307,
        GetEventRaidReward = 2308,
        GetEventBattleGachaInfo = 2310,
        EventBattleGachaOpen = 2311,
        EventBattleGachaReset = 2312,
        GetRaidRankList = 3113,
        GetRaidInfo = 3114,
        PvPRankingList = 3123,
        RefreshPvPDuelList = 3124,
        PvPDuelList = 3125,
        GetRecordList = 3131,
        GetReplayList = 3132,
        GetReplayInfo = 3133,
        GetAnnihilationMapInfo = 3135,
        UseTimeMachineSweep = 3201,
        SituationInformation = 3202,
        ReceiveRaidReward = 3215,
        PvPDuelInfo = 3221,
        ReceivePvPReward = 3227,
        DefenderSetting = 3228,
        GetDefenderInfo = 3229,
        ReceiveDuelPointReward = 3230,
        BattleOut = 3232,
        DispatchAdvancedParty = 3236,
        ResetAnnihilationStage = 3237,
        WaveBattleList = 3301,
        PvPWaveDuelList = 3401,
        RefreshPvPWaveDuelList = 3402,
        PvPWaveDuelRankingList = 3403,
        GetWaveDuelDefenderInfo = 3404,
        WaveDuelDefenderSetting = 3405,
        GetExplorationList = 3501,
        ExplorationStart = 3502,
        ExplorationCancel = 3503,
        ExplorationComplete = 3504,
        GetGroupReward = 3510,
        WorldDuelInformation = 3601,
        WorldDuelDefenderSetting = 3603,
        WorldDuelBuffUpgrade = 3605,
        WorldDuelEnemyInfo = 3606,
        WorldDuelBuffSetting = 3610,
        WaveBattleStart = 3730,
        AnnihilationStageStart = 3731,
        WorldMapStageStart = 3732,
        CooperateBattleStart = 3733,
        RaidStart = 3734,
        SituationSweepStart = 3735,
        StartAnnihilation = 3736,
        InfinityBattleStart = 3737,
        PvPStartDuel = 3738,
        PvPStartWaveDuel = 3739,
        PvPStartWorldDuel = 3740,
        EventBattleStart = 3741,
        EventRaidBattleStart = 3742,
        CommanderSkillLevelUp = 4124,
        CommanderLevelUp = 4214,
        CommanderRankUp = 4218,
        CommanderRankUpImmediate = 4220,
        UnitLevelUp = 4301,
        UnitLevelUpImmediate = 4302,
        GetUnitResearchList = 4303,
        UnitUpgrade = 4304,
        CommanderClassUp = 4304,
        ChangeCommanderCostume = 4305,
        BuyCommanderCostume = 4306,
        GiftFood = 4307,
        GetFavorReward = 4308,
        GetCommanderScenario = 4309,
        CompleteCommanderScenario = 4310,
        RecieveCommanderScenarioReward = 4311,
        GetMarried = 4312,
        TranscendenceSkillUp = 4313,
        StartDateMode = 4401,
        DateModeGetGift = 4402,
        GetTroopInformation = 5119,
        RecruitCommander = 5211,
        CommanderDelayCancel = 5217,
        ChangeTroopNickname = 5218,
        UpdateTroopRole = 5219,
        PreDeckSetting = 5220,
        ExchangeMedal = 5221,
        BuyPredeckSlot = 5222,
        BankInfo = 5302,
        GetBankReward = 5303,
        GetMailList = 6101,
        GetReward = 6102,
        ReadMail = 6103,
        GetRankingReward = 6105,
        GetFirstPaymentReward = 6108,
        DailyBonusCheck = 6112,
        CompleteAchievement = 6132,
        DailyBonusReceive = 6213,
        AchievementReward = 6231,
        MissionReward = 6233,
        AllAchievementReward = 6235,
        AllMissionReward = 6236,
        GetCarnivalList = 6241,
        CarnivalComplete = 6242,
        CarnivalBuyPackage = 6243,
        CarnivalSelectItem = 6244,
        GachaInformation = 6311,
        GachaOpenBox = 6312,
        BuyVipGacha = 6313,
        GetVipGachaInfo = 6314,
        GachaRatingInformationType = 6315,
        GachaRatingInformationTypeB = 6316,
        CompleteMissionGoal = 6324,
        GetRotationBannerInfo = 6401,
        GetCashShopList = 7100,
        CheckPayment = 7101,
        CheckPaymentAmazon = 7102,
        CheckPaymentIOS = 7103,
        CheckPaymentOneStore = 7104,
        RequestPayment = 7105,
        GetDispatchCommanderList = 7170,
        DispatchCommander = 7171,
        GetDispatchCommanderListFromLogin = 7172,
        RecallDispatch = 7173,
        GuildDispatchCommanderList = 7174,
        MakeOrderId = 7202,
        ShopBuyGold = 7203,
        GuildList = 7211,
        CreateGuild = 7212,
        UpdateGuildInfo = 7213,
        GuildCloseDown = 7214,
        DelegatingGuild = 7215,
        DeportGuildMember = 7216,
        LeaveGuild = 7217,
        SearchGuild = 7218,
        GuildMemberList = 7219,
        UpgradeGuildSkill = 7220,
        UpgradeGuildLevel = 7222,
        ApplyGuildJoin = 7251,
        CancelGuildJoin = 7252,
        FreeJoinGuild = 7253,
        ManageGuildJoinMember = 7254,
        ApproveGuildJoin = 7255,
        RefuseGuildJoin = 7256,
        AppointSubMaster = 7257,
        FireSubMaster = 7258,
        AnnihilationMapInformation = 7301,
        AnnihilationEnemyInformation = 7306,
        SellItem = 7401,
        OpenItem = 7402,
        SetItemEquipment = 7421,
        ReleaseItemEquipment = 7422,
        UpgradeItemEquipment = 7423,
        DecompositionItemEquipment = 7424,
        GetGuildBoard = 7450,
        GuildBoardWrite = 7451,
        GuildBoardDelete = 7452,
        ConquestJoin = 7501,
        GetConquestInfo = 7502,
        SetConquestTroop = 7503,
        GetConquestTroop = 7504,
        DeleteConquestTroop = 7505,
        BuyConquestTroopSlot = 7506,
        GetConquestMovePath = 7507,
        SetConquestMoveTroop = 7508,
        GetConquestCurrentStateInfo = 7509,
        GetConquestStageInfo = 7510,
        StartConquestRadar = 7511,
        GetConquestRadar = 7512,
        GetConquestStageUserInfo = 7513,
        GetConquestBattle = 7514,
        GetGuildRanking = 7515,
        GetConquestNotice = 7516,
        SetConquestNotice = 7517,
        GetConquestReplay = 7518,
        CooperateBattleInfo = 7601,
        CooperateBattleComplete = 7602,
        CooperateBattlePointGuildRank = 7603,
        CooperateBattlePointRank = 7604,
        DBVersionCheck = 8101,
        UserTerm = 8104,
        GetCommonNotice = 8110,
        GetEventNotice = 8111,
        GetShutDownNotice = 8114,
        GameVersionInfo = 8115,
        InputCoupon = 8116,
        GetCouponList = 8117,
        GetBadWordList = 8118,
        StartWebEvent = 8119,
        GetEventRemaingTime = 8120,
        GetWebEvent = 8121,
        GetSecretShopList = 8200,
        BuySecretShopItem = 8201,
        RefreshSecretShopList = 8202,
        GetBuyVipShop = 8203,
        GetPlugEventInfo = 8300,
        GetPostEventReward = 8301,
        GetCommentEventReward = 8302,
        StartWeaponProgress = 8500,
        GetWeaponProgressList = 8501,
        WeaponProgressSlotOpen = 8502,
        WeaponProgressFinish = 8503,
        WeaponProgressBuyImmediateTicket = 8504,
        WeaponProgressUseImmediateTicket = 8505,
        EquipWeapon = 8506,
        ReleaseWeapon = 8507,
        UpgradeWeapon = 8508,
        DecompositionWeapon = 8509,
        ComposeWeaponBox = 8512,
        UpgradeWeaponInventory = 8513,
        TradeWeaponUpgradeTicket = 8514,
        GetWeaponProgressHistory = 8520,
        GetDormitoryInfo = 8600,
        GetDormitoryFloorInfo = 8601,
        ConstructDormitoryFloor = 8602,
        FinishConstructDormitoryFloor = 8603,
        ChangeDormitoryFloorName = 8604,
        GetDormitoryShopProductList = 8610,
        BuyDormitoryShopProduct = 8611,
        SellDormitoryItem = 8612,
        BuyDormitoryHeadCostume = 8614,
        GetDormitoryFloorDetailInfo = 8620,
        ChangeDormitoryWallpaper = 8621,
        ArrangeDormitoryDecoration = 8630,
        EditDormitoryDecoration = 8631,
        RemoveDormitoryDecoration = 8632,
        GetDormitoryCommanderInfo = 8640,
        ArrangeDormitoryCommander = 8641,
        RemoveDormitoryCommander = 8642,
        ChangeDormitoryCommanderHead = 8643,
        ChangeDormitoryCommanderBody = 8644,
        GetDormitoryPoint = 8650,
        SearchDormitoryUser = 8660,
        AddDormitoryFavorUser = 8661,
        RemoveDormitoryFavorUser = 8662,
        GetDormitoryFavorUser = 8663,
        GetDormitoryGuildUser = 8664,
        GetRecommendUser = 8665,
        GetDormitoryUserFloorInfo = 8670,
        GetDormitoryUserFloorDetailInfo = 8671,
        InfinityBattleInformation = 8700,
        GetInfinityBattleDeck = 8701,
        SaveInfinityBattleDeck = 8702,
        StartInfinityBattleScenario = 8703,
        InfinityBattleGetReward = 8704,

    }


}