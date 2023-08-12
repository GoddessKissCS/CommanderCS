using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Carnival
{
    public class CarnivalSelectItem
    {
        
    }
}
/*	// Token: 0x060060C5 RID: 24773 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6244", true, true)]
	public void CarnivalSelectItem(int ctid, int cidx, int ridx)
	{
	}

	// Token: 0x060060C6 RID: 24774 RVA: 0x001B0C24 File Offset: 0x001AEE24
	private IEnumerator CarnivalSelectItemResult(JsonRpcClient.Request request, string result, Dictionary<string, Dictionary<string, Protocols.CarnivalList.ProcessData>> ctnt)
	{
		if (result != null)
		{
			this.localUser.RefreshCarnivalFromNetwork(ctnt);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x060060C7 RID: 24775 RVA: 0x001B0C50 File Offset: 0x001AEE50
	private IEnumerator CarnivalSelectItemError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 20001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5065"));
		}
		yield break;
	}*/