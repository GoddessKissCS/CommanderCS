using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class GachaInformationResponse
    {
        [JsonProperty("gbIdx")]
        public string type { get; set; }

        [JsonProperty("cnt")]
        public int freeOpenRemainCount { get; set; }

        [JsonProperty("remain")]
        public int freeOpenRemainTime { get; set; }

        [JsonProperty("acc")]
        public int pilotRate { get; set; }
    }
}