using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Inventory
{
    public class StartWeaponProgress
    {
        
    }
}
/*	// Token: 0x06006163 RID: 24931 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8500", true, true)]
	public void StartWeaponProgress(int slot, int wmat1, int wmat2, int wmat3, int wmat4)
	{
	}

	// Token: 0x06006164 RID: 24932 RVA: 0x001B1914 File Offset: 0x001AFB14
	private IEnumerator StartWeaponProgressResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, int slot, int remain)
	{
		UIManager.instance.world.weaponResearch.inProgress.StartProgress(slot, remain);
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006165 RID: 24933 RVA: 0x001B1948 File Offset: 0x001AFB48
	private IEnumerator StartWeaponProgressError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/