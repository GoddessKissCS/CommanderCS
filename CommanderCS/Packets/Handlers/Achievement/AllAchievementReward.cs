using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Achievement
{
    [Packet(Id = Method.AllAchievementReward)]
    public class AllAchievementReward : BaseMethodHandler<AllAchievementRewardRequest>
    {
        public override object Handle(AllAchievementRewardRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            user.Achievements ??= [];

            int currentTime = (int)TimeManager.CurrentEpoch;

            Dictionary<string, int> receiveAchievementIdx = [];
            List<RewardInfo.AchievementData> nextAchievementList = [];

            // Find all completed but not yet received achievements
            foreach (var kvp in user.Achievements)
            {
                if (kvp.Value.complete && !kvp.Value.received)
                {
                    kvp.Value.received = true;
                    kvp.Value.completeTime = currentTime;

                    // Parse back the idx from the key
                    string[] parts = kvp.Key.Split('_');
                    string idx = parts[0];
                    int sort = kvp.Value.sort;

                    receiveAchievementIdx[idx] = sort;

                    // Look for next achievement in chain
                    int idxInt = int.Parse(idx);
                    var next = RemoteObjectManager.instance.regulation.achievementDtbl.Find(
                        x => x.idx == idxInt && x.sort == sort + 1);

                    if (next != null)
                    {
                        string nextKey = $"{next.idx}_{next.sort}";
                        var nextProgress = user.Achievements.ContainsKey(nextKey) ? user.Achievements[nextKey] : null;

                        RewardInfo.AchievementData nextData = new()
                        {
                            achievementId = next.idx,
                            sort = next.sort,
                            point = nextProgress?.point ?? 0,
                            complete = nextProgress is { complete: true } ? 1 : 0,
                            receive = nextProgress is { received: true } ? 1 : 0,
                        };
                        nextAchievementList.Add(nextData);
                    }
                }
            }

            DatabaseManager.GameProfile.UpdateAchievements(SessionId, user.Achievements);

            var resource = UserResources2Resource(user.Resources);

            RewardInfo result = new()
            {
                reward = [],
                resource = resource,
                time = currentTime,
                receiveAchievementIdx = receiveAchievementIdx,
                nextAchievementList = nextAchievementList,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

            return response;
        }
    }

    public class AllAchievementRewardRequest
    {
    }
}

/*	// Token: 0x06005FAA RID: 24490 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6235", true, true)]
	public void AllAchievementReward()
	{
	}

	// Token: 0x06005FAB RID: 24491 RVA: 0x001AF4D4 File Offset: 0x001AD6D4
	private IEnumerator AllAchievementRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_DailyMission_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.RefreshRewardFromNetwork(result);
		foreach (KeyValuePair<string, int> keyValuePair in result.receiveAchievementIdx)
		{
			RoMission roMission = this.localUser.FindAchievement(keyValuePair.Key, keyValuePair.Value);
			this.localUser.badgeAchievementCount--;
			roMission.received = true;
			roMission.bListShow = false;
			roMission.completeTime = (double)result.time;
			this.localUser.achievementCompleteCount++;
		}
		if (this.localUser.badgeAchievementCount < 0)
		{
			this.localUser.badgeAchievementCount = 0;
		}
		if (result.nextAchievementList != null)
		{
			foreach (Protocols.RewardInfo.AchievementData achievementData in result.nextAchievementList)
			{
				RoMission roMission2 = this.localUser.FindAchievement(achievementData.achievementId.ToString(), achievementData.sort);
				if (roMission2 != null)
				{
					roMission2.bListShow = true;
					roMission2.received = achievementData.receive == 1;
					roMission2.combleted = achievementData.complete == 1;
					roMission2.conditionCount = achievementData.point;
					if (roMission2.combleted && !roMission2.received)
					{
						this.localUser.badgeAchievementCount++;
					}
				}
			}
		}
		UIManager.instance.world.warHome.Set(EReward.Achievement);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005FAC RID: 24492 RVA: 0x001AF4F8 File Offset: 0x001AD6F8
	private IEnumerator AllAchievementRewardError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		yield break;
	}*/
