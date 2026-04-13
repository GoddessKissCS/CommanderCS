using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.UpgradeItemEquipment)]
    public class UpgradeItemEquipment : BaseMethodHandler<UpgradeItemEquipmentRequest>
    {
        public override object Handle(UpgradeItemEquipmentRequest request)
        {
            var user = GetUserGameProfile();

            var eidx = request.eidx.ToString();
            var cid = request.cid.ToString();
            var elv = request.elv.ToString();
            var newElv = (request.elv + 1).ToString();

            if(cid != "0")
            {
                if (!user.CommanderData.ContainsKey(cid))
                {
                    return new ErrorPacket
                    {
                        Id = BasePacket.Id,
                        Error = new ErrorMessageId { code = ErrorCode.Failure }
                    };
                }
            }

            if (!user.Inventory.equipItem.ContainsKey(eidx) || !user.Inventory.equipItem[eidx].ContainsKey(elv))
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources }
                };
            }

            var equipItemRow = RemoteObjectManager.instance.regulation.equipItemDtbl.Find(x => x.key == eidx);
            var upgradeData = RemoteObjectManager.instance.regulation.FindUpgradeItemInfo(equipItemRow.UpgradeType, request.elv);

            if (upgradeData == null)
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId { code = ErrorCode.Failure }
                };
            }

            // Consume upgrade materials from partData
            (string id, int vol)[] materials =
            [
                (upgradeData.upgradeMaterial1, upgradeData.upgradeMaterial1Volume),
                (upgradeData.upgradeMaterial2, upgradeData.upgradeMaterial2Volume),
                (upgradeData.upgradeMaterial3, upgradeData.upgradeMaterial3Volume),
                (upgradeData.upgradeMaterial4, upgradeData.upgradeMaterial4Volume),
                (upgradeData.upgradeMaterial5, upgradeData.upgradeMaterial5Volume),
            ];

            foreach (var (id, vol) in materials)
            {
                if (string.IsNullOrEmpty(id) || vol <= 0)
                    continue;

                if (!user.Inventory.partData.ContainsKey(id) || user.Inventory.partData[id] < vol)
                {
                    return new ErrorPacket
                    {
                        Id = BasePacket.Id,
                        Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources }
                    };
                }

                user.Inventory.partData[id] = Math.Max(0, user.Inventory.partData[id] - vol);
            }

            // Consume gold cost
            if (upgradeData.upgradeGoodsVolume > 0 && user.Resources.gold < upgradeData.upgradeGoodsVolume)
            {
                return new ErrorPacket
                {
                    Id = BasePacket.Id,
                    Error = new ErrorMessageId { code = ErrorCode.NotEnoughResources }
                };
            }

            if (upgradeData.upgradeGoodsVolume > 0)
            {
                user.Resources.gold -= upgradeData.upgradeGoodsVolume;
                DatabaseManager.GameProfile.UpdateGold(SessionId, upgradeData.upgradeGoodsVolume, false);
            }

            // Move item from elv to elv+1 (upgrading consumes one of the old level, produces one of the new level)
            var oldEquip = user.Inventory.equipItem[eidx][elv];
            if (!user.Inventory.equipItem[eidx].ContainsKey(newElv))
            {
                // cid == 0 means not equipped on a commander, so no commander list to carry over
                user.Inventory.equipItem[eidx][newElv] = new EquipItemInfo
                {
                    totalCount = 1,
                    availableCount = 1,
                    equipCommanderList = cid != "0" ? new List<int>(oldEquip.equipCommanderList) : [],
                };
            }
            else
            {
                user.Inventory.equipItem[eidx][newElv].totalCount += 1;
                user.Inventory.equipItem[eidx][newElv].availableCount += 1;
                if (cid != "0")
                    user.Inventory.equipItem[eidx][newElv].equipCommanderList.AddRange(oldEquip.equipCommanderList);
            }

            oldEquip.totalCount -= 1;
            oldEquip.availableCount -= 1;

            if (oldEquip.totalCount <= 0)
            {
                oldEquip.totalCount = 0;
                oldEquip.availableCount = 0;
            }

            // Update commander's equipItemInfo to new level
            if(cid != "0")
            {
                var commander = user.CommanderData[cid];
                if (commander.equipItemInfo.ContainsKey(eidx))
                    commander.equipItemInfo[eidx] = request.elv + 1;
            }

            DatabaseManager.GameProfile.UpdatePartData(SessionId, user.Inventory.partData);
            DatabaseManager.GameProfile.UpdateEquipItemData(SessionId, user.Inventory.equipItem);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);

            var userInfoResponse = GetUserInformationResponse(user);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInfoResponse,
            };

            return response;
        }
    }

    public class UpgradeItemEquipmentRequest
    {
        [JsonProperty("eidx")]
        public int eidx { get; set; }

        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("elv")]
        public int elv { get; set; }
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
		if (result.commanderInfo != null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair3 in result.commanderInfo)
			{
				if (keyValuePair3.Value.equipItemInfo != null)
				{
					foreach (KeyValuePair<string, int> keyValuePair4 in keyValuePair3.Value.equipItemInfo)
					{
						this.localUser.EquipedList_upgradeItem(keyValuePair4.Key, keyValuePair4.Value, keyValuePair3.Key);
						roItem = this.localUser.EquipedList_FindItem(keyValuePair4.Key, keyValuePair3.Key, keyValuePair4.Value);
						RoCommander roCommander = this.localUser.FindCommander(keyValuePair3.Key);
						if (roCommander != null && roItem != null)
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
