namespace StellarGK.Packets.Handlers.Gift
{
    public class GiftFood
    {
    }
}

/*	// Token: 0x0600608C RID: 24716 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4307", true, true)]
	public void GiftFood(int cid, int cgid, int amnt)
	{
	}

	// Token: 0x0600608D RID: 24717 RVA: 0x001B0798 File Offset: 0x001AE998
	private IEnumerator GiftFoodResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result.commanderInfo != null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderInfo)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				roCommander.favorStep = keyValuePair.Value.favorStep;
				roCommander.favorPoint = keyValuePair.Value.favorPoint;
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		UIManager.instance.RefreshOpenedUI();
		this.localUser.sendingGift = false;
		yield break;
	}*/