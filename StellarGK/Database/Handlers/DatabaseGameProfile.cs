using MongoDB.Driver;
using StellarGK.Database.Schemes;
using StellarGK.Host.Handlers.Login;
using StellarGKLibrary.ExcelReader;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Utils;

namespace StellarGK.Database.Handlers
{
    public class DatabaseGameProfile : DatabaseTable<GameProfileScheme>
    {
        public DatabaseGameProfile() : base("GameProfile")
        {
        }

        public GameProfileScheme? GetOrCreate(int memberId, int server)
        {
            var tryUser = Collection.AsQueryable()
                       .Where(d => d.Server == server && d.MemberId == memberId)
                       .FirstOrDefault();

            if (tryUser != null) { return tryUser; }

            int uno = DatabaseManager.AutoIncrements.GetNextNumber("UNO", 1000);

            GameProfileScheme user = new()
            {
                Server = server,
                WorldMapStages = WorldMapStageData.GetInstance().AddAllStagesAtDefault(),
                WorldMapStagesReward = WorldMapStageData.GetInstance().AddDefaultWorldMapIsRewardCollected(),
                SweepClearData = new() { },
                LastStage = 0,
                UserStatistics = new()
                {
                    StageClearCount = 0,
                    SweepClearCount = 0,
                    PreWinStreak = 0,
                    RaidHighScore = 0,
                    VipShopResetTime = 0,
                    weaponMakeSlotCount = 0,
                    VipShop = 0,
                    WinStreak = 0,
                    ArenaHighRank = 0,
                    WinMostStreak = 0,
                    ArmyCommanderDestroyCount = 0,
                    ArmyUnitDestroyCount = 0,
                    CommanderDestroyCount = 0,
                    firstPayment = 0,
                    NavyCommanderDestroyCount = 0,
                    NavyUnitDestroyCount = 0,
                    NormalGachaCount = 0,
                    PredeckCount = 0,
                    PremiumGachaCount = 0,
                    PveLoseCount = 0,
                    PveWinCount = 0,
                    PvpLoseCount = 0,
                    PvpWinCount = 0,
                    RaidHighRank = 0,
                    TotalGold = 100000,
                    TotalPlunderGold = 0,
                    UnitDestroyCount = 0,
                    weaponInventoryCount = 0,
                },
                CommanderData = new()
                {
                },
                CompleteRewardGroupIdx = new()
                {
                },
                DispatchedCommanders = null,
                GuildId = null,
                MemberId = memberId,
                Notifaction = false,
                PreDeck = new() { },
                TutorialData = new()
                {
                    skip = false,
                    step = 0
                },
                UserDevice = new()
                {
                },
                UserInventory = new()
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
                ResetDateTime = 0,
                UserResources = new()
                {
                    sweepTicket = 0,
                    annCoin = 0,
                    BlackChallenge = 0,
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
                Uno = uno.ToString(),
                WorldState = 0,
                // result.worldState != -1;
                // if exploration is finished id assume
                LastLoginTime = 0,
                UserBadges = new()
                {
                    arena = 0,
                    dlms = 0,
                    achv = 0,
                    rwd = 0,
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
                VipRechargeData = new()
                {
                    new()
                    {
                        count = 9,
                        idx = 601,
                        mid = 0,
                    }
                },
                BlockedUsers = new()
                {
                },
                BoughtCashShopItems = new()
                {
                },
                Session = string.Empty,
                MailDataList = new()
                {
                },
                DailyBonusCheck = new()
                {
                },
            };

            Collection.InsertOne(user);

            return user;
        }

        public GameProfileScheme? FromUidAndServer(int memberId, int server)
        {
            var tryUser = Collection.AsQueryable()
                       .Where(d => d.Server == server && d.MemberId == memberId)
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
            return Collection.AsQueryable().Where(d => d.UserResources.nickname == nickname).Count() > 0;
        }

        public GameProfileScheme? FindBySession(string session)
        {
            var tryUser = Collection.AsQueryable()
                       .Where(d => d.Session == session)
                       .FirstOrDefault();

            if (tryUser == null)
            {
            }

            return tryUser;
        }

        public GameProfileScheme FindByNick(string nickname)
        {
            return Collection.AsQueryable().Where(d => d.UserResources.nickname == nickname).FirstOrDefault();
        }

        public UserInformationResponse.BattleStatistics UserStatisticsFromSession(string session)
        {
            var statistics = FindBySession(session).UserStatistics;

            UserInformationResponse.BattleStatistics BattleStatisticstis = new()
            {
                navyCommanderDestroyCount = statistics.NavyCommanderDestroyCount,
                stageClearCount = statistics.StageClearCount,
                sweepClearCount = statistics.SweepClearCount,
                preWinStreak = statistics.PreWinStreak,
                raidHighScore = statistics.RaidHighScore,
                vipShop = statistics.VipShop,
                vipShopResetTime = statistics.VipShopResetTime,
                weaponMakeSlotCount = statistics.weaponMakeSlotCount,
                winMostStreak = statistics.WinMostStreak,
                winStreak = statistics.WinStreak,
                arenaHighRank = statistics.ArenaHighRank,
                armyCommanderDestroyCount = statistics.ArmyCommanderDestroyCount,
                armyUnitDestroyCount = statistics.ArmyUnitDestroyCount,
                commanderDestroyCount = statistics.CommanderDestroyCount,
                firstPayment = statistics.firstPayment,
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
                weaponInventoryCount = statistics.weaponInventoryCount,
                unitDestroyCount = statistics.UnitDestroyCount,
            };

            return BattleStatisticstis;
        }

        public UserInformationResponse.Resource? UserResourcesFromSession(string session)
        {
            var resources = FindBySession(session).UserResources;

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

        public void UpdateUserResources(string session, UserResources resources)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources", resources);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGoldAndCash(string session, int new_gold, int new_cash, bool useAddition)
        {
            var user = FindBySession(session);

            int gold, cash, stats_gold;

            if (useAddition)
            {
                gold = user.UserResources.gold + new_gold;
                stats_gold = user.UserStatistics.TotalGold + new_gold;
                cash = user.UserResources.cash + new_cash;
            }
            else
            {
                gold = user.UserResources.gold - new_gold;
                stats_gold = user.UserStatistics.TotalGold - new_gold;
                cash = user.UserResources.cash - new_cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.gold", gold).Set("UserResources.cash", cash).Set("UserStatistics.totalGold", stats_gold);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateGold(string session, int gold, bool useAddition)
        {
            var user = FindBySession(session);

            int stats_gold;
            if (useAddition)
            {
                gold = user.UserResources.gold + gold;
                stats_gold = user.UserStatistics.TotalGold + gold;
            }
            else
            {
                gold = user.UserResources.gold - gold;
                stats_gold = user.UserStatistics.TotalGold - gold;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.gold", gold).Set("UserStatistics.totalGold", stats_gold);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateCash(string session, int cash, bool useAddition)
        {
            var user = FindBySession(session);

            if (useAddition)
            {
                cash = user.UserResources.cash + cash;
            }
            else
            {
                cash = user.UserResources.cash - cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("userResources.cash", cash);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateOnLogin(LoginRequest @params, string session)
        {
            UserDevice userDevice = new()
            {
                Apk = @params.apkFileName,
                Country = @params.countryCode,
                Device = @params.deviceName,
                Deviceid = @params.deviceId,
                Gameversion = @params.gameVersion,
                Gpid = @params.largoId,
                Language = @params.languageCode,
                OsCode = @params.osCode,
                Osversion = @params.osVersion,
                PatchType = @params.patchType,
                PlatformId = @params.platform,
                PushRegistrationId = @params.pushRegistrationId,
            };

            var CurrTimeStamp = Utility.CurrentTimeStamp();

            var filter = Builders<GameProfileScheme>.Filter.Eq("MemberId", @params.memberId) &
                         Builders<GameProfileScheme>.Filter.Eq("Server", @params.world);

            var update = Builders<GameProfileScheme>.Update.Set("Session", session).Set("UserDevice", userDevice).Set("LastLoginTime", CurrTimeStamp);

            Collection.UpdateOne(filter, update);

            DatabaseManager.Account.UpdateLastServerLoggedIn(@params.world, @params.memberId);
        }

        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateCommanderData(int id, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, id);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(string session, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(int id, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, id);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateItemData(string session, Dictionary<string, int> goods)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.itemData, goods);

            Collection.UpdateOne(filter, update);
        }

        public UserInformationResponse.TutorialData UpdateStepAndSkip(string session, UserInformationResponse.TutorialData tutorialData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("TutorialData", tutorialData);

            Collection.UpdateOne(filter, update);

            return FindBySession(session).TutorialData;
        }

        public bool ChangeThumbnail(string session, int idx)
        {
            int id = CommanderCostumeData.GetInstance().FromId(idx).ctid;

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.thumbnailId", id);

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public void UpdateStep(string session, int tutorialStep)
        {
            var user = FindBySession(session).TutorialData;

            user.step = tutorialStep;

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("TutorialData", user);

            Collection.UpdateOne(filter, update);
        }

        public void UpdateNickName(string session, string accountName)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.nickname", accountName);

            Collection.UpdateOne(filter, update);
        }

        public bool AddBlockedUser(BlockUser toBeBlocked, string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);
            var filter = Builders<GameProfileScheme>.Filter.Eq("MemberId", user.MemberId);
            var update = Builders<GameProfileScheme>.Update.Push("BlockedUsers", toBeBlocked);

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool DelBlockedUser(string session, int channel, string uno)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq("MemberId", user.MemberId),
                Builders<GameProfileScheme>.Filter.ElemMatch(x => x.BlockedUsers,
                    Builders<BlockUser>.Filter.And(
                        Builders<BlockUser>.Filter.Eq("ch", channel),
                        Builders<BlockUser>.Filter.Eq("uno", uno)
                    )
                )
            );

            var deleteResult = Collection.DeleteOne(filter);

            return deleteResult.DeletedCount > 0;
        }

        public bool ReadMail(string session, int MailIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<GameProfileScheme>.Filter.Eq("MemberId", user.MemberId);

            var update = Builders<GameProfileScheme>.Update.PullFilter("MailInfo",
                Builders<MailInfo.MailData>.Filter.And(
                    Builders<MailInfo.MailData>.Filter.Eq("idx", MailIdx)
                ));

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateNotifaction(string session, int onoff)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);
            var update = Builders<GameProfileScheme>.Update.Set("Notifaction", Convert.ToBoolean(onoff));

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateWorldMapReward(string session, int worldMapId)
        {
            var user = FindBySession(session);

            string mapId = "" + worldMapId;

            user.WorldMapStagesReward[mapId] = 1;

            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);
            var update = Builders<GameProfileScheme>.Update.Set("WorldMapStagesReward", user.WorldMapStagesReward);

            var updateResult = Collection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }
    }
}