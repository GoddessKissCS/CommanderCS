using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CommanderCS.Library.Protocols.GachaOpenBoxResponse;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.DecompositionItemEquipment)]
    public class DecompositionItemEquipment : BaseMethodHandler<DecompositionItemEquipmentRequest>
    {
        public override object Handle(DecompositionItemEquipmentRequest request)
        {
            var user = GetUserGameProfile();

            var DissambleItem = RemoteObjectManager.instance.regulation.equipItemDtbl.Find(x => x.key == request.eidx.ToString());

			var DissambleItemData = RemoteObjectManager.instance.regulation.equipItemDisassembleDtbl.Find(x => x.disassembleType == DissambleItem.disassembleType && x.level == request.elv);

            int ammount = request.amnt;
            string itemId = request.eidx.ToString();
            string itemLevel = request.elv.ToString();

            if (user.Inventory.equipItem.ContainsKey(itemId) && user.Inventory.equipItem[itemId].ContainsKey(itemLevel))
            {
                var equipInfo = user.Inventory.equipItem[itemId][itemLevel];
                equipInfo.totalCount -= ammount;
                equipInfo.availableCount -= ammount;

                if (equipInfo.totalCount <= 0)
                {
                    equipInfo.totalCount = 0;
                    equipInfo.availableCount = 0;
                }

                DatabaseManager.GameProfile.UpdateEquipItemData(SessionId, user.Inventory.equipItem);
            }

            List<RewardInfo.RewardData> rewardList =
            [
                new()
                {
                    effect = 0,
                    rewardCnt = DissambleItemData.return1 * ammount,
                    rewardId = DissambleItemData.disassembleMaterial1,
                    rewardType = ERewardType.UnitMaterial,
                },
                new()
                {
                    effect = 0,
                    rewardCnt = DissambleItemData.return2 * ammount,
                    rewardId = DissambleItemData.disassembleMaterial2,
                    rewardType = ERewardType.UnitMaterial,
                },
                new()
                {
                    effect = 0,
                    rewardCnt = DissambleItemData.return3 * ammount,
                    rewardId = DissambleItemData.disassembleMaterial3,
                    rewardType = ERewardType.UnitMaterial,
                },
                new()
                {
                    effect = 0,
                    rewardCnt = DissambleItemData.return4 * ammount,
                    rewardId = DissambleItemData.disassembleMaterial4,
                    rewardType = ERewardType.UnitMaterial,
                },
                new()
                {
                    effect = 0,
                    rewardCnt = DissambleItemData.return5 * ammount,
                    rewardId = DissambleItemData.disassembleMaterial5,
                    rewardType = ERewardType.UnitMaterial,
                },
            ];

            foreach (var reward in rewardList)
            {
                if (!user.Inventory.partData.TryAdd(reward.rewardId, reward.rewardCnt))
                    user.Inventory.partData[reward.rewardId] += reward.rewardCnt;
            }
            DatabaseManager.GameProfile.UpdatePartData(SessionId, user.Inventory.partData);

            var information = GetUserInformationResponse(user);

            JObject tutorialResponse = new()
            {
                ["id"] = BasePacket.Id,
                ["result"] = new JObject
                {
                    ["reward"] = JArray.FromObject(rewardList),
                    ["rsoc"] = JObject.FromObject(information.goodsInfo),
                    ["uifo"] = JObject.FromObject(information.battleStatisticsInfo),
                    ["comm"] = JObject.FromObject(information.__commanderInfo),
                    ["uno"] = information.uno,
                    ["stage"] = information.stage,
                    ["part"] = JObject.FromObject(information.partData),
                    ["medl"] = JObject.FromObject(information.medalData),
                    ["ersoc"] = JObject.FromObject(information.eventResourceData),
                    ["food"] = JObject.FromObject(information.foodData),
                    ["item"] = JObject.FromObject(information.itemData),
                    ["gld"] = null,
                    ["cc"] = JObject.FromObject(information.sweepClearData),
                    ["deck"] = JArray.FromObject(information.preDeck),
                    ["nhcc"] = JObject.FromObject(information.donHaveCommCostumeData),
                    ["grp"] = JArray.FromObject(information.completeRewardGroupIdx),
                    ["rstm"] = information.resetRemain,
                    ["onoff"] = information.notification,
                    ["equip"] = JObject.FromObject(information.equipItem),
                    ["guit"] = JObject.FromObject(information.groupItemData),
                    ["weapon"] = JObject.FromObject(information.weaponList)
                }
            };

            return tutorialResponse;
        }
    }


    public class res
    {
        [JsonProperty("result")]
        public UserInformationResponse result { get; set; }

        [JsonProperty("reward")]
        public List<RewardInfo.RewardData> reward { get; set; }
    }

    public class DecompositionItemEquipmentRequest
    {
        [JsonProperty("eidx")]
        public int eidx { get; set; }

        [JsonProperty("elv")]
        public int elv { get; set; }

        [JsonProperty("amnt")]
        public int amnt { get; set; }
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
