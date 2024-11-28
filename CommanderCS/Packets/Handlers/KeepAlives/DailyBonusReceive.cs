namespace CommanderCS.Packets.Handlers.KeepAlives
{
    public class DailyBonusReceive
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6213", true, true)]
	public void DailyBonusReceive()
	{
	}

	// Token: 0x06005F5D RID: 24413 RVA: 0x001AEE94 File Offset: 0x001AD094
	private IEnumerator DailyBonusReceiveResult(JsonRpcClient.Request request, Protocols.RewardInfo reward)
	{
		if (reward.commander is not null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in reward.commander)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(value.id);
				CommanderCompleteType commanderCompleteType = ((roCommander.state != ECommanderState.Nomal) ? CommanderCompleteType.Recruit : CommanderCompleteType.Transmission);
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(commanderCompleteType, value.id);
			}
		}
		else
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(reward.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		this.localUser.RefreshRewardFromNetwork(reward);
		this.localUser.dailyBonus.isReceived = true;
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("DailyBonusReceive");
		yield break;
	}*/