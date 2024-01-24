using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.Gacha
{
    [Packet(Id = Method.GachaInformation)]
    public class GachaInformation : BaseMethodHandler<GachaInformationRequest>
    {
        public override object Handle(GachaInformationRequest @params)
        {
            ResponsePacket response = new();

            Dictionary<string, GachaInformationResponse> test = [];

            GachaInformationResponse w = new()
            {
                freeOpenRemainTime = 0,
                freeOpenRemainCount = 1,
                pilotRate = 1,
                type = "1"
            };

            GachaInformationResponse ws = new()
            {
                freeOpenRemainTime = 0,
                freeOpenRemainCount = 1,
                pilotRate = 0,
                type = "2"
            };

            test.Add("1", w);
            test.Add("2", ws);

            response.Id = BasePacket.Id;
            response.Result = test;

            return response;
        }
    }

    public class GachaInformationRequest
    {
    }
}

/*// Token: 0x06005F5E RID: 24414 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6311", true, true)]
	public void GachaInformation()
	{
	}

	// Token: 0x06005F5F RID: 24415 RVA: 0x001AEEB8 File Offset: 0x001AD0B8
	private IEnumerator GachaInformationResult(JsonRpcClient.Request request, Dictionary<string, Protocols.GachaInformationResponse> result)
	{
		this._CheckReceiveTestData("GachaInformation");
		foreach (Protocols.GachaInformationResponse gachaInformationResponse in result.Values)
		{
			this.localUser.RefreshGachaFromNetwork(gachaInformationResponse);
		}
		if (!UIManager.instance.world.existGacha || !UIManager.instance.world.gacha.isActive)
		{
			UIManager.instance.world.gacha.InitAndOpenGacha();
		}
		else
		{
			UIManager.instance.world.gacha.RefreshGacha();
		}
		yield break;
	}*/