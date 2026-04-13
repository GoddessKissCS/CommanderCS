using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = CommanderCS.Library.Enums.Method.RecieveCommanderScenarioReward)]
    public class RecieveCommanderScenarioReward : BaseMethodHandler<RecieveCommanderScenarioRewardRequest>
    {
        public override object Handle(RecieveCommanderScenarioRewardRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            var resource = UserResources2Resource(user.Resources);

            string cid = request.cid.ToString();
            string sid = request.sid.ToString();

            var rewardData = RemoteObjectManager.instance.regulation.commanderScenarioRewardDtbl.Find(x => x.csid == request.sid && x.cid == cid);

            List<RewardInfo.RewardData> rewards = [];

            if (rewardData != null)
            {
                RewardInfo.RewardData reward = new()
                {
                    effect = 0,
                    rewardCnt = rewardData.rewardCount,
                    rewardId = rewardData.rewardIdx.ToString(),
                    rewardType = rewardData.rewardType
                };
                rewards.Add(reward);

                if (rewardData.rewardType == ERewardType.Costume)
                {
                    if (user.CommanderData.ContainsKey(cid))
                    {
                        if (!user.CommanderData[cid].haveCostume.Contains(rewardData.rewardIdx))
                        {
                            user.CommanderData[cid].haveCostume.Add(rewardData.rewardIdx);
                        }
                    }
                    else if (!user.Inventory.donHaveCommCostumeData.ContainsKey(cid))
                    {
                        user.Inventory.donHaveCommCostumeData.Add(cid, [rewardData.rewardIdx]);
                    }
                    else if (!user.Inventory.donHaveCommCostumeData[cid].Contains(rewardData.rewardIdx))
                    {
                        user.Inventory.donHaveCommCostumeData[cid].Add(rewardData.rewardIdx);
                    }

                    DatabaseManager.GameProfile.UpdateCommanderData(SessionId, user.CommanderData);
                    DatabaseManager.GameProfile.UpdateDontHaveCommanderCostumeData(SessionId, user.Inventory.donHaveCommCostumeData);
                }
                else if (rewardData.rewardType == ERewardType.Goods)
                {
                    DatabaseManager.GameProfile.UpdateGoldAndCash(SessionId, 0, rewardData.rewardCount, true);
                    user.Resources.cash += rewardData.rewardCount;
                }
            }

            if (user.CommanderScenario.ContainsKey(cid)
                && user.CommanderScenario[cid].ContainsKey(sid))
            {
                user.CommanderScenario[cid][sid].receive = 1;
                DatabaseManager.GameProfile.UpdateCommanderScenario(SessionId, user.CommanderScenario);
            }

            var updatedResource = UserResources2Resource(user.Resources);

            RecieveScenarioReward result = new()
            {
                reward = rewards,
                resource = updatedResource,
                commander = user.CommanderData,
                partData = user.Inventory.partData,
                medalData = user.Inventory.medalData,
                eventResourceData = user.Inventory.eventResourceData,
                itemData = user.Inventory.itemData,
                foodData = user.Inventory.foodData,
                costumeData = [],
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

            return response;
        }
    }

    public class RecieveCommanderScenarioRewardRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("sid")]
        public int sid { get; set; }
    }
}

/*	// Token: 0x060060E2 RID: 24802 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4311", true, true)]
	public void RecieveCommanderScenarioReward(int cid, int sid)
	{
	}

	// Token: 0x060060E3 RID: 24803 RVA: 0x001B0E70 File Offset: 0x001AF070
	private IEnumerator RecieveCommanderScenarioRewardResult(JsonRpcClient.Request request, Protocols.RecieveScenarioReward result)
	{
		if (result is not null)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup is not null)
			{
				scenarioResultPopup.Init(result.reward, false);
			}
			this.localUser.RefreshGoodsFromNetwork(result.resource);
			this.localUser.RefreshPartFromNetwork(result.partData);
			this.localUser.RefreshItemFromNetwork(result.eventResourceData);
			this.localUser.RefreshItemFromNetwork(result.itemData);
			this.localUser.RefreshMedalFromNetwork(result.medalData);
			this.localUser.AddCommanderFromNetwork(result.commander);
			this.localUser.RefreshCostumeFromNetwork(result.costumeData);
			this.localUser.RefreshItemFromNetwork(result.foodData);
			UIManager.instance.RefreshOpenedUI();
			yield break;
		}
		yield break;
	}*/
