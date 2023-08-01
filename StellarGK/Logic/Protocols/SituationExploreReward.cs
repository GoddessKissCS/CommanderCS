using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SituationExploreReward
    {
        [JsonProperty("sply")]
        public int exploreTicket { get; set; }

        [JsonProperty("gold")]
        public string __gold { get; set; }

        [JsonProperty("cash")]
        public string __cash { get; set; }

        [JsonProperty("reward")]
        public object __reward { get; set; }

        public Dictionary<string, int> reward
        {
            get
            {
                if (__reward == null)
                {
                    return null;
                }
                JArray jarray = null;
                try
                {
                    jarray = JArray.FromObject(__reward);
                }
                catch (Exception ex)
                {
                    _ = ex;
                }
                if (jarray != null)
                {
                    return null;
                }
                JObject jobject = JObject.FromObject(__reward);
                return jobject.ToObject<Dictionary<string, int>>();
            }
        }
    }
}
