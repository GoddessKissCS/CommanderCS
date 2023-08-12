using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dormitory
{
    public class SellDormitoryItem
    {
        
    }
}
/*	// Token: 0x060061B2 RID: 25010 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8612", true, true)]
	public void SellDormitoryItem(EStorageType ityp, string tidx, int amnt)
	{
	}

	// Token: 0x060061B3 RID: 25011 RVA: 0x001B1F44 File Offset: 0x001B0144
	private IEnumerator SellDormitoryItemResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		this.localUser.RefreshRewardFromNetwork(result);
		Message.Send("Update.Goods");
		Message.Send("Inven.Update");
		yield break;
	}*/