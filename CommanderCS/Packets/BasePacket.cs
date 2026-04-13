using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets
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

    public abstract class BaseMethodHandler<TRequest>
    {
        public BasePacket BasePacket { get; set; }

        public abstract object Handle(TRequest reqParam);

        public string SessionId => BasePacket.SessionId;

        public AccountScheme? GetUserAccount()
        {
            return DatabaseManager.Account.FindBySession(BasePacket.SessionId);
        }

        public GameProfileScheme? GetUserGameProfile()
        {
            return DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);
        }

        public DormitoryScheme? GetUserDormitory()
        {
            return DatabaseManager.Dormitory.FindBySession(BasePacket.SessionId);
        }

        public GuildScheme GetUserGuild()
        {
            return DatabaseManager.Guild.FindBySession(BasePacket.SessionId);
        }

        public UserInformationResponse.BattleStatistics UserStatistics2BattleStatistics(UserBattleStatistics statistics)
        {
            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = statistics.NavyCommanderDestroyCount,
                stageClearCount = statistics.StageClearCount,
                sweepClearCount = statistics.SweepClearCount,
                preWinStreak = statistics.PreWinStreak,
                raidHighScore = statistics.RaidHighScore,
                vipShop = statistics.VipShop,
                vipShopResetTime = statistics.VipShopResetTime,
                weaponMakeSlotCount = statistics.WeaponMakeSlotCount,
                winMostStreak = statistics.WinMostStreak,
                winStreak = statistics.WinStreak,
                arenaHighRank = statistics.ArenaHighRank,
                armyCommanderDestroyCount = statistics.ArmyCommanderDestroyCount,
                armyUnitDestroyCount = statistics.ArmyUnitDestroyCount,
                commanderDestroyCount = statistics.CommanderDestroyCount,
                firstPayment = statistics.FirstPayment,
                navyUnitDestroyCount = statistics.NavyUnitDestroyCount,
                normalGachaCount = statistics.NormalGachaCount,
                predeckCount = statistics.PredeckCount,
                premiumGachaCount = statistics.PremiumGachaCount,
                pveLoseCount = statistics.PveLoseCount,
                pveWinCount = statistics.PveWinCount,
                pvpLoseCount = statistics.PvpLoseCount,
                pvpWinCount = statistics.PvpWinCount,
                raidHighRank = statistics.RaidHighRank,
                totalGold = statistics.TotalGold,
                totalPlunderGold = statistics.TotalPlunderGold,
                weaponInventoryCount = statistics.WeaponInventoryCount,
                unitDestroyCount = statistics.UnitDestroyCount,
            };

            return BattleStatisticstis;
        }

        public static UserInformationResponse.Resource? UserResources2Resource(UserResources resources)
        {
            UserInformationResponse.Resource resource = new()
            {
                __nickname = resources.nickname,
                __annCoin = Convert.ToString(resources.annCoin),
                __level = Convert.ToString(resources.level),
                __blackChallenge = Convert.ToString(resources.BlackChallenge),
                __blueprintArmy = Convert.ToString(resources.blueprintArmy),
                __blueprintNavy = Convert.ToString(resources.blueprintNavy),
                __bullet = Convert.ToString(resources.bullet),
                __cash = Convert.ToString(resources.cash),
                __challenge = Convert.ToString(resources.challenge),
                __challengeCoin = Convert.ToString(resources.challengeCoin),
                __chip = Convert.ToString(resources.chip),
                __commanderGift = Convert.ToString(resources.commanderGift),
                __commanderPromotionPoint = Convert.ToString(resources.commanderPromotionPoint),
                __eventRaidTicket = Convert.ToString(resources.eventRaidTicket),
                __exp = Convert.ToString(resources.exp),
                __explorationTicket = Convert.ToString(resources.explorationTicket),
                __gold = Convert.ToString(resources.gold),
                __guildCoin = Convert.ToString(resources.guildCoin),
                __honor = Convert.ToString(resources.honor),
                __oil = Convert.ToString(resources.oil),
                __opcon = Convert.ToString(resources.opcon),
                __opener = Convert.ToString(resources.opener),
                __raidCoin = Convert.ToString(resources.raidCoin),
                __ring = Convert.ToString(resources.ring),
                __sweepTicket = Convert.ToString(resources.sweepTicket),
                __thumbnailId = Convert.ToString(resources.thumbnailId),
                __vipExp = Convert.ToString(resources.vipExp),
                __vipLevel = Convert.ToString(resources.vipLevel),
                __waveDuelCoin = Convert.ToString(resources.waveDuelCoin),
                __waveDuelTicket = Convert.ToString(resources.waveDuelTicket),
                __weaponImmediateTicket = Convert.ToString(resources.weaponImmediateTicket),
                __weaponMakeTicket = Convert.ToString(resources.weaponMakeTicket),
                __weaponMaterial1 = Convert.ToString(resources.weaponMaterial1),
                __weaponMaterial2 = Convert.ToString(resources.weaponMaterial2),
                __weaponMaterial3 = Convert.ToString(resources.weaponMaterial3),
                __weaponMaterial4 = Convert.ToString(resources.weaponMaterial4),
                __worldDuelCoin = Convert.ToString(resources.worldDuelCoin),
                __worldDuelTicket = Convert.ToString(resources.worldDuelTicket),
                __worldDuelUpgradeCoin = Convert.ToString(resources.worldDuelUpgradeCoin),
            };

            return resource;
        }

        public UserInformationResponse GetUserInformationResponse(GameProfileScheme user)
        {
            var Resources = UserResources2Resource(user.Resources);
            var BattleStatisticstis = UserStatistics2BattleStatistics(user.Statistics);

            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);


            var userEquipData = Utility.ConvertEquipItem(user.Inventory.equipItem);

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

                equipItem = userEquipData,

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

            var userEquipData = Utility.ConvertEquipItem(user.Inventory.equipItem);

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

                equipItem = userEquipData,

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
        public SystemPacket GetDailyResetSystemMessage()
        {
            SystemPacket system = new()
            {
                Result = new()
                {
                    systemCheck = new()
                    {
                        message = new()
                        {
                            cn = "Daily Reset happend.",
                            en = "Daily Reset happend.",
                            jp = "Daily Reset happend.",
                            ko = "Daily Reset happend.",
                            ru = "Daily Reset happend.",
                            tw = "Daily Reset happend.",
                        },
                        nowTime = TimeManager.CurrentEpochMilliseconds
                    },
                }
            };

            return system;
        }
    }
}