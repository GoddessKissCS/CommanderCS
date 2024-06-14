using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;

namespace CommanderCS.MongoDB.Schemes
{
    /// <summary>
    /// Represents a user's game profile scheme.
    /// </summary>
    public class GameProfileScheme
    {
        /// <summary>
        /// Gets or sets the unique identifier of the game profile scheme.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the member ID associated with the user.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the server ID.
        /// </summary>
        public int Server { get; set; }

        /// <summary>
        /// Gets or sets the guild ID.
        /// </summary>
        public int? GuildId { get; set; }

        /// <summary>
        /// Gets or sets the world state.
        /// </summary>
        public int WorldState { get; set; }

        /// <summary>
        /// Gets or sets the session ID of the user.
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Gets or sets the unique number associated with the user.
        /// </summary>
        public int Uno { get; set; }

        /// <summary>
        /// Gets or sets the last stage.
        /// </summary>
        public int LastStage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notifications are enabled.
        /// </summary>
        public bool Notifaction { get; set; }

        /// <summary>
        /// Gets or sets the reset date time.
        /// </summary>
        public int ResetDateTime { get; set; }

        /// <summary>
        /// Gets or sets the last login time.
        /// </summary>
        public double LastLoginTime { get; set; }

        /// <summary>
        /// Gets or sets the user device information.
        /// </summary>
        public UserDevice UserDevice { get; set; }

        /// <summary>
        /// Gets or sets the user battle statistics.
        /// </summary>
        public UserBattleStatistics UserStatistics { get; set; }

        /// <summary>
        /// Gets or sets the user resources.
        /// </summary>
        public UserResources UserResources { get; set; }

        /// <summary>
        /// Gets or sets the user inventory.
        /// </summary>
        public UserInventory UserInventory { get; set; }

        /// <summary>
        /// Gets or sets the user badges.
        /// </summary>
        public UserBadges UserBadges { get; set; }

        /// <summary>
        /// Gets or sets the battle data.
        /// </summary>
        public BattleData BattleData { get; set; }

        /// <summary>
        /// Gets or sets the tutorial data.
        /// </summary>
        public UserInformationResponse.TutorialData TutorialData { get; set; }

        /// <summary>
        /// Gets or sets the commander data.
        /// </summary>
        public Dictionary<string, UserInformationResponse.Commander> CommanderData { get; set; }

        /// <summary>
        /// Gets or sets the pre-deck configurations.
        /// </summary>
        public List<UserInformationResponse.PreDeck> PreDeck { get; set; }

        /// <summary>
        /// Gets or sets the complete reward group indices.
        /// </summary>
        public List<int> CompleteRewardGroupIdx { get; set; }

        /// <summary>
        /// Gets or sets the dispatched commanders.
        /// </summary>
        public Dictionary<string, DispatchedCommanderInfo> DispatchedCommanders { get; set; }

        /// <summary>
        /// Gets or sets the VIP recharge data.
        /// </summary>
        public List<UserInformationResponse.VipRechargeData> VipRechargeData { get; set; }

        /// <summary>
        /// Gets or sets the bought cash shop items.
        /// </summary>
        public Dictionary<string, int> BoughtCashShopItems { get; set; }

        /// <summary>
        /// Gets or sets the list of blocked users.
        /// </summary>
        public List<BlockUser> BlockedUsers { get; set; }

        /// <summary>
        /// Gets or sets the list of mail data.
        /// </summary>
        public List<MailInfo.MailData>? MailDataList { get; set; }

        /// <summary>
        /// Gets or sets the daily bonus check data.
        /// </summary>
        public List<DailyBonusCheckResponse> DailyBonusCheck { get; set; }

        /// <summary>
        /// Gets or sets the ranking data.
        /// </summary>
        public RankingData RankingData { get; set; }

        /// <summary>
        /// Gets or sets the defender deck data.
        /// </summary>
        public DefenderDeck DefenderDeck { get; set; }

        /// <summary>
        /// Gets or sets the exploration data.
        /// </summary>
        public List<ExplorationData> ExplorationData { get; set; }

        /// <summary>
        /// Gets or sets the weapon information.
        /// </summary>
        public WeaponInformation WeaponInformation { get; set; }

