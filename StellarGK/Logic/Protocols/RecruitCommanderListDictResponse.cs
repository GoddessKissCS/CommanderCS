using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecruitCommanderListDictResponse
    {
        [JsonPropertyName("list")]
        public Dictionary<string, Commander> list { get; set; }

        [JsonPropertyName("remain")]
        public int remainTime { get; set; }


        public class Commander
        {
            [JsonPropertyName("cid")]
            public string id { get; set; }

            [JsonPropertyName("grd")]
            public string rank { get; set; }

            [JsonPropertyName("honr")]
            public int honor { get; set; }

            [JsonPropertyName("gold")]
            public int gold { get; set; }

            [JsonPropertyName("cash")]
            public int cash { get; set; }

            [JsonPropertyName("sell")]
            public bool recruited { get; set; }

            [JsonPropertyName("wait")]
            public int waitTime { get; set; }

            [JsonPropertyName("dnm")]
            public int troopNickname { get; set; }
        }
    }
}
