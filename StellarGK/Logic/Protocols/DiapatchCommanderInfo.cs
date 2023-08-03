using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class DiapatchCommanderInfo
    {
        [JsonPropertyName("cid")]
        public int cid { get; set; }

        [JsonPropertyName("rgtm")]
        public int runtime { get; set; }

        [JsonPropertyName("ecnt")]
        public int engageCnt { get; set; }

        [JsonPropertyName("egld")]
        public int getGold { get; set; }
    }
}
