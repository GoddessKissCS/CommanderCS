using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dormitory
{
    public class ChangeDormitoryCommanderBody
    {
        
    }
}/*	// Token: 0x060061C9 RID: 25033 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8644", true, true)]
	public void ChangeDormitoryCommanderBody(string cid, string idx)
	{
	}

	// Token: 0x060061CA RID: 25034 RVA: 0x001B20C8 File Offset: 0x001B02C8
	private IEnumerator ChangeDormitoryCommanderBodyResult(JsonRpcClient.Request request, Protocols.Dormitory.ChangeCommanderBodyResponse result)
	{
		SingletonMonoBehaviour<DormitoryData>.Instance.dormitory.UpdateInvenData(EDormitoryItemType.CostumeBody, result.invenBody);
		foreach (KeyValuePair<string, Protocols.Dormitory.CommanderBodyData> keyValuePair in result.bodyData)
		{
			string key = keyValuePair.Key;
			RoDormitory.Item body = SingletonMonoBehaviour<DormitoryData>.Instance.characters[key].body;
			Dictionary<string, Protocols.Dormitory.CommanderBodyData>.Enumerator enumerator;
			KeyValuePair<string, Protocols.Dormitory.CommanderBodyData> keyValuePair2 = enumerator.Current;
			body.id = keyValuePair2.Value.bodyId;
			Message.Send<string>("Chr.Update.Costume", key);
		}
		yield break;
	}

	// Token: 0x060061CB RID: 25035 RVA: 0x001B20E4 File Offset: 0x001B02E4
	private IEnumerator ChangeDormitoryCommanderBodyError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 85153)
		{
		}
		yield break;
	}*/