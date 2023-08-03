using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class RefreshPvPDuel
    {
        [JsonPropertyName("list")]
        public Dictionary<int, PvPDuelList.PvPDuelData> duelList { get; set; }

        [JsonPropertyName("rfrm")]
        public int remain { get; set; }

        [JsonPropertyName("itrm")]
        public int time { get; set; }

        [JsonPropertyName("oprm")]
        public int openRemain { get; set; }

        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource rsoc;
    }
}
