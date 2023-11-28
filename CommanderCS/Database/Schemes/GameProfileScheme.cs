using MongoDB.Bson;
using CommanderCS.Enum;
using CommanderCS.Protocols;

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
        public UserInformationResponse.TutorialData TutorialData { get; set; }
        public Dictionary<string, List<WorldMapInformationResponse>> WorldMapStages { get; set; }
        public Dictionary<string, int> WorldMapStagesReward { get; set; }
        public Dictionary<string, UserInformationResponse.Commander> CommanderData { get; set; }
        public List<UserInformationResponse.PreDeck> PreDeck { get; set; }
        public List<int> CompleteRewardGroupIdx { get; set; }
        public Dictionary<string, List<int>> SweepClearData { get; set; }
        public Dictionary<string, DiapatchCommanderInfo> DispatchedCommanders { get; set; }
        public List<UserInformationResponse.VipRechargeData> VipRechargeData { get; set; }
        public Dictionary<string, int> BoughtCashShopItems { get; set; }
        public List<BlockUser> BlockedUsers { get; set; }
        public List<MailInfo.MailData>? MailDataList { get; set; }
        public List<DailyBonusCheckResponse> DailyBonusCheck { get; set; }

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
        public int TotalGold { get; set; }
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
        public int PredeckCount { get; set; }
        public int firstPayment { get; set; }
        public int weaponMakeSlotCount { get; set; }
        public int weaponInventoryCount { get; set; }
    }

    public class UserResources
    {
        public string nickname { get; set; }
        public int annCoin { get; set; }
        public int BlackChallenge { get; set; }
        public int blueprintArmy { get; set; }
        public int blueprintNavy { get; set; }
        public int bullet { get; set; }
        public int cash { get; set; }
        public int challenge { get; set; }
        public int challengeCoin { get; set; }
        public int chip { get; set; }
        public int commanderGift { get; set; }
        public int commanderPromotionPoint { get; set; }
        public int eventRaidTicket { get; set; }
        public int exp { get; set; }
        public int explorationTicket { get; set; }
        public int gold { get; set; }
        public int guildCoin { get; set; }
        public int honor { get; set; }
        public int level { get; set; }
        public int oil { get; set; }
        public int opcon { get; set; }
        public int opener { get; set; }
        public int raidCoin { get; set; }
        public int ring { get; set; }
        public int sweepTicket { get; set; }
        public int thumbnailId { get; set; }
        public int vipExp { get; set; }
        public int vipLevel { get; set; }
        public int waveDuelCoin { get; set; }
        public int waveDuelTicket { get; set; }
        public int weaponImmediateTicket { get; set; }
        public int weaponMakeTicket { get; set; }
        public int weaponMaterial1 { get; set; }
        public int weaponMaterial2 { get; set; }
        public int weaponMaterial3 { get; set; }
        public int weaponMaterial4 { get; set; }
        public int worldDuelCoin { get; set; }
        public int worldDuelTicket { get; set; }
        public int worldDuelUpgradeCoin { get; set; }
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
}