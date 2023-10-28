namespace StellarGK.Packets.Handlers.Commander
{
    public class UpgradeWeapon
    {
    }
}

/*	// Token: 0x0600617B RID: 24955 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8508", true, true)]
	public void UpgradeWeapon(int wno)
	{
	}

	// Token: 0x0600617C RID: 24956 RVA: 0x001B1B3C File Offset: 0x001AFD3C
	private IEnumerator UpgradeWeaponResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Dictionary<string, int> part, Dictionary<string, Protocols.WeaponData> weapon)
	{
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		this.localUser.RefreshPartFromNetwork(part);
		this.localUser.RefreshWeaponFromNetwork(weapon);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600617D RID: 24957 RVA: 0x001B1B70 File Offset: 0x001AFD70
	private IEnumerator UpgradeWeaponError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/