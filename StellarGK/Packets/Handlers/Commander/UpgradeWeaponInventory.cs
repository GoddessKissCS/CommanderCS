namespace StellarGK.Packets.Handlers.Commander
{
    public class UpgradeWeaponInventory
    {
    }
}

/*	// Token: 0x0600617E RID: 24958 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8513", true, true)]
	public void UpgradeWeaponInventory()
	{
	}

	// Token: 0x0600617F RID: 24959 RVA: 0x001B1B84 File Offset: 0x001AFD84
	private IEnumerator UpgradeWeaponInventoryResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.BattleStatistics uifo, Protocols.UserInformationResponse.Resource rsoc)
	{
		this.localUser.statistics.weaponInventoryCount = uifo.weaponInventoryCount;
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006180 RID: 24960 RVA: 0x001B1BB0 File Offset: 0x001AFDB0
	private IEnumerator UpgradeWeaponInventoryError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/