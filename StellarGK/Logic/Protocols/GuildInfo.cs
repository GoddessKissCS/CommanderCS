using System.Text.Json.Serialization;

namespace StellarGK.Logic.Protocols
{

    public class GuildInfo
    {
        [JsonPropertyName("rsoc")]
        public UserInformationResponse.Resource resource { get; set; }

        [JsonPropertyName("gld")]
        public UserInformationResponse.UserGuild guildInfo { get; set; }

        [JsonPropertyName("member")]
        public List<GuildMember.MemberData> memberData { get; set; }

        [JsonPropertyName("glist")]
        public List<RoGuild> guildList { get; set; }
    }
}
