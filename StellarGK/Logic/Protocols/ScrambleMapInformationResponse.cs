using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ScrambleMapInformationResponse
    {
        [JsonPropertyName("stage")]
        public string stageId { get; set; }

        [JsonPropertyName("stus")]
        public int status { get; set; }

        [JsonPropertyName("rmhp")]
        public string __hp { get; set; }
    }
}
