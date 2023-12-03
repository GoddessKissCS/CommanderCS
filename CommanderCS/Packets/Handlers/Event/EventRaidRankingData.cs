namespace CommanderCS.Packets.Handlers.Event
{
    public class EventRaidRankingData
    {
    }
}

/*	// Token: 0x06006128 RID: 24872 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2307", true, true)]
	public void EventRaidRankingData(int mbid)
	{
	}

	// Token: 0x06006129 RID: 24873 RVA: 0x001B1428 File Offset: 0x001AF628
	private IEnumerator EventRaidRankingDataResult(JsonRpcClient.Request request, List<Protocols.EventRaidRankingData> result)
	{
		string text = this._FindRequestProperty(request, "mbid");
		UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
		eventBattle.CreateRaidRankingPopup(result);
		yield break;
	}

	// Token: 0x0600612A RID: 24874 RVA: 0x001B1454 File Offset: 0x001AF654
	private IEnumerator EventRaidRankingError(JsonRpcClient.Request request, string result, int code)
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
				if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
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