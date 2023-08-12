using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ChangeDormitoryFloorName
    {
        
    }
}
/*	// Token: 0x060061AA RID: 25002 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8604", true, true)]
	public void ChangeDormitoryFloorName(string fno, string fnm)
	{
	}

	// Token: 0x060061AB RID: 25003 RVA: 0x001B1EA8 File Offset: 0x001B00A8
	private IEnumerator ChangeDormitoryFloorNameResult(JsonRpcClient.Request request, Protocols.Dormitory.ChangeDormitoryFloorNameResponse result)
	{
		SingletonMonoBehaviour<DormitoryData>.Instance.room.name = result.name;
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		Message.Send("Room.Update.Name");
		Message.Send("Update.Goods");
		yield break;
	}

	// Token: 0x060061AC RID: 25004 RVA: 0x001B1ECC File Offset: 0x001B00CC
	private IEnumerator ChangeDormitoryFloorNameResultError(JsonRpcClient.Request request, string result, int code)
	{
		if (code != 85102)
		{
			if (code != 85101)
			{
				if (code != 85100)
				{
				}
			}
			else
			{
				NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("81015"));
			}
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("7054"));
		}
		yield break;
	}*/