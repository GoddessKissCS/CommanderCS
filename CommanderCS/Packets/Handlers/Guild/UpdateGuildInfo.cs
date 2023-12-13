using CommanderCS.Database;
using CommanderCS.Host;
using Newtonsoft.Json;
using CommanderCS.Enum.Packet;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.UpdateGuildInfo)]
    public class UpdateGuildInfo : BaseMethodHandler<UpdateGuildInfoRequest>
    {
        public override object Handle(UpdateGuildInfoRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();

            ErrorCode code = DatabaseManager.Guild.UpdateGuildInfo(@params.act, @params.val, session);

            if (code != ErrorCode.Success)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = code },
                    Id = BasePacket.Id,
                };
                return error;
            }

            var rsoc = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            Protocols.GuildInfo guildInfo = new()
            {
                resource = rsoc,
                guildInfo = guild,
                guildList = null,
                memberData = null,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = guildInfo,
            };

            return response;
        }
    }

    public class UpdateGuildInfoRequest
    {
        [JsonProperty("act")]
        public int act { get; set; }

        [JsonProperty("val")]
        public string val { get; set; }
    }
}

/*	// Token: 0x06006033 RID: 24627 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7213", true, true)]
	public void UpdateGuildInfo(int act, string val)
	{
	}

	// Token: 0x06006034 RID: 24628 RVA: 0x001AFFE8 File Offset: 0x001AE1E8
	private IEnumerator UpdateGuildInfoResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		UIGuildManagePopup uiguildManagePopup = UnityEngine.Object.FindObjectOfType(typeof(UIGuildManagePopup)) as UIGuildManagePopup;
		int num = int.Parse(this._FindRequestProperty(request, "act"));
		if (num = 0)
		{
			this.localUser.guildInfo.name = result.guildInfo.name;
			if (uiguildManagePopup != null)
			{
				uiguildManagePopup.SetChangeName(this.localUser.guildInfo.name);
			}
		}
		else if (num = 1)
		{
			this.localUser.guildInfo.emblem = result.guildInfo.emblem;
			if (uiguildManagePopup != null)
			{
				uiguildManagePopup.SetChangeEmblem(this.localUser.guildInfo.emblem);
			}
		}
		else if (num = 2)
		{
			this.localUser.guildInfo.limitLevel = result.guildInfo.limitLevel;
			if (uiguildManagePopup != null)
			{
				uiguildManagePopup.SetChangeMinLevel(this.localUser.guildInfo.limitLevel);
			}
		}
		else if (num = 3)
		{
			this.localUser.guildInfo.guildType = result.guildInfo.guildType;
			if (uiguildManagePopup != null)
			{
				uiguildManagePopup.SetChangeType(this.localUser.guildInfo.guildType);
			}
		}
		else if (num = 4)
		{
			this.localUser.guildInfo.notice = result.guildInfo.notice;
		}
		if (uiguildManagePopup != null)
		{
			uiguildManagePopup.SetGuildInof();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006035 RID: 24629 RVA: 0x001B0014 File Offset: 0x001AE214
	private IEnumerator UpdateGuildInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71005)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110021"));
		}
		else if (code = 71009)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110022"));
		}
		else if (code = 71007 || code = 71018)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110303"));
			UIManager.instance.world.guild.Close();
		}
		else
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), "Error Code:" + code);
		}
		yield break;
	}*/