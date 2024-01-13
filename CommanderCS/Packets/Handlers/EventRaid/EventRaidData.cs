namespace CommanderCS.Packets.Handlers.Event
{
    public class EventRaidData
    {
    }
}

/*	// Token: 0x06006125 RID: 24869 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2306", true, true)]
	public void EventRaidData(int mbid)
	{
	}

	// Token: 0x06006126 RID: 24870 RVA: 0x001B13E0 File Offset: 0x001AF5E0
	private IEnumerator EventRaidDataResult(JsonRpcClient.Request request, string result, Protocols.EventRaidData bInfo)
	{
		string text = this._FindRequestProperty(request, "mbid");
		UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
		eventBattle.UpdateEventRaid(text, bInfo);
		eventBattle.StartRaidReadyBattle(text);
		yield break;
	}

	// Token: 0x06006127 RID: 24871 RVA: 0x001B140C File Offset: 0x001AF60C
	private IEnumerator EventRaidDataError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 70201 || code = 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6600"));
			if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
			{
				UIManager.instance.world.eventBattle.CloseEventRaid();
			}
		}
		else if (code = 70204 || code = 70205)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), string.Empty, Localization.Get("1001"));
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
			UISimplePopup uisimplePopup2 = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("6606"), Localization.Get("1001"));
			uisimplePopup2.onClose = delegate
			{
				if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
				{
					UIManager.instance.world.eventBattle.RefreshEventRaid();
				}
			};
		}
		yield break;
	}*/