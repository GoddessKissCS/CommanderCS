namespace StellarGK.Packets.Handlers.Inventory
{
    public class SetItemEquipment
    {
    }
}

/*	// Token: 0x060060EB RID: 24811 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7421", true, true)]
	public void SetItemEquipment(int eidx, int cid, int elv)
	{
	}

	// Token: 0x060060EC RID: 24812 RVA: 0x001B0F1C File Offset: 0x001AF11C
	private IEnumerator SetItemEquipmentResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		if (result.equipItem != null && result.commanderInfo != null)
		{
			RoCommander roCommander = null;
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderInfo)
			{
				string key = keyValuePair.Key;
				roCommander = this.localUser.FindCommander(key);
				if (roCommander != null)
				{
					foreach (KeyValuePair<string, int> keyValuePair2 in keyValuePair.Value.equipItemInfo)
					{
						RoItem roItem = this.localUser.EquipedList_FindItem(keyValuePair2.Key, key, keyValuePair2.Value);
						if (roItem == null)
						{
							this.localUser.EquipedList_AddItem(RoItem.Create(keyValuePair2.Key, keyValuePair2.Value, 1, key));
							RoItem roItem2 = this.localUser.EquipedList_FindItem(keyValuePair2.Key, key, keyValuePair2.Value);
							roCommander.SetEquipItem(roItem2.pointType, roItem2);
						}
						else
						{
							roCommander.SetEquipItem(roItem.pointType, roItem);
						}
					}
				}
			}
			int num = 0;
			RoItem roItem3 = null;
			string text = string.Empty;
			foreach (KeyValuePair<string, Dictionary<int, Protocols.EquipItemInfo>> keyValuePair3 in result.equipItem)
			{
				text = keyValuePair3.Key;
				int num2 = 0;
				foreach (KeyValuePair<int, Protocols.EquipItemInfo> keyValuePair4 in keyValuePair3.Value)
				{
					int key2 = keyValuePair4.Key;
					if ((result.equipItem.Count == 2 && num == 0) || (keyValuePair3.Value.Count == 2 && num2 == 0))
					{
						RoItem roItem4 = this.localUser.EquipedList_FindItem(text, roCommander.id, key2);
						if (roItem4 != null)
						{
							this.localUser.EquipedeList_RemoveItem(roItem4);
						}
					}
					roItem3 = this.localUser.EquipedList_FindItem(text, roCommander.id, key2);
					this.localUser.SetEquipPossibleItemCount(text, key2, keyValuePair4.Value.availableCount);
					num2++;
				}
				num++;
			}
			if (UIManager.instance.world.existCommanderDetail && UIManager.instance.world.commanderDetail.isActive)
			{
				UICommanderDetail commanderDetail = UIManager.instance.world.commanderDetail;
				commanderDetail.OnRefresh();
				commanderDetail.haveItemListPopup.RefreshList();
			}
			if (UIManager.instance.world.existLaboratory && UIManager.instance.world.laboratory.isActive)
			{
				UIManager.instance.world.laboratory.currSelectItem = roItem3;
				UIManager.instance.world.laboratory.OnRefresh();
			}
		}
		yield break;
	}*/