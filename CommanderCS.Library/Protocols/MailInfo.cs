using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class MailInfo
    {
        [JsonProperty("list")]
        public List<MailData> mailList { get; set; }

        public class MailData
        {
            [JsonProperty("idx")]
            public int idx { get; set; }

            [JsonProperty("type")]
            public int type { get; set; }

            [JsonProperty("msg")]
            public string message { get; set; }

            [JsonProperty("rmtm")]
            public double remainTime { get; set; }

            [JsonProperty("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }

            [JsonProperty("sts")]
            public string status { get; set; }

            [JsonProperty("recv")]
            public string __receive { get; set; }
        }
    }
}