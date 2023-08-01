using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChattingMsgData
    {
        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("rply", NullValueHandling = NullValueHandling.Ignore)]
        public ChattingRecordInfo record { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
