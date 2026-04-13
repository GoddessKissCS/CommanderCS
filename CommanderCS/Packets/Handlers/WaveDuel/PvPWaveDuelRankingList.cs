using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;
using CommanderCS.MongoDB;
using CommanderCS.MongoDB.Schemes;
using Newtonsoft.Json;

namespace CommanderCS.Packets.Handlers.WaveDuel
{
    [Packet(Id = Method.PvPWaveDuelRankingList)]
    public class PvPWaveDuelRankingList : BaseMethodHandler<PvPWaveDuelRankingListRequest>
    {
        public override object Handle(PvPWaveDuelRankingListRequest request)
        {
            GameProfileScheme User = GetUserGameProfile();

            List<PvPRankingList.RankData> rankList = [];

            rankList.Add(new()
            {
                grade = 1,
                score = 10000,
                guildServer = 1,
                guildName = "kek",
                id = 1,
                level = 140,
                rank = 1,
                replayId = "1",
                thumb = "1001",
                time = 0,
                _name = "s"
            });

            // TODO: Pull actual ranked players from DB and populate rankList

            PvPRankingList pvPRankingList = new()
            {
                rankList = rankList,
                user = User.RankingData.WaveDuelRankingData,
            };


            var obj = JsonConvert.SerializeObject(pvPRankingList);

            ResponsePacket response = new()
            {
                Id = BasePacket.Id,
                Result = obj,
            };

            return response;
        }
    }

    public class PvPWaveDuelRankingListRequest
    {
    }
}

/*	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3403", true, true)]
	public void PvPWaveDuelRankingList()
	{
	}

	// Token: 0x06005F94 RID: 24468 RVA: 0x001AF2EC File Offset: 0x001AD4EC
	private IEnumerator PvPWaveDuelRankingListResult(JsonRpcClient.Request request, object result)
	{
		this.duelRankingList.Clear();
		if (result !=null)
		{
		}
		Protocols.PvPRankingList pvPRankingList = this._ConvertJObject<Protocols.PvPRankingList>(result);
		if (pvPRankingList = null)
		{
			yield break;
		}
		for (int i = 0; i < pvPRankingList.rankList.Count; i++)
		{
			RoUser roUser = RoUser.CreateRankListUser(EBattleType.WaveDuel, pvPRankingList.rankList[i]);
			this.duelRankingList.Add(roUser);
		}
		UIPopup.Create<RankingList>("RankingList").Set(EBattleType.WaveDuel, RemoteObjectManager.instance.duelRankingList);
		yield break;
	}*/
