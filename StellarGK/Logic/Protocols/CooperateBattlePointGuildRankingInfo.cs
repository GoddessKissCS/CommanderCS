using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateBattlePointGuildRankingInfo
    {
        [JsonPropertyName("rank")]
        public int rank { get; set; }

        [JsonPropertyName("gIdx")]
        public int gIdx { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("lv")]
        public int lv { get; set; }

        [JsonPropertyName("eblm")]
        public int eblm { get; set; }

        [JsonPropertyName("server")]
        public int server { get; set; }

        [JsonPropertyName("stage")]
        public int stage { get; set; }

        [JsonPropertyName("step")]
        public int step { get; set; }

        [JsonPropertyName("accDmg")]
        public ulong accDmg { get; set; }
    }
}
