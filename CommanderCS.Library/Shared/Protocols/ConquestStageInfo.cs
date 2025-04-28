using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Protocols
{
    public class ConquestStageInfo
    {
        [JsonProperty("einfo")]
        public EnemyInfo enemyInfo { get; set; }

        [JsonProperty("alie")]
        public List<User> alieList { get; set; }

        [JsonProperty("enemy")]
        public List<User> enemyList { get; set; }

        public class User
        {
            [JsonProperty("uno")]
            public string uno { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("thumb")]
            public string thumb { get; set; }

            [JsonProperty("auth")]
            public int auth { get; set; }

            [JsonProperty("standby")]
            public int standby { get; set; }

            [JsonProperty("move")]
            public int move { get; set; }
        }

        public class EnemyInfo
        {
            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("emblem")]
            public string emblem { get; set; }

            [JsonProperty("gidx")]
            public int gidx { get; set; }
        }
    }
}