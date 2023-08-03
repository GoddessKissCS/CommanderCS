using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GetTroopInformationResponse
    {
        [JsonPropertyName("cid")]
        public string commanderId { get; set; }

        [JsonPropertyName("dnm")]
        public string nickname { get; set; }

        [JsonPropertyName("deck")]
        public Dictionary<string, Slot> slots { get; set; }


        public class Slot
        {
            [JsonPropertyName("uid")]
            public string unitId { get; set; }
        }
    }
}
