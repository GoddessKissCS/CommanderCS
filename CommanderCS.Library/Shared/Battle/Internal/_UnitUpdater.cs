using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation.DataRows;

namespace CommanderCSLibrary.Shared.Battle.Internal
{
    public class _UnitUpdater : FrameAccessor
    {
        private Random _random;

        private bool _hasActivatedSkills;

        private int _selectedSkillIndex;

        private int _selectedTargetIndex;

        private List<Skill> _activatableSkills;

        private bool _hasEventInputs;

        private bool _hasInputs;

        private bool _isRhsUnit;

        private bool _isTurnUnit;

        private bool _isRaidUnit;

        internal _UnitUpdater()
        {
        }

        internal _UnitUpdater(Random random)
        {
            SetRandom(random);
        }

        public void SetRandom(Random random)
        {
            _random = random;
        }

        public override bool OnFrameAccessStart()
        {
            return true;
        }

        public void StautsLifeCheck()
        {
            try
            {
                List<Status> list = [];
                Status status = null;
                Dictionary<int, Status>.Enumerator enumerator = unit._status.GetEnumerator();
                bool flag = enumerator.MoveNext();
                while (flag)
                {
                    status = enumerator.Current.Value;
                    if (!status.IsAlive)
                    {
                        list.Add(status);
                    }
                    flag = enumerator.MoveNext();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (unit._status.Remove(list[i].Dri))
                    {
                        RemoveUnitStatus(list[i]);
                    }
                }
            }
            catch (Exception)
            {
                //Logger.Log("######## Error : Unit.cs UpdateStauts()");
            }
        }

        public void CleanStatus()
        {
            if (unit._status.Count > 0)
            {
                Status status = null;
                Dictionary<int, Status>.Enumerator enumerator = unit._status.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    status = enumerator.Current.Value;
                    RemoveUnitStatus(status);
                }
                unit._status.Clear();
            }
        }

        public void RemoveUnitStatus(Status status)
        {
            unit._maxHealthBonus -= status.MaxHealthBonus;
            unit._speedBonus -= status.SpeedBonus;
            unit._luckBonus -= status.LuckBonus;
            unit._attackDamageBonus -= status.AttackDamageBonus;
            unit._defenseBonus -= status.DefenseBonus;
            unit._criticalChanceBonus -= status.CriticalChanceBonus;
            unit._criticalDamageBonus -= status.CriticalDamageBonus;
            unit._recvHealBonus -= status.RecvHealBonus;
            unit._accuracyBonus -= status.AccuracyBonus;
            if (status.StunVal > 0 && unitDr.stateAllImmunity <= 0)
            {
                unit._stun--;
                if (unit._stun < 0)
                {
                    unit._stun = 0;
                }
            }
            if (status.AggroVal > 0 && unitDr.stateAllImmunity <= 0)
            {
                unit._aggro -= status.AggroVal;
                if (unit._aggro < 0)
                {
                    unit._aggro = 0;
                }
            }
            if (status.SilenceVal > 0 && unitDr.stateAllImmunity <= 0)
            {
                unit._silenceVal--;
                if (unit._silenceVal < 0)
                {
                    unit._silenceVal = 0;
                }
            }
            if (status.UnbeatableVal > 0)
            {
                unit._unbeatableVal--;
                if (unit._unbeatableVal < 0)
                {
                    unit._unbeatableVal = 0;
                }
            }
            if (status._dotDamage > 0)
            {
                unit._dotDamangeVal--;
                if (unit._dotDamangeVal < 0)
                {
                    unit._dotDamangeVal = 0;
                }
            }
            if (status.Shield > 0)
            {
                unit._statusShieldVal--;
                if (unit._statusShieldVal <= 0)
                {
                    unit._maxShiled = 0;
                    unit._shiled = 0;
                    unit._statusShieldVal = 0;
                }
            }
            if (status.ShieldCount > 0)
            {
                unit._shiledCount = 0;
            }
            if (status.AttackPoint)
            {
                unit._attackPoint = false;
            }
            if (status.FixedEvasionRate > 0)
            {
                unit._fixedEvasionRate = 0;
            }
            if (status.DamageCutRate > 0)
            {
                unit._damageCutRate = 0;
            }
            if (status.DamageRecoveryRate > 0)
            {
                unit._damageRecoveryRate = 0;
            }
        }

