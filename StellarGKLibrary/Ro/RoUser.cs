using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Shared.Regulation;
using UnityEngine;

[JsonObject]
public class RoUser
{
	public int mIdx { get; set; }

	public string tokn { get; set; }

	public string id { get; set; }

	public string uno { get; set; }

	public int channel { get; set; }

	public string changeDeviceCode { get; set; }

	public string openPlatformToken { get; set; }

	public int loginType { get; set; }

	public Platform platform { get; set; }

	public bool isShowGLink { get; set; }

	public string localeCountryCode { get; set; }

	public string platformUserInfo { get; set; }

	public int lastClearStage { get; set; }

	public int lastPlayStage { get; set; }

	public int lastConquestReplayPoint { get; set; }

	public int lastClearAnnihilationStage { get; set; }

	public string nickname { get; set; }

	public int beforeLevel { get; set; }

	public int world { get; set; }

	private int _level { get; set; }

	public int level
	{
		get
		{
			return Mathf.Max(_level, 1);
		}
		set
		{
			_level = value;
		}
	}

	public string thumbnailId { get; set; }

	public RoTroop mainTroop
	{
		get
		{
			if (battleTroopList == null || battleTroopList.Count <= 0)
			{
				return null;
			}
			return battleTroopList[0];
		}
	}

	public List<RoTroop> battleTroopList { get; set; }

	public string guildName { get; set; }

	public int guildWorld { get; set; }

	public List<RoGuildSkill> guildSkillList { get; set; }

	public Dictionary<string, int> worldDuelBuff { get; set; }

	public Dictionary<EWorldDuelBuff, EWorldDuelBuffEffect> activeBuff { get; set; }

	public static RoUser Create(string id = null)
	{
		RoUser roUser = new RoUser();
		roUser.id = id;
		roUser.battleTroopList = new List<RoTroop>();
		roUser.InitEmpty();
		if (roUser.activeBuff == null)
		{
			roUser.activeBuff = new Dictionary<EWorldDuelBuff, EWorldDuelBuffEffect>();
			roUser.activeBuff.Add(EWorldDuelBuff.att, EWorldDuelBuffEffect.b);
			roUser.activeBuff.Add(EWorldDuelBuff.def, EWorldDuelBuffEffect.b);
			roUser.activeBuff.Add(EWorldDuelBuff.sup, EWorldDuelBuffEffect.b);
		}
		return roUser;
	}

	public virtual void InitEmpty()
	{
		battleTroopList.Clear();
		if (guildSkillList == null)
		{
			guildSkillList = new List<RoGuildSkill>();
		}
		if (completeRewardGroupList == null)
		{
			completeRewardGroupList = new List<int>();
		}
	}

	public static RoUser CreateDummyUser(string id, string nickname, string commanderId)
	{
		RoUser roUser = RoUser.Create(id);
		roUser.nickname = nickname;
		roUser.level = UnityEngine.Random.Range(1, 100);
		RoCommander roCommander = RoCommander.Create(commanderId, UnityEngine.Random.Range(1, 1), UnityEngine.Random.Range(1, 6), UnityEngine.Random.Range(1, 10), 0, 0, 0, new List<int>(), "N");
		roUser.battleTroopList.Add(RoTroop.CreateRandomTroop(roCommander, false));
		return roUser;
	}

	public static RoUser CreateAnnihilationEnemy(List<Dictionary<int, Protocols.AnnihilationMapInfo.CommanderData>> enemyList, int stageIdx)
	{
		RoUser roUser = RoUser.Create(null);
		for (int i = 0; i < enemyList.Count; i++)
		{
			roUser.battleTroopList.Add(RoTroop.CreateAnnihilationEnemyTroop(enemyList[i], stageIdx.ToString()));
		}
		return roUser;
	}

	public static RoUser CreateScenarioUser(List<RoLocalUser.ScenarioBattleInfo> userBattleInfo)
	{
		RoUser roUser = RoUser.Create(null);
		roUser.battleTroopList.Add(RoTroop.CreateScenarioTroop(userBattleInfo));
		return roUser;
	}

	public static RoUser CreateWaveBattleUser(List<EnemyUnitDataRow> userBattleInfo)
	{
		RoUser roUser = RoUser.Create(null);
		roUser.battleTroopList.Add(RoTroop.CreateWaveBattleRoTroop(userBattleInfo));
		return roUser;
	}

