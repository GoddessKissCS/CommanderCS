using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class SystemMessage
    {
        [JsonPropertyName("lvup")]
        public int level { get; set; }

        [JsonPropertyName("sess")]
        public string session { get; set; }

        [JsonPropertyName("cid")]
        public string commanderId { get; set; }

        [JsonPropertyName("dmid")]
        public int missionId { get; set; }

        [JsonPropertyName("fin")]
        public bool missionComplete { get; set; }

        [JsonPropertyName("gidx")]
        public string __gidx { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("systemCheck")]
        public SystemCheck systemCheck { get; set; }

        [JsonPropertyName("notice")]
        public NoticeList noticeList { get; set; }

        [JsonPropertyName("cnv")]
        public int carnival1 { get; set; }

        [JsonPropertyName("cnv2")]
        public int carnival2 { get; set; }

        [JsonPropertyName("cnv3")]
        public int carnival3 { get; set; }

        [JsonPropertyName("rstm")]
        public int resetRemain { get; set; }


        public class SystemCheck
        {
            [JsonPropertyName("fromTime")]
            public double fromTime { get; set; }

            [JsonPropertyName("toTime")]
            public double toTime { get; set; }

            [JsonPropertyName("msg")]
            public Message message { get; set; }

            [JsonPropertyName("now")]
            public double nowTime { get; set; }


            public class Message
            {
                [JsonPropertyName("ko")]
                public string ko { get; set; }

                [JsonPropertyName("cng")]
                public string cn { get; set; }

                [JsonPropertyName("cnb")]
                public string tw { get; set; }

                [JsonPropertyName("jp")]
                public string jp { get; set; }

                [JsonPropertyName("en")]
                public string en { get; set; }

                [JsonPropertyName("ru")]
                public string ru { get; set; }
            }
        }


        public class NoticeList
        {
            [JsonPropertyName("realtime")]
            public NoticeData realtime { get; set; }

            [JsonPropertyName("chat")]
            public NoticeData chat { get; set; }
        }


        public class NoticeData
        {
            [JsonPropertyName("ctnt")]
            public string contents { get; set; }

            [JsonPropertyName("idx")]
            public int idx { get; set; }

            [JsonPropertyName("sdt")]
            public double startDate { get; set; }

            [JsonPropertyName("edt")]
            public double endDate { get; set; }
        }
    }
}