        /// <summary>
        /// Gets or sets the shop data.
        /// </summary>
        public ShopData ShopData { get; set; }

        /// <summary>
        /// Gets or sets the daily buyables data.
        /// </summary>
        public DailyBuyables DailyBuyables { get; set; }

        /// <summary>
        /// Gets or sets the dictionary containing gacha information.
        /// </summary>
        public Dictionary<string, GachaInformationResponse> GachaInformation { get; set; }
    }

    /// <summary>
    /// Represents user device information.
    /// </summary>
    public class UserDevice
    {
        /// <summary>
        /// Gets or sets the platform ID.
        /// </summary>
        public Platform PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the device name.
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// Gets or sets the device ID.
        /// </summary>
        public string Deviceid { get; set; }

        /// <summary>
        /// Gets or sets the patch type.
        /// </summary>
        public int PatchType { get; set; }

        /// <summary>
        /// Gets or sets the OS code.
        /// </summary>
        public OSCode OsCode { get; set; }

        /// <summary>
        /// Gets or sets the OS version.
        /// </summary>
        public string Osversion { get; set; }

        /// <summary>
        /// Gets or sets the game version.
        /// </summary>
        public string Gameversion { get; set; }

        /// <summary>
        /// Gets or sets the APK file name.
        /// </summary>
        public string Apk { get; set; }

        /// <summary>
        /// Gets or sets the push registration ID.
        /// </summary>
        public string PushRegistrationId { get; set; }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Gpid.
        /// </summary>
        public string Gpid { get; set; }
    }

    /// <summary>
    /// Represents user battle statistics.
    /// </summary>
    public class UserBattleStatistics
    {
        /// <summary>
        /// Gets or sets the total amount of gold.
        /// </summary>
        public int TotalGold { get; set; } = 100000;

        /// <summary>
        /// Gets or sets the count of PvE wins.
        /// </summary>
        public int PveWinCount { get; set; }

        /// <summary>
        /// Gets or sets the count of PvE losses.
        /// </summary>
        public int PveLoseCount { get; set; }

        /// <summary>
        /// Gets or sets the count of PvP wins.
        /// </summary>
        public int PvpWinCount { get; set; }

        /// <summary>
        /// Gets or sets the count of PvP losses.
        /// </summary>
        public int PvpLoseCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy army commanders destroyed.
        /// </summary>
        public int ArmyCommanderDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy army units destroyed.
        /// </summary>
        public int ArmyUnitDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy navy commanders destroyed.
        /// </summary>
        public int NavyCommanderDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy navy units destroyed.
        /// </summary>
        public int NavyUnitDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the total amount of gold plundered.
        /// </summary>
        public int TotalPlunderGold { get; set; }

        /// <summary>
        /// Gets or sets the current win streak.
        /// </summary>
        public int WinStreak { get; set; }

        /// <summary>
        /// Gets or sets the highest win streak achieved.
        /// </summary>
        public int WinMostStreak { get; set; }

        /// <summary>
        /// Gets or sets the win streak before the current one.
        /// </summary>
        public int PreWinStreak { get; set; }

        /// <summary>
        /// Gets or sets the highest arena rank achieved.
        /// </summary>
        public int ArenaHighRank { get; set; }

        /// <summary>
        /// Gets or sets the highest raid rank achieved.
        /// </summary>
        public int RaidHighRank { get; set; }

        /// <summary>
        /// Gets or sets the highest raid score achieved.
        /// </summary>
        public int RaidHighScore { get; set; }

        /// <summary>
        /// Gets or sets the count of normal gacha draws.
        /// </summary>
        public int NormalGachaCount { get; set; }

        /// <summary>
        /// Gets or sets the count of premium gacha draws.
        /// </summary>
        public int PremiumGachaCount { get; set; }

        /// <summary>
        /// Gets or sets the count of stages cleared.
        /// </summary>
        public int StageClearCount { get; set; }

        /// <summary>
        /// Gets or sets the count of stages cleared using sweep.
        /// </summary>
        public int SweepClearCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy units destroyed.
        /// </summary>
        public int UnitDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the count of enemy commanders destroyed.
        /// </summary>
        public int CommanderDestroyCount { get; set; }

        /// <summary>
        /// Gets or sets the VIP shop level.
        /// </summary>
        public int VipShop { get; set; }

