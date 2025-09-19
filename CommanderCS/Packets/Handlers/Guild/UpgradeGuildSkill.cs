using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Guild
{
    [Packet(Id = Method.UpgradeGuildSkill)]
    public class UpgradeGuildSkill : BaseMethodHandler<UpgradeGuildSkillRequest>
    {
        public override object Handle(UpgradeGuildSkillRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            GuildScheme Guild = GetUserGuild();

            var guildSkill = Guild.SkillDada.Where(d => d.idx == @params.gsid).FirstOrDefault();

            var upgradeSkill = RemoteObjectManager.instance.regulation.guildSkillDtbl.FirstOrDefault(x => x.level == guildSkill.level + 1);

            if (upgradeSkill.level < Guild.Level)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.HigherFederationLevelRequired },
                    Id = BasePacket.Id,
                };

                return error;
            }

            if (upgradeSkill.cost < Guild.Point)
            {
                ErrorPacket error = new()
                {
                    Error = new() { code = ErrorCode.HigherFederationLevelRequired },
                    Id = BasePacket.Id,
                };

                return error;
            }

            int index = Guild.SkillDada.FindIndex(skill => skill.idx == @params.gsid);

            if (index >= 0)
            {
                guildSkill.level += 1;
                Guild.SkillDada[index] = guildSkill;
            }

            Guild.Point -= upgradeSkill.cost;

            DatabaseManager.Guild.UpdateGuildSkill(User.GuildId, Guild.SkillDada, Guild.Point);

            var guildInfo = DatabaseManager.Guild.RequestGuild(User.GuildId, User.Uno);

            CommanderCS.Library.Protocols.GuildInfo guildList = new()
            {
                resource = null,
                guildInfo = guildInfo,
                memberData = null,
                guildList = null,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = guildList,
            };

            return response;
        }
    }

    public class UpgradeGuildSkillRequest
    {
        [JsonProperty("gsid")]
        public int gsid { get; set; }
    }
}

/*	// Token: 0x0600604C RID: 24652 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7220", true, true)]
	public void UpgradeGuildSkill(int gsid)
	{
	}

	// Token: 0x0600604D RID: 24653 RVA: 0x001B0250 File Offset: 0x001AE450
	private IEnumerator UpgradeGuildSkillResult(JsonRpcClient.Request request, Protocols.GuildInfo result)
	{
		this.localUser.guildInfo.point = result.guildInfo.point;
		using (List<Protocols.UserInformationResponse.UserGuild.GuildSkill>.Enumerator enumerator = result.guildInfo.skillDada.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Protocols.UserInformationResponse.UserGuild.GuildSkill list = enumerator.Current;
				this.localUser.guildSkillList.Find((RoGuildSkill skill) => skill.idx = list.idx).skillLevel = list.level;
			}
		}
		UIGuildManagePopup uiguildManagePopup = UnityEngine.Object.FindObjectOfType(typeof(UIGuildManagePopup)) as UIGuildManagePopup;
		if (uiguildManagePopup is not null)
		{
			uiguildManagePopup.OnRefresh();
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x0600604E RID: 24654 RVA: 0x001B0274 File Offset: 0x001AE474
	private IEnumerator UpgradeGuildSkillError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71014)
		{
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("110259"));
		}
		yield break;
	}*/