using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;
using System.Text.Json.Serialization;

namespace StellarGK.Host.Handlers.Commander
{
    [Packet(Id = Method.CommanderLevelUp)]
    public class CommanderLevelUp : BaseMethodHandler<CommanderLevelUpRequest>
    {

        public override object Handle(CommanderLevelUpRequest @params)
        {
            // "cid":13,"cnt":1,"ctt":"ctt1"

            // packet.count = cnt 
            // packet.commanderTrainingTicket = ctt
#warning TODO ADD MAXLEVEL CHECK SO YOU CANT OVERLEVEL THEM OVER YOUR LEVEL
            //GIVES OUT ERRORCODE 20001 or 20003

            var user = GetUserGameProfile();

            var commanderList = user.CommanderData;

            var itemData = user.UserInventory.itemData;

            if (commanderList.TryGetValue(@params.commanderId.ToString(), out UserInformationResponse.Commander commander) && commander != null)
            {

                int id = GoodsData.GetInstance().FromServerFieldName(@params.commanderTrainingTicket).type;

                int commanderXP = Convert.ToInt32(commander.__exp);

                for (int i = 0; i < @params.count; i++)
                {
                    TryLevelingUp(id, ref commanderXP);
                }

                commander.__exp = "" + commanderXP;

            }


            return "{}";
        }

        private static Dictionary<int, int> ExpList { get; set; } = new Dictionary<int, int>()
        {
            {8,50 },
            {16,300 },
            {17,1000 },
            {18,3000 },
            {19,10000 }
        };


        private static bool TryLevelingUp(int ticketId, ref int xp)
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
        }

    }

    public class CommanderLevelUpRequest
    {
        [JsonPropertyName("cid")]
        public int commanderId { get; set; }

        [JsonPropertyName("cnt")]
        public int count { get; set; }

        [JsonPropertyName("ctt")]
        public string commanderTrainingTicket { get; set; }
    }
}