	public static RoUser CreateInfinityBattleUser(string enemyId)
	{
		RoUser roUser = RoUser.Create(null);
		roUser.battleTroopList = RoTroop.CreateEnemy(enemyId);
		return roUser;
	}

	public void UpdateUserTroop(Protocols.UserInformationResponse.Commander data)
	{
	}

	public void ResetHpTroop()
	{
		for (int i = 0; i < battleTroopList.Count; i++)
		{
			battleTroopList[i].ResetHpUnit();
		}
	}

	public static RoUser CreateRankListUser(EBattleType type, Protocols.PvPRankingList.RankData data)
	{
		RoUser roUser = RoUser.Create(data.id.ToString());
		roUser.nickname = data.name;
		roUser.duelGradeIdx = 3;
		if (type == EBattleType.WaveDuel)
		{
			roUser.duelRanking = data.rank;
			roUser.duelScore = data.score;
			roUser.duelGradeIdx = roUser.GetWaveDuelRankGrade();
		}
		else if (type == EBattleType.Duel)
		{
			roUser.duelRanking = data.rank;
			roUser.duelScore = data.score;
			roUser.duelGradeIdx = roUser.GetDuelRankGrade();
		}
		else if (type == EBattleType.WorldDuel)
		{
			roUser.worldDuelRanking = data.rank;
			roUser.worldDuelScore = data.score;
			roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
		}
		roUser.replayId = data.replayId;
		roUser.level = data.level;
		roUser.thumbnailId = data.thumb;
		roUser.guildName = data.guildName;
		return roUser;
	}

	public static RoUser CreateRankListUser(Protocols.WorldDuelInformation.UserData data)
	{
		RoUser roUser = RoUser.Create(data.userName);
		roUser.nickname = data.userName;
		roUser.worldDuelRanking = 1;
		roUser.worldDuelScore = data.score;
		roUser.worldWinCount = data.win;
		roUser.worldLoseCount = data.lose;
		roUser.world = data.world;
		roUser.guildWorld = data.guildWorld;
		roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
		roUser.guildName = data.guildName;
		roUser.thumbnailId = data.thmb;
		return roUser;
	}

	public static RoUser CreateRaidRankListUser(Protocols.PvPRankingList.RankData data)
	{
		RoUser roUser = RoUser.Create(data.id.ToString());
		roUser.nickname = data.name;
		roUser.level = data.level;
		roUser.thumbnailId = data.thumb;
		roUser.raidRanking = data.rank;
		roUser.raidScore = data.score;
		roUser.guildName = data.guildName;
		roUser.raidGradeIdx = roUser.GetRaidRankGrade();
		return roUser;
	}

	public static RoUser CreateWaveDuelListUser(Protocols.PvPDuelList.PvPDuelData data)
	{
		RoUser roUser = RoUser.Create(null);
		roUser.nickname = data.name;
		roUser.level = data.level;
		roUser.duelRanking = data.rank;
		roUser.id = data.idx.ToString();
		roUser.thumbnailId = data.thumbnail;
		roUser.pvpResult = data.clear == "1";
		for (int i = 1; i <= ConstValue.waveDuelTroopCount; i++)
		{
			string text = i.ToString();
			if (data.decks.ContainsKey(text))
			{
				roUser.battleTroopList.Add(RoTroop.CreateTroop(data.decks[text]));
			}
			else
			{
				roUser.battleTroopList.Add(RoTroop.CreateTroop(new List<Protocols.PvPDuelList.PvPDuelDeck>()));
			}
		}
		roUser.guildName = data.guildName;
		roUser.uno = data.uno.ToString();
		if (data.guildSkills != null)
		{
			for (int j = 0; j < data.guildSkills.Count; j++)
			{
				if (data.guildSkills[j].level > 0)
				{
					roUser.guildSkillList.Add(RoGuildSkill.Create(data.guildSkills[j].idx, data.guildSkills[j].level));
				}
			}
		}
		roUser.SetGroupCompleteData(data.groupBuffs);
		return roUser;
	}

