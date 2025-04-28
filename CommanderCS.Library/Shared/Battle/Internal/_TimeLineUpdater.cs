using CommanderCS.Library.Shared.Enum;
using CommanderCS.Library.Shared.Regulation.DataRows;

namespace CommanderCS.Library.Shared.Battle.Internal
{
    public class _TimeLineUpdater : FrameAccessor
    {
        private Random _random;

        internal _TimeLineUpdater()
        {
        }

        internal _TimeLineUpdater(Random random)
        {
            SetRandom(random);
        }

        public void SetRandom(Random random)
        {
            _random = random;
        }

        public override bool OnFrameAccessStart()
        {
            frame._onTurn = false;
            frame._onWaveTurn = false;
            if (frame._isWaitingNextTurn)
            {
                if (frame._isWaitingInput)
                {
                    Unit unit = frame.units[frame.turnUnitIndex];
                    if (!unit.isDead && !unit.isStatusStun)
                    {
                        return false;
                    }
                }
                if (!simulator.isEnded && (frame._lhsTimeLine is null || frame._lhsTimeLine.Count == 0) && (frame._rhsTimeLine is null || frame._rhsTimeLine.Count == 0))
                {
                    if (frame._lhsTimeLine.Count == 0 && frame._rhsTimeLine.Count == 0)
                    {
                        int waveTurn = frame._waveTurn;
                        frame._waveTurn++;
                        frame._onWaveTurn = true;
                    }
                    frame._lhsTimeLine = [];
                    frame._rhsTimeLine = [];
                    int lhsTroopIndex = simulator.GetLhsTroopIndex(frame.lhsTroopStartIndex);
                    int rhsTroopIndex = simulator.GetRhsTroopIndex(frame.rhsTroopStartIndex);
                    if (lhsTroopIndex < 0 || rhsTroopIndex < 0)
                    {
                        frame._isLhsTimeLineTurn = false;
                    }
                    else if (simulator.lhsTroops[lhsTroopIndex]._speed >= simulator.rhsTroops[rhsTroopIndex]._speed)
                    {
                        frame._isLhsTimeLineTurn = true;
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        if (frame.lhsTroopStartIndex >= 0)
                        {
                            int num = frame.lhsTroopStartIndex + i;
                            Unit unit2 = frame.units[num];
                            if (unit2 is not null && !unit2.isDead)
                            {
                                frame._lhsTimeLine.Add(num);
                            }
                        }
                        int num2 = frame.rhsTroopStartIndex + i;
                        if (num2 >= frame.units.Count || !frame.IsUnitInBattle(num2))
                        {
                            continue;
                        }
                        Unit unit3 = frame.units[num2];
                        if (unit3 is null)
                        {
                            continue;
                        }
                        if (simulator.initState.battleType == EBattleType.Raid && unit3._charType == ECharacterType.RaidPart)
                        {
                            string key = $"{simulator.initState.raidData.raidId}_{frame._waveTurn}_{unit3._unitIdx % 9}";
                            int num3 = simulator.regulation.raidDtbl.FindIndex(key);
                            if (num3 >= 0)
                            {
                                RaidDataRow raidDataRow = simulator.regulation.raidDtbl[num3];
                                if (raidDataRow.health != 0)
                                {
                                    if (raidDataRow.health < 0)
                                    {
                                        unit3._health = 0;
                                    }
                                    else if (raidDataRow.health > 0)
                                    {
                                        unit3._maxHealth = raidDataRow.health;
                                        unit3._health = raidDataRow.health;
                                    }
                                    if (unit3._health > 0)
                                    {
                                        unit3._takenHealing = raidDataRow.health;
                                        if (unit3.isDead)
                                        {
                                            unit3._takenRevival = true;
                                            unit3._delayActiveTime = RaidData.delayActiveTime;
                                        }
                                    }
                                }
                            }
                            if (unit3.isDead)
                            {
                                if (unit3.takenRevival)
                                {
                                    frame._rhsTimeLine.Add(num2);
                                }
                            }
                            else
                            {
                                frame._rhsTimeLine.Add(num2);
                            }
                        }
                        else if (!unit3.isDead)
                        {
                            frame._rhsTimeLine.Add(num2);
                        }
                    }
                }
                Unit unit4 = null;
                List<int> list = [];
                foreach (int item in frame._lhsTimeLine)
                {
                    if (frame.IsUnitInBattle(item))
                    {
                        unit4 = frame._units[item];
                        if (unit4 is not null && unit4.health > 0)
                        {
                            list.Add(item);
                        }
                    }
                }
                frame._lhsTimeLine = list;
                list = new List<int>();
                foreach (int item2 in frame._rhsTimeLine)
                {
                    if (frame.IsUnitInBattle(item2))
                    {
                        unit4 = frame._units[item2];
                        if (unit4 is not null && unit4.health > 0)
                        {
                            list.Add(item2);
                        }
                    }
                }
                frame._rhsTimeLine = list;
                if (frame._isLhsTimeLineTurn)
                {
                    if (frame._lhsTimeLine.Count == 0 && frame._rhsTimeLine.Count > 0)
                    {
                        frame._isLhsTimeLineTurn = false;
                    }
                }
                else if (frame._rhsTimeLine.Count == 0 && frame._lhsTimeLine.Count > 0)
                {
                    frame._isLhsTimeLineTurn = true;
                }
                if (frame._isLhsTimeLineTurn)
                {
                    int num4;
                    Unit unit5;
                    do
                    {
                        if (frame._lhsTimeLine.Count == 0)
                        {
                            return false;
                        }
                        num4 = frame._lhsTimeLine[0];
                        frame._lhsTimeLine.RemoveAt(0);
                        unit5 = frame._units[num4];
                    }
                    while (unit5 is null || unit5.health <= 0);
                    frame._turnUnitIndex = num4;
                }
                else
                {
                    int num5;
                    Unit unit6;
                    do
                    {
                        if (frame._rhsTimeLine.Count == 0)
                        {
                            return false;
                        }
                        num5 = frame._rhsTimeLine[0];
                        frame._rhsTimeLine.RemoveAt(0);
                        unit6 = frame._units[num5];
                    }
                    while (unit6 is null || unit6.health <= 0);
                    frame._turnUnitIndex = num5;
                }
                frame._isLhsTimeLineTurn = !frame._isLhsTimeLineTurn;
                frame._isWaitingInput = true;
                frame._turn++;
                frame._onTurn = true;
                unit4 = frame._units[frame._turnUnitIndex];
                unit4._isTurn = true;
                unit4._turn++;
                Skill skill = unit4._skills[0];
                if (skill is not null)
                {
                    SkillDataRow skillDataRow = simulator.regulation.skillDtbl[skill.dri];
                    skill._sp = skillDataRow.maxSp;
                    skill._curSp = skill._sp;
                    skill._activeState = true;
                }
            }
            return true;
        }

