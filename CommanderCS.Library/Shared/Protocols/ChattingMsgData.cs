using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class ChattingMsgData
    {
        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("rply", NullValueHandling = NullValueHandling.Ignore)]
        public ChattingRecordInfo record { get; set; }
    }
}