using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class PacketAttribute : Attribute
    {
        public Method Id { get; set; }
    }

    public class BasePacket
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("method")]
        public int Method { get; set; }

        [JsonProperty("sess")]
        public string SessionId { get; set; }
    }

    public class ParamsPacket : BasePacket
    {
        [JsonProperty("params")]
        public JToken Params { get; set; }
    }

    public abstract class BaseMethodHandler<TParams>
    {
        public BasePacket BasePacket { get; set; }

        public abstract object Handle(TParams @params);

        public string SessionId => BasePacket.SessionId;

        private GameProfileScheme _user = null;

        public GameProfileScheme User
        {
            get
            {
                if (_user is null && BasePacket.SessionId is not null)
                {
                    _user = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);
                }
                return _user;
            }
        }

        private AccountScheme _account = null;

        public AccountScheme Account
        {
            get
            {
                if (_account is null && BasePacket.SessionId is not null)
                {
                    _account = DatabaseManager.Account.FindBySession(BasePacket.SessionId);
                }
                return _account;
            }
        }

        private DormitoryScheme _dormitory = null;

        public DormitoryScheme Dormitory
        {
            get
            {
                if (_dormitory is null && BasePacket.SessionId is not null)
                {
                    _dormitory = DatabaseManager.Dormitory.FindBySession(BasePacket.SessionId);
                }
                return _dormitory;
            }
        }

        private GuildScheme _guild = null;

        public GuildScheme Guild
        {
            get
            {
                if (_guild is null && BasePacket.SessionId is not null)
                {
                    _guild = DatabaseManager.Guild.FindBySession(BasePacket.SessionId);
                }
                return _guild;
            }
        }

        private Regulation _regulation = null;

        public Regulation Regulation
        {
            get
            {
                if (_regulation is null)
                {
                    _regulation = RemoteObjectManager.instance.regulation;
                }
                return _regulation;
            }
        }

        public UserInformationResponse GetUserInformationResponse(GameProfileScheme user)
        {
            UserInformationResponse.Resource Resources = new()
            {
                __nickname = user.Resources.nickname,
                __annCoin = Convert.ToString(user.Resources.annCoin),
                __level = Convert.ToString(user.Resources.level),
                __blackChallenge = Convert.ToString(user.Resources.BlackChallenge),
                __blueprintArmy = Convert.ToString(user.Resources.blueprintArmy),
                __blueprintNavy = Convert.ToString(user.Resources.blueprintNavy),
                __bullet = Convert.ToString(user.Resources.bullet),
                __cash = Convert.ToString(user.Resources.cash),
                __challenge = Convert.ToString(user.Resources.challenge),
                __challengeCoin = Convert.ToString(user.Resources.challengeCoin),
                __chip = Convert.ToString(user.Resources.chip),
                __commanderGift = Convert.ToString(user.Resources.commanderGift),
                __commanderPromotionPoint = Convert.ToString(user.Resources.commanderPromotionPoint),
                __eventRaidTicket = Convert.ToString(user.Resources.eventRaidTicket),
                __exp = Convert.ToString(user.Resources.exp),
                __explorationTicket = Convert.ToString(user.Resources.explorationTicket),
                __gold = Convert.ToString(user.Resources.gold),
                __guildCoin = Convert.ToString(user.Resources.guildCoin),
                __honor = Convert.ToString(user.Resources.honor),
                __oil = Convert.ToString(user.Resources.oil),
                __opcon = Convert.ToString(user.Resources.opcon),
                __opener = Convert.ToString(user.Resources.opener),
                __raidCoin = Convert.ToString(user.Resources.raidCoin),
                __ring = Convert.ToString(user.Resources.ring),
                __sweepTicket = Convert.ToString(user.Resources.sweepTicket),
                __thumbnailId = Convert.ToString(user.Resources.thumbnailId),
                __vipExp = Convert.ToString(user.Resources.vipExp),
                __vipLevel = Convert.ToString(user.Resources.vipLevel),
                __waveDuelCoin = Convert.ToString(user.Resources.waveDuelCoin),
                __waveDuelTicket = Convert.ToString(user.Resources.waveDuelTicket),
                __weaponImmediateTicket = Convert.ToString(user.Resources.weaponImmediateTicket),
                __weaponMakeTicket = Convert.ToString(user.Resources.weaponMakeTicket),
                __weaponMaterial1 = Convert.ToString(user.Resources.weaponMaterial1),
                __weaponMaterial2 = Convert.ToString(user.Resources.weaponMaterial2),
                __weaponMaterial3 = Convert.ToString(user.Resources.weaponMaterial3),
                __weaponMaterial4 = Convert.ToString(user.Resources.weaponMaterial4),
                __worldDuelCoin = Convert.ToString(user.Resources.worldDuelCoin),
                __worldDuelTicket = Convert.ToString(user.Resources.worldDuelTicket),
                __worldDuelUpgradeCoin = Convert.ToString(user.Resources.worldDuelUpgradeCoin),
            };

            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = user.Statistics.NavyCommanderDestroyCount,
                stageClearCount = user.Statistics.StageClearCount,
                sweepClearCount = user.Statistics.SweepClearCount,
                preWinStreak = user.Statistics.PreWinStreak,
                raidHighScore = user.Statistics.RaidHighScore,
                vipShop = user.Statistics.VipShop,
                vipShopResetTime = user.Statistics.VipShopResetTime,
                weaponMakeSlotCount = user.Statistics.WeaponMakeSlotCount,
                winMostStreak = user.Statistics.WinMostStreak,
                winStreak = user.Statistics.WinStreak,
                arenaHighRank = user.Statistics.ArenaHighRank,
                armyCommanderDestroyCount = user.Statistics.ArmyCommanderDestroyCount,
                armyUnitDestroyCount = user.Statistics.ArmyUnitDestroyCount,
                commanderDestroyCount = user.Statistics.CommanderDestroyCount,
                firstPayment = user.Statistics.FirstPayment,
                navyUnitDestroyCount = user.Statistics.NavyUnitDestroyCount,
                normalGachaCount = user.Statistics.NormalGachaCount,
                predeckCount = user.Statistics.PredeckCount,
                premiumGachaCount = user.Statistics.PremiumGachaCount,
                pveLoseCount = user.Statistics.PveLoseCount,
                pveWinCount = user.Statistics.PveWinCount,
                pvpLoseCount = user.Statistics.PvpLoseCount,
                pvpWinCount = user.Statistics.PvpWinCount,
                raidHighRank = user.Statistics.RaidHighRank,
                totalGold = user.Statistics.TotalGold,
                totalPlunderGold = user.Statistics.TotalPlunderGold,
                weaponInventoryCount = user.Statistics.WeaponInventoryCount,
                unitDestroyCount = user.Statistics.UnitDestroyCount,
            };

            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = Resources,
                battleStatisticsInfo = BattleStatisticstis,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notification,

                foodData = user.Inventory.foodData,
                eventResourceData = user.Inventory.eventResourceData,
                groupItemData = user.Inventory.groupItemData,
                itemData = user.Inventory.itemData,
                medalData = user.Inventory.medalData,
                partData = user.Inventory.partData,

                resetRemain = user.ResetDateTime, // should it be set?

                equipItem = user.Inventory.equipItem,

                donHaveCommCostumeData = user.Inventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.Inventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            return userInformationResponse;
        }

        public UserInformationResponse GetUserInformationResponse(GameProfileScheme user, string commanderId)
        {
            UserInformationResponse.Resource Resources = new()
            {
                __nickname = user.Resources.nickname,
                __annCoin = Convert.ToString(user.Resources.annCoin),
                __level = Convert.ToString(user.Resources.level),
                __blackChallenge = Convert.ToString(user.Resources.BlackChallenge),
                __blueprintArmy = Convert.ToString(user.Resources.blueprintArmy),
                __blueprintNavy = Convert.ToString(user.Resources.blueprintNavy),
                __bullet = Convert.ToString(user.Resources.bullet),
                __cash = Convert.ToString(user.Resources.cash),
                __challenge = Convert.ToString(user.Resources.challenge),
                __challengeCoin = Convert.ToString(user.Resources.challengeCoin),
                __chip = Convert.ToString(user.Resources.chip),
                __commanderGift = Convert.ToString(user.Resources.commanderGift),
                __commanderPromotionPoint = Convert.ToString(user.Resources.commanderPromotionPoint),
                __eventRaidTicket = Convert.ToString(user.Resources.eventRaidTicket),
                __exp = Convert.ToString(user.Resources.exp),
                __explorationTicket = Convert.ToString(user.Resources.explorationTicket),
                __gold = Convert.ToString(user.Resources.gold),
                __guildCoin = Convert.ToString(user.Resources.guildCoin),
                __honor = Convert.ToString(user.Resources.honor),
                __oil = Convert.ToString(user.Resources.oil),
                __opcon = Convert.ToString(user.Resources.opcon),
                __opener = Convert.ToString(user.Resources.opener),
                __raidCoin = Convert.ToString(user.Resources.raidCoin),
                __ring = Convert.ToString(user.Resources.ring),
                __sweepTicket = Convert.ToString(user.Resources.sweepTicket),
                __thumbnailId = Convert.ToString(user.Resources.thumbnailId),
                __vipExp = Convert.ToString(user.Resources.vipExp),
                __vipLevel = Convert.ToString(user.Resources.vipLevel),
                __waveDuelCoin = Convert.ToString(user.Resources.waveDuelCoin),
                __waveDuelTicket = Convert.ToString(user.Resources.waveDuelTicket),
                __weaponImmediateTicket = Convert.ToString(user.Resources.weaponImmediateTicket),
                __weaponMakeTicket = Convert.ToString(user.Resources.weaponMakeTicket),
                __weaponMaterial1 = Convert.ToString(user.Resources.weaponMaterial1),
                __weaponMaterial2 = Convert.ToString(user.Resources.weaponMaterial2),
                __weaponMaterial3 = Convert.ToString(user.Resources.weaponMaterial3),
                __weaponMaterial4 = Convert.ToString(user.Resources.weaponMaterial4),
                __worldDuelCoin = Convert.ToString(user.Resources.worldDuelCoin),
                __worldDuelTicket = Convert.ToString(user.Resources.worldDuelTicket),
                __worldDuelUpgradeCoin = Convert.ToString(user.Resources.worldDuelUpgradeCoin),
            };

            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = user.Statistics.NavyCommanderDestroyCount,
                stageClearCount = user.Statistics.StageClearCount,
                sweepClearCount = user.Statistics.SweepClearCount,
                preWinStreak = user.Statistics.PreWinStreak,
                raidHighScore = user.Statistics.RaidHighScore,
                vipShop = user.Statistics.VipShop,
                vipShopResetTime = user.Statistics.VipShopResetTime,
                weaponMakeSlotCount = user.Statistics.WeaponMakeSlotCount,
                winMostStreak = user.Statistics.WinMostStreak,
                winStreak = user.Statistics.WinStreak,
                arenaHighRank = user.Statistics.ArenaHighRank,
                armyCommanderDestroyCount = user.Statistics.ArmyCommanderDestroyCount,
                armyUnitDestroyCount = user.Statistics.ArmyUnitDestroyCount,
                commanderDestroyCount = user.Statistics.CommanderDestroyCount,
                firstPayment = user.Statistics.FirstPayment,
                navyUnitDestroyCount = user.Statistics.NavyUnitDestroyCount,
                normalGachaCount = user.Statistics.NormalGachaCount,
                predeckCount = user.Statistics.PredeckCount,
                premiumGachaCount = user.Statistics.PremiumGachaCount,
                pveLoseCount = user.Statistics.PveLoseCount,
                pveWinCount = user.Statistics.PveWinCount,
                pvpLoseCount = user.Statistics.PvpLoseCount,
                pvpWinCount = user.Statistics.PvpWinCount,
                raidHighRank = user.Statistics.RaidHighRank,
                totalGold = user.Statistics.TotalGold,
                totalPlunderGold = user.Statistics.TotalPlunderGold,
                weaponInventoryCount = user.Statistics.WeaponInventoryCount,
                unitDestroyCount = user.Statistics.UnitDestroyCount,
            };

            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);


            var keysToRemove = user.CommanderData.Keys
                .Where(key => key != commanderId)
                .ToList();

            // Remove all keys except the one to keep
            foreach (var key in keysToRemove)
            {
                user.CommanderData.Remove(key);
            }

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = Resources,
                battleStatisticsInfo = BattleStatisticstis,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notification,

                foodData = user.Inventory.foodData,
                eventResourceData = user.Inventory.eventResourceData,
                groupItemData = user.Inventory.groupItemData,
                itemData = user.Inventory.itemData,
                medalData = user.Inventory.medalData,
                partData = user.Inventory.partData,

                resetRemain = user.ResetDateTime, // should it be set?

                equipItem = user.Inventory.equipItem,

                donHaveCommCostumeData = user.Inventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.Inventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            return userInformationResponse;
        }

        public UserInformationResponse DatabaseGetUserInformationResponse(GameProfileScheme user)
        {
            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(BasePacket.SessionId);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(BasePacket.SessionId);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            var commanderData = JObject.FromObject(user.CommanderData);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notification,

                foodData = user.Inventory.foodData,
                eventResourceData = user.Inventory.eventResourceData,
                groupItemData = user.Inventory.groupItemData,
                itemData = user.Inventory.itemData,
                medalData = user.Inventory.medalData,
                partData = user.Inventory.partData,

                resetRemain = user.ResetDateTime, // should be set?

                equipItem = user.Inventory.equipItem,

                donHaveCommCostumeData = user.Inventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.Inventory.weaponList,
                __commanderInfo = commanderData,
            };

            return userInformationResponse;
        }
    }
}