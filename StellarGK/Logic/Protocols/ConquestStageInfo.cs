using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class ConquestStageInfo
    {
        [JsonPropertyName("einfo")]
        public EnemyInfo enemyInfo { get; set; }

        [JsonPropertyName("alie")]
        public List<User> alieList { get; set; }

        [JsonPropertyName("enemy")]
        public List<User> enemyList { get; set; }


        public class User
        {
            [JsonPropertyName("uno")]
            public string uno { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("thumb")]
            public string thumb { get; set; }

            [JsonPropertyName("auth")]
            public int auth { get; set; }

            [JsonPropertyName("standby")]
            public int standby { get; set; }

            [JsonPropertyName("move")]
            public int move { get; set; }
        }


        public class EnemyInfo
        {
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("emblem")]
            public string emblem { get; set; }

            [JsonPropertyName("gidx")]
            public int gidx { get; set; }
        }
    }
}
