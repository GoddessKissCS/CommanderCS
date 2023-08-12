using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Inventory
{
    public class DecompositionItemEquipment
    {
        
    }
}
/*	// Token: 0x060060F1 RID: 24817 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7424", true, true)]
	public void DecompositionItemEquipment(int eidx, int elv, int amnt)
	{
	}

	// Token: 0x060060F2 RID: 24818 RVA: 0x001B0F88 File Offset: 0x001AF188
	private IEnumerator DecompositionItemEquipmentResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result, List<Protocols.RewardInfo.RewardData> reward)
	{
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		string text = string.Empty;
		foreach (KeyValuePair<string, Dictionary<int, Protocols.EquipItemInfo>> keyValuePair in result.equipItem)
		{
			text = keyValuePair.Key;
			foreach (KeyValuePair<int, Protocols.EquipItemInfo> keyValuePair2 in keyValuePair.Value)
			{
				int key = keyValuePair2.Key;
				this.localUser.SetEquipPossibleItemCount(text, key, keyValuePair2.Value.availableCount);
			}
		}
		UIPopup.Create<UIGetItem>("GetItem").Set(reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		if (UIManager.instance.world.existLaboratory && UIManager.instance.world.laboratory.isActive)
		{
			UIManager.instance.world.laboratory.currSelectItem = null;
			UIManager.instance.world.laboratory.OnRefresh();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/