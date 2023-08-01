using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTroopInformationResponse
    {
        [JsonProperty("cid")]
        public string commanderId { get; set; }

        [JsonProperty("dnm")]
        public string nickname { get; set; }

        [JsonProperty("deck")]
        public Dictionary<string, Slot> slots { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class Slot
        {
            [JsonProperty("uid")]
            public string unitId { get; set; }
        }
    }
}
