using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    [Packet(Id = Method.InfinityBattleGetReward)]
    public class InfinityBattleGetReward : BaseMethodHandler<InfinityBattleGetRewardRequest>
    {
        public override object Handle(InfinityBattleGetRewardRequest request)
        {
            var user = GetUserGameProfile();

            string ifid = request.ifid.ToString();
            int msid = request.msid;

            var fieldData = InfinityTowerSchemeToInfinityTowerData(user.BattleData.InfinityTowerData.infinityData).infinityData.fieldData;

            // Mark the mission as reward collected
            if (fieldData.ContainsKey(ifid) && fieldData[ifid].ContainsKey(msid))
            {
                fieldData[ifid][msid] = EInfinityTowerStageState.VictoryAndRewardCollected;
            }

            //DatabaseManager.GameProfile.UpdateInfinityTowerFieldData(SessionId, fieldData);

            var resc = UserResources2Resource(user.Resources);

            InfinityTowerReward result = new()
            {
                reward = [],
                resource = resc,
                fieldData = fieldData,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = result,
            };

            return response;
        }


        private InfinityTowerInformation InfinityTowerSchemeToInfinityTowerData(InfinityTowerDataScheme scheme)
        {
            InfinityTowerInformation towerData = new()
            {
                infinityData = new()
                {
                    curField = scheme.curField,
                    fieldData = scheme.fieldData?.ToDictionary(
                        outer => outer.Key,
                        outer => outer.Value?.ToDictionary(
                            inner => int.Parse(inner.Key),
                            inner => inner.Value))
                        ?? []
                }
            };

            return towerData;
        }

    }

    public class InfinityBattleGetRewardRequest
    {
        [JsonProperty("ifid")]
        public int ifid { get; set; }

        [JsonProperty("msid")]
        public int msid { get; set; }
    }
}/*	// Token: 0x06006196 RID: 24982 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8704", true, true)]
	public void InfinityBattleGetReward(int ifid, int msid)
	{
	}

	// Token: 0x06006197 RID: 24983 RVA: 0x001B1D6C File Offset: 0x001AFF6C
	private IEnumerator InfinityBattleGetRewardResult(JsonRpcClient.Request request, Protocols.InfinityTowerReward result)
	{
		if (result != null)
		{
			UIPopup.Create<UIGetItem>("GetItem").Set(result.reward, string.Empty);
			SoundManager.PlaySFX("SE_ItemGet_001", false, 0f, float.MaxValue, float.MaxValue, default(Vector3), null, SoundDuckingSetting.DoNotDuck, 0f, 1f);
			this.localUser.RefreshRewardFromNetwork(result);
			UIManager.instance.world.infinityBattle.UpdateInfinityBattleData(string.Empty, result.fieldData);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006198 RID: 24984 RVA: 0x001B1D90 File Offset: 0x001AFF90
	private IEnumerator InfinityBattleGetRewardError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/