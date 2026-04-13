using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DailyBonusRewardDataRow : DataRow
    {
        public int index { get; private set; }

        public int version { get; private set; }

        public ERewardType rewardType { get; private set; }

        public int day { get; private set; }

        public int goodsId { get; private set; }

        public int goodsCount { get; private set; }

        public int vipLevel { get; private set; }

        public int multiply { get; private set; }

        public int startTime { get; private set; }

        public int endTime { get; private set; }

        private DailyBonusRewardDataRow()
        {
        }

        public string GetKey()
        {
            return index.ToString();
        }
    }
}