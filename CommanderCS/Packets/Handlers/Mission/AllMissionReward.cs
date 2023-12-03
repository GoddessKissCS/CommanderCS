namespace CommanderCS.Packets.Handlers.Mission
{
    public class AllMissionReward
    {
    }
}

/*	// Token: 0x06005FA5 RID: 24485 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6236", true, true)]
	public void AllMissionReward()
	{
	}

	// Token: 0x06005FA6 RID: 24486 RVA: 0x001AF468 File Offset: 0x001AD668
	private IEnumerator AllMissionRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_DailyMission_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		if (result.receiveMissinIdx != null)
		{
			foreach (int num in result.receiveMissinIdx)
			{
				RoMission roMission = this.localUser.FindMission(num.ToString());
				if (roMission != null)
				{
					roMission.received = true;
				}
				this.localUser.badgeMissionCount--;
				this.localUser.missionCompleteCount++;
			}
		}
		UIManager.instance.world.warHome.Set(EReward.DailyMission);
		yield break;
	}

	// Token: 0x06005FA7 RID: 24487 RVA: 0x001AF48C File Offset: 0x001AD68C
	private IEnumerator AllMissionRewardError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 13009)
		{
			UIManager.instance.world.warHome.Close();
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7045"));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/