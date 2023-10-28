using Newtonsoft.Json;

namespace StellarGK.Host.Handlers.Event
{
    [Packet(Id = Method.GetWebEvent)]
    public class GetWebEvent : BaseMethodHandler<GetWebEventRequest>
    {
        public override object Handle(GetWebEventRequest @params)
        {
            GetWebEventPacket gwe = new()
            {
                wev = new List<string>() { "NONE" }
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = gwe,
            };

            return response;
        }

        public class GetWebEventPacket
        {
            [JsonProperty("wev")]
            public List<string> wev { get; set; }
        }
    }

    public class GetWebEventRequest
    {
    }
}

/*	// Token: 0x06006111 RID: 24849 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8121", true, true)]
	public void GetWebEvent(int ch)
	{
	}

	// Token: 0x06006112 RID: 24850 RVA: 0x001B122C File Offset: 0x001AF42C
	private IEnumerator GetWebEventResult(JsonRpcClient.Request request, string result, List<string> wev)
	{
		if (!this.localUser.badgeWebEvent)
		{
			if (this.localUser.webEventUrls == null || this.localUser.webEventUrls.Count != wev.Count)
			{
				this.localUser.badgeWebEvent = true;
			}
			else
			{
				for (int i = 0; i < this.localUser.webEventUrls.Count; i++)
				{
					if (this.localUser.webEventUrls[i] != wev[i])
					{
						this.localUser.badgeWebEvent = true;
						break;
					}
				}
			}
		}
		this.localUser.webEventUrls = wev;
		yield break;
	}*/