	public static RoUser CreateDuelListUser(EBattleType type, Protocols.PvPDuelList.PvPDuelData data)
	{
		RoUser roUser = RoUser.Create(null);
		roUser.nickname = data.name;
		roUser.level = data.level;
		roUser.id = data.idx.ToString();
		roUser.thumbnailId = data.thumbnail;
		roUser.pvpResult = data.clear == "1";
		RoTroop roTroop = RoTroop.CreateTroop(data.deck);
		roUser.battleTroopList.Add(roTroop);
		roUser.guildName = data.guildName;
		roUser.uno = data.uno.ToString();
		roUser.worldDuelBuff = data.duelBuff;
		roUser.world = data.world;
		if (type == EBattleType.Duel)
		{
			roUser.duelRanking = data.rank;
			roUser.duelScore = data.score;
			roUser.duelGradeIdx = roUser.GetDuelRankGrade();
		}
		else if (type == EBattleType.WorldDuel)
		{
			roUser.worldDuelRanking = data.rank;
			roUser.worldDuelScore = data.score;
			roUser.worldWinCount = data.winCnt;
			roUser.worldLoseCount = data.loseCnt;
			roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
		}
		if (data.activeBuff != null)
		{
			for (int i = 0; i < data.activeBuff.Count; i++)
			{
				EWorldDuelBuff eworldDuelBuff = i + EWorldDuelBuff.att;
				EWorldDuelBuffEffect eworldDuelBuffEffect;
				if (data.activeBuff[i] == 0)
				{
					eworldDuelBuffEffect = EWorldDuelBuffEffect.b;
				}
				else
				{
					eworldDuelBuffEffect = EWorldDuelBuffEffect.d;
				}
				roUser.activeBuff[eworldDuelBuff] = eworldDuelBuffEffect;
			}
		}
		if (data.guildSkills != null)
		{
			for (int j = 0; j < data.guildSkills.Count; j++)
			{
				if (data.guildSkills[j].level > 0)
				{
					roUser.guildSkillList.Add(RoGuildSkill.Create(data.guildSkills[j].idx, data.guildSkills[j].level));
				}
			}
		}
		roUser.SetGroupCompleteData(data.groupBuffs);
		return roUser;
	}

	public static RoUser CreateNPC(string id, string nickname, List<RoTroop> troopList)
	{
		RoUser roUser = RoUser.Create(id);
		roUser.nickname = nickname;
		roUser.battleTroopList = troopList;
		roUser.level = 1;
		return roUser;
	}

	public static RoUser CreateEventBattleEnemy(string id, string nickname, List<RoTroop> troopList)
	{
		RoUser roUser = RoUser.Create(id);
		roUser.nickname = nickname;
		roUser.battleTroopList = troopList;
		roUser.level = 1;
		return roUser;
	}

	public static RoUser CreateWaveBattleEnemy(string id, string nickname, List<RoTroop> troopList)
	{
		RoUser roUser = RoUser.Create(id);
		roUser.nickname = nickname;
		roUser.battleTroopList = troopList;
		roUser.level = 1;
		return roUser;
	}

	public void SetDummyDuelInfo()
	{
		duelScore = UnityEngine.Random.Range(10000, 1000000);
		duelWinCount = duelScore / UnityEngine.Random.Range(100, 120);
		duelLoseCount = duelScore / UnityEngine.Random.Range(100, 120);
		duelWinningStreak = UnityEngine.Random.Range(0, 5);
		SetDuelGrade();
	}

	private void SetDuelGrade()
	{
	}

	public string GetRaidGradeIcon()
	{
		if (raidGradeIdx == 0)
		{
			return unRankedSpriteName;
		}
		RankingDataRow rankingDataRow = RemoteObjectManager.instance.regulation.rankingDtbl[raidGradeIdx.ToString()];
		return rankingDataRow.icon;
	}

	public string GetDuelGradeIcon()
	{
		if (duelGradeIdx == 0)
		{
			return unRankedSpriteName;
		}
		RankingDataRow rankingDataRow = RemoteObjectManager.instance.regulation.rankingDtbl[duelGradeIdx.ToString()];
		return rankingDataRow.icon;
	}

	public string GetDuelGradeIcon(int idx)
	{
		if (idx == 0)
		{
			return unRankedSpriteName;
		}
		RankingDataRow rankingDataRow = RemoteObjectManager.instance.regulation.rankingDtbl[idx.ToString()];
		return rankingDataRow.icon;
	}

