namespace CommanderCS.Packets.Handlers.Inventory
{
    public class WeaponProgressUseImmediateTicket
    {
    }
}

/*	// Token: 0x0600616F RID: 24943 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8505", true, true)]
	public void WeaponProgressUseImmediateTicket(int slot)
	{
	}

	// Token: 0x06006170 RID: 24944 RVA: 0x001B1A34 File Offset: 0x001AFC34
	private IEnumerator WeaponProgressUseImmediateTicketResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Dictionary<string, Protocols.WeaponData> weapon, List<Protocols.RewardInfo.RewardData> reward)
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

	// Token: 0x06006171 RID: 24945 RVA: 0x001B1A70 File Offset: 0x001AFC70
	private IEnumerator WeaponProgressUseImmediateTicketError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/