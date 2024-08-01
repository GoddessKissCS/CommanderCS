using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.CreateGuild)]
    public class CreateGuild : BaseMethodHandler<CreateGuildRequest>
    {
        public override object Handle(CreateGuildRequest @params)
        {
            if (Misc.NameCheck(@params.gnm))
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.FederationNameContainsBadwordsOrIsInvalid },
                };

                return error;
            }

            var guild = DatabaseManager.Guild.FindByName(@params.gnm);

            if (guild is not null)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.FederationNameAlreadyExists },
                };

                return error;
            }

            GuildInfo createGuild = DatabaseManager.Guild.CreateGuild(SessionId, @params.gnm, @params.emb, @params.gtyp, @params.lvlm);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = createGuild,
            };

            return response;
        }
    }

    public class CreateGuildRequest
    {
        [JsonProperty("gnm")]
        public string gnm { get; set; }

        [JsonProperty("gtyp")]
        public int gtyp { get; set; }

        [JsonProperty("lvlm")]
        public int lvlm { get; set; }

        [JsonProperty("emb")]
        public int emb { get; set; }
    }
}

/*	// Token: 0x0600601F RID: 24607 RVA: 0x000492CD File Offset: 0x000474CD
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7212", true, true)]
	public void CreateGuild(string gnm, int gtyp, int lvlm, int emb)
	{
		this.tempNickName = this.localUser.nickname;
	}

	// Token: 0x06006020 RID: 24608 RVA: 0x001AFE40 File Offset: 0x001AE040
	private IEnumerator CreateGuildResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.RefreshGoodsFromNetwork(result.resource);
		this.localUser.RefreshGuildFromNetwork(result.guildInfo);
		if (result.memberData = null)
		{
			this.localUser.nickname = this.tempNickName;
			List<Protocols.GuildMember.MemberData> list = new List<Protocols.GuildMember.MemberData>();
			list.Add(new Protocols.GuildMember.MemberData
			{
				uno = int.Parse(this.localUser.uno),
				thumnail = int.Parse(this.localUser.thumbnailId),
				name = this.localUser.nickname,
				level = this.localUser.level,
				lastTime = 10.0,
				memberGrade = 1,
				world = this.localUser.world
			});
			UIManager.instance.world.guild.InitGuildMemberList(list);
		}
		else
		{
			UIManager.instance.world.guild.InitGuildMemberList(result.memberData);
		}
		for (int i = 0; i < this.localUser.guildSkillList.Count; i++)
		{
			this.localUser.guildSkillList[i].skillLevel = 0;
		}
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("112011"));
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06006021 RID: 24609 RVA: 0x001AFE64 File Offset: 0x001AE064
	private IEnumerator CreateGuildError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71005)
		{
			That Federation name already exists
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110021"));
		}
		else if (code = 71009)
		{
		You have entered an invalid word for a Federation name.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110022"));
		}
		else if (code = 71303)
		{
			You can join or send a request to join to only 1 Federation.
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110219"));
		}
		yield break;
	}*/