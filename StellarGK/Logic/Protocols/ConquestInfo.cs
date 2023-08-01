using Newtonsoft.Json;
using StellarGK.Logic.Enums;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ConquestInfo
    {
        [JsonProperty("step")]
        public EConquestState state { get; set; }

        [JsonProperty("remain")]
        public int remain { get; set; }

        [JsonProperty("signed")]
        public int sign { get; set; }

        [JsonProperty("join")]
        public int join { get; set; }

        [JsonProperty("side")]
        public string side { get; set; }

        [JsonProperty("prev")]
        public PrevState prev { get; set; }

        [JsonObject(MemberSerialization.OptIn)]
        public class PrevState
        {
            [JsonProperty("isWin")]
            public int isWin { get; set; }

            [JsonProperty("exdt")]
            public int exdt { get; set; }

            [JsonProperty("point")]
            public Point pointData { get; set; }

            [JsonProperty("users")]
            public Dictionary<string, int> userList { get; set; }

            [JsonProperty("usrpnt")]
            public List<int> standbyList { get; set; }

            [JsonObject(MemberSerialization.OptIn)]
            public class Point
            {
                [JsonProperty("win")]
                public List<int> win { get; set; }

                [JsonProperty("lose")]
                public List<int> lose { get; set; }
            }
        }
    }

}
