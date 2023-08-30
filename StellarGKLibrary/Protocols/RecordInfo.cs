using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{

    public class RecordInfo
    {

        [JsonProperty("gnm", NullValueHandling = NullValueHandling.Ignore)]
        public string guildName { get; set; }

        [JsonProperty("uno")]
        public int uno { get; set; }

        [JsonProperty("rid")]
        public string id { get; set; }

        [JsonProperty("replayData")]
        public object data { get; set; }

        [JsonProperty("ws")]
        public int winState { get; set; }

        [JsonProperty("smvr")]
        public int simulationVer { get; set; }

        [JsonProperty("rlvr")]
        public double regulationVer { get; set; }

        [JsonProperty("unm")]
        public string _userName { get; set; }

        [JsonProperty("thmb")]
        public string thumbnail { get; set; }

        [JsonProperty("lv")]
        public int level { get; set; }

        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("date")]
        public double date { get; set; }

        [JsonProperty("vs")]
        public UserInfo userInfo { get; set; }


        public class UserInfo
        {
            [JsonProperty("lnm")]
            public string lName { get; set; }

            [JsonProperty("llv")]
            public int lLevel { get; set; }

            [JsonProperty("rnm")]
            public string rName { get; set; }

            [JsonProperty("rlv")]
            public string rLevel { get; set; }
        }
    }
}
