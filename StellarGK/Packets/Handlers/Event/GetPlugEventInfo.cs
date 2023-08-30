using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = Method.GetPlugEventInfo)]
    public class GetPlugEventInfo : BaseMethodHandler<GetPlugEventInfoRequest>
    {
        public override object Handle(GetPlugEventInfoRequest @params)
        {
            ResponsePacket response = new();

            GetPlugEventInfoPacket plugEventInfo = new()
            {
                cmt = new List<int>() { },
                pst = new List<int>() { }
            };

            response.Id = BasePacket.Id;
            response.Result = plugEventInfo;

            return response;
        }

        public class GetPlugEventInfoPacket
        {
            [JsonProperty("pst")]
            public List<int> pst { get; set; }

            [JsonProperty("cmt")]
            public List<int> cmt { get; set; }
        }
    }

    public class GetPlugEventInfoRequest
    {

    }
}
/*	// Token: 0x06006131 RID: 24881 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8300", true, true)]
	public void GetPlugEventInfo()
	{
	}

	// Token: 0x06006132 RID: 24882 RVA: 0x001B1500 File Offset: 0x001AF700
	private IEnumerator GetPlugEventInfoResult(JsonRpcClient.Request request, string result, List<int> pst, List<int> cmt)
	{
		this.localUser.articleEvent = pst;
		this.localUser.commentEvent = cmt;
		yield break;
	}

	// Token: 0x06006133 RID: 24883 RVA: 0x001B152C File Offset: 0x001AF72C
	private IEnumerator GetPlugEventInfoError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/