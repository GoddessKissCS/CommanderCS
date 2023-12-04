using CommanderCS.Host;

namespace CommanderCS.Packets.Handlers.PvP
{
    [Packet(Id = Method.PvPRankingList)]
    public class PvPRankingList : BaseMethodHandler<PvPRankingListRequest>
    {
        public override object Handle(PvPRankingListRequest @params)
        {
            Protocols.PvPRankingList pvPRankingList = new()
            {
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
            };

            return response;
        }
    }

    public class PvPRankingListRequest
    {
    }
}

/*	// Token: 0x06005F81 RID: 24449 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3123", true, true)]
	public void PvPRankingList()
	{
	}

	// Token: 0x06005F82 RID: 24450 RVA: 0x001AF190 File Offset: 0x001AD390
	private IEnumerator PvPRankingListResult(JsonRpcClient.Request request, object result)
	{
		this.duelRankingList.Clear();
		if (result != null)
		{
		}
		Protocols.PvPRankingList pvPRankingList = this._ConvertJObject<Protocols.PvPRankingList>(result);
		if (pvPRankingList = null)
		{
			yield break;
		}
		for (int i = 0; i < pvPRankingList.rankList.Count; i++)
		{
			RoUser roUser = RoUser.CreateRankListUser(EBattleType.Duel, pvPRankingList.rankList[i]);
			this.duelRankingList.Add(roUser);
		}
		UIPopup.Create<RankingList>("RankingList").Set(EBattleType.Duel, RemoteObjectManager.instance.duelRankingList);
		yield break;
	}*/