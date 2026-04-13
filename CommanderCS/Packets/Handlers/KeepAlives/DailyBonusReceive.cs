using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.KeepAlives
{
    [Packet(Id = Method.DailyBonusReceive)]
    public class DailyBonusReceive : BaseMethodHandler<DailyBonusReceiveRequest>
    {
        public override object Handle(DailyBonusReceiveRequest request)
        {
            var user = GetUserGameProfile();

            DateTime currentDate = DateTime.Now;
            int currentDateInt = int.Parse(currentDate.ToString("yyyyMMdd"));
            int day = currentDate.Day;

            // Find the bonus entry matching today's day within the current date range
            var dailyBonus = user.DailyBonusCheck?.FirstOrDefault(x =>
                x.day == day
                && int.Parse(x.startTimeString) <= currentDateInt
                && int.Parse(x.endTimeString) >= currentDateInt);

            if (dailyBonus == null || dailyBonus.receiveState == 1)
            {
                ResponsePacket errorResponse = new()
                {
                    Id = BasePacket.Id,
                    Result = null,
                };

                return errorResponse;
            }

            // Look up the goods info from the regulation table
            var goods = RemoteObjectManager.instance.regulation.FindGoodsServerType(dailyBonus.goodsId);

            int rewardCount = dailyBonus.goodsCount;

            // Look up VIP multiplier from regulation data
            var bonusDataRow = RemoteObjectManager.instance.regulation.dailyBonusRewardDtbl
                .FirstOrDefault(r => r.day == dailyBonus.day
                    && r.startTime.ToString() == dailyBonus.startTimeString
                    && r.endTime.ToString() == dailyBonus.endTimeString);

            if (bonusDataRow != null && bonusDataRow.vipLevel > 0 && user.Resources.vipLevel >= bonusDataRow.vipLevel)
            {
                rewardCount *= bonusDataRow.multiply;
            }

            string rewardId = bonusDataRow.goodsId.ToString();

            List<RewardInfo.RewardData> rewards =
            [
                new()
                {
                    rewardType = bonusDataRow.rewardType,
                    rewardId = rewardId,
                    rewardCnt = rewardCount,
                }
            ];

            // Mark today's bonus as received
            dailyBonus.receiveState = 1;
            DatabaseManager.GameProfile.UpdateDailyBonusCheck(SessionId, user.DailyBonusCheck);

            var rsoc = UserResources2Resource(user.Resources);

            RewardInfo rewardInfo = new()
            {
                reward = rewards,
                resource = rsoc,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "{}"
            };

            return response;
        }
    }

    public class DailyBonusReceiveRequest
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6213", true, true)]
	public void DailyBonusReceive()
	{
	}

	// Token: 0x06005F5D RID: 24413 RVA: 0x001AEE94 File Offset: 0x001AD094
	private IEnumerator DailyBonusReceiveResult(JsonRpcClient.Request request, Protocols.RewardInfo reward)
	{
		if (reward.commander is not null)
		{
			foreach (KeyValuePair<string, Protocols.UserInformationResponse.Commander> keyValuePair in reward.commander)
			{
				Protocols.UserInformationResponse.Commander value = keyValuePair.Value;
				RoCommander roCommander = this.localUser.FindCommander(value.id);
				CommanderCompleteType commanderCompleteType = ((roCommander.state != ECommanderState.Nomal) ? CommanderCompleteType.Recruit : CommanderCompleteType.Transmission);
				UICommanderComplete uicommanderComplete = UIPopup.Create<UICommanderComplete>("CommanderComplete");
				uicommanderComplete.Init(commanderCompleteType, value.id);
			}
		}
		else
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(reward.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		}
		this.localUser.RefreshRewardFromNetwork(reward);
		this.localUser.dailyBonus.isReceived = true;
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("DailyBonusReceive");
		yield break;
	}*/