namespace StellarGK.Packets.Handlers.Cooperate
{
    public class CooperateBattleComplete
    {

    }
}
/*	// Token: 0x0600610B RID: 24843 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7602", true, true)]
	public void CooperateBattleComplete(int stage, int step)
	{
	}

	// Token: 0x0600610C RID: 24844 RVA: 0x001B11B4 File Offset: 0x001AF3B4
	private IEnumerator CooperateBattleCompleteResult(JsonRpcClient.Request request, Protocols.CooperateBattleRewardInfo result)
	{
		UIGetItem uigetItem = UIPopup.Create<UIGetItem>("GetItem");
		uigetItem.Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		UICooperateBattle cooperateBattle = UIManager.instance.world.cooperateBattle;
		if (cooperateBattle.isActive)
		{
			Protocols.CooperateBattleData cooperateBattleData = new Protocols.CooperateBattleData();
			cooperateBattleData.coop = result.coop;
			cooperateBattleData.recv = result.recv;
			int prevStage = this.localUser.coopStage;
			cooperateBattle.Set(cooperateBattleData);
			uigetItem.onClose = delegate
			{
				if (UIManager.instance.world.cooperateBattle.isActive && prevStage > 0 && this.localUser.coopStage > prevStage)
				{
					UIManager.instance.world.cooperateBattle.LevelUp();
				}
			};
		}
		yield break;
	}

	// Token: 0x0600610D RID: 24845 RVA: 0x001B11D8 File Offset: 0x001AF3D8
	private IEnumerator CooperateBattleCompleteError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			if (UIManager.instance.world.guild.isActive)
			{
				UIManager.instance.world.guild.Close();
			}
		}
		else if (code == 71603)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5090029"));
		}
		yield break;
	}*/