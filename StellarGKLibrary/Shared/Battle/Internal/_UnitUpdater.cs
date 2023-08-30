namespace StellarGKLibrary.Shared.Battle.Internal
{
    public class _UnitUpdater : FrameAccessor
    {
        internal _UnitUpdater()
        {
        }

        //internal _UnitUpdater(Random random)
        //{
        //	SetRandom(random);
        //}

        //public void SetRandom(Random random)
        //{
        //	_random = random;
        //}

        //public override bool OnFrameAccessStart()
        //{
        //	return true;
        //}

        //public void StautsLifeCheck()
        //{
        //	try
        //	{
        //		List<Status> list = new List<Status>();
        //		Dictionary<int, Status>.Enumerator enumerator = base.unit._status.GetEnumerator();
        //		bool flag = enumerator.MoveNext();
        //		while (flag)
        //		{
        //			KeyValuePair<int, Status> keyValuePair = enumerator.Current;
        //			Status value = keyValuePair.Value;
        //			if (!value.IsAlive)
        //			{
        //				list.Add(value);
        //			}
        //			flag = enumerator.MoveNext();
        //		}
        //		for (int i = 0; i < list.Count; i++)
        //		{
        //			if (base.unit._status.Remove(list[i].Dri))
        //			{
        //				RemoveUnitStatus(list[i]);
        //			}
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		Logger.Log("######## Error : Unit.cs UpdateStauts()");
        //	}
        //}

        //public void CleanStatus()
        //{
        //	if (base.unit._status.Count <= 0)
        //	{
        //		return;
        //	}
        //	foreach (KeyValuePair<int, Status> keyValuePair in base.unit._status)
        //	{
        //		Status value = keyValuePair.Value;
        //		RemoveUnitStatus(value);
        //	}
        //	base.unit._status.Clear();
        //}

        //public void RemoveUnitStatus(Status status)
        //{
        //	base.unit._maxHealthBonus -= status.MaxHealthBonus;
        //	base.unit._speedBonus -= status.SpeedBonus;
        //	base.unit._luckBonus -= status.LuckBonus;
        //	base.unit._attackDamageBonus -= status.AttackDamageBonus;
        //	base.unit._defenseBonus -= status.DefenseBonus;
        //	base.unit._criticalChanceBonus -= status.CriticalChanceBonus;
        //	base.unit._criticalDamageBonus -= status.CriticalDamageBonus;
        //	base.unit._recvHealBonus -= status.RecvHealBonus;
        //	base.unit._accuracyBonus -= status.AccuracyBonus;
        //	if (status.StunVal > 0 && base.unitDr.stateAllImmunity <= 0)
        //	{
        //		base.unit._stun--;
        //		if (base.unit._stun < 0)
        //		{
        //			base.unit._stun = 0;
        //		}
        //	}
        //	if (status.AggroVal > 0 && base.unitDr.stateAllImmunity <= 0)
        //	{
        //		base.unit._aggro -= status.AggroVal;
        //		if (base.unit._aggro < 0)
        //		{
        //			base.unit._aggro = 0;
        //		}
        //	}
        //	if (status.SilenceVal > 0 && base.unitDr.stateAllImmunity <= 0)
        //	{
        //		base.unit._silenceVal--;
        //		if (base.unit._silenceVal < 0)
        //		{
        //			base.unit._silenceVal = 0;
        //		}
        //	}
        //	if (status.UnbeatableVal > 0)
        //	{
        //		base.unit._unbeatableVal--;
        //		if (base.unit._unbeatableVal < 0)
        //		{
        //			base.unit._unbeatableVal = 0;
        //		}
        //	}
        //	if (status._dotDamage > 0)
        //	{
        //		base.unit._dotDamangeVal--;
        //		if (base.unit._dotDamangeVal < 0)
        //		{
        //			base.unit._dotDamangeVal = 0;
        //		}
        //	}
        //	if (status.Shield > 0)
        //	{
        //		base.unit._statusShieldVal--;
        //		if (base.unit._statusShieldVal <= 0)
        //		{
        //			base.unit._maxShiled = 0;
        //			base.unit._shiled = 0;
        //			base.unit._statusShieldVal = 0;
        //		}
        //	}
        //	if (status.ShieldCount > 0)
        //	{
        //		base.unit._shiledCount = 0;
        //	}
        //	if (status.AttackPoint)
        //	{
        //		base.unit._attackPoint = false;
        //	}
        //	if (status.FixedEvasionRate > 0)
        //	{
        //		base.unit._fixedEvasionRate = 0;
        //	}
        //	if (status.DamageCutRate > 0)
        //	{
        //		base.unit._damageCutRate = 0;
        //	}
        //	if (status.DamageRecoveryRate > 0)
        //	{
        //		base.unit._damageRecoveryRate = 0;
        //	}
        //}

        //public void RemoveUnitShield(Unit target)
        //{
        //	target._shiled = 0;
        //	target._maxShiled = 0;
        //	Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
        //	while (statusItr.MoveNext())
        //	{
        //		KeyValuePair<int, Status> keyValuePair = statusItr.Current;
        //		if (keyValuePair.Value.Shield > 0)
        //		{
        //			KeyValuePair<int, Status> keyValuePair2 = statusItr.Current;
        //			keyValuePair2.Value._clingingTimeTick = 0;
        //			KeyValuePair<int, Status> keyValuePair3 = statusItr.Current;
        //			keyValuePair3.Value._clingingTurn = 0;
        //		}
        //	}
        //}

        //public void RemoveUnitAggro(Unit target)
        //{
        //	target._aggro = 0;
        //	Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
        //	while (statusItr.MoveNext())
        //	{
        //		KeyValuePair<int, Status> keyValuePair = statusItr.Current;
        //		if (keyValuePair.Value.AggroVal > 0)
        //		{
        //			KeyValuePair<int, Status> keyValuePair2 = statusItr.Current;
        //			keyValuePair2.Value._aggroVal = 0;
        //			KeyValuePair<int, Status> keyValuePair3 = statusItr.Current;
        //			keyValuePair3.Value._clingingTimeTick = 0;
        //			KeyValuePair<int, Status> keyValuePair4 = statusItr.Current;
        //			keyValuePair4.Value._clingingTurn = 0;
        //		}
        //	}
        //}

        //public void UpdateUnitStatus()
        //{
        //	StautsLifeCheck();
        //	if (base.unit._charType != ECharacterType.RaidPart && base.unit._charType != ECharacterType.Raid)
        //	{
        //		base.unit._maxHealth = (int)((long)(base.unitDr.maxHealth + base.unit._addHp) * (100L + (long)base.unit.maxHealthBonus) / 100L);
        //	}
        //	long num = base.unit._takenDamage + base.unit._takenCriticalDamage;
        //	if (num > 0L)
        //	{
        //		if (base.unit._shiled > 0)
        //		{
        //			base.unit._shiled = (int)Math.Max((long)base.unit._shiled - num, -2147483648L);
        //			if (base.unit._shiled <= 0)
        //			{
        //				num = (long)(-(long)base.unit._shiled);
        //				base.unit._shiled = 0;
        //				base.unit._maxShiled = 0;
        //				RemoveUnitShield(base.unit);
        //			}
        //			else
        //			{
        //				num = 0L;
        //			}
        //		}
        //		if (_isRhsUnit)
        //		{
        //			if (_isRaidUnit)
        //			{
        //				base.frame._totalAttackDamage += num;
        //			}
        //			else if (base.unit._health > 0)
        //			{
        //				if (num > (long)base.unit._health)
        //				{
        //					base.frame._totalAttackDamage += (long)base.unit._health;
        //				}
        //				else
        //				{
        //					base.frame._totalAttackDamage += num;
        //				}
        //			}
        //		}
        //		if (!_isRaidUnit)
        //		{
        //			base.unit._health = (int)Math.Max((long)base.unit._health - num, -2147483648L);
        //		}
        //		if (!base.unit.isDead)
        //		{
        //			if (base.unit._hasEventHpSkill)
        //			{
        //				int num2 = base.frame.FindActivatableEventSkill(base.simulator.regulation, EventSkillType.OnHealthRate, base.unitIndex);
        //				if (num2 >= 0 && !base.unit.skills[num2].isIgnoreDeathType)
        //				{
        //					int remainedHealthRate = base.unit.skills[num2].SkillDataRow.remainedHealthRate;
        //					int num3 = (int)((long)base.unit._health * 100L / (long)base.unit._maxHealth);
        //					if (remainedHealthRate >= num3)
        //					{
        //						base.unit._eventSkillType = EventSkillType.OnHealthRate;
        //						base.unit._eventSkillIndex = num2;
        //						base.frame._isWaitingNextTurn = false;
        //					}
        //				}
        //			}
        //			if (!base.unit.hasEventSkill && base.unit._hasEventCounterSkill)
        //			{
        //				int num4 = base.frame.FindActivatableEventSkill(base.simulator.regulation, EventSkillType.OnBeHit, base.unitIndex);
        //				if (num4 >= 0)
        //				{
        //					int spCostOnBeHit = base.unit.skills[num4].SkillDataRow.spCostOnBeHit;
        //					if (spCostOnBeHit > _random.Next(0, 100))
        //					{
        //						base.unit._eventSkillType = EventSkillType.OnBeHit;
        //						base.unit._eventSkillIndex = num4;
        //						base.unit._eventSkillTargetUnitIndex = base.unit._enemyAttackerUnitIdx;
        //						base.frame._isWaitingNextTurn = false;
        //					}
        //				}
        //			}
        //		}
        //	}
        //	if (!base.unit._isDead)
        //	{
        //		long num5 = base.unit._takenHealing + base.unit._takenCriticalHealing;
        //		if (num5 > 0L)
        //		{
        //			base.unit._health = (int)Math.Min((long)base.unit._health + num5, 2147483647L);
        //			if (base.unit._health > base.unit.maxHealth && !_isRaidUnit)
        //			{
        //				base.unit._health = base.unit.maxHealth;
        //			}
        //		}
        //	}
        //	if (base.unit._health <= 0)
        //	{
        //		if (!base.unit._isDead)
        //		{
        //			if (!_isRaidUnit)
        //			{
        //				base.unit._isDead = true;
        //				base.unit._onDead = true;
        //			}
        //			if (base.unit._isDead)
        //			{
        //				if (!_isRhsUnit)
        //				{
        //					base.frame._lhsDeadUnitCount++;
        //				}
        //				if (base.unit.enemyAttackerUnitIdx >= 0)
        //				{
        //					Unit unit = base.frame.units[base.unit.enemyAttackerUnitIdx];
        //					if (unit != null)
        //					{
        //						for (int i = 0; i < unit.skills.Count; i++)
        //						{
        //							if (unit.skills[i] != null)
        //							{
        //								if (unit.skills[i].sp < unit.skills[i].SkillDataRow.maxSp)
        //								{
        //									unit.skills[i]._sp += unit.skills[i].SkillDataRow.spOnDestroy;
        //									if (unit.skills[i]._sp > unit.skills[i].SkillDataRow.maxSp)
        //									{
        //										unit.skills[i]._sp = unit.skills[i].SkillDataRow.maxSp;
        //									}
        //								}
        //								else
        //								{
        //									unit.skills[i]._sp = unit.skills[i].SkillDataRow.maxSp;
        //								}
        //								if (i > 1)
        //								{
        //									unit.skills[i]._curSp = unit.skills[i]._sp;
        //								}
        //							}
        //						}
        //					}
        //				}
        //				if (_isRhsUnit)
        //				{
        //					base.frame._gold += base.unit._dropGold;
        //					EBranch branch = base.unitDr.branch;
        //					if (branch != EBranch.Army)
        //					{
        //						if (branch == EBranch.Navy)
        //						{
        //							base.frame._navyDestoryCnt++;
        //						}
        //					}
        //					else
        //					{
        //						base.frame._armyDestoryCnt++;
        //					}
        //				}
        //				for (int j = 0; j < base.unit.skills.Count; j++)
        //				{
        //					if (base.unit.skills[j] != null)
        //					{
        //						base.unit.skills[j]._remainedMotionTime = 0;
        //					}
        //				}
        //				int num6 = base.frame.FindActivatableEventSkill(base.simulator.regulation, EventSkillType.OnHealthRate, base.unitIndex);
        //				if (num6 >= 0 && base.unit.skills[num6].isIgnoreDeathType)
        //				{
        //					int remainedHealthRate2 = base.unit.skills[num6].SkillDataRow.remainedHealthRate;
        //					int num7 = (int)((long)base.unit._health * 100L / (long)base.unit._maxHealth);
        //					if (remainedHealthRate2 >= num7)
        //					{
        //						base.unit._eventSkillType = EventSkillType.OnHealthRate;
        //						base.unit._eventSkillIndex = num6;
        //						base.frame._isWaitingNextTurn = false;
        //					}
        //				}
        //			}
        //		}
        //	}
        //	else if (base.unit._takenDamageRecovery > 0L)
        //	{
        //		base.unit._health = (int)Math.Min((long)base.unit._health + base.unit._takenDamageRecovery, 2147483647L);
        //		if (base.unit._health > base.unit.maxHealth && !_isRaidUnit)
        //		{
        //			base.unit._health = base.unit.maxHealth;
        //		}
        //		base.unit._statsHealing += base.unit._takenDamageRecovery;
        //		base.unit._uiTakenHealing += base.unit._takenDamageRecovery;
        //	}
        //}

        //public override bool OnUnitAccessStart()
        //{
        //	_hasActivatedSkills = false;
        //	_selectedSkillIndex = -1;
        //	_selectedTargetIndex = -1;
        //	_activatableSkills = null;
        //	_hasInputs = false;
        //	_hasEventInputs = false;
        //	_isRhsUnit = false;
        //	_isTurnUnit = false;
        //	_isRaidUnit = false;
        //	base.unit._enableEventSkill = false;
        //	base.unit._isTurn = false;
        //	base.unit._onDead = false;
        //	base.unit._uiTakenDamage = 0L;
        //	base.unit._uiTakenHealing = 0L;
        //	if (!base.frame.IsUnitInBattle(base.unitIndex))
        //	{
        //		return false;
        //	}
        //	if (base.unit._takenRevival)
        //	{
        //		base.unit._isDead = false;
        //	}
        //	if (base.frame.turnUnitIndex == base.unitIndex)
        //	{
        //		_isTurnUnit = true;
        //		base.unit._isTurn = true;
        //	}
        //	_isRhsUnit = base.frame.IsRhsUnitInBattle(base.unitIndex);
        //	if (_isRhsUnit)
        //	{
        //		if (base.simulator.initState.battleType == EBattleType.Raid)
        //		{
        //			_isRaidUnit = base.unit._charType == ECharacterType.Raid;
        //		}
        //		else if (base.simulator.initState.battleType == EBattleType.CooperateBattle)
        //		{
        //			_isRaidUnit = base.unit._charType == ECharacterType.Raid || base.unit._charType == ECharacterType.RaidPart;
        //		}
        //	}
        //	if (base.unit.isEnteredNow && base.unit._hasEventEnterSkill)
        //	{
        //		int num = base.frame.FindActivatableEventSkill(base.simulator.regulation, EventSkillType.OnBattleEnter, base.unitIndex);
        //		if (num >= 0)
        //		{
        //			base.unit._eventSkillType = EventSkillType.OnBattleEnter;
        //			base.unit._eventSkillIndex = num;
        //			base.frame._isWaitingNextTurn = false;
        //		}
        //		base.unit._isEnteredNow = false;
        //	}
        //	UpdateUnitStatus();
        //	UpdateInputData();
        //	if (base.unit._delayActiveTime > 0)
        //	{
        //		base.unit._delayActiveTime -= 66;
        //		return false;
        //	}
        //	return CanUpdateUnit();
        //}

        //protected bool CanUpdateUnit()
        //{
        //	if (base.simulator.option.immediatelyUseActiveSkill && !_isTurnUnit && _isRhsUnit)
        //	{
        //		if (!base.unit.isPlayingAction)
        //		{
        //			return true;
        //		}
        //		if (_hasEventInputs && base.unit.skills[_selectedSkillIndex].isIgnoreDeathType)
        //		{
        //			return true;
        //		}
        //	}
        //	if (base.simulator.option.playMode == Option.PlayMode.RealTime)
        //	{
        //		return true;
        //	}
        //	if (!base.frame.isWaitingInput || !_isTurnUnit)
        //	{
        //		if (base.simulator.option.playMode == Option.PlayMode.PureTurn)
        //		{
        //			return false;
        //		}
        //		if (!_hasInputs && !_hasEventInputs)
        //		{
        //			return false;
        //		}
        //	}
        //	return true;
        //}

        //protected bool UpdateInputData()
        //{
        //	if (base.unit.hasEventSkill && base.unit.eventSkillType == EventSkillType.OnBattleEnter)
        //	{
        //		_hasEventInputs = true;
        //		_selectedSkillIndex = base.unit._eventSkillIndex;
        //	}
        //	else
        //	{
        //		Input lhsInput = base.frame.lhsInput;
        //		Input rhsInput = base.frame.rhsInput;
        //		if (lhsInput != null && lhsInput.unitIndex == base.unitIndex)
        //		{
        //			if ((lhsInput.targetIndex == -1 || base.frame.IsRhsUnitInBattle(lhsInput.targetIndex)) && base.unit.hasActiveSkill && base.unit._activeSkillIdx == lhsInput.skillIndex && base.frame.CanUseSkill(base.simulator.option) && base.simulator.CanSkillAction(base.unit, lhsInput.skillIndex))
        //			{
        //				_hasInputs = true;
        //				_selectedSkillIndex = lhsInput.skillIndex;
        //				_selectedTargetIndex = lhsInput.targetIndex;
        //				if (!base.simulator.option.canSelectTarget)
        //				{
        //					_selectedTargetIndex = -1;
        //				}
        //			}
        //		}
        //		else if (rhsInput != null && rhsInput.unitIndex == base.unitIndex && base.simulator.CanUnitControl(base.unit) && (rhsInput.targetIndex == -1 || base.frame.IsRhsUnitInBattle(rhsInput.targetIndex)) && base.unit.hasActiveSkill && base.unit._activeSkillIdx == lhsInput.skillIndex && base.simulator.CanSkillAction(base.unit, rhsInput.skillIndex))
        //		{
        //			_hasInputs = true;
        //			_selectedSkillIndex = rhsInput.skillIndex;
        //			_selectedTargetIndex = rhsInput.targetIndex;
        //			if (!base.simulator.option.canSelectTarget)
        //			{
        //				_selectedTargetIndex = -1;
        //			}
        //		}
        //		if (!_hasInputs && base.unit.hasEventSkill)
        //		{
        //			_hasEventInputs = true;
        //			_selectedSkillIndex = base.unit._eventSkillIndex;
        //		}
        //	}
        //	if (base.unit.aggro > 0)
        //	{
        //		Unit unit = base.frame.units[base.unit.aggroUnitIdx];
        //		if (unit.isDead)
        //		{
        //			RemoveUnitAggro(base.unit);
        //		}
        //		else
        //		{
        //			_selectedTargetIndex = base.unit.aggroUnitIdx;
        //		}
        //	}
        //	return false;
        //}

        //public bool CanSkillAction(Skill skill)
        //{
        //	return skill != null && base.unit.stun <= 0 && base.unit.silenceVal <= 0 && (base.unit.aggro <= 0 || (skill.SkillDataRow.targetType != ESkillTargetType.Own && skill.SkillDataRow.targetType != ESkillTargetType.Friend));
        //}

        //public override void OnUnitAccessEnd()
        //{
        //	if (_activatableSkills == null || _activatableSkills.Count <= 0)
        //	{
        //		base.unit._eventSkillIndex = -1;
        //		return;
        //	}
        //	if (_hasActivatedSkills || (_selectedSkillIndex >= 0 && _activatableSkills[_selectedSkillIndex] == null))
        //	{
        //		foreach (Skill skill in _activatableSkills)
        //		{
        //			if (skill != null)
        //			{
        //				skill._remainedMotionTime = 0;
        //			}
        //		}
        //		base.unit._eventSkillIndex = -1;
        //		return;
        //	}
        //	if (_selectedSkillIndex < 0)
        //	{
        //		if (base.unit.isEnemyType)
        //		{
        //			for (int i = 1; i < _activatableSkills.Count; i++)
        //			{
        //				if (_activatableSkills[i] != null && _activatableSkills[i].isActiveSkill)
        //				{
        //					int num = base.frame.FindSkillTarget(base.simulator.regulation, base.unitIndex, i, 0);
        //					if (num >= 0)
        //					{
        //						_selectedSkillIndex = i;
        //						if (base.unit.aggro <= 0)
        //						{
        //							_selectedTargetIndex = num;
        //						}
        //						break;
        //					}
        //				}
        //			}
        //		}
        //		if (_selectedSkillIndex < 0 && _isTurnUnit)
        //		{
        //			if (_activatableSkills[0] != null)
        //			{
        //				int num2 = base.frame.FindSkillTarget(base.simulator.regulation, base.unitIndex, 0, 0);
        //				if (num2 >= 0)
        //				{
        //					_selectedSkillIndex = 0;
        //					if (base.unit.aggro <= 0)
        //					{
        //						_selectedTargetIndex = num2;
        //					}
        //				}
        //			}
        //			for (int j = 1; j < _activatableSkills.Count; j++)
        //			{
        //				if (_activatableSkills[j] != null && _activatableSkills[j].HasEventOccurrenceProbability)
        //				{
        //					int occurrenceProbability = _activatableSkills[j].SkillDataRow.occurrenceProbability;
        //					if (occurrenceProbability > _random.Next(0, 100))
        //					{
        //						int num3 = base.frame.FindSkillTarget(base.simulator.regulation, base.unitIndex, j, 0);
        //						if (num3 >= 0)
        //						{
        //							_selectedSkillIndex = j;
        //							if (base.unit.aggro <= 0)
        //							{
        //								_selectedTargetIndex = num3;
        //							}
        //						}
        //						break;
        //					}
        //				}
        //			}
        //		}
        //		if (_selectedSkillIndex < 0)
        //		{
        //			foreach (Skill skill2 in _activatableSkills)
        //			{
        //				if (skill2 != null)
        //				{
        //					skill2._remainedMotionTime = 0;
        //				}
        //			}
        //			base.unit._eventSkillIndex = -1;
        //			return;
        //		}
        //	}
        //	for (int k = 0; k < _activatableSkills.Count; k++)
        //	{
        //		Skill skill3 = _activatableSkills[k];
        //		if (skill3 != null)
        //		{
        //			SkillDataRow skillDataRow = base.simulator.regulation.skillDtbl[skill3.dri];
        //			if (skillDataRow != null)
        //			{
        //				if (k != _selectedSkillIndex)
        //				{
        //					skill3._remainedMotionTime = 0;
        //				}
        //				else
        //				{
        //					if (_selectedTargetIndex < 0)
        //					{
        //						int num4 = base.frame.FindSkillTarget(base.simulator.regulation, base.unitIndex, _selectedSkillIndex, 0);
        //						if (num4 >= 0)
        //						{
        //							_selectedTargetIndex = num4;
        //						}
        //					}
        //					if (_selectedTargetIndex < 0)
        //					{
        //						base.unit._eventSkillIndex = -1;
        //						skill3._remainedMotionTime = 0;
        //						if (base.unit.skills[_selectedSkillIndex].isIgnoreDeathType)
        //						{
        //							base.unit._hasEventDeathSkill = false;
        //							return;
        //						}
        //					}
        //					else
        //					{
        //						if (_hasInputs)
        //						{
        //							if (base.frame.lhsInput != null && base.frame.lhsInput.unitIndex == base.unitIndex && _selectedSkillIndex == base.frame.lhsInput.skillIndex)
        //							{
        //								base.frame.lhsInput._result = true;
        //							}
        //							if (base.frame.rhsInput != null && base.frame.rhsInput.unitIndex == base.unitIndex && _selectedSkillIndex == base.frame.rhsInput.skillIndex)
        //							{
        //								base.frame.rhsInput._result = true;
        //							}
        //						}
        //						if (_isTurnUnit)
        //						{
        //							base.frame._isWaitingInput = false;
        //						}
        //						if (skill3.isActiveSkill)
        //						{
        //							base.frame._hasSkillActionUnit = true;
        //						}
        //						base.unit._playingActionIndex = _selectedSkillIndex;
        //						skill3._activeState = false;
        //						skill3._targetIndex = _selectedTargetIndex;
        //						if (base.unit.eventSkillType == EventSkillType.OnCombo)
        //						{
        //							skill3._remainedMotionTime += 660;
        //						}
        //						if (skill3._bCutInSkill)
        //						{
        //							FireEvent fireEvent = base.simulator.regulation.unitMotionDtbl[skill3.unitMotionDri].fireEvents[0];
        //							if (base.simulator.option.canInterfereSkill)
        //							{
        //								if (skill3.FireActionDr != null)
        //								{
        //								}
        //							}
        //							else if (skill3.FireActionDr != null)
        //							{
        //								FireActionDataRow.TimeSet timeSet = skill3.FireActionDr.GetTimeSet(base.simulator.CanEnableFireAction(base.unit));
        //								if (timeSet.timeSleepDuringFire)
        //								{
        //									skill3._remainedMotionTime -= fireEvent.time;
        //								}
        //								else
        //								{
        //									skill3._remainedMotionTime += timeSet.fireDelayTime;
        //								}
        //							}
        //							else
        //							{
        //								skill3._remainedMotionTime -= fireEvent.time;
        //							}
        //							skill3._remainedMotionTime += 66;
        //						}
        //						skill3._initMotionTime = skill3._remainedMotionTime;
        //						if (!_isRhsUnit && skill3.isActiveSkill)
        //						{
        //							base.frame._lhsActiveSkillUseCount++;
        //						}
        //						int num5 = base.unitDr.attackDamage + base.unit._addAtk;
        //						int num6 = (int)((long)skillDataRow.attackDamage * (long)skill3.SkillLevelFormal.AttackDamage / 1000L);
        //						int num7 = skillDataRow.attackDamage + num6;
        //						int attackDamageBonus = base.unit.attackDamageBonus;
        //						int num8 = base.unitDr.accuracy + base.unit._addAim;
        //						int accuracy = skillDataRow.accuracy;
        //						int accuracyBonus = base.unit.accuracyBonus;
        //						int num9 = base.unitDr.criticalChance + base.unit._addCitr;
        //						int criticalChance = skillDataRow.criticalChance;
        //						int criticalChanceBonus = base.unit.criticalChanceBonus;
        //						int num10 = base.unitDr.criticalDamageBonus + base.unit._addCitDmg;
        //						int criticalDamageBonus = skillDataRow.criticalDamageBonus;
        //						int criticalDamageBonus2 = base.unit.criticalDamageBonus;
        //						skill3._attackDamage = (num5 + num7) * (100 + attackDamageBonus) / 100;
        //						if (skill3._attackDamage < 0)
        //						{
        //							skill3._attackDamage = 0;
        //						}
        //						skill3._accuracy = (num8 + accuracy) * (100 + accuracyBonus) / 100;
        //						if (skill3._accuracy < 0)
        //						{
        //							skill3._accuracy = 0;
        //						}
        //						skill3._criticalChance = (num9 + criticalChance) * (100 + criticalChanceBonus) / 100;
        //						if (skill3._criticalChance < 0)
        //						{
        //							skill3._criticalChance = 0;
        //						}
        //						skill3._criticalDamage = (int)((long)skill3.attackDamage * (long)(100 + num10 + criticalDamageBonus + criticalDamageBonus2) / 100L);
        //						if (skill3._criticalDamage < skill3.attackDamage)
        //						{
        //							skill3._criticalDamage = skill3.attackDamage;
        //						}
        //						if (_hasEventInputs)
        //						{
        //							if (base.unit.eventSkillIndex != _selectedSkillIndex)
        //							{
        //								if (base.unit.eventSkillType != EventSkillType.OnHealthRate)
        //								{
        //									base.unit._eventSkillIndex = -1;
        //								}
        //							}
        //							else
        //							{
        //								base.unit._eventSkillIndex = -1;
        //								base.unit._enableEventSkill = true;
        //							}
        //						}
        //						if (base.unit.isEnableEventSkill)
        //						{
        //							if (base.unit.eventSkillType == EventSkillType.OnBeHit)
        //							{
        //								skill3._attackDamage = (int)((long)skill3._attackDamage * 110L / 100L);
        //								skill3._criticalDamage = (int)((long)skill3._criticalDamage * 110L / 100L);
        //							}
        //							if (base.unit.eventSkillType != EventSkillType.OnCombo)
        //							{
        //								skill3._sp -= skillDataRow.maxSp;
        //							}
        //						}
        //						else
        //						{
        //							skill3._sp -= skillDataRow.maxSp;
        //						}
        //						if (skill3.SkillDataRow.consumeHpRate > 0 && base.unit._health > 0)
        //						{
        //							int num11 = (int)((long)base.unit._maxHealth * (long)skill3.SkillDataRow.consumeHpRate / 100L);
        //							if (num11 >= base.unit._health)
        //							{
        //								num11 = base.unit._health - 1;
        //							}
        //							base.unit._health -= num11;
        //							base.unit._uiTakenDamage += (long)num11;
        //						}
        //						skill3._curSp = skill3._sp;
        //					}
        //				}
        //			}
        //		}
        //	}
        //}

        //public override bool OnSkillAccessStart()
        //{
        //	if (base.simulator.option.playMode == Option.PlayMode.RealTime)
        //	{
        //		base.skill._sp++;
        //	}
        //	if (base.skill._remainedMotionTime > 0 && !_hasInputs)
        //	{
        //		_hasActivatedSkills = true;
        //		return false;
        //	}
        //	if (base.unit._cls < base.skill.SkillDataRow.openGrade)
        //	{
        //		return false;
        //	}
        //	if (!base.skill.CanUse)
        //	{
        //		return false;
        //	}
        //	if (base.unit.isDead)
        //	{
        //		if (!base.skill.isIgnoreDeathType)
        //		{
        //			return false;
        //		}
        //	}
        //	else
        //	{
        //		if (base.unit.isStatusStun)
        //		{
        //			return false;
        //		}
        //		if (base.unit.isStatusSilence)
        //		{
        //			if (base.skillIndex != 0)
        //			{
        //				return false;
        //			}
        //			if (_hasInputs)
        //			{
        //				return false;
        //			}
        //			if (_hasEventInputs && base.unit.eventSkillType != EventSkillType.OnBeHit && base.unit.eventSkillType != EventSkillType.OnCombo)
        //			{
        //				return false;
        //			}
        //		}
        //		if (base.unit.isStatusAggro && (base.skill.SkillDataRow.targetType == ESkillTargetType.Own || base.skill.SkillDataRow.targetType == ESkillTargetType.Friend))
        //		{
        //			return false;
        //		}
        //	}
        //	if (base.skill.isActiveSkill && !base.frame.CanUseSkill(base.simulator.option))
        //	{
        //		return false;
        //	}
        //	if (base.unitMotionDr.fireEvents[0] == null)
        //	{
        //		return false;
        //	}
        //	if (_activatableSkills == null)
        //	{
        //		Regulation.ExtendList<Skill>(ref _activatableSkills, 5);
        //	}
        //	base.skill._remainedMotionTime = base.unitMotionDr.playTime + 66;
        //	_activatableSkills[base.skillIndex] = base.skill;
        //	return false;
        //}

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
    }
}
