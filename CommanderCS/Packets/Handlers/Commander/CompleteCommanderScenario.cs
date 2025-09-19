using Amazon.Runtime.Internal.Transform;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = CommanderCS.Library.Enums.Method.CompleteCommanderScenario)]
    public class CompleteCommanderScenario : BaseMethodHandler<CompleteCommanderScenarioRequest>
    {
        public override object Handle(CompleteCommanderScenarioRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            var resc = UserResources2Resource(User.Resources);

            string cid = @params.cid.ToString();
            string sid = @params.sid.ToString();
            string sqid = @params.sqid.ToString();

			var scenario = new CommanderScenario() { complete = new() { sqid }, receive = 0 };


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
                    reward = [],
                    duelScoreData = [],
                    resource = resc,
                }
            };



            if (User.CommanderScenario != null)
            {
                if (!User.CommanderScenario.ContainsKey(cid))
                {
                    var commandescen = new Dictionary<string, CommanderScenario>
                    {
                        { sid, scenario }
                    };

                    User.CommanderScenario[cid] = commandescen;
                }

				if (User.CommanderScenario[cid].ContainsKey(sid))
				{
					return response;
				}

                User.CommanderScenario[cid][sid] = scenario;
            }


			DatabaseManager.GameProfile.UpdateCommanderScenario(SessionId, User.CommanderScenario);


			//if (User.CommanderScenario[@params.cid + ""][@params.sid + ""].complete.Contains(@params.sqid + "")) {
			//    return response;
			//}



            // Allows you to complete scenarios? and gives you shit if you complete x

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
		if (result is not null)
		{
			ScenarioResultPopup scenarioResultPopup = UIPopup.Create<ScenarioResultPopup>("ScenarioResultPopup");
			if (scenarioResultPopup is not null)
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
			if (scenarioResultPopup is not null)
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