using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateBattlePointUserRankingInfo
    {
        [JsonPropertyName("rank")]
        public int rank { get; set; }

        [JsonPropertyName("uno")]
        public string uno { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("thumb")]
        public int thumb { get; set; }

        [JsonPropertyName("accDmg")]
        public ulong accDmg { get; set; }

        [JsonPropertyName("lv")]
        public int lv { get; set; }

        [JsonPropertyName("world")]
        public int world { get; set; }
    }
}
