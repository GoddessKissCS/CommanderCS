using Newtonsoft.Json;
using CommanderCS.Database;
using CommanderCS.ExcelReader;
using CommanderCS.Protocols;

namespace CommanderCS.Host.Handlers.Commander
{
    [Packet(Id = Method.CommanderRankUp)]
    public class CommanderRankUp : BaseMethodHandler<CommanderRankUpRequest>
    {
        public override object Handle(CommanderRankUpRequest @params)
        {
            ResponsePacket response = new();

            string session = GetSession();

            var user = GetUserGameProfile();

            string cid = @params.cid.ToString();

            if (user.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander != null)
            {
                var commanderRankData = CommanderRankData.GetInstance().FromRank(commander.__rank);

                user.UserInventory.medalData.TryGetValue(cid, out var commanderMedals);

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

                commanderRankData = CommanderRankData.GetInstance().FromRank(commander.__rank);

                user.UserInventory.medalData[cid] = commanderMedals;
                user.CommanderData[cid] = commander;

                DatabaseManager.GameProfile.UpdateGold(session, commanderRankData.gold, false);
            }
            else
            {
                user.UserInventory.medalData.TryGetValue(cid, out var commanderMedals);

                var CostumeData = CommanderCostumeData.GetInstance().FromId(cid);

                var commanderData = CommanderData.GetInstance().FromId(cid);

                if (!TryRecruitCommander(commanderData.grade, ref commanderMedals))
                {
                    ErrorPacket error = new() { 
                        Id = BasePacket.Id,
                        Error = new() { code = ErrorCode.NotEnoughResources },
                    };

                    return error;
                }

                user.UserInventory.medalData[cid] = commanderMedals;

                var newestCommander = CreateCommander(cid, CostumeData.ctid, commanderMedals, commanderData.grade);

                int newcommanderId = 1;

                if (user.CommanderData.Count > 0)
                {
                    newcommanderId = Convert.ToInt32(user.CommanderData.Last().Key) + 1;
                }

                user.CommanderData.Add(newcommanderId.ToString(), newestCommander);

                DatabaseManager.GameProfile.UpdateGold(session, commanderData.recruitGold, false);
            }

            DatabaseManager.GameProfile.UpdateCommanderData(session, user.CommanderData);
            DatabaseManager.GameProfile.UpdateMedalData(session, user.UserInventory.medalData);

            var newResources = GetUserGameProfile();

            CommanderRankUpResponse cmrup = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session),
                medl = newResources.UserInventory.medalData,
                comm = newResources.CommanderData,
            };

            response.Result = cmrup;
            response.Id = BasePacket.Id;

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
            UserInformationResponse.Commander __commander = new()
            {
                state = "N",
                __skv1 = "1",
                __skv2 = "1",
                __skv3 = "1",
                __skv4 = "1",
                __cls = "0",
                __exp = "0",
                __level = "1",
                __rank = "" + grade,
                favorRewardStep = 0,
                favorStep = 0,
                currentCostume = costumeid,
                eventCostume = new() { },
                equipItemInfo = new() { },
                equipWeaponInfo = new() { },
                favorPoint = 0,
                favr = 0,
                fvrd = 0,
                haveCostume = new() { costumeid },
                id = commanderid,
                marry = 0,
                medl = commanderMedals,
#warning TODO CREATE A ROLE TABLE
                role = "A",
                transcendence = new() { 0, 0, 0, 0 },
            };

            return __commander;
        }
    }

    public class CommanderRankUpRequest
    {
        [JsonProperty("cid")]
        public int cid { get; set; }
    }
}