        public override bool OnUnitAccessStart()
        {
            if (!frame.IsUnitInBattle(unitIndex))
            {
                return false;
            }
            if (frame.onTurn)
            {
                if (simulator.initState.battleType == EBattleType.Raid)
                {
                    string text = string.Empty;
                    if (unit._charType == ECharacterType.Raid || unit._charType == ECharacterType.RaidPart)
                    {
                        if (!unit.isDead)
                        {
                            if (frame.turnUnitIndex == unitIndex)
                            {
                                text = $"{simulator.initState.raidData.raidId}_{frame._waveTurn}_{unit._unitIdx % 9}";
                            }
                        }
                        else if (frame.onWaveTurn)
                        {
                            text = $"{simulator.initState.raidData.raidId}_{frame._waveTurn}_{unit._unitIdx % 9}";
                        }
                    }
                    if (!string.IsNullOrEmpty(text) && simulator.regulation.raidDtbl.ContainsKey(text))
                    {
                        RaidDataRow raidDataRow = simulator.regulation.raidDtbl[text];
                        unit._attackDamageBonus += raidDataRow.attackIncrease;
                        unit._defenseBonus += raidDataRow.defenseIncrease;
                        unit._accuracyBonus += raidDataRow.accuracyIncrease;
                        unit._luckBonus += raidDataRow.luckIncrease;
                        unit._criticalChanceBonus += raidDataRow.criticalIncrease;
                        unit._criticalDamageBonus += raidDataRow.criticalDmgIncrease;
                        unit._speedBonus += raidDataRow.speedIncrease;
                    }
                }
                if (unit.criticalHitCount > 0)
                {
                    for (int i = 1; i < unit.skills.Count; i++)
                    {
                        Skill skill = unit.skills[i];
                        if (skill is not null)
                        {
                            skill._sp += skill.SkillDataRow.spOnCriticalHit;
                            if (skill._sp >= skill.SkillDataRow.maxSp)
                            {
                                skill._sp = skill.SkillDataRow.maxSp;
                            }
                            if (i > 1)
                            {
                                skill._curSp = skill._sp;
                            }
                        }
                    }
                    unit._hitCount = 0;
                    unit._criticalHitCount = 0;
                }
                else if (unit.hitCount > 0)
                {
                    for (int j = 1; j < unit.skills.Count; j++)
                    {
                        Skill skill2 = unit.skills[j];
                        if (skill2 is not null)
                        {
                            skill2._sp += skill2.SkillDataRow.spOnHit;
                            if (skill2._sp >= skill2.SkillDataRow.maxSp)
                            {
                                skill2._sp = skill2.SkillDataRow.maxSp;
                            }
                            if (j > 1)
                            {
                                skill2._curSp = skill2._sp;
                            }
                        }
                    }
                    unit._hitCount = 0;
                    unit._criticalHitCount = 0;
                }
                if (unit.beHitCount > 0)
                {
                    for (int k = 1; k < unit.skills.Count; k++)
                    {
                        Skill skill3 = unit.skills[k];
                        if (skill3 is not null)
                        {
                            skill3._sp += skill3.SkillDataRow.spOnBeHit;
                            if (skill3._sp >= skill3.SkillDataRow.maxSp)
                            {
                                skill3._sp = skill3.SkillDataRow.maxSp;
                            }
                            if (k > 1)
                            {
                                skill3._curSp = skill3._sp;
                            }
                        }
                    }
                    unit._beHitCount = 0;
                }
                unit._takenProjectilesOnTurn.Clear();
            }
            UpdateUnitStatus();
            return false;
        }

