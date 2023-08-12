using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Inventory
{
    public class SellItem
    {
        
    }
}
/*	// Token: 0x06006090 RID: 24720 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7401", true, true)]
	public void SellItem(int ityp, int tidx, int amnt)
	{
	}

	// Token: 0x06006091 RID: 24721 RVA: 0x001B07E8 File Offset: 0x001AE9E8
	private IEnumerator SellItemResult(JsonRpcClient.Request request, Protocols.SellItemData result)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		int num = int.Parse(this._FindRequestProperty(request, "ityp"));
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		NetworkAnimation.Instance.CreateFloatingText(Localization.Get("1315"));
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/