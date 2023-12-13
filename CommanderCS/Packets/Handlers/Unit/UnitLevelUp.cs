using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.Unit
{
    [Packet(Id = Method.UnitLevelUp)]
    public class UnitLevelUp : BaseMethodHandler<UnitLevelUpRequest>
    {
        public override object Handle(UnitLevelUpRequest @params)
        {
            ResponsePacket response = new()
            {
                Result = null,
                Id = BasePacket.Id
            };

            return response;
        }
    }

    public class UnitLevelUpRequest
    {
        [JsonProperty("idx")]
        public int idx { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4301", true, true)]
	public void UnitLevelUp(int idx)
	{
	}

	// Token: 0x06005F42 RID: 24386 RVA: 0x001AEC04 File Offset: 0x001ACE04
	private IEnumerator UnitLevelUpResult(JsonRpcClient.Request request, Protocols.UnitLevelUpResponse result)
	{
		this.localUser.gold = (int)Math.Min(result.gold, 2147483647L);
		if (result.blueprintArmy >= 0)
		{
			this.localUser.blueprintArmy = result.blueprintArmy;
		}
		if (result.blueprintNavy >= 0)
		{
			this.localUser.blueprintNavy = result.blueprintNavy;
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F43 RID: 24387 RVA: 0x001AEC28 File Offset: 0x001ACE28
	private IEnumerator UnitLevelUpError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}*/