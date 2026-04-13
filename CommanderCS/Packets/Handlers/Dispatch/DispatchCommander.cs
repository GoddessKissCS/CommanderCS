using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using static CommanderCS.Library.Protocols.GuildDispatchCommanderList;

namespace CommanderCS.Packets.Handlers.Dispatch
{
    [Packet(Id = Method.DispatchCommander)]
    public class DispatchCommander : BaseMethodHandler<DispatchCommanderRequest>
    {
        public override object Handle(DispatchCommanderRequest request)
        {
            var time = TimeManager.GetCurrentTime();

            DispatchedCommanderInfo commanderInfo = new()
            {
                cid = request.cid,
                engageCnt = 0,
                getGold = 0,
                runtime = 0,
                DispatchTime = time,
            };

            var slot = request.slot.ToString();

            Dictionary<string, DispatchedCommanderInfo> dispatchedcommanders = new()
            {
                { slot, commanderInfo }
            };

            DatabaseManager.GameProfile.UpdateDispatchedCommander(SessionId, dispatchedcommanders);

            // If the player is in a guild, push the commander into the guild's shared dispatch pool
            var user = GetUserGameProfile();
            var guild = GetUserGuild();

            if (guild !=null && user.CommanderData !=null)
            {
                user.CommanderData.TryGetValue(request.cid.ToString(), out var commander);

                if (commander !=null)
                {
                    GuildDispatchCommanderInfo guildCommanderInfo = new()
                    {
                        userIdx = user.Uno,
                        userLevel = user.Resources.level,
                        userName = user.Resources.nickname,
                        userThumbnail = user.Resources.thumbnailId.ToString(),
                        cid = request.cid,
                        level = int.Parse(commander.__level ?? "1"),
                        grade = int.Parse(commander.__rank ?? "1"),
                        cls = int.Parse(commander.__cls ?? "1"),
                        skillLv_1 = int.Parse(commander.__skv1 ?? "0"),
                        skillLv_2 = int.Parse(commander.__skv2 ?? "0"),
                        skillLv_3 = int.Parse(commander.__skv3 ?? "0"),
                        skillLv_4 = int.Parse(commander.__skv4 ?? "0"),
                        costumeIdx = commander.currentCostume,
                        favorStep = commander.favorStep,
                        marry = commander.marry,
                        transcendence = commander.transcendence ?? [],
                        possibleEngage = 3,
                        existEngaged = 0,
                        sp = 0,
                        dmghp = 0,
                        hp = 0,
                        equipItem = commander.equipItemInfo ?? [],
                        weaponItem = commander.equipWeaponInfo ?? [],
                    };

                    DatabaseManager.Guild.UpdateDispatchedGuildCommander(guild.GuildId, guildCommanderInfo);
                }
            }

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = dispatchedcommanders,
            };

            return response;
        }
    }

    public class DispatchCommanderRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("slot")]
        public int slot { get; set; }
    }
}

/*	// Token: 0x060060B5 RID: 24757 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7171", true, true)]
	public void DispatchCommander(int cid, int slot)
	{
	}

	// Token: 0x060060B6 RID: 24758 RVA: 0x001B0AC4 File Offset: 0x001AECC4
	private IEnumerator DispatchCommanderResult(JsonRpcClient.Request request, Dictionary<string, Protocols.DiapatchCommanderInfo> result)
	{
		RoLocalUser.SlotDispatchInfo slotDispatchInfo = new RoLocalUser.SlotDispatchInfo();
		foreach (KeyValuePair<string, Protocols.DiapatchCommanderInfo> keyValuePair in result)
		{
			slotDispatchInfo.SlotNum = keyValuePair.Key;
			slotDispatchInfo.dispatchCommanderInfo = keyValuePair.Value;
			if (!this.localUser.slotDispatchInfo.Contains(slotDispatchInfo))
			{
				this.localUser.slotDispatchInfo.Add(slotDispatchInfo);
			}
		}
		if (UIManager.instance.world.guild.dispatch !=null)
		{
			UIManager.instance.world.guild.dispatch.SetDispatchList();
		}
		yield break;
	}

	// Token: 0x060060B7 RID: 24759 RVA: 0x001B0AE8 File Offset: 0x001AECE8
	private IEnumerator DispatchCommanderError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			UIManager.instance.world.guild.CloseDispatchPopup();
			UIManager.instance.world.guild.Close();
		}
		yield break;
	}*/
