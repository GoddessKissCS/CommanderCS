using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ConquestTroopInfo
    {
        [JsonPropertyName("squard")]
        public Dictionary<int, Troop> squard { get; set; }

        [JsonPropertyName("slot")]
        public List<int> slot { get; set; }

        [JsonPropertyName("enemy")]
        public Enemy eGuild { get; set; }


        public class Enemy
        {
            [JsonPropertyName("nm")]
            public string name { get; set; }

            [JsonPropertyName("world")]
            public int world { get; set; }

            [JsonPropertyName("emblem")]
            public int emblem { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("mcnt")]
            public int mcnt { get; set; }
        }


        public class Troop
        {
            [JsonPropertyName("point")]
            public int point { get; set; }

            [JsonPropertyName("status")]
            public string status { get; set; }

            [JsonPropertyName("remain")]
            public int remain { get; set; }

            [JsonPropertyName("mvtm")]
            public int mvtm { get; set; }

            [JsonPropertyName("path")]
            public List<int> path { get; set; }

            [JsonPropertyName("ucash")]
            public int ucash { get; set; }

            [JsonPropertyName("deck")]
            public Dictionary<string, string> deck { get; set; }
        }
    }
}
