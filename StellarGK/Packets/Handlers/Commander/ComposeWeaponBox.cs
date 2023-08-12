using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Commander
{
    public class ComposeWeaponBox
    {
        
    }
}
/*	// Token: 0x06006181 RID: 24961 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8512", true, true)]
	public void ComposeWeaponBox(int gidx, int amnt)
	{
	}

	// Token: 0x06006182 RID: 24962 RVA: 0x001B1BC4 File Offset: 0x001AFDC4
	private IEnumerator ComposeWeaponBoxResult(JsonRpcClient.Request request, string result, Dictionary<string, int> item, List<Protocols.RewardInfo.RewardData> reward)
	{
		this.localUser.RefreshItemFromNetwork(item);
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006183 RID: 24963 RVA: 0x001B1BF0 File Offset: 0x001AFDF0
	private IEnumerator ComposeWeaponBoxError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/