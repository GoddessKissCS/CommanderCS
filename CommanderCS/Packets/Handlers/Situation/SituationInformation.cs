using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Situation
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.SituationInformation)]
    public class SituationInformation : BaseMethodHandler<SituationInformationRequest>
    {
        public override object Handle(SituationInformationRequest @params)
        {
            SituationInformationResponse InforeSponse = new();

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = InforeSponse,
            };

            return response;
        }
    }

    public class SituationInformationRequest
    {
    }

    public class SituationInformationResponse
    {
        [JsonProperty("did")]
        public int did { get; set; }

        [JsonProperty("rtm")]
        public int rtm { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3202", true, true)]
	public void SituationInformation()
	{
	}

	// Token: 0x06005F7C RID: 24444 RVA: 0x001AF0E4 File Offset: 0x001AD2E4
	private IEnumerator SituationInformationResult(JsonRpcClient.Request request, string result, int did, int rtm)
	{
		if (UIManager.instance.world != null)
		{
			if (!UIManager.instance.world.existSituation || !UIManager.instance.world.situation.isActive)
			{
				UIManager.instance.world.situation.InitAndOpenSituation();
			}
			UIManager.instance.world.situation.SetSweepEnable(did, rtm);
		}
		if (UIManager.instance.battle != null)
		{
			UIBattleResult battleResult = UIManager.instance.battle.BattleResult;
			battleResult.Open();
		}
		yield break;
	}*/