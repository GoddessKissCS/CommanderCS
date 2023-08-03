using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GachaInformationResponse
    {
        [JsonPropertyName("gbIdx")]
        public string type { get; set; }

        [JsonPropertyName("cnt")]
        public int freeOpenRemainCount { get; set; }

        [JsonPropertyName("remain")]
        public int freeOpenRemainTime { get; set; }

        [JsonPropertyName("acc")]
        public int pilotRate { get; set; }
    }
}
