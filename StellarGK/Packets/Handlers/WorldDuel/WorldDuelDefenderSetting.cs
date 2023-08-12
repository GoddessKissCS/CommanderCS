using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.WorldDuel
{
    public class WorldDuelDefenderSetting
    {
        
    }
}
/*	// Token: 0x06006151 RID: 24913 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3603", true, true)]
	public void WorldDuelDefenderSetting(JObject deck)
	{
	}

	// Token: 0x06006152 RID: 24914 RVA: 0x001B1794 File Offset: 0x001AF994
	private IEnumerator WorldDuelDefenderSettingResult(JsonRpcClient.Request request, string result)
	{
		if (!string.IsNullOrEmpty(result))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(this._FindRequestProperty(request, "deck"));
			this.localUser.RefreshDefenderTroop(dictionary);
			UIManager.instance.world.readyBattle.CloseAnimation();
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006153 RID: 24915 RVA: 0x001B17C0 File Offset: 0x001AF9C0
	private IEnumerator WorldDuelDefenderSettingError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/