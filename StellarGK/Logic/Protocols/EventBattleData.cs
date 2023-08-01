using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class EventBattleData
    {
        [JsonProperty("evt")]
        public EventData eventData { get; set; }

        [JsonProperty("boss")]
        public RaidData raidData { get; set; }

        [JsonProperty("bossCnt")]
        public int bossCnt { get; set; }

        [JsonProperty("rcnt")]
        public int rewardCnt { get; set; }

        [JsonProperty("rcntAll")]
        public int rewardCntAll { get; set; }

        [JsonProperty("map")]
        public Dictionary<int, int> clearList { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class EventData
        {
            [JsonProperty("efid")]
            public string efid { get; set; }

            [JsonProperty("esid")]
            public string esid { get; set; }

            [JsonProperty("remain")]
            public double remain { get; set; }

            [JsonProperty("type")]
            public int type { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class RaidData
        {
            [JsonProperty("remain")]
            public double remain { get; set; }
        }
    }
}
