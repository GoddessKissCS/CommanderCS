namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    public class InfinityBattleGetReward
    {
    }
}/*	// Token: 0x06006196 RID: 24982 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8704", true, true)]
	public void InfinityBattleGetReward(int ifid, int msid)
	{
	}

	// Token: 0x06006197 RID: 24983 RVA: 0x001B1D6C File Offset: 0x001AFF6C
	private IEnumerator InfinityBattleGetRewardResult(JsonRpcClient.Request request, Protocols.InfinityTowerReward result)
	{
		if (result is not null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			this.localUser.RefreshRewardFromNetwork(result);
			UIManager.instance.world.infinityBattle.UpdateInfinityBattleData(string.Empty, result.fieldData);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006198 RID: 24984 RVA: 0x001B1D90 File Offset: 0x001AFF90
	private IEnumerator InfinityBattleGetRewardError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/