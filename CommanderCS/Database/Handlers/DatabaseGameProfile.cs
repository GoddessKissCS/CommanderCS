﻿using MongoDB.Bson;
using MongoDB.Driver;
using CommanderCS.Database.Schemes;
using CommanderCS.Host.Handlers.Login;
using CommanderCS.ExcelReader;
using CommanderCS.Protocols;
using CommanderCS.Utils;
using CommanderCSLibrary.Utils;
using System.Linq.Expressions;

namespace CommanderCS.Database.Handlers
{
    public class DatabaseGameProfile : DatabaseTable<GameProfileScheme>
    {
        public DatabaseGameProfile() : base("GameProfile")
        {
        }

        public GameProfileScheme? GetOrCreate(int memberId, int server)
        {
            var tryUser = DatabaseCollection.AsQueryable()
                       .Where(d => d.Server == server && d.MemberId == memberId)
                       .FirstOrDefault();

            if (tryUser != null) { return tryUser; }

            int uno = DatabaseManager.AutoIncrements.GetNextNumber("UNO", 1000);

            var worldmapstagesreward = WorldMapStageData.GetInstance().AddDefaultWorldMapIsRewardCollected();
            var WorldMapStages = WorldMapStageData.GetInstance().AddAllStagesAtDefault();

            GameProfileScheme user = new()
            {
                Server = server,
                WorldMapData = new()
                {
                  StageReward = worldmapstagesreward,
                  Stages = WorldMapStages
                },
                BattleData = new()
                {
                    SweepClearData = []
                },
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
                CommanderData = [],
                CompleteRewardGroupIdx = [],
                DispatchedCommanders = null,
                GuildId = null,
                MemberId = memberId,
                Notifaction = false,
                PreDeck = [],
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
                    equipItem = [],
                    donHaveCommCostumeData = [],
                    eventResourceData = [],
                    groupItemData = [],
                    foodData = [],
                    itemData = [],
                    medalData = [],
                    partData = [],
                    weaponList = []
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
                Uno = uno,
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
                VipRechargeData =
                [
                    new()
                    {
                        count = 0,
                        idx = 601,
                        mid = 0,
                    }
                ],
                BlockedUsers = [],
                BoughtCashShopItems = [],
                Session = string.Empty,
                MailDataList = [],
                DailyBonusCheck = [],
            };

            DatabaseManager.Dormitory.Create(uno);

            DatabaseCollection.InsertOne(user);

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
            else
            {
                return GetOrCreate(memberId, server);
            }
        }

        public bool AccountExists(string nickname)
        {
            return DatabaseCollection.AsQueryable().Where(d => d.UserResources.nickname == nickname).Count() > 0;
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
            } else {
                user.UserResources.gold -= new_gold;
                user.UserStatistics.TotalGold -= new_gold;
                user.UserResources.cash -= new_cash;
            }

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.gold", user.UserResources.gold).Set("UserResources.cash", user.UserResources.cash).Set("UserStatistics.totalGold", user.UserStatistics.TotalGold);

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

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.gold", user.UserResources.gold).Set("UserStatistics.totalGold", user.UserStatistics.TotalGold);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateCash(string session, int cash, bool useAddition)
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

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.cash", user.UserResources.cash);

            DatabaseCollection.UpdateOne(filter, update);
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

            var filter = Builders<GameProfileScheme>.Filter.Eq("MemberId", @params.memberId) &
                         Builders<GameProfileScheme>.Filter.Eq("Server", @params.world);

            var update = Builders<GameProfileScheme>.Update.Set("Session", session).Set("UserDevice", userDevice).Set("LastLoginTime", CurrTimeStamp);

            DatabaseCollection.UpdateOne(filter, update);

            DatabaseManager.Account.UpdateLastServerLoggedIn(@params.world, @params.memberId);
        }

        public void UpdateCommanderData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }


        public void UpdateCommanderDataAndMedalData(string session, Dictionary<string, UserInformationResponse.Commander> commanderList, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList).Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateCommanderData(int id, Dictionary<string, UserInformationResponse.Commander> commanderList)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, id);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.CommanderData, commanderList);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(string session, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateMedalData(int id, Dictionary<string, int> medalsdata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.MemberId, id);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.medalData, medalsdata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateItemData(string session, Dictionary<string, int> goods)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq(x => x.Session, session);
            var update = Builders<GameProfileScheme>.Update.Set(x => x.UserInventory.itemData, goods);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public UserInformationResponse.TutorialData UpdateTutorialData(string session, UserInformationResponse.TutorialData tutorialData)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("TutorialData", tutorialData);

            DatabaseCollection.UpdateOne(filter, update);

            var rtutorialData = FindBySession(session).TutorialData;

            return rtutorialData;
        }

        public bool ChangeThumbnailId(string session, int idx)
        {
            int id = CommanderCostumeData.GetInstance().FromId(idx).ctid;

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.thumbnailId", id);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public void UpdateTutorialStep(string session, int tutorialStep)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("TutorialData.step", tutorialStep);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateNickName(string session, string accountName)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            var update = Builders<GameProfileScheme>.Update.Set("UserResources.nickname", accountName);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public bool AddBlockedUser(BlockUser toBeBlocked, string session)
        {
            var user = DatabaseManager.GameProfile.FindBySession(session);
            var filter = Builders<GameProfileScheme>.Filter.Eq("MemberId", user.MemberId);
            var update = Builders<GameProfileScheme>.Update.Push("BlockedUsers", toBeBlocked);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

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

            var deleteResult = DatabaseCollection.DeleteOne(filter);

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

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateNotifaction(string session, int onoff)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("session", session);
            var update = Builders<GameProfileScheme>.Update.Set("Notifaction", Convert.ToBoolean(onoff));

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public bool UpdateWorldMapReward(string session, int worldMapId)
        {
            var user = FindBySession(session);

            string worldMapid = worldMapId.ToString();

            user.WorldMapData.StageReward[worldMapid] = 1;

            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);
            var update = Builders<GameProfileScheme>.Update.Set("WorldMapData.StageReward", user.WorldMapData.StageReward);

            var updateResult = DatabaseCollection.UpdateOne(filter, update);

            return updateResult.ModifiedCount > 0;
        }

        public void UpdateVipRechargeData(string session, List<UserInformationResponse.VipRechargeData> vipRechargedata)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);
            var update = Builders<GameProfileScheme>.Update.Set("VipRechargeData", vipRechargedata);

            DatabaseCollection.UpdateOne(filter, update);
        }

        public void UpdateVipRechargeCount(string session, int idx, int newCount)
        {
            var filter = Builders<GameProfileScheme>.Filter.And(
                Builders<GameProfileScheme>.Filter.Eq("Session", session),
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
                Builders<GameProfileScheme>.Filter.Eq("Session", session),
                Builders<GameProfileScheme>.Filter.Eq("VipRechargeData.idx", idx)
            );

            var projection = Builders<GameProfileScheme>.Projection.Expression(x => x.VipRechargeData[-1].count);

            var result = DatabaseCollection.Find(filter).Project(projection).FirstOrDefault();

            return result;
        }

        public void UpdateProfile(string session, GameProfileScheme user)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Session", session);

            DatabaseCollection.ReplaceOne(filter, user);
        }

        public void UpdateGuildId(int uno, int guildId)
        {
            var filter = Builders<GameProfileScheme>.Filter.Eq("Uno", uno);
            var update = Builders<GameProfileScheme>.Update.Set("GuildId", guildId);

            DatabaseCollection.UpdateOne(filter, update);
        }

    }
}