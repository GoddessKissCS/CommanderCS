using MongoDB.Bson;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Schemes
{
    public class GameProfileScheme
    {

        public ObjectId Id { get; set; }
        public int memberId { get; set; }
        public int server { get; set; }
        public int? guildId { get; set; }
        public int worldState { get; set; }
        public string session { get; set; }
        public string uno { get; set; }
        public int lastStage { get; set; }
        public bool notifaction { get; set; }
        public int resetDateTime { get; set; }
        public int lastLoginTime { get; set; }
        public UserDevice userDevice { get; set; }
        public UserBattleStatistics userStatistics { get; set; }
        public UserResources userResources { get; set; }
        public UserInventory userInventory { get; set; }
        public UserBadges userBadges { get; set; }
        public UserInformationResponse.TutorialData tutorialData { get; set; }
        public Dictionary<string, List<WorldMapInformationResponse>> stages { get; set; }
        public Dictionary<string, UserInformationResponse.Commander> commanderData { get; set; }
        public List<UserInformationResponse.PreDeck> preDeck { get; set; }
        public List<int> completeRewardGroupIdx { get; set; }
        public Dictionary<string, List<int>> sweepClearData { get; set; }
        public Dictionary<string, DiapatchCommanderInfo> dispatchedCommanders { get; set; }
        public List<UserInformationResponse.VipRechargeData> vipRechargeData { get; set; }
        public Dictionary<string, int> boughtCashShopItems { get; set; }
        public List<BlockUser> blockedUsers { get; set; }
    }

    public class UserDevice
    {
        public int platformId { get; set; }
        public string device { get; set; }
        public string deviceid { get; set; }
        public int patchType { get; set; }
        public int osCode { get; set; }
        public string osversion { get; set; }
        public string gameversion { get; set; }
        public string apk { get; set; }
        public string pushRegistrationId { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string gpid { get; set; }
    }

    public class UserBattleStatistics
    {
        public int totalGold { get; set; }
        public int pveWinCount { get; set; }
        public int pveLoseCount { get; set; }
        public int pvpWinCount { get; set; }
        public int pvpLoseCount { get; set; }
        public int armyCommanderDestroyCount { get; set; }
        public int armyUnitDestroyCount { get; set; }
        public int navyCommanderDestroyCount { get; set; }
        public int navyUnitDestroyCount { get; set; }
        public int totalPlunderGold { get; set; }
        public int winStreak { get; set; }
        public int winMostStreak { get; set; }
        public int preWinStreak { get; set; }
        public int arenaHighRank { get; set; }
        public int raidHighRank { get; set; }
        public int raidHighScore { get; set; }
        public int normalGachaCount { get; set; }
        public int premiumGachaCount { get; set; }
        public int stageClearCount { get; set; }
        public int sweepClearCount { get; set; }
        public int unitDestroyCount { get; set; }
        public int commanderDestroyCount { get; set; }
        public int vipShop { get; set; }
        public int vipShopResetTime { get; set; }
        public int predeckCount { get; set; }
        public int firstPayment { get; set; }
        public int weaponMakeSlotCount { get; set; }
        public int weaponInventoryCount { get; set; }
    }

    public class UserResources
    {
        public string nickname { get; set; }
        public int annCoin { get; set; }
        public int blackChallenge { get; set; }
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