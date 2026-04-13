using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.DailyBonusCheck)]
    public class DailyBonusCheck : BaseMethodHandler<DailyBonusCheckRequest>
    {
        public override object Handle(DailyBonusCheckRequest request)
        {
            // ADD Daily list that clears every month
            // Check against which day it is today and give the apprioate response

            var user = GetUserGameProfile();

            DateTime currentDate = DateTime.Now;
            int currentDateInt = int.Parse(currentDate.ToString("yyyyMMdd"));
            int day = currentDate.Day;

            // Find the bonus entry matching today's day within the current date range
            var dailyBonus = user.DailyBonusCheck?.FirstOrDefault(x =>
                x.day == day
                && int.Parse(x.startTimeString) <= currentDateInt
                && int.Parse(x.endTimeString) >= currentDateInt);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}",
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