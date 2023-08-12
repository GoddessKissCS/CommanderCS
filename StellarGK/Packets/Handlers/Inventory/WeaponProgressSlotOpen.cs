namespace StellarGK.Packets.Handlers.Inventory
{
    public class WeaponProgressSlotOpen
    {

    }
}
/*	// Token: 0x06006166 RID: 24934 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8502", true, true)]
	public void WeaponProgressSlotOpen()
	{
	}

	// Token: 0x06006167 RID: 24935 RVA: 0x001B195C File Offset: 0x001AFB5C
	private IEnumerator WeaponProgressSlotOpenResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.BattleStatistics uifo, Protocols.UserInformationResponse.Resource rsoc)
	{
		this.localUser.statistics.weaponMakeSlotCount = uifo.weaponMakeSlotCount;
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006168 RID: 24936 RVA: 0x001B1988 File Offset: 0x001AFB88
	private IEnumerator WeaponProgressSlotOpenError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/