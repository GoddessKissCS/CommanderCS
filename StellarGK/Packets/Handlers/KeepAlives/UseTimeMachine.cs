namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class UseTimeMachine
    {
    }
}

/*	// Token: 0x06005FF9 RID: 24569 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "2208", true, true)]
	public void UseTimeMachine(int mid, int cnt, int cash)
	{
	}

	// Token: 0x06005FFA RID: 24570 RVA: 0x001AFAC8 File Offset: 0x001ADCC8
	private IEnumerator UseTimeMachineResult(JsonRpcClient.Request request, Protocols.PlunderTimeMachine result)
	{
		string text = this._FindRequestProperty(request, "mid");
		string text2 = this._FindRequestProperty(request, "cnt");
		RoWorldMap.Stage stage = this.localUser.FindWorldMapStage(text);
		stage.clearCount = int.Parse(text2);
		this.localUser.useBullet = true;
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		if (!this.localUser.statistics.isBuyVipShop && result.VipShopOpen = 1)
		{
			this.localUser.statistics.vipShopResetTime_Data.SetByDuration((double)result.VipShopRemainTime);
			this.localUser.statistics.vipShop = result.VipShopOpen;
			this.localUser.statistics.vipShopisFloating = true;
			this.ScheduleLocalPush(ELocalPushType.LeaveVipShop, result.VipShopRemainTime);
		}
		UIPopup.Create<UITimeMachinePopup>("TimeMachinePopup").Init(result.reward, ETimeMachineType.Stage);
		yield break;
	}*/