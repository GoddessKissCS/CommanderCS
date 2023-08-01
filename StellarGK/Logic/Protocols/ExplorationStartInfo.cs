using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ExplorationStartInfo
    {
        [JsonProperty("idx")]
        public int idx;

        [JsonProperty("cid")]
        public List<string> cids;
    }
}
