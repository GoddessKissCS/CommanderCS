namespace CommanderCS.Packets.Handlers.PvP
{
    public class PvPDuelInfo
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3221", true, true)]
	public void PvPDuelInfo(int idx)
	{
	}

	// Token: 0x06005F88 RID: 24456 RVA: 0x001AF1FC File Offset: 0x001AD3FC
	private IEnumerator PvPDuelInfoResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Commander target)
	{
		string text = this._FindRequestProperty(request, "idx");
		RoUser roUser = this.localUser.duelTargetList[int.Parse(text)];
		if (target is not null)
		{
			roUser.UpdateUserTroop(target);
		}
		BattleData battleData = UIManager.instance.world.rankingBattle.battleData;
		battleData.defender = roUser;
		UIManager.instance.world.readyBattle.InitAndOpenReadyBattle(battleData);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/