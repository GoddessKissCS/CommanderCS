using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class GetConquestBattle
    {
        [JsonProperty("entry")]
        public Entry entry { get; set; }

        [JsonProperty("battle")]
        public List<Battle> battle { get; set; }

        [JsonProperty("world")]
        public int enemyWorld { get; set; }

        [JsonProperty("egnm")]
        public string enemyName { get; set; }

        [JsonProperty("eside")]
        public string eSide { get; set; }

        public class Entry
        {
            [JsonProperty("red")]
            public List<EntryInfo> red { get; set; }

            [JsonProperty("blue")]
            public List<EntryInfo> blue { get; set; }
        }

        public class EntryInfo
        {
            [JsonProperty("uno")]
            public string uno { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("lv")]
            public int level { get; set; }

            [JsonProperty("thumb")]
            public string thumb { get; set; }

            [JsonProperty("deck")]
            public List<ConquestStageUser.Deck> deck { get; set; }
        }

        public class Battle
        {
            [JsonProperty("entry")]
            public BattleEntry entry { get; set; }

            [JsonProperty("result")]
            public Result result { get; set; }

            [JsonProperty("rid")]
            public string replayId { get; set; }
        }

        public class BattleEntry
        {
            [JsonProperty("red")]
            public Dictionary<string, BattleEntryInfo> red { get; set; }

            [JsonProperty("blue")]
            public Dictionary<string, BattleEntryInfo> blue { get; set; }
        }

        public class BattleEntryInfo
        {
            [JsonProperty("pos")]
            public int pos { get; set; }

            [JsonProperty("hp")]
            public int hp { get; set; }

            [JsonProperty("maxHp")]
            public int maxHp { get; set; }
        }

        public class Result
        {
            [JsonProperty("red")]
            public Dictionary<string, ResultInfo> red { get; set; }

            [JsonProperty("blue")]
            public Dictionary<string, ResultInfo> blue { get; set; }
        }

        public class ResultInfo
        {
            [JsonProperty("hp")]
            public int hp { get; set; }
        }
    }
}