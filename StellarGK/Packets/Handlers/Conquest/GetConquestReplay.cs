using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Conquest
{
    public class GetConquestReplay
    {
        
    }
}
/*	// Token: 0x0600608A RID: 24714 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "7518", true, true)]
	public void GetConquestReplay(string rid)
	{
	}

	// Token: 0x0600608B RID: 24715 RVA: 0x001B0774 File Offset: 0x001AE974
	private IEnumerator GetConquestReplayResult(JsonRpcClient.Request request, object result)
	{
		if (result == null)
		{
			if (this.localUser.playingChatRecord != null)
			{
				this.localUser.playingChatRecord.hasRecord = false;
				this.localUser.playingChatRecord = null;
			}
			NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("19079"));
			yield break;
		}
		this.localUser.playingChatRecord = null;
		JsonSerializerSettings serializerSettings = Regulation.SerializerSettings;
		Record record = (Record)JsonConvert.DeserializeObject<JToken>(result.ToString());
		BattleData battleData = BattleData.Create(EBattleType.Conquest);
		battleData.attacker = this.localUser.CreateForBattle(new List<RoTroop> { null });
		battleData.defender = RoUser.Create(null);
		battleData.isReplayMode = true;
		battleData.record = record;
		battleData.move = EBattleResultMove.Conquest;
		battleData.attacker.nickname = record.initState.dualData._playerName;
		battleData.attacker.level = record.initState.dualData._playerLevel;
		battleData.attacker.guildName = record.initState.dualData._playerGuildName;
		battleData.defender.nickname = record.initState.dualData._enemyName;
		battleData.defender.level = record.initState.dualData._enemyLevel;
		battleData.defender.duelRanking = record.initState.dualData._enemyRank;
		battleData.defender.guildName = record.initState.dualData._enemyGuildName;
		battleData.defender.uno = record.initState.dualData._enemyUno;
		BattleData.Set(battleData);
		Loading.Load(Loading.Battle);
		yield break;
	}*/