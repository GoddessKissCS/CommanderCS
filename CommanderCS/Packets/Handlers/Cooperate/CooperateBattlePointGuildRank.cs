using CommanderCS.Library.Enums;
using CommanderCS.Library.Protocols;

namespace CommanderCS.Packets.Handlers.Cooperate
{
    [Packet(Id = Method.CooperateBattlePointGuildRank)]
    public class CooperateBattlePointGuildRank : BaseMethodHandler<CooperateBattlePointGuildRankRequest>
    {
        public override object Handle(CooperateBattlePointGuildRankRequest @params)
        {
            ResponsePacket response = new ResponsePacket()
            {
                Id = BasePacket.Id,
            };

            // ADD sometime missing data

            List<CooperateBattlePointGuildRankingInfo> cooperateBattlePointGuildRankingInfos = new() { };

            response.Result = cooperateBattlePointGuildRankingInfos;

            return response;
        }
    }

    public class CooperateBattlePointGuildRankRequest
    { }
}

/*	// Token: 0x06006105 RID: 24837 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7603", true, true)]
	public void CooperateBattlePointGuildRank()
	{
	}

	// Token: 0x06006106 RID: 24838 RVA: 0x001B1134 File Offset: 0x001AF334
	private IEnumerator CooperateBattlePointGuildRankResult(JsonRpcClient.Request request, List<Protocols.CooperateBattlePointGuildRankingInfo> result)
	{
		if (!UIManager.instance.world.cooperateBattle.isActive)
		{
			yield break;
		}
		UIManager.instance.world.cooperateBattle.SetRankingData(result);
		yield break;
	}

	// Token: 0x06006107 RID: 24839 RVA: 0x001B1150 File Offset: 0x001AF350
	private IEnumerator CooperateBattlePointGuildRankError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			if (UIManager.instance.world.guild.isActive)
			{
				UIManager.instance.world.guild.Close();
			}
		}
		else if (code = 71603)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("5090032"));
		}
		yield break;
	}*/