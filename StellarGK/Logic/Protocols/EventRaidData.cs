using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class EventRaidData
    {
        [JsonPropertyName("mbid")]
        public string bossId { get; set; }

        [JsonPropertyName("eidx")]
        public string eIdx { get; set; }

        [JsonPropertyName("enmy")]
        public string enemy { get; set; }

        [JsonPropertyName("lv")]
        public int level { get; set; }

        [JsonPropertyName("hp")]
        public int hp { get; set; }

        [JsonPropertyName("dmg")]
        public int damage { get; set; }

        [JsonPropertyName("remain")]
        public int remain { get; set; }

        [JsonPropertyName("name")]
        public string userName { get; set; }

        [JsonPropertyName("attendCount")]
        public int attendCount { get; set; }

        [JsonPropertyName("isown")]
        public int isOwn { get; set; }

        [JsonPropertyName("isshare")]
        public int isShare { get; set; }

        [JsonPropertyName("isclr")]
        public int clear { get; set; }

        [JsonPropertyName("recvRwd")]
        public int receive { get; set; }
    }
}
