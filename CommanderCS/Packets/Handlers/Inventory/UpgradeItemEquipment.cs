namespace CommanderCS.Packets.Handlers.Inventory
{
    public class UpgradeItemEquipment
    {
    }
}

/*	// Token: 0x060060EF RID: 24815 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7423", true, true)]
	public void UpgradeItemEquipment(int eidx, int cid, int elv)
	{
	}

	// Token: 0x060060F0 RID: 24816 RVA: 0x001B0F64 File Offset: 0x001AF164
	private IEnumerator UpgradeItemEquipmentResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		RoItem roItem = null;
		string text = string.Empty;
		int num = 0;
		foreach (KeyValuePair<string, Dictionary<int, Protocols.EquipItemInfo>> keyValuePair in result.equipItem)
		{
			text = keyValuePair.Key;
			foreach (KeyValuePair<int, Protocols.EquipItemInfo> keyValuePair2 in keyValuePair.Value)
			{
				num = keyValuePair2.Key;
				this.localUser.SetEquipPossibleItemCount(text, num, keyValuePair2.Value.availableCount);
			}
		}
		if (result.commanderInfo is not null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair3 in result.commanderInfo)
			{
				if (keyValuePair3.Value.equipItemInfo is not null)
				{
					foreach (KeyValuePair<string, int> keyValuePair4 in keyValuePair3.Value.equipItemInfo)
					{
						this.localUser.EquipedList_upgradeItem(keyValuePair4.Key, keyValuePair4.Value, keyValuePair3.Key);
						roItem = this.localUser.EquipedList_FindItem(keyValuePair4.Key, keyValuePair3.Key, keyValuePair4.Value);
						RoCommander roCommander = this.localUser.FindCommander(keyValuePair3.Key);
						if (roCommander is not null && roItem is not null)
						{
							roCommander.SetEquipItem(roItem.pointType, roItem);
						}
					}
				}
			}
		}
		if (roItem = null)
		{
			roItem = this.localUser.EquipPossibleList_FindItem(text, num);
		}
		if (UIManager.instance.world.existLaboratory && UIManager.instance.world.laboratory.isActive)
		{
			UIManager.instance.world.laboratory.currSelectItem = roItem;
			UIManager.instance.world.laboratory.OnRefresh();
			SoundManager.PlaySFX("SE_Upgrade_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/