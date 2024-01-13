using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class GetTroopInformationResponse
    {
        [JsonProperty("cid")]
        public string commanderId { get; set; }

        [JsonProperty("dnm")]
        public string nickname { get; set; }

        [JsonProperty("deck")]
        public Dictionary<string, Slot> slots { get; set; }

        public class Slot
        {
            [JsonProperty("uid")]
            public string unitId { get; set; }
        }
    }
}