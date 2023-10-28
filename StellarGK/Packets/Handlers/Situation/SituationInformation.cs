namespace StellarGK.Packets.Handlers.Situation
{
    public class SituationInformation
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3202", true, true)]
	public void SituationInformation()
	{
	}

	// Token: 0x06005F7C RID: 24444 RVA: 0x001AF0E4 File Offset: 0x001AD2E4
	private IEnumerator SituationInformationResult(JsonRpcClient.Request request, string result, int did, int rtm)
	{
		if (UIManager.instance.world != null)
		{
			if (!UIManager.instance.world.existSituation || !UIManager.instance.world.situation.isActive)
			{
				UIManager.instance.world.situation.InitAndOpenSituation();
			}
			UIManager.instance.world.situation.SetSweepEnable(did, rtm);
		}
		if (UIManager.instance.battle != null)
		{
			UIBattleResult battleResult = UIManager.instance.battle.BattleResult;
			battleResult.Open();
		}
		yield break;
	}*/