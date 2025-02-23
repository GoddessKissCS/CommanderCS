﻿using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Protocols
{
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