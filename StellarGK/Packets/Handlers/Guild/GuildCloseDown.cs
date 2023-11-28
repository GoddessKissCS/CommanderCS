using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.Utils;

namespace CommanderCS.Packets.Handlers.Guild
{
	[Packet(Id = Method.GuildCloseDown)]
    public class GuildCloseDown : BaseMethodHandler<GuildCloseDownRequest>
    {
        public override object Handle(GuildCloseDownRequest @params)
        {
            var user = GetUserGameProfile();

            var closeTime = Utility.GetCurrentTimeInSeconds();

			DatabaseManager.Guild.CloseDownGuild(user.GuildId, closeTime);
			DatabaseManager.Guild.ResetMemberGrades(user.GuildId);

			var res = new GuildCloseDownResponse()
			{
				ctime = closeTime,
			};

            ResponsePacket response = new()
			{
				Id = BasePacket.Id,
				Result = res	
            };

			return response;
        }
    }

    public class GuildCloseDownRequest
    {
    }

    public class GuildCloseDownResponse
	{
		[JsonProperty("ctime")]
		public double ctime {  get; set; }	

    }

}

/*	// Token: 0x0600603E RID: 24638 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7214", true, true)]
	public void GuildCloseDown()
	{
	}

	// Token: 0x0600603F RID: 24639 RVA: 0x001B00EC File Offset: 0x001AE2EC
	private IEnumerator GuildCloseDownResult(JsonRpcClient.Request request, string result, double ctime)
	{
		this.localUser.guildInfo.closeTime = ctime;
		this.localUser.guildInfo.state = 1;
		this.localUser.guildInfo.memberGrade = 0;
		UIGuildManagePopup uiguildManagePopup = UnityEngine.Object.FindObjectOfType(typeof(UIGuildManagePopup)) as UIGuildManagePopup;
		if (uiguildManagePopup != null)
		{
			uiguildManagePopup.Close();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/