using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class MissionInfo
    {
        [JsonPropertyName("dlms")]
        public List<MissionData> missionList { get; set; }

        [JsonPropertyName("dmg")]
        public int goal { get; set; }

        [JsonPropertyName("dmcc")]
        public int completeCount { get; set; }


        public class MissionData
        {
            [JsonPropertyName("dmid")]
            public int missionId { get; set; }

            [JsonPropertyName("dmpt")]
            public int point { get; set; }

            [JsonPropertyName("fin")]
            public int complete { get; set; }

            [JsonPropertyName("rcvd")]
            public int receive { get; set; }
        }
    }
}
