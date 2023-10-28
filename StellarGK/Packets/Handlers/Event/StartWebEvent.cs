namespace StellarGK.Packets.Handlers.Event
{
    public class StartWebEvent
    {
    }
}

/*	// Token: 0x06006113 RID: 24851 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8119", true, true)]
	public void StartWebEvent(int ch)
	{
	}

	// Token: 0x06006114 RID: 24852 RVA: 0x001B1250 File Offset: 0x001AF450
	private IEnumerator StartWebEventResult(JsonRpcClient.Request request, string result, List<string> wev)
	{
		this.localUser.webEventUrls = wev;
		this.localUser.badgeWebEvent = false;
		if (this.localUser.webEventUrls.Count > 0)
		{
			UIPopup.Create<UIWebviewPopup>("UIWebView").Init(RemoteObjectManager.Base64Decode(this.localUser.webEventUrls[0]));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("1999"));
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/