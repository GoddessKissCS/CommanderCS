using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.TranscendenceSkillUp)]
    public class TranscendenceSkillUp : BaseMethodHandler<TranscendenceSkillUpRequest>
    {
        public override object Handle(TranscendenceSkillUpRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();

            string cid = @params.cid.ToString();

            user.CommanderData[cid].transcendence[@params.slot - 1] += 1;

            user.UserInventory.medalData[cid] -= 10;

            DatabaseManager.GameProfile.UpdateMedalData(session, user.UserInventory.medalData);
            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);

            var goods = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);
            var battlestats = DatabaseManager.GameProfile.UserStatistics2BattleStatistics(user.UserStatistics);
            var guild = DatabaseManager.Guild.RequestGuild(user.GuildId, user.Uno);

            UserInformationResponse userInformationResponse = new()
            {
                goodsInfo = goods,
                battleStatisticsInfo = battlestats,
                uno = user.Uno.ToString(),
                stage = user.LastStage,
                notification = user.Notifaction,

                foodData = user.UserInventory.foodData,
                eventResourceData = user.UserInventory.eventResourceData,
                groupItemData = user.UserInventory.groupItemData,
                itemData = user.UserInventory.itemData,
                medalData = user.UserInventory.medalData,
                partData = user.UserInventory.partData,

                resetRemain = user.ResetDateTime, // should be set?

                equipItem = user.UserInventory.equipItem,

                donHaveCommCostumeData = user.UserInventory.donHaveCommCostumeData,
                completeRewardGroupIdx = user.CompleteRewardGroupIdx,
                guildInfo = guild,
                sweepClearData = user.BattleData.SweepClearData,
                preDeck = user.PreDeck,
                weaponList = user.UserInventory.weaponList,
                __commanderInfo = JObject.FromObject(user.CommanderData),
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = userInformationResponse,
            };

            return response;
        }
    }

    public class TranscendenceSkillUpRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }

        [JsonProperty("slot")]
        public int slot { get; set; }
    }
}

/*	// Token: 0x0600615D RID: 24925 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "4313", true, true)]
	public void TranscendenceSkillUp(int cid, int slot)
	{
	}

	// Token: 0x0600615E RID: 24926 RVA: 0x001B1894 File Offset: 0x001AFA94
	private IEnumerator TranscendenceSkillUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		this.localUser.FromNetwork(result);
		UIManager.instance.RefreshOpenedUI();
		yield return null;
		int slot = int.Parse(this._FindRequestProperty(request, "slot"));
		UITranscendencePopup obj = UnityEngine.Object.FindObjectOfType(typeof(UITranscendencePopup)) as UITranscendencePopup;
		if (obj != null)
		{
			obj.Set(slot);
		}
		yield break;
	}

	// Token: 0x0600615F RID: 24927 RVA: 0x001B18C0 File Offset: 0x001AFAC0
	private IEnumerator TranscendenceSkillUpError(JsonRpcClient.Request request, string result, int code)
	{
		NetworkAnimation.Instance.CreateFloatingText("Error code:" + code);
		yield break;
	}*/