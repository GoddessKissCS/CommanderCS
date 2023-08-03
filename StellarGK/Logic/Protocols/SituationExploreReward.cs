using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace StellarGK.Logic.Protocols
{

    public class SituationExploreReward
    {
        [JsonPropertyName("sply")]
        public int exploreTicket { get; set; }

        [JsonPropertyName("gold")]
        public string __gold { get; set; }

        [JsonPropertyName("cash")]
        public string __cash { get; set; }

        [JsonPropertyName("reward")]
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
