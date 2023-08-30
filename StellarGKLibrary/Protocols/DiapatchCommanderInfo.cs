using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class DiapatchCommanderInfo
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("rgtm")]
        public int runtime { get; set; }

        [JsonProperty("ecnt")]
        public int engageCnt { get; set; }

        [JsonProperty("egld")]
        public int getGold { get; set; }
    }
}
