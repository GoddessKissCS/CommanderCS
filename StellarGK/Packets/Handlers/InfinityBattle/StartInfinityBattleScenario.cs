using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.InfinityBattle
{
    public class StartInfinityBattleScenario
    {
        
    }
}
/*	// Token: 0x06006193 RID: 24979 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8703", true, true)]
	public void StartInfinityBattleScenario(int ifid)
	{
	}

	// Token: 0x06006194 RID: 24980 RVA: 0x001B1D2C File Offset: 0x001AFF2C
	private IEnumerator StartInfinityBattleScenarioResult(JsonRpcClient.Request request, string result)
	{
		if (!string.IsNullOrEmpty(result))
		{
			string text = this._FindRequestProperty(request, "ifid");
			InfinityFieldDataRow infinityFieldDataRow = this.regulation.infinityFieldDtbl[text];
			this.localUser.currScenario.scenarioId = infinityFieldDataRow.scenarioIdx;
			this.localUser.currScenario.commanderId = 0;
			Loading.Load(Loading.Scenario);
		}
		yield break;
	}

	// Token: 0x06006195 RID: 24981 RVA: 0x001B1D58 File Offset: 0x001AFF58
	private IEnumerator StartInfinityBattleScenarioError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/