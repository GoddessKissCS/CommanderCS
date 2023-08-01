using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RecordInfo
    {

        [JsonProperty("gnm", NullValueHandling = NullValueHandling.Ignore)]
        public string guildName { get; set; }

        [JsonProperty("uno")]
        public int uno;

        [JsonProperty("rid")]
        public string id;

        [JsonProperty("replayData")]
        public object data;

        [JsonProperty("ws")]
        public int winState;

        [JsonProperty("smvr")]
        public int simulationVer;

        [JsonProperty("rlvr")]
        public double regulationVer;

        [JsonProperty("unm")]
        public string _userName;

        [JsonProperty("thmb")]
        public string thumbnail;

        [JsonProperty("lv")]
        public int level;

        [JsonProperty("rank")]
        public int rank;

        [JsonProperty("date")]
        public double date;

        [JsonProperty("vs")]
        public UserInfo userInfo;

        [JsonObject(MemberSerialization.OptIn)]
        public class UserInfo
        {
            [JsonProperty("lnm")]
            public string lName;

            [JsonProperty("llv")]
            public int lLevel;

            [JsonProperty("rnm")]
            public string rName;

            [JsonProperty("rlv")]
            public string rLevel;
        }
    }
}
