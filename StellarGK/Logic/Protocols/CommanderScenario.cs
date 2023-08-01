using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CommanderScenario
    {
        [JsonProperty("qrtr")]
        public List<string> complete { get; set; }

        [JsonProperty("rcvd")]
        public int receive { get; set; }
    }
}
