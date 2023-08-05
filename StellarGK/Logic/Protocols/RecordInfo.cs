using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecordInfo
    {

        [JsonPropertyName("gnm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string guildName { get; set; }

        [JsonPropertyName("uno")]
        public int uno { get; set; }

        [JsonPropertyName("rid")]
        public string id { get; set; }

        [JsonPropertyName("replayData")]
        public object data { get; set; }

        [JsonPropertyName("ws")]
        public int winState { get; set; }

        [JsonPropertyName("smvr")]
        public int simulationVer { get; set; }

        [JsonPropertyName("rlvr")]
        public double regulationVer { get; set; }

        [JsonPropertyName("unm")]
        public string _userName { get; set; }

        [JsonPropertyName("thmb")]
        public string thumbnail { get; set; }

        [JsonPropertyName("lv")]
        public int level { get; set; }

        [JsonPropertyName("rank")]
        public int rank { get; set; }

        [JsonPropertyName("date")]
        public double date { get; set; }

        [JsonPropertyName("vs")]
        public UserInfo userInfo { get; set; }


        public class UserInfo
        {
            [JsonPropertyName("lnm")]
            public string lName { get; set; }

            [JsonPropertyName("llv")]
            public int lLevel { get; set; }

            [JsonPropertyName("rnm")]
            public string rName { get; set; }

            [JsonPropertyName("rlv")]
            public string rLevel { get; set; }
        }
    }
}
