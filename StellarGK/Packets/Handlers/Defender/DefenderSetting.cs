using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Defender
{
    public class DefenderSetting
    {
        
    }
}

/*	// Token: 0x06005F8F RID: 24463 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3228", true, true)]
	public void DefenderSetting(JObject deck)
	{
	}

	// Token: 0x06005F90 RID: 24464 RVA: 0x001AF29C File Offset: 0x001AD49C
	private IEnumerator DefenderSettingResult(JsonRpcClient.Request request, string result)
	{
		if (result.Equals("True"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._FindRequestProperty(request, "deck"));
			this.localUser.RefreshDefenderTroop(dictionary);
			UIManager.instance.world.readyBattle.CloseAnimation();
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/