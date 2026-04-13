using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using static CommanderCS.Library.Protocols.GachaOpenBoxResponse;
using static CommanderCS.Library.Troop.Slot;

namespace CommanderCS.Packets.Handlers.Inventory
{
    [Packet(Id = Method.OpenItem)]
    public class OpenItem : BaseMethodHandler<OpenItemRequest>
    {
        public override object Handle(OpenItemRequest request)
        {
            var user = GetUserGameProfile();

			var idx = request.tidx.ToString();

            var rewardType = request.rtyp;
            var selectedRewardId = request.ridx;
            var count = request.amnt;


            if(rewardType == 0 && selectedRewardId != 0)
            {
                //this just means we have a selected item out of a box
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };


            var items = RemoteObjectManager.instance.regulation.randomBoxRewardDtbl.FindAll(x => x.idx == idx);

            if (user.Inventory.itemData.ContainsKey(idx))
            {
                user.Inventory.itemData[idx] = Math.Max(0, user.Inventory.itemData[idx] - count);
                DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
            }

            List<RewardInfo.RewardData> rewardList = [];

            var OpenItemSell = new SellItemData()
			{
				rewardList = rewardList
			};

            if (items.Any(x => x.giveType == 2))
            {
                string selectedRewardIdStringed = selectedRewardId.ToString();

                var selectedReward = items.Find(x => x.rewardIdx == selectedRewardIdStringed);

                if(selectedReward.rewardType == ERewardType.Commander)
                {
                    if (!user.CommanderData.ContainsKey(selectedRewardIdStringed))
                    {
                        var commander = CreateCommander(int.Parse(selectedRewardIdStringed));

                        user.CommanderData[selectedRewardIdStringed] = commander;

                        Dictionary<string, UserInformationResponse.Commander> addedCommander = new()
                        {
                            { selectedRewardIdStringed, commander },
                        };

                        DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
                        OpenItemSell.commanderData = addedCommander;
                        OpenItemSell.itemData = user.Inventory.itemData;

                        rewardList.Add(new()
                        {
                            rewardCnt = RandomGenerator.Shared.Next(selectedReward.rewardAmountMin, selectedReward.rewardAmountMax),
                            rewardId = selectedReward.rewardIdx,
                            rewardType = selectedReward.rewardType,
                            effect = 0,
                        });
                    }
                    else
                    {
                        // commander already owned, give 35 medals instead
                        if (!user.Inventory.medalData.TryAdd(selectedRewardIdStringed, 35))
                            user.Inventory.medalData[selectedRewardIdStringed] += 35;
                        DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
                        OpenItemSell.medalData = user.Inventory.medalData;
                        OpenItemSell.itemData = user.Inventory.itemData;


                        rewardList.Add(new()
                        {
                            rewardCnt = RandomGenerator.Shared.Next(selectedReward.rewardAmountMin, selectedReward.rewardAmountMax),
                            rewardId = selectedReward.rewardIdx,
                            rewardType = selectedReward.rewardType,
                            effect = 0,
                        });
                    }
                }

                if(selectedReward.rewardType == ERewardType.Medal)
                {

                    if (!user.Inventory.medalData.TryAdd(selectedRewardIdStringed, Math.Max(selectedReward.rewardAmountMin, selectedReward.rewardAmountMax)))
                        user.Inventory.medalData[selectedRewardIdStringed] += Math.Max(selectedReward.rewardAmountMin, selectedReward.rewardAmountMax);
                    DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
                    OpenItemSell.medalData = user.Inventory.medalData;
                    OpenItemSell.itemData = user.Inventory.itemData;

                    rewardList.Add(new()
                    {
                        rewardCnt = RandomGenerator.Shared.Next(selectedReward.rewardAmountMin, selectedReward.rewardAmountMax),
                        rewardId = selectedReward.rewardIdx,
                        rewardType = selectedReward.rewardType,
                        effect = 0,
                    });
                }


                response.Result = OpenItemSell;

                return response;
            }

            else if (items.All(x => x.rewardType == ERewardType.Item || x.rewardType == ERewardType.Dormitory_AdvancedDeco))
            {
                // all items share the same rewardType, pick one at random
                // 184 = biased toward lower rewards, 185 = middle, 186 = higher
                for (int i = 0; i < count; i++)
                {
                    var item = idx switch
                    {
                        "181" or "184" => PickWeighted(items, [40, 25, 15, 10, 7, 3]),
                        "182" or "185" => PickWeighted(items, [10, 15, 25, 25, 15, 10]),
                        "183" or "186" => PickWeighted(items, [3, 7, 10, 15, 25, 40]),
                        _ => items[RandomGenerator.Shared.Next(0, items.Count)],
                    };
                    rewardList.Add(new()
                    {
                        rewardCnt = RandomGenerator.Shared.Next(item.rewardAmountMin, item.rewardAmountMax),
                        rewardId = item.rewardIdx,
                        rewardType = item.rewardType,
                        effect = 0,
                    });
                }
            }
            else
            {
                foreach (var item in items)
                {
                    rewardList.Add(new()
                    {
                        rewardCnt = RandomGenerator.Shared.Next(item.rewardAmountMin, item.rewardAmountMax),
                        rewardId = item.rewardIdx,
                        rewardType = item.rewardType,
                        effect = 0,
                    });
                }
            }

            // giveType 1 = always given, add regardless of which path was taken above
            foreach (var guaranteed in items.Where(x => x.giveType == 1))
            {
                rewardList.Add(new()
                {
                    rewardCnt = RandomGenerator.Shared.Next(guaranteed.rewardAmountMin, guaranteed.rewardAmountMax),
                    rewardId = guaranteed.rewardIdx,
                    rewardType = guaranteed.rewardType,
                    effect = 0,
                });
            }

            foreach (var reward in rewardList)
                ApplyRewardToUser(user, reward, OpenItemSell);


            response.Result = OpenItemSell;

            return response;
        }


