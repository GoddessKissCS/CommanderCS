using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    public class VipBenefitsDataRow : DataRow
    {
        public int vipLevel { get; private set; }
        public int dailyBulletRefill { get; private set; }
        public int dailyGoldExchange { get; private set; }
        public int dailyMissionReset { get; private set; }
        public int dailyArenaTicketRefill { get; private set; }
        public int dailyRaidTicketRefill { get; private set; }
        public int dailyCancelLossRecord { get; private set; }
        public int specialGiftRefill { get; private set; }
        public bool allDeatchMatchStagesRewardTickets { get; private set; }
        public bool reducedPremiumTreasureTime { get; private set; }
        public bool reducedNormalTreastureTime { get; private set; }
        public bool oddNumberedStagesInDeathMatchDropMidGradeTickets { get; private set; }
        public bool evenNumberedStagesInDeathMatchDropHighGradeTickets { get; private set; }
        public bool dispatchedFederationPilotsDoubleGoldIncome { get; private set; }
        public bool higherMinimuGoldExchangeRate { get; private set; }
        public bool floatingShipCanBeAnchored { get; private set; }
        public bool freeDailyExtraBattleTickets { get; private set; }
        public bool extraDailyShootoutGoldEntry { get; private set; }
        public bool canScoutSpecialPilotFromCruiseHall { get; private set; }
        public bool freeSpecialShopRefresh { get; private set; }
        public bool freeDailyConvertibleMedals { get; private set; }
        public string comment { get; private set; }

        private VipBenefitsDataRow()
        {
        }

        public string GetKey()
        {
            return vipLevel.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}