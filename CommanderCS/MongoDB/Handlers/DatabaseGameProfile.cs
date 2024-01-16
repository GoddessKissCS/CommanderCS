using CommanderCS.Host;
using CommanderCS.Host.Handlers.Login;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Protocols;
using MongoDB.Driver;

namespace CommanderCS.MongoDB.Handlers
{
    public class DatabaseGameProfile : DatabaseTable<GameProfileScheme>
    {
        public DatabaseGameProfile() : base("GameProfile")
        {
        }

        public GameProfileScheme? GetOrCreate(int memberId, int server)
        {
            var existingUser = DatabaseCollection.AsQueryable()
                .Where(d => d.Server == server && d.MemberId == memberId)
                .FirstOrDefault();

            if (existingUser != null)
            {
                return existingUser;
            }

            int uno = DatabaseManager.AutoIncrements.GetNextNumber("UNO");

            var WorldMapStages = Constants.regulation.GetAllWorldMapStages();

            var currTime = TimeManager.CurrentEpoch;

            GameProfileScheme user = new()
            {
                Server = server,
                LastStage = 0,
                UserStatistics = new() { },
                CommanderData = [],
                CompleteRewardGroupIdx = [],
                DispatchedCommanders = null,
                ExplorationData = [],
                GuildId = null,
                MemberId = memberId,
                Notifaction = false,
                PreDeck =
                [
                    new()
                    {
                        idx = 0,
                        name = "Deck 1",
                        deckData = []
                    },
                    new()
                    {
                        idx = 1,
                        name = "Deck 2",
                        deckData = []
                    },
                    new()
                    {
                        idx = 2,
                        name = "Deck 3",
                        deckData = []
                    },
                    new()
                    {
                        idx = 3,
                        name = "Deck 4",
                        deckData = []
                    },
                    new()
                    {
                        idx = 4,
                        name = "Deck 5",
                        deckData = []
                    }
                ],
                TutorialData = new() { skip = false, step = 0 },
                UserDevice = new() { },
                UserInventory = new UserInventory()
                {
                    medalData = new()
                    {
                        { "1", 10 }
                    },
                    equipItem = [],
                    itemData = [],
                    foodData = [],
                    groupItemData = [],
                    partData = [],
                    weaponList = [],
                    eventResourceData = [],
                    donHaveCommCostumeData = [],
                    costumeData = [],
                },
                ResetDateTime = 0,
                UserResources = new() { },
                Uno = uno,
                WorldState = 0,
                // result.worldState != -1;
                // if exploration is finished id assume
                LastLoginTime = currTime,
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
                    cnvl = [],
                    ccnv = 0,
                    cnvl2 = [],
                    ccvn2 = 0,
                    cnvl3 = [],
                    ccvn3 = 0,
                    wb = 0,
                    gb = 0,
                    grp = 0,
                    ercnt = 0,
                    iftw = 0,
                },
                VipRechargeData = [new() { count = 0, idx = 601, mid = 0 }],
                BlockedUsers = [],
                BoughtCashShopItems = [],
                Session = string.Empty,
                MailDataList = [],
                DailyBonusCheck = [],
                DefenderDeck = new()
                {
                    PvPDefenderDeck = [],
                    WaveDuelDefenderDecks = []
                },
                BattleData = new()
                {
                    WorldMapStageReward = new()
                    {
                        { "0", 0 },
                        { "1", 0 },
                        { "2", 0 },
                        { "3", 0 },
                        { "4", 0 },
                        { "5", 0 },
                        { "6", 0 },
                        { "7", 0 },
                        { "8", 0 },
                        { "9", 0 },
                        { "10", 0 },
                        { "11", 0 },
                        { "12", 0 },
                        { "13", 0 },
                        { "14", 0 },
                        { "15", 0 },
                        { "16", 0 },
                        { "17", 0 },
                        { "18", 0 },
                    },
                    WorldMapStages = WorldMapStages,
                    SweepClearData = []
                },
                RankingData = new()
                {
                    PvPDuelRankingData = new()
                    {
                        score = 1000
                    },
                    WaveDuelRankingData = new()
                },
            };

            DatabaseCollection.InsertOne(user);

            DatabaseManager.Dormitory.Create(uno);

            return user;
        }

        public GameProfileScheme? FromUidAndServer(int memberId, int server)
        {
            var tryUser = DatabaseCollection.AsQueryable()
                          .Where(d => d.Server == server && d.MemberId == memberId)
                          .FirstOrDefault();

            if (tryUser != null)
            {
                return tryUser;
            }

            return GetOrCreate(memberId, server);
        }

