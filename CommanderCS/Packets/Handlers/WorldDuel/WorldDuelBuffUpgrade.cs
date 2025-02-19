using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.WorldDuel
{
    [Packet(Id = CommanderCSLibrary.Shared.Enum.Method.WorldDuelBuffUpgrade)]
    public class WorldDuelBuffUpgrade : BaseMethodHandler<WorldDuelBuffUpgradeRequest>
    {
        public override object Handle(WorldDuelBuffUpgradeRequest @params)
        {
            WorldDuelBuffUpgradeResponse worldDuelBuffUpgradeResponse = new()
            {
                rsoc = UserResources2Resource(User.Resources),
                buff = [],
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = worldDuelBuffUpgradeResponse,
            };

            return response;
        }
    }

    public class WorldDuelBuffUpgradeRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class WorldDuelBuffUpgradeResponse
    {
        [JsonProperty("rsoc")]
        public UserInformationResponse.Resource rsoc { get; set; }

        [JsonProperty("buff")]
        public Dictionary<string, int> buff { get; set; }
    }
}

/*	// Token: 0x06006157 RID: 24919 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3605", true, true)]
	public void WorldDuelBuffUpgrade(string type)
	{
	}

	// Token: 0x06006158 RID: 24920 RVA: 0x001B1814 File Offset: 0x001AFA14
	private IEnumerator WorldDuelBuffUpgradeResult(JsonRpcClient.Request request, string result, Protocols.UserInformationResponse.Resource rsoc, Dictionary<string, int> buff)
	{
		if (!string.IsNullOrEmpty(result))
		{
			this.localUser.RefreshGoodsFromNetwork(rsoc);
			this.localUser.RefreshWorldDuelBuffFromNetwork(buff);
			UIManager.instance.RefreshOpenedUI();
		}
		yield break;
	}

	// Token: 0x06006159 RID: 24921 RVA: 0x001B1848 File Offset: 0x001AFA48
	private IEnumerator WorldDuelBuffUpgradeError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/