using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Regulation.DataRows;
using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Ro
{
    [JsonObject]
    public class RoUser
    {
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
                return Math.Max(_level, 1);
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
                if (battleTroopList is null || battleTroopList.Count <= 0)
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
            RoUser roUser = new()
            {
                id = id,
                battleTroopList = []
            };
            roUser.InitEmpty();
            if (roUser.activeBuff is null)
            {
                roUser.activeBuff = new Dictionary<EWorldDuelBuff, EWorldDuelBuffEffect>
                {
                    { EWorldDuelBuff.att, EWorldDuelBuffEffect.b },
                    { EWorldDuelBuff.def, EWorldDuelBuffEffect.b },
                    { EWorldDuelBuff.sup, EWorldDuelBuffEffect.b }
                };
            }
            return roUser;
        }

        public virtual void InitEmpty()
        {
            battleTroopList.Clear();
            if (guildSkillList is null)
            {
                guildSkillList = [];
            }
            if (completeRewardGroupList is null)
            {
                completeRewardGroupList = [];
            }
        }

        //public static RoUser CreateDummyUser(string id, string nickname, string commanderId)
        //{
        //	RoUser roUser = Create(id);
        //	roUser.nickname = nickname;
        //	roUser.level = Random.Shared.Next(1, 100);
        //	RoCommander commander = RoCommander.Create(commanderId, Random.Range(1, 1), Random.Range(1, 6), Random.Range(1, 10), 0, 0, 0, new List<int>());
        //	roUser.battleTroopList.Add(RoTroop.CreateRandomTroop(commander));
        //	return roUser;
        //}

        //public static RoUser CreateAnnihilationEnemy(List<Dictionary<int, Protocols.AnnihilationMapInfo.CommanderData>> enemyList, int stageIdx)
        //{
        //	RoUser roUser = Create();
        //	for (int i = 0; i < enemyList.Count; i++)
        //	{
        //		roUser.battleTroopList.Add(RoTroop.CreateAnnihilationEnemyTroop(enemyList[i], stageIdx.ToString()));
        //	}
        //	return roUser;
        //}

        //public static RoUser CreateScenarioUser(List<RoLocalUser.ScenarioBattleInfo> userBattleInfo)
        //{
        //	RoUser roUser = Create();
        //	roUser.battleTroopList.Add(RoTroop.CreateScenarioTroop(userBattleInfo));
        //	return roUser;
        //}

        //public static RoUser CreateWaveBattleUser(List<EnemyUnitDataRow> userBattleInfo)
        //{
        //	RoUser roUser = Create();
        //	roUser.battleTroopList.Add(RoTroop.CreateWaveBattleRoTroop(userBattleInfo));
        //	return roUser;
        //}

        //public static RoUser CreateInfinityBattleUser(string enemyId)
        //{
        //    RoUser roUser = Create();
        //    roUser.battleTroopList = RoTroop.CreateEnemy(enemyId);
        //    return roUser;
        //}

        //public void UpdateUserTroop(Protocols.UserInformationResponse.Commander data)
        //{
        //}

        //public void ResetHpTroop()
        //{
        //    for (int i = 0; i < battleTroopList.Count; i++)
        //    {
        //        battleTroopList[i].ResetHpUnit();
        //    }
        //}

        //public static RoUser CreateRankListUser(EBattleType type, Protocols.PvPRankingList.RankData data)
        //{
        //	RoUser roUser = Create(data.id.ToString());
        //	roUser.nickname = data._name;
        //	roUser.duelGradeIdx = 3;
        //	switch (type)
        //	{
        //	case EBattleType.WaveDuel:
        //		roUser.duelRanking = data.rank;
        //		roUser.duelScore = data.score;
        //		roUser.duelGradeIdx = roUser.GetWaveDuelRankGrade();
        //		break;
        //	case EBattleType.Duel:
        //		roUser.duelRanking = data.rank;
        //		roUser.duelScore = data.score;
        //		roUser.duelGradeIdx = roUser.GetDuelRankGrade();
        //		break;
        //	case EBattleType.WorldDuel:
        //		roUser.worldDuelRanking = data.rank;
        //		roUser.worldDuelScore = data.score;
        //		roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
        //		break;
        //	}
        //	roUser.replayId = data.replayId;
        //	roUser.level = data.level;
        //	roUser.thumbnailId = data.thumb;
        //	roUser.guildName = data.guildName;
        //	return roUser;
        //}

        //public static RoUser CreateRankListUser(Protocols.WorldDuelInformation.UserData data)
        //{
        //	RoUser roUser = Create(data.userName);
        //	roUser.nickname = data.userName;
        //	roUser.worldDuelRanking = 1;
        //	roUser.worldDuelScore = data.score;
        //	roUser.worldWinCount = data.win;
        //	roUser.worldLoseCount = data.lose;
        //	roUser.world = data.world;
        //	roUser.guildWorld = data.guildWorld;
        //	roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
        //	roUser.guildName = data.guildName;
        //	roUser.thumbnailId = data.thmb;
        //	return roUser;
        //}

        //public static RoUser CreateRaidRankListUser(Protocols.PvPRankingList.RankData data)
        //{
        //	RoUser roUser = Create(data.id.ToString());
        //	roUser.nickname = data._name;
        //	roUser.level = data.level;
        //	roUser.thumbnailId = data.thumb;
        //	roUser.raidRanking = data.rank;
        //	roUser.raidScore = data.score;
        //	roUser.guildName = data.guildName;
        //	roUser.raidGradeIdx = roUser.GetRaidRankGrade();
        //	return roUser;
        //}

        //public static RoUser CreateWaveDuelListUser(Protocols.PvPDuelList.PvPDuelData data)
        //{
        //	RoUser roUser = Create();
        //	roUser.nickname = data._name;
        //	roUser.level = data.level;
        //	roUser.duelRanking = data.rank;
        //	roUser.id = data.idx.ToString();
        //	roUser.thumbnailId = data.thumbnail;
        //	roUser.pvpResult = data.clear == "1";
        //	for (int i = 1; i <= ConstValue.waveDuelTroopCount; i++)
        //	{
        //		string key = i.ToString();
        //		if (data.decks.ContainsKey(key))
        //		{
        //			roUser.battleTroopList.Add(RoTroop.CreateTroop(data.decks[key]));
        //		}
        //		else
        //		{
        //			roUser.battleTroopList.Add(RoTroop.CreateTroop(new List<Protocols.PvPDuelList.PvPDuelDeck>()));
        //		}
        //	}
        //	roUser.guildName = data.guildName;
        //	roUser.uno = data.uno.ToString();
        //	if (data.guildSkills is not null)
        //	{
        //		for (int j = 0; j < data.guildSkills.Count; j++)
        //		{
        //			if (data.guildSkills[j].level > 0)
        //			{
        //				roUser.guildSkillList.Add(RoGuildSkill.Create(data.guildSkills[j].idx, data.guildSkills[j].level));
        //			}
        //		}
        //	}
        //	roUser.SetGroupCompleteData(data.groupBuffs);
        //	return roUser;
        //}

        //public static RoUser CreateDuelListUser(EBattleType type, Protocols.PvPDuelList.PvPDuelData data)
        //{
        //	RoUser roUser = Create();
        //	roUser.nickname = data.name;
        //	roUser.level = data.level;
        //	roUser.id = data.idx.ToString();
        //	roUser.thumbnailId = data.thumbnail;
        //	roUser.pvpResult = data.clear == "1";
        //	RoTroop item = RoTroop.CreateTroop(data.deck);
        //	roUser.battleTroopList.Add(item);
        //	roUser.guildName = data.guildName;
        //	roUser.uno = data.uno.ToString();
        //	roUser.worldDuelBuff = data.duelBuff;
        //	roUser.world = data.world;
        //	switch (type)
        //	{
        //	case EBattleType.Duel:
        //		roUser.duelRanking = data.rank;
        //		roUser.duelScore = data.score;
        //		roUser.duelGradeIdx = roUser.GetDuelRankGrade();
        //		break;
        //	case EBattleType.WorldDuel:
        //		roUser.worldDuelRanking = data.rank;
        //		roUser.worldDuelScore = data.score;
        //		roUser.worldWinCount = data.winCnt;
        //		roUser.worldLoseCount = data.loseCnt;
        //		roUser.duelGradeIdx = roUser.GetWorldDuelRankGrade();
        //		break;
        //	}
        //	if (data.activeBuff is not null)
        //	{
        //		for (int i = 0; i < data.activeBuff.Count; i++)
        //		{
        //			EWorldDuelBuff key = (EWorldDuelBuff)(i + 1);
        //			EWorldDuelBuffEffect eWorldDuelBuffEffect = EWorldDuelBuffEffect.b;
        //			eWorldDuelBuffEffect = ((data.activeBuff[i] == 0) ? EWorldDuelBuffEffect.b : EWorldDuelBuffEffect.d);
        //			roUser.activeBuff[key] = eWorldDuelBuffEffect;
        //		}
        //	}
        //	if (data.guildSkills is not null)
        //	{
        //		for (int j = 0; j < data.guildSkills.Count; j++)
        //		{
        //			if (data.guildSkills[j].level > 0)
        //			{
        //				roUser.guildSkillList.Add(RoGuildSkill.Create(data.guildSkills[j].idx, data.guildSkills[j].level));
        //			}
        //		}
        //	}
        //	roUser.SetGroupCompleteData(data.groupBuffs);
        //	return roUser;
        //}

        public static RoUser CreateNPC(string id, string nickname, List<RoTroop> troopList)
        {
            RoUser roUser = Create(id);
            roUser.nickname = nickname;
            roUser.battleTroopList = troopList;
            roUser.level = 1;
            return roUser;
        }

        public static RoUser CreateEventBattleEnemy(string id, string nickname, List<RoTroop> troopList)
        {
            RoUser roUser = Create(id);
            roUser.nickname = nickname;
            roUser.battleTroopList = troopList;
            roUser.level = 1;
            return roUser;
        }

        public static RoUser CreateWaveBattleEnemy(string id, string nickname, List<RoTroop> troopList)
        {
            RoUser roUser = Create(id);
            roUser.nickname = nickname;
            roUser.battleTroopList = troopList;
            roUser.level = 1;
            return roUser;
        }

        //public void SetDummyDuelInfo()
        //{
        //	duelScore = Random.Range(10000, 1000000);
        //	duelWinCount = duelScore / Random.Range(100, 120);
        //	duelLoseCount = duelScore / Random.Range(100, 120);
        //	duelWinningStreak = Random.Range(0, 5);
        //	SetDuelGrade();
        //}

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
            int result = 3;
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
            return result;
        }

        public int GetWorldDuelRankGrade()
        {
            int result = 827;
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
            return result;
        }

        public int GetWaveDuelRankGrade()
        {
            int result = 3;
            List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.WaveDuel);
            for (int i = 0; i < list.Count; i++)
            {
                RankingDataRow rankingDataRow = list[i];
                if (rankingDataRow.rankingType2 == ERankingType.Normal && duelRanking >= rankingDataRow.ranking1 && duelRanking <= rankingDataRow.ranking2)
                {
                    return rankingDataRow.r_idx;
                }
            }
            return result;
        }

        public int GetRaidRankGrade()
        {
            int result = 105;
            List<RankingDataRow> list = RemoteObjectManager.instance.regulation.FindDuelRankingList(ERankingContentsType.Raid);
            for (int i = 0; i < list.Count; i++)
            {
                RankingDataRow rankingDataRow = list[i];
                if (rankingDataRow.rankingType2 == ERankingType.Normal && raidRanking >= rankingDataRow.ranking1 && raidRanking <= rankingDataRow.ranking2)
                {
                    return rankingDataRow.r_idx;
                }
            }
            return result;
        }

        public void SetGroupCompleteData(List<int> list)
        {
            if (list is null)
            {
                return;
            }
            completeRewardGroupList = list;
            Regulation.Regulation regulation = RemoteObjectManager.instance.regulation;
            completeRewardGroupList.Sort((int a, int b) => regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => int.Parse(data.groupIdx) == b).typeIndex.CompareTo(regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => int.Parse(data.groupIdx) == a).typeIndex));
        }

        public List<string> GetBuffIdxList()
        {
            List<string> list = [];
            Regulation.Regulation regulation = RemoteObjectManager.instance.regulation;
            foreach (KeyValuePair<EWorldDuelBuff, EWorldDuelBuffEffect> data in activeBuff)
            {
                string key = $"{data.Key.ToString()}{data.Value.ToString()}";
                int level = Math.Max(worldDuelBuff[key], 1);
                StrongestBuffBattleDataRow strongestBuffBattleDataRow = regulation.strongestBuffBattleDtbl.Find((StrongestBuffBattleDataRow row) => row.buffTarget == data.Key && row.buffEffectType == data.Value && row.buffLevel == level);
                list.Add(strongestBuffBattleDataRow.idx);
            }
            return list;
        }
    }
}