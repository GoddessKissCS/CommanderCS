using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GuildMember
    {
        [JsonPropertyName("member")]
        public List<MemberData> memberData { get; set; }

        [JsonPropertyName("bb")]
        public int badge { get; set; }


        public class MemberData
        {
            [JsonPropertyName("uno")]
            public int uno { get; set; }

            [JsonPropertyName("unm")]
            public string name { get; set; }

            [JsonPropertyName("thumb")]
            public int thumnail { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("time")]
            public double lastTime { get; set; }

            [JsonPropertyName("mstr")]
            public int memberGrade { get; set; }

            [JsonPropertyName("dpnt")]
            public int todayPoint { get; set; }

            [JsonPropertyName("mpnt")]
            public int totalPoint { get; set; }

            [JsonPropertyName("pbpnt")]
            public int paymentBonusPoint { get; set; }

            [JsonPropertyName("world")]
            public int world { get; set; }
        }
    }
}
