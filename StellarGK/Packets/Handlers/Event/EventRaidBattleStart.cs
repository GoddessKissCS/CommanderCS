namespace StellarGK.Packets.Handlers.Event
{
    public class EventRaidBattleStart
    {

    }
}
/*	// Token: 0x06006145 RID: 24901 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3742", true, true)]
	public void EventRaidBattleStart(int type, JObject deck, int mbid)
	{
	}

	// Token: 0x06006146 RID: 24902 RVA: 0x001B16AC File Offset: 0x001AF8AC
	private IEnumerator EventRaidBattleStartResult(JsonRpcClient.Request request, string result)
	{
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06006147 RID: 24903 RVA: 0x001B16C8 File Offset: 0x001AF8C8
	private IEnumerator EventRaidBattleStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70201)
		{
			UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("6601"), Localization.Get("1001"));
			uisimplePopup.onClose = delegate
			{
				if (UIManager.instance.world.readyBattle.isActive)
				{
					UIManager.instance.world.readyBattle.CloseAnimation();
				}
			};
		}
		else if (code == 70202 || code == 70203)
		{
			UISimplePopup uisimplePopup2 = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, Localization.Get("6606"), Localization.Get("1001"));
			uisimplePopup2.onClose = delegate
			{
				if (UIManager.instance.world.readyBattle.isActive)
				{
					UIManager.instance.world.readyBattle.CloseAnimation();
					UIManager.instance.world.eventBattle.RefreshEventRaid();
				}
			};
		}
		yield break;
	}*/