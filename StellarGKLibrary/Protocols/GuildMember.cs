using Newtonsoft.Json;

namespace StellarGKLibrary.Protocols
{
    public class GuildMember
    {
        [JsonProperty("member")]
        public List<MemberData> memberData { get; set; }

        [JsonProperty("bb")]
        public int badge { get; set; }

        public class MemberData
        {
            [JsonProperty("uno")]
            public int uno { get; set; }

            [JsonProperty("unm")]
            public string name { get; set; }

            [JsonProperty("thumb")]
            public int thumnail { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("time")]
            public double lastTime { get; set; }

            [JsonProperty("mstr")]
            public int memberGrade { get; set; }

            [JsonProperty("dpnt")]
            public int todayPoint { get; set; }

            [JsonProperty("mpnt")]
            public int totalPoint { get; set; }

            [JsonProperty("pbpnt")]
            public int paymentBonusPoint { get; set; }

            [JsonProperty("world")]
            public int world { get; set; }
        }
    }
}