        /// <summary>
        /// Gets or sets the time of VIP shop reset.
        /// </summary>
        public int VipShopResetTime { get; set; }

        /// <summary>
        /// Gets or sets the count of pre-decks available.
        /// </summary>
        public int PredeckCount { get; set; } = 5;

        /// <summary>
        /// Gets or sets the count of first payments made.
        /// </summary>
        public int FirstPayment { get; set; }

        /// <summary>
        /// Gets or sets the count of weapon make slots.
        /// </summary>
        public int WeaponMakeSlotCount { get; set; }

        /// <summary>
        /// Gets or sets the count of weapon inventory slots.
        /// </summary>
        public int WeaponInventoryCount { get; set; }
    }

    /// <summary>
    /// Represents the resources of the user.
    /// </summary>
    public class UserResources
    {
        /// <summary>
        /// Gets or sets the nickname of the user.
        /// </summary>
        public string nickname { get; set; } = "Commander";

        /// <summary>
        /// Gets or sets the annCoin of the user.
        /// </summary>
        public int annCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the BlackChallenge of the user.
        /// </summary>
        public int BlackChallenge { get; set; } = 0;

        /// <summary>
        /// Gets or sets the blueprintArmy of the user.
        /// </summary>
        public int blueprintArmy { get; set; } = 0;

        /// <summary>
        /// Gets or sets the blueprintNavy of the user.
        /// </summary>
        public int blueprintNavy { get; set; } = 0;

        /// <summary>
        /// Gets or sets the bullet of the user.
        /// </summary>
        public int bullet { get; set; } = 500;

        /// <summary>
        /// Gets or sets the cash of the user.
        /// </summary>
        public int cash { get; set; } = 500;

        /// <summary>
        /// Gets or sets the challenge of the user.
        /// </summary>
        public int challenge { get; set; } = 0;

        /// <summary>
        /// Gets or sets the challengeCoin of the user.
        /// </summary>
        public int challengeCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the chip of the user.
        /// </summary>
        public int chip { get; set; } = 0;

        /// <summary>
        /// Gets or sets the commanderGift of the user.
        /// </summary>
        public int commanderGift { get; set; } = 0;

        /// <summary>
        /// Gets or sets the commanderPromotionPoint of the user.
        /// </summary>
        public int commanderPromotionPoint { get; set; } = 0;

        /// <summary>
        /// Gets or sets the eventRaidTicket of the user.
        /// </summary>
        public int eventRaidTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the exp of the user.
        /// </summary>
        public int exp { get; set; } = 0;

        /// <summary>
        /// Gets or sets the explorationTicket of the user.
        /// </summary>
        public int explorationTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the gold of the user.
        /// </summary>
        public int gold { get; set; } = 100000;

        /// <summary>
        /// Gets or sets the guildCoin of the user.
        /// </summary>
        public int guildCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the honor of the user.
        /// </summary>
        public int honor { get; set; } = 0;

        /// <summary>
        /// Gets or sets the level of the user.
        /// </summary>
        public int level { get; set; } = 1;

        /// <summary>
        /// Gets or sets the oil of the user.
        /// </summary>
        public int oil { get; set; } = 0;

        /// <summary>
        /// Gets or sets the opcon of the user.
        /// </summary>
        public int opcon { get; set; } = 0;

        /// <summary>
        /// Gets or sets the opener of the user.
        /// </summary>
        public int opener { get; set; } = 0;

        /// <summary>
        /// Gets or sets the raidCoin of the user.
        /// </summary>
        public int raidCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the ring of the user.
        /// </summary>
        public int ring { get; set; } = 0;

        /// <summary>
        /// Gets or sets the sweepTicket of the user.
        /// </summary>
        public int sweepTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the thumbnailId of the user.
        /// </summary>
        public int thumbnailId { get; set; } = 1001;

        /// <summary>
        /// Gets or sets the vipExp of the user.
        /// </summary>
        public int vipExp { get; set; } = 0;

        /// <summary>
        /// Gets or sets the vipLevel of the user.
        /// </summary>
        public int vipLevel { get; set; } = 0;

