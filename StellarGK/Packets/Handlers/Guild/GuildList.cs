using StellarGK.Database;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildList)]
    public class GuildList : BaseCommandHandler<GuildListRequest>
    {
        public override object Handle(GuildListRequest @params)
        {

            Logic.Protocols.GuildInfo guildList = new()
            {
                resource = null,
                guildInfo = null,
                memberData = null,
                guildList = null,
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = guildList, 
            };

            var user = GetGameProfile();

            var userGuild = DatabaseManager.Guild.RequestGuild(user.guildId);

            if(userGuild != null)
            {
                var memberData = DatabaseManager.Guild.RequestGuildMembers(user.guildId);

                guildList.memberData = memberData;
                guildList.guildInfo = userGuild;

                return response;
            }

            guildList.guildList = DatabaseManager.Guild.GetAllGuilds(GetSession());

            return response;
        }

    }

    public class GuildListRequest
    {

    }
}
