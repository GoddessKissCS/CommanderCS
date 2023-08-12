namespace StellarGK.Packets.Handlers.Commander
{
    public class DecompositionWeapon
    {

    }
}
/*	// Token: 0x06006178 RID: 24952 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8509", true, true)]
	public void DecompositionWeapon(List<int> wnos)
	{
	}

	// Token: 0x06006179 RID: 24953 RVA: 0x001B1AF4 File Offset: 0x001AFCF4
	private IEnumerator DecompositionWeaponResult(JsonRpcClient.Request request, string result, Dictionary<string, int> part, List<Protocols.RewardInfo.RewardData> reward, List<string> wnos)
	{
		this.localUser.RefreshPartFromNetwork(part);
		this.localUser.RemoveWeapon(wnos);
		UIManager.instance.world.weaponResearch.weaponList.ResetDecompositionList();
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600617A RID: 24954 RVA: 0x001B1B28 File Offset: 0x001AFD28
	private IEnumerator DecompositionWeaponError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/