        private void ApplyRewardToUser(MongoDB.Schemes.GameProfileScheme user, RewardInfo.RewardData reward, SellItemData result)
        {
            string rewardId = reward.rewardId;
            int count = reward.rewardCnt;

            switch (reward.rewardType)
            {
                case ERewardType.Goods:
                    // rewardId 4 = gold, rewardId 2 = cash
                    switch (rewardId)
                    {
                        case "4":
                            user.Resources.gold += count;
                            DatabaseManager.GameProfile.UpdateGold(SessionId, count, true);
                            break;
                        case "2":
                            user.Resources.cash += count;
                            DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, count, true);
                            break;

                        case "1001":
                            user.Resources.vipExp += count;
                            DatabaseManager.GameProfile.UpdateOnlyVipEXP(SessionId, count);
                            break;

                        default:
                            if (!user.Inventory.itemData.TryAdd(rewardId, count))
                                user.Inventory.itemData[rewardId] += count;
                            DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
                            break;
                    }
                    result.resource = UserResources2Resource(user.Resources);
                    result.itemData = user.Inventory.itemData;
                    break;

                case ERewardType.Medal:
                    // rewardId = commander id
                    if (!user.Inventory.medalData.TryAdd(rewardId, count))
                        user.Inventory.medalData[rewardId] += count;
                    DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
                    result.medalData = user.Inventory.medalData;
                    result.itemData = user.Inventory.itemData;
                    break;

                case ERewardType.Item:
                    if (!user.Inventory.equipItem.ContainsKey(rewardId))
                        user.Inventory.equipItem[rewardId] = [];

                    if (user.Inventory.equipItem[rewardId].TryGetValue("1", out var existingEquip))
                    {
                        existingEquip.totalCount += count;
                        existingEquip.availableCount += count;
                    }
                    else
                    {
                        user.Inventory.equipItem[rewardId]["1"] = new EquipItemInfo
                        {
                            totalCount = count,
                            availableCount = count,
                            equipCommanderList = [],
                        };
                    }
                    DatabaseManager.GameProfile.UpdateEquipItemData(SessionId, user.Inventory.equipItem);
                    result.equipItem = user.Inventory.equipItem.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.ToDictionary(inner => int.Parse(inner.Key), inner => inner.Value));
                    result.itemData = user.Inventory.itemData;
                    break;

