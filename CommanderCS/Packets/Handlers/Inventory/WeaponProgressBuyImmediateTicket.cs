namespace CommanderCS.Packets.Handlers.Inventory
{
    public class WeaponProgressBuyImmediateTicket
    {
    }
}

/*	// Token: 0x0600616C RID: 24940 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8504", true, true)]
	public void WeaponProgressBuyImmediateTicket(int slot)
	{
	}

	// Token: 0x0600616D RID: 24941 RVA: 0x001B19E4 File Offset: 0x001AFBE4
	private IEnumerator WeaponProgressBuyImmediateTicketResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Dictionary<string, Protocols.WeaponData> weapon, List<Protocols.RewardInfo.RewardData> reward)
	{
		int num = int.Parse(this._FindRequestProperty(request, "slot"));
		this.localUser.RefreshWeaponFromNetwork(weapon);
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.world.weaponResearch.inProgress.ResetProgress(num);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600616E RID: 24942 RVA: 0x001B1A20 File Offset: 0x001AFC20
	private IEnumerator WeaponProgressBuyImmediateTicketError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/