        public void RemoveUnitShield(Unit target)
        {
            target._shiled = 0;
            target._maxShiled = 0;
            Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
            while (statusItr.MoveNext())
            {
                if (statusItr.Current.Value.Shield > 0)
                {
                    statusItr.Current.Value._clingingTimeTick = 0;
                    statusItr.Current.Value._clingingTurn = 0;
                }
            }
        }

        public void RemoveUnitAggro(Unit target)
        {
            target._aggro = 0;
            Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
            while (statusItr.MoveNext())
            {
                if (statusItr.Current.Value.AggroVal > 0)
                {
                    statusItr.Current.Value._aggroVal = 0;
                    statusItr.Current.Value._clingingTimeTick = 0;
                    statusItr.Current.Value._clingingTurn = 0;
                }
            }
        }

        public void UpdateUnitStatus()
        {
            StautsLifeCheck();
            if (unit._charType != ECharacterType.RaidPart && unit._charType != ECharacterType.Raid)
            {
                unit._maxHealth = (int)((unitDr.maxHealth + unit._addHp) * (100L + (long)unit.maxHealthBonus) / 100);
            }
            long num = unit._takenDamage + unit._takenCriticalDamage;
            if (num > 0)
            {
                if (unit._shiled > 0)
                {
                    unit._shiled = (int)Math.Max(unit._shiled - num, -2147483648L);
                    if (unit._shiled <= 0)
                    {
                        num = -unit._shiled;
                        unit._shiled = 0;
                        unit._maxShiled = 0;
                        RemoveUnitShield(unit);
                    }
                    else
                    {
                        num = 0L;
                    }
                }
                if (_isRhsUnit)
                {
                    if (_isRaidUnit)
                    {
                        frame._totalAttackDamage += num;
                    }
                    else if (unit._health > 0)
                    {
                        if (num > unit._health)
                        {
                            frame._totalAttackDamage += unit._health;
                        }
                        else
                        {
                            frame._totalAttackDamage += num;
                        }
                    }
                }
                if (!_isRaidUnit)
                {
                    unit._health = (int)Math.Max(unit._health - num, -2147483648L);
                }
                if (!unit.isDead)
                {
                    if (unit._hasEventHpSkill)
                    {
                        int num2 = frame.FindActivatableEventSkill(simulator.regulation, EventSkillType.OnHealthRate, unitIndex);
                        if (num2 >= 0 && !unit.skills[num2].isIgnoreDeathType)
                        {
                            int remainedHealthRate = unit.skills[num2].SkillDataRow.remainedHealthRate;
                            int num3 = (int)((long)unit._health * 100L / unit._maxHealth);
                            if (remainedHealthRate >= num3)
                            {
                                unit._eventSkillType = EventSkillType.OnHealthRate;
                                unit._eventSkillIndex = num2;
                                frame._isWaitingNextTurn = false;
                            }
                        }
                    }
                    if (!unit.hasEventSkill && unit._hasEventCounterSkill)
                    {
                        int num4 = frame.FindActivatableEventSkill(simulator.regulation, EventSkillType.OnBeHit, unitIndex);
                        if (num4 >= 0)
                        {
                            int spCostOnBeHit = unit.skills[num4].SkillDataRow.spCostOnBeHit;
                            if (spCostOnBeHit > _random.Next(0, 100))
                            {
                                unit._eventSkillType = EventSkillType.OnBeHit;
                                unit._eventSkillIndex = num4;
                                unit._eventSkillTargetUnitIndex = unit._enemyAttackerUnitIdx;
                                frame._isWaitingNextTurn = false;
                            }
                        }
                    }
                }
            }
            if (!unit._isDead)
            {
                long num5 = unit._takenHealing + unit._takenCriticalHealing;
                if (num5 > 0)
                {
                    unit._health = (int)Math.Min(unit._health + num5, 2147483647L);
                    if (unit._health > unit.maxHealth && !_isRaidUnit)
                    {
                        unit._health = unit.maxHealth;
                    }
                }
            }
            if (unit._health <= 0)
            {
                if (unit._isDead)
                {
                    return;
                }
                if (!_isRaidUnit)
                {
                    unit._isDead = true;
                    unit._onDead = true;
                }
                if (!unit._isDead)
                {
                    return;
                }
                if (!_isRhsUnit)
                {
                    frame._lhsDeadUnitCount++;
                }
                if (unit.enemyAttackerUnitIdx >= 0)
                {
                    Unit unit = frame.units[base.unit.enemyAttackerUnitIdx];
                    if (unit is not null)
                    {
                        for (int i = 0; i < unit.skills.Count; i++)
                        {
                            if (unit.skills[i] is null)
                            {
                                continue;
                            }
                            if (unit.skills[i].sp < unit.skills[i].SkillDataRow.maxSp)
                            {
                                unit.skills[i]._sp += unit.skills[i].SkillDataRow.spOnDestroy;
                                if (unit.skills[i]._sp > unit.skills[i].SkillDataRow.maxSp)
                                {
                                    unit.skills[i]._sp = unit.skills[i].SkillDataRow.maxSp;
                                }
                            }
                            else
                            {
                                unit.skills[i]._sp = unit.skills[i].SkillDataRow.maxSp;
                            }
                            if (i > 1)
                            {
                                unit.skills[i]._curSp = unit.skills[i]._sp;
                            }
                        }
                    }
                }
                if (_isRhsUnit)
                {
                    frame._gold += unit._dropGold;
                    switch (unitDr.branch)
                    {
                        case EBranch.Army:
                            frame._armyDestoryCnt++;
                            break;

                        case EBranch.Navy:
                            frame._navyDestoryCnt++;
                            break;
                    }
                }
                for (int j = 0; j < unit.skills.Count; j++)
                {
                    if (unit.skills[j] is not null)
                    {
                        unit.skills[j]._remainedMotionTime = 0;
                    }
                }
                int num6 = frame.FindActivatableEventSkill(simulator.regulation, EventSkillType.OnHealthRate, unitIndex);
                if (num6 >= 0 && unit.skills[num6].isIgnoreDeathType)
                {
                    int remainedHealthRate2 = unit.skills[num6].SkillDataRow.remainedHealthRate;
                    int num7 = (int)((long)unit._health * 100L / unit._maxHealth);
                    if (remainedHealthRate2 >= num7)
                    {
                        unit._eventSkillType = EventSkillType.OnHealthRate;
                        unit._eventSkillIndex = num6;
                        frame._isWaitingNextTurn = false;
                    }
                }
            }
            else if (unit._takenDamageRecovery > 0)
            {
                unit._health = (int)Math.Min(unit._health + unit._takenDamageRecovery, 2147483647L);
                if (unit._health > unit.maxHealth && !_isRaidUnit)
                {
                    unit._health = unit.maxHealth;
                }
                unit._statsHealing += unit._takenDamageRecovery;
                unit._uiTakenHealing += unit._takenDamageRecovery;
            }
        }

