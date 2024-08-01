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
                __nickname = user.UserResources.nickname,
                __annCoin = Convert.ToString(user.UserResources.annCoin),
                __level = Convert.ToString(user.UserResources.level),
                __blackChallenge = Convert.ToString(user.UserResources.BlackChallenge),
                __blueprintArmy = Convert.ToString(user.UserResources.blueprintArmy),
                __blueprintNavy = Convert.ToString(user.UserResources.blueprintNavy),
                __bullet = Convert.ToString(user.UserResources.bullet),
                __cash = Convert.ToString(user.UserResources.cash),
                __challenge = Convert.ToString(user.UserResources.challenge),
                __challengeCoin = Convert.ToString(user.UserResources.challengeCoin),
                __chip = Convert.ToString(user.UserResources.chip),
                __commanderGift = Convert.ToString(user.UserResources.commanderGift),
                __commanderPromotionPoint = Convert.ToString(user.UserResources.commanderPromotionPoint),
                __eventRaidTicket = Convert.ToString(user.UserResources.eventRaidTicket),
                __exp = Convert.ToString(user.UserResources.exp),
                __explorationTicket = Convert.ToString(user.UserResources.explorationTicket),
                __gold = Convert.ToString(user.UserResources.gold),
                __guildCoin = Convert.ToString(user.UserResources.guildCoin),
                __honor = Convert.ToString(user.UserResources.honor),
                __oil = Convert.ToString(user.UserResources.oil),
                __opcon = Convert.ToString(user.UserResources.opcon),
                __opener = Convert.ToString(user.UserResources.opener),
                __raidCoin = Convert.ToString(user.UserResources.raidCoin),
                __ring = Convert.ToString(user.UserResources.ring),
                __sweepTicket = Convert.ToString(user.UserResources.sweepTicket),
                __thumbnailId = Convert.ToString(user.UserResources.thumbnailId),
                __vipExp = Convert.ToString(user.UserResources.vipExp),
                __vipLevel = Convert.ToString(user.UserResources.vipLevel),
                __waveDuelCoin = Convert.ToString(user.UserResources.waveDuelCoin),
                __waveDuelTicket = Convert.ToString(user.UserResources.waveDuelTicket),
                __weaponImmediateTicket = Convert.ToString(user.UserResources.weaponImmediateTicket),
                __weaponMakeTicket = Convert.ToString(user.UserResources.weaponMakeTicket),
                __weaponMaterial1 = Convert.ToString(user.UserResources.weaponMaterial1),
                __weaponMaterial2 = Convert.ToString(user.UserResources.weaponMaterial2),
                __weaponMaterial3 = Convert.ToString(user.UserResources.weaponMaterial3),
                __weaponMaterial4 = Convert.ToString(user.UserResources.weaponMaterial4),
                __worldDuelCoin = Convert.ToString(user.UserResources.worldDuelCoin),
                __worldDuelTicket = Convert.ToString(user.UserResources.worldDuelTicket),
                __worldDuelUpgradeCoin = Convert.ToString(user.UserResources.worldDuelUpgradeCoin),
            };

            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = user.UserStatistics.NavyCommanderDestroyCount,
                stageClearCount = user.UserStatistics.StageClearCount,
                sweepClearCount = user.UserStatistics.SweepClearCount,
                preWinStreak = user.UserStatistics.PreWinStreak,
                raidHighScore = user.UserStatistics.RaidHighScore,
                vipShop = user.UserStatistics.VipShop,
                vipShopResetTime = user.UserStatistics.VipShopResetTime,
                weaponMakeSlotCount = user.UserStatistics.WeaponMakeSlotCount,
                winMostStreak = user.UserStatistics.WinMostStreak,
                winStreak = user.UserStatistics.WinStreak,
                arenaHighRank = user.UserStatistics.ArenaHighRank,
                armyCommanderDestroyCount = user.UserStatistics.ArmyCommanderDestroyCount,
                armyUnitDestroyCount = user.UserStatistics.ArmyUnitDestroyCount,
                commanderDestroyCount = user.UserStatistics.CommanderDestroyCount,
                firstPayment = user.UserStatistics.FirstPayment,
                navyUnitDestroyCount = user.UserStatistics.NavyUnitDestroyCount,
                normalGachaCount = user.UserStatistics.NormalGachaCount,
                predeckCount = user.UserStatistics.PredeckCount,
                premiumGachaCount = user.UserStatistics.PremiumGachaCount,
                pveLoseCount = user.UserStatistics.PveLoseCount,
                pveWinCount = user.UserStatistics.PveWinCount,
                pvpLoseCount = user.UserStatistics.PvpLoseCount,
                pvpWinCount = user.UserStatistics.PvpWinCount,
                raidHighRank = user.UserStatistics.RaidHighRank,
                totalGold = user.UserStatistics.TotalGold,
                totalPlunderGold = user.UserStatistics.TotalPlunderGold,
                weaponInventoryCount = user.UserStatistics.WeaponInventoryCount,
                unitDestroyCount = user.UserStatistics.UnitDestroyCount,
            };

            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = Resources,
                battleStatisticsInfo = BattleStatisticstis,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime, // should it be set?

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            return userInformationResponse;
        }

        public UserInformationResponse GetDatabaseUserInformationResponse(GameProfileScheme user)
        {
            var goods = DatabaseManager.GameProfile.UserResourcesFromSession(BasePacket.SessionId);
            var battlestats = DatabaseManager.GameProfile.UserStatisticsFromSession(BasePacket.SessionId);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime, // should be set?

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            return userInformationResponse;
        }
    }
}