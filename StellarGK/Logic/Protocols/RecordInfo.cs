using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RecordInfo
    {

        [JsonPropertyName("gnm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string guildName { get; set; }

        [JsonPropertyName("uno")]
        public int uno;

        [JsonPropertyName("rid")]
        public string id;

        [JsonPropertyName("replayData")]
        public object data;

        [JsonPropertyName("ws")]
        public int winState;

        [JsonPropertyName("smvr")]
        public int simulationVer;

        [JsonPropertyName("rlvr")]
        public double regulationVer;

        [JsonPropertyName("unm")]
        public string _userName;

        [JsonPropertyName("thmb")]
        public string thumbnail;

        [JsonPropertyName("lv")]
        public int level;

        [JsonPropertyName("rank")]
        public int rank;

        [JsonPropertyName("date")]
        public double date;

        [JsonPropertyName("vs")]
        public UserInfo userInfo;


        public class UserInfo
        {
            [JsonPropertyName("lnm")]
            public string lName;

            [JsonPropertyName("llv")]
            public int lLevel;

            [JsonPropertyName("rnm")]
            public string rName;

            [JsonPropertyName("rlv")]
            public string rLevel;
        }
    }
}
