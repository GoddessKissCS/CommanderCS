using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class ServerData
    {
        [JsonProperty("ws")]
        public List<ServerInfo> serverInfoList { get; set; }

        [JsonProperty("new")]
        public int newServer { get; set; }

        [JsonProperty("rsrv")]
        public int recommandServer { get; set; }

        public class ServerInfo
        {
            [JsonProperty("wld")]
            public int idx { get; set; }

            [JsonProperty("stus")]
            public int status { get; set; }

            [JsonProperty("thum")]
            public int thumnail { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("lcdt")]
            public double lastLoginTime { get; set; }
        }
    }
}