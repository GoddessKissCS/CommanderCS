using CommanderCS.Host;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using static CommanderCS.Packets.Handlers.WaveDuel.PvPWaveDuelList;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.PvPWaveDuelList)]
    public class PvPWaveDuelList : BaseMethodHandler<PvPWaveDuelListRequest>
    {
        public override object Handle(PvPWaveDuelListRequest @params)
        {
            // TODO FINISH
            // need to check score and the get duelist between the range

            //			User.RankingData.PvPDuelRankingData.score;

            CommanderCSLibrary.Shared.Protocols.PvPDuelList pvPDuel = new()
            {
                duelList = [],
                openRemain = 86400,
                remain = 86400,
                time = (int)TimeManager.CurrentEpoch,
                user = User.RankingData.PvPDuelRankingData
            };

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = pvPDuel,
            };

            return response;
        }

        public class PvPWaveDuelListRequest
        {
        }
    }
}

/*	// Token: 0x06005F97 RID: 24471 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3401", true, true)]
	public void PvPWaveDuelList()
	{
	}

	// Token: 0x06005F98 RID: 24472 RVA: 0x001AF334 File Offset: 0x001AD534
	private IEnumerator PvPWaveDuelListResult(JsonRpcClient.Request request, Protocols.PvPDuelList result)
	{
		this.localUser.duelTargetList.Clear();
		this.localUser.duelTargetRefreshTime.SetByDuration((double)result.remain);
		this.localUser.currentSeasonDuelTime.SetByDuration((double)result.time);
		this.localUser.currentSeasonOpenRemainDuelTime.SetByDuration((double)result.openRemain);
		if (result.duelList is not null)
		{
			for (int i = 1; i <= result.duelList.Count; i++)
			{
				this.localUser.duelTargetList.Add(result.duelList[i].idx, RoUser.CreateWaveDuelListUser(result.duelList[i]));
			}
		}
		if (result.user is not null)
		{
			this.localUser.duelScore = result.user.score;
			this.localUser.duelNextScore = result.user.nextScore;
			this.localUser.duelGradeIdx = result.user.rewardId;
			this.localUser.duelWinningStreak = Mathf.Max(result.user.winningStreak - 1, 0);
			this.localUser.duelRanking = result.user.ranking;
			this.localUser.duelRankingRate = result.user.rankingRate;
			this.localUser.duelWinCount = result.user.winCnt;
			this.localUser.duelLoseCount = result.user.loseCnt;
			this.localUser.duelPoint = result.user.duelPoint;
			this.localUser.rewardDuelPoint = result.user.rewardDuelPoint;
		}
		UIManager.instance.world.rankingBattle.InitAndOpen(EBattleType.WaveDuel);
		yield break;
	}*/