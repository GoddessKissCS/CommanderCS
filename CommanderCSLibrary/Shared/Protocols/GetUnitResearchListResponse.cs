using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class GetUnitResearchListResponse
    {
        [JsonProperty("idx")]
        public int id { get; set; }

        [JsonProperty("time")]
        public int remainTime { get; set; }
    }
}