using Newtonsoft.Json;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildList)]
    public class GuildList : BaseCommandHandler<GuildListRequest>
    {
        public override object Handle(GuildListRequest @params)
        {
            List<RoGuild> guilds = new();

            RoGuild guild = new()
            {
                apnt = 1,
                cnt = 1,
                emb = 1,
                gidx = 1,
                gnm = "Admin Lounge",
                gtyp = 1,
                lev = 1,
                list = "",
                mxCnt = 1,
                ntc = "Hey",
                world = 1,
            };

            guilds.Add(guild);

            // TODO ADD SEARCH
            // TODO
            // GUILDLIST returns either guildlist or guildinfo + memberdata
            // guildlist when you arent in a guild
            // and guildinfo + memberdata when you are in a guild
            // needs to be added 


            Logic.Protocols.GuildInfo guildInfo = new()
            {
                resource = null,
                guildInfo = null,
                memberData = null,
                guildList = guilds,
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = guildInfo
            };

            return JsonConvert.SerializeObject(response);
        }

    }

    public class GuildListRequest
    {

    }
}
