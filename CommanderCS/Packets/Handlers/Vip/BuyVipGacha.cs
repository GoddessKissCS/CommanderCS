using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static CommanderCS.Packets.Handlers.Vip.BuyVipGacha;

namespace CommanderCS.Packets.Handlers.Vip
{
	[Packet(Id = Method.BuyVipGacha)]
	public class BuyVipGacha : BaseMethodHandler<BuyVipGachaRequest>
	{
		public override object Handle(BuyVipGachaRequest request)
		{
			var user = GetUserGameProfile();

			var stored = user.ShopData.VipCruiseGacha;

			var available = stored.VipGachaInfoList
				.Where(x => x.Value.rewardRate == 1)
				.ToDictionary(x => x.Key, x => x.Value);


			//will be revamped in future to be better

			user.Resources.cash -= 800;
			DatabaseManager.GameProfile.UpdateOnlyCash(SessionId, 800, false);

            var slotEntry = PickWeightedSlot(available);
			var slot = slotEntry.Value;

			stored.gachaCount += 1;
			stored.VipGachaInfoList[slotEntry.Key].rewardRate = 0;

            VipGacha result = new()
            {
                VipGachaInfoList = stored.VipGachaInfoList,
                gachaCount = stored.gachaCount,
                refreshTime = Math.Max(0, stored.refreshTime - (int)TimeManager.CurrentEpoch),
                gacharesult =[
					new()
                    {
                        rewardType_result = (int)slot.rewardType,
                        rewardIdx_result = slot.rewardIdx,
                        rewardCount_result = slot.rewardCount,
                    }
				],
            };


            switch (slot.rewardType)
			{
				case ERewardType.Commander:
					var commanderId = slot.rewardIdx.ToString();
					if (!user.CommanderData.ContainsKey(commanderId))
					{
						var commander = CreateCommander(slot.rewardIdx);
						user.CommanderData[commanderId] = commander;
						DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);

                        user.CommanderData = [];
                        user.CommanderData[commanderId] = commander;
						result.commanderData = user.CommanderData;
                    }
					else
					{
						if (!user.Inventory.medalData.TryAdd(commanderId, 35))
							user.Inventory.medalData[commanderId] += 35;
						DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
						result.medalData = [];
                        result.medalData[commanderId] = slot.rewardCount;
                    }

					foreach (var key in stored.VipGachaInfoList.Keys.ToList())
						stored.VipGachaInfoList[key].rewardRate = 1;

					stored.gachaCount = 0;
					result.gachaCount = 0;
					break;

				case ERewardType.Medal:
					var medalKey = slot.rewardIdx.ToString();
					if (!user.Inventory.medalData.TryAdd(medalKey, slot.rewardCount))
						user.Inventory.medalData[medalKey] += slot.rewardCount;
					DatabaseManager.GameProfile.UpdateMedalData(SessionId, user.Inventory.medalData);
					result.medalData = [];
					result.medalData[medalKey] = slot.rewardCount;
					break;

				case ERewardType.Goods:

					switch (slot.rewardIdx)
					{
						case 3:
                            user.Resources.gold += slot.rewardCount;
                            DatabaseManager.GameProfile.UpdateGold(SessionId, slot.rewardCount, true);
							break;
						case 4:
                            user.Resources.gold += slot.rewardCount;
                            DatabaseManager.GameProfile.UpdateGold(SessionId, slot.rewardCount, true);
							break;
						case 5:
							user.Resources.bullet += slot.rewardCount;
							DatabaseManager.GameProfile.UpdateBullet(SessionId, slot.rewardCount, true);
							break;
						case 202:
							if (!user.Inventory.itemData.TryAdd("202", slot.rewardCount))
								user.Inventory.itemData["202"] += slot.rewardCount;
							DatabaseManager.GameProfile.UpdateItemData(SessionId, user.Inventory.itemData);
							break;
                    }
					break;
			}

			user = GetUserGameProfile();

