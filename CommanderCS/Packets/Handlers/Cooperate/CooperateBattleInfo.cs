using CommanderCS.Host;
using CommanderCSLibrary.Shared.Enum;
using static CommanderCS.Packets.Handlers.Cooperate.CooperateBattleInfo;

namespace CommanderCS.Packets.Handlers.Cooperate
{
	[Packet(Id = Method.CooperateBattleInfo)]
    public class CooperateBattleInfo : BaseMethodHandler<CooperateBattleInfoRequest>
    {
        public override object Handle(CooperateBattleInfoRequest @params)
        {
			ResponsePacket response = new ResponsePacket()
			{
				Id = BasePacket.Id,
			};

			CommanderCSLibrary.Shared.Protocols.CooperateBattleData battleData = new()
			{
				coop = new()
				{
					stage = 1,
					step = 1,
					dmg = 1,
					remain = 5,
					ticket = 1,
				},
				recv = new()
				{
					stage = 1,
					step = 1
				}
			};

			response.Result = battleData;

			return response;

        }

		public class CooperateBattleInfoRequest
		{

		}
    }
}

/*	// Token: 0x06006102 RID: 24834 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7601", true, true)]
	public void CooperateBattleInfo()
	{
	}

	// Token: 0x06006103 RID: 24835 RVA: 0x001B10EC File Offset: 0x001AF2EC
	private IEnumerator CooperateBattleInfoResult(JsonRpcClient.Request request, Protocols.CooperateBattleData result)
	{
		int coopStage = this.localUser.coopStage;
		if (!UIManager.instance.world.existCooperateBattle)
		{
			UIManager.instance.world.cooperateBattle.InitAndOpen(result);
		}
		else if (!UIManager.instance.world.cooperateBattle.isActive)
		{
			UIManager.instance.world.cooperateBattle.InitAndOpen(result);
		}
		else
		{
			UIManager.instance.world.cooperateBattle.Set(result);
		}
		if (coopStage > 0 && this.localUser.coopStage > coopStage)
		{
			UIManager.instance.world.cooperateBattle.LevelUp();
		}
		yield break;
	}

	// Token: 0x06006104 RID: 24836 RVA: 0x001B1110 File Offset: 0x001AF310
	private IEnumerator CooperateBattleInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (code = 71001)
		{
			NetworkAnimation.Instance.CreateFloatingText(Localization.Get("110303"));
			if (UIManager.instance.world.guild.isActive)
			{
				UIManager.instance.world.guild.Close();
			}
		}
		else if (code = 71605)
		{
			int num = int.Parse(this.regulation.defineDtbl["COOPERATE_BATTLE_OPEN_GUILD_LEVEL"].value);
			NetworkAnimation.Instance.CreateFloatingText(Localization.Format("110089", new object[] { num }));
		}
		yield break;
	}*/