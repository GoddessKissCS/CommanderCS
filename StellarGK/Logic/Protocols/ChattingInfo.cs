using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ChattingInfo
    {
        [JsonPropertyName("whisper")]
        public List<ChattingData> whisperList { get; set; }

        [JsonPropertyName("channel")]
        public List<ChattingData> channelList { get; set; }

        [JsonPropertyName("guild")]
        public List<ChattingData> guildList { get; set; }

        [JsonPropertyName("time")]
        public int time { get; set; }


        public class ChattingData
        {
            [JsonPropertyName("chanel")]
            public string __channel { get; set; }

            [JsonPropertyName("uno")]
            public string __uno { get; set; }

            [JsonPropertyName("svr")]
            public int sendChannel { get; set; }

            [JsonPropertyName("swld")]
            public int sendWorld { get; set; }

            [JsonPropertyName("send")]
            public string sendUno { get; set; }

            [JsonPropertyName("snm")]
            public string nickname { get; set; }

            [JsonPropertyName("gnm")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string guildName { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("msg")]
            public string message { get; set; }

            [JsonPropertyName("date")]
            public double date { get; set; }

            [JsonPropertyName("thmb")]
            public string thumbnail { get; set; }

            /*
             * 
             *  TODO
            public ChattingMsgData chatMsgData
            {
                get
                {
                    if (_chatMsgData == null)
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
                        if (_chatMsgData.record != null)
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
