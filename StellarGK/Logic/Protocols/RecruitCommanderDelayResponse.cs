using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RecruitCommanderDelayResponse
    {
        [JsonProperty("wait")]
        public int wait { get; set; }

        [JsonProperty("gold")]
        public string __gold { get; set; }

        [JsonProperty("cash")]
        public string __cash { get; set; }

        [JsonProperty("comm")]
        public SimpleCommanderInfo commander { get; set; }
    }
}
