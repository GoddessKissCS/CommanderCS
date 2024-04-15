using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapStageStart)]
    public class WorldMapStageStart : BaseMethodHandler<WorldMapStageStartRequest>
    {
        public override object Handle(WorldMapStageStartRequest @params)
        {
            var session = GetSession();
            WorldMapStageStartResponse wmssr = new();

            //TODO: look at the stage and then the rewards it can gen
            List<RewardInfo.RewardData> test = [];

            //TODO: find out how to add exp
            wmssr.reward = test;

            wmssr.rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(session);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = wmssr
            };

            return response;
        }

        internal class WorldMapStageStartResponse
        {
            [JsonProperty("rsoc")]
            public UserInformationResponse.Resource rsoc { get; set; }

            [JsonProperty("reward")]
            public List<RewardInfo.RewardData> reward { get; set; }
        }
    }

    public class WorldMapStageStartRequest
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("deck")]
        public JObject Deck { get; set; }

        [JsonProperty("gdp")]
        public JObject Gdp { get; set; }

        [JsonProperty("ucash")]
        public int Ucash { get; set; }

        [JsonProperty("mid")]
        public int Mid { get; set; }

        [JsonProperty("np")]
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