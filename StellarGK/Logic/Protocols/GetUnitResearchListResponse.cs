using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GetUnitResearchListResponse
    {
        [JsonPropertyName("idx")]
        public int id { get; set; }

        [JsonPropertyName("time")]
        public int remainTime { get; set; }
    }
}
