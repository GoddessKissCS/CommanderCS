namespace StellarGK.Database.Models
{
    public class BattleStatisticsScheme
    {
        public int Id { get; set; }
        public int totalGold { get; set; }
        public int pveWinCount { get; set; }
        public int pveLoseCount { get; set; }
        public int pvpWinCount { get; set; }
        public int pvpLoseCount { get; set; }
        public int armyCommanderDestroyCount { get; set; }
        public int armyUnitDestroyCount { get; set; }
        public int navyCommanderDestroyCount { get; set; }
        public int navyUnitDestroyCount { get; set; }
        public int totalPlunderGold { get; set; }
        public int winStreak { get; set; }
        public int winMostStreak { get; set; }
        public int preWinStreak { get; set; }
        public int arenaHighRank { get; set; }
        public int raidHighRank { get; set; }
        public int raidHighScore { get; set; }
        public int normalGachaCount { get; set; }
        public int premiumGachaCount { get; set; }
        public int stageClearCount { get; set; }
        public int sweepClearCount { get; set; }
        public int unitDestroyCount { get; set; }
        public int commanderDestroyCount { get; set; }
        public int vipShop { get; set; }
        public int vipShopResetTime { get; set; }
        public int predeckCount { get; set; }
        public bool firstPayment { get; set; }
        public int weaponMakeSlotCount { get; set; }
        public int weaponInventoryCount { get; set; }

    }
}
