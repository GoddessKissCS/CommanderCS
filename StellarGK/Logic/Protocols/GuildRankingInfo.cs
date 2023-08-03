using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GuildRankingInfo
    {
        [JsonPropertyName("idx")]
        public int idx { get; set; }

        [JsonPropertyName("world")]
        public int world { get; set; }

        [JsonPropertyName("rnk")]
        public int rank { get; set; }

        [JsonPropertyName("gnm")]
        public string guildName { get; set; }

        [JsonPropertyName("lev")]
        public int level { get; set; }

        [JsonPropertyName("apt")]
        public int point { get; set; }

        [JsonPropertyName("scr")]
        public int score { get; set; }

        [JsonPropertyName("emb")]
        public int emblem { get; set; }

        [JsonPropertyName("cnt")]
        public int count { get; set; }
    }
}
