using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Guild
{
    public class AppointSubMaster
    {
        
    }
}
/*	// Token: 0x06006046 RID: 24646 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7257", true, true)]
	public void AppointSubMaster(int tuno)
	{
	}

	// Token: 0x06006047 RID: 24647 RVA: 0x001B01B0 File Offset: 0x001AE3B0
	private IEnumerator AppointSubMasterResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		UIManager.instance.world.guild.AppointSubMaster(true, num);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006048 RID: 24648 RVA: 0x001B01D4 File Offset: 0x001AE3D4
	private IEnumerator AppointSubMasterError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71001)
		{
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		else if (code == 71019)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Format("110114", new object[] { this.regulation.defineDtbl["GUILD_MAX_AIDE"].value }));
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/