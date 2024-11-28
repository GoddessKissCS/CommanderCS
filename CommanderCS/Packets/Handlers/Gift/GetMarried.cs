using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Gift
{
    [Packet(Id = Method.GetMarried)]
    public class GetMarried : BaseMethodHandler<GetMarriedRequest>
    {
        public override object Handle(GetMarriedRequest @params)
        {
            string cid = @params.cid.ToString();

            User.CommanderData[cid].marry = 1;
            User.Resources.ring -= 1;

            DatabaseManager.GameProfile.UpdateCommanderMarriage(SessionId, User, User.CommanderData[cid]);
            UserInformationResponse userInformationResponse = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class GetMarriedRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}

/*	// Token: 0x0600612E RID: 24878 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4312", true, true)]
	public void GetMarried(int cid)
	{
	}

	// Token: 0x0600612F RID: 24879 RVA: 0x001B14B8 File Offset: 0x001AF6B8
	private IEnumerator GetMarriedResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		if (result.commanderInfo is not null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in result.commanderInfo)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(keyValuePair.Value.id);
				roCommander.marry = keyValuePair.Value.marry;
			}
		}
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		UIManager.instance.RefreshOpenedUI();
		CommanderScenarioDataRow commanderScenarioDataRow = this.regulation.FindCommanderScenario(text, 0);
		if (commanderScenarioDataRow is not null)
		{
			this.localUser.currScenario.scenarioId = commanderScenarioDataRow.csid;
			this.localUser.currScenario.commanderId = int.Parse(text);
			Loading.Load(Loading.Scenario);
		}
		yield break;
	}

	// Token: 0x06006130 RID: 24880 RVA: 0x001B14E4 File Offset: 0x001AF6E4
	private IEnumerator GetMarriedError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText("Error code:" + code);
		yield break;
	}*/