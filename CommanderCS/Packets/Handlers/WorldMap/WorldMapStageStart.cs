using CommanderCS.MongoDB;
using CommanderCSLibrary.Packets;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Host.Handlers.WorldMap
{
    [Packet(Id = Method.WorldMapStageStart)]
    public class WorldMapStageStart : BaseMethodHandler<WorldMapStageStartRequest>
    {
        public override object Handle(WorldMapStageStartRequest @params)
        {
            WorldMapStageStartResponse wmssr = new();

            //TODO: look at the stage and then the rewards it can gen
            List<RewardInfo.RewardData> test = [];


            string worldMapId = @params.Mid.ToString();

            var worldstagetbl = Regulation.worldMapStageDtbl.Find(x => x.id == worldMapId);

            //var worldReward = Regulation.rewardDtbl.Find(x => x.rewardIdx == 10101);

            User.Resources.bullet -= worldstagetbl.bullet;

            switch (@params.Mid)
            {
                case 1:

                    test.Add(new()
                    {
                        effect = 0,
                        rewardCnt = 5,
                        rewardId = "10101",
                        rewardType = ERewardType.UnitMaterial,
                    });

                    break;

            }

            //TODO: find out how to add exp
            wmssr.reward = test;

            wmssr.rsoc = DatabaseManager.GameProfile.UserResourcesFromSession(SessionId);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = wmssr
            };

            return response;
        }
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
		if (UIManager.instance.battle is not null)
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