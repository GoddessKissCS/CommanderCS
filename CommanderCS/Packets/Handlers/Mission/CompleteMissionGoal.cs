namespace CommanderCS.Packets.Handlers.Mission
{
    public class CompleteMissionGoal
    {
    }
}

/*	// Token: 0x06005FAF RID: 24495 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6234", true, true)]
	public void CompleteMissionGoal(int type, int idx)
	{
	}

	// Token: 0x06005FB0 RID: 24496 RVA: 0x001AF538 File Offset: 0x001AD738
	private IEnumerator CompleteMissionGoalResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "type");
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_DailyMissionReward_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		if (text = "1")
		{
			this.localUser.missionGoal++;
			UIManager.instance.world.warHome.SetInfo(EReward.DailyMission);
		}
		else if (text = "2")
		{
			this.localUser.achievementGoal++;
			UIManager.instance.world.warHome.SetInfo(EReward.Achievement);
		}
		this._CheckReceiveTestData("CompleteGoalResult");
		yield break;
	}*/