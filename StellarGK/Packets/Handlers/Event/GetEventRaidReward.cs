namespace StellarGK.Packets.Handlers.Event
{
    public class GetEventRaidReward
    {
    }
}

/*	// Token: 0x0600612B RID: 24875 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2308", true, true)]
	public void GetEventRaidReward(int mbid)
	{
	}

	// Token: 0x0600612C RID: 24876 RVA: 0x001B1470 File Offset: 0x001AF670
	private IEnumerator GetEventRaidRewardResult(JsonRpcClient.Request request, Protocols.EventRaidReward result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "mbid"));
		UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, result.rewardCount);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIEventBattle eventBattle = UIManager.instance.world.eventBattle;
		if (num > 0)
		{
			eventBattle.EventRaidRewardReceive(result.rewardCount.mbids);
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600612D RID: 24877 RVA: 0x001B149C File Offset: 0x001AF69C
	private IEnumerator GetEventRaidRewardError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70201 || code == 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6600"));
			if (UIManager.instance.world.existEventBattle && UIManager.instance.world.eventBattle.isActive)
			{
				UIManager.instance.world.eventBattle.CloseEventRaid();
			}
		}
		else if (code == 70204 || code == 70205 || code == 70208 || code == 70209)
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
		else if (code == 70211)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6610"));
		}
		yield break;
	}*/