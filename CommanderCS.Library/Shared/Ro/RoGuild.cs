using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Ro
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RoGuild
    {
        [JsonProperty]
        public string list { get; set; }

        [JsonProperty]
        public int gidx { get; set; }

        [JsonProperty]
        public string gnm { get; set; }

        [JsonProperty]
        public string ntc { get; set; }

        [JsonProperty]
        public int lev { get; set; }

        [JsonProperty]
        public int apnt { get; set; }

        [JsonProperty]
        public int emb { get; set; }

        [JsonProperty]
        public int gtyp { get; set; }

        [JsonProperty]
        public int mxCnt { get; set; }

        [JsonProperty]
        public int cnt { get; set; }

        [JsonProperty]
        public int world { get; set; }
    }
}