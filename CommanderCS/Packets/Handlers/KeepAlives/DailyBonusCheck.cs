using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Protocols;

namespace CommanderCS.Host.Handlers.KeepAlives
{
    [Packet(Id = Method.DailyBonusCheck)]
    public class DailyBonusCheck : BaseMethodHandler<DailyBonusCheckRequest>
    {
        public override object Handle(DailyBonusCheckRequest @params)
        {
#warning TODO
            // ADD Daily list that clears every month
            // Check against which day it is today and give the apprioate response

            //DateTime currentDate = DateTime.Now;
            //DateTime startOfMonth = new(currentDate.Year, currentDate.Month, 1);
            //int day = currentDate.Day;
            //int startOfMonthAsInt = int.Parse(startOfMonth.ToString("yyyyMMdd"));

            //var dailybonus = DailyBonusData.GetInstance().FromDay(day, startOfMonthAsInt);

            DailyBonusCheckResponse DailyBonusCheckResponse = new()
            {
                day = 1,
                version = "49",
                goodsId = "3",
                goodsCount = 400,
                startTimeString = "2023101",
                endTimeString = "20231130",
                receiveState = 1,
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