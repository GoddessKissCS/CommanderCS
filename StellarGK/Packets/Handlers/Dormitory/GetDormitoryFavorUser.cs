using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dormitory
{
    public class GetDormitoryFavorUser
    {
        
    }
}/*	// Token: 0x060061DB RID: 25051 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8663", true, true)]
	public void GetDormitoryFavorUser()
	{
	}

	// Token: 0x060061DC RID: 25052 RVA: 0x001B2200 File Offset: 0x001B0400
	private IEnumerator GetDormitoryFavorUserResult(JsonRpcClient.Request request, string result, List<Protocols.Dormitory.SearchUserInfo> ulist)
	{
		Message.Send<MessageEvent.Search.Data>("Search.Get.Users", new MessageEvent.Search.Data
		{
			type = EVisitType.Favorites,
			users = ulist
		});
		yield break;
	}*/