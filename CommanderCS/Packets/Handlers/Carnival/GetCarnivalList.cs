using CommanderCS.Library;
using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Packets.Handlers.Carnival
{
    [Packet(Id = Method.GetCarnivalList)]
    public class GetCarnivalList : BaseMethodHandler<GetCarnivalListRequest>
    {
        public override object Handle(GetCarnivalListRequest request)
        {
            GameProfileScheme user = GetUserGameProfile();

            var resource = UserResources2Resource(user.Resources);

            int connectTime = (int)TimeManager.CurrentEpoch;
            DateTime now = DateTime.UtcNow;

            var regulation = RemoteObjectManager.instance.regulation;

            Dictionary<string, CarnivalList.CarnivaTime> carnivalList = [];
            Dictionary<string, Dictionary<string, CarnivalList.ProcessData>> carnivalProcessList = [];

            foreach (var carnivalType in regulation.carnivalTypeDtbl)
            {
                DateTime startDate = DateTime.Parse($"{carnivalType.startDate} {carnivalType.startTime}");
                DateTime endDate = DateTime.Parse($"{carnivalType.endDate} {carnivalType.endTime}");

                if (now < startDate || now > endDate)
                {
                    continue;
                }

                int remainSeconds = (int)(endDate - now).TotalSeconds;

                carnivalList[carnivalType.idx] = new CarnivalList.CarnivaTime()
                {
                    remain = remainSeconds.ToString(),
                };

                Dictionary<string, CarnivalList.ProcessData> processEntries = [];

                foreach (var entry in regulation.carnivalDtbl)
                {
                    if (entry.cTidx != carnivalType.idx)
                    {
                        continue;
                    }

                    processEntries[entry.idx] = new CarnivalList.ProcessData()
                    {
                        count = 0,
                        complete = 0,
                        receive = 0,
                        able = 0,
                        startTime = startDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        endTime = endDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        remain = remainSeconds.ToString(),
                    };
                }

                if (processEntries.Count > 0)
                {
                    carnivalProcessList[carnivalType.idx] = processEntries;
                }
            }

            CarnivalList result = new()
            {
                carnivalList = carnivalList,
                carnivalProcessList = carnivalProcessList,
                rewardList = [],
                resource = resource,
                connectTime = connectTime,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = JObject.FromObject(result),
            };

            return response;
        }
    }

    public class GetCarnivalListRequest
    {
        [JsonProperty("cctype")]
        public int cctype { get; set; }

        [JsonProperty("eidx")]
        public int eidx { get; set; }
    }
}

/*	// Token: 0x060060BE RID: 24766 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "6241", true, true)]
	public void GetCarnivalList(int eidx, int cctype)
	{
	}

	// Token: 0x060060BF RID: 24767 RVA: 0x001B0B84 File Offset: 0x001AED84
	private IEnumerator GetCarnivalListResult(JsonRpcClient.Request request, Protocols.CarnivalList result)
	{
		if (result != null)
		{
			this.localUser.connectTime = result.connectTime;
			int num = int.Parse(this._FindRequestProperty(request, "eidx"));
			foreach (KeyValuePair<string, Dictionary<string, Protocols.CarnivalList.ProcessData>> keyValuePair in result.carnivalProcessList)
			{
				foreach (KeyValuePair<string, Protocols.CarnivalList.ProcessData> keyValuePair2 in keyValuePair.Value)
				{
					switch (this.RemoteObjectManager.instance.regulation.FindCarnivalType(keyValuePair.Key))
					{
					case ECarnivalType.NewUserExchangeEvent_Reward:
					case ECarnivalType.NewUserExchangeEvent_Mission:
					case ECarnivalType.ExchangeEvent_Reward:
					case ECarnivalType.ExchangeEvent_Mission:
					case ECarnivalType.EventBattle_Exchange:
						if (keyValuePair2.Value.receive == 1)
						{
							keyValuePair2.Value.complete = 1;
						}
						else
						{
							keyValuePair2.Value.complete = ((!this.localUser.IsCompleteExchangeCarnival(keyValuePair2.Key)) ? 0 : 1);
						}
						break;
					}
				}
			}
			this.localUser.carnivalList = result;
			if (result.carnivalList.Count == 0)
			{
				NetworkAnimation.Instance.CreateFloatingText(Localization.Get("6037"));
				yield break;
			}
			if (!UIManager.instance.world.existCarnival || !UIManager.instance.world.carnival.isActive)
			{
				UIManager.instance.world.carnival.Init(num);
			}
			else
			{
				UIManager.instance.RefreshOpenedUI();
			}
		}
		yield break;
	}*/
