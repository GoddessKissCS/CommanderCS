using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ChattingRecordInfo
    {
        [JsonPropertyName("rid")]
        public string id { get; set; }

        [JsonPropertyName("unm")]
        public string userName { get; set; }

        [JsonPropertyName("enm")]
        public string enemyName { get; set; }

        [JsonPropertyName("type")]
        public ERePlayType rePlayType { get; set; }

        [JsonIgnore]
        public bool hasRecord { get; set; }
    }
}
