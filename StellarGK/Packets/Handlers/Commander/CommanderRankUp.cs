﻿using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;


namespace StellarGK.Host.Handlers.Commander
{
    [Command(Id = CommandId.CommanderRankUp)]
    public class CommanderRankUp : BaseCommandHandler<CommanderRankUpRequest>
    {
        public override object Handle(CommanderRankUpRequest @params)
        {
            ResponsePacket response = new();

            string session = GetSession();

            var user = GetGameProfile();


            string cid = @params.cid.ToString();

            if (user.commanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander != null)
            {
                var commanderRankData = CommanderRankData.GetInstance().FromRank(commander.__rank);

                user.userInventory.medalData.TryGetValue(cid, out var commanderMedals);

                if (!TryRankUpCommander(commanderRankData.rank, ref commanderMedals))
                {
                    response.id = BasePacket.Id;
                    response.error = new() { code = ErrorCode.NotEnoughResources };

                    return response;
                }

                commander.__rank = (Convert.ToInt32(commander.__rank) + 1).ToString();
                commander.medl = commanderMedals;

                commanderRankData = CommanderRankData.GetInstance().FromRank(commander.__rank);

                user.userInventory.medalData[cid] = commanderMedals;
                user.commanderData[cid] = commander;

                DatabaseManager.GameProfile.UpdateGold(session, commanderRankData.gold, false);

            } else {

                user.userInventory.medalData.TryGetValue(cid, out var commanderMedals);

                var CostumeData = CommanderCostumeData.GetInstance().FromId(cid);

                var commanderData = CommanderData.GetInstance().FromId(cid);

                if (!TryRecruitCommander(commanderData.grade, ref commanderMedals))
                {
                    response.id = BasePacket.Id;
                    response.error = new() { code = ErrorCode.NotEnoughResources };

                    return response;
                }

                user.userInventory.medalData[cid] = commanderMedals;

                var newestCommander = CreateCommander(cid, CostumeData.ctid, commanderMedals, commanderData.grade);

                int newcommanderId = 1;

                if (user.commanderData.Count > 0)
                {
                    newcommanderId = Convert.ToInt32(user.commanderData.Last().Key) + 1;
                }

                user.commanderData.Add(newcommanderId.ToString(), newestCommander);

                DatabaseManager.GameProfile.UpdateGold(session, commanderData.recruitGold, false);
            }

            DatabaseManager.GameProfile.UpdateCommanderData(session, user.commanderData);
            DatabaseManager.GameProfile.UpdateMedalData(session, user.userInventory.medalData);

            var newResources = GetGameProfile();

            CommanderRankUpResponse cmrup = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session),
                medl = newResources.userInventory.medalData,
                comm = newResources.commanderData,
            };

            response.result = cmrup;
            response.id = BasePacket.Id;

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
                role = "A", // TODO CREATE A ROLE TABLE
                transcendence = new() { 0, 0, 0, 0 },
            };

            return __commander;
        }

    }

    public class CommanderRankUpRequest
    {
        [JsonPropertyName("cid")]
        public int cid { get; set; }
    }
}