			result.resource = UserResources2Resource(user.Resources);

            DatabaseManager.GameProfile.UpdateVipCruiseGacha(SessionId, stored);


			var response = new ResponsePacket
			{
				Id = BasePacket.Id,
				Result = result,
			};

			return response;
		}

		private static KeyValuePair<string, VipGacha.VipGachaInfo> PickWeightedSlot(Dictionary<string, VipGacha.VipGachaInfo> list)
		{
			float total = list.Values.Sum(x => x.rewardPoint);
			float roll = (float)(RandomGenerator.Shared.NextDouble() * total);

			float cumulative = 0f;
			foreach (var entry in list)
			{
				cumulative += entry.Value.rewardPoint;
				if (roll < cumulative)
					return entry;
			}

			return list.Last();
		}
		private UserInformationResponse.Commander CreateCommander(int commanderid)
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

		public class BuyVipGachaRequest
		{
		}
	}
}

/*	// Token: 0x060060B3 RID: 24755 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6313", true, true)]
	public void BuyVipGacah()
	{
	}

	// Token: 0x060060B4 RID: 24756 RVA: 0x001B0AA0 File Offset: 0x001AECA0
	private IEnumerator BuyVipGacahResult(JsonRpcClient.Request request, Protocols.VipGacha result)
	{
		List<Protocols.VipGacha.VipGachaResult> gacharesult = result.gacharesult;
		Protocols.RewardInfo.RewardData rewardData = new Protocols.RewardInfo.RewardData();
		List<Protocols.RewardInfo.RewardData> list = new List<Protocols.RewardInfo.RewardData>();
		ERewardType erewardType = ERewardType.Undefined;t
		int num = -1;
		for (int i = 0; i < this.localUser.gachaInfoList.Count; i++)
		{
			if (this.localUser.gachaInfoList[i].rewardType = gacharesult[0].rewardType_result && this.localUser.gachaInfoList[i].rewardIdx = gacharesult[0].rewardIdx_result)
			{
				num = this.localUser.gachaInfoList[i].rewardIdx;
				this.localUser.gachaInfoList[i].rewardRate--;
				erewardType = (ERewardType)gacharesult[0].rewardType_result;
				rewardData.rewardType = (ERewardType)gacharesult[0].rewardType_result;
				rewardData.rewardCnt = gacharesult[0].rewardCount_result;
				rewardData.rewardId = gacharesult[0].rewardIdx_result.ToString();
				list.Add(rewardData);
			}
		}
		if (erewardType = ERewardType.Commander)
		{
			RoCommander roCommander = RemoteObjectManager.instance.localUser.FindCommander(num.ToString());
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
				UIVipGachaContents vipGachaContents = UIManager.instance.world.vipGacha.vipGachaContents;
				if (vipGachaContents !=null)
				{
					vipGachaContents.UnRegisterEndPopup();
				}
				RemoteObjectManager.instance.RequestVipGachaInfo();
			}
		}
		else if (list !=null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(list, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshPartFromNetwork(result.partData);
		this.localUser.RefreshMedalFromNetwork(result.medalData);
		this.localUser.RefreshItemFromNetwork(result.itemData);
		this.localUser.AddCommanderFromNetwork(result.commanderData);
		this.localUser.RefreshItemFromNetwork(result.groupItemData);
		this.localUser.vipGachaCount = result.gachaCount;
		this.localUser.gachaInfoList.Clear();
		foreach (KeyValuePair<string, Protocols.VipGacha.VipGachaInfo> keyValuePair in result.VipGachaInfoList)
		{
			this.localUser.gachaInfoList.Add(keyValuePair.Value);
		}
		this.localUser.vipGachaCount = result.gachaCount;
		UIVipGachaContents vipGachaContents2 = UIManager.instance.world.vipGacha.vipGachaContents;
		if (vipGachaContents2 !=null)
		{
			UIManager.instance.world.vipGacha.vipGachaContents.Init(this.localUser.gachaInfoList);
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
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/
