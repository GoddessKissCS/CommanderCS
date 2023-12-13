using CommanderCS.Enum.Packet;
using CommanderCS.Protocols;
using Newtonsoft.Json;

namespace CommanderCS.Host.Handlers.Carnival
{
    [Packet(Id = Method.GetCarnivalList)]
    public class GetCarnivalList : BaseMethodHandler<GetCarnivalListRequest>
    {
        public override object Handle(GetCarnivalListRequest @params)
        {
            ResponsePacket response = new();

            CarnivalList CLlist = new CarnivalList();

            Dictionary<string, CarnivalList.CarnivaTime> carnivalList = new Dictionary<string, CarnivalList.CarnivaTime>();
            Dictionary<string, Dictionary<string, CarnivalList.ProcessData>> carnivalProcessList = new Dictionary<string, Dictionary<string, CarnivalList.ProcessData>>();
            List<RewardInfo.RewardData> rewardList = new List<RewardInfo.RewardData>();

            return "{}";
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
					switch (this.regulation.FindCarnivalType(keyValuePair.Key))
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