using System;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Guild
{
    [Command(Id = CommandId.GuildMemberList)]
    public class GuildMemberList : BaseCommandHandler<GuildMemberListRequest>
    {
        public override object Handle(GuildMemberListRequest @params)
        {
            ResponsePacket response = new()
            {
                id = BasePacket.Id,
            };

            var user = GetGameProfile();

            if(user.guildId == null)
            {
                response.result = null;
                return response;
            }

            GuildMember guild = new()
            {
                memberData = DatabaseManager.Guild.RequestGuildMembers(user.guildId),
                badge = 0, // NO IDEA WHAT THIS SETS
                           // TODO
            };

            return response;
        }
    }
    public class GuildMemberListRequest
    {

    }
}
