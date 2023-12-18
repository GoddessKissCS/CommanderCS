using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class RecruitCommanderListDictResponse
    {
        [JsonProperty("list")]
        public Dictionary<string, Commander> list { get; set; }

        [JsonProperty("remain")]
        public int remainTime { get; set; }

        public class Commander
        {
            [JsonProperty("cid")]
            public string id { get; set; }

            [JsonProperty("grd")]
            public string rank { get; set; }

            [JsonProperty("honr")]
            public int honor { get; set; }

            [JsonProperty("gold")]
            public int gold { get; set; }

            [JsonProperty("cash")]
            public int cash { get; set; }

            [JsonProperty("sell")]
            public bool recruited { get; set; }

            [JsonProperty("wait")]
            public int waitTime { get; set; }

            [JsonProperty("dnm")]
            public int troopNickname { get; set; }
        }
    }
}