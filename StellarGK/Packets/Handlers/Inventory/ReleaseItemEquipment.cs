namespace StellarGK.Packets.Handlers.Inventory
{
    public class ReleaseItemEquipment
    {
    }
}

/*	// Token: 0x060060ED RID: 24813 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7422", true, true)]
	public void ReleaseItemEquipment(int eidx, int cid)
	{
	}

	// Token: 0x060060EE RID: 24814 RVA: 0x001B0F40 File Offset: 0x001AF140
	private IEnumerator ReleaseItemEquipmentResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result.equipItem != null && result.commanderInfo != null)
		{
			string releaseItemIdx = string.Empty;
			int num = 0;
			foreach (KeyValuePair<string, Dictionary<int, Protocols.EquipItemInfo>> keyValuePair in result.equipItem)
			{
				releaseItemIdx = keyValuePair.Key;
				foreach (KeyValuePair<int, Protocols.EquipItemInfo> keyValuePair2 in keyValuePair.Value)
				{
					num = keyValuePair2.Key;
					this.localUser.SetEquipPossibleItemCount(releaseItemIdx, num, keyValuePair2.Value.availableCount);
				}
			}
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair3 in result.commanderInfo)
			{
				string key = keyValuePair3.Key;
				RoCommander roCommander = this.localUser.FindCommander(key);
				if (roCommander != null)
				{
					EquipItemDataRow equipItemDataRow = this.regulation.equipItemDtbl.Find((EquipItemDataRow row) => row.key == releaseItemIdx);
					RoItem roItem = this.localUser.EquipedList_FindItem(releaseItemIdx, key, num);
					if (roItem != null)
					{
						this.localUser.EquipedeList_RemoveItem(roItem);
						roCommander.ClearEquipItem(equipItemDataRow.pointType, roItem);
					}
				}
			}
			if (UIManager.instance.world.existCommanderDetail && UIManager.instance.world.commanderDetail.isActive)
			{
				UICommanderDetail commanderDetail = UIManager.instance.world.commanderDetail;
				commanderDetail.OnRefresh();
				commanderDetail.haveItemListPopup.RefreshList();
			}
			if (UIManager.instance.world.existLaboratory && UIManager.instance.world.laboratory.isActive)
			{
				UIManager.instance.world.laboratory.haveItemListPopup.RefreshList();
			}
		}
		yield break;
	}*/