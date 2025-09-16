namespace CommanderCS.Packets.Handlers.Exploration
{
    public class ExplorationComplete
    {
    }
}

/*	// Token: 0x060060FB RID: 24827 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3504", true, true)]
	public void ExplorationComplete(int idx)
	{
	}

	// Token: 0x060060FC RID: 24828 RVA: 0x001B105C File Offset: 0x001AF25C
	private IEnumerator ExplorationCompleteResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "idx");
		ExplorationDataRow explorationDataRow = this.RemoteObjectManager.instance.regulation.explorationDtbl[text];
		string worldMap = explorationDataRow.worldMap;
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		int num = this.RemoteObjectManager.instance.regulation.commanderLevelDtbl[(this.localUser.level + 1).ToString()].aexp - 1;
		RoExploration roExploration = this.localUser.explorationDtbl[worldMap];
		for (int i = 0; i < roExploration.commanders.Count; i++)
		{
			int num2 = roExploration.commanders[i].aExp + result.exp;
			if (num2 > num)
			{
				num2 = num;
			}
			roExploration.commanders[i].aExp = num2;
		}
		roExploration.Set(null);
		UIExplorationPopup.UIRefresh(worldMap);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/