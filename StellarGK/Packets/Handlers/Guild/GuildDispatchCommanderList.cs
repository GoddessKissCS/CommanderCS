using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Guild
{
    public class GuildDispatchCommanderList
    {
        
    }
}
/*	// Token: 0x060060C8 RID: 24776 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7174", true, true)]
	public void GuildDispatchCommanderList(int type)
	{
	}

	// Token: 0x060060C9 RID: 24777 RVA: 0x001B0C6C File Offset: 0x001AEE6C
	private IEnumerator GuildDispatchCommanderListResult(JsonRpcClient.Request request, Protocols.GuildDispatchCommanderList result)
	{
		this.localUser.SetMercenaryList(result);
		string text = this._FindRequestProperty(request, "type");
		int num = int.Parse(text);
		if (num == 1 || num == 5 || num == 10 || num == 15)
		{
			UIManager.instance.world.commanderList.SetEngageCommanderList();
		}
		yield break;
	}*/