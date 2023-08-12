using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.PvP
{
    public class RefreshPvPWaveDuelList
    {
        
    }
}

/*	// Token: 0x06005F95 RID: 24469 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3402", true, true)]
	public void RefreshPvPWaveDuelList()
	{
	}

	// Token: 0x06005F96 RID: 24470 RVA: 0x001AF310 File Offset: 0x001AD510
	private IEnumerator RefreshPvPWaveDuelListResult(JsonRpcClient.Request request, Protocols.RefreshPvPDuel result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.RefreshGoodsFromNetwork(result.rsoc);
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		this.localUser.currentSeasonOpenRemainDuelTime.SetByDuration((double)result.openRemain);
		if (result.duelList != null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateWaveDuelListUser(result.duelList[i]));
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/