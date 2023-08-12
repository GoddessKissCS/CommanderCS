using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Inventory
{
    public class OpenItem
    {
        
    }
}
/*	// Token: 0x06006092 RID: 24722 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7402", true, true)]
	public void OpenItem(int ityp, int tidx, int amnt, int rtyp, int ridx)
	{
	}

	// Token: 0x06006093 RID: 24723 RVA: 0x001B0814 File Offset: 0x001AEA14
	private IEnumerator OpenItemResult(JsonRpcClient.Request request, Protocols.SellItemData result)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		int num = int.Parse(this._FindRequestProperty(request, "ityp"));
		if (result.rewardList != null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		ERewardType erewardType = (ERewardType)int.Parse(this._FindRequestProperty(request, "rtyp"));
		string text = this._FindRequestProperty(request, "ridx");
		if (erewardType == ERewardType.Commander)
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			if (roCommander != null)
			{
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				if (uicommanderComplete != null)
				{
					if (roCommander.state != ECommanderState.Nomal)
					{
						uicommanderComplete.Init(CommanderCompleteType.Recruit, roCommander.id);
					}
					else
					{
						uicommanderComplete.Init(CommanderCompleteType.Transmission, roCommander.id);
					}
				}
			}
			if (result.commanderData != null)
			{
				foreach (Protocols.UserInformationResponse.Commander commander in result.commanderData.Values)
				{
					RoCommander roCommander2 = this.localUser.FindCommander(commander.id);
					if (commander.haveCostume != null && commander.haveCostume.Count > 0)
					{
						roCommander2.haveCostumeList = commander.haveCostume;
					}
				}
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		this.localUser.RefreshItemFromNetwork(result.eventResourceData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		this.localUser.RefreshWeaponFromNetwork(result.weaponData);
		this.localUser.RefreshGoodsFromNetwork(result.dormitoryResource);
		this.localUser.RefreshDormitoryItemNormalFromNetwork(result.dormitoryItemNormal);
		this.localUser.RefreshDormitoryItemAdvancedFromNetwork(result.dormitoryItemAdvanced);
		this.localUser.RefreshDormitoryItemWallpaperFromNetwork(result.dormitoryItemWallpaper);
		this.localUser.RefreshDormitoryCostumeBodyFromNetwork(result.dormitoryCostumeBody);
		this.localUser.RefreshDormitoryCostumeHeadFromNetwork(result.dormitoryCostumeHead);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/