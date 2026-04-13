using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Gacha
{
    [Packet(Id = Method.GachaInformation)]
    public class GachaInformation : BaseMethodHandler<GachaInformationRequest>
    {
        private const int FreeOpenCooldownSeconds = 172800; // 48 hours

        public override object Handle(GachaInformationRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            var result = User.GachaInformation?.ToDictionary(
                kvp => kvp.Key,
                kvp => ToResponse(kvp.Value)
            );

            // ToResponse may have updated freeOpenRemainCount, persist changes
            DatabaseManager.GameProfile.UpdateGachaInformation(SessionId, User.GachaInformation);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = result,
            };

            return response;
        }

        public static GachaInformationResponse ToResponse(GachaData gachaData)
        {
            int remainTime = 0;

            if (gachaData.lastFreeOpenTime.HasValue)
            {
                double elapsed = (DateTime.UtcNow - gachaData.lastFreeOpenTime.Value).TotalSeconds;
                int remaining = FreeOpenCooldownSeconds - (int)elapsed;

                if (remaining > 0)
                {
                    remainTime = remaining;
                }
                else
                {
                    remainTime = 0;
                    gachaData.freeOpenRemainCount = 1;
                }
            }

            return new GachaInformationResponse
            {
                type = gachaData.type,
                freeOpenRemainCount = gachaData.freeOpenRemainCount,
                freeOpenRemainTime = remainTime,
                pilotRate = gachaData.pilotRate,
            };
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