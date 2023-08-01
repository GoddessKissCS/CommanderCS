using Newtonsoft.Json;

namespace StellarGK.Logic.Protocols
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GuildInfo
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonProperty("gld")]
        public UserInformationResponse.UserGuild guildInfo { get; set; }

        [JsonProperty("member")]
        public List<GuildMember.MemberData> memberData { get; set; }

        [JsonProperty("glist")]
        public List<RoGuild> guildList { get; set; }
    }
}
