using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class SystemMessage
    {
        [JsonProperty("lvup")]
        public int level { get; set; }

        [JsonProperty("sess")]
        public string session { get; set; }

        [JsonProperty("cid")]
        public string commanderId { get; set; }

        [JsonProperty("dmid")]
        public int missionId { get; set; }

        [JsonProperty("fin")]
        public bool missionComplete { get; set; }

        [JsonProperty("gidx")]
        public string __gidx { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("systemCheck")]
        public SystemCheck systemCheck { get; set; }

        [JsonProperty("notice")]
        public NoticeList noticeList { get; set; }

        [JsonProperty("cnv")]
        public int carnival1 { get; set; }

        [JsonProperty("cnv2")]
        public int carnival2 { get; set; }

        [JsonProperty("cnv3")]
        public int carnival3 { get; set; }

        [JsonProperty("rstm")]
        public int resetRemain { get; set; }

        public class SystemCheck
        {
            [JsonProperty("fromTime")]
            public double fromTime { get; set; }

            [JsonProperty("toTime")]
            public double toTime { get; set; }

            [JsonProperty("msg")]
            public Message message { get; set; }

            [JsonProperty("now")]
            public double nowTime { get; set; }

            public class Message
            {
                [JsonProperty("ko")]
                public string ko { get; set; }

                [JsonProperty("cng")]
                public string cn { get; set; }

                [JsonProperty("cnb")]
                public string tw { get; set; }

                [JsonProperty("jp")]
                public string jp { get; set; }

                [JsonProperty("en")]
                public string en { get; set; }

                [JsonProperty("ru")]
                public string ru { get; set; }
            }
        }

        public class NoticeList
        {
            [JsonProperty("realtime")]
            public NoticeData realtime { get; set; }

            [JsonProperty("chat")]
            public NoticeData chat { get; set; }
        }

        public class NoticeData
        {
            [JsonProperty("ctnt")]
            public string contents { get; set; }

            [JsonProperty("idx")]
            public int idx { get; set; }

            [JsonProperty("sdt")]
            public double startDate { get; set; }

            [JsonProperty("edt")]
            public double endDate { get; set; }
        }
    }
}