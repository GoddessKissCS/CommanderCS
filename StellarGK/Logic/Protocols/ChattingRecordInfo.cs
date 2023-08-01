using Newtonsoft.Json;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChattingRecordInfo
    {
        [JsonProperty("rid")]
        public string id { get; set; }

        [JsonProperty("unm")]
        public string userName { get; set; }

        [JsonProperty("enm")]
        public string enemyName { get; set; }

        [JsonProperty("type")]
        public ERePlayType rePlayType { get; set; }

        [JsonIgnore]
        public bool hasRecord { get; set; }
    }
}
