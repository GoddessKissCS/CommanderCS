using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.SetConquestNotice)]
    public class SetConquestNotice : BaseMethodHandler<SetConquestNoticeRequest>
    {
        public override object Handle(SetConquestNoticeRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "True",
            };

            var user = GetUserGameProfile();
            var guild = GetUserGuild();

            if (user is null || guild is null)
            {
                return response;
            }

            // Only guild master (1) or sub-master (2) can set the notice
            int memberGrade = DatabaseManager.Guild.GetMemberGrade(guild.GuildId, user.MemberId);

            if (memberGrade != 0)
            {
                DatabaseManager.Conquest.UpdateNotice(guild.GuildId, request.notice);
            }

            return response;
        }
    }

    public class SetConquestNoticeRequest
    {
        public string notice { get; set; }
    }
}

/*	// Token: 0x06006088 RID: 24712 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7517", true, true)]
	public void SetConquestNotice(string notice)
	{
	}

	// Token: 0x06006089 RID: 24713 RVA: 0x001B0760 File Offset: 0x001AE960
	private IEnumerator SetConquestNoticeResult(JsonRpcClient.Request request, string result, string notice)
	{
		NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110377"));
		yield break;
	}*/
