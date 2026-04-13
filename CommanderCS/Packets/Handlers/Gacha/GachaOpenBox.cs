using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Gacha
{
    [Packet(Id = Method.GachaOpenBox)]
    public class GachaOpenBox : BaseMethodHandler<GachaOpenBoxRequest>
    {
        private static readonly Random _random = new();

        public override object Handle(GachaOpenBoxRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            List<GachaOpenBoxResponse.Reward> rewards = [];

            string gachaKey = request.gbIdx.ToString();
            GachaData gachaData = null;
            User.GachaInformation?.TryGetValue(gachaKey, out gachaData);

            if (User.TutorialData?.step != 6 && User.TutorialData?.skip == false)
            {
               rewards = GetTutorialRewards(request.gbIdx, User, rewards);
            } else
            {
                rewards = GetRandomGachaRewards(request.gbIdx, User, rewards, request.cnt, gachaData);
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            GachaInformationResponse ws = User.GachaInformation != null && User.GachaInformation.TryGetValue(gachaKey, out var currentGacha)
                ? GachaInformation.ToResponse(currentGacha)
                : new GachaInformationResponse();


            var userEquipData = Utility.ConvertEquipItem(User.Inventory.equipItem);

            GachaOpenBoxResponse gachaOpen = new()
            {
                changedGachaInformation = ws,
                rewardList = rewards,
                goodsResult = rsoc,
                costumeData = User.Inventory.costumeData,
                foodData = User.Inventory.foodData,
                partData = User.Inventory.partData,
                itemData = User.Inventory.itemData,
                medalData = User.Inventory.medalData,
                commanderIdDict = User.CommanderData,
                eventResourceData = User.Inventory.eventResourceData,
                equipItem = userEquipData
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = gachaOpen,
            };

            return response;
        }


        // complete pilot is 3.4%, the probability of drawing a costume is 7.14%, and the probability of drawing a medal is 89.45%
        private List<GachaOpenBoxResponse.Reward> GetTutorialRewards(int gbIdx, GameProfileScheme user, List<GachaOpenBoxResponse.Reward> rewards)
        {
            switch (gbIdx)
            {
                case 1:
                   // Tutorial step 6: give the player fixed starter rewards
                    rewards.Add(new() { count = 5, id = "8", type = ERewardType.Goods });
                    user.Inventory.itemData.Add("8", 5);
                    DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
                    return rewards;
                case 2:
                    rewards.Add(new() { count = 1, id = "2", type = ERewardType.Commander });
                    user.CommanderData = RemoteObjectManager.instance.regulation.AddSpecificCommander(user.CommanderData, 2);
                    DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
                    return rewards;
            }
            return rewards;
        }

        private List<GachaOpenBoxResponse.Reward> GetRandomGachaRewards(int gbIdx, GameProfileScheme user, List<GachaOpenBoxResponse.Reward> rewards, int count, GachaData gachaData)
        {
            // TODO: Replace placeholder logic with actual gacha tables

            string gachaBoxIndex = gbIdx.ToString();

            if (count == 1)
            {
                if (gachaData != null)
                {
                    // Recalculate in case the cooldown has expired since last check
                    GachaInformation.ToResponse(gachaData);

                    if (gachaData.freeOpenRemainCount > 0)
                    {

                        user.GachaInformation[gachaBoxIndex].lastFreeOpenTime = DateTime.UtcNow;
                        user.GachaInformation[gachaBoxIndex].freeOpenRemainCount = 0;
                    }
                }


            }

            for (int i = 0; i < count; i++)
            {
                switch (gbIdx)
                {
                    case 1:
                    {
                        user.GachaInformation[gachaBoxIndex].pilotRate += 1;
                         // Normal gacha - random items
                        string[] itemPool = ["1", "3", "5", "8", "10"];
                        string itemId = itemPool[_random.Next(itemPool.Length)];
                        int amount = _random.Next(1, 11);

                        rewards.Add(new() { count = amount, id = itemId, type = ERewardType.Item });

                        if (user.Inventory.itemData.ContainsKey(itemId))
                            user.Inventory.itemData[itemId] += amount;
                        else
                            user.Inventory.itemData[itemId] = amount;

                        break;
                    }
                    case 2:
                    {
                        // Premium gacha - chance for commander or medals
                        int roll = _random.Next(100);

                        if (gachaData.pilotRate >= 9)
                        {
                                //Now we gurantee an pilot
                                //or if we got on in a roll we remove the pity too
                                // but only on 10x if we dont drop a pilot we increase pity
                        }

                        if (roll < 5)
                        {
                            // 10% chance: commander
                            int[] commanderPool = [2, 3, 5, 7, 10];
                            int commanderId = commanderPool[_random.Next(commanderPool.Length)];
                            string commanderIdStringed = commanderId.ToString();

                            rewards.Add(new() { count = 1, id = commanderId.ToString(), type = ERewardType.Commander });
                                if (!user.CommanderData.ContainsKey(commanderIdStringed))
                                {
                                    user.CommanderData = RemoteObjectManager.instance.regulation.AddSpecificCommander(user.CommanderData, commanderId);
                                } else
                                {
                                    if (user.Inventory.medalData.ContainsKey(commanderIdStringed))
                                        user.Inventory.medalData[commanderIdStringed] += 60;
                                    else
                                        user.Inventory.medalData[commanderIdStringed] = 60;
                                }
                        }
                        else if (roll < 45)
                        {
                            user.GachaInformation[gachaBoxIndex].pilotRate += 1;
                                // 30% chance: medals
                            string[] medalPool = ["1", "2", "3", "5"];
                            string medalId = medalPool[_random.Next(medalPool.Length)];
                            int amount = _random.Next(5, 21);

                            rewards.Add(new() { count = amount, id = medalId, type = ERewardType.Medal });

                            if (user.Inventory.medalData.ContainsKey(medalId))
                                user.Inventory.medalData[medalId] += amount;
                            else
                                user.Inventory.medalData[medalId] = amount;
                        }
                        else
                        {
                            user.GachaInformation[gachaBoxIndex].pilotRate += 1;
                            // 60% chance: random items
                            string[] itemPool = ["1", "3", "5", "8", "10"];
                            string itemId = itemPool[_random.Next(itemPool.Length)];
                            int amount = _random.Next(1, 6);

                            rewards.Add(new() { count = amount, id = itemId, type = ERewardType.Item });

                            if (user.Inventory.itemData.ContainsKey(itemId))
                                user.Inventory.itemData[itemId] += amount;
                            else
                                user.Inventory.itemData[itemId] = amount;
                        }
                        break;
                    }
                }
            }

            // Persist all changes once after the loop
            DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
            DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
            DatabaseManager.GameProfile.UpdateGachaInformation(SessionId, user.GachaInformation);

            return rewards;
        }
    }

    public class GachaOpenBoxRequest
    {
        [JsonProperty("gbIdx")]
        public int gbIdx { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6312", true, true)]
	public void GachaOpenBox(int gbIdx, int cnt)
	{
	}

	// Token: 0x06005F61 RID: 24417 RVA: 0x001AEEDC File Offset: 0x001AD0DC
	private IEnumerator GachaOpenBoxResult(JsonRpcClient.Request request, Protocols.GachaOpenBoxResponse result)
	{
		this._CheckReceiveTestData("GachaOpenBox");
		this.localUser.RefreshGachaFromNetwork(result.changedGachaInformation);
		this.localUser.RefreshGoodsFromNetwork(result.goodsResult);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshCostumeFromNetwork(result.costumeData);
		this.localUser.RefreshUserEquipItemFromNetwork(result.equipItem);
		this.localUser.RefreshItemFromNetwork(result.foodData);
		string gachaId = this._FindRequestProperty(request, "gbIdx");
		if (UIManager.instance.world.gacha.isActive)
		{
			List<UIGacha.BoxData> list = new List<UIGacha.BoxData>();
			CommanderCompleteType getType = CommanderCompleteType.Undefined;
			result.rewardList.ForEach(delegate(Protocols.GachaOpenBoxResponse.Reward data)
			{
				if (data = null)
				{
					return;
				}
				EGachaAnimationType egachaAnimationType = EGachaAnimationType.Normal;
				GachaRewardDataRow gachaRewardDataRow = this.RemoteObjectManager.instance.regulation.gachaRewardDtbl.Find((GachaRewardDataRow row) => row.gachaType = gachaId && row.rewardType = data.type && row.rewardId = data.id);
				int num = 0;
				bool flag = false;
				if (data.type = ERewardType.Medal || data.type = ERewardType.Commander)
				{
					RoCommander roCommander2 = this.localUser.FindCommander(data.id);
					getType = ((roCommander2.state != ECommanderState.Nomal) ? CommanderCompleteType.Recruit : CommanderCompleteType.Transmission);
					num = data.count;
					if (data.type = ERewardType.Commander)
					{
						roCommander2.state = ECommanderState.Nomal;
					}
				}
				if (gachaRewardDataRow is not null)
				{
					if (gachaRewardDataRow.effectType = 1)
					{
						egachaAnimationType = EGachaAnimationType.RainBow;
					}
					else if (gachaRewardDataRow.effectType = 2)
					{
						egachaAnimationType = EGachaAnimationType.Premium;
					}
				}
				else if (data.type = ERewardType.Commander)
				{
					egachaAnimationType = EGachaAnimationType.RainBow;
				}
				list.Add(new UIGacha.BoxData
				{
					gachaType = egachaAnimationType,
					rewardType = data.type,
					rewardId = data.id,
					rewardCount = data.count,
					getType = getType,
					getCommanderMedal = num,
					isNew = flag
				});
			});
			if (result.commanderIdDict is not null)
			{
				foreach (Protocols.UserInformationResponse.Commander commander in result.commanderIdDict.Values)
				{
					RoCommander roCommander = this.localUser.FindCommander(commander.id);
					if (commander.haveCostume is not null && commander.haveCostume.Count > 0)
					{
						roCommander.haveCostumeList = commander.haveCostume;
					}
				}
			}
			UIManager.instance.world.gacha.OpenBox(list);
		}
		if (result.changedGachaInformation is not null && result.changedGachaInformation.type = "2" && result.changedGachaInformation.freeOpenRemainTime > 0)
		{
			this.ScheduleLocalPush(ELocalPushType.PremiumGachaFree, result.changedGachaInformation.freeOpenRemainTime);
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/

/*
public static string GachaOpenBox(Packet packet)
{
    GachaBoxOpenResult gacha = new();

    List<GachaOpenBoxResponse.Reward> rewards = new();

    int count = (int)packet.Parameters["cnt"];
    int GachaType = (int)packet.Parameters["gbIdx"];

    for (int i = 0; i > count; i++)
    {
        var reward = JsonParser.GachaReward(GachaType);
        JObject rewarded = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(reward));

        GachaOpenBoxResponse.Reward RealItem = new();

        ERewardType MN = (ERewardType)Enum.ToObject(typeof(ERewardType), (int)rewarded["rewardType"]);

        RealItem.id = (string)rewarded["rewardId"];
        RealItem.count = (int)rewarded["rewardCount"];
        RealItem.type = MN;

        rewards.Add(RealItem);
    }

    GachaOpenBoxResponse gachaOpen = new();
    gachaOpen.changedGachaInformation = new();
    gachaOpen.rewardList = rewards;
    gachaOpen.goodsResult = new();
    gachaOpen.costumeData = new();
    gachaOpen.foodData = new();
    gachaOpen.partData = new();
    gachaOpen.itemData = new();
    gachaOpen.medalData = new();
    gachaOpen.commanderIdDict = new();
    gachaOpen.commanderIdMedalDict = new();
    gachaOpen.eventResourceData = new();
    gachaOpen.equipItem = new();

    gacha.id = packet.id;
    gacha.result = gachaOpen;

    return Serialize(gacha);
}

*/