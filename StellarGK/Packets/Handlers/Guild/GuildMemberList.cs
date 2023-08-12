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

/*	// Token: 0x0600602D RID: 24621 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7219", true, true)]
	public void GuildMemberList()
	{
	}

	// Token: 0x0600602E RID: 24622 RVA: 0x001AFF84 File Offset: 0x001AE184
	private IEnumerator GuildMemberListResult(JsonRpcClient.Request request, Protocols.GuildMember result)
	{
		if (!this.localUser.IsExistGuild())
		{
			yield break;
		}
		if (result != null)
		{
			UIManager.instance.world.guild.InitAndOpenGuildInfo(result.memberData);
			UISetter.SetActive(UIManager.instance.world.guild.guildBoardBadge, result.badge == 1);
		}
		yield break;
	}*/