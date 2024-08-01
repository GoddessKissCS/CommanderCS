using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCSLibrary.Packets
{
    public class WorldMapStageStartResponse
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }
    }
    public class WorldMapStageStartRequest
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("deck")]
        public JObject Deck { get; set; }

        [JsonProperty("gdp")]
        public JObject Gdp { get; set; }

        [JsonProperty("ucash")]
        public int Ucash { get; set; }

        [JsonProperty("mid")]
        public int Mid { get; set; }

        [JsonProperty("np")]
        public int Np { get; set; }
    }

}
