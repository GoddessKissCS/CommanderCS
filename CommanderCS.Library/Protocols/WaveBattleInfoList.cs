using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class WaveBattleInfoList
    {
        [JsonProperty("wavebattle")]
        public List<WaveBattleInfo> InfoList { get; set; }

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