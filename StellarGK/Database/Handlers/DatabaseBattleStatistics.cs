using MongoDB.Driver;
using StellarGK.Database.Models;
using StellarGK.Logic.Protocols;

namespace StellarGK.Database.Handlers
{

    public class DatabaseBattleStatistics : DatabaseTable<BattleStatisticsScheme>
    {
        public DatabaseBattleStatistics() : base("BattleStatistics") { }

        public BattleStatisticsScheme? Create(int mIdx)
        {
            BattleStatisticsScheme? tryUser = collection.AsQueryable().Where(d => d.Id == mIdx).FirstOrDefault();
            if (tryUser != null) { return tryUser; }

            BattleStatisticsScheme user = new()
            {
                Id = mIdx,
                totalGold = 100000,
                pveWinCount = 0,
                pveLoseCount = 0,
                pvpLoseCount = 0,
                pvpWinCount = 0,
                armyCommanderDestroyCount = 0,
                armyUnitDestroyCount = 0,
                navyCommanderDestroyCount = 0,
                navyUnitDestroyCount = 0,
                totalPlunderGold = 0,
                winStreak = 0,
                winMostStreak = 0,
                preWinStreak = 0,
                arenaHighRank = 0,
                raidHighRank = 0,
                raidHighScore = 0,
                normalGachaCount = 0,
                premiumGachaCount = 0,
                stageClearCount = 0,
                sweepClearCount = 0,
                unitDestroyCount = 0,
                vipShop = 0,
                vipShopResetTime = 0,
                predeckCount = 0,
                firstPayment = false,
                weaponInventoryCount = 0,
                weaponMakeSlotCount = 0,
            };

            collection.InsertOne(user);

            return user;
        }


        public UserInformationResponse.BattleStatistics RequestBattleStatistics(int uid)
        {
            var battleInfo = FindByUid(uid);

            return SchemeIntoBattleStatistics(battleInfo);
        }
        public UserInformationResponse.BattleStatistics SchemeIntoBattleStatistics(BattleStatisticsScheme statistics)
        {
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
                firstPayment = Convert.ToInt32(statistics.firstPayment),
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


        public BattleStatisticsScheme? FindByName(string name)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.name == name).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }
        public BattleStatisticsScheme? FindByToken(string token)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.token == token).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }
        public BattleStatisticsScheme? FindByUid(int uid)
        {
            BattleStatisticsScheme? user = collection.AsQueryable().Where(d => d.Id == uid).FirstOrDefault();
            return user;
        }
        public BattleStatisticsScheme? FindBySession(string session)
        {
            AccountScheme? user = DatabaseAccount.collection.AsQueryable().Where(d => d.session == session).FirstOrDefault();
            var battleinfo = FindByUid(user.Id);

            return battleinfo;
        }


        public void AddGold(int id, int newGold)
        {
            BattleStatisticsScheme account = FindByUid(id);

            int gold = account.totalGold + newGold;

            var filter = Builders<BattleStatisticsScheme>.Filter.Eq("Id", id);

            var update = Builders<BattleStatisticsScheme>.Update.Set("totalGold", gold);

            collection.UpdateOne(filter, update);
        }
    }
}