        public override bool OnUnitAccessStart()
        {
            _hasActivatedSkills = false;
            _selectedSkillIndex = -1;
            _selectedTargetIndex = -1;
            _activatableSkills = null;
            _hasInputs = false;
            _hasEventInputs = false;
            _isRhsUnit = false;
            _isTurnUnit = false;
            _isRaidUnit = false;
            unit._enableEventSkill = false;
            unit._isTurn = false;
            unit._onDead = false;
            unit._uiTakenDamage = 0L;
            unit._uiTakenHealing = 0L;
            if (!frame.IsUnitInBattle(unitIndex))
            {
                return false;
            }
            if (unit._takenRevival)
            {
                unit._isDead = false;
            }
            if (frame.turnUnitIndex == unitIndex)
            {
                _isTurnUnit = true;
                unit._isTurn = true;
            }
            _isRhsUnit = frame.IsRhsUnitInBattle(unitIndex);
            if (_isRhsUnit)
            {
                if (simulator.initState.battleType == EBattleType.Raid)
                {
                    _isRaidUnit = unit._charType == ECharacterType.Raid;
                }
                else if (simulator.initState.battleType == EBattleType.CooperateBattle)
                {
                    _isRaidUnit = unit._charType == ECharacterType.Raid || unit._charType == ECharacterType.RaidPart;
                }
            }
            if (unit.isEnteredNow && unit._hasEventEnterSkill)
            {
                int num = frame.FindActivatableEventSkill(simulator.regulation, EventSkillType.OnBattleEnter, unitIndex);
                if (num >= 0)
                {
                    unit._eventSkillType = EventSkillType.OnBattleEnter;
                    unit._eventSkillIndex = num;
                    frame._isWaitingNextTurn = false;
                }
                unit._isEnteredNow = false;
            }
            UpdateUnitStatus();
            UpdateInputData();
            if (unit._delayActiveTime > 0)
            {
                unit._delayActiveTime -= 66;
                return false;
            }
            if (CanUpdateUnit())
            {
                return true;
            }
            return false;
        }

