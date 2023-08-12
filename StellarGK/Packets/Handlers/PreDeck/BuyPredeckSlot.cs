using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.PreDeck
{
    public class BuyPredeckSlot
    {
        
    }
}
/*	// Token: 0x0600614A RID: 24906 RVA: 0x001B1710 File Offset: 0x001AF910
	private IEnumerator GetEventRemaingTimeError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}

	// Token: 0x0600614B RID: 24907 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "5222", true, true)]
	public void BuyPredeckSlot()
	{
	}

	// Token: 0x0600614C RID: 24908 RVA: 0x001B1724 File Offset: 0x001AF924
	private IEnumerator BuyPredeckSlotResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result != null)
		{
			this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
			this.localUser.statistics.predeckCount = result.battleStatisticsInfo.predeckCount;
			this.localUser.RefreshPreDeckFromNetwork(result.preDeck);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x0600614D RID: 24909 RVA: 0x001B1748 File Offset: 0x001AF948
	private IEnumerator BuyPredeckSlotError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/