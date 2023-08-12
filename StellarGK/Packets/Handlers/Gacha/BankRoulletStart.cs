using System.Text.Json.Serialization;
using StellarGK.Database;
using StellarGK.Logic.ExcelReader;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Command(Id = CommandId.BankRoulletStart)]
    public class BankRoulletStart : BaseCommandHandler<BankRoulletStartRequest>
    {
        public static Random random = new();

        public static Random random1 = new(random.Next());

        public override object Handle(BankRoulletStartRequest @params)
        {
            int vIdx;// metrobank id
            int vcnt;// curremt rechargeCount? + 1

            // return cnt is the remaining spins

            string session = GetSession();

            var luck = BankGold(session, @params.count);

            BankRoullet bankRoullet = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session),
                luck = luck,
                cnt = @params.count
            };

            ResponsePacket response = new()
            {
                id = BasePacket.Id,
                result = bankRoullet
            };


            return response;

        }

        private static List<int> BankGold(string sessionId, int spins)
        {
            List<int> luck = new(10);

            for (int i = 0; i < spins; i++)
            {
                luck.Add(random1.Next(1, 10));
            };

            var user = DatabaseManager.GameProfile.FindBySession(sessionId);

            int thebankGold = UserLevelData.GetInstance().FromLevel(user.userResources.level).bankGold;

            int updateGold = luck.Sum() * thebankGold;

            int minusCash = 100;

            if (spins == 1)
            {
                minusCash = 10;
            }

            var newCash = user.userResources.cash - minusCash;

            var newGold = user.userResources.gold + updateGold;

            DatabaseManager.GameProfile.UpdateGoldAndCash(sessionId, newGold, newCash, true);

            return luck;

        }

        public class BankRoullet
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }
            [JsonPropertyName("cnt")]
            public int cnt { get; set; }
            [JsonPropertyName("luck")]
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
/*	// Token: 0x06005FC9 RID: 24521 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "1501", true, true)]
	public void BankRoulletStart(int vidx, int cnt, int vcnt)
	{
	}

	// Token: 0x06005FCA RID: 24522 RVA: 0x001AF720 File Offset: 0x001AD920
	private IEnumerator BankRoulletStartResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, int cnt, List<int> luck)
	{
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		string text = 601.ToString();
		this.localUser.resourceRechargeList[text] = cnt;
		UIManager.instance.world.metroBank.RoulletPlay(luck);
		yield break;
	}

	// Token: 0x06005FCB RID: 24523 RVA: 0x001AF754 File Offset: 0x001AD954
	private IEnumerator BankRoulletStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (code == 53010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		yield break;
	}*/