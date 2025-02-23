﻿using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Bank
{
    [Packet(Id = Method.BankRoulletStart)]
    public class BankRoulletStart : BaseMethodHandler<BankRoulletStartRequest>
    {
        public override object Handle(BankRoulletStartRequest @params)
        {
            // THIS NEEDS A REWORK
            var vip_spins = DatabaseManager.GameProfile.GetVipRechargeCount(SessionId, 601);

            var remainingSpins = vip_spins + @params.count;

            DatabaseManager.GameProfile.UpdateVipRechargeCount(SessionId, 601, remainingSpins);

            var luck = SpinBankRouletteAndProcessResults(SessionId, @params.count);

            var rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

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

        private static List<int> SpinBankRouletteAndProcessResults(string sessionId, int spins)
        {
            var rouletteLuck = RandomGenerator.BankRoulletLuck(spins);

            var userLevel = DatabaseManager.GameProfile.FindBySession(sessionId).Resources.level;

            int bankGold = RemoteObjectManager.instance.regulation.userLevelDtbl.FirstOrDefault(x => x.level == userLevel).bankGold;

            int updatedGold = rouletteLuck.Sum() * bankGold;

            int cashDeduction = (spins == 10) ? 100 : 10;

            DatabaseManager.GameProfile.UpdateGold(sessionId, updatedGold, true);
            DatabaseManager.GameProfile.UpdateOnlyCash(sessionId, cashDeduction, false);

            return rouletteLuck;
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