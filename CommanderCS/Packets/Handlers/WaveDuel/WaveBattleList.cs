using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.WaveBattleList)]
    public class WaveBattleList : BaseMethodHandler<WaveBattleListRequest>
    {
        public override object Handle(WaveBattleListRequest request)
        {
            // Need to figure out the daily shit for this thing

            var endTime = (int)(DateTime.UtcNow.Date.AddDays(1) - DateTime.UtcNow).TotalSeconds;

            var startTime = (int)(DateTime.UtcNow.Date.AddDays(0) - DateTime.UtcNow).TotalSeconds;

            WaveBattleInfoList waveBattleInfoList = new()
            {
                InfoList = new(),
            };

            for (int i = 1; i <= 4; i++)
            {
                WaveBattleInfoList.WaveBattleInfo waveBattle = new()
                {
                    battleIdx = i,
                    clearCount = 0,
                    closeTime = endTime,
                    maxCount = 99,
                    openTime = 0,
                };

                waveBattleInfoList.InfoList.Add(waveBattle);
            }

            ResponsePacket packet = new()
            {
                Id = BasePacket.Id,
                Result = waveBattleInfoList,
            };

            return packet;
        }
    }

    public class WaveBattleListRequest
    {
    }
}

/*	// Token: 0x060060E4 RID: 24804 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3301", true, true)]
	public void WaveBattleList()
	{
	}

	// Token: 0x060060E5 RID: 24805 RVA: 0x001B0E94 File Offset: 0x001AF094
	private IEnumerator WaveBattleListResult(JsonRpcClient.Request request, Protocols.WaveBattleInfoList result)
	{
		if (result !=null && result.InfoList !=null)
		{
			if (!UIManager.instance.world.existWaveBattle || !UIManager.instance.world.waveBattle.isActive)
			{
				UIManager.instance.world.waveBattle.InitAndOpen();
			}
			UIManager.instance.world.waveBattle.SetWaveData(result.InfoList);
		}
		yield return null;
		yield break;
	}*/