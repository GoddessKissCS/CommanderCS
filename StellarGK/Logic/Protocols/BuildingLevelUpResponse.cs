using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BuildingLevelUpResponse
    {
        [JsonProperty("gold")]
        public string __gold { get; set; }

        [JsonProperty("cash")]
        public string __cash { get; set; }

        [JsonProperty("remain")]
        public int remainTime { get; set; }
    }
}
