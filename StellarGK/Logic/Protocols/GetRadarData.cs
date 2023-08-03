using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{


    public class GetRadarData
    {
        [JsonPropertyName("Radar")]
        public Radar radar { get; set; }


        public class Radar
        {
            [JsonPropertyName("remain")]
            public int remain { get; set; }

            [JsonPropertyName("ovtm")]
            public int overTime { get; set; }

            [JsonPropertyName("stm")]
            public int startTime { get; set; }

            [JsonPropertyName("unm")]
            public string uName { get; set; }

            [JsonPropertyName("info")]
            public Dictionary<int, User> info { get; set; }
        }


        public class User
        {
            [JsonPropertyName("alie")]
            public Info alie { get; set; }

            [JsonPropertyName("enemy")]
            public Info enemy { get; set; }
        }


        public class Info
        {
            [JsonPropertyName("move")]
            public int move { get; set; }

            [JsonPropertyName("stand")]
            public int stand { get; set; }
        }
    }
}
