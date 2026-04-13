using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Mail
{
    [Packet(Id = Method.GetReward)]
    public class GetReward : BaseMethodHandler<GetRewardRequest>
    {
        public override object Handle(GetRewardRequest request)
        {
            var user = GetUserGameProfile();

            var mail = user.MailDataList?.FirstOrDefault(m => m.idx == request.idx);

            if (mail?.reward == null || mail.reward.Count == 0)
            {
                ResponsePacket errorResponse = new()
                {
                    Id = BasePacket.Id,
                    Result = null,
                };

                return errorResponse;
            }

            // Mark mail as received (keeps it in the DB but hides from player's mail list)
            DatabaseManager.GameProfile.MarkMailReceived(SessionId, request.idx);

            var rsoc = UserResources2Resource(user.Resources);

            RewardInfo rewardInfo = new()
            {
                reward = mail.reward,
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

    public class GetRewardRequest
    {
        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }
    }
}

/*[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6102", true, true)]
	public void GetReward(int idx, int type)
	{
	}

	// Token: 0x06005F70 RID: 24432 RVA: 0x001AEFF4 File Offset: 0x001AD1F4
	private IEnumerator GetRewardResult(JsonRpcClient.Request request, Protocols.RewardInfo result)
	{
		string text = this._FindRequestProperty(request, "idx");
		RoReward roReward = this.localUser.FindReward(text);
		UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
		SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
		this.localUser.rewardList.Remove(roReward);
		this.localUser.newMailCount--;
		this.localUser.badgeNewMailCount--;
		this.localUser.RefreshRewardFromNetwork(result);
		UIManager.instance.world.mail.Set(EReward.Mail);
		UIManager.instance.RefreshOpenedUI();
		this._CheckReceiveTestData("GetRewardResult");
		yield break;
	}*/