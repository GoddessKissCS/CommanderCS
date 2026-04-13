using CommanderCS.Library.Enums;

namespace CommanderCS.Packets.Handlers.Raid
{
    [Packet(Id = Method.ReceiveRaidReward)]
    public class ReceiveRaidReward : BaseMethodHandler<ReceiveRaidRewardRequest>
    {
        public override object Handle(ReceiveRaidRewardRequest request)
        {
            //TODO: Calculate and grant actual raid rewards based on ranking/score

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = "ok",
            };

            return response;
        }
    }

    public class ReceiveRaidRewardRequest { }
}

/*	// Token: 0x06005FF7 RID: 24567 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3215", true, true)]
	public void ReceiveRaidReward()
	{
	}

	// Token: 0x06005FF8 RID: 24568 RVA: 0x001AFAB4 File Offset: 0x001ADCB4
	private IEnumerator ReceiveRaidRewardResult(JsonRpcClient.Request request, string result)
	{
		UIPopup.Create<ReceiveDuelRewardPopup>("ReceiveDuelRewardPopup").Set(PvPRewardType.Raid);
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/