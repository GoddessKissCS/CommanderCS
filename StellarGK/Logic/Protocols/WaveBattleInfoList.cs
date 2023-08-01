using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WaveBattleInfoList
    {
        [JsonProperty("wavebattle")]
        public List<WaveBattleInfo> InfoList { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class WaveBattleInfo
        {
            [JsonProperty("wbid")]
            public int battleIdx { get; set; }

            [JsonProperty("otime")]
            public int openTime { get; set; }

            [JsonProperty("ctime")]
            public int closeTime { get; set; }

            [JsonProperty("clearCnt")]
            public int clearCount { get; set; }

            [JsonProperty("maxCnt")]
            public int maxCount { get; set; }
        }
    }
}
