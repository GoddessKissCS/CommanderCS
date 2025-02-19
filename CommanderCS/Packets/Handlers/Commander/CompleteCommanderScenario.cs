using CommanderCS.Host;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using CommanderCSLibrary.Packets;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.Commander
{
	[Packet(Id = CommanderCSLibrary.Shared.Enum.Method.CompleteCommanderScenario)]
    public class CompleteCommanderScenario : BaseMethodHandler<CompleteCommanderScenarioRequest>
    {
        public override object Handle(CompleteCommanderScenarioRequest @params)
        {
			ResponsePacket response = new()
			{
				Id = BasePacket.Id,
				Result = new CommanderCSLibrary.Shared.Protocols.CompleteScenario()
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
					resource = UserResources2Resource(User.Resources)
				},
			};
			
			// Allows you to

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