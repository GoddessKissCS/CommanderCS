using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class RewardDataRow : DataRow
    {
        public ERewardCategory category { get; private set; }

        public int type { get; private set; }

        public int typeIndex { get; private set; }

        public ERewardType rewardType { get; private set; }

        public int rewardIdx { get; private set; }

        public int minCount { get; private set; }

        public int maxCount { get; private set; }

        public int rate { get; private set; }

        public void AddCount(int maxCount, int minCount)
        {
            this.maxCount += maxCount;
            this.minCount += minCount;
        }

        public void Clone(RewardDataRow row)
        {
            rewardType = row.rewardType;
            rewardIdx = row.rewardIdx;
            maxCount = row.maxCount;
            minCount = row.minCount;
        }

        public string GetKey()
        {
            return category.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}