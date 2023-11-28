namespace CommanderCS.Packets.Handlers.Event
{
    public class EventRaidList
    {
    }
}

/*	// Token: 0x06006122 RID: 24866 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2305", true, true)]
	public void EventRaidList(int type)
	{
	}

	// Token: 0x06006123 RID: 24867 RVA: 0x001B1398 File Offset: 0x001AF598
	private IEnumerator EventRaidListResult(JsonRpcClient.Request request, Protocols.EventRaidList result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "type"));
		UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
		eventBattle.CreateEventRaidPopup(num, result.rewardCount, result.bossList);
		yield break;
	}

	// Token: 0x06006124 RID: 24868 RVA: 0x001B13C4 File Offset: 0x001AF5C4
	private IEnumerator EventRaidListError(JsonRpcClient.Request request, string result, int code)
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
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), string.Empty, Localization.Get("1001"));
			uisimplePopup.onClose = delegate
			{
				if (UIManager.instance.world.readyBattle.isActive && UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
				{
					UIManager.instance.world.eventBattle.ClosePopUp();
				}
			};
		}
		yield break;
	}*/