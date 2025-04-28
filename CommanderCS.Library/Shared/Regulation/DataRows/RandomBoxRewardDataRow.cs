using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class RandomBoxRewardDataRow : DataRow
    {
        public string idx { get; private set; }

        public ERewardType rewardType { get; private set; }

        public string rewardIdx { get; private set; }

        public int rewardAmountMin { get; private set; }

        public int rewardAmountMax { get; private set; }

        public int giveType { get; private set; }

        private RandomBoxRewardDataRow()
        {
        }

        public string GetKey()
        {
            return $"{idx}_{rewardType}_{rewardIdx}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}