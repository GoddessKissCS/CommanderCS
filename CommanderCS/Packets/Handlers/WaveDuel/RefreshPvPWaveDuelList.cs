using CommanderCS.Database;
using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace StellarGK.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.RefreshPvPWaveDuelList)]
    public class RefreshPvPWaveDuelList : BaseMethodHandler<RefreshPvPWaveDuelListRequest>
    {
        public override object Handle(RefreshPvPWaveDuelListRequest @params)
        {
            var user = GetUserGameProfile();

            // need to check score and the get duelist between the range

            var rsoc = DatabaseManager.GameProfile.UserResources2Resource(user.UserResources);

            RefreshPvPDuel refreshDuel = new()
            {
                duelList = [],
                openRemain = 86400,
                remain = 86400,
                time = (int)TimeManager.CurrentEpoch,
                rsoc = rsoc,
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = refreshDuel,
            };

            return response;
        }
    }

    public class RefreshPvPWaveDuelListRequest
    {
    }
}

/*	// Token: 0x06005F95 RID: 24469 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3402", true, true)]
	public void RefreshPvPWaveDuelList()
	{
	}

	// Token: 0x06005F96 RID: 24470 RVA: 0x001AF310 File Offset: 0x001AD510
	private IEnumerator RefreshPvPWaveDuelListResult(JsonRpcClient.Request request, Protocols.RefreshPvPDuel result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.RefreshGoodsFromNetwork(result.rsoc);
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		this.localUser.currentSeasonOpenRemainDuelTime.SetByDuration((double)result.openRemain);
		if (result.duelList != null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateWaveDuelListUser(result.duelList[i]));
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/