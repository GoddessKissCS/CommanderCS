using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class RankingRewardDataRow : DataRow
    {
        public int r_idx { get; private set; }

        public ERankingContentsType type { get; private set; }

        public string g_idx { get; private set; }

        public int rewardAmount { get; private set; }

        public ERankingType rankingMinType { get; private set; }

        public int rankingMin { get; private set; }

        public ERankingType rankingMaxType { get; private set; }

        public int rankingMax { get; private set; }

        public string icon { get; private set; }

        public string name { get; private set; }

        public string GetKey()
        {
            return r_idx.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}