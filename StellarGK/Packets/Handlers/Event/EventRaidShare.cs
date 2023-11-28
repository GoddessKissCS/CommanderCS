namespace CommanderCS.Packets.Handlers.Event
{
    public class EventRaidShare
    {
    }
}

/*	// Token: 0x0600611F RID: 24863 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2304", true, true)]
	public void EventRaidShare(int mbid)
	{
	}

	// Token: 0x06006120 RID: 24864 RVA: 0x001B1350 File Offset: 0x001AF550
	private IEnumerator EventRaidShareResult(JsonRpcClient.Request request, string result)
	{
		string text = this._FindRequestProperty(request, "mbid");
		if (result = "true" || result = "True")
		{
			UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
			eventBattle.EventRaidShared(text);
			UISimplePopup.CreateOK(true, "1303", "6609", null, "5775");
		}
		yield break;
	}

	// Token: 0x06006121 RID: 24865 RVA: 0x001B137C File Offset: 0x001AF57C
	private IEnumerator EventRaidShareError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70201 || code = 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6600"));
			if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
			{
				UIManager.instance.world.eventBattle.ClosePopUp();
			}
		}
		else if (code = 70204 || code = 70205)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Format("110367", new object[] { code }), Localization.Get("1001"));
			uisimplePopup.onClose = delegate
			{
				if (UIManager.instance.world.readyBattle.isActive && UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
				{
					UIManager.instance.world.eventBattle.ClosePopUp();
				}
			};
		}
		else if (code = 70207 || code = 70202 || code = 70203)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6606"));
		}
		yield break;
	}*/