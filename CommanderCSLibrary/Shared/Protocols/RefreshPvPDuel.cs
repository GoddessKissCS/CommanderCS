using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
    public class RefreshPvPDuel
    {
        [JsonProperty("list")]
        public Dictionary<int, PvPDuelList.PvPDuelData> duelList { get; set; }

        [JsonProperty("rfrm")]
        public int remain { get; set; }

        [JsonProperty("itrm")]
        public int time { get; set; }

        [JsonProperty("oprm")]
        public int openRemain { get; set; }

        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }
    }
}