        protected bool CanUpdateUnit()
        {
            if (simulator.option.immediatelyUseActiveSkill && !_isTurnUnit && _isRhsUnit)
            {
                if (!unit.isPlayingAction)
                {
                    return true;
                }
                if (_hasEventInputs && unit.skills[_selectedSkillIndex].isIgnoreDeathType)
                {
                    return true;
                }
            }
            if (simulator.option.playMode == Option.PlayMode.RealTime)
            {
                return true;
            }
            if (!frame.isWaitingInput || !_isTurnUnit)
            {
                if (simulator.option.playMode == Option.PlayMode.PureTurn)
                {
                    return false;
                }
                if (!_hasInputs && !_hasEventInputs)
                {
                    return false;
                }
            }
            return true;
        }

        protected bool UpdateInputData()
        {
            if (unit.hasEventSkill && unit.eventSkillType == EventSkillType.OnBattleEnter)
            {
                _hasEventInputs = true;
                _selectedSkillIndex = unit._eventSkillIndex;
            }
            else
            {
                Input lhsInput = frame.lhsInput;
                Input rhsInput = frame.rhsInput;
                if (lhsInput is not null && lhsInput.unitIndex == unitIndex)
                {
                    if ((lhsInput.targetIndex == -1 || frame.IsRhsUnitInBattle(lhsInput.targetIndex)) && unit.hasActiveSkill && unit._activeSkillIdx == lhsInput.skillIndex && frame.CanUseSkill(simulator.option) && simulator.CanSkillAction(unit, lhsInput.skillIndex))
                    {
                        _hasInputs = true;
                        _selectedSkillIndex = lhsInput.skillIndex;
                        _selectedTargetIndex = lhsInput.targetIndex;
                        if (!simulator.option.canSelectTarget)
                        {
                            _selectedTargetIndex = -1;
                        }
                    }
                }
                else if (rhsInput is not null && rhsInput.unitIndex == unitIndex && simulator.CanUnitControl(unit) && (rhsInput.targetIndex == -1 || frame.IsRhsUnitInBattle(rhsInput.targetIndex)) && unit.hasActiveSkill && unit._activeSkillIdx == lhsInput.skillIndex && simulator.CanSkillAction(unit, rhsInput.skillIndex))
                {
                    _hasInputs = true;
                    _selectedSkillIndex = rhsInput.skillIndex;
                    _selectedTargetIndex = rhsInput.targetIndex;
                    if (!simulator.option.canSelectTarget)
                    {
                        _selectedTargetIndex = -1;
                    }
                }
                if (!_hasInputs && unit.hasEventSkill)
                {
                    _hasEventInputs = true;
                    _selectedSkillIndex = unit._eventSkillIndex;
                }
            }
            if (unit.aggro > 0)
            {
                Unit unit = frame.units[base.unit.aggroUnitIdx];
                if (unit.isDead)
                {
                    RemoveUnitAggro(unit);
                }
                else
                {
                    _selectedTargetIndex = unit.aggroUnitIdx;
                }
            }
            return false;
        }

