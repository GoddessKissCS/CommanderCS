using CommanderCS.Host;
using CommanderCS.Host.Handlers.Login;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Protocols;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json.Linq;
using static CommanderCSLibrary.Shared.Protocols.ConquestStageUser;

namespace CommanderCS.MongoDB.Handlers
{
    /// <summary>
    /// Represents a database table for game profiles.
    /// </summary>
    public class DatabaseGameProfile : DatabaseTable<GameProfileScheme>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseGameProfile"/> class.
        /// </summary>
        public DatabaseGameProfile() : base("GameProfile")
        {
        }

        /// <summary>
        /// Gets or creates a game profile for the specified member ID and server.
        /// </summary>
        /// <param name="memberId">The member ID associated with the game profile.</param>
        /// <param name="server">The server ID associated with the game profile.</param>
        /// <returns>The existing or newly created game profile.</returns>
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

            var WorldMapStages = RemoteObjectManager.instance.regulation.GetAllWorldMapStages();

            var currTime = TimeManager.CurrentEpoch;

            GameProfileScheme user = new()
            {
                Server = server,
                LastStage = 0,
                UserStatistics = new()
                {
                    WeaponMakeSlotCount = 2,
                    WeaponInventoryCount = 200
                },
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
                    itemData = new()
                    {
                        { "10", 5 } // BOSS Tickets
                    },
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
                VipRechargeData = [
                    new() { count = 0, idx = 601, mid = 0 },
                    new() { count = 5, idx = 106, mid = 0 }
                    ],
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
                    {
                        score = 1000
                    },
                    RaidRankingData = new()
                    {
                    },
                },
                WeaponInformation = new()
                {
                    WeaponProgressList = []
                },
                DailyBuyables = new()
                {
                    RaidKeys = 20,
                },
                ShopData = new()
                {
                    BuyVipShop = new()
                    {
                    },
                    ChallengeShop = new()
                    {
                    },
                    DailyShop = new()
                    {
                    },
                    RaidShop = new()
                    {
                    },
                    WaveDuelShop = new()
                    {
                    },
                },
                GachaInformation = new()
                {
                    { "1",
                        new()
                        {
                            freeOpenRemainCount = 0,
                            freeOpenRemainTime = 0,
                            pilotRate = 1,
                            type = "1",
                        }
                    },
                    {
                        "2", new()
                        {
                            freeOpenRemainCount = 1,
                            freeOpenRemainTime = 0,
                            pilotRate = 0,
                            type = "2",
                        }
                    }
                }
            };

            DatabaseCollection.InsertOne(user);

            DatabaseManager.Dormitory.Create(uno);

            return user;
        }

        /// <summary>
        /// Retrieves the game profile associated with the specified member ID and server, creating it if it does not exist.
        /// </summary>
        /// <param name="memberId">The member ID associated with the game profile.</param>
        /// <param name="server">The server ID associated with the game profile.</param>
        /// <returns>The game profile associated with the member ID and server.</returns>
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

        /// <summary>
        /// Checks if an account with the specified nickname exists.
        /// </summary>
        /// <param name="nickname">The nickname of the account to check.</param>
        /// <returns>True if an account with the specified nickname exists, otherwise false.</returns>
        public bool AccountExists(string nickname)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.UserResources.nickname == nickname).Any();
        }

        /// <summary>
        /// Checks if a session token exists in the database.
        /// </summary>
        /// <param name="session">The session token to check.</param>
        /// <returns>True if the session token exists, otherwise false.</returns>
        public bool SessionTokenExists(string session)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Session == session).Any();
        }

        /// <summary>
        /// Finds a game profile associated with the specified session token.
        /// </summary>
        /// <param name="session">The session token associated with the game profile.</param>
        /// <returns>The game profile associated with the session token, or null if not found.</returns>
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

        /// <summary>
        /// Finds a game profile associated with the specified UNO.
        /// </summary>
        /// <param name="uno">The UNO associated with the game profile.</param>
        /// <returns>The game profile associated with the UNO, or null if not found.</returns>
        public GameProfileScheme FindByUno(int uno)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.Uno == uno).FirstOrDefault();
        }

        /// <summary>
        /// Finds a game profile associated with the specified nickname.
        /// </summary>
        /// <param name="nickname">The nickname associated with the game profile.</param>
        /// <returns>The game profile associated with the nickname, or null if not found.</returns>
        public GameProfileScheme FindByNick(string nickname)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.UserResources.nickname == nickname).FirstOrDefault();
        }

        /// <summary>
        /// Finds game profiles associated with the specified member ID.
        /// </summary>
        /// <param name="memberId">The member ID associated with the game profiles.</param>
        /// <returns>A list of game profiles associated with the member ID.</returns>
        public List<GameProfileScheme> FindByMemberIdList(string memberId)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.MemberId == int.Parse(memberId)).ToList();
        }

        /// <summary>
        /// Retrieves the count of game profile schemes.
        /// </summary>
        /// <returns>The count of game profile schemes as a string.</returns>
        public string GetGameProfileSchemeCount()
        {
            var filter = Builders<GameProfileScheme>.Filter.Empty;

            long count = DatabaseCollection.CountDocuments(filter);

            return count.ToString();
        }

        /// <summary>
        /// Retrieves battle statistics from the game profile associated with the specified session.
        /// </summary>
        /// <param name="session">The session associated with the game profile.</param>
        /// <returns>Battle statistics from the game profile.</returns>
        public UserInformationResponse.BattleStatistics UserStatisticsFromSession(string session)
        {
            var user = FindBySession(session);

            var statistics = user.UserStatistics;

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

        /// <summary>
        /// Converts user battle statistics to battle statistics for response.
        /// </summary>
        /// <param name="statistics">The user battle statistics to convert.</param>
        /// <returns>Battle statistics suitable for response.</returns>
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

        /// <summary>
        /// Retrieves user resources from the game profile associated with the specified session.
        /// </summary>
        /// <param name="session">The session associated with the game profile.</param>
        /// <returns>User resources from the game profile.</returns>
        public UserInformationResponse.Resource? UserResourcesFromSession(string session)
        {
            var user = FindBySession(session);

            var resources = user.UserResources;

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

        /// <summary>
        /// Converts user resources to the response format.
        /// </summary>
        /// <param name="resources">User resources to convert.</param>
        /// <returns>User resources in the response format.</returns>
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

        /// <summary>
        /// Updates the user resources associated with the given session.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="resources">The updated user resources.</param>
        public void UpdateUserResources(string session, UserResources resources)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources, resources);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the gold and cash of the user associated with the given session.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="new_gold">The new amount of gold.</param>
        /// <param name="new_cash">The new amount of cash.</param>
        /// <param name="useAddition">A boolean indicating whether to add or subtract the specified amounts.</param>
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

        /// <summary>
        /// Updates the gold of the user associated with the given session.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="gold">The amount of gold to update.</param>
        /// <param name="useAddition">A boolean indicating whether to add or subtract the specified amount.</param>
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

        /// <summary>
        /// Updates the cash of the user associated with the given session.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="cash">The amount of cash to update.</param>
        /// <param name="useAddition">A boolean indicating whether to add or subtract the specified amount.</param>
        /// <returns>The updated game profile scheme of the user.</returns>
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

        /// <summary>
        /// Updates the user's information upon login.
        /// </summary>
        /// <param name="params">The login request parameters.</param>
        /// <param name="session">The session associated with the user.</param>
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
        }

        /// <summary>
        /// Updates the user data in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="user">The updated user profile.</param>
        public void UpdateUserData(string session, GameProfileScheme user)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);

            DatabaseCollection.ReplaceOne(filter, user);
        }

        /// <summary>
        /// Updates the commander data for a user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="commanderList">The updated commander data to be stored.</param>
        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the commander data for a user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="commander">The updated commander to be stored.</param>
        public void UpdateSpecificCommander(string session, UserInformationResponse.Commander commander)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session),
                Builders<GameProfileScheme>.Filter.Eq("CommanderData.Key", commander.id)
            );

            var update = Builders<GameProfileScheme>.Update.Set("CommanderData.$", commander);

            DatabaseCollection.UpdateOne(filter, update);
        }


        /// <summary>
        /// Updates the food data for a user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="foodData">The updated food data to be stored.</param>
        public void UpdateFoodData(string session, Dictionary<string, int> foodData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.foodData, foodData);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the list of commander costumes that the user does not have in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="donthaveCostumes">The updated dictionary containing the commander costume data.</param>
        public void UpdateDontHaveCommanderCostumeData(string session, Dictionary<string, List<int>> donthaveCostumes)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.donHaveCommCostumeData, donthaveCostumes);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the commander data and medal data associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="commanderList">The updated dictionary containing the commander data.</param>
        /// <param name="medalsdata">The updated dictionary containing the medal data.</param>
        public void UpdateCommanderDataAndMedalData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList).Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the medal data associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="medalsdata">The updated dictionary containing the medal data.</param>
        public void UpdateMedalData(string session, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the item data associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="items">The updated dictionary containing the item data.</param>
        public void UpdateItemData(string session, Dictionary<string, int> items)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.itemData, items);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the part data associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="parts">The updated dictionary containing the part data.</param>
        public void UpdatePartData(string session, Dictionary<string, int> parts)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.partData, parts);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the tutorial data associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="tutorialData">The updated tutorial data.</param>
        public void UpdateTutorialData(string session, UserInformationResponse.TutorialData tutorialData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.TutorialData, tutorialData);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Changes the thumbnail ID associated with the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="costumeId">The new thumbnail ID to set for the user.</param>
        /// <returns>True if the thumbnail ID was successfully changed; otherwise, false.</returns>
        public bool ChangeThumbnailId(string session, int costumeId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.thumbnailId, costumeId);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Updates the tutorial step for the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="tutorialStep">The new tutorial step to set for the user.</param>
        public void UpdateTutorialStep(string session, int tutorialStep)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.TutorialData.step, tutorialStep);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the nickname of the user in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="accountName">The new nickname to set for the user.</param>
        public void UpdateNickName(string session, string accountName)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.nickname, accountName);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Adds a blocked user to the user's profile.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="blockUser">The user to be blocked.</param>
        /// <returns>True if the user was successfully added to the blocked list, false otherwise.</returns>
        public bool AddBlockedUser(string session, BlockUser blockUser)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Push(x => x.BlockedUsers, blockUser);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Removes a blocked user from the user's profile.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="channel">The channel of the blocked user.</param>
        /// <param name="uno">The unique identifier of the blocked user.</param>
        /// <returns>True if the user was successfully removed from the blocked list, false otherwise.</returns>
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

        /// <summary>
        /// Marks a specific mail as read for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="MailIdx">The index of the mail to be marked as read.</param>
        /// <returns>True if the mail was successfully marked as read, false otherwise.</returns>
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

        /// <summary>
        /// Updates the notification setting for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="onoff">The new notification setting (1 for on, 0 for off).</param>
        /// <returns>True if the notification setting was successfully updated, false otherwise.</returns>
        public bool UpdateNotifaction(string session, int onoff)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.Notifaction, Convert.ToBoolean(onoff));

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Updates the reward status for a specific world map stage for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="worldMapId">The ID of the world map.</param>
        /// <param name="StageReward">The dictionary containing the reward status for each world map stage.</param>
        /// <returns>True if the reward status was successfully updated, false otherwise.</returns>
        public bool UpdateWorldMapReward(string session, int worldMapId, Dictionary<string, int> StageReward)
        {
            string worldMapid = worldMapId.ToString();

            StageReward[worldMapid] = 1;

            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.BattleData.WorldMapStageReward, StageReward);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Updates the VIP recharge data for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="vipRechargedata">The list containing the VIP recharge data.</param>
        public void UpdateVipRechargeData(string session, List<UserInformationResponse.VipRechargeData> vipRechargedata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.VipRechargeData, vipRechargedata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the count of a specific VIP recharge data entry for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="idx">The index of the VIP recharge data entry.</param>
        /// <param name="newCount">The new count to set for the specified entry.</param>
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

        /// <summary>
        /// Retrieves the count of a specific VIP recharge data entry for the user.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="idx">The index of the VIP recharge data entry.</param>
        /// <returns>The count of the specified VIP recharge data entry.</returns>
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

        /// <summary>
        /// Updates the user profile in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="user">The updated user profile.</param>
        public void UpdateProfile(string session, GameProfileScheme user)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);

            DatabaseCollection.ReplaceOne(filter, user);
        }

        /// <summary>
        /// Updates the guild ID associated with a user.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildId">The new guild ID to be associated with the user.</param>
        public void UpdateGuild(int uno, object? guildId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Uno, uno);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.GuildId, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the guild ID associated with a user.
        /// </summary>
        /// <param name="uno">The unique identifier of the user.</param>
        /// <param name="guildId">The new guild ID to be associated with the user.</param>
        public void UpdateGuildId(int uno, int guildId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Uno, uno);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.GuildId, guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the pre-deck information for a user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="preDecks">The new list of pre-deck configurations.</param>
        public void UpdatePreDeck(string session, List<UserInformationResponse.PreDeck> preDecks)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.PreDeck, preDecks);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Adds an empty pre-deck slot to the user's profile.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="preDeckCount">The total number of pre-deck slots.</param>
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

        /// <summary>
        /// Requests to set a nickname for the user after completing the tutorial.
        /// </summary>
        /// <param name="sess">The session ID of the user.</param>
        /// <param name="nickname">The desired nickname to set.</param>
        /// <returns>The error code indicating the result of the request.</returns>
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

            UpdateNickName(sess, nickname);

            return ErrorCode.Success;
        }

        /// <summary>
        /// Requests to change the nickname for the user.
        /// </summary>
        /// <param name="AccountName">The new nickname to set.</param>
        /// <param name="sess">The session ID of the user.</param>
        /// <returns>The error code indicating the result of the request.</returns>
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

        /// <summary>
        /// Updates the dispatched commanders for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="dispatchedCommanderList">The dictionary containing dispatched commander information.</param>
        public void UpdateDispatchedCommander(string session, Dictionary<string, DispatchedCommanderInfo> dispatchedCommanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DispatchedCommanders, dispatchedCommanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the number of rings for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="ring">The new number of rings for the user.</param>
        public void UpdateRings(string session, int ring)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.ring, ring);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the weapon inventory count for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="weaponInventoryCount">The new weapon inventory count for the user.</param>
        public void UpdateWeaponInventoryCount(string session, int weaponInventoryCount)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserStatistics.WeaponInventoryCount, weaponInventoryCount);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the PvP defender deck for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="deck">The new PvP defender deck configuration.</param>
        public bool UpdatePvPDefenderDeck(string session, Dictionary<string, string> deck)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DefenderDeck.PvPDefenderDeck, deck);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        /// <summary>
        /// Updates the wave defender decks for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="decks">The new wave defender deck configurations.</param>
        public void UpdateWaveDefenderDecks(string session, Dictionary<string, Dictionary<string, string>> decks)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DefenderDeck.WaveDuelDefenderDecks, decks);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the world defender decks for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="decks">The new world defender deck configurations.</param>
        public void UpdateWorldDefenderDeck(string session, Dictionary<string, string> decks)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DefenderDeck.WorldDuelDefenderDeck, decks);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the number of daily buyable raid keys for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="Keys">The new number of daily buyable raid keys.</param>
        public void UpdateDailyBuyableRaidKeys(string session, int Keys)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DailyBuyables.RaidKeys, Keys);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the infinity battle deck configuration for the user.
        /// </summary>
        /// <param name="session">The session ID of the user.</param>
        /// <param name="deck">The new infinity battle deck configuration.</param>
        public void UpdateInfinityBattleDeck(string session, JObject deck)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.DefenderDeck.InfinityBattleDeck, deck);

            DatabaseCollection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Updates the user data in the database.
        /// </summary>
        /// <param name="session">The session associated with the user.</param>
        /// <param name="user">The updated user profile.</param>
        public void UpdateCommanderMarriage(string session, GameProfileScheme user, UserInformationResponse.Commander commander)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
            Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session),
            Builders<GameProfileScheme>.Filter.Eq("CommanderData.Key", commander.id)
            );

            var update = Builders<GameProfileScheme>.Update.Set("CommanderData.$", commander);

            DatabaseCollection.UpdateOne(filter, update);


            var filter2 = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update2 = Builders<GameProfileScheme>.Update.Set(x => x.UserResources.ring, user.UserResources.ring);

            DatabaseCollection.UpdateOne(filter2, update2);
        }

    }
}