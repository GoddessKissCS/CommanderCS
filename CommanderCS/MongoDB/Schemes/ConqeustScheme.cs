using CommanderCS.Library.Protocols;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace CommanderCS.MongoDB.Schemes
{
    public class ConqeustScheme
    {
        public ObjectId Id { get; set; }
        public int GuildId { get; set; }
        public int enemyGuildId { get; set; }
        public string notice { get; set; }
        public ConquestTroopInfoScheme conquestTroopInfo { get; set; }
        public ConquestInfo conquestInfo { get; set; }
        // Unix epoch seconds when the current conquest phase expires
        public long phaseEndTime { get; set; }
    }

    public class ConquestTroopInfoScheme
    {
        [JsonProperty("squard")]
        public Dictionary<string, Troop> squard { get; set; }

        [JsonProperty("slot")]
        public List<int> slot { get; set; }

        [JsonProperty("enemy")]
        public Enemy enemyGuild { get; set; }

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
            public int memberCount { get; set; }
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
