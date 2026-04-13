using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;

namespace CommanderCS.Packets.Handlers.Achievement
{
    [Packet(Id = Method.CompleteAchievement)]
    public class CompleteAchievement : BaseMethodHandler<CompleteAchievementRequest>
    {
        public override object Handle(CompleteAchievementRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            user.Achievements ??= [];

            int currentTime = (int)TimeManager.CurrentEpoch;

            List<CompleteAchievementInfo> completedList = [];

            foreach (var achievement in RemoteObjectManager.instance.regulation.achievementDtbl)
            {
                string key = $"{achievement.idx}_{achievement.sort}";

                if (user.Achievements.ContainsKey(key) && user.Achievements[key].complete)
                {
                    continue;
                }

                AchievementProgress progress = new()
                {
                    sort = achievement.sort,
                    point = 0,
                    complete = true,
                    received = false,
                    completeTime = currentTime,
                };

                user.Achievements[key] = progress;

                CompleteAchievementInfo info = new()
                {
                    achievementId = achievement.idx,
                    sort = achievement.sort,
                    time = currentTime,
                };
                completedList.Add(info);
            }

            DatabaseManager.GameProfile.UpdateAchievements(SessionId, user.Achievements);

            CompleteAchievementInfo[] completeAchievementInfosArray = completedList.ToArray();

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = completeAchievementInfosArray,
            };

            return response;
        }
    }

    public class CompleteAchievementRequest
    {
    }
}

/*	// Token: 0x06005FAD RID: 24493 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6132", true, true)]
	public void CompleteAchievement()
	{
	}

	// Token: 0x06005FAE RID: 24494 RVA: 0x001AF514 File Offset: 0x001AD714
	private IEnumerator CompleteAchievementResult(JsonRpcClient.Request request, Protocols.CompleteAchievementInfo[] result)
	{
		for (int i = 0; i < result.Length; i++)
		{
			RoMission roMission = this.localUser.FindAchievement(result[i].achievementId.ToString(), result[i].sort);
			if (roMission !=null)
			{
				roMission.received = true;
				roMission.completeTime = (double)result[i].time;
			}
		}
		this._CheckReceiveTestData("CompleteAchievementResult");
		yield break;
	}*/
