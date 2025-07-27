using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CommanderRankUpImmediate)]
    public class CommanderRankUpImmediate : BaseMethodHandler<CommanderRankUpImmediateRequest>
    {
        public override object Handle(CommanderRankUpImmediateRequest @params)
        {
            User = DatabaseManager.GameProfile.FindBySession(BasePacket.SessionId);

            string cid = @params.cid.ToString();

            //needs to be reworked to be more readable

            if (User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander is not null)
            {
                var commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == int.Parse(commander.__rank));

                User.Inventory.medalData.TryGetValue(cid, out var commanderMedals);

                if (!TryRankUpCommander(commanderRankData.rank, ref commanderMedals))
                {
                    ErrorPacket error = new()
                    {
                        Id = BasePacket.Id,
                        Error = new() { code = ErrorCode.NotEnoughResources },
                    };

                    return error;
                }

                commander.__rank = (Convert.ToInt32(commander.__rank) + 1).ToString();
                commander.medl = commanderMedals;

                commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == commanderRankData.rank);

                User.Inventory.medalData[cid] = commanderMedals;
                User.CommanderData[cid] = commander;

                DatabaseManager.GameProfile.UpdateGold(SessionId, commanderRankData.gold, false);
            }
            else
            {
                User.Inventory.medalData.TryGetValue(cid, out var commanderMedals);

                var CostumeData = Regulation.commanderCostumeDtbl.FirstOrDefault(x => x.cid == int.Parse(cid));

                var commanderData = Regulation.commanderDtbl.FirstOrDefault(x => x.id == cid);

                if (!TryRecruitCommander(commanderData.grade, ref commanderMedals))
                {
                    ErrorPacket error = new()
                    {
                        Id = BasePacket.Id,
                        Error = new() { code = ErrorCode.NotEnoughResources },
                    };

                    return error;
                }

                User.Inventory.medalData[cid] = commanderMedals;

                var newestCommander = CreateCommander(cid, CostumeData.ctid, commanderMedals, commanderData.grade);

                int newcommanderId = 1;

                if (User.CommanderData.Count > 0)
                {
                    newcommanderId = Convert.ToInt32(User.CommanderData.Last().Key) + 1;
                }

                User.CommanderData.Add(newcommanderId.ToString(), newestCommander);

                DatabaseManager.GameProfile.UpdateGold(SessionId, commanderData.recruitGold, false);
            }

            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);
            DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);

            var newResources = User;

            var rsoc = UserResources2Resource(newResources.Resources);

            CommanderRankUpImmediateResponse cmrup = new()
            {
                cash = int.Parse(rsoc.__cash),
                medl = User.CommanderData[cid].medl,
                comm = null,
            };

            ResponsePacket response = new()
            {
                Result = cmrup,
                Id = BasePacket.Id
            };

            return response;
        }

        private static Dictionary<int, int> GradeCostList { get; set; } = new Dictionary<int, int>()
        {
            { 1, 10 },
            { 2, 30 },
            { 3, 80 }
        };

        private static Dictionary<int, int> RankCostList { get; set; } = new Dictionary<int, int>()
        {
            { 1, 20 },
            { 2, 50 },
            { 3, 100 },
            { 4, 150 },
            { 5, 250 }
        };

        private static bool TryRecruitCommander(int grade, ref int medals)
        {
            if (!GradeCostList.TryGetValue(grade, out var cost))
            {
                throw new Exception($"Grade {grade} Not Defined");
            }

            if (medals < cost)
            {
                return false;
            }

            medals -= cost;

            return true;
        }

        private static bool TryRankUpCommander(int grade, ref int medals)
        {
            if (!RankCostList.TryGetValue(grade, out var cost))
            {
                throw new Exception($"Grade {grade} Not Defined");
            }

            if (medals < cost)
            {
                return false;
            }

            medals -= cost;

            return true;
        }

        private static UserInformationResponse.Commander CreateCommander(string commanderid, int costumeid, int commanderMedals, int grade)
        {
            var commanderRole = RemoteObjectManager.instance.regulation.commanderRoleDtbl.Find(x => x.Id == int.Parse(commanderid)).Role;

            UserInformationResponse.Commander __commander = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "0",
                __skv4 = "0",
                __cls = "0",
                __exp = "0",
                __level = "1",
                __rank = grade.ToString(),
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = costumeid,
                eventCostume = [],
                equipItemInfo = [],
                equipWeaponInfo = [],
                favorPoint = 0,
                favr = 0,
                fvrd = 0,
                haveCostume = [costumeid],
                id = commanderid,
                marry = 0,
                medl = commanderMedals,
                role = commanderRole,
                transcendence = [0, 0, 0, 0],
            };

            return __commander;
        }
    }

    public class CommanderRankUpImmediateRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }
    }

    public class CommanderRankUpImmediateResponse
    {
        [JsonProperty("cash")]
        public int cash { get; set; }

        [JsonProperty("medl")]
        public int medl { get; set; }

        [JsonProperty("comm")]
        public SimpleCommanderInfo comm { get; set; }
    }
}

/*
  public void CommanderRankUpImmediate(int cid)
	{
	}

	// Token: 0x06005F30 RID: 24368 RVA: 0x001AE924 File Offset: 0x001ACB24
	private IEnumerator CommanderRankUpImmediateResult(JsonRpcClient.Request request, string result, int cash, int medl, Protocols.SimpleCommanderInfo comm)
	{
		string text = this._FindRequestProperty(request, "cid");
		if (!string.IsNullOrEmpty(text))
		{
			RoCommander roCommander = this.localUser.FindCommander(text);
			RoCommander roCommander2 = roCommander;
			roCommander2.rank++;
			roCommander.rankUpTime.SetInvalidValue();
		}
		this.localUser.cash = cash;
		this.localUser.medal = medl;
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}

	// Token: 0x06005F31 RID: 24369 RVA: 0x001AE958 File Offset: 0x001ACB58
	private IEnumerator CommanderRankUpImmediateError(JsonRpcClient.Request request, string result, int code, string message)
	{
		UISimplePopup.CreateDebugOK(code.ToString(), message, "확인");
		yield break;
	}
*/