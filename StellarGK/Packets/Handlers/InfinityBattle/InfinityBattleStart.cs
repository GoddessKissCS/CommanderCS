using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.InfinityBattle
{
    public class InfinityBattleStart
    {
        
    }
}
/*	// Token: 0x06006199 RID: 24985 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3737", true, true)]
	public void InfinityBattleStart(int type, int ifid, JObject deck)
	{
	}

	// Token: 0x0600619A RID: 24986 RVA: 0x001B1DA4 File Offset: 0x001AFFA4
	private IEnumerator InfinityBattleStartResult(JsonRpcClient.Request request, string result)
	{
		BattleData battleData = BattleData.Get();
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x0600619B RID: 24987 RVA: 0x001B1DB8 File Offset: 0x001AFFB8
	private IEnumerator InfinityBattleStartError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/