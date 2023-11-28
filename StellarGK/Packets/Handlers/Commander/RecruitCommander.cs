namespace CommanderCS.Packets.Handlers.Commander
{
    public class RecruitCommander
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5211", true, true)]
	public void RecruitCommander(int cid)
	{
	}

	// Token: 0x06005F39 RID: 24377 RVA: 0x001AE9F0 File Offset: 0x001ACBF0
	private IEnumerator RecruitCommanderResult(JsonRpcClient.Request request, Protocols.RecruitCommanderResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		if (string.IsNullOrEmpty(text))
		{
			yield break;
		}
		RoRecruit.Entry entry = this.localUser.recruit.Find(text);
		if (entry != null)
		{
			entry.recruited = true;
			RoCommander roCommander = this.localUser.FindCommander(text);
			CommanderCompleteType commanderCompleteType;
			if (roCommander.state = ECommanderState.Nomal)
			{
				commanderCompleteType = CommanderCompleteType.Transmission;
			}
			else
			{
				commanderCompleteType = CommanderCompleteType.Recruit;
			}
			roCommander.state = ECommanderState.Nomal;
			roCommander.aMedal = result.commander.medal;
			UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
			uicommanderComplete.Init(commanderCompleteType, roCommander.id);
			this.localUser.gold = (int)Math.Min(result.gold, 2147483647L);
			this.localUser.honor = result.honor;
			UIManager.instance.RefreshOpenedUI();
			yield break;
		}
		yield break;
	}

	// Token: 0x06005F3A RID: 24378 RVA: 0x001AEA1C File Offset: 0x001ACC1C
	private IEnumerator RecruitCommanderError(JsonRpcClient.Request request, string result, int code, string message)
	{
		if (code = 20001)
		{
			UISimplePopup.CreateDebugOK("자원부족", result, "확인");
		}
		else if (code = 30004)
		{
		}
		yield break;
	}*/