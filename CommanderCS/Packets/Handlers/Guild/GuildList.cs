using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.GuildList)]
    public class GuildList : BaseMethodHandler<GuildListRequest>
    {
        public override object Handle(GuildListRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            CommanderCS.Library.Protocols.GuildInfo guildList = new()
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

            var userGuild = DatabaseManager.Guild.RequestGuild(User.GuildId, User.Uno);

            if (userGuild is not null)
            {
                var memberData = DatabaseManager.Guild.RequestGuildMembers(User.GuildId);

                guildList.memberData = memberData;
                guildList.guildInfo = userGuild;

                return response;
            }

            guildList.guildList = DatabaseManager.Guild.GetAllGuilds(SessionId);

            return response;
        }
    }

    public class GuildListRequest
    {
    }
}