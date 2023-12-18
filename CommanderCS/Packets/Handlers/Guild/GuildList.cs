using CommanderCS.Database;
using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Guild
{
    [Packet(Id = Method.GuildList)]
    public class GuildList : BaseMethodHandler<GuildListRequest>
    {
        public override object Handle(GuildListRequest @params)
        {
            CommanderCSLibrary.Shared.Protocols.GuildInfo guildList = new()
            {
                resource = null,
                guildInfo = null,
                memberData = null,
                guildList = null,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = guildList,
            };

            var user = GetUserGameProfile();

            var userGuild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            if (userGuild != null)
            {
                var memberData = DatabaseManager.Guild.RequestGuildMembers(user.GuildId);

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