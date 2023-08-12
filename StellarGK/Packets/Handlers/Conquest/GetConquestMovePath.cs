using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestMovePath
    {
        
    }
}
/*	// Token: 0x0600606F RID: 24687 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7507", true, true)]
	public void GetConquestMovePath(int dest, int slot)
	{
	}

	// Token: 0x06006070 RID: 24688 RVA: 0x001B0520 File Offset: 0x001AE720
	private IEnumerator GetConquestMovePathResult(JsonRpcClient.Request request, string result, List<int> path, int distance)
	{
		if (!string.IsNullOrEmpty(result) && UIManager.instance.world.conquestMap.isActive && UIManager.instance.world.conquestMap.stagePopup != null)
		{
			string text = this._FindRequestProperty(request, "dest");
			string text2 = this._FindRequestProperty(request, "slot");
			UIManager.instance.world.conquestMap.stagePopup.OnOpenMoveInfoPopup(int.Parse(text), int.Parse(text2), distance);
		}
		yield break;
	}

	// Token: 0x06006071 RID: 24689 RVA: 0x001B0554 File Offset: 0x001AE754
	private IEnumerator GetConquestMovePathError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
		}
		else if (code == 71501)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71502)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71507)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110366"));
		}
		else if (code == 71506)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		else if (code == 71508)
		{
			UISimplePopup.CreateOK(false, Localization.Get("1303"), Localization.Format("110367", new object[] { code }), null, "1001");
		}
		UIManager.instance.world.guild.Close();
		yield break;
	}*/