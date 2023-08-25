using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Guild
{
    [Packet(MethodId.GuildMemberList)]
    public class GuildMemberList : BaseMethodHandler<GuildMemberListRequest>
    {
        public override object Handle(GuildMemberListRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            var user = GetUserGameProfile();

            if (user.GuildId == null)
            {
                response.Result = null;
                return response;
            }

            GuildMember guild = new()
            {
                memberData = DatabaseManager.Guild.RequestGuildMembers(user.GuildId),
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