	public int GetDuelRankGrade()
	{
		int num = 3;
		List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.Challenge);
		for (int i = 0; i < list.Count; i++)
		{
			RankingDataRow rankingDataRow = list[i];
			if (rankingDataRow.rankingType2 == ERankingType.Normal)
			{
				if (duelScore >= rankingDataRow.ranking1 && duelRanking <= rankingDataRow.ranking2)
				{
					return rankingDataRow.r_idx;
				}
			}
			else if (duelScore >= rankingDataRow.ranking1)
			{
				return rankingDataRow.r_idx;
			}
		}
		return num;
	}

	public int GetWorldDuelRankGrade()
	{
		int num = 827;
		List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.WorldDuel);
		for (int i = 0; i < list.Count; i++)
		{
			RankingDataRow rankingDataRow = list[i];
			if (rankingDataRow.rankingType2 == ERankingType.Normal)
			{
				if (worldDuelScore >= rankingDataRow.ranking1 && worldDuelRanking <= rankingDataRow.ranking2)
				{
					return rankingDataRow.r_idx;
				}
			}
			else if (worldDuelScore >= rankingDataRow.ranking1)
			{
				return rankingDataRow.r_idx;
			}
		}
		return num;
	}

	public int GetWaveDuelRankGrade()
	{
		int num = 3;
		List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.WaveDuel);
		for (int i = 0; i < list.Count; i++)
		{
			RankingDataRow rankingDataRow = list[i];
			if (rankingDataRow.rankingType2 == ERankingType.Normal && duelRanking >= rankingDataRow.ranking1 && duelRanking <= rankingDataRow.ranking2)
			{
				return rankingDataRow.r_idx;
			}
		}
		return num;
	}

	public int GetRaidRankGrade()
	{
		int num = 105;
		List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.Raid);
		for (int i = 0; i < list.Count; i++)
		{
			RankingDataRow rankingDataRow = list[i];
			if (rankingDataRow.rankingType2 == ERankingType.Normal && raidRanking >= rankingDataRow.ranking1 && raidRanking <= rankingDataRow.ranking2)
			{
				return rankingDataRow.r_idx;
			}
		}
		return num;
	}

	public void SetGroupCompleteData(List<int> list)
	{
		if (list != null)
		{
			completeRewardGroupList = list;
			Regulation regulation = RemoteObjectManager.instance.regulation;
			completeRewardGroupList.Sort((int a, int b) => regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => int.Parse(data.groupIdx) == b).typeIndex.CompareTo(regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => int.Parse(data.groupIdx) == a).typeIndex));
		}
	}

	public List<string> GetBuffIdxList()
	{
		List<string> list = new List<string>();
		Regulation regulation = RemoteObjectManager.instance.regulation;
		using (Dictionary<EWorldDuelBuff, EWorldDuelBuffEffect>.Enumerator enumerator = activeBuff.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RoUser.<GetBuffIdxList>c__AnonStorey2 <GetBuffIdxList>c__AnonStorey = new RoUser.<GetBuffIdxList>c__AnonStorey2();
				<GetBuffIdxList>c__AnonStorey.data = enumerator.Current;
				string text = string.Format("{0}{1}", <GetBuffIdxList>c__AnonStorey.data.Key.ToString(), <GetBuffIdxList>c__AnonStorey.data.Value.ToString());
				int level = Mathf.Max(worldDuelBuff[text], 1);
				StrongestBuffBattleDataRow strongestBuffBattleDataRow = regulation.strongestBuffBattleDtbl.Find((StrongestBuffBattleDataRow row) => row.buffTarget == <GetBuffIdxList>c__AnonStorey.data.Key && row.buffEffectType == <GetBuffIdxList>c__AnonStorey.data.Value && row.buffLevel == level);
				list.Add(strongestBuffBattleDataRow.idx);
			}
		}
		return list;
	}

	public int duelScore;

	public int duelNextScore;

	public int duelRanking;

	public float duelRankingRate;

	public int duelGradeIdx;

	public int duelWinCount;

	public int duelLoseCount;

	public int duelWinningStreak;

	public int duelLosingStreak;

	public int winRank;

	public int winRankIdx;

	public string replayId;

	public int raidScore;

	public int raidNextScore;

	public int raidRanking;

	public float raidRankingRate;

	public int raidGradeIdx;

	public int raidCount;

	public int raidBestScore;

	public int raidAverageScore;

	public int raidRank;

	public int raidRewardPoint;

	public int worldDuelRanking;

	public int worldDuelScore;

	public int worldWinRank;

	public int worldWinRankIdx;

	public int worldWinCount;

	public int worldLoseCount;

	public int mainTotalPower;

	public bool pvpResult;

	public int todayFavorUpCount;

	public int duelPoint = 8;

	public int rewardDuelPoint = 4;

	public List<int> completeRewardGroupList;

	private string unRankedSpriteName = "icon_Ranking_00";
}
