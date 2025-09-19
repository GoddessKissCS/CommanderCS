using CommanderCS.Library;
using CommanderCS.Library.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
	[Packet(Id = Library.Enums.Method.InfinityBattleInformation)]
    public class InfinityBattleInformation : BaseMethodHandler<InfinityBattleInformationRequest>
    {
		public override object Handle(InfinityBattleInformationRequest @params)
		{

            Library.Protocols.InfinityTowerInformation InfinityTowerInformation = new()
			{
				infinityData = new()
				{
					fieldData = [],
					curField = "",		
				},
				retryStage = ""
			};

            ResponsePacket responsePacket = new()
			{
				Id = BasePacket.Id,
				Result = InfinityTowerInformation
            };

			return responsePacket;
        }
    }

	public class InfinityBattleInformationRequest
	{
        [JsonProperty("ifid")]
        public int ifid { get; set; }

        [JsonProperty("deck")]
        public string retryStage { get; set; }
    }

}/*	// Token: 0x0600618A RID: 24970 RVA: 0x000120F8 File Offset: 0x000102F8

	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8700", true, true)]
	public void InfinityBattleInformation(int ifid, string retryStage)
	{
	}

	// Token: 0x0600618B RID: 24971 RVA: 0x001B1C84 File Offset: 0x001AFE84
	private IEnumerator InfinityBattleInformationResult(JsonRpcClient.Request request, Protocols.InfinityTowerInformation result)
	{
		if (this.localUser.infinityStageList = null)
		{
			this.localUser.infinityStageList = new Dictionary<string, Dictionary<int, int>>();
		}
		this.localUser.infinityStageList.Clear();
		int num = this.RemoteObjectManager.instance.regulation.infinityFieldDtbl.length - 1;
		while (0 <= num)
		{
			InfinityFieldDataRow infinityFieldDataRow = this.RemoteObjectManager.instance.regulation.infinityFieldDtbl[num];
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (result.infinityData.fieldData.ContainsKey(infinityFieldDataRow.infinityFieldIdx))
			{
				dictionary = result.infinityData.fieldData[infinityFieldDataRow.infinityFieldIdx];
			}
			this.localUser.infinityStageList.Add(infinityFieldDataRow.infinityFieldIdx, dictionary);
			num--;
		}
		result.retryStage = this._FindRequestProperty(request, "retryStage");
		UIManager.instance.world.infinityBattle.Init();
		UIManager.instance.world.infinityBattle.SetData(result);
		yield break;
	}

	// Token: 0x0600618C RID: 24972 RVA: 0x001B1CB0 File Offset: 0x001AFEB0
	private IEnumerator InfinityBattleInformationError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/