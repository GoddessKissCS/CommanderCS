using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCS.ExcelReader;
using System.ComponentModel;

namespace CommanderCS.Packets.Handlers.Guild
{

    [Packet(Id = Method.UpgradeGuildSkill)]
    public class UpgradeGuildSkill : BaseMethodHandler<UpgradeGuildSkillRequest> {

        public override object Handle(UpgradeGuildSkillRequest @params)
        {
			var user = GetUserGameProfile();

			var guild = DatabaseManager.Guild.FindByUid(user.GuildId);

			var guildSkill = guild.SkillDada.Where(d => d.idx == @params.gsid).FirstOrDefault();

			var upgradeCost = GuildSkillData.GetInstance().FromSkillLevel(guildSkill.level + 1);

			if(upgradeCost.cost > guild.Point)
			{
				ErrorPacket error = new()
				{
					Error = new() { code = ErrorCode.HigherFederationLevelRequired},
					Id = BasePacket.Id,
				};

				return error;
			}

            int index = guild.SkillDada.FindIndex(skill => skill.idx == @params.gsid);

            if (index >= 0)
            {
                guildSkill.level += 1;
                guild.SkillDada[index] = guildSkill;

            }

			guild.Point -= upgradeCost.cost;

            DatabaseManager.Guild.UpdateGuildSkill(user.GuildId, guild.SkillDada, guild.Point);

            var newGuild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            CommanderCS.Protocols.GuildInfo guildList = new()
            {
                resource = null,
                guildInfo = newGuild,
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
		if (uiguildManagePopup != null)
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