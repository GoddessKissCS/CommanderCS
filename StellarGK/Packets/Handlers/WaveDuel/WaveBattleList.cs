using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.WaveDuel
{
    public class WaveBattleList
    {
        
    }
}
/*	// Token: 0x060060E4 RID: 24804 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3301", true, true)]
	public void WaveBattleList()
	{
	}

	// Token: 0x060060E5 RID: 24805 RVA: 0x001B0E94 File Offset: 0x001AF094
	private IEnumerator WaveBattleListResult(JsonRpcClient.Request request, Protocols.WaveBattleInfoList result)
	{
		if (result != null && result.InfoList != null)
		{
			if (!UIManager.instance.world.existWaveBattle || !UIManager.instance.world.waveBattle.isActive)
			{
				UIManager.instance.world.waveBattle.InitAndOpen();
			}
			UIManager.instance.world.waveBattle.SetWaveData(result.InfoList);
		}
		yield return null;
		yield break;
	}*/