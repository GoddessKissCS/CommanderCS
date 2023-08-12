namespace StellarGK.Packets.Handlers.Commander
{
    public class TradeWeaponUpgradeTicket
    {

    }
}
/*	// Token: 0x06006184 RID: 24964 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8514", true, true)]
	public void TradeWeaponUpgradeTicket(int tidx, int amnt)
	{
	}

	// Token: 0x06006185 RID: 24965 RVA: 0x001B1C04 File Offset: 0x001AFE04
	private IEnumerator TradeWeaponUpgradeTicketResult(JsonRpcClient.Request request, string result, Dictionary<string, int> part, List<Protocols.RewardInfo.RewardData> reward)
	{
		this.localUser.RefreshPartFromNetwork(part);
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006186 RID: 24966 RVA: 0x001B1C30 File Offset: 0x001AFE30
	private IEnumerator TradeWeaponUpgradeTicketError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/