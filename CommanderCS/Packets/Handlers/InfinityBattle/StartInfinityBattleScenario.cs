using CommanderCS.Library;
using CommanderCS.Library.Enums;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    [Packet(Id = Method.StartInfinityBattleScenario)]
    public class StartInfinityBattleScenario : BaseMethodHandler<StartInfinityBattleScenarioRequest>
    {
        public override object Handle(StartInfinityBattleScenarioRequest request)
        {
            //var infinityField = RemoteObjectManager.instance.regulation.infinityFieldDtbl.Find(x => x.infinityFieldIdx == request.ifid.ToString());

            //if (infinityField == null)
            //{
            //    ErrorPacket error = new()
            //    {
            //        Id = BasePacket.Id,
            //        Error = new ErrorMessageId
            //        {
            //            code = ErrorCode.Failure
            //        }
            //    };

            //    return error;
            //}

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "false",
            };

            return response;
        }
    }

    public class StartInfinityBattleScenarioRequest
    {
        [JsonProperty("ifid")]
        public int ifid { get; set; }
    }
}

/*	// Token: 0x06006193 RID: 24979 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8703", true, true)]
	public void StartInfinityBattleScenario(int ifid)
	{
	}

	// Token: 0x06006194 RID: 24980 RVA: 0x001B1D2C File Offset: 0x001AFF2C
	private IEnumerator StartInfinityBattleScenarioResult(JsonRpcClient.Request request, string result)
	{
		if (!string.IsNullOrEmpty(result))
		{
			string text = this._FindRequestProperty(request, "ifid");
			InfinityFieldDataRow infinityFieldDataRow = this.RemoteObjectManager.instance.regulation.infinityFieldDtbl[text];
			this.localUser.currScenario.scenarioId = infinityFieldDataRow.scenarioIdx;
			this.localUser.currScenario.commanderId = 0;
			Loading.Load(Loading.Scenario);
		}
		yield break;
	}

	// Token: 0x06006195 RID: 24981 RVA: 0x001B1D58 File Offset: 0x001AFF58
	private IEnumerator StartInfinityBattleScenarioError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/