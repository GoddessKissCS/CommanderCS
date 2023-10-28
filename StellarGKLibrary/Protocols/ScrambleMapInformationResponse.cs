using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class ScrambleMapInformationResponse
    {
        [JsonProperty("stage")]
        public string stageId { get; set; }

        [JsonProperty("stus")]
        public int status { get; set; }

        [JsonProperty("rmhp")]
        public string __hp { get; set; }
    }
}