        public bool CanSkillAction(Skill skill)
        {
            if (skill is null)
            {
                return false;
            }
            if (unit.stun > 0)
            {
                return false;
            }
            if (unit.silenceVal > 0)
            {
                return false;
            }
            if (unit.aggro > 0 && (skill.SkillDataRow.targetType == ESkillTargetType.Own || skill.SkillDataRow.targetType == ESkillTargetType.Friend))
            {
                return false;
            }
            return true;
        }

        public override void OnUnitAccessEnd()
        {
            if (_activatableSkills is null || _activatableSkills.Count <= 0)
            {
                unit._eventSkillIndex = -1;
                return;
            }
            if (_hasActivatedSkills || (_selectedSkillIndex >= 0 && _activatableSkills[_selectedSkillIndex] is null))
            {
                foreach (Skill activatableSkill in _activatableSkills)
                {
                    if (activatableSkill is not null)
                    {
                        activatableSkill._remainedMotionTime = 0;
                    }
                }
                unit._eventSkillIndex = -1;
                return;
            }
            if (_selectedSkillIndex < 0)
            {
                if (unit.isEnemyType)
                {
                    for (int i = 1; i < _activatableSkills.Count; i++)
                    {
                        if (_activatableSkills[i] is null || !_activatableSkills[i].isActiveSkill)
                        {
                            continue;
                        }
                        int num = frame.FindSkillTarget(simulator.regulation, unitIndex, i);
                        if (num >= 0)
                        {
                            _selectedSkillIndex = i;
                            if (unit.aggro <= 0)
                            {
                                _selectedTargetIndex = num;
                            }
                            break;
                        }
                    }
                }
                if (_selectedSkillIndex < 0 && _isTurnUnit)
                {
                    if (_activatableSkills[0] is not null)
                    {
                        int num2 = frame.FindSkillTarget(simulator.regulation, unitIndex, 0);
                        if (num2 >= 0)
                        {
                            _selectedSkillIndex = 0;
                            if (unit.aggro <= 0)
                            {
                                _selectedTargetIndex = num2;
                            }
                        }
                    }
                    for (int j = 1; j < _activatableSkills.Count; j++)
                    {
                        if (_activatableSkills[j] is null || !_activatableSkills[j].HasEventOccurrenceProbability)
                        {
                            continue;
                        }
                        int occurrenceProbability = _activatableSkills[j].SkillDataRow.occurrenceProbability;
                        if (occurrenceProbability <= _random.Next(0, 100))
                        {
                            continue;
                        }
                        int num3 = frame.FindSkillTarget(simulator.regulation, unitIndex, j);
                        if (num3 >= 0)
                        {
                            _selectedSkillIndex = j;
                            if (unit.aggro <= 0)
                            {
                                _selectedTargetIndex = num3;
                            }
                        }
                        break;
                    }
                }
                if (_selectedSkillIndex < 0)
                {
                    foreach (Skill activatableSkill2 in _activatableSkills)
                    {
                        if (activatableSkill2 is not null)
                        {
                            activatableSkill2._remainedMotionTime = 0;
                        }
                    }
                    unit._eventSkillIndex = -1;
                    return;
                }
            }
            for (int k = 0; k < _activatableSkills.Count; k++)
            {
                Skill skill = _activatableSkills[k];
                if (skill is null)
                {
                    continue;
                }
                SkillDataRow skillDataRow = simulator.regulation.skillDtbl[skill.dri];
                if (skillDataRow is null)
                {
                    continue;
                }
                if (k != _selectedSkillIndex)
                {
                    skill._remainedMotionTime = 0;
                    continue;
                }
                if (_selectedTargetIndex < 0)
                {
                    int num4 = frame.FindSkillTarget(simulator.regulation, unitIndex, _selectedSkillIndex);
                    if (num4 >= 0)
                    {
                        _selectedTargetIndex = num4;
                    }
                }
                if (_selectedTargetIndex < 0)
                {
                    unit._eventSkillIndex = -1;
                    skill._remainedMotionTime = 0;
                    if (unit.skills[_selectedSkillIndex].isIgnoreDeathType)
                    {
                        unit._hasEventDeathSkill = false;
                        break;
                    }
                    continue;
                }
                if (_hasInputs)
                {
                    if (frame.lhsInput is not null && frame.lhsInput.unitIndex == unitIndex && _selectedSkillIndex == frame.lhsInput.skillIndex)
                    {
                        frame.lhsInput._result = true;
                    }
                    if (frame.rhsInput is not null && frame.rhsInput.unitIndex == unitIndex && _selectedSkillIndex == frame.rhsInput.skillIndex)
                    {
                        frame.rhsInput._result = true;
                    }
                }
                if (_isTurnUnit)
                {
                    frame._isWaitingInput = false;
                }
                if (skill.isActiveSkill)
                {
                    frame._hasSkillActionUnit = true;
                }
                unit._playingActionIndex = _selectedSkillIndex;
                skill._activeState = false;
                skill._targetIndex = _selectedTargetIndex;
                if (unit.eventSkillType == EventSkillType.OnCombo)
                {
                    skill._remainedMotionTime += 660;
                }
                if (skill._bCutInSkill)
                {
                    FireEvent fireEvent = simulator.regulation.unitMotionDtbl[skill.unitMotionDri].fireEvents[0];
                    if (simulator.option.canInterfereSkill)
                    {
                        if (skill.FireActionDr is null)
                        {
                        }
                    }
                    else if (skill.FireActionDr is not null)
                    {
                        FireActionDataRow.TimeSet timeSet = skill.FireActionDr.GetTimeSet(simulator.CanEnableFireAction(unit));
                        if (timeSet.timeSleepDuringFire)
                        {
                            skill._remainedMotionTime -= fireEvent.time;
                        }
                        else
                        {
                            skill._remainedMotionTime += timeSet.fireDelayTime;
                        }
                    }
                    else
                    {
                        skill._remainedMotionTime -= fireEvent.time;
                    }
                    skill._remainedMotionTime += 66;
                }
                skill._initMotionTime = skill._remainedMotionTime;
                if (!_isRhsUnit && skill.isActiveSkill)
                {
                    frame._lhsActiveSkillUseCount++;
                }
                int num5 = unitDr.attackDamage + unit._addAtk;
                int num6 = (int)((long)skillDataRow.attackDamage * (long)skill.SkillLevelFormal.AttackDamage / 1000);
                int num7 = skillDataRow.attackDamage + num6;
                int attackDamageBonus = unit.attackDamageBonus;
                int num8 = unitDr.accuracy + unit._addAim;
                int accuracy = skillDataRow.accuracy;
                int accuracyBonus = unit.accuracyBonus;
                int num9 = unitDr.criticalChance + unit._addCitr;
                int criticalChance = skillDataRow.criticalChance;
                int criticalChanceBonus = unit.criticalChanceBonus;
                int num10 = unitDr.criticalDamageBonus + unit._addCitDmg;
                int criticalDamageBonus = skillDataRow.criticalDamageBonus;
                int criticalDamageBonus2 = unit.criticalDamageBonus;
                skill._attackDamage = (num5 + num7) * (100 + attackDamageBonus) / 100;
                if (skill._attackDamage < 0)
                {
                    skill._attackDamage = 0;
                }
                skill._accuracy = (num8 + accuracy) * (100 + accuracyBonus) / 100;
                if (skill._accuracy < 0)
                {
                    skill._accuracy = 0;
                }
                skill._criticalChance = (num9 + criticalChance) * (100 + criticalChanceBonus) / 100;
                if (skill._criticalChance < 0)
                {
                    skill._criticalChance = 0;
                }
                skill._criticalDamage = (int)((long)skill.attackDamage * (long)(100 + num10 + criticalDamageBonus + criticalDamageBonus2) / 100);
                if (skill._criticalDamage < skill.attackDamage)
                {
                    skill._criticalDamage = skill.attackDamage;
                }
                if (_hasEventInputs)
                {
                    if (unit.eventSkillIndex != _selectedSkillIndex)
                    {
                        if (unit.eventSkillType != EventSkillType.OnHealthRate)
                        {
                            unit._eventSkillIndex = -1;
                        }
                    }
                    else
                    {
                        unit._eventSkillIndex = -1;
                        unit._enableEventSkill = true;
                    }
                }
                if (unit.isEnableEventSkill)
                {
                    if (unit.eventSkillType == EventSkillType.OnBeHit)
                    {
                        skill._attackDamage = (int)((long)skill._attackDamage * 110L / 100);
                        skill._criticalDamage = (int)((long)skill._criticalDamage * 110L / 100);
                    }
                    if (unit.eventSkillType != EventSkillType.OnCombo)
                    {
                        skill._sp -= skillDataRow.maxSp;
                    }
                }
                else
                {
                    skill._sp -= skillDataRow.maxSp;
                }
                if (skill.SkillDataRow.consumeHpRate > 0 && unit._health > 0)
                {
                    int num11 = (int)((long)unit._maxHealth * (long)skill.SkillDataRow.consumeHpRate / 100);
                    if (num11 >= unit._health)
                    {
                        num11 = unit._health - 1;
                    }
                    unit._health -= num11;
                    unit._uiTakenDamage += num11;
                }
                skill._curSp = skill._sp;
            }
        }

