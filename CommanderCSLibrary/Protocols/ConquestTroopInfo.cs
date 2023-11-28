using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class ConquestTroopInfo
    {
        [JsonProperty("squard")]
        public Dictionary<int, Troop> squard { get; set; }

        [JsonProperty("slot")]
        public List<int> slot { get; set; }

        [JsonProperty("enemy")]
        public Enemy eGuild { get; set; }

        public class Enemy
        {
            [JsonProperty("nm")]
            public string name { get; set; }

            [JsonProperty("world")]
            public int world { get; set; }

            [JsonProperty("emblem")]
            public int emblem { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("mcnt")]
            public int mcnt { get; set; }
        }

        public class Troop
        {
            [JsonProperty("point")]
            public int point { get; set; }

            [JsonProperty("status")]
            public string status { get; set; }

            [JsonProperty("remain")]
            public int remain { get; set; }

            [JsonProperty("mvtm")]
            public int mvtm { get; set; }

            [JsonProperty("path")]
            public List<int> path { get; set; }

            [JsonProperty("ucash")]
            public int ucash { get; set; }

            [JsonProperty("deck")]
            public Dictionary<string, string> deck { get; set; }
        }
    }
}