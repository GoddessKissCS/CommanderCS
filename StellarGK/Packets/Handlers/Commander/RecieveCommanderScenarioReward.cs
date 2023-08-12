using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Commander
{
    public class RecieveCommanderScenarioReward
    {
        
    }
}
/*	// Token: 0x060060E2 RID: 24802 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4311", true, true)]
	public void RecieveCommanderScenarioReward(int cid, int sid)
	{
	}

	// Token: 0x060060E3 RID: 24803 RVA: 0x001B0E70 File Offset: 0x001AF070
	private IEnumerator RecieveCommanderScenarioRewardResult(JsonRpcClient.Request request, Protocols.RecieveScenarioReward result)
	{
		if (result != null)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup != null)
			{
				scenarioResultPopup.Init(result.reward, false);
			}
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
		yield break;
	}*/