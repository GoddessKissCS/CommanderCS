namespace StellarGKLibrary.Shared.Battle
{
    public class ClearMission
    {
        public int clearCount
        {
            get
            {
                return this._clearCount;
            }
            set
            {
                if (this._clearCount == value)
                {
                    return;
                }
                this._clearCount = value;
                if (this.OnChangeClearState != null)
                {
                    this.OnChangeClearState();
                }
            }
        }

        public int missionCount
        {
            get
            {
                return this._missions.Count;
            }
        }

        //public void Init(Simulator simulator)
        //{
        //	this._updater = new Action<ClearMissionItem>[]
        //	{
        //		new Action<ClearMissionItem>(this.None),
        //		new Action<ClearMissionItem>(this.Survival),
        //		new Action<ClearMissionItem>(this.LimitedTurn),
        //		new Action<ClearMissionItem>(this.Include_Attacker),
        //		new Action<ClearMissionItem>(this.Include_Defender),
        //		new Action<ClearMissionItem>(this.Include_Supporter),
        //		new Action<ClearMissionItem>(this.Include_Commander),
        //		new Action<ClearMissionItem>(this.Include_Minimum_Count),
        //		new Action<ClearMissionItem>(this.All_Survival),
        //		new Action<ClearMissionItem>(this.Less_Attacker),
        //		new Action<ClearMissionItem>(this.Less_Defender),
        //		new Action<ClearMissionItem>(this.Less_Supporter),
        //		new Action<ClearMissionItem>(this.Less_UseActiveSkill),
        //		new Action<ClearMissionItem>(this.Include_Grade_2),
        //		new Action<ClearMissionItem>(this.Include_Grade_3),
        //		new Action<ClearMissionItem>(this.Include_Grade_4),
        //		new Action<ClearMissionItem>(this.Include_Grade_5),
        //		new Action<ClearMissionItem>(this.Less_Grade_2),
        //		new Action<ClearMissionItem>(this.Less_Grade_3),
        //		new Action<ClearMissionItem>(this.Less_Grade_4),
        //		new Action<ClearMissionItem>(this.Less_Grade_5),
        //		new Action<ClearMissionItem>(this.ClearStage)
        //	};
        //	this._simulator = simulator;
        //	this._clearCount = 0;
        //	this._missions.Clear();
        //	Regulation regulation = this._simulator.regulation;
        //	if (this._simulator.initState.battleType == EBattleType.Plunder)
        //	{
        //		WorldMapStageDataRow worldMapStageDataRow = regulation.worldMapStageDtbl[this._simulator.initState.stageID];
        //		this.Add(new ClearMissionItem(EBattleClearCondition.ClearStage, 1, "0"));
        //		this.Add(new ClearMissionItem(EBattleClearCondition.LimitedTurn, 2, worldMapStageDataRow.turn1.ToString()));
        //		this.Add(new ClearMissionItem(EBattleClearCondition.LimitedTurn, 4, worldMapStageDataRow.turn2.ToString()));
        //	}
        //	else if (this._simulator.initState.battleType == EBattleType.ScenarioBattle)
        //	{
        //		ScenarioBattleDataRow scenarioBattleDataRow = regulation.scenarioBattleDtbl[this._simulator.initState.stageID];
        //		this.Add(new ClearMissionItem(EBattleClearCondition.ClearStage, 1, "0"));
        //		this.Add(new ClearMissionItem(EBattleClearCondition.LimitedTurn, 2, scenarioBattleDataRow.turn1.ToString()));
        //		this.Add(new ClearMissionItem(EBattleClearCondition.LimitedTurn, 4, scenarioBattleDataRow.turn2.ToString()));
        //	}
        //	else if (this._simulator.initState.battleType == EBattleType.EventBattle)
        //	{
        //		EventBattleFieldDataRow eventBattleFieldDataRow = regulation.eventBattleFieldDtbl[simulator.initState.stageID];
        //		this.Add(new ClearMissionItem(EBattleClearCondition.ClearStage, 1, "0"));
        //		this.Add(new ClearMissionItem(eventBattleFieldDataRow.clearCondition1, 2, eventBattleFieldDataRow.clearCondition1_Value));
        //		this.Add(new ClearMissionItem(eventBattleFieldDataRow.clearCondition2, 4, eventBattleFieldDataRow.clearCondition2_Value));
        //	}
        //	else if (this._simulator.initState.battleType == EBattleType.InfinityBattle)
        //	{
        //		InfinityFieldDataRow infinityFieldDataRow = regulation.infinityFieldDtbl[simulator.initState.stageID];
        //		this.Add(new ClearMissionItem(EBattleClearCondition.ClearStage, 1, "0"));
        //		this.Add(new ClearMissionItem(infinityFieldDataRow.clearMission01, 2, infinityFieldDataRow.clearMission01Count));
        //		this.Add(new ClearMissionItem(infinityFieldDataRow.clearMission02, 4, infinityFieldDataRow.clearMission02Count));
        //	}
        //	this.Update();
        //}

        //public void Add(ClearMissionItem item)
        //{
        //	this.Update(item);
        //	this._missions.Add(item);
        //}

        //public void Update(ClearMissionItem item)
        //{
        //	if (item.isFinish)
        //	{
        //		return;
        //	}
        //	if (this._updater[(int)item.condition] == null)
        //	{
        //		return;
        //	}
        //	this._updater[(int)item.condition](item);
        //}

        //public void MissionAllFail()
        //{
        //	for (int i = 0; i < this._missions.Count; i++)
        //	{
        //		this._missions[i].isSuccess = false;
        //		this._missions[i].isFinish = true;
        //	}
        //	this.clearCount = 0;
        //	this.clearValue = 0;
        //}

        //public void MissionAllSuccess()
        //{
        //	int num = 0;
        //	for (int i = 0; i < this._missions.Count; i++)
        //	{
        //		this._missions[i].isSuccess = true;
        //		this._missions[i].isFinish = true;
        //		num += this._missions[i].id;
        //	}
        //	this.clearCount = this._missions.Count;
        //	this.clearValue = num;
        //}

        //public void Update()
        //{
        //	int num = 0;
        //	int num2 = 0;
        //	for (int i = 0; i < this._missions.Count; i++)
        //	{
        //		if (!this._missions[i].isFinish)
        //		{
        //			this.Update(this._missions[i]);
        //		}
        //		if (this._missions[i].isSuccess)
        //		{
        //			num += this._missions[i].id;
        //			num2++;
        //		}
        //	}
        //	this.clearCount = num2;
        //	this.clearValue = num;
        //}

        //private void None(ClearMissionItem item)
        //{
        //	item.isSuccess = true;
        //	item.isFinish = true;
        //}

        //private void ClearStage(ClearMissionItem item)
        //{
        //	if (this._simulator.result == null)
        //	{
        //		return;
        //	}
        //	item.isSuccess = this._simulator.result.IsWin;
        //	item.isFinish = true;
        //}

        //private void Survival(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	int num2 = this._simulator.initState._lhsUnitCount - this._simulator.frame._lhsDeadUnitCount;
        //	item.isSuccess = num2 >= num;
        //	if (!item.isSuccess)
        //	{
        //		item.isFinish = true;
        //	}
        //}

        //private void LimitedTurn(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	if (this._simulator.initState.battleType == EBattleType.Plunder)
        //	{
        //		item.isSuccess = this._simulator.frame._waveTurn < num;
        //		if (!item.isSuccess)
        //		{
        //			item.isFinish = true;
        //			return;
        //		}
        //	}
        //	item.isSuccess = this._simulator.frame._waveTurn <= num;
        //	if (!item.isSuccess)
        //	{
        //		item.isFinish = true;
        //	}
        //}

        //private void Include_Attacker(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsAttackerCount >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Defender(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsDefenderCount >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Supporter(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsSupporterCount >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Commander(ClearMissionItem item)
        //{
        //	Regulation regulation = this._simulator.regulation;
        //	CommanderDataRow commanderDataRow = regulation.commanderDtbl[item.conditionValue];
        //	item.isSuccess = false;
        //	IList<Troop> lhsTroops = this._simulator.initState.lhsTroops;
        //	for (int i = 0; i < lhsTroops.Count; i++)
        //	{
        //		for (int j = 0; j < 9; j++)
        //		{
        //			int lhsUnitIndex = this._simulator.GetLhsUnitIndex(i, j);
        //			Unit unit = this._simulator.frame.units[lhsUnitIndex];
        //			if (unit != null && unit._cdri >= 0)
        //			{
        //				CommanderDataRow commanderDataRow2 = regulation.commanderDtbl[unit._cdri];
        //				if (commanderDataRow2.resourceId == commanderDataRow.resourceId)
        //				{
        //					item.isSuccess = true;
        //					break;
        //				}
        //			}
        //		}
        //	}
        //	item.isFinish = true;
        //}

        //private void Include_Minimum_Count(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsUnitCount <= num;
        //	item.isFinish = true;
        //}

        //private void All_Survival(ClearMissionItem item)
        //{
        //	item.isSuccess = this._simulator.frame._lhsDeadUnitCount <= 0;
        //	if (!item.isSuccess)
        //	{
        //		item.isFinish = true;
        //	}
        //}

        //private void Less_Attacker(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsAttackerCount <= num;
        //	item.isFinish = true;
        //}

        //private void Less_Defender(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsDefenderCount <= num;
        //	item.isFinish = true;
        //}

        //private void Less_Supporter(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsSupporterCount <= num;
        //	item.isFinish = true;
        //}

        //private void Less_UseActiveSkill(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.frame._lhsActiveSkillUseCount <= num;
        //	if (!item.isSuccess)
        //	{
        //		item.isFinish = true;
        //	}
        //}

        //private void Include_Grade_2(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade2Count >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Grade_3(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade3Count >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Grade_4(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade4Count >= num;
        //	item.isFinish = true;
        //}

        //private void Include_Grade_5(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade5Count >= num;
        //	item.isFinish = true;
        //}

        //private void Less_Grade_2(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade2Count > 0 && this._simulator.initState._lhsInitGrade2Count <= num;
        //	item.isFinish = true;
        //}

        //private void Less_Grade_3(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade3Count > 0 && this._simulator.initState._lhsInitGrade3Count <= num;
        //	item.isFinish = true;
        //}

        //private void Less_Grade_4(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade4Count > 0 && this._simulator.initState._lhsInitGrade4Count <= num;
        //	item.isFinish = true;
        //}

        //private void Less_Grade_5(ClearMissionItem item)
        //{
        //	int num = int.Parse(item.conditionValue);
        //	item.isSuccess = this._simulator.initState._lhsInitGrade5Count > 0 && this._simulator.initState._lhsInitGrade5Count <= num;
        //	item.isFinish = true;
        //}

        //private Simulator _simulator;

        private List<ClearMissionItem> _missions = new List<ClearMissionItem>();

        private Action<ClearMissionItem>[] _updater;

        private int _clearCount;

        public int clearValue;

        public Action OnChangeClearState;
    }
}