        public override bool OnSkillAccessStart()
        {
            if (simulator.option.playMode == Option.PlayMode.RealTime)
            {
                skill._sp++;
            }
            if (skill._remainedMotionTime > 0 && !_hasInputs)
            {
                _hasActivatedSkills = true;
                return false;
            }
            if (unit._cls < skill.SkillDataRow.openGrade)
            {
                return false;
            }
            if (!skill.CanUse)
            {
                return false;
            }
            if (unit.isDead)
            {
                if (!skill.isIgnoreDeathType)
                {
                    return false;
                }
            }
            else
            {
                if (unit.isStatusStun)
                {
                    return false;
                }
                if (unit.isStatusSilence)
                {
                    if (skillIndex != 0)
                    {
                        return false;
                    }
                    if (_hasInputs)
                    {
                        return false;
                    }
                    if (_hasEventInputs && unit.eventSkillType != EventSkillType.OnBeHit && unit.eventSkillType != EventSkillType.OnCombo)
                    {
                        return false;
                    }
                }
                if (unit.isStatusAggro && (skill.SkillDataRow.targetType == ESkillTargetType.Own || skill.SkillDataRow.targetType == ESkillTargetType.Friend))
                {
                    return false;
                }
            }
            if (skill.isActiveSkill && !frame.CanUseSkill(simulator.option))
            {
                return false;
            }
            if (unitMotionDr.fireEvents[0] is null)
            {
                return false;
            }
            if (_activatableSkills is null)
            {
                Shared.Regulation.Regulation.ExtendList(ref _activatableSkills, 5);
            }
            skill._remainedMotionTime = unitMotionDr.playTime + 66;
            _activatableSkills[skillIndex] = skill;
            return false;
        }
    }
}