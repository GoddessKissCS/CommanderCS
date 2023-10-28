namespace StellarGK.Packets.Handlers.Dormitory
{
    public class BuyDormitoryShopProduct
    {
    }
}

/*	// Token: 0x060061AF RID: 25007 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8611", true, true)]
	public void BuyDormitoryShopProduct(EDormitoryItemType styp, string sidx)
	{
	}

	// Token: 0x060061B0 RID: 25008 RVA: 0x001B1F04 File Offset: 0x001B0104
	private IEnumerator BuyDormitoryShopProductResult(JsonRpcClient.Request request, Protocols.Dormitory.BuyShopProductResponse result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		this.localUser.RefreshRewardFromNetwork(result);
		Message.Send("Update.Goods");
		Message.Send("Inven.Update");
		Message.Send<Protocols.Dormitory.BuyShopProductResponse>("Shop.Update", result);
		yield break;
	}

	// Token: 0x060061B1 RID: 25009 RVA: 0x001B1F28 File Offset: 0x001B0128
	private IEnumerator BuyDormitoryShopProductError(JsonRpcClient.Request request, string result, int code)
	{
		switch (code)
		{
		case 85120:
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81044"));
			break;

		case 85121:
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81061"));
			break;

		case 85123:
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81042"));
			break;

		case 85124:
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81043"));
			break;
		}
		yield break;
	}*/