namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestNotice
    {
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
		if (num == 1 && string.IsNullOrEmpty(notice))
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