using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Cooperate
{
    public class CooperateBattlePointRank
    {
        
    }
}
/*	// Token: 0x06006108 RID: 24840 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7604", true, true)]
	public void CooperateBattlePointRank(int step)
	{
	}

	// Token: 0x06006109 RID: 24841 RVA: 0x001B116C File Offset: 0x001AF36C
	private IEnumerator CooperateBattlePointRankResult(JsonRpcClient.Request request, List<Protocols.CooperateBattlePointUserRankingInfo> result)
	{
		if (!UIManager.instance.world.cooperateBattle.isActive)
		{
			yield break;
		}
		int num = int.Parse(this._FindRequestProperty(request, "step"));
		UIManager.instance.world.cooperateBattle.SetRankingData(num, result);
		yield break;
	}

	// Token: 0x0600610A RID: 24842 RVA: 0x001B1198 File Offset: 0x001AF398
	private IEnumerator CooperateBattlePointRankError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			if (UIManager.instance.world.guild.isActive)
			{
				UIManager.instance.world.guild.Close();
			}
		}
		else if (code == 71603)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5090032"));
		}
		yield break;
	}*/