using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventBattleData
    {
        [JsonPropertyName("evt")]
        public EventData eventData { get; set; }

        [JsonPropertyName("boss")]
        public RaidData raidData { get; set; }

        [JsonPropertyName("bossCnt")]
        public int bossCnt { get; set; }

        [JsonPropertyName("rcnt")]
        public int rewardCnt { get; set; }

        [JsonPropertyName("rcntAll")]
        public int rewardCntAll { get; set; }

        [JsonPropertyName("map")]
        public Dictionary<int, int> clearList { get; set; }


        public class EventData
        {
            [JsonPropertyName("efid")]
            public string efid { get; set; }

            [JsonPropertyName("esid")]
            public string esid { get; set; }

            [JsonPropertyName("remain")]
            public double remain { get; set; }

            [JsonPropertyName("type")]
            public int type { get; set; }
        }


        public class RaidData
        {
            [JsonPropertyName("remain")]
            public double remain { get; set; }
        }
    }
}
