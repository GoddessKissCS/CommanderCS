using CommanderCS.Library.Enums;
using CommanderCS.MongoDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.InfinityBattle
{
    [Packet(Id = Method.InfinityBattleStart)]
    public class InfinityBattleStart : BaseMethodHandler<InfinityBattleStartRequest>
    {
        public override object Handle(InfinityBattleStartRequest request)
        {
            var user = GetUserGameProfile();

            Dictionary<string, string> deck = request.deck.ToObject<Dictionary<string, string>>();

            DatabaseManager.GameProfile.UpdateInfinityBattleDeck(SessionId, deck);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "success",
            };

            return response;
        }
    }

    public class InfinityBattleStartRequest
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("ifid")]
        public int ifid { get; set; }

        [JsonProperty("deck")]
        public JObject deck { get; set; }
    }
}

/*	// Token: 0x06006199 RID: 24985 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3737", true, true)]
	public void InfinityBattleStart(int type, int ifid, JObject deck)
	{
	}

	// Token: 0x0600619A RID: 24986 RVA: 0x001B1DA4 File Offset: 0x001AFFA4
	private IEnumerator InfinityBattleStartResult(JsonRpcClient.Request request, string result)
	{
		BattleData battleData = BattleData.Get();
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}

	// Token: 0x0600619B RID: 24987 RVA: 0x001B1DB8 File Offset: 0x001AFFB8
	private IEnumerator InfinityBattleStartError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/