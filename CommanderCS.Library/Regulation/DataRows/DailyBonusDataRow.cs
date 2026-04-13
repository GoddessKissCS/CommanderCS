using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DailyBonusDataRow : DataRow
    {
        public int index { get; private set; }

        public string version { get; private set; }

        public ERewardType rewardType { get; private set; }

        public int day { get; private set; }

        public string goodsId { get; private set; }

        public int goodsCount { get; private set; }

        public int vipLevel { get; private set; }

        public int multiply { get; private set; }

        public string startTimeString { get; private set; }

        [JsonIgnore]
        public DateTime startTime
        {
            get
            {
                return new();
            }
        }

        public string endTimeString { get; private set; }

        [JsonIgnore]
        public DateTime endTime
        {
            get
            {
                return new();
            }
        }

        private DailyBonusDataRow()
        {
        }

        public string GetKey()
        {
            return index.ToString();
        }
    }
}