using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Achievement
{
    [Packet(Id = Method.CompleteAchievement)]
    public class CompleteAchievement : BaseMethodHandler<CompleteAchievementRequest>
    {
        public override object Handle(CompleteAchievementRequest @params)
        {
            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = Array.Empty<CompleteAchievementInfo>(),
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
			if (roMission is not null)
			{
				roMission.received = true;
				roMission.completeTime = (double)result[i].time;
			}
		}
		this._CheckReceiveTestData("CompleteAchievementResult");
		yield break;
	}*/