using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StellarGK.Database;
using StellarGK.Host.Handlers.Event;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.BankRoulletStart)]
    public class BankRoulletStart : BaseCommandHandler<BankRoulletStartRequest>
    {
        public static Random random = new();

        public static Random random1 = new(random.Next());

        public override string Handle(BankRoulletStartRequest @params)
        {
            int vIdx;// metrobank id
            int vcnt;// curremt rechargeCount? + 1

            // return cnt is the remaining spins



            var resources = DatabaseManager.Resources.RequestResourcesScheme(BasePacket.Session);

            var luck = BankGold(BasePacket.Session, @params.count);


            BankRoullet bankRoullet = new()
            {
                rsoc = resources,
                luck = luck,
                cnt = @params.count
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = bankRoullet
            };


            return JsonConvert.SerializeObject(response);

        }

        private static List<int> BankGold(string sessionId, int spins)
        {
            List<int> luck = new(10);

            for (int i = 0; i < spins; i++)
            {
                luck.Add(random1.Next(1, 10));
            };

            var resources = DatabaseManager.Resources.FindBySession(sessionId);

            int thebankGold = UserLevelData.GetInstance().FromLevel(resources.level).bankGold;

            int updateGold = luck.Sum() * thebankGold;

            int minusCash = 100;

            if (spins == 1)
            {
                minusCash = 10;
            }


            var newCash = Convert.ToInt32(resources.cash) - minusCash;

            var newGold = Convert.ToInt32(resources.gold) + updateGold;

            DatabaseManager.Resources.UpdateGoldAndCash(resources.Id, newGold, newCash);

            DatabaseManager.BattleStatistics.AddGold(resources.Id, newGold);

            return luck;

        }

        public class BankRoullet
        {
            public UserInformationResponse.Resource rsoc { get; set; }
            public int cnt { get; set; }
            public List<int> luck { get; set; }

        }

    }

    public class BankRoulletStartRequest 
    {
        [JsonPropertyName("cnt")]
        public int count { get; set; }

        [JsonPropertyName("vidx")]
        public int vidx { get; set; }

        [JsonPropertyName("vcnt")]
        public int vcnt { get; set; }
    }
}