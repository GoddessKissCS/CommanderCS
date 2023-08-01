using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GuildRankingInfo
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("world")]
        public int world { get; set; }

        [JsonProperty("rnk")]
        public int rank { get; set; }

        [JsonProperty("gnm")]
        public string guildName { get; set; }

        [JsonProperty("lev")]
        public int level { get; set; }

        [JsonProperty("apt")]
        public int point { get; set; }

        [JsonProperty("scr")]
        public int score { get; set; }

        [JsonProperty("emb")]
        public int emblem { get; set; }

        [JsonProperty("cnt")]
        public int count { get; set; }
    }
}
