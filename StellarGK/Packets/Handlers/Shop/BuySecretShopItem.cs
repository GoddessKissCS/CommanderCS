namespace StellarGK.Packets.Handlers.Shop
{
    public class BuySecretShopItem
    {

    }
}
/*	// Token: 0x06006015 RID: 24597 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8201", true, true)]
	public void BuySecretShopItem(int styp, int id)
	{
	}

	// Token: 0x06006016 RID: 24598 RVA: 0x001AFD94 File Offset: 0x001ADF94
	private IEnumerator BuySecretShopItemResult(JsonRpcClient.Request request, Protocols.ShopReward result)
	{
		if (result != null)
		{
			List<Protocols.RewardInfo.RewardData> list = new List<Protocols.RewardInfo.RewardData>();
			for (int i = 0; i < this.localUser.shopList.Count; i++)
			{
				Protocols.SecretShop.ShopData shopData = this.localUser.shopList[i];
				if (shopData.id == result.shop.id)
				{
					shopData.sold = result.shop.sold;
				}
			}
			list.Add(new Protocols.RewardInfo.RewardData
			{
				rewardType = result.shop.type,
				rewardId = result.shop.idx.ToString(),
				rewardCnt = result.shop.count
			});
			UIPopup.Create<UIGetItem>("GetItem").Set(list, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			this.localUser.RefreshItemFromNetwork(result.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.itemData);
			this.localUser.RefreshGoodsFromNetwork(result.rsoc);
			this.localUser.RefreshPartFromNetwork(result.partData);
			this.localUser.RefreshMedalFromNetwork(result.medalData);
			this.localUser.AddCommanderFromNetwork(result.commanderData);
			this.localUser.RefreshItemFromNetwork(result.foodData);
			this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
			this.localUser.RefreshItemFromNetwork(result.groupItemData);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/