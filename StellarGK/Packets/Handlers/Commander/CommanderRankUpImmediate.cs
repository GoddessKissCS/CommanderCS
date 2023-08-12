namespace StellarGK.Packets.Handlers.Commander
{
    public class CommanderRankUpImmediate
    {
    }
}


/*
  public void CommanderRankUpImmediate(int cid)
	{
	}

	// Token: 0x06005F30 RID: 24368 RVA: 0x001AE924 File Offset: 0x001ACB24
	private IEnumerator CommanderRankUpImmediateResult(JsonRpcClient.Request request, string result, int cash, int medl, Protocols.SimpleCommanderInfo comm)
	{
		string text = this._FindRequestProperty(request, "cid");
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			RoCommander roCommander2 = roCommander;
			roCommander2.rank++;
			roCommander.rankUpTime.SetInvalidValue();
		}
		this.localUser.cash = cash;
		this.localUser.medal = medl;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F31 RID: 24369 RVA: 0x001AE958 File Offset: 0x001ACB58
	private IEnumerator CommanderRankUpImmediateError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}
*/