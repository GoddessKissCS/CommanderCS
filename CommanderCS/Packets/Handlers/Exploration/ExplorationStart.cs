namespace CommanderCS.Packets.Handlers.Exploration
{
    public class ExplorationStart
    {
    }
}

/*	// Token: 0x060060F5 RID: 24821 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3502", true, true)]
	public void ExplorationStart(int idx, List<string> cid)
	{
	}

	// Token: 0x060060F6 RID: 24822 RVA: 0x001B0FD8 File Offset: 0x001AF1D8
	private IEnumerator ExplorationStartResult(JsonRpcClient.Request request, bool result)
	{
		if (result)
		{
			string text = this._FindRequestProperty(request, "idx");
			ExplorationDataRow explorationDataRow = this.regulation.explorationDtbl[text];
			string worldMap = explorationDataRow.worldMap;
			Protocols.ExplorationData explorationData = new Protocols.ExplorationData();
			explorationData.idx = explorationDataRow.idx;
			explorationData.remainTime = (double)(explorationDataRow.searchTime * 3600);
			explorationData.cids = JsonConvert.DeserializeObject<List<string>>(this._FindRequestProperty(request, "cid"));
			this.localUser.explorationDtbl[worldMap].Set(explorationData);
			UIExplorationPopup.UIRefresh(worldMap);
		}
		yield break;
	}*/