using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class ChattingInfo
    {
        [JsonProperty("whisper")]
        public List<ChattingData> whisperList { get; set; }

        [JsonProperty("channel")]
        public List<ChattingData> channelList { get; set; }

        [JsonProperty("guild")]
        public List<ChattingData> guildList { get; set; }

        [JsonProperty("time")]
        public int time { get; set; }

        public class ChattingData
        {
            [JsonProperty("chanel")]
            public string __channel { get; set; }

            [JsonProperty("uno")]
            public string __uno { get; set; }

            [JsonProperty("svr")]
            public int sendChannel { get; set; }

            [JsonProperty("swld")]
            public int sendWorld { get; set; }

            [JsonProperty("send")]
            public string sendUno { get; set; }

            [JsonProperty("snm")]
            public string nickname { get; set; }

            [JsonProperty("gnm", NullValueHandling = NullValueHandling.Ignore)]
            public string guildName { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("msg")]
            public string message { get; set; }

            [JsonProperty("date")]
            public double date { get; set; }

            [JsonProperty("thmb")]
            public string thumbnail { get; set; }

            /*
             *
             *  TODO
            public ChattingMsgData chatMsgData
            {
                get
                {
                    if (_chatMsgData is null)
                    {
                        _chatMsgData = JsonConvert.DeserializeObject<ChattingMsgData>(message, new JsonSerializerSettings
                        {
                            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                            DefaultValueHandling = DefaultValueHandling.Include,
                            NullValueHandling = NullValueHandling.Include,
                            ContractResolver = new DefaultContractResolver
                            {
#pragma warning disable CS0618
                                DefaultMembersSearchFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
#pragma warning restore CS0618
                            }
                        });
                        if (_chatMsgData.record is not null)
                        {
                            _chatMsgData.record.hasRecord = true;
                        }
                    }
                    return _chatMsgData;
                }
            }
            */

            [JsonIgnore]
            public ChattingMsgData _chatMsgData;
        }
    }
}