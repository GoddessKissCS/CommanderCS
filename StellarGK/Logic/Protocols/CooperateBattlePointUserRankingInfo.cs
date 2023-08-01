using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CooperateBattlePointUserRankingInfo
    {
        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("uno")]
        public string uno { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("thumb")]
        public int thumb { get; set; }

        [JsonProperty("accDmg")]
        public ulong accDmg { get; set; }

        [JsonProperty("lv")]
        public int lv { get; set; }

        [JsonProperty("world")]
        public int world { get; set; }
    }
}
