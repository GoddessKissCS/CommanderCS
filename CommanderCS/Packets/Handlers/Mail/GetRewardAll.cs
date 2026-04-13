using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetRewardAll)]
    public class GetRewardAll : BaseMethodHandler<GetRewardAllRequest>
    {
#warning TODO NEEDS FURTHER CODE

        public override object Handle(GetRewardAllRequest request)
        {
            var user = GetUserGameProfile();

            // Collect rewards from all mails that have not been received yet
            var unreceived = user.MailDataList?
                .Where(m => m.__receive == "0" && m.reward != null && m.reward.Count > 0)
                .ToList();

            if (unreceived == null || unreceived.Count == 0)
            {
                ResponsePacket errorResponse = new()
                {
                    Id = BasePacket.Id,
                    Result = null,
                };

                return errorResponse;
            }

            // Gather all rewards from all unreceived mails
            List<RewardInfo.RewardData> allRewards = [];

            foreach (var mail in unreceived)
            {
                allRewards.AddRange(mail.reward);
                // Mark mail as received (keeps it in the DB but hides from player's mail list)
                DatabaseManager.GameProfile.MarkMailReceived(SessionId, mail.idx);
            }

            var rsoc = UserResources2Resource(user.Resources);

            RewardInfo rewardInfo = new()
            {
                reward = allRewards,
                resource = rsoc,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = rewardInfo,
            };

            return response;
        }
    }

    public class GetRewardAllRequest
    {
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6104", true, true)]
	public void GetRewardAll()
	{
	}

	// Token: 0x06005F74 RID: 24436 RVA: 0x001AF04C File Offset: 0x001AD24C
	private IEnumerator GetRewardAllResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		if (result.reward.Count < 1)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("7066"));
		}
		else
		{
			List<RoReward> list = new List<RoReward>();
			for (int i = this.localUser.rewardList.Count - 1; i >= 0; i--)
			{
				if (this.localUser.rewardList[i].type = EReward.Mail && (!string.IsNullOrEmpty(this.localUser.rewardList[i].rewardId) || this.localUser.rewardList[i].rewardItem != null))
				{
					RoReward roReward = this.localUser.rewardList[i];
					list.Add(roReward);
					this.localUser.rewardList.Remove(roReward);
					this.localUser.newMailCount--;
					this.localUser.badgeNewMailCount--;
				}
			}
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			this.localUser.RefreshRewardFromNetwork(result);
			UIManager.instance.world.mail.Set(EReward.Mail);
			UIManager.instance.RefreshOpenedUI();
			this._CheckReceiveTestData("GetRewardResult");
		}
		yield break;
	}*/