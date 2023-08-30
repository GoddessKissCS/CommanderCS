using Newtonsoft.Json;


namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Frame
    {
        internal Frame()
        {
        }

        public int randomSeed
        {
            get
            {
                return this._randomSeed;
            }
        }

        public Input lhsInput
        {
            get
            {
                return this._lhsInput;
            }
        }

        public Input rhsInput
        {
            get
            {
                return this._rhsInput;
            }
        }

        public IList<Unit> units
        {
            get
            {
                return this._units.AsReadOnly();
            }
        }

        public int time
        {
            get
            {
                return this._time;
            }
        }

        public int turn
        {
            get
            {
                return this._turn;
            }
        }

        public IList<int> lhsTimeLine
        {
            get
            {
                return this._lhsTimeLine.AsReadOnly();
            }
        }

        public IList<int> rhsTimeLine
        {
            get
            {
                return this._rhsTimeLine.AsReadOnly();
            }
        }

        public bool isWaitingInput
        {
            get
            {
                return this._isWaitingInput;
            }
        }

        public int turnUnitIndex
        {
            get
            {
                return this._turnUnitIndex;
            }
        }

        public int lhsTroopStartIndex
        {
            get
            {
                return this._lhsTroopStartIndex;
            }
        }

        public int rhsTroopStartIndex
        {
            get
            {
                return this._rhsTroopStartIndex;
            }
        }

        public int gold
        {
            get
            {
                return this._gold;
            }
        }

        public int armyDestoryCnt
        {
            get
            {
                return this._armyDestoryCnt;
            }
        }

        public int navyDestoryCnt
        {
            get
            {
                return this._navyDestoryCnt;
            }
        }

        public long totalAttackDamage
        {
            get
            {
                return this._totalAttackDamage;
            }
        }

        public bool onTurn
        {
            get
            {
                return this._onTurn;
            }
        }

        public bool lhsOnWave
        {
            get
            {
                return this._lhsOnWave;
            }
        }

        public bool rhsOnWave
        {
            get
            {
                return this._rhsOnWave;
            }
        }

        public bool onWaveTurn
        {
            get
            {
                return this._onWaveTurn;
            }
        }

        public bool isWaitingLhsInput
        {
            get
            {
                return this._isWaitingInput && this.IsLhsUnitInBattle(this._turnUnitIndex);
            }
        }

        public bool isWaitingRhsInput
        {
            get
            {
                return this._isWaitingInput && this.IsRhsUnitInBattle(this._turnUnitIndex);
            }
        }

        public static bool IsSame(Frame f1, Frame f2)
        {
            return f1 == f2 || (f1._randomSeed == f2.randomSeed && f1._isWaitingInput == f2.isWaitingInput && f1._isWaitingNextTurn == f2._isWaitingNextTurn && f1._turnUnitIndex == f2._turnUnitIndex && f1._lhsTroopStartIndex == f2._lhsTroopStartIndex && f1._rhsTroopStartIndex == f2._rhsTroopStartIndex && f1._time == f2._time && f1._turn == f2._turn && Input.IsSame(f1._lhsInput, f2._lhsInput) && f1._rhsInput == f2._rhsInput && f1._units.Count == f2._units.Count);
        }

        public bool IsUnitInBattle(int unitIndex)
        {
            return this.IsLhsUnitInBattle(unitIndex) || this.IsRhsUnitInBattle(unitIndex);
        }

        public bool IsLhsUnit(int unitIndex)
        {
            for (int i = this._lhsTroopStartIndex; i >= 0; i -= 9)
            {
                int num = i + 9;
                if (unitIndex >= i && unitIndex < num)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRhsUnit(int unitIndex)
        {
            int i = this._rhsTroopStartIndex;
            int count = this.units.Count;
            while (i >= count)
            {
                int num = i + 9;
                if (unitIndex >= i && unitIndex < num)
                {
                    return true;
                }
                i += 9;
            }
            return false;
        }

        public bool IsLhsUnitInBattle(int unitIndex)
        {
            int lhsTroopStartIndex = this._lhsTroopStartIndex;
            int num = lhsTroopStartIndex + 9;
            return unitIndex >= lhsTroopStartIndex && unitIndex < num;
        }

        public bool IsRhsUnitInBattle(int unitIndex)
        {
            int rhsTroopStartIndex = this._rhsTroopStartIndex;
            int num = rhsTroopStartIndex + 9;
            return unitIndex >= rhsTroopStartIndex && unitIndex < num;
        }

        //public int FindSkillTarget(Regulation rg, int unitIndex, int skillIndex, int subIndex = 0)
        //{
        //	Unit unit = this._units[unitIndex];
        //	Skill skill = ((unit != null) ? unit.skills[skillIndex] : null);
        //	if (skill == null)
        //	{
        //		return -1;
        //	}
        //	SkillDataRow skillDataRow = skill.SkillDataRow;
        //	int num = 0;
        //	ESkillTargetType eskillTargetType = skillDataRow.targetTypes[subIndex];
        //	if (eskillTargetType != ESkillTargetType.Own)
        //	{
        //		if (eskillTargetType != ESkillTargetType.Friend)
        //		{
        //			if (eskillTargetType == ESkillTargetType.Enemy)
        //			{
        //				if (unit.side == EBattleSide.Left)
        //				{
        //					num = this._rhsTroopStartIndex;
        //				}
        //				else
        //				{
        //					num = this._lhsTroopStartIndex;
        //				}
        //			}
        //		}
        //		else if (unit.side == EBattleSide.Left)
        //		{
        //			num = this._lhsTroopStartIndex;
        //		}
        //		else
        //		{
        //			num = this._rhsTroopStartIndex;
        //		}
        //		int[,] array = null;
        //		switch (unitIndex % 9)
        //		{
        //		case 0:
        //		case 3:
        //		case 6:
        //			switch (skillDataRow.targetPatterns[subIndex])
        //			{
        //			case ESkillTargetPattern.Normal:
        //				array = Frame._PriorityTable036;
        //				break;
        //			case ESkillTargetPattern.Front:
        //				array = Frame._PriorityFrontTable036;
        //				break;
        //			case ESkillTargetPattern.Back:
        //				array = Frame._PriorityBackTable036;
        //				break;
        //			case ESkillTargetPattern.sequence:
        //				array = Frame._PriorityFrontTable036;
        //				break;
        //			case ESkillTargetPattern.Random:
        //				array = this.GetRandomPriorityTable();
        //				break;
        //			default:
        //				array = Frame._PriorityTable036;
        //				break;
        //			}
        //			break;
        //		case 1:
        //		case 4:
        //		case 7:
        //			switch (skillDataRow.targetPatterns[subIndex])
        //			{
        //			case ESkillTargetPattern.Normal:
        //				array = Frame._PriorityTable147;
        //				break;
        //			case ESkillTargetPattern.Front:
        //				array = Frame._PriorityFrontTable147;
        //				break;
        //			case ESkillTargetPattern.Back:
        //				array = Frame._PriorityBackTable147;
        //				break;
        //			case ESkillTargetPattern.sequence:
        //				array = Frame._PriorityFrontTable036;
        //				break;
        //			case ESkillTargetPattern.Random:
        //				array = this.GetRandomPriorityTable();
        //				break;
        //			default:
        //				array = Frame._PriorityTable147;
        //				break;
        //			}
        //			break;
        //		case 2:
        //		case 5:
        //		case 8:
        //			switch (skillDataRow.targetPatterns[subIndex])
        //			{
        //			case ESkillTargetPattern.Normal:
        //				array = Frame._PriorityTable258;
        //				break;
        //			case ESkillTargetPattern.Front:
        //				array = Frame._PriorityFrontTable258;
        //				break;
        //			case ESkillTargetPattern.Back:
        //				array = Frame._PriorityBackTable258;
        //				break;
        //			case ESkillTargetPattern.sequence:
        //				array = Frame._PriorityFrontTable036;
        //				break;
        //			case ESkillTargetPattern.Random:
        //				array = this.GetRandomPriorityTable();
        //				break;
        //			default:
        //				array = Frame._PriorityTable258;
        //				break;
        //			}
        //			break;
        //		}
        //		bool flag = false;
        //		bool flag2 = false;
        //		Unit unit2 = null;
        //		Unit unit3 = null;
        //		for (int i = 0; i < array.GetLength(0); i++)
        //		{
        //			if (flag)
        //			{
        //				break;
        //			}
        //			for (int j = 0; j < array.GetLength(1); j++)
        //			{
        //				int num2 = array[i, j];
        //				int num3 = num + num2;
        //				if (num3 >= 0 && num3 < this._units.Count)
        //				{
        //					Unit unit4 = this._units[num3];
        //					if (unit4 != null && unit4.health > 0)
        //					{
        //						if (unit2 == null)
        //						{
        //							unit2 = unit4;
        //						}
        //						if (unit4.attackPoint && skill.isDamageSkill(subIndex))
        //						{
        //							unit3 = unit4;
        //							flag = true;
        //							break;
        //						}
        //						if (!flag2)
        //						{
        //							if (this.IsTargetStatusCondition(unit4, skillDataRow.targetStatusConditions[subIndex], skillDataRow.conditionValues[subIndex]))
        //							{
        //								flag2 = true;
        //								bool flag3 = true;
        //								bool flag4 = true;
        //								if (skillDataRow.targetJobConditions[subIndex] != ESkillTargetJobCondition.None)
        //								{
        //									flag2 = false;
        //									if (unit3 != null)
        //									{
        //										int num4 = this.JobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit3, unit4);
        //										if (num4 > 0)
        //										{
        //											flag4 = false;
        //											if (this.IsHighJobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit4) && skillDataRow.targetStatisticConditions[subIndex] == ESkillTargetStatisticCondition.None)
        //											{
        //												flag2 = true;
        //											}
        //										}
        //										else if (num4 == 0)
        //										{
        //											flag4 = true;
        //											flag3 = false;
        //										}
        //										else
        //										{
        //											flag3 = false;
        //											flag4 = false;
        //										}
        //									}
        //									else
        //									{
        //										flag4 = false;
        //										if (this.IsHighJobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit4) && skillDataRow.targetStatisticConditions[subIndex] == ESkillTargetStatisticCondition.None)
        //										{
        //											flag2 = true;
        //										}
        //									}
        //								}
        //								if (flag4 && skillDataRow.targetStatisticConditions[subIndex] != ESkillTargetStatisticCondition.None)
        //								{
        //									flag2 = false;
        //									if (unit3 != null)
        //									{
        //										flag3 = false;
        //										if (this.StatisticCondition(rg, skillDataRow.targetStatisticConditions[subIndex], unit3, unit4))
        //										{
        //											flag3 = true;
        //										}
        //									}
        //								}
        //								if (flag3)
        //								{
        //									unit3 = unit4;
        //								}
        //								if (flag2 && !skill.isDamageSkill(subIndex))
        //								{
        //									flag = true;
        //									break;
        //								}
        //							}
        //						}
        //					}
        //				}
        //			}
        //		}
        //		Unit unit5 = null;
        //		if (unit3 != null)
        //		{
        //			unit5 = unit3;
        //		}
        //		else if (skillDataRow.conditionTypes[subIndex] == ESkillConditionType.None && unit2 != null)
        //		{
        //			unit5 = unit2;
        //		}
        //		if (unit5 != null)
        //		{
        //			return unit5._unitIdx;
        //		}
        //		return -1;
        //	}
        //	else
        //	{
        //		if (skillDataRow.conditionTypes[subIndex] == ESkillConditionType.None)
        //		{
        //			return unitIndex;
        //		}
        //		if (this.IsTargetStatusCondition(unit, skillDataRow.targetStatusConditions[subIndex], skillDataRow.conditionValues[subIndex]))
        //		{
        //			return unitIndex;
        //		}
        //		return -1;
        //	}
        //}

        //public bool StatisticCondition(Regulation rg, ESkillTargetStatisticCondition statisticCondition, Unit srcUnit, Unit targetUnit)
        //{
        //	switch (statisticCondition)
        //	{
        //	case ESkillTargetStatisticCondition.None:
        //		return true;
        //	case ESkillTargetStatisticCondition.Minimum_HpRate:
        //	{
        //		float num = (float)srcUnit.health / (float)srcUnit.maxHealth;
        //		float num2 = (float)targetUnit.health / (float)targetUnit.maxHealth;
        //		return num2 < num;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_HpRate:
        //	{
        //		float num3 = (float)srcUnit.health / (float)srcUnit.maxHealth;
        //		float num4 = (float)targetUnit.health / (float)targetUnit.maxHealth;
        //		return num4 > num3;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Hp:
        //		return targetUnit.health < srcUnit.health;
        //	case ESkillTargetStatisticCondition.Maximum_Hp:
        //		return targetUnit.health > srcUnit.health;
        //	case ESkillTargetStatisticCondition.Minimum_Atk:
        //	{
        //		UnitDataRow unitDataRow = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow2 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addAtk + unitDataRow2.attackDamage < srcUnit._addAtk + unitDataRow.attackDamage;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Atk:
        //	{
        //		UnitDataRow unitDataRow3 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow4 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addAtk + unitDataRow4.attackDamage > srcUnit._addAtk + unitDataRow3.attackDamage;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Aim:
        //	{
        //		UnitDataRow unitDataRow5 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow6 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addAim + unitDataRow6.accuracy < srcUnit._addAim + unitDataRow5.accuracy;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Aim:
        //	{
        //		UnitDataRow unitDataRow7 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow8 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addAim + unitDataRow8.accuracy > srcUnit._addAim + unitDataRow7.accuracy;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Luk:
        //	{
        //		UnitDataRow unitDataRow9 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow10 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addLuck + unitDataRow10.luck < srcUnit._addLuck + unitDataRow9.luck;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Luk:
        //	{
        //		UnitDataRow unitDataRow11 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow12 = rg.unitDtbl[targetUnit.dri];
        //		return targetUnit._addLuck + unitDataRow12.luck > srcUnit._addLuck + unitDataRow11.luck;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Active_Sp:
        //		return targetUnit.hasActiveSkill && (!srcUnit.hasActiveSkill || targetUnit.skills[targetUnit._activeSkillIdx].sp < srcUnit.skills[srcUnit._activeSkillIdx].sp);
        //	case ESkillTargetStatisticCondition.Maximum_Active_Sp:
        //		return targetUnit.hasActiveSkill && (!srcUnit.hasActiveSkill || targetUnit.skills[targetUnit._activeSkillIdx].sp > srcUnit.skills[srcUnit._activeSkillIdx].sp);
        //	case ESkillTargetStatisticCondition.Minimum_Atk_With_Buff:
        //	{
        //		UnitDataRow unitDataRow13 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow14 = rg.unitDtbl[targetUnit.dri];
        //		int num5 = (unitDataRow13.attackDamage + srcUnit._addAtk) * (100 + srcUnit.attackDamageBonus) / 100;
        //		int num6 = (unitDataRow14.attackDamage + targetUnit._addAtk) * (100 + targetUnit.attackDamageBonus) / 100;
        //		return num6 < num5;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Atk_With_Buff:
        //	{
        //		UnitDataRow unitDataRow15 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow16 = rg.unitDtbl[targetUnit.dri];
        //		int num7 = (unitDataRow15.attackDamage + srcUnit._addAtk) * (100 + srcUnit.attackDamageBonus) / 100;
        //		int num8 = (unitDataRow16.attackDamage + targetUnit._addAtk) * (100 + targetUnit.attackDamageBonus) / 100;
        //		return num8 > num7;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Aim_With_Buff:
        //	{
        //		UnitDataRow unitDataRow17 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow18 = rg.unitDtbl[targetUnit.dri];
        //		int num9 = (unitDataRow17.accuracy + srcUnit._addAim) * (100 + srcUnit.accuracyBonus) / 100;
        //		int num10 = (unitDataRow18.accuracy + targetUnit._addAim) * (100 + targetUnit.accuracyBonus) / 100;
        //		return num10 < num9;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Aim_With_Buff:
        //	{
        //		UnitDataRow unitDataRow19 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow20 = rg.unitDtbl[targetUnit.dri];
        //		int num11 = (unitDataRow19.accuracy + srcUnit._addAim) * (100 + srcUnit.accuracyBonus) / 100;
        //		int num12 = (unitDataRow20.accuracy + targetUnit._addAim) * (100 + targetUnit.accuracyBonus) / 100;
        //		return num12 > num11;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Luk_With_Buff:
        //	{
        //		UnitDataRow unitDataRow21 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow22 = rg.unitDtbl[targetUnit.dri];
        //		int num13 = (unitDataRow21.luck + srcUnit._addLuck) * (100 + srcUnit.luckBonus) / 100;
        //		int num14 = (unitDataRow22.luck + targetUnit._addLuck) * (100 + targetUnit.luckBonus) / 100;
        //		return num14 < num13;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Luk_With_Buff:
        //	{
        //		UnitDataRow unitDataRow23 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow24 = rg.unitDtbl[targetUnit.dri];
        //		int num15 = (unitDataRow23.luck + srcUnit._addLuck) * (100 + srcUnit.luckBonus) / 100;
        //		int num16 = (unitDataRow24.luck + targetUnit._addLuck) * (100 + targetUnit.luckBonus) / 100;
        //		return num16 > num15;
        //	}
        //	case ESkillTargetStatisticCondition.Minimum_Def_With_Buff:
        //	{
        //		UnitDataRow unitDataRow25 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow26 = rg.unitDtbl[targetUnit.dri];
        //		int num17 = (unitDataRow25.defense + srcUnit._addDef) * (100 + srcUnit.defenseBonus) / 100;
        //		int num18 = (unitDataRow26.defense + targetUnit._addDef) * (100 + targetUnit.defenseBonus) / 100;
        //		return num18 < num17;
        //	}
        //	case ESkillTargetStatisticCondition.Maximum_Def_With_Buff:
        //	{
        //		UnitDataRow unitDataRow27 = rg.unitDtbl[srcUnit.dri];
        //		UnitDataRow unitDataRow28 = rg.unitDtbl[targetUnit.dri];
        //		int num19 = (unitDataRow27.defense + srcUnit._addDef) * (100 + srcUnit.defenseBonus) / 100;
        //		int num20 = (unitDataRow28.defense + targetUnit._addDef) * (100 + targetUnit.defenseBonus) / 100;
        //		return num20 > num19;
        //	}
        //	default:
        //		return false;
        //	}
        //}

        //protected bool IsHighJobCondition(Regulation rg, ESkillTargetJobCondition jobCondition, Unit targetUnit)
        //{
        //	UnitDataRow unitDataRow = rg.unitDtbl[targetUnit.dri];
        //	switch (jobCondition)
        //	{
        //	case ESkillTargetJobCondition.None:
        //		return true;
        //	case ESkillTargetJobCondition.Defender_Supporter_Attacker:
        //	case ESkillTargetJobCondition.Defender_Attacker_Supporter:
        //		return unitDataRow.job == EJob.Defense;
        //	case ESkillTargetJobCondition.Supporter_Attacker_Defender:
        //	case ESkillTargetJobCondition.Supporter_Defender_Attacker:
        //		return unitDataRow.job == EJob.Support;
        //	case ESkillTargetJobCondition.Attacker_Defender_Supporter:
        //	case ESkillTargetJobCondition.Attacker_Supporter_Defender:
        //		return unitDataRow.job == EJob.Attack;
        //	default:
        //		return false;
        //	}
        //}

        //protected int JobCondition(Regulation rg, ESkillTargetJobCondition jobCondition, Unit srcUnit, Unit targetUnit)
        //{
        //	UnitDataRow unitDataRow = rg.unitDtbl[srcUnit.dri];
        //	UnitDataRow unitDataRow2 = rg.unitDtbl[targetUnit.dri];
        //	if (unitDataRow.job == unitDataRow2.job)
        //	{
        //		return 0;
        //	}
        //	switch (jobCondition)
        //	{
        //	case ESkillTargetJobCondition.None:
        //		return -1;
        //	case ESkillTargetJobCondition.Defender_Supporter_Attacker:
        //		if (unitDataRow2.job == EJob.Defense)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Support && unitDataRow.job != EJob.Defense)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	case ESkillTargetJobCondition.Defender_Attacker_Supporter:
        //		if (unitDataRow2.job == EJob.Defense)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Attack && unitDataRow.job != EJob.Defense)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	case ESkillTargetJobCondition.Supporter_Attacker_Defender:
        //		if (unitDataRow2.job == EJob.Support)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Attack && unitDataRow.job != EJob.Support)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	case ESkillTargetJobCondition.Supporter_Defender_Attacker:
        //		if (unitDataRow2.job == EJob.Support)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Defense && unitDataRow.job != EJob.Support)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	case ESkillTargetJobCondition.Attacker_Defender_Supporter:
        //		if (unitDataRow2.job == EJob.Attack)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Defense && unitDataRow.job != EJob.Attack)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	case ESkillTargetJobCondition.Attacker_Supporter_Defender:
        //		if (unitDataRow2.job == EJob.Attack)
        //		{
        //			return 1;
        //		}
        //		if (unitDataRow2.job == EJob.Support && unitDataRow.job != EJob.Attack)
        //		{
        //			return 1;
        //		}
        //		return -1;
        //	default:
        //		return -1;
        //	}
        //}

        //public bool IsTargetStatusCondition(Unit targetUnit, ESkillTargetStatusCondition condition, int conditionVal = 0)
        //{
        //	switch (condition)
        //	{
        //	case ESkillTargetStatusCondition.None:
        //		return true;
        //	case ESkillTargetStatusCondition.StatusDotDamage:
        //		return targetUnit.dotDamangeVal > 0;
        //	case ESkillTargetStatusCondition.StatusUnbeatable:
        //		return targetUnit.unbeatableVal > 0;
        //	case ESkillTargetStatusCondition.StatusSilence:
        //		return targetUnit.silenceVal > 0;
        //	case ESkillTargetStatusCondition.StatusStun:
        //		return targetUnit.stun > 0;
        //	case ESkillTargetStatusCondition.StatusAggro:
        //		return targetUnit.aggro > 0;
        //	case ESkillTargetStatusCondition.StatusBuff:
        //		return targetUnit.maxHealthBonus > 0 || targetUnit.speedBonus > 0 || targetUnit.accuracyBonus > 0 || targetUnit.luckBonus > 0 || targetUnit.attackDamageBonus > 0 || targetUnit.defenseBonus > 0 || targetUnit.criticalChanceBonus > 0 || targetUnit.criticalDamageBonus > 0;
        //	case ESkillTargetStatusCondition.StatusMinHpRate:
        //	{
        //		int num = (int)((long)targetUnit.health * 100L / (long)targetUnit.maxHealth);
        //		return num <= conditionVal;
        //	}
        //	case ESkillTargetStatusCondition.StatusMaxHpRate:
        //	{
        //		int num2 = (int)((long)targetUnit.health * 100L / (long)targetUnit.maxHealth);
        //		return num2 >= conditionVal;
        //	}
        //	case ESkillTargetStatusCondition.StatusShield:
        //		return targetUnit.shiled > 0;
        //	default:
        //		return false;
        //	}
        //}

        //public List<int> FindSkillTargetCandidates(Regulation rg, int unitIndex, int skillIndex)
        //{
        //	Unit unit = this._units[unitIndex];
        //	Skill skill = ((unit != null) ? unit._skills[skillIndex] : null);
        //	if (skill == null)
        //	{
        //		return new List<int>();
        //	}
        //	SkillDataRow skillDataRow = rg.skillDtbl[skill.dri];
        //	ESkillTargetType targetType = skillDataRow.targetType;
        //	if (targetType == ESkillTargetType.Friend)
        //	{
        //		return this.FindFriendTargetCandidates(unitIndex);
        //	}
        //	if (targetType != ESkillTargetType.Enemy)
        //	{
        //		return this.FindEnemyTargetCandidates(unitIndex, false);
        //	}
        //	return this.FindEnemyTargetCandidates(unitIndex, true);
        //}

        public List<int> FindFriendTargetCandidates(int unitIndex)
        {
            int num = this._rhsTroopStartIndex;
            if (!this.IsRhsUnitInBattle(unitIndex))
            {
                num = this._lhsTroopStartIndex;
            }
            return this._FindTargetCandidates(unitIndex, num, true);
        }

        public List<int> FindEnemyTargetCandidates(int unitIndex, bool shouldIgnoreBlocking = false)
        {
            int num = this._rhsTroopStartIndex;
            if (this.IsRhsUnitInBattle(unitIndex))
            {
                num = this._lhsTroopStartIndex;
            }
            return this._FindTargetCandidates(unitIndex, num, true);
        }

        private int[,] GetRandomPriorityTable()
        {
            Random random = new Random(this._randomSeed);
            switch (random.Next(0, 9))
            {
                case 0:
                    return Frame._PriorityTable036;
                case 1:
                    return Frame._PriorityTable258;
                case 2:
                    return Frame._PriorityTable147;
                case 3:
                    return Frame._PriorityFrontTable036;
                case 4:
                    return Frame._PriorityFrontTable258;
                case 5:
                    return Frame._PriorityFrontTable147;
                case 6:
                    return Frame._PriorityBackTable036;
                case 7:
                    return Frame._PriorityBackTable258;
                case 8:
                    return Frame._PriorityBackTable147;
                default:
                    return Frame._PriorityTable036;
            }
        }

        private List<int> _FindTargetCandidates(int unitIndex, int targetTroopStartIndex, bool shouldIgnoreBlocking)
        {
            int num = unitIndex % 9;
            List<int> list = new List<int>();
            int[,] array = Frame._PriorityTable147;
            switch (num)
            {
                case 0:
                case 3:
                case 6:
                    array = Frame._PriorityTable036;
                    break;
                case 2:
                case 5:
                case 8:
                    array = Frame._PriorityTable258;
                    break;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int num2 = array[i, j];
                    int num3 = targetTroopStartIndex + num2;
                    if (num3 >= 0 && num3 < this._units.Count)
                    {
                        Unit unit = this._units[num3];
                        if (unit != null && unit.health > 0)
                        {
                            list.Add(num3);
                            if (!shouldIgnoreBlocking)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return list;
        }

        //public int FindActivatableEventSkill(Regulation rg, EventSkillType type, int unitIndex)
        //{
        //	Unit unit = this._units[unitIndex];
        //	if (unit == null)
        //	{
        //		return -1;
        //	}
        //	for (int i = 0; i < unit._skills.Count; i++)
        //	{
        //		Skill skill = unit._skills[i];
        //		if (skill != null && skill.remainedMotionTime <= 0)
        //		{
        //			SkillDataRow skillDataRow = rg.skillDtbl[skill.dri];
        //			bool flag = this.IsEnableEventSkillType(type, skillDataRow);
        //			if (flag && skill.sp >= skillDataRow.maxSp)
        //			{
        //				return i;
        //			}
        //		}
        //	}
        //	return -1;
        //}

        //protected bool IsEnableEventSkillType(EventSkillType type, SkillDataRow dr)
        //{
        //	switch (type)
        //	{
        //	case EventSkillType.OnBattleEnter:
        //		return dr.spCostOnEnter > 0;
        //	case EventSkillType.OnBeHit:
        //		return dr.spCostOnBeHit > 0;
        //	case EventSkillType.OnCombo:
        //		return dr.spCostOnCombo > 0;
        //	case EventSkillType.OnHealthRate:
        //		return dr.remainedHealthRate >= 0;
        //	default:
        //		return false;
        //	}
        //}

        public bool CanUseSkill(Option option)
        {
            return option.canInterfereSkill || !this._hasSkillActionUnit;
        }

        [JsonProperty]
        internal int _randomSeed;

        [JsonProperty]
        internal Input _lhsInput;

        [JsonProperty]
        internal Input _rhsInput;

        [JsonProperty]
        internal List<Unit> _units;

        [JsonProperty]
        internal int _time;

        [JsonProperty]
        internal int _turn;

        [JsonProperty]
        internal int _waveTurn;

        [JsonProperty]
        internal int _lhsWave;

        [JsonIgnore]
        internal bool _lhsOnWave;

        [JsonProperty]
        internal int _rhsWave;

        [JsonIgnore]
        internal bool _rhsOnWave;

        [JsonIgnore]
        internal bool _onTurn;

        [JsonIgnore]
        internal bool _onWaveTurn;

        [JsonProperty]
        internal bool _isLhsTimeLineTurn;

        internal List<int> _lhsTimeLine;

        internal List<int> _rhsTimeLine;

        [JsonProperty]
        internal bool _isWaitingInput;

        [JsonProperty]
        internal bool _isWaitingNextTurn;

        [JsonIgnore]
        internal bool _hasSkillActionUnit;

        [JsonProperty]
        internal bool _isWaitingNextWave;

        [JsonProperty]
        internal int _turnUnitIndex;

        [JsonProperty]
        internal int _lhsTroopStartIndex;

        [JsonProperty]
        internal int _rhsTroopStartIndex;

        [JsonProperty]
        internal int _gold;

        [JsonProperty]
        internal int _armyDestoryCnt;

        [JsonProperty]
        internal int _navyDestoryCnt;

        [JsonProperty]
        internal int _lhsActiveSkillUseCount;

        [JsonProperty]
        internal int _lhsDeadUnitCount;

        [JsonProperty]
        internal long _totalAttackDamage;

        public static readonly int[,] _PriorityTable036 = new int[,]
        {
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 }
        };

        public static readonly int[,] _PriorityTable258 = new int[,]
        {
            { 2, 5, 8 },
            { 1, 4, 7 },
            { 0, 3, 6 }
        };

        public static readonly int[,] _PriorityTable147 = new int[,]
        {
            { 1, 4, 7 },
            { 0, 3, 6 },
            { 2, 5, 8 }
        };

        public static readonly int[,] _PriorityFrontTable036 = new int[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        public static readonly int[,] _PriorityFrontTable258 = new int[,]
        {
            { 2, 1, 0 },
            { 5, 4, 3 },
            { 8, 7, 6 }
        };

        public static readonly int[,] _PriorityFrontTable147 = new int[,]
        {
            { 1, 0, 2 },
            { 4, 3, 5 },
            { 7, 6, 8 }
        };

        public static readonly int[,] _PriorityBackTable036 = new int[,]
        {
            { 6, 7, 8 },
            { 3, 4, 5 },
            { 0, 1, 2 }
        };

        public static readonly int[,] _PriorityBackTable258 = new int[,]
        {
            { 8, 7, 6 },
            { 5, 4, 3 },
            { 2, 1, 0 }
        };

        public static readonly int[,] _PriorityBackTable147 = new int[,]
        {
            { 7, 6, 8 },
            { 4, 3, 5 },
            { 1, 0, 2 }
        };
    }
}
