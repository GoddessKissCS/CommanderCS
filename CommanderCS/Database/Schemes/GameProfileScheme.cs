using CommanderCS.Enum;
using CommanderCS.Protocols;
using MongoDB.Bson;

namespace CommanderCS.Database.Schemes
{
    public class GameProfileScheme
    {
        public ObjectId Id { get; set; }
        public int MemberId { get; set; }
        public int Server { get; set; }
        public int? GuildId { get; set; }
        public int WorldState { get; set; }
        public string Session { get; set; }
        public int Uno { get; set; }
        public int LastStage { get; set; }
        public bool Notifaction { get; set; }
        public int ResetDateTime { get; set; }
        public double LastLoginTime { get; set; }
        public UserDevice UserDevice { get; set; }
        public UserBattleStatistics UserStatistics { get; set; }
        public UserResources UserResources { get; set; }
        public UserInventory UserInventory { get; set; }
        public UserBadges UserBadges { get; set; }
        public WorldMapData WorldMapData { get; set; }
        public BattleData BattleData { get; set; }
        public UserInformationResponse.TutorialData TutorialData { get; set; }
        public Dictionary<string, UserInformationResponse.Commander> CommanderData { get; set; }
        public List<UserInformationResponse.PreDeck> PreDeck { get; set; }
        public List<int> CompleteRewardGroupIdx { get; set; }
        public Dictionary<string, DiapatchCommanderInfo> DispatchedCommanders { get; set; }
        public List<UserInformationResponse.VipRechargeData> VipRechargeData { get; set; }
        public Dictionary<string, int> BoughtCashShopItems { get; set; }
        public List<BlockUser> BlockedUsers { get; set; }
        public List<MailInfo.MailData>? MailDataList { get; set; }
        public List<DailyBonusCheckResponse> DailyBonusCheck { get; set; }
        public RankingData RankingData { get; set; }
        public DefenderDeck DefenderDeck { get; set; }

        //public List<WaveBattleInfoList.WaveBattleInfo> WaveBattleInfos { get; set; }
    }

    public class UserDevice
    {
        public Platform PlatformId { get; set; }
        public string Device { get; set; }
        public string Deviceid { get; set; }
        public int PatchType { get; set; }
        public OSCode OsCode { get; set; }
        public string Osversion { get; set; }
        public string Gameversion { get; set; }
        public string Apk { get; set; }
        public string PushRegistrationId { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Gpid { get; set; }
    }

    public class UserBattleStatistics
    {
        public int TotalGold { get; set; } = 100000;
        public int PveWinCount { get; set; }
        public int PveLoseCount { get; set; }
        public int PvpWinCount { get; set; }
        public int PvpLoseCount { get; set; }
        public int ArmyCommanderDestroyCount { get; set; }
        public int ArmyUnitDestroyCount { get; set; }
        public int NavyCommanderDestroyCount { get; set; }
        public int NavyUnitDestroyCount { get; set; }
        public int TotalPlunderGold { get; set; }
        public int WinStreak { get; set; }
        public int WinMostStreak { get; set; }
        public int PreWinStreak { get; set; }
        public int ArenaHighRank { get; set; }
        public int RaidHighRank { get; set; }
        public int RaidHighScore { get; set; }
        public int NormalGachaCount { get; set; }
        public int PremiumGachaCount { get; set; }
        public int StageClearCount { get; set; }
        public int SweepClearCount { get; set; }
        public int UnitDestroyCount { get; set; }
        public int CommanderDestroyCount { get; set; }
        public int VipShop { get; set; }
        public int VipShopResetTime { get; set; }
        public int PredeckCount { get; set; } = 5;
        public int firstPayment { get; set; }
        public int weaponMakeSlotCount { get; set; }
        public int weaponInventoryCount { get; set; }
    }

    public class UserResources
    {
        public string nickname { get; set; } = string.Empty;
        public int annCoin { get; set; } = 0;
        public int BlackChallenge { get; set; } = 0;
        public int blueprintArmy { get; set; } = 0;
        public int blueprintNavy { get; set; } = 0;
        public int bullet { get; set; } = 500;
        public int cash { get; set; } = 500;
        public int challenge { get; set; } = 0;
        public int challengeCoin { get; set; } = 0;
        public int chip { get; set; } = 0;
        public int commanderGift { get; set; } = 0;
        public int commanderPromotionPoint { get; set; } = 0;
        public int eventRaidTicket { get; set; } = 0;
        public int exp { get; set; } = 0;
        public int explorationTicket { get; set; } = 0;
        public int gold { get; set; } = 100000;
        public int guildCoin { get; set; } = 0;
        public int honor { get; set; } = 0;
        public int level { get; set; } = 1;
        public int oil { get; set; } = 0;
        public int opcon { get; set; } = 0;
        public int opener { get; set; } = 0;
        public int raidCoin { get; set; } = 0;
        public int ring { get; set; } = 0;
        public int sweepTicket { get; set; } = 0;
        public int thumbnailId { get; set; } = 1001;
        public int vipExp { get; set; } = 0;
        public int vipLevel { get; set; } = 0;
        public int waveDuelCoin { get; set; } = 0;
        public int waveDuelTicket { get; set; } = 0;
        public int weaponImmediateTicket { get; set; } = 0;
        public int weaponMakeTicket { get; set; } = 0;
        public int weaponMaterial1 { get; set; } = 0;
        public int weaponMaterial2 { get; set; } = 0;
        public int weaponMaterial3 { get; set; } = 0;
        public int weaponMaterial4 { get; set; } = 0;
        public int worldDuelCoin { get; set; } = 0;
        public int worldDuelTicket { get; set; } = 0;
        public int worldDuelUpgradeCoin { get; set; } = 0;
    }

    public class UserInventory
    {
        public Dictionary<string, int> medalData { get; set; }
        public Dictionary<string, int> foodData { get; set; }
        public Dictionary<string, int> groupItemData { get; set; }
        public Dictionary<string, int> itemData { get; set; }
        public Dictionary<string, int> partData { get; set; }
        public Dictionary<string, int> eventResourceData { get; set; }
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }
        public Dictionary<string, WeaponData> weaponList { get; set; }
        public Dictionary<string, List<int>> donHaveCommCostumeData { get; set; }
    }

    public class UserBadges
    {
        public int arena { get; set; }
        public int dlms { get; set; }
        public int achv { get; set; }
        public int rwd { get; set; }
        public Dictionary<string, int> shop { get; set; }
        public List<string> cnvl { get; set; }
        public int ccnv { get; set; }
        public List<string> cnvl2 { get; set; }
        public int ccvn2 { get; set; }
        public List<string> cnvl3 { get; set; }
        public int ccvn3 { get; set; }
        public int wb { get; set; }
        public int gb { get; set; }
        public int grp { get; set; }
        public int ercnt { get; set; }
        public int iftw { get; set; }
    }

    public class WorldMapData
    {
        public Dictionary<string, List<WorldMapInformationResponse>> Stages { get; set; }

        public Dictionary<string, int> StageReward { get; set; }
    }

    public class BattleData
    {
        public Dictionary<string, List<int>> SweepClearData { get; set; }
    }

    public class RankingData
    {
        public RankingUserData PvPDuelRankingData { get; set; }

        public RankingUserData WaveDuelRankingData { get; set; }
    }

    public class DefenderDeck
    {
        public Dictionary<string, string> PvPDefenderDeck { get; set; }

        public Dictionary<string, Dictionary<string, string>> WaveDuelDefenderDecks { get; set; }
    }

}