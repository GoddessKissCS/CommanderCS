using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.KeepAlives
{
    public class Mission
    {
        
    }
}

/*	// Token: 0x06005FA0 RID: 24480 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1104", true, true)]
	public void Mission(List<string> type)
	{
	}

	// Token: 0x06005FA1 RID: 24481 RVA: 0x001AF3FC File Offset: 0x001AD5FC
	private IEnumerator MissionResult(JsonRpcClient.Request request, object result)
	{
		this._CheckReceiveTestData("MissionList");
		for (int i = 0; i < this.localUser.missionList.Count; i++)
		{
			if (this.localUser.missionList[i].level <= this.localUser.level)
			{
				this.localUser.missionList[i].bListShow = true;
			}
			if (this.localUser.missionList[i].VipCount > this.localUser.vipLevel)
			{
				this.localUser.missionList[i].bListShow = false;
			}
			this.localUser.missionList[i].received = false;
			this.localUser.missionList[i].combleted = false;
			this.localUser.missionList[i].conditionCount = 0;
		}
		if (result != null)
		{
			Protocols.MissionInfo missionInfo = this._ConvertJObject<Protocols.MissionInfo>(result);
			if (missionInfo != null)
			{
				this.localUser.missionCompleteCount = missionInfo.completeCount;
				this.localUser.missionGoal = missionInfo.goal;
				this.localUser.badgeMissionCount = 0;
				for (int j = 0; j < missionInfo.missionList.Count; j++)
				{
					RoMission roMission = this.localUser.FindMission(missionInfo.missionList[j].missionId.ToString());
					if (roMission != null)
					{
						roMission.received = missionInfo.missionList[j].receive == 1;
						roMission.combleted = missionInfo.missionList[j].complete == 1;
						roMission.conditionCount = missionInfo.missionList[j].point;
						if (roMission.combleted && !roMission.received)
						{
							this.localUser.badgeMissionCount++;
						}
					}
				}
			}
			Protocols.AchievementInfo achievementInfo = this._ConvertJObject<Protocols.AchievementInfo>(result);
			if (achievementInfo != null)
			{
				this.localUser.achievementCompleteCount = achievementInfo.completeCount;
				this.localUser.achievementGoal = achievementInfo.goal;
				this.localUser.badgeAchievementCount = 0;
				for (int k = 0; k < achievementInfo.AchievementList.Count; k++)
				{
					RoMission roMission2 = this.localUser.FindAchievement(achievementInfo.AchievementList[k].achievementId.ToString(), achievementInfo.AchievementList[k].sort);
					if (roMission2 != null)
					{
						roMission2.received = achievementInfo.AchievementList[k].receive == 1;
						roMission2.combleted = achievementInfo.AchievementList[k].complete == 1;
						roMission2.conditionCount = achievementInfo.AchievementList[k].point;
						if (roMission2.combleted && !roMission2.received)
						{
							this.localUser.badgeAchievementCount++;
						}
						roMission2.bListShow = true;
					}
				}
			}
			Protocols.UserInformationResponse userInformationResponse = this._ConvertJObject<Protocols.UserInformationResponse>(result);
			if (userInformationResponse != null)
			{
				this.localUser.FromNetwork(userInformationResponse);
			}
			UIManager.instance.RefreshOpenedUI();
		}
		UIManager.instance.world.warHome.Set(EReward.DailyMission);
		UIManager.instance.world.warHome.Open();
		yield break;
	}*/