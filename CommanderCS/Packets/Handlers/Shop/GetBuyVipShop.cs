using CommanderCSLibrary.Shared.Enum;

namespace CommanderCS.Host.Handlers.Shop
{
    [Packet(Id = Method.GetBuyVipShop)]
    public class GetBuyVipShop : BaseMethodHandler<GetBuyVipShopRequest>
    {
        public override object Handle(GetBuyVipShopRequest @params)
        {
            return "{}";
        }
    }

    public class GetBuyVipShopRequest
    {
    }
}

/*	// Token: 0x060060AF RID: 24751 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8203", true, true)]
	public void GetBuyVipShop()
	{
	}

	// Token: 0x060060B0 RID: 24752 RVA: 0x001B0A58 File Offset: 0x001AEC58
	private IEnumerator GetBuyVipShopResult(JsonRpcClient.Request request, Protocols.BuyVipShop result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.FromNetwork(result.userInfo);
		if (result.userInfo.vipShop = 1 && result.userInfo.vipShopResetTime = 0)
		{
			this.localUser.statistics.isBuyVipShop = true;
		}
		this.CancelLocalPush(ELocalPushType.LeaveVipShop);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/