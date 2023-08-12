using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Guild
{
    public class ApplyGuildJoin
    {
        
    }
}
/*	// Token: 0x06006027 RID: 24615 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7251", true, true)]
	public void ApplyGuildJoin(int gidx)
	{
	}

	// Token: 0x06006028 RID: 24616 RVA: 0x001AFEEC File Offset: 0x001AE0EC
	private IEnumerator ApplyGuildJoinResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "gidx"));
		UIManager.instance.world.guild.ChangeGuildItemState(num, "req");
		yield break;
	}

	// Token: 0x06006029 RID: 24617 RVA: 0x001AFF10 File Offset: 0x001AE110
	private IEnumerator ApplyGuildJoinError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 71301)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.RomoveGuildList(num);
		}
		else if (code == 71302)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			int num2 = int.Parse(this._FindRequestProperty(request, "gidx"));
			UIManager.instance.world.guild.ChangeGuildItemType(num2, 1);
		}
		else if (code == 71303)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110219"));
		}
		else if (code == 71110)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110265"));
		}
		else if (code == 71111)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110266"));
		}
		else if (code == 71112)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110306"));
		}
		yield break;
	}*/