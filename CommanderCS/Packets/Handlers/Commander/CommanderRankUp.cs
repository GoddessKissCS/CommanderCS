using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;

using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Commander
{
    [Packet(Id = Method.CommanderRankUp)]
    public class CommanderRankUp : BaseMethodHandler<CommanderRankUpRequest>
    {
        public override object Handle(CommanderRankUpRequest @params)
        {
            string cid = @params.commanderId.ToString();

            if (User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander != null)
            {
                var commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == int.Parse(commander.__rank));

                User.UserInventory.medalData.TryGetValue(cid, out var commanderMedals);

                if (!TryRankUpCommander(commanderRankData.rank, ref commanderMedals))
                {
                    ErrorPacket error = new()
                    {
                        Id = BasePacket.Id,
                        Error = new() { code = ErrorCode.NotEnoughResources },
                    };

                    return error;
                }

                int upgradedRank = Convert.ToInt32(commander.__rank) + 1;

                commander.__rank = upgradedRank.ToString();
                commander.state = "N";

                commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == upgradedRank);

                User.UserInventory.medalData[cid] = commanderMedals;
                User.CommanderData[cid] = commander;

                DatabaseManager.GameProfile.UpdateGold(SessionId, commanderRankData.gold, false);

            } else {

                int recruitCost = (@params.commanderId == 1 || @params.commanderId == 2 || @params.commanderId == 5 ||
                       @params.commanderId == 14 || @params.commanderId == 17 || @params.commanderId == 18 ||
                       @params.commanderId == 26) ? 1000 : 50000;

                User.UserInventory.medalData.TryGetValue(cid, out int commanderMedals);

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

                User.UserInventory.medalData[cid] = commanderMedals;

                var CostumeData = Regulation.commanderCostumeDtbl.FirstOrDefault(x => x.cid == @params.commanderId);

                var newestCommander = CreateCommander(@params.commanderId, CostumeData.ctid, commanderMedals, commanderData.grade);

                int newcommanderId;

                if (User.CommanderData.Count > 0)
                {
                    // Get the last key and convert it to an integer safely
                    var lastKey = User.CommanderData.Keys.Last();

                    if (int.TryParse(lastKey, out int lastKeyInt))
                    {
                        newcommanderId = lastKeyInt + 1;
                    }
                    else
                    {
                        throw new InvalidOperationException("The last key in CommanderData is not a valid integer.");
                    }
                }
                else
                {
                    // If no commanders exist, start with ID 1
                    newcommanderId = 1;
                }

                string newCommander = newcommanderId.ToString();

                var user = User;

                var data = user.CommanderData;

                data.TryAdd(newCommander, newestCommander);

                DatabaseManager.GameProfile.UpdateGold(SessionId, recruitCost, false);
            }

            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);
            DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.UserInventory.medalData);

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            User.CommanderData.TryGetValue(cid, out var commander1);

            Dictionary<string, UserInformationResponse.Commander> uprankedCommander = new()
            {
                { cid, commander1 }
            };

            CommanderRankUpResponse cmrup = new()
            {
                rsoc = rsoc,
                medl = User.UserInventory.medalData,
                comm = uprankedCommander,
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

        public static UserInformationResponse.Commander CreateCommander(int commanderid, int costumeid, int commanderMedals, int grade)
        {
            var commanderRole = RemoteObjectManager.instance.regulation.commanderRoleDtbl.Find(x => x.commanderId == commanderid).commanderRole;

            //need to check if hero starts with other grades or cls

            string commadnderGrade = grade.ToString();
            string commanderId = commanderid.ToString();

            UserInformationResponse.Commander __commander = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "0",
                __skv4 = "0",
                __cls = "1",
                __exp = "0",
                __level = "1",
                __rank = commadnderGrade,
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
                id = commanderId,
                marry = 0,
                medl = 0,
                role = commanderRole,
                transcendence = [0, 0, 0, 0],
            };

            return __commander;
        }
    }

    public class CommanderRankUpRequest
    {
        [JsonProperty("cid")]
        public int commanderId { get; set; }
    }
}