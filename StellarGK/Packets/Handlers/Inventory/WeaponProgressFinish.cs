namespace StellarGK.Packets.Handlers.Inventory
{
    public class WeaponProgressFinish
    {

    }
}
/*	// Token: 0x06006169 RID: 24937 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8503", true, true)]
	public void WeaponProgressFinish(int slot)
	{
	}

	// Token: 0x0600616A RID: 24938 RVA: 0x001B199C File Offset: 0x001AFB9C
	private IEnumerator WeaponProgressFinishResult(JsonRpcClient.Request request, string result, Dictionary<string, Protocols.WeaponData> weapon, List<Protocols.RewardInfo.RewardData> reward)
	{
		int num = int.Parse(this._FindRequestProperty(request, "slot"));
		this.localUser.RefreshWeaponFromNetwork(weapon);
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.world.weaponResearch.inProgress.ResetProgress(num);
		yield break;
	}

	// Token: 0x0600616B RID: 24939 RVA: 0x001B19D0 File Offset: 0x001AFBD0
	private IEnumerator WeaponProgressFinishError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/