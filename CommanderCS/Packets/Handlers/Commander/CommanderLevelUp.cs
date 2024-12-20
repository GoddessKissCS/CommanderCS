﻿using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using CommanderCSLibrary.Shared.Enum;

using CommanderCSLibrary.Shared.Protocols;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Commander
{
    [Packet(Id = Method.CommanderLevelUp)]
    public class CommanderLevelUp : BaseMethodHandler<CommanderLevelUpRequest>
    {
        public override object Handle(CommanderLevelUpRequest @params)
        {
            string sid = Regulation.goodsDtbl.FirstOrDefault(x => x.serverFieldName == @params.commanderTrainingTicket).type;

            if (@params.count > User.Inventory.itemData[sid])
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.NotEnoughResources },
                };

                return error;
            }

            string cid = @params.commanderId.ToString();

            if (User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander is not null)
            {
                int commanderXP = Convert.ToInt32(commander.__exp);

                for (int i = 1; i < @params.count;)
                {
                    if (User.Inventory.itemData[sid] > 0)
                    {
                        User.Inventory.itemData[sid] -= 1;
                    }

                    TryLevelingUp(sid, ref commanderXP);

                    i++;
                }

                commander.__exp = commanderXP.ToString();

                commander = CheckCommanderLevelRecursive(commander, Regulation, User);
            }

            if (int.Parse(commander.__level) > User.Resources.level)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.CommanderCantLevelHigherThanUser },
                };

                return error;
            }

            DatabaseManager.GameProfile.UpdateItemData(SessionId, User.Inventory.itemData);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = GetUserInformationResponse(User),
            };

            return response;
        }

        private static Dictionary<string, int> ExpList { get; set; } = new Dictionary<string, int>()
        {
            { "8"  , 50 },
            { "16" , 300 },
            { "17" , 1000 },
            { "18" , 3000 },
            { "19" , 10000 }
        };

        private static UserInformationResponse.Commander CheckCommanderLevelRecursive(UserInformationResponse.Commander commander, Regulation rg, GameProfileScheme user)
        {
            int commanderLevel = int.Parse(commander.__level);

            var row = rg.commanderLevelDtbl.Find(x => x.level == commanderLevel);

            int commanderXp = int.Parse(commander.__exp);

            if (commanderXp > row.exp)
            {
                commander.__level = (commanderLevel + 1).ToString();
                commander.__exp = (commanderXp -= row.exp).ToString();

                return CheckCommanderLevelRecursive(commander, rg, user);
            }

            return commander;
        }

        private static bool TryLevelingUp(string ticketId, ref int xp)
        {
            if (!ExpList.TryGetValue(ticketId, out var addingXp))
            {
                throw new Exception($"Grade {ticketId} Not Defined");
            }

            if (xp < addingXp)
            {
                return false;
            }

            xp += addingXp;

            return true;

            // needs to add check for the level up while adding xp and checking if the commander level isnt higher than user level
        }
    }

    public class CommanderLevelUpRequest
    {
        [JsonProperty("cid")]
        public int commanderId { get; set; }

        [JsonProperty("cnt")]
        public int count { get; set; }

        [JsonProperty("ctt")]
        public string commanderTrainingTicket { get; set; }
    }
}