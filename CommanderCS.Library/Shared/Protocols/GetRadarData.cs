using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class GetRadarData
    {
        [JsonProperty("Radar")]
        public Radar radar { get; set; }

        public class Radar
        {
            [JsonProperty("remain")]
            public int remain { get; set; }

            [JsonProperty("ovtm")]
            public int overTime { get; set; }

            [JsonProperty("stm")]
            public int startTime { get; set; }

            [JsonProperty("unm")]
            public string uName { get; set; }

            [JsonProperty("info")]
            public Dictionary<int, User> info { get; set; }
        }

        public class User
        {
            [JsonProperty("alie")]
            public Info alie { get; set; }

            [JsonProperty("enemy")]
            public Info enemy { get; set; }
        }

        public class Info
        {
            [JsonProperty("move")]
            public int move { get; set; }

            [JsonProperty("stand")]
            public int stand { get; set; }
        }
    }
}