using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class CommanderScenario
    {
        [JsonPropertyName("qrtr")]
        public List<string> complete { get; set; }

        [JsonPropertyName("rcvd")]
        public int receive { get; set; }
    }
}
