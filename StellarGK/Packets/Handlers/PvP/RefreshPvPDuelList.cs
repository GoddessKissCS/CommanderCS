using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.PvP
{
    public class RefreshPvPDuelList
    {
        
    }
}
/*	// Token: 0x06005F83 RID: 24451 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3124", true, true)]
	public void RefreshPvPDuelList()
	{
	}

	// Token: 0x06005F84 RID: 24452 RVA: 0x001AF1B4 File Offset: 0x001AD3B4
	private IEnumerator RefreshPvPDuelListResult(JsonRpcClient.Request request, Protocols.RefreshPvPDuel result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.RefreshGoodsFromNetwork(result.rsoc);
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		if (result.duelList != null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateDuelListUser(EBattleType.Duel, result.duelList[i]));
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/