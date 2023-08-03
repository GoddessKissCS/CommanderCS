using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ServerData
    {
        [JsonPropertyName("ws")]
        public List<ServerInfo> serverInfoList { get; set; }

        [JsonPropertyName("new")]
        public int newServer { get; set; }

        [JsonPropertyName("rsrv")]
        public int recommandServer { get; set; }


        public class ServerInfo
        {
            [JsonPropertyName("wld")]
            public int idx { get; set; }

            [JsonPropertyName("stus")]
            public int status { get; set; }

            [JsonPropertyName("thum")]
            public int thumnail { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("lcdt")]
            public double lastLoginTime { get; set; }
        }
    }
}
