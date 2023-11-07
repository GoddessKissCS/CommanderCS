using Newtonsoft.Json;
using StellarGK.Database;
using StellarGKLibrary.ExcelReader;
using StellarGKLibrary.Protocols;
using StellarGKLibrary.Utils;

namespace StellarGK.Host.Handlers.Bank
{
    [Packet(Id = Method.BankRoulletStart)]
    public class BankRoulletStart : BaseMethodHandler<BankRoulletStartRequest>
    {
        public override object Handle(BankRoulletStartRequest @params)
        {
            string session = GetSession();

            var user = GetUserGameProfile();

            var count = @params.count;

            var vip_spins = Misc.GetVipRechargeCount(user.VipRechargeData, 601);

            var remainingSpins = vip_spins + count;

            user.VipRechargeData = Misc.UpdateVipRechargeCount(user.VipRechargeData, 601, remainingSpins);

            DatabaseManager.GameProfile.UpdateVipRechargeData(session, user.VipRechargeData);

            var luck = BankGold(session, count);

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session);

            BankRoullet bankRoullet = new()
            {
                rsoc = rsoc,
                luck = luck,
                count = remainingSpins
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
            Random random = new();

            Random random1 = new(random.Next(1, 99));

            List<int> luck = new(10);

            for (int i = 0; i < spins; i++)
            {
                luck.Add(random1.Next(1, 10));
            };

            var user = DatabaseManager.GameProfile.FindBySession(sessionId);

            int thebankGold = UserLevelData.GetInstance().FromLevel(user.UserResources.level).bankGold;

            int updateGold = luck.Sum() * thebankGold;

            int minusCash = 10;

            if (spins == 10)
            {
                minusCash = 100;
            }

            DatabaseManager.GameProfile.UpdateGold(sessionId, updateGold, true);
            DatabaseManager.GameProfile.UpdateCash(sessionId, minusCash, false);

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
		if (code = 53010)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("7054"));
		}
		yield break;
	}*/