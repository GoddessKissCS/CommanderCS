using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using StellarGK.Database;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.WorldMap
{
    [Command(Id = CommandId.WorldMapStageStart)]
    public class WorldMapStageStart : BaseCommandHandler<WorldMapStageStartRequest>
    {
        public override object Handle(WorldMapStageStartRequest @params)
        {
            ResponsePacket response = new();

            WorldMapStageStartRes wmssr = new();

            List<RewardInfo.RewardData> test = new();

            wmssr.reward = test;

            wmssr.rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(GetSession());

            response.id = BasePacket.Id;
            response.result = wmssr;


            return response;
        }

        public class WorldMapStageStartRes
        {
            [JsonPropertyName("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }
            [JsonPropertyName("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }
        }

    }

    public class WorldMapStageStartRequest
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("deck")]
        public JObject Deck { get; set; }

        [JsonPropertyName("gdp")]
        public JObject Gdp { get; set; }

        [JsonPropertyName("ucash")]
        public int Ucash { get; set; }

        [JsonPropertyName("mid")]
        public int Mid { get; set; }

        [JsonPropertyName("np")]
        public int Np { get; set; }
    }
}


/*
[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3732", true, true)]
	public void WorldMapStageStart(int type, JObject deck, JObject gdp, int ucash, int mid, int np)
	{
	}

	// Token: 0x06005F57 RID: 24407 RVA: 0x001AEDF0 File Offset: 0x001ACFF0
	private IEnumerator WorldMapStageStartResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, List<Protocols.RewardInfo.RewardData> reward)
	{
		this.localUser.useBullet = true;
		this.localUser.RefreshGoodsFromNetwork(rsoc);
		BattleData battleData = BattleData.Get();
		battleData.rewardItems = reward;
		BattleData.Set(battleData);
		this._CheckReceiveTestData("TEST_WorldMapStageBattleStart");
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x06005F58 RID: 24408 RVA: 0x001AEE1C File Offset: 0x001AD01C
	private IEnumerator WorldMapStageStartError(JsonRpcClient.Request request, string result, int code)
	{
		if (UIManager.instance.battle != null)
		{
			if (code == 21006 || code == 21007)
			{
				UISimplePopup uisimplePopup = UISimplePopup.CreateOK(false, Localization.Get("1303"), string.Empty, string.Format(Localization.Get("10000009"), Localization.Get("4006")), Localization.Get("1001"));
			}
		}
		else
		{
			base.StartCoroutine(this.OnJsonRpcRequestError(request, result, code));
		}
		yield break;
	}*/