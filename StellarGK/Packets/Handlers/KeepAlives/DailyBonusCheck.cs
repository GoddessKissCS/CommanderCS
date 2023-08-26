using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.KeepAlives
{
    [Packet(Id = MethodId.DailyBonusCheck)]
    public class DailyBonusCheck : BaseMethodHandler<DailyBonusCheckRequest>
    {
        public override object Handle(DailyBonusCheckRequest @params)
        {
#warning TODO
            // ADD Daily list that clears every month
            // Check against which day it is today and give the apprioate response

            DailyBonusCheckResponse DailyBonusCheckResponse = new()
            {
                day = 1,
                version = "1",
                goodsId = "1",
                goodsCount = 10,
                startTimeString = "1",
                endTimeString = "2",
                receiveState = 0,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = DailyBonusCheckResponse,
            };

            return response;
        }

    }

    public class DailyBonusCheckRequest
    {

    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6112", true, true)]
	public void DailyBonusCheck()
	{
	}

	// Token: 0x06005F5B RID: 24411 RVA: 0x001AEE70 File Offset: 0x001AD070
	private IEnumerator DailyBonusCheckResult(JsonRpcClient.Request request, Protocols.DailyBonusCheckResponse result)
	{
		this.localUser.RefreshDailyBonusFromNetwork(result);
		this._CheckReceiveTestData("DailyBonusCheck");
		UIDailyBonus dailyBonus = UIManager.instance.world.dailyBonus;
		if (!result.received)
		{
			dailyBonus.InitAndOpenDailyBonus();
		}
		else
		{
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}*/