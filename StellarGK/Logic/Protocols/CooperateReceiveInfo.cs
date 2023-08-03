using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CooperateReceiveInfo
    {
        [JsonPropertyName("stage")]
        public int stage { get; set; }

        [JsonPropertyName("step")]
        public int step { get; set; }
    }
}
