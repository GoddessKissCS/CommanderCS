namespace CommanderCS.Packets.Handlers.Exploration
{
    public class ExplorationCancel
    {
    }
}

/*	// Token: 0x060060F9 RID: 24825 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3503", true, true)]
	public void ExplorationCancel(int idx)
	{
	}

	// Token: 0x060060FA RID: 24826 RVA: 0x001B1030 File Offset: 0x001AF230
	private IEnumerator ExplorationCancelResult(JsonRpcClient.Request request, bool result)
	{
		if (result)
		{
			string text = this._FindRequestProperty(request, "idx");
			ExplorationDataRow explorationDataRow = this.regulation.explorationDtbl[text];
			string worldMap = explorationDataRow.worldMap;
			this.localUser.explorationDtbl[worldMap].Set(null);
			UIExplorationPopup.UIRefresh(worldMap);
		}
		yield break;
	}*/