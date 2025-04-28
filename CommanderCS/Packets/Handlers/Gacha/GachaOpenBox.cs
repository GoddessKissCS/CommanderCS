using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Gacha
{
    [Packet(Id = Method.GachaOpenBox)]
    public class GachaOpenBox : BaseMethodHandler<GachaOpenBoxRequest>
    {
        public override object Handle(GachaOpenBoxRequest @params)
        {
            List<GachaOpenBoxResponse.Reward> rewards = [];

            GachaInformationResponse ws = new()
            {
                freeOpenRemainTime = 259200,
                freeOpenRemainCount = 0,
                pilotRate = 0,
                type = "2"
            };

            // TODO : ADD RANDOM RNG GENERATOR FOR LOOT AND IF ITS COMMANDER ADD IT TO THE USER IF NOT ADD MEDALS AND ETC

            // PUT THE GachaInformationResponse INTO GAMEPROFILESCHEME TO SEE IF USER X KEEPS ETC SHIT AND DO A

            switch (@params.gbIdx)
            {
                case 1:
                    rewards.Add(new() { count = 5, id = "8", type = ERewardType.Goods });
                    User.Inventory.itemData.Add("8", 5);
                    DatabaseManager.GameProfile.UpdateItemData(SessionId, User.Inventory.itemData);
                    break;

                case 2:
                    rewards.Add(new() { count = 1, id = "2", type = ERewardType.Commander });
                    User.CommanderData = Regulation.AddSpecificCommander(User.CommanderData, 2);
                    DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);
                    break;
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

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
                equipItem = User.Inventory.equipItem
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = gachaOpen,
            };

            return response;
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
				GachaRewardDataRow gachaRewardDataRow = this.regulation.gachaRewardDtbl.Find((GachaRewardDataRow row) => row.gachaType = gachaId && row.rewardType = data.type && row.rewardId = data.id);
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