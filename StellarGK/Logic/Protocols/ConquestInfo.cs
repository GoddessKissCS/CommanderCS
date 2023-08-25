using StellarGK.Logic.Enums;
using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ConquestInfo
    {
        [JsonPropertyName("step")]
        public EConquestState state { get; set; }

        [JsonPropertyName("remain")]
        public int remain { get; set; }

        [JsonPropertyName("signed")]
        public int sign { get; set; }

        [JsonPropertyName("join")]
        public int join { get; set; }

        [JsonPropertyName("side")]
        public string side { get; set; }

        [JsonPropertyName("prev")]
        public PrevState prev { get; set; }


        public class PrevState
        {
            [JsonPropertyName("isWin")]
            public int isWin { get; set; }

            [JsonPropertyName("exdt")]
            public int exdt { get; set; }

            [JsonPropertyName("point")]
            public Point pointData { get; set; }

            [JsonPropertyName("users")]
            public Dictionary<string, int> userList { get; set; }

            [JsonPropertyName("usrpnt")]
            public List<int> standbyList { get; set; }


            public class Point
            {
                [JsonPropertyName("win")]
                public List<int> win { get; set; }

                [JsonPropertyName("lose")]
                public List<int> lose { get; set; }
            }
        }
    }

}
