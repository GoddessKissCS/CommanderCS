using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class WaveBattleInfoList
    {
        [JsonPropertyName("wavebattle")]
        public List<WaveBattleInfo> InfoList { get; set; }


        public class WaveBattleInfo
        {
            [JsonPropertyName("wbid")]
            public int battleIdx { get; set; }

            [JsonPropertyName("otime")]
            public int openTime { get; set; }

            [JsonPropertyName("ctime")]
            public int closeTime { get; set; }

            [JsonPropertyName("clearCnt")]
            public int clearCount { get; set; }

            [JsonPropertyName("maxCnt")]
            public int maxCount { get; set; }
        }
    }
}
