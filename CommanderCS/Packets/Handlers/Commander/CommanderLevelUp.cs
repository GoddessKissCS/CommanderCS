using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.Library.Regulation;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Commander
{
    [Packet(Id = Method.CommanderLevelUp)]
    public class CommanderLevelUp : BaseMethodHandler<CommanderLevelUpRequest>
    {
        public override object Handle(CommanderLevelUpRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            string sid = RemoteObjectManager.instance.regulation.goodsDtbl.FirstOrDefault(x => x.serverFieldName == request.commanderTrainingTicket).type;

            if (request.count > User.Inventory.itemData[sid])
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.NotEnoughResources },
                };

                return error;
            }

            string cid = request.commanderId.ToString();

            if (!User.CommanderData.TryGetValue(cid, out UserInformationResponse.Commander commander) || commander == null)
            {
                ErrorPacket error = new()
                {
                    Id = BasePacket.Id,
                    Error = new() { code = ErrorCode.Failure },
                };

                return error;
            }

            int commanderXP = Convert.ToInt32(commander.__exp);

            for (int i = 0; i < request.count; i++)
            {
                User.Inventory.itemData[sid] -= 1;
                AddTicketExp(sid, ref commanderXP);
            }

            commander.__exp = commanderXP.ToString();

            commander = CheckCommanderLevel(commander, RemoteObjectManager.instance.regulation, User);

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
            DatabaseManager.GameProfile.UpdateSpecificCommander(SessionId, User.CommanderData[cid]);

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

                if (commanderXp < row.exp) break; // Exit when XP != enough for next level

                commanderXp -= row.exp;
                commanderLevel++;
            }

            commander.__level = commanderLevel.ToString();
            commander.__exp = commanderXp.ToString();

            return commander;
        }

        private static void AddTicketExp(string ticketId, ref int xp)
        {
            if (!ExpList.TryGetValue(ticketId, out var addingXp))
            {
                throw new Exception($"Grade {ticketId} Not Defined");
            }

            xp += addingXp;
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