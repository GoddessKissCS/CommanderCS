namespace CommanderCS.Packets.Handlers.Exploration
{
    public class ExplorationStartAll
    {
    }
}

/*	// Token: 0x060060F7 RID: 24823 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3550", true, true)]
	public void ExplorationStartAll(JArray search)
	{
	}

	// Token: 0x060060F8 RID: 24824 RVA: 0x001B1004 File Offset: 0x001AF204
	private IEnumerator ExplorationStartAllResult(JsonRpcClient.Request request, bool result)
	{
		if (result)
		{
			string text = this._FindRequestProperty(request, "search");
			List<Protocols.ExplorationStartInfo> list = JsonConvert.DeserializeObject<List<Protocols.ExplorationStartInfo>>(text);
			if (list is not null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					ExplorationDataRow explorationDataRow = this.regulation.explorationDtbl[list[i].idx.ToString()];
					string worldMap = explorationDataRow.worldMap;
					Protocols.ExplorationData explorationData = new Protocols.ExplorationData();
					explorationData.idx = explorationDataRow.idx;
					explorationData.remainTime = (double)(explorationDataRow.searchTime * 3600);
					explorationData.cids = list[i].cids;
					this.localUser.explorationDtbl[worldMap].Set(explorationData);
					UIExplorationPopup.UIRefresh(worldMap);
				}
			}
		}
		yield break;
	}*/