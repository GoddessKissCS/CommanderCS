using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.ManageGuildJoinMember)]
    public class ManageGuildJoinMember : BaseMethodHandler<ManageGuildJoinMemberRequest>
    {
        public override object Handle(ManageGuildJoinMemberRequest @params)
        {
            var application = DatabaseManager.GuildApplication.GetGuildApplications(User.GuildId);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = application,
            };

            return response;
        }
    }

    public class ManageGuildJoinMemberRequest
    {
    }
}

/*	// Token: 0x06006036 RID: 24630 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7254", true, true)]
	public void ManageGuildJoinMember()
	{
	}

	// Token: 0x06006037 RID: 24631 RVA: 0x001B0030 File Offset: 0x001AE230
	private IEnumerator ManageGuildJoinMemberResult(JsonRpcClient.Request request, List<Protocols.GuildMember.MemberData> result)
	{
		UIPopup.Create<UIGuildMemberJoinPopUp>("GuildMemberJoinPopUp").InitAndOpenMemberList(result);
		yield break;
	}*/