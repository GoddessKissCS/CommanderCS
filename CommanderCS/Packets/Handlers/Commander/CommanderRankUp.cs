﻿using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation;
using CommanderCSLibrary.Shared.Regulation.DataRows;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Commander
{
    [Packet(Id = Method.CommanderRankUp)]
    public class CommanderRankUp : BaseMethodHandler<CommanderRankUpRequest>
    {
        public override object Handle(CommanderRankUpRequest @params)
        {
            string cid = @params.commanderId.ToString();

            bool commanderExists = User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander is not null;

            if (commanderExists)
            {
                int commanderRank = int.Parse(commander.__rank);

                CommanderRankDataRow commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == commanderRank);

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

                int upgradedRank = Convert.ToInt32(commander.__rank) + 1;

                commander.__rank = upgradedRank.ToString();
                commander.state = "N";

                commanderRankData = Regulation.commanderRankDtbl.FirstOrDefault(x => x.rank == upgradedRank);

                User.Inventory.medalData[cid] = commanderMedals;
                User.CommanderData[cid] = commander;

                DatabaseManager.GameProfile.UpdateGold(SessionId, commanderRankData.gold, false);
                DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);
                DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);
            }
            else
            {
                int recruitCost = (@params.commanderId == 1 || @params.commanderId == 2 || @params.commanderId == 5 ||
                        @params.commanderId == 14 || @params.commanderId == 17 || @params.commanderId == 18 ||
                        @params.commanderId == 26) ? 1000 : 50000;

                User.Inventory.medalData.TryGetValue(cid, out int commanderMedals);

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

                var newestCommander = CreateCommander(@params.commanderId, commanderMedals, commanderData.grade);

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
                    newcommanderId = 0;
                }

                string newCommander = newcommanderId.ToString();

                User.CommanderData.TryAdd(newCommander, newestCommander);

                DatabaseManager.GameProfile.UpdateGold(SessionId, recruitCost, false);
                DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);
                DatabaseManager.GameProfile.UpdateMedalData(SessionId, User.Inventory.medalData);
            }

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            User.CommanderData.TryGetValue(cid, out var commander1);

            Dictionary<string, UserInformationResponse.Commander> uprankedCommander = new()
            {
                { cid, commander1 }
            };

            CommanderRankUpResponse cmrup = new()
            {
                rsoc = rsoc,
                medl = User.Inventory.medalData,
                comm = uprankedCommander,
            };

            ResponsePacket response = new()
            {
                Result = cmrup,
                Id = BasePacket.Id
            };

            return response;
        }

        private static bool TryRecruitCommander(int grade, ref int medals)
        {
            if (!Constants.GradeCostList.TryGetValue(grade, out var cost))
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
            if (!Constants.RankCostList.TryGetValue(grade, out var cost))
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

        public static UserInformationResponse.Commander CreateCommander(int commanderid, int commanderMedals, int grade)
        {
            var commanderRole = RemoteObjectManager.instance.regulation.commanderRoleDtbl.Find(x => x.Id == commanderid).Role;
            var costumeId = RemoteObjectManager.instance.regulation.commanderCostumeDtbl.FirstOrDefault(x => x.cid == commanderid).ctid;

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
                currentCostume = costumeId,
                eventCostume = [],
                equipItemInfo = [],
                equipWeaponInfo = [],
                favorPoint = 0,
                favr = 0,
                fvrd = 0,
                haveCostume = [costumeId],
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