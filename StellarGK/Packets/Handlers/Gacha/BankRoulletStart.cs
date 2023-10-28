using Newtonsoft.Json;
using StellarGK.Database;
using StellarGKLibrary.ExcelReader;
using StellarGKLibrary.Protocols;

namespace StellarGK.Host.Handlers.Gacha
{
    [Packet(Id = Method.BankRoulletStart)]
    public class BankRoulletStart : BaseMethodHandler<BankRoulletStartRequest>
    {
        public static Random random = new();

        public static Random random1 = new(random.Next());

        public override object Handle(BankRoulletStartRequest @params)
        {
            int vIdx;// metrobank id
            int vcnt;// current rechargeCount? + 1

            // return cnt is the remaining spins

            string session = GetSession();

            var count = @params.count;

            var luck = BankGold(session, count);

            BankRoullet bankRoullet = new()
            {
                rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session),
                luck = luck,
                count = count
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = bankRoullet
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

            int thebankGold = UserLevelData.GetInstance().FromLevel(user.UserResources.level).bankGold;

            int updateGold = luck.Sum() * thebankGold;

            int minusCash = 100;

            if (spins == 1)
            {
                minusCash = 10;
            }

            user.UserResources.cash -= minusCash;

            user.UserResources.gold += updateGold;

            DatabaseManager.GameProfile.UpdateUserResources(sessionId, user.UserResources);

            return luck;
        }

        public class BankRoullet
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }

            [JsonProperty("cnt")]
            public int count { get; set; }

            [JsonProperty("luck")]
            public List<int> luck { get; set; }
        }
    }

    public class BankRoulletStartRequest
    {
        [JsonProperty("cnt")]
        public int count { get; set; }

        [JsonProperty("vidx")]
        public int vidx { get; set; }

        [JsonProperty("vcnt")]
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