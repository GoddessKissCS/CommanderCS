using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.DelegatingGuild)]
    public class DelegatingGuild : BaseMethodHandler<DelegatingGuildRequest>
    {
        public override object Handle(DelegatingGuildRequest @params)
        {
            bool isInGuild = DatabaseManager.Guild.IsUnoInMemberData(User.GuildId, User.Uno);

            if (!isInGuild)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.YouAlreadyLeftTheFederation },
                    Id = BasePacket.Id,
                };

                return error;
            }

            DatabaseManager.Guild.AppointNewGuildMaster(User.GuildId, User.Uno, @params.tuno);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "accepted",
            };

            return response;
        }
    }

    public class DelegatingGuildRequest
    {
        [JsonProperty("tuno")]
        public int tuno { get; set; }
    }
}

/*	// Token: 0x06006040 RID: 24640 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7215", true, true)]
	public void DelegatingGuild(int tuno)
	{
	}

	// Token: 0x06006041 RID: 24641 RVA: 0x001B0110 File Offset: 0x001AE310
	private IEnumerator DelegatingGuildResult(JsonRpcClient.Request request, string result)
	{
		int num = int.Parse(this._FindRequestProperty(request, "tuno"));
		this.localUser.guildInfo.memberGrade = 0;
		UIManager.instance.world.guild.DelegationGildMaster(num);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006042 RID: 24642 RVA: 0x001B0134 File Offset: 0x001AE334
	private IEnumerator DelegatingGuildError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			int num = int.Parse(this._FindRequestProperty(request, "tuno"));
			UIManager.instance.world.guild.RemoveMemberList(num);
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110228"));
		}
		yield break;
	}*/