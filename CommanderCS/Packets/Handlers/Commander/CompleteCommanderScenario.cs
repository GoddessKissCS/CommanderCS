using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CompleteCommanderScenario)]
    public class CompleteCommanderScenario : BaseMethodHandler<CompleteCommanderScenarioRequest>
    {
        public override object Handle(CompleteCommanderScenarioRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            string cid = request.cid.ToString();
            string sid = request.sid.ToString();
            string sqid = request.sqid.ToString();

            int medalAmount = 5;
            if (!User.Inventory.medalData.TryAdd(cid, medalAmount))
                User.Inventory.medalData[cid] += medalAmount;

            DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);

            if (!User.CommanderScenario.ContainsKey(cid))
            {
                User.CommanderScenario[cid] = new Dictionary<string, CommanderScenario>();
            }

            if (!User.CommanderScenario[cid].ContainsKey(sid))
            {
                User.CommanderScenario[cid][sid] = new CommanderScenario() { complete = [], receive = 0 };
            }

            var existing = User.CommanderScenario[cid][sid];

            if (!existing.complete.Contains(sqid))
            {
                existing.complete.Add(sqid);
            }

            DatabaseManager.GameProfile.UpdateCommanderScenario(SessionId, User.CommanderScenario);

            var resc = UserResources2Resource(User.Resources);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new CompleteScenario()
                {
                    commander = User.CommanderData,
                    costumeData = User.Inventory.costumeData,
                    foodData = User.Inventory.foodData,
                    medalData = User.Inventory.medalData,
                    itemData = User.Inventory.itemData,
                    partData = User.Inventory.partData,
                    eventResourceData = User.Inventory.eventResourceData,
                    reward =
                    [
                        new()
                        {
                            rewardType = ERewardType.Medal,
                            rewardId = cid,
                            rewardCnt = medalAmount,
                            effect = 0,
                        }
                    ],
                    duelScoreData = [],
                    resource = resc,
                }
            };

            return response;
        }
    }

    public class CompleteCommanderScenarioRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("sid")]
        public int sid { get; set; }

        [JsonProperty("sqid")]
        public int sqid { get; set; }
    }
}

/*	// Token: 0x060060DF RID: 24799 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4310", true, true)]
	public void CompleteCommanderScenario(int cid, int sid, int sqid)
	{
	}

	// Token: 0x060060E0 RID: 24800 RVA: 0x001B0E28 File Offset: 0x001AF028
	private IEnumerator CompleteCommanderScenarioResult(JsonRpcClient.Request request, Protocols.CompleteScenario result)
	{
		if (result !=null)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup !=null)
			{
				scenarioResultPopup.Init(result.reward, false);
			}
			scenarioResultPopup.onClose = delegate
			{
				this.waitingScenarioComplete = false;
			};
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
		this.waitingScenarioComplete = false;
		yield break;
	}

	// Token: 0x060060E1 RID: 24801 RVA: 0x001B0E4C File Offset: 0x001AF04C
	private IEnumerator CompleteCommanderScenarioError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 30111)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup !=null)
			{
				scenarioResultPopup.Init(null, true);
			}
			scenarioResultPopup.onClose = delegate
			{
				this.waitingScenarioComplete = false;
			};
		}
		else
		{
			this.waitingScenarioComplete = false;
		}
		yield break;
	}*/