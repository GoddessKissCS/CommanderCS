using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host.Handlers.Login;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;
using StellarGK.Tools;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameProfile : DatabaseTable<GameProfileScheme>
    {
        public DatabaseGameProfile() : base("GameProfile") { }
        public GameProfileScheme? GetOrCreate(int memberId, int server)
        {
            var tryUser = collection.AsQueryable()
                       .Where(d => d.server == server && d.memberId == memberId)
                       .FirstOrDefault();

            if (tryUser != null) { return tryUser; }

            int uno = DatabaseManager.AutoIncrements.GetNextNumber("UNO", 1000);

            GameProfileScheme user = new()
            {
                server = server,
                stages = WorldMapStageData.GetInstance().AddAllStagesAtDefault(),
                sweepClearData = new() { },
                lastStage = 0,
                userStatistics = new()
                {
                    stageClearCount = 0,
                    sweepClearCount = 0,
                    preWinStreak = 0,
                    raidHighScore = 0,
                    vipShopResetTime = 0,
                    weaponMakeSlotCount = 0,
                    vipShop = 0,
                    winStreak = 0,
                    arenaHighRank = 0,
                    winMostStreak = 0,
                    armyCommanderDestroyCount = 0,
                    armyUnitDestroyCount = 0,
                    commanderDestroyCount = 0,
                    firstPayment = 0,
                    navyCommanderDestroyCount = 0,
                    navyUnitDestroyCount = 0,
                    normalGachaCount = 0,
                    predeckCount = 0,
                    premiumGachaCount = 0,
                    pveLoseCount = 0,
                    pveWinCount = 0,
                    pvpLoseCount = 0,
                    pvpWinCount = 0,
                    raidHighRank = 0,
                    totalGold = 100000,
                    totalPlunderGold = 0,
                    unitDestroyCount = 0,
                    weaponInventoryCount = 0,
                },
                commanderData = new() { },
                completeRewardGroupIdx = new() { },
                dispatchedCommanders = new() { },
                guildId = null,
                memberId = memberId,
                notifaction = false,
                preDeck = new() { },
                tutorialData = new() { skip = false, step = 0 },
                userDevice = new() { },
                userInventory = new()
                {
                    equipItem = new() { },
                    donHaveCommCostumeData = new() { },
                    eventResourceData = new() { },
                    groupItemData = new() { },
                    foodData = new() { },
                    itemData = new() { },
                    medalData = new() { },
                    partData = new() { },
                    weaponList = new() { }
                },
                resetDateTime = 0,
                userResources = new()
                {
                    sweepTicket = 0,
                    annCoin = 0,
                    blackChallenge = 0,
                    blueprintArmy = 0,
                    blueprintNavy = 0,
                    bullet = 500,
                    cash = 500,
                    challenge = 0,
                    challengeCoin = 0,
                    chip = 0,
                    commanderGift = 0,
                    commanderPromotionPoint = 0,
                    eventRaidTicket = 0,
                    exp = 0,
                    gold = 100000,
                    explorationTicket = 0,
                    guildCoin = 0,
                    honor = 0,
                    level = 1,
                    opcon = 0,
                    oil = 0,
                    opener = 0,
                    raidCoin = 0,
                    ring = 0,
                    thumbnailId = 1001,
                    vipExp = 0,
                    vipLevel = 0,
                    waveDuelCoin = 0,
                    weaponImmediateTicket = 0,
                    waveDuelTicket = 0,
                    weaponMakeTicket = 0,
                    weaponMaterial1 = 0,
                    weaponMaterial2 = 0,
                    weaponMaterial3 = 0,
                    weaponMaterial4 = 0,
                    worldDuelCoin = 0,
                    worldDuelTicket = 0,
                    worldDuelUpgradeCoin = 0,
                },
                uno = uno.ToString(),
                worldState = 0,
                // result.worldState != -1;
                // if exploration is finished id assume
                lastLoginTime = 0,
                userBadges = new()
                {
                    arena = 1,
                    dlms = 1,
                    achv = 1,
                    rwd = 1,
                    shop = new Dictionary<string, int>()
                {
                    { "raid", 0 },
                    { "arena3", 0 },
                    { "arena", 0 }
                },
                    cnvl = new List<string>(),
                    ccnv = 0,
                    cnvl2 = new List<string>(),
                    ccvn2 = 0,
                    cnvl3 = new List<string>(),
                    ccvn3 = 0,
                    wb = 0,
                    gb = 0,
                    grp = 0,
                    ercnt = 0,
                    iftw = 0,
                },
                vipRechargeData = new() { },
            };

            collection.InsertOne(user);

            return user;
        }

        public GameProfileScheme? FromUidAndServer(int memberId, int server)
        {
            var tryUser = collection.AsQueryable()
                       .Where(d => d.server == server && d.memberId == memberId)
                       .FirstOrDefault();

            if (tryUser != null)
            {
                return tryUser;
            }
            else
            {
                return GetOrCreate(memberId, server);
            }
        }

        public bool AccountExists(string nickname)
        {
            return collection.AsQueryable().Where(d => d.userResources.nickname == nickname).Count() > 0;
        }

        public GameProfileScheme? FindBySession(string session)
        {
            var tryUser = collection.AsQueryable()
                       .Where(d => d.session == session)
                       .FirstOrDefault();

            if (tryUser == null)
            {

            }

            return tryUser;
        }

        public GameProfileScheme FindByNick(string nickname)
        {
            GameProfileScheme? user = collection.AsQueryable().Where(d => d.userResources.nickname == nickname).FirstOrDefault();
            return user;
        }


        public UserInformationResponse.BattleStatistics UserStatisticsFromSession(string session)
        {
            var statistics = FindBySession(session).userStatistics;

            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = statistics.navyCommanderDestroyCount,
                stageClearCount = statistics.stageClearCount,
                sweepClearCount = statistics.sweepClearCount,
                preWinStreak = statistics.preWinStreak,
                raidHighScore = statistics.raidHighScore,
                vipShop = statistics.vipShop,
                vipShopResetTime = statistics.vipShopResetTime,
                weaponMakeSlotCount = statistics.weaponMakeSlotCount,
                winMostStreak = statistics.winMostStreak,
                winStreak = statistics.winStreak,
                arenaHighRank = statistics.arenaHighRank,
                armyCommanderDestroyCount = statistics.armyCommanderDestroyCount,
                armyUnitDestroyCount = statistics.armyUnitDestroyCount,
                commanderDestroyCount = statistics.commanderDestroyCount,
                firstPayment = statistics.firstPayment,
                navyUnitDestroyCount = statistics.navyUnitDestroyCount,
                normalGachaCount = statistics.normalGachaCount,
                predeckCount = statistics.predeckCount,
                premiumGachaCount = statistics.premiumGachaCount,
                pveLoseCount = statistics.pveLoseCount,
                pveWinCount = statistics.pveWinCount,
                pvpLoseCount = statistics.pvpLoseCount,
                pvpWinCount = statistics.pvpWinCount,
                raidHighRank = statistics.raidHighRank,
                totalGold = statistics.totalGold,
                totalPlunderGold = statistics.totalPlunderGold,
                weaponInventoryCount = statistics.weaponInventoryCount,
                unitDestroyCount = statistics.unitDestroyCount,
            };

            return BattleStatisticstis;
        }

        public UserInformationResponse.Resource? UserResourcesFromSession(string session)
        {
            var resources = FindBySession(session).userResources;

            UserInformationResponse.Resource resource = new()
            {
                __nickname = resources.nickname,
                __annCoin = Convert.ToString(resources.annCoin),
                __level = Convert.ToString(resources.level),
                __blackChallenge = Convert.ToString(resources.blackChallenge),
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

        public void UpdateGoldAndCash(string session, int new_gold, int new_cash, bool useAddition)
        {
            var user = FindBySession(session);

            int gold, cash, stats_gold;

            if (useAddition)
            {
                gold = user.userResources.gold + new_gold;
                stats_gold = user.userStatistics.totalGold + new_gold;
                cash = user.userResources.cash + new_cash;
            }
            else
            {
                gold = user.userResources.gold - new_gold;
                stats_gold = user.userStatistics.totalGold - new_gold;
                cash = user.userResources.cash - new_cash;
            }


            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.gold", gold).Set("userResources.cash", cash).Set("userStatistics.totalGold", stats_gold);

            collection.UpdateOne(filter, update);

        }
        public void UpdateGold(string session, int gold, bool useAddition)
        {
            var user = FindBySession(session);

            int stats_gold;
            if (useAddition)
            {
                gold = user.userResources.gold + gold;
                stats_gold = user.userStatistics.totalGold + gold;
            }
            else
            {
                gold = user.userResources.gold - gold;
                stats_gold = user.userStatistics.totalGold - gold;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.gold", gold).Set("userStatistics.totalGold", stats_gold);

            collection.UpdateOne(filter, update);


        }
        public void UpdateCash(string session, int cash, bool useAddition)
        {
            var user = FindBySession(session);

            if (useAddition)
            {
                cash = user.userResources.cash + cash;

            }
            else
            {
                cash = user.userResources.cash - cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.cash", cash);

            collection.UpdateOne(filter, update);

        }

        public void UpdateOnLogin(LoginRequest @params, string session)
        {

            UserDevice userDevice = new()
            {
                apk = @params.apkFileName,
                country = @params.countryCode,
                device = @params.deviceName,
                deviceid = @params.deviceId,
                gameversion = @params.gameVersion,
                gpid = @params.largoId,
                language = @params.languageCode,
                osCode = (int)@params.osCode,
                osversion = @params.osVersion,
                patchType = @params.patchType,
                platformId = (int)@params.platform,
                pushRegistrationId = @params.pushRegistrationId,
            };


            var filter = Builders<GameProfileScheme>.Filter.Eq("memberId", @params.memberId) &
                         Builders<GameProfileScheme>.Filter.Eq("server", @params.world);

            var update = Builders<GameProfileScheme>.Update.Set("session", session).Set("userDevice", userDevice).Set("lastLoginTime", Constants.CurrentTimeStamp);

            collection.UpdateOne(filter, update);

            DatabaseManager.Account.UpdateLastServerLoggedIn(@params.world, @params.memberId);
        }

        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.commanderData, commanderList);

            collection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(string session, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.userInventory.medalData, medalsdata);

            collection.UpdateOne(filter, update);
        }

        public void UpdateItemData(string session, Dictionary<string, int> goods)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.userInventory.itemData, goods);

            collection.UpdateOne(filter, update);
        }


        public UserInformationResponse.TutorialData UpdateStepAndSkip(string session, UserInformationResponse.TutorialData tutorialData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("tutorialData", tutorialData);

            collection.UpdateOne(filter, update);

            return FindBySession(session).tutorialData;
        }

        public bool ChangeThumbnail(string session, int idx)
        {
            int id = CommanderCostumeData.GetInstance().FromId(idx).ctid;

            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.thumbnailId", id);

            var updateResult =  collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;

        }

        public void UpdateStep(string session, int tutorialStep)
        {
            var user = FindBySession(session).tutorialData;

            user.step = tutorialStep;

            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("tutorialData", user);

            collection.UpdateOne(filter, update);
        }

        public void UpdateNickName(string session, string accountName)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.nickname", accountName);

            collection.UpdateOne(filter, update);
        }

        public bool AddBlockedUser(BlockUser toBeBlocked, string session)
        {

            var user = DatabaseManager.GameProfile.FindBySession(session);
            var filter = Builders<GameProfileScheme>.Filter.Eq("Id", user.memberId);
            var update = Builders<GameProfileScheme>.Update.Push("blockedUsers", toBeBlocked);

            var updateResult = collection.UpdateOne(filter, update);

            if (updateResult.ModifiedCount > 0)
            {
                return true;
            }
            return false;
        }
        public bool DelBlockedUser(string session, int channel, string uno)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<GameProfileScheme>.Filter.Eq("memberId", user.memberId);
            var update = Builders<GameProfileScheme>.Update.PullFilter("blockedUsers",
                         Builders<BlockUser>.Filter.And(
                         Builders<BlockUser>.Filter.Eq("ch", channel),
                         Builders<BlockUser>.Filter.Eq("uno", uno)
                                                             ));

            var updateResult = collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

    }
}