                case ERewardType.UnitMaterial:
                    if (!user.Inventory.partData.TryAdd(rewardId, count))
                        user.Inventory.partData[rewardId] += count;
                    DatabaseManager.GameProfile.UpdatePartData(SessionId, user.Inventory.partData);
                    result.partData = user.Inventory.partData;
                    result.itemData = user.Inventory.itemData;
                    break;

                case ERewardType.Commander:
                    if (!user.CommanderData.ContainsKey(rewardId))
                    {
                        var commander = CreateCommander(int.Parse(rewardId));

                        user.CommanderData[rewardId] = commander;

                        Dictionary<string, UserInformationResponse.Commander> addedCommander = new()
                        {
                            { rewardId, commander },
                        };

                        DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
                        result.commanderData = addedCommander;
                        result.itemData = user.Inventory.itemData;
                    }
                    else
                    {
                        // commander already owned, give 35 medals instead
                        if (!user.Inventory.medalData.TryAdd(rewardId, 35))
                            user.Inventory.medalData[rewardId] += 35;
                        DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
                        result.medalData = user.Inventory.medalData;
                        result.itemData = user.Inventory.itemData;
                    }
                    break;

                // TODO: EventItem, Commander, WeaponItem, Dormitory types require more complex logic
            }
        }
        private static UserInformationResponse.Commander CreateCommander(int commanderid)
        {
            var commanderRole = RemoteObjectManager.instance.regulation.commanderRoleDtbl.Find(x => x.Id == commanderid).Role;
            var costumeId = RemoteObjectManager.instance.regulation.commanderCostumeDtbl.FirstOrDefault(x => x.cid == commanderid).ctid;

            string commanderId = commanderid.ToString();
            var commanderGrade = RemoteObjectManager.instance.regulation.commanderDtbl.Find(x => x.id == commanderId).grade;
            //need to check if hero starts with other grades or cls

            string commmanderGrade = commanderGrade.ToString();


            UserInformationResponse.Commander __commander = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "0",
                __skv4 = "0",
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = commmanderGrade,
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = costumeId,
                eventCostume = [],
                equipItemInfo = [],
                equipWeaponInfo = [],
                favorPoint = 0,
                favr = 0,
                fvrd = 0,
                haveCostume = [costumeId],
                id = commanderId,
                marry = 0,
                medl = 0,
                role = commanderRole,
                transcendence = [0, 0, 0, 0],
            };

            return __commander;
        }
        private static T PickWeighted<T>(List<T> items, int[] weights)
        {
            int total = 0;
            for (int i = 0; i < Math.Min(items.Count, weights.Length); i++)
                total += weights[i];

            int roll = RandomGenerator.Shared.Next(0, total);
            int cumulative = 0;
            for (int i = 0; i < Math.Min(items.Count, weights.Length); i++)
            {
                cumulative += weights[i];
                if (roll < cumulative)
                    return items[i];
            }

            return items[^1];
        }
    }

    public class OpenItemRequest
    {
        [JsonProperty("ityp")]
        public EStorageType ityp { get; set; }

        [JsonProperty("tidx")]
        public int tidx { get; set; }

        [JsonProperty("amnt")]
        public int amnt { get; set; }

        [JsonProperty("rtyp")]
        public int rtyp { get; set; }

        [JsonProperty("ridx")]
        public int ridx { get; set; }
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
		if (result.rewardList !=null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.rewardList, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		ERewardType erewardType = (ERewardType)int.Parse(this._FindRequestProperty(request, "rtyp"));
		string text = this._FindRequestProperty(request, "ridx");
		if (erewardType = ERewardType.Commander)
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			if (roCommander !=null)
			{
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				if (uicommanderComplete !=null)
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
			if (result.commanderData !=null)
			{
				foreach (Protocols.UserInformationResponse.Commander commander in result.commanderData.Values)
				{
					RoCommander roCommander2 = this.localUser.FindCommander(commander.id);
					if (commander.haveCostume !=null && commander.haveCostume.Count > 0)
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