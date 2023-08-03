using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WorldMapInformationResponse
    {
        [JsonPropertyName("mid")]
        public string stageId { get; set; }

        [JsonPropertyName("cnt")]
        public int clearCount { get; set; }

        [JsonPropertyName("star")]
        public int star { get; set; }
    }
}
