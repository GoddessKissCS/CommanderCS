using CommanderCS.Protocols;

namespace CommanderCS.Host.Handlers.Gacha
{
    [Packet(Id = Method.GachaInformation)]
    public class GachaInformation : BaseMethodHandler<GachaInformationRequest>
    {
        public override object Handle(GachaInformationRequest @params)
        {
            ResponsePacket response = new();

            Dictionary<string, GachaInformationResponse> test = new();

            GachaInformationResponse w = new()
            {
                freeOpenRemainTime = 0,
                freeOpenRemainCount = 0,
                pilotRate = 1,
                type = "1"
            };

            test.Add("1", w);

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