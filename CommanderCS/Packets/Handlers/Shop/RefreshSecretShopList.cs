namespace CommanderCS.Packets.Handlers.Shop
{
    public class RefreshSecretShopList
    {
    }
}

/*	// Token: 0x06006005 RID: 24581 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8202", true, true)]
	public void RefreshSecretShopList(int styp)
	{
	}

	// Token: 0x06006006 RID: 24582 RVA: 0x001AFC30 File Offset: 0x001ADE30
	private IEnumerator RefreshSecretShopListResult(JsonRpcClient.Request request, Protocols.SecretShop result)
	{
		if (result is not null && result.shopList.Count != 0)
		{
			this.localUser.shopList = result.shopList;
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.shopRefreshCount = result.refreshCount;
			this.localUser.shopRefreshFree = result.reset = 0;
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/