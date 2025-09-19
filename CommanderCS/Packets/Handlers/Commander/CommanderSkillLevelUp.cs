using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation.DataRows;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CommanderSkillLevelUp)]
    public class CommanderSkillLevelUp : BaseMethodHandler<CommanderSkillLevelUpRequest>
    {
        public override object Handle(CommanderSkillLevelUpRequest @params)
        {
            GameProfileScheme User = GetUserGameProfile();

            string cid = @params.CommanderId.ToString();
            var skillCostDtbl = RemoteObjectManager.instance.regulation.skillCostDtbl;
            int skillIndex = @params.skillIndex;
            int count = @params.Count;

            int currentSkillLevel = skillIndex switch
            {
                1 => int.Parse(User.CommanderData[cid].__skv1),
                2 => int.Parse(User.CommanderData[cid].__skv2),
                3 => int.Parse(User.CommanderData[cid].__skv3),
                4 => int.Parse(User.CommanderData[cid].__skv4),
            };

            int totalCost = 0, skillCostDtblIndex = 0, typeCostSkillIndex = skillIndex - 1;
            int targetLevel = currentSkillLevel + count;

            for (int level = currentSkillLevel; level < targetLevel;)
            {
                skillCostDtblIndex = level - 1;

                totalCost += skillCostDtbl[skillCostDtblIndex].typeCost[typeCostSkillIndex];

                level++;
            }

            switch (@params.skillIndex)
            {
                case 1:
                    User.CommanderData[cid].__skv1 = targetLevel.ToString();
                    break;
                case 2:
                    User.CommanderData[cid].__skv1 = targetLevel.ToString();
                    break;
                case 3:
                    User.CommanderData[cid].__skv1 = targetLevel.ToString();
                    break;
                case 4:
                    User.CommanderData[cid].__skv1 = targetLevel.ToString();
                    break;
                default:
                    throw new ArgumentException("Invalid skill index");
            }

            User.Resources.gold -= totalCost;

            DatabaseManager.GameProfile.UpdateGold(SessionId, totalCost, false);
            DatabaseManager.GameProfile.UpdateSpecificCommander(SessionId, User.CommanderData[cid]);

            UserInformationResponse user = GetUserInformationResponse(User);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = user,
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