namespace StellarGK.Packets.Handlers.Event
{
    public class GetEventBattleGachaInfo
    {
    }
}

/*	// Token: 0x0600613C RID: 24892 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2311", true, true)]
	public void EventBattleGachaOpen(int eidx, int cnt)
	{
	}

	// Token: 0x0600613D RID: 24893 RVA: 0x001B15BC File Offset: 0x001AF7BC
	private IEnumerator EventBattleGachaOpenResult(JsonRpcClient.Request request, Protocols.EventBattleGachaOpen result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
		Protocols.EventBattleGachaInfo infoData = new Protocols.EventBattleGachaInfo();
		infoData.reset = result.reset;
		infoData.season = result.season;
		infoData.info = result.info;
		yield return UIManager.instance.world.eventBattle.OpenGacha(infoData);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600613E RID: 24894 RVA: 0x001B15E0 File Offset: 0x001AF7E0
	private IEnumerator EventBattleGachaOpenError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70210)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("6600"));
			yield break;
		}
		base.StartCoroutine(this.OnJsonRpcRequestError(request, result, code));
		yield break;
	}*/