using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GetConquestBattle
    {
        [JsonPropertyName("entry")]
        public Entry entry { get; set; }

        [JsonPropertyName("battle")]
        public List<Battle> battle { get; set; }

        [JsonPropertyName("world")]
        public int enemyWorld { get; set; }

        [JsonPropertyName("egnm")]
        public string enemyName { get; set; }

        [JsonPropertyName("eside")]
        public string eSide { get; set; }


        public class Entry
        {
            [JsonPropertyName("red")]
            public List<EntryInfo> red { get; set; }

            [JsonPropertyName("blue")]
            public List<EntryInfo> blue { get; set; }
        }


        public class EntryInfo
        {
            [JsonPropertyName("uno")]
            public string uno { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("lv")]
            public int level { get; set; }

            [JsonPropertyName("thumb")]
            public string thumb { get; set; }

            [JsonPropertyName("deck")]
            public List<ConquestStageUser.Deck> deck { get; set; }
        }


        public class Battle
        {
            [JsonPropertyName("entry")]
            public BattleEntry entry { get; set; }

            [JsonPropertyName("result")]
            public Result result { get; set; }

            [JsonPropertyName("rid")]
            public string replayId { get; set; }
        }


        public class BattleEntry
        {
            [JsonPropertyName("red")]
            public Dictionary<string, BattleEntryInfo> red { get; set; }

            [JsonPropertyName("blue")]
            public Dictionary<string, BattleEntryInfo> blue { get; set; }
        }


        public class BattleEntryInfo
        {
            [JsonPropertyName("pos")]
            public int pos { get; set; }

            [JsonPropertyName("hp")]
            public int hp { get; set; }

            [JsonPropertyName("maxHp")]
            public int maxHp { get; set; }
        }


        public class Result
        {
            [JsonPropertyName("red")]
            public Dictionary<string, ResultInfo> red { get; set; }

            [JsonPropertyName("blue")]
            public Dictionary<string, ResultInfo> blue { get; set; }
        }


        public class ResultInfo
        {
            [JsonPropertyName("hp")]
            public int hp { get; set; }
        }
    }
}
