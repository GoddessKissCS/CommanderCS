using Newtonsoft.Json;

namespace CommanderCS.Library.Protocols
{
    public class CooperateBattleData
    {
        [JsonProperty("coop")]
        public CooperateInfo coop { get; set; }

        [JsonProperty("recv")]
        public CooperateReceiveInfo recv { get; set; }
    }
}