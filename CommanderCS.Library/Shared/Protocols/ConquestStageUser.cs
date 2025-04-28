using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class ConquestStageUser
    {
        [JsonProperty("slot")]
        public int slot { get; set; }

        [JsonProperty("stat")]
        public string state { get; set; }

        [JsonProperty("deck")]
        public List<Deck> deck { get; set; }

        public class Deck
        {
            [JsonProperty("cid")]
            public string cid { get; set; }

            [JsonProperty("lev")]
            public int level { get; set; }

            [JsonProperty("grade")]
            public int grade { get; set; }

            [JsonProperty("class")]
            public int cls { get; set; }

            [JsonProperty("cos")]
            public int costume { get; set; }

            [JsonProperty("pos")]
            public int position { get; set; }

            [JsonProperty("mry")]
            public int marry { get; set; }

            [JsonProperty("tsdc")]
            public List<int> transcendence { get; set; }
        }
    }
}