        public bool AccountExists(string nickname)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.UserResources.nickname == nickname).Any();
        }

        public bool SessionTokenExists(string session)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Session == session).Any();
        }

        public GameProfileScheme? FindBySession(string session)
        {
            var tryUser = DatabaseCollection.AsQueryable()
                          .Where(d => d.Session == session)
                          .FirstOrDefault();

            if (tryUser == null)
            {
            }

            return tryUser;
        }

        public GameProfileScheme FindByUno(int uno)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uno).FirstOrDefault();
        }

        public GameProfileScheme FindByNick(string nickname)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.UserResources.nickname == nickname).FirstOrDefault();
        }

        public List<GameProfileScheme> FindByMemberIdList(string memberId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.MemberId == int.Parse(memberId)).ToList();
        }

        public string GetGameProfileSchemeCount()
        {
            var filter = Builders<GameProfileScheme>.Filter.Empty;

            long count = DatabaseCollection.CountDocuments(filter);

            return count.ToString();
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

        public UserInformationResponse.Resource? UserResources2Resource(UserResources resources)
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

        public void UpdateUserResources(string session, UserResources resources)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources, resources);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateGoldAndCash(string session, int new_gold, int new_cash, bool useAddition)
        {
            var user = FindBySession(session);

            if (useAddition)
            {
                user.UserResources.gold += new_gold;
                user.UserStatistics.TotalGold += new_gold;
                user.UserResources.cash += new_cash;
            }
            else
            {
                user.UserResources.gold -= new_gold;
                user.UserStatistics.TotalGold -= new_gold;
                user.UserResources.cash -= new_cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.gold, user.UserResources.gold).Set(x => x.UserResources.cash, user.UserResources.cash).Set(x => x.UserStatistics.TotalGold, user.UserStatistics.TotalGold);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateGold(string session, int gold, bool useAddition)
        {
            var user = FindBySession(session);

            if (useAddition)
            {
                user.UserResources.gold += gold;
                user.UserStatistics.TotalGold += gold;
            }
            else
            {
                user.UserResources.gold -= gold;
                user.UserStatistics.TotalGold -= gold;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.gold, user.UserResources.gold).Set(x => x.UserStatistics.TotalGold, user.UserStatistics.TotalGold);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public GameProfileScheme UpdateCash(string session, int cash, bool useAddition)
        {
            var user = FindBySession(session);

            if (useAddition)
            {
                user.UserResources.cash += cash;
            }
            else
            {
                user.UserResources.cash -= cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.cash, user.UserResources.cash);

            var options = new FindOneAndUpdateOptions<GameProfileScheme>
            {
                ReturnDocument = ReturnDocument.After, // Return the updated document
            };

            var updatedUser = DatabaseCollection.FindOneAndUpdate(filter, update, options);

            return updatedUser;
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

            var CurrTimeStamp = TimeManager.CurrentEpoch;

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, @params.memberId) &
                         Builders<GameProfileScheme>.Filter.Eq(x => x.Server, @params.world);

            var update = Builders<GameProfileScheme>.Update.Set(x => x.Session, session).Set(x => x.UserDevice, userDevice).Set(x => x.LastLoginTime, CurrTimeStamp);

            DatabaseCollection.UpdateOne(filter, update);

            DatabaseManager.Account.UpdateLastServerLoggedIn(@params.world, @params.memberId);
        }

        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateFoodData(string session, Dictionary<string, int> foodData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.foodData, foodData);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateDontHaveCommanderCostumeData(string session, Dictionary<string, List<int>> donthaveCostumes)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.donHaveCommCostumeData, donthaveCostumes);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateCommanderDataAndMedalData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList).Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(string session, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateItemData(string session, Dictionary<string, int> goods)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.itemData, goods);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdatePartData(string session, Dictionary<string, int> goods)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.partData, goods);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateTutorialData(string session, UserInformationResponse.TutorialData tutorialData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.TutorialData, tutorialData);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public bool ChangeThumbnailId(string session, int idx)
        {
            int id = Constants.regulation.commanderCostumeDtbl.FirstOrDefault(x => x.cid == idx).ctid;

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.thumbnailId, id);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public void UpdateTutorialStep(string session, int tutorialStep)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.TutorialData.step, tutorialStep);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateNickName(string session, string accountName)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.nickname, accountName);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public bool AddBlockedUser(string session, BlockUser blockUser)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Push(x => x.BlockedUsers, blockUser);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool DelBlockedUser(string session, int channel, string uno)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session),
                Builders<GameProfileScheme>.Filter.ElemMatch(x => x.BlockedUsers,
                    Builders<BlockUser>.Filter.And(
                        Builders<BlockUser>.Filter.Eq(x => x.channel, channel),
                        Builders<BlockUser>.Filter.Eq(x => x.uno, uno)
                                                  )
                                                            )
                                                               );

            var deleteResult = DatabaseCollection.DeleteOne(filter);

            return deleteResult.DeletedCount > 0;
        }

        public bool ReadMail(string session, int MailIdx)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, user.MemberId);

            var update = Builders<GameProfileScheme>.Update.PullFilter(x => x.MailDataList,
                Builders<MailInfo.MailData>.Filter.And(
                    Builders<MailInfo.MailData>.Filter.Eq(x => x.idx, MailIdx)
                                                      ));

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateNotifaction(string session, int onoff)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.Notifaction, Convert.ToBoolean(onoff));

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateWorldMapReward(string session, int worldMapId, Dictionary<string, int> StageReward)
        {
            string worldMapid = worldMapId.ToString();

            StageReward[worldMapid] = 1;

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.BattleData.WorldMapStageReward, StageReward);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public void UpdateVipRechargeData(string session, List<UserInformationResponse.VipRechargeData> vipRechargedata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.VipRechargeData, vipRechargedata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateVipRechargeCount(string session, int idx, int newCount)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session),
                Builders<GameProfileScheme>.Filter.Eq("VipRechargeData.idx", idx)
                                                               );

            var update = Builders<GameProfileScheme>.Update.Set(
                "VipRechargeData.$.count",
                newCount
                                                               );

            DatabaseCollection.UpdateOne(filter, update);
        }

        public int GetVipRechargeCount(string session, int idx)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session),
                Builders<GameProfileScheme>.Filter.Eq("VipRechargeData.idx", idx)
                                                               );

            var projection = Builders<GameProfileScheme>.Projection.Expression(x => x.VipRechargeData[-1].count);

            var result = DatabaseCollection.Find(filter).Project(projection).FirstOrDefault();

            return result;
        }

        public void UpdateProfile(string session, GameProfileScheme user)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);

            DatabaseCollection.ReplaceOne(filter, user);
        }

        public void UpdateGuild(int uno, object? guildId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Uno, uno);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.GuildId, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateGuildId(int uno, int guildId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Uno, uno);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.GuildId, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdatePreDeck(string session, List<UserInformationResponse.PreDeck> preDecks)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.PreDeck, preDecks);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void AddEmptyPreDeckSlot(string session, int preDeckCount)
        {
            UserInformationResponse.PreDeck emptyPreDeck = new()
            {
                idx = preDeckCount,
                name = string.Empty,
                deckData = []
            };

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Push(x => x.PreDeck, emptyPreDeck);
            DatabaseCollection.UpdateOne(filter, update);

            var filter2 = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update2 = Builders<GameProfileScheme>.Update.Set(x => x.UserStatistics.PredeckCount, preDeckCount + 1);
            DatabaseCollection.UpdateOne(filter2, update2);
        }

        public ErrorCode RequestNicknameAfterTutorial(string sess, string nickname)
        {
            if (Misc.NameCheck(nickname))
            {
                return ErrorCode.InappropriateWords;
            }

            if (AccountExists(nickname))
            {
                return ErrorCode.AlreadyInUse;
            }

            var userGameProfile = FindBySession(sess);

            if (userGameProfile.TutorialData.skip != true)
            {
                UpdateTutorialStep(sess, 2);
            }

            DatabaseManager.GameProfile.UpdateNickName(sess, nickname);

            return ErrorCode.Success;
        }

        public ErrorCode RequestNickNameChange(string AccountName, string sess)
        {
            if (Misc.NameCheck(AccountName))
            {
                return ErrorCode.InappropriateWords;
            }

            if (AccountExists(AccountName))
            {
                return ErrorCode.AlreadyInUse;
            }

            DatabaseManager.GameProfile.UpdateNickName(sess, AccountName);
            DatabaseManager.GameProfile.UpdateCash(sess, 100, false);

            return ErrorCode.Success;
        }

        public void UpdateDispatchedCommander(string session, Dictionary<string, DispatchedCommanderInfo> dispatchedCommanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DispatchedCommanders, dispatchedCommanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateRings(string session, int ring)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.ring, ring);

            DatabaseCollection.UpdateOne(filter, update);
        }
    }
}