using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class MailInfo
    {
        [JsonPropertyName("list")]
        public List<MailData> mailList { get; set; }

        public class MailData
        {
            [JsonPropertyName("idx")]
            public int idx { get; set; }

            [JsonPropertyName("type")]
            public int type { get; set; }

            [JsonPropertyName("msg")]
            public string message { get; set; }

            [JsonPropertyName("rmtm")]
            public double remainTime { get; set; }

            [JsonPropertyName("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }

            [JsonPropertyName("sts")]
            public string status { get; set; }

            [JsonPropertyName("recv")]
            public string __receive { get; set; }
        }
    }
}
