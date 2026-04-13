using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CommanderScenarioRewardDataRow : DataRow
    {
        public int csid { get; private set; }

        public string cid { get; private set; }

        public int rewardIdx { get; private set; }

        public int rewardCount { get; private set; }

        public ERewardType rewardType { get; private set; }

        public string GetKey()
        {
            return csid.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
