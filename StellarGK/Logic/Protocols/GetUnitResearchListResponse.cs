using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetUnitResearchListResponse
    {
        [JsonProperty("idx")]
        public int id { get; set; }

        [JsonProperty("time")]
        public int remainTime { get; set; }
    }
}
