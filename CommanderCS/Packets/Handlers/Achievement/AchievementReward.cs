using CommanderCS.Host;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Achievement
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.AchievementReward)]
    public class AchievementReward : BaseMethodHandler<AchievementRewardRequest>
    {
        public override object Handle(AchievementRewardRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = new RewardInfo()
            };

            return response;
        }
    }

    public class AchievementRewardRequest
    {
        [JsonProperty("acid")]
        public int acid { get; set; }

        [JsonProperty("asot")]
        public int asot { get; set; }
    }
}

/*	// Token: 0x06005FA8 RID: 24488 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6231", true, true)]
	public void AchievementReward(int acid, int asot)
	{
	}

	// Token: 0x06005FA9 RID: 24489 RVA: 0x001AF4A8 File Offset: 0x001AD6A8
	private IEnumerator AchievementRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "acid");
		int num = int.Parse(this._FindRequestProperty(request, "asot"));
		RoMission roMission = this.localUser.FindAchievement(text, num);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_DailyMission_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.badgeAchievementCount--;
		this.localUser.RefreshRewardFromNetwork(result);
		roMission.received = true;
		roMission.bListShow = false;
		roMission.completeTime = (double)result.time;
		if (result.nextAchievement is not null)
		{
			RoMission roMission2 = this.localUser.FindAchievement(result.nextAchievement.achievementId.ToString(), result.nextAchievement.sort);
			if (roMission2 is not null)
			{
				roMission2.bListShow = true;
				roMission2.received = result.nextAchievement.receive == 1;
				roMission2.combleted = result.nextAchievement.complete == 1;
				roMission2.conditionCount = result.nextAchievement.point;
				if (roMission2.combleted && !roMission2.received)
				{
					this.localUser.badgeAchievementCount++;
				}
			}
		}
		this.localUser.achievementCompleteCount++;
		UIManager.instance.world.warHome.Set(EReward.Achievement);
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("AchievementRewardResult");
		yield break;
	}*/