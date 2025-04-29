using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GroupInfoDataRow : DataRow
    {
        public string tabidx { get; private set; }

        public string tabname { get; private set; }

        public string groupIdx { get; private set; }

        public string groupName { get; private set; }

        public string groupComment { get; private set; }

        public int typeIndex { get; private set; }

        public ERewardType rewardType { get; private set; }

        public int rewardIdx { get; private set; }

        public int minCount { get; private set; }

        private GroupInfoDataRow()
        {
        }

        public string GetKey()
        {
            return groupIdx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}