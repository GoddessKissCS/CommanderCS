using Newtonsoft.Json;

namespace CommanderCS.Protocols
{
    public class CooperateBattleData
    {
        [JsonProperty("coop")]
        public CooperateInfo coop { get; set; }

        [JsonProperty("recv")]
        public CooperateReceiveInfo recv { get; set; }
    }
}