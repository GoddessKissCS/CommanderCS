namespace CommanderCS.Packets.Handlers.Duel
{
    public class ReceiveDuelPointReward
    {
    }
}

/*	// Token: 0x06005FF5 RID: 24565 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3230", true, true)]
	public void ReceiveDuelPointReward(int didx)
	{
	}

	// Token: 0x06005FF6 RID: 24566 RVA: 0x001AFA90 File Offset: 0x001ADC90
	private IEnumerator ReceiveDuelPointRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.rewardDuelPoint = result.duelScoreData["didx"];
		this.localUser.badgeChallenge = this.localUser.duelPoint >= this.localUser.rewardDuelPoint && this.localUser.rewardDuelPoint != 0;
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/