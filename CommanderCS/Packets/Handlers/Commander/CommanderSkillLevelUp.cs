using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

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
                    user.CommanderData[cid].__skv1 = (upgradeLevel + int.Parse(user.CommanderData[cid].__skv1)).ToString();
                    break;

                case 2:
                    user.CommanderData[cid].__skv2 = (upgradeLevel + int.Parse(user.CommanderData[cid].__skv2)).ToString();
                    break;

                case 3:
                    user.CommanderData[cid].__skv3 = (upgradeLevel + int.Parse(user.CommanderData[cid].__skv3)).ToString();
                    break;

                case 4:
                    user.CommanderData[cid].__skv4 = (upgradeLevel + int.Parse(user.CommanderData[cid].__skv4)).ToString();
                    break;
            }

            user.UserResources.gold -= totalCost;

            DatabaseManager.GameProfile.UpdateGold(session, totalCost, false);
            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = GetUserInformationResponse(user),
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