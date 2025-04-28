using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class CommanderScenario
    {
        [JsonProperty("qrtr")]
        public List<string> complete { get; set; }

        [JsonProperty("rcvd")]
        public int receive { get; set; }
    }
}