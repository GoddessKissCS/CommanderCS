using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Dormitory
{
    public class GetDormitoryPoint
    {
        
    }
}/*	// Token: 0x060061CC RID: 25036 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8650", true, true)]
	public void GetDormitoryPoint(string cid)
	{
	}

	// Token: 0x060061CD RID: 25037 RVA: 0x001B2100 File Offset: 0x001B0300
	private IEnumerator GetDormitoryPointResult(JsonRpcClient.Request request, Protocols.Dormitory.GetPointResponse result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		Message.Send("Update.Goods");
		foreach (KeyValuePair<string, Protocols.Dormitory.CommanderRaminData> keyValuePair in result.reaminData)
		{
			string key = keyValuePair.Key;
			TimeData remain = SingletonMonoBehaviour<DormitoryData>.Instance.characters[key].remain;
			Dictionary<string, Protocols.Dormitory.CommanderRaminData>.Enumerator enumerator;
			KeyValuePair<string, Protocols.Dormitory.CommanderRaminData> keyValuePair2 = enumerator.Current;
			remain.SetByDuration(keyValuePair2.Value.remain);
			Message.Send<string>("Chr.Update.RewardRemain", key);
		}
		yield break;
	}*/