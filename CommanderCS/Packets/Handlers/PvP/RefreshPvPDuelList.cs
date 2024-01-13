using CommanderCS.MongoDB;
using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Protocols;

namespace CommanderCS.Packets.Handlers.PvP
{
    [Packet(Id = Method.RefreshPvPDuelList)]
    public class RefreshPvPDuelList : BaseMethodHandler<RefreshPvPDuelListRequest>
    {
        public override object Handle(RefreshPvPDuelListRequest @params)
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

    public class RefreshPvPDuelListRequest
    {
    }
}

/*	// Token: 0x06005F83 RID: 24451 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3124", true, true)]
	public void RefreshPvPDuelList()
	{
	}

	// Token: 0x06005F84 RID: 24452 RVA: 0x001AF1B4 File Offset: 0x001AD3B4
	private IEnumerator RefreshPvPDuelListResult(JsonRpcClient.Request request, Protocols.RefreshPvPDuel result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.RefreshGoodsFromNetwork(result.rsoc);
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		if (result.duelList != null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateDuelListUser(EBattleType.Duel, result.duelList[i]));
			}
		}
		UIManager.instance.RefreshOpenedUI();
		yield break;
	}*/