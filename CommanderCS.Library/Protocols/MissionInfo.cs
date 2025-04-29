using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class MissionInfo
    {
        [JsonProperty("dlms")]
        public List<MissionData> missionList { get; set; }

        [JsonProperty("dmg")]
        public int goal { get; set; }

        [JsonProperty("dmcc")]
        public int completeCount { get; set; }

        public class MissionData
        {
            [JsonProperty("dmid")]
            public int missionId { get; set; }

            [JsonProperty("dmpt")]
            public int point { get; set; }

            [JsonProperty("fin")]
            public int complete { get; set; }

            [JsonProperty("rcvd")]
            public int receive { get; set; }
        }
    }
}