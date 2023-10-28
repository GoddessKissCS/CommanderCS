namespace StellarGK.Packets.Handlers.Commander
{
    public class CompleteCommanderScenario
    {
    }
}

/*	// Token: 0x060060DF RID: 24799 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4310", true, true)]
	public void CompleteCommanderScenario(int cid, int sid, int sqid)
	{
	}

	// Token: 0x060060E0 RID: 24800 RVA: 0x001B0E28 File Offset: 0x001AF028
	private IEnumerator CompleteCommanderScenarioResult(JsonRpcClient.Request request, Protocols.CompleteScenario result)
	{
		if (result != null)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup != null)
			{
				scenarioResultPopup.Init(result.reward, false);
			}
			scenarioResultPopup.onClose = delegate
			{
				this.waitingScenarioComplete = false;
			};
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.RefreshPartFromNetwork(result.partData);
			this.localUser.RefreshItemFromNetwork(result.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.itemData);
			this.localUser.RefreshMedalFromNetwork(result.medalData);
			this.localUser.AddCommanderFromNetwork(result.commander);
			this.localUser.RefreshCostumeFromNetwork(result.costumeData);
			this.localUser.RefreshItemFromNetwork(result.foodData);
			UIManager.instance.RefreshOpenedUI();
			yield break;
		}
		this.waitingScenarioComplete = false;
		yield break;
	}

	// Token: 0x060060E1 RID: 24801 RVA: 0x001B0E4C File Offset: 0x001AF04C
	private IEnumerator CompleteCommanderScenarioError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 30111)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup != null)
			{
				scenarioResultPopup.Init(null, true);
			}
			scenarioResultPopup.onClose = delegate
			{
				this.waitingScenarioComplete = false;
			};
		}
		else
		{
			this.waitingScenarioComplete = false;
		}
		yield break;
	}*/