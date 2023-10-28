using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class CooperateBattlePointGuildRankingInfo
    {
        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("gIdx")]
        public int gIdx { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("lv")]
        public int lv { get; set; }

        [JsonProperty("eblm")]
        public int eblm { get; set; }

        [JsonProperty("server")]
        public int server { get; set; }

        [JsonProperty("stage")]
        public int stage { get; set; }

        [JsonProperty("step")]
        public int step { get; set; }

        [JsonProperty("accDmg")]
        public ulong accDmg { get; set; }
    }
}