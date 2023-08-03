using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ChattingMsgData
    {
        [JsonPropertyName("data")]
        public string data { get; set; }

        [JsonPropertyName("rply")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ChattingRecordInfo record { get; set; }
    }
}
