using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarGK.Packets.Handlers.Replay
{
    public class GetReplayInfo
    {
        
    }
}
/*	// Token: 0x06005FE5 RID: 24549 RVA: 0x000120F8 File Offset: 0x000102F8
	[JsonRpcClient.RequestAttribute("http://gk.flerogames.com/checkData.php", "3133", true, true)]
	public void GetReplayInfo(string rid, ERePlayType type)
	{
	}

	// Token: 0x06005FE6 RID: 24550 RVA: 0x001AF954 File Offset: 0x001ADB54
	private IEnumerator GetReplayInfoResult(JsonRpcClient.Request request, Protocols.RecordInfo result)
	{
		if (result == null)
		{
			yield break;
		}
		if (result.data == null)
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
		Record record = (Record)JsonConvert.DeserializeObject<JToken>(result.data.ToString());
		BattleData battleData = BattleData.Get();
		battleData.isReplayMode = true;
		battleData.record = record;
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
	}

	// Token: 0x06005FE7 RID: 24551 RVA: 0x001AF978 File Offset: 0x001ADB78
	private IEnumerator GetReplayInfoError(JsonRpcClient.Request request, string result, int code)
	{
		if (this.localUser.playingChatRecord != null)
		{
			this.localUser.playingChatRecord.hasRecord = false;
			this.localUser.playingChatRecord = null;
		}
		NetworkAnimation.Instance.CreateFloatingText(new Vector3(0f, -0.5f, 0f), Localization.Get("19079"));
		yield break;
	}*/