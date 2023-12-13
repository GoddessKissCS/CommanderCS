using CommanderCS.Enum.Packet;
using CommanderCS.Host;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Defender
{
    [Packet(Id = Method.GetDefenderInfo)]
    public class GetDefenderInfo : BaseMethodHandler<GetDefenderInfoRequest>
    {
        public override object Handle(GetDefenderInfoRequest @params)
        {
            var user = GetUserGameProfile();
                
            GetDefenderInfoResponse getDefenderInfo = new()
            {
                deck = user.DefenderDeck.PvPDefenderDeck,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = getDefenderInfo,
            };

            return response;
        }
    }

    public class GetDefenderInfoRequest
    {
    }

    public class GetDefenderInfoResponse
    {
        [JsonProperty("deck")]
        public Dictionary<string, string> deck { get; set; }
    }
}

/*
	// Token: 0x06005F91 RID: 24465 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3229", true, true)]
	public void GetDefenderInfo()
	{
	}

	// Token: 0x06005F92 RID: 24466 RVA: 0x001AF2C8 File Offset: 0x001AD4C8
	private IEnumerator GetDefenderInfoResult(JsonRpcClient.Request request, string result, Dictionary<string, string> deck)
	{
		this.localUser.RefreshDefenderTroop(deck);
		yield break;
	}*/