        /// <summary>
        /// Gets or sets the waveDuelCoin of the user.
        /// </summary>
        public int waveDuelCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the waveDuelTicket of the user.
        /// </summary>
        public int waveDuelTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of immediate weapon tickets.
        /// </summary>
        public int weaponImmediateTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of weapon make tickets.
        /// </summary>
        public int weaponMakeTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of weapon material 1.
        /// </summary>
        public int weaponMaterial1 { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of weapon material 2.
        /// </summary>
        public int weaponMaterial2 { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of weapon material 3.
        /// </summary>
        public int weaponMaterial3 { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of weapon material 4.
        /// </summary>
        public int weaponMaterial4 { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of world duel coins.
        /// </summary>
        public int worldDuelCoin { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of world duel tickets.
        /// </summary>
        public int worldDuelTicket { get; set; } = 0;

        /// <summary>
        /// Gets or sets the amount of world duel upgrade coins.
        /// </summary>
        public int worldDuelUpgradeCoin { get; set; } = 0;
    }

    /// <summary>
    /// Represents the inventory of the user.
    /// </summary>
    public class UserInventory
    {
        /// <summary>
        /// Gets or sets the medal data of the user.
        /// </summary>
        public Dictionary<string, int> medalData { get; set; }

        /// <summary>
        /// Gets or sets the food data of the user.
        /// </summary>
        public Dictionary<string, int> foodData { get; set; }

        /// <summary>
        /// Gets or sets the group item data of the user.
        /// </summary>
        public Dictionary<string, int> groupItemData { get; set; }

        /// <summary>
        /// Gets or sets the item data of the user.
        /// </summary>
        public Dictionary<string, int> itemData { get; set; }

        /// <summary>
        /// Gets or sets the part data of the user.
        /// </summary>
        public Dictionary<string, int> partData { get; set; }

        /// <summary>
        /// Gets or sets the event resource data of the user.
        /// </summary>
        public Dictionary<string, int> eventResourceData { get; set; }

        /// <summary>
        /// Gets or sets the equipment items of the user.
        /// </summary>
        public Dictionary<string, Dictionary<int, EquipItemInfo>> equipItem { get; set; }

        /// <summary>
        /// Gets or sets the weapon list of the user.
        /// </summary>
        public Dictionary<string, WeaponData> weaponList { get; set; }

        /// <summary>
        /// Gets or sets the costumes that the user does not have.
        /// </summary>
        public Dictionary<string, List<int>> donHaveCommCostumeData { get; set; }

        /// <summary>
        /// Gets or sets the costume data of the user.
        /// </summary>
        public List<Dictionary<string, RewardInfo.HaveCostumeInfo>> costumeData { get; set; }
    }

    /// <summary>
    /// Represents the badges of the user.
    /// </summary>
    public class UserBadges
    {
        /// <summary>
        /// Gets or sets the arena badge count.
        /// </summary>
        public int arena { get; set; }

        /// <summary>
        /// Gets or sets the dlms badge count.
        /// </summary>
        public int dlms { get; set; }

        /// <summary>
        /// Gets or sets the achv badge count.
        /// </summary>
        public int achv { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of shop badges.
        /// </summary>
        public Dictionary<string, int> shop { get; set; }

        /// <summary>
        /// Gets or sets the list of cnvl badges.
        /// </summary>
        public List<string> cnvl { get; set; }

        /// <summary>
        /// Gets or sets the ccnv badge count.
        /// </summary>
        public int ccnv { get; set; }

        /// <summary>
        /// Gets or sets the list of cnvl2 badges.
        /// </summary>
        public List<string> cnvl2 { get; set; }

        /// <summary>
        /// Gets or sets the ccvn2 badge count.
        /// </summary>
        public int ccvn2 { get; set; }

        /// <summary>
        /// Gets or sets the list of cnvl3 badges.
        /// </summary>
        public List<string> cnvl3 { get; set; }

        /// <summary>
        /// Gets or sets the ccvn3 badge count.
        /// </summary>
        public int ccvn3 { get; set; }

        /// <summary>
        /// Gets or sets the wb badge count.
        /// </summary>
        public int wb { get; set; }

        /// <summary>
        /// Gets or sets the gb badge count.
        /// </summary>
        public int gb { get; set; }

        /// <summary>
        /// Gets or sets the grp badge count.
        /// </summary>
        public int grp { get; set; }

        /// <summary>
        /// Gets or sets the ercnt badge count.
        /// </summary>
        public int ercnt { get; set; }

        /// <summary>
        /// Gets or sets the iftw badge count.
        /// </summary>
        public int iftw { get; set; }
    }

    /// <summary>
    /// Represents the battle data including world map stages, rewards, and sweep clear data.
    /// </summary>
    public class BattleData
    {
        /// <summary>
        /// Gets or sets the dictionary of world map stages.
        /// </summary>
        public Dictionary<string, List<WorldMapInformationResponse>> WorldMapStages { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of world map stage rewards.
        /// </summary>
        public Dictionary<string, int> WorldMapStageReward { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of sweep clear data.
        /// </summary>
        public Dictionary<string, List<int>> SweepClearData { get; set; }
    }

    /// <summary>
    /// Represents the ranking data for different game modes.
    /// </summary>
    public class RankingData
    {
        /// <summary>
        /// Gets or sets the ranking data for PvP duel.
        /// </summary>
        public RankingUserData PvPDuelRankingData { get; set; }

        /// <summary>
        /// Gets or sets the ranking data for wave duel.
        /// </summary>
        public RankingUserData WaveDuelRankingData { get; set; }

        /// <summary>
        /// Gets or sets the ranking data for raid.
        /// </summary>
        public RankingUserData RaidRankingData { get; set; }
    }

    /// <summary>
    /// Represents the defender deck configuration.
    /// </summary>
    public class DefenderDeck
    {
        /// <summary>
        /// Gets or sets the PvP defender deck.
        /// </summary>
        public Dictionary<string, string> PvPDefenderDeck { get; set; }

        /// <summary>
        /// Gets or sets the world duel defender deck.
        /// </summary>
        public Dictionary<string, string> WorldDuelDefenderDeck { get; set; }

        /// <summary>
        /// Gets or sets the wave duel defender decks.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> WaveDuelDefenderDecks { get; set; }

        /// <summary>
        /// Gets or sets the infinity battle deck.
        /// </summary>
        public JObject InfinityBattleDeck { get; set; }
    }

    /// <summary>
    /// Represents information about a dispatched commander.
    /// </summary>
    public class DispatchedCommanderInfo
    {
        /// <summary>
        /// Gets or sets the commander ID.
        /// </summary>
        public int cid { get; set; }

        /// <summary>
        /// Gets or sets the runtime of the commander.
        /// </summary>
        public int runtime { get; set; }

        /// <summary>
        /// Gets or sets the engagement count of the commander.
        /// </summary>
        public int engageCnt { get; set; }

        /// <summary>
        /// Gets or sets the amount of gold obtained by the commander.
        /// </summary>
        public int getGold { get; set; }

        /// <summary>
        /// Gets or sets the dispatch time of the commander.
        /// </summary>
        public double DispatchTime { get; set; }
    }

    /// <summary>
    /// Represents information about weapons in the game.
    /// </summary>
    public class WeaponInformation
    {
        /// <summary>
        /// Gets or sets the list of weapon progress slot data.
        /// </summary>
        public List<WeaponProgressSlotData> WeaponProgressList { get; set; }
    }

    /// <summary>
    /// Represents the data for various in-game shops.
    /// </summary>
    public class ShopData
    {
        /// <summary>
        /// Gets or sets the daily shop data.
        /// </summary>
        public SecretShop DailyShop { get; set; }

        /// <summary>
        /// Gets or sets the raid shop data.
        /// </summary>
        public SecretShop RaidShop { get; set; }

        /// <summary>
        /// Gets or sets the wave duel shop data.
        /// </summary>
        public SecretShop WaveDuelShop { get; set; }

        /// <summary>
        /// Gets or sets the challenge shop data.
        /// </summary>
        public SecretShop ChallengeShop { get; set; }

        /// <summary>
        /// Gets or sets the buy VIP shop data.
        /// </summary>
        public BuyVipShop BuyVipShop { get; set; }
    }

    /// <summary>
    /// Represents daily buyable items.
    /// </summary>
    public class DailyBuyables
    {
        /// <summary>
        /// Gets or sets the number of raid keys available for purchase daily.
        /// </summary>
        public int RaidKeys { get; set; } = 5;
    }
}