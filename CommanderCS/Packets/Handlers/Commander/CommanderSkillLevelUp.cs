using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CommanderCS.Packets.Handlers.Commander
{
	[Packet(Id = Method.CommanderSkillLevelUp)]
    public class CommanderSkillLevelUp : BaseMethodHandler<CommanderSkillLevelUpRequest>
    {
        public override object Handle(CommanderSkillLevelUpRequest @params)
        {
            var user = GetUserGameProfile();
            var session = GetSession();
            var rg = GetRegulation();

            string cid = @params.cid.ToString();

            int totalCost = 0;

            int skillIndex = @params.sidx;
            int upgradeLevel = @params.cnt;

            string upgradeLevelStringed = upgradeLevel.ToString();

            for (var i = 1; i <= upgradeLevel;)
            {
                var skillcostdtbl = rg.skillCostDtbl.Find(x => x.level == i);

                if (skillcostdtbl != null && skillIndex < skillcostdtbl.typeCost.Count)
                {
                    var cost = skillcostdtbl.typeCost[skillIndex - 1];
                    totalCost += cost;
                }

                i++;
            }

            switch (skillIndex)
            {
                case 1:
                    user.CommanderData[cid].__skv1 = upgradeLevelStringed;
                    break;
                case 2: 
                    user.CommanderData[cid].__skv2 = upgradeLevelStringed;
                    break;
                case 3:
                    user.CommanderData[cid].__skv3 = upgradeLevelStringed;
                    break;
                case 4:
                    user.CommanderData[cid].__skv4 = upgradeLevelStringed;
                    break;
            }

            user.UserResources.gold -= totalCost;

            DatabaseManager.GameProfile.UpdateGold(session, totalCost, false);
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
	public class CommanderSkillLevelUpRequest
	{
        [JsonProperty("cid")]
		public int cid { get; set; }

        [JsonProperty("sidx")]
        public int sidx { get; set; }

        [JsonProperty("cnt")]
        public int cnt { get; set; }
	}
}

/*public void CommanderSkillLevelUp(int cid, int sidx, int cnt)
	{
	}

	// Token: 0x06005F33 RID: 24371 RVA: 0x001AE97C File Offset: 0x001ACB7C
	private IEnumerator CommanderSkillLevelUpResult(JsonRpcClient.Request request, Protocols.UserInformationResponse result)
	{
		string text = this._FindRequestProperty(request, "cid");
		string text2 = this._FindRequestProperty(request, "sidx");
		int num = int.Parse(this._FindRequestProperty(request, "cnt"));
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			roCommander.SkillLevelUp(this._ConvertStringToInt(text2), num);
		}
		this.localUser.RefreshGoodsFromNetwork(result.goodsInfo);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}
*/