        protected void UpdateUnitStatus()
        {
            if (!unit.isDead)
            {
                Dictionary<int, Status>.Enumerator statusItr = unit.StatusItr;
                while (statusItr.MoveNext())
                {
                    Status value = statusItr.Current.Value;
                    UpdateUnitStatus(value);
                }
            }
        }

        protected void UpdateUnitStatus(Status status)
        {
            int elapsedTurn = status._elapsedTurn;
            status._isAlive = true;
            status._elapsedTimeTick += 66;
            status._elapsedTurn = unit._turn - status._createdTurn;
            if (status._clingingTurn == 0 && status._clingingTimeTick == 0)
            {
                status._isAlive = false;
            }
            else if (status._elapsedTimeTick >= status._clingingTimeTick && status._elapsedTurn > status._clingingTurn)
            {
                status._isAlive = false;
            }
            else
            {
                if (elapsedTurn == status._elapsedTurn)
                {
                    return;
                }
                if (status._dotDamage > 0)
                {
                    int num = status._dotDamage;
                    Unit unit = frame.units[status._ownerUnitIdx];
                    UnitDataRow unitDataRow = simulator.regulation.unitDtbl[status._ownerUnitIdx];
                    if (unitDataRow.typeDown == unitDr.type)
                    {
                        num = num * unitDataRow.typeHandicap / 100;
                    }
                    if (unitDataRow.typeUpper == unitDr.type)
                    {
                        num = num * unitDataRow.typeBonus / 100;
                    }
                    int num2 = (unit.defense + unit._addDef) * (100 + unit.defenseBonus) / 100;
                    if (num2 < 0)
                    {
                        num2 = 0;
                    }
                    int num3 = num;
                    num = num * 100 / (100 + num2);
                    if (num3 > 0)
                    {
                        unit._statsDefense += num3 - num;
                    }
                    unit._dealtDamage += num;
                    unit._takenDamage += num;
                    unit._statsAttack += num;
                }
                if (status._dotHealing > 0)
                {
                    Unit unit2 = frame.units[status._ownerUnitIdx];
                    int dotHealing = status._dotHealing;
                    unit._takenHealing += dotHealing;
                    unit2._statsHealing += dotHealing;
                }
            }
        }

        private void _SortTimeLine(List<int> timeLine)
        {
            for (int i = 1; i < timeLine.Count; i++)
            {
                int value = timeLine[i];
                int num = i - 1;
                int num2 = frame._units[timeLine[i]].speed * (100 + frame._units[timeLine[i]].speedBonus) / 100;
                while (num >= 0)
                {
                    int num3 = frame._units[timeLine[num]].speed * (100 + frame._units[timeLine[num]].speedBonus) / 100;
                    if (num3 < num2)
                    {
                        timeLine[num + 1] = timeLine[num];
                        num--;
                        continue;
                    }
                    break;
                }
                timeLine[num + 1] = value;
            }
        }
    }
}