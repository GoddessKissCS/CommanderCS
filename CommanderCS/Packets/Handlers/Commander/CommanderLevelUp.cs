using CommanderCS.MongoDB;
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

            if (User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) && commander != null)
            {
                int commanderXP = Convert.ToInt32(commander.__exp);

                for (int i = 0; i < @params.count;)
                {

                    //NEED TO CHECK IF its 0
                    User.Inventory.itemData[sid] -= 1;

                    TryLevelingUp(sid, ref commanderXP);

                    i++;
                }

                commander.__exp = commanderXP.ToString();

                commander = CheckCommanderLevel(commander, Regulation, User);
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

            User.CommanderData[cid] = commander;

            DatabaseManager.GameProfile.UpdateItemData(SessionId, User.Inventory.itemData);
            DatabaseManager.GameProfile.UpdateCommanderData(SessionId, User.CommanderData);

            User.CommanderData = [];

            User.CommanderData[cid] = commander;

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

        private static UserInformationResponse.Commander CheckCommanderLevel(UserInformationResponse.Commander commander, Regulation rg, GameProfileScheme user)
        {
            int commanderLevel = int.Parse(commander.__level);
            int commanderXp = int.Parse(commander.__exp);

            while (true)
            {
                var row = rg.commanderLevelDtbl.Find(x => x.level == commanderLevel);
                if (row == null || row.exp == 0) break; // Prevent potential errors or infinite loops

                if (commanderXp < row.exp) break; // Exit when XP is not enough for next level

                commanderXp -= row.exp;
                commanderLevel++;
            }

            commander.__level = commanderLevel.ToString();
            commander.__exp = commanderXp.ToString();

            return commander;
        }

        private static bool TryLevelingUp(string ticketId, ref int xp)
        {
            if (!ExpList.TryGetValue(ticketId, out var addingXp))
            {
                throw new Exception($"Grade {ticketId} Not Defined");
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