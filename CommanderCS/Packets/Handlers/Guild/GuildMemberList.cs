using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Guild
{
    [Packet(Id = Method.GuildMemberList)]
    public class GuildMemberList : BaseMethodHandler<GuildMemberListRequest>
    {
        public override object Handle(GuildMemberListRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            if (User.GuildId is null)
            {
                response.Result = null;
                return response;
            }

            var memberData = DatabaseManager.Guild.RequestGuildMembers(User.GuildId);

            GuildMember guild = new()
            {
                memberData = memberData,
                badge = 0,
            };

#warning TODO ADD If there was a New Entry in the guildboard since you last saw it

            response.Result = guild;

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
		if (result is not null)
		{
			UIManager.instance.world.guild.InitAndOpenGuildInfo(result.memberData);
			UISetter.SetActive(UIManager.instance.world.guild.guildBoardBadge, result.badge = 1);
		}
		yield break;
	}*/