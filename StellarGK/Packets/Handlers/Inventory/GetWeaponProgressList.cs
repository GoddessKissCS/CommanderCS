using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Inventory
{
    public class GetWeaponProgressList
    {
        
    }
}
/*	// Token: 0x06006160 RID: 24928 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8501", true, true)]
	public void GetWeaponProgressList()
	{
	}

	// Token: 0x06006161 RID: 24929 RVA: 0x001B18DC File Offset: 0x001AFADC
	private IEnumerator GetWeaponProgressListResult(JsonRpcClient.Request request, List<Protocols.WeaponProgressSlotData> result)
	{
		if (!UIManager.instance.world.existWeaponResearch || !UIManager.instance.world.weaponResearch.isActive)
		{
			UIManager.instance.world.weaponResearch.InitAndOpenWeaponResearch();
		}
		UIManager.instance.world.weaponResearch.SelectTabContents();
		UIManager.instance.world.weaponResearch.SetWeaponProgressData(result);
		yield break;
	}

	// Token: 0x06006162 RID: 24930 RVA: 0x001B18F8 File Offset: 0x001AFAF8
	private IEnumerator GetWeaponProgressListError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 70201 || code == 70210)
		{
		}
		yield break;
	}*/