using System.Text.Json.Serialization;


namespace StellarGK.Logic.Protocols
{

    public class ConquestStageUser
    {
        [JsonPropertyName("slot")]
        public int slot { get; set; }

        [JsonPropertyName("stat")]
        public string state { get; set; }

        [JsonPropertyName("deck")]
        public List<Deck> deck { get; set; }


        public class Deck
        {
            [JsonPropertyName("cid")]
            public string cid { get; set; }

            [JsonPropertyName("lev")]
            public int level { get; set; }

            [JsonPropertyName("grade")]
            public int grade { get; set; }

            [JsonPropertyName("class")]
            public int cls { get; set; }

            [JsonPropertyName("cos")]
            public int costume { get; set; }

            [JsonPropertyName("pos")]
            public int position { get; set; }

            [JsonPropertyName("mry")]
            public int marry { get; set; }

            [JsonPropertyName("tsdc")]
            public List<int> transcendence { get; set; }
        }
    }
}
