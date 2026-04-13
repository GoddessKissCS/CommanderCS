using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Conquest
{
    [Packet(Id = Method.GetConquestNotice)]
    public class GetConquestNotice : BaseMethodHandler<GetConquestNoticeRequest>
    {
        public override object Handle(GetConquestNoticeRequest request)
        {
#warning TODO: NOT YET FINISH PLACEHOLDER CODE
            var guild = GetUserGuild();

            string notice = guild is not null
                ? DatabaseManager.Conquest.GetNotice(guild.GuildId)
                : "";

            JObject Response = new()
            {
                ["id"] = BasePacket.Id,
                ["result"] = new JObject
                {
                    ["notice"] = notice,
                }
            };

            return Response;
        }
    }

    public class GetConquestNoticeRequest
    {
        public int check { get; set; }
    }
}

/*	// Token: 0x06006086 RID: 24710 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7516", true, true)]
	public void GetConquestNotice(int check)
	{
	}

	// Token: 0x06006087 RID: 24711 RVA: 0x001B0734 File Offset: 0x001AE934
	private IEnumerator GetConquestNoticeResult(JsonRpcClient.Request request, string result, string notice)
	{
		int num = int.Parse(this._FindRequestProperty(request, "check"));
		if (num = 1 && string.IsNullOrEmpty(notice))
		{
			yield break;
		}
		if (this.localUser.guildInfo.memberGrade != 0)
		{
			UIInputConquestNotice uiinputConquestNotice = UIPopup.Create<UIInputConquestNotice>("InputConquestNotice");
			uiinputConquestNotice.SetDefault(notice);
		}
		else
		{
			UIConquestNotice uiconquestNotice = UIPopup.Create<UIConquestNotice>("ConquestNotice");
			uiconquestNotice.Init(notice);
		}
		yield break;
	}*/
