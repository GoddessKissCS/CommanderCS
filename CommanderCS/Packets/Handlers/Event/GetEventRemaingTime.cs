using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.Event
{
    [Packet(Id = Method.GetEventRemaingTime)]
    public class GetEventRemaingTime : BaseMethodHandler<GetEventRemaingTimeRequest>
    {
        public override object Handle(GetEventRemaingTimeRequest @params)
        {
            GetEventRemainingTimeResponse remainingEventTime = new()
            {
                buff = []
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = remainingEventTime,
            };

            return response;
        }

        public class GetEventRemainingTimeResponse
        {
            [JsonProperty("buff")]
            public Dictionary<string, int> buff { get; set; }
        }
    }

    public class GetEventRemaingTimeRequest
    {
    }
}

/*	// Token: 0x06006148 RID: 24904 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "8120", true, true)]
	public void GetEventRemaingTime()
	{
	}

	// Token: 0x06006149 RID: 24905 RVA: 0x001B16E4 File Offset: 0x001AF8E4
	private IEnumerator GetEventRemaingTimeResult(JsonRpcClient.Request request, string result, Dictionary<string, int> buff)
	{
		if (result is not null && buff.Count > 0)
		{
			this.localUser.eventRemaingTime.Clear();
			List<string> list = new List<string>(buff.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				string text = list[i];
				int num = buff[text];
				TimeData timeData = TimeData.Create();
				timeData.SetByDuration((double)num);
				this.localUser.eventRemaingTime.Add(text, timeData);
			}
		}
		yield break;
	}

	// Token: 0x0600614A RID: 24906 RVA: 0x001B1710 File Offset: 0x001AF910
	private IEnumerator GetEventRemaingTimeError(JsonRpcClient.Request request, string result, int code)
	{
		yield break;
	}*/