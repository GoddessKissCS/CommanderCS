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
            string cid = @params.CommanderId.ToString();

            int totalCost = 0;

            for (var i = 1; i <= @params.Count;)
            {
                var skillcostdtbl = Regulation.skillCostDtbl.Find(x => x.level == i);

                if (skillcostdtbl != null && @params.skillIndex < skillcostdtbl.typeCost.Count)
                {
                    var cost = skillcostdtbl.typeCost[@params.skillIndex - 1];
                    totalCost += cost;
                }

                i++;
            }


            switch (@params.skillIndex)
            {
                case 1:
                    User.CommanderData[cid].__skv1 = (int.Parse(User.CommanderData[cid].__skv1) + @params.Count).ToString();
                    break;

                case 2:
                    User.CommanderData[cid].__skv2 = (int.Parse(User.CommanderData[cid].__skv2 + @params.Count).ToString());
                    break;

                case 3:
                    User.CommanderData[cid].__skv3 = (int.Parse(User.CommanderData[cid].__skv3) + @params.Count).ToString();
                    break;

                case 4:
                    User.CommanderData[cid].__skv4 = (int.Parse(User.CommanderData[cid].__skv4) + @params.Count).ToString();
                    break;
            }

            User.UserResources.gold -= totalCost;

            DatabaseManager.GameProfile.UpdateGold(SessionId, totalCost, false);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = GetUserInformationResponse(User),
            };

            return response;
        }
    }

    public class CommanderSkillLevelUpRequest
    {
        [JsonProperty("cid")]
        public int CommanderId { get; set; }

        [JsonProperty("sidx")]
        public int skillIndex { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }
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