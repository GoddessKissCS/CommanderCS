using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class EventRaidData
    {
        [JsonProperty("mbid")]
        public string bossId { get; set; }

        [JsonProperty("eidx")]
        public string eIdx { get; set; }

        [JsonProperty("enmy")]
        public string enemy { get; set; }

        [JsonProperty("lv")]
        public int level { get; set; }

        [JsonProperty("hp")]
        public int hp { get; set; }

        [JsonProperty("dmg")]
        public int damage { get; set; }

        [JsonProperty("remain")]
        public int remain { get; set; }

        [JsonProperty("name")]
        public string userName { get; set; }

        [JsonProperty("attendCount")]
        public int attendCount { get; set; }

        [JsonProperty("isown")]
        public int isOwn { get; set; }

        [JsonProperty("isshare")]
        public int isShare { get; set; }

        [JsonProperty("isclr")]
        public int clear { get; set; }

        [JsonProperty("recvRwd")]
        public int receive { get; set; }
    }
}