using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.Unit
{
    [Packet(Id = Method.UnitLevelUpImmediate)]
    public class UnitLevelUpImmediate : BaseMethodHandler<UnitLevelUpImmediateRequest>
    {
        public override object Handle(UnitLevelUpImmediateRequest @params)
        {
            ResponsePacket response = new()
            {
                Result = null,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class UnitLevelUpImmediateRequest
    {
        [JsonProperty("idx")]
        public int idx { get; set; }
    }

    public class UnitLevelUpImmediateResponse
    {
        [JsonProperty("cash")]
        public int cash { get; set; }
    }
}

/*
    [JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4302", true, true)]
	public void UnitLevelUpImmediate(int idx)
	{
	}

    private IEnumerator UnitLevelUpImmediateResult(JsonRpcClient.Request request, string result, int cash)
	{
		string text = this._FindRequestProperty(request, "idx");
		if (string.IsNullOrEmpty(text))
		{
			yield break;
		}
		RoUnit roUnit = this.localUser.FindUnit(text);
		roUnit.trainingTime.SetInvalidValue();
		this.localUser.cash = cash;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F46 RID: 24390 RVA: 0x001AEC78 File Offset: 0x001ACE78
	private IEnumerator UnitLevelUpImmediateError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}*/