using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EventBattleGachaRewardDataRow : DataRow
    {
        public int eventIdx { get; private set; }

        public int count { get; private set; }

        public int idx { get; private set; }

        public int mainReward { get; private set; }

        public ERewardType rewardType { get; private set; }

        public string rewardIdx { get; private set; }

        public int rewardAmount { get; private set; }

        public int rewardCount { get; private set; }

        public int effect { get; private set; }

        public string GetKey()
        {
            return $"{eventIdx}_{count}_{idx}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}