using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation.DataRows;
using Newtonsoft.Json;

namespace CommanderCS.Library.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Frame
    {
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

        public static readonly int[,] _PriorityTable036 = new int[3, 3]
        {
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 }
        };

        public static readonly int[,] _PriorityTable258 = new int[3, 3]
        {
            { 2, 5, 8 },
            { 1, 4, 7 },
            { 0, 3, 6 }
        };

        public static readonly int[,] _PriorityTable147 = new int[3, 3]
        {
            { 1, 4, 7 },
            { 0, 3, 6 },
            { 2, 5, 8 }
        };

        public static readonly int[,] _PriorityFrontTable036 = new int[3, 3]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        public static readonly int[,] _PriorityFrontTable258 = new int[3, 3]
        {
            { 2, 1, 0 },
            { 5, 4, 3 },
            { 8, 7, 6 }
        };

        public static readonly int[,] _PriorityFrontTable147 = new int[3, 3]
        {
            { 1, 0, 2 },
            { 4, 3, 5 },
            { 7, 6, 8 }
        };

        public static readonly int[,] _PriorityBackTable036 = new int[3, 3]
        {
            { 6, 7, 8 },
            { 3, 4, 5 },
            { 0, 1, 2 }
        };

        public static readonly int[,] _PriorityBackTable258 = new int[3, 3]
        {
            { 8, 7, 6 },
            { 5, 4, 3 },
            { 2, 1, 0 }
        };

        public static readonly int[,] _PriorityBackTable147 = new int[3, 3]
        {
            { 7, 6, 8 },
            { 4, 3, 5 },
            { 1, 0, 2 }
        };

        public int randomSeed => _randomSeed;

        public Input lhsInput => _lhsInput;

        public Input rhsInput => _rhsInput;

        public IList<Unit> units => _units.AsReadOnly();

        public int time => _time;

        public int turn => _turn;

        public IList<int> lhsTimeLine => _lhsTimeLine.AsReadOnly();

        public IList<int> rhsTimeLine => _rhsTimeLine.AsReadOnly();

        public bool isWaitingInput => _isWaitingInput;

        public int turnUnitIndex => _turnUnitIndex;

        public int lhsTroopStartIndex => _lhsTroopStartIndex;

        public int rhsTroopStartIndex => _rhsTroopStartIndex;

        public int gold => _gold;

        public int armyDestoryCnt => _armyDestoryCnt;

        public int navyDestoryCnt => _navyDestoryCnt;

        public long totalAttackDamage => _totalAttackDamage;

        public bool onTurn => _onTurn;

        public bool lhsOnWave => _lhsOnWave;

        public bool rhsOnWave => _rhsOnWave;

        public bool onWaveTurn => _onWaveTurn;

        public bool isWaitingLhsInput => _isWaitingInput && IsLhsUnitInBattle(_turnUnitIndex);

        public bool isWaitingRhsInput => _isWaitingInput && IsRhsUnitInBattle(_turnUnitIndex);

        internal Frame()
        {
        }

        public static bool IsSame(Frame f1, Frame f2)
        {
            if (f1 == f2)
            {
                return true;
            }
            if (f1._randomSeed != f2.randomSeed)
            {
                return false;
            }
            if (f1._isWaitingInput != f2.isWaitingInput)
            {
                return false;
            }
            if (f1._isWaitingNextTurn != f2._isWaitingNextTurn)
            {
                return false;
            }
            if (f1._turnUnitIndex != f2._turnUnitIndex)
            {
                return false;
            }
            if (f1._lhsTroopStartIndex != f2._lhsTroopStartIndex)
            {
                return false;
            }
            if (f1._rhsTroopStartIndex != f2._rhsTroopStartIndex)
            {
                return false;
            }
            if (f1._time != f2._time)
            {
                return false;
            }
            if (f1._turn != f2._turn)
            {
                return false;
            }
            if (!Input.IsSame(f1._lhsInput, f2._lhsInput))
            {
                return false;
            }
            if (f1._rhsInput != f2._rhsInput)
            {
                return false;
            }
            if (f1._units.Count != f2._units.Count)
            {
                return false;
            }
            return true;
        }

        public bool IsUnitInBattle(int unitIndex)
        {
            return IsLhsUnitInBattle(unitIndex) || IsRhsUnitInBattle(unitIndex);
        }

        public bool IsLhsUnit(int unitIndex)
        {
            for (int num = _lhsTroopStartIndex; num >= 0; num -= 9)
            {
                int num2 = num + 9;
                if (unitIndex >= num && unitIndex < num2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRhsUnit(int unitIndex)
        {
            int i = _rhsTroopStartIndex;
            for (int count = units.Count; i >= count; i += 9)
            {
                int num = i + 9;
                if (unitIndex >= i && unitIndex < num)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsLhsUnitInBattle(int unitIndex)
        {
            int num = _lhsTroopStartIndex;
            int num2 = num + 9;
            return unitIndex >= num && unitIndex < num2;
        }

        public bool IsRhsUnitInBattle(int unitIndex)
        {
            int num = _rhsTroopStartIndex;
            int num2 = num + 9;
            return unitIndex >= num && unitIndex < num2;
        }

        public int FindSkillTarget(Regulation.Regulation rg, int unitIndex, int skillIndex, int subIndex = 0)
        {
            Unit unit = _units[unitIndex];
            Skill skill = unit?.skills[skillIndex];
            if (skill is null)
            {
                return -1;
            }
            SkillDataRow skillDataRow = skill.SkillDataRow;
            int num = 0;
            switch (skillDataRow.targetTypes[subIndex])
            {
                case ESkillTargetType.Own:
                    if (skillDataRow.conditionTypes[subIndex] == ESkillConditionType.None)
                    {
                        return unitIndex;
                    }
                    if (IsTargetStatusCondition(unit, skillDataRow.targetStatusConditions[subIndex], skillDataRow.conditionValues[subIndex]))
                    {
                        return unitIndex;
                    }
                    return -1;

                case ESkillTargetType.Friend:
                    num = unit.side != 0 ? _rhsTroopStartIndex : _lhsTroopStartIndex;
                    break;

                case ESkillTargetType.Enemy:
                    num = unit.side != 0 ? _lhsTroopStartIndex : _rhsTroopStartIndex;
                    break;
            }
            int[,] array = null;
            switch (unitIndex % 9)
            {
                case 0:
                case 3:
                case 6:
                    array = skillDataRow.targetPatterns[subIndex] switch
                    {
                        ESkillTargetPattern.Normal => _PriorityTable036,
                        ESkillTargetPattern.sequence => _PriorityFrontTable036,
                        ESkillTargetPattern.Front => _PriorityFrontTable036,
                        ESkillTargetPattern.Back => _PriorityBackTable036,
                        ESkillTargetPattern.Random => GetRandomPriorityTable(),
                        _ => _PriorityTable036,
                    };
                    break;

                case 1:
                case 4:
                case 7:
                    array = skillDataRow.targetPatterns[subIndex] switch
                    {
                        ESkillTargetPattern.Normal => _PriorityTable147,
                        ESkillTargetPattern.sequence => _PriorityFrontTable036,
                        ESkillTargetPattern.Front => _PriorityFrontTable147,
                        ESkillTargetPattern.Back => _PriorityBackTable147,
                        ESkillTargetPattern.Random => GetRandomPriorityTable(),
                        _ => _PriorityTable147,
                    };
                    break;

                case 2:
                case 5:
                case 8:
                    array = skillDataRow.targetPatterns[subIndex] switch
                    {
                        ESkillTargetPattern.Normal => _PriorityTable258,
                        ESkillTargetPattern.sequence => _PriorityFrontTable036,
                        ESkillTargetPattern.Front => _PriorityFrontTable258,
                        ESkillTargetPattern.Back => _PriorityBackTable258,
                        ESkillTargetPattern.Random => GetRandomPriorityTable(),
                        _ => _PriorityTable258,
                    };
                    break;
            }
            bool flag = false;
            bool flag2 = false;
            Unit unit2 = null;
            Unit unit3 = null;
            Unit unit4 = null;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (flag)
                {
                    break;
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int num2 = array[i, j];
                    int num3 = num + num2;
                    if (num3 < 0 || num3 >= _units.Count)
                    {
                        continue;
                    }
                    unit4 = _units[num3];
                    if (unit4 is null || unit4.health <= 0)
                    {
                        continue;
                    }
                    if (unit2 is null)
                    {
                        unit2 = unit4;
                    }
                    if (unit4.attackPoint && skill.isDamageSkill(subIndex))
                    {
                        unit3 = unit4;
                        flag = true;
                        break;
                    }
                    if (flag2 || !IsTargetStatusCondition(unit4, skillDataRow.targetStatusConditions[subIndex], skillDataRow.conditionValues[subIndex]))
                    {
                        continue;
                    }
                    flag2 = true;
                    bool flag3 = true;
                    bool flag4 = true;
                    if (skillDataRow.targetJobConditions[subIndex] != 0)
                    {
                        flag2 = false;
                        if (unit3 is not null)
                        {
                            int num4 = JobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit3, unit4);
                            if (num4 > 0)
                            {
                                flag4 = false;
                                if (IsHighJobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit4) && skillDataRow.targetStatisticConditions[subIndex] == ESkillTargetStatisticCondition.None)
                                {
                                    flag2 = true;
                                }
                            }
                            else if (num4 == 0)
                            {
                                flag4 = true;
                                flag3 = false;
                            }
                            else
                            {
                                flag3 = false;
                                flag4 = false;
                            }
                        }
                        else
                        {
                            flag4 = false;
                            if (IsHighJobCondition(rg, skillDataRow.targetJobConditions[subIndex], unit4) && skillDataRow.targetStatisticConditions[subIndex] == ESkillTargetStatisticCondition.None)
                            {
                                flag2 = true;
                            }
                        }
                    }
                    if (flag4 && skillDataRow.targetStatisticConditions[subIndex] != 0)
                    {
                        flag2 = false;
                        if (unit3 is not null)
                        {
                            flag3 = false;
                            if (StatisticCondition(rg, skillDataRow.targetStatisticConditions[subIndex], unit3, unit4))
                            {
                                flag3 = true;
                            }
                        }
                    }
                    if (flag3)
                    {
                        unit3 = unit4;
                    }
                    if (flag2 && !skill.isDamageSkill(subIndex))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            Unit unit5 = null;
            if (unit3 is not null)
            {
                unit5 = unit3;
            }
            else if (skillDataRow.conditionTypes[subIndex] == ESkillConditionType.None && unit2 is not null)
            {
                unit5 = unit2;
            }
            return unit5?._unitIdx ?? -1;
        }

        public bool StatisticCondition(Regulation.Regulation rg, ESkillTargetStatisticCondition statisticCondition, Unit srcUnit, Unit targetUnit)
        {
            switch (statisticCondition)
            {
                case ESkillTargetStatisticCondition.None:
                    return true;

                case ESkillTargetStatisticCondition.Minimum_HpRate:
                    {
                        float num19 = srcUnit.health / (float)srcUnit.maxHealth;
                        float num20 = targetUnit.health / (float)targetUnit.maxHealth;
                        return num20 < num19;
                    }
                case ESkillTargetStatisticCondition.Maximum_HpRate:
                    {
                        float num17 = srcUnit.health / (float)srcUnit.maxHealth;
                        float num18 = targetUnit.health / (float)targetUnit.maxHealth;
                        return num18 > num17;
                    }
                case ESkillTargetStatisticCondition.Minimum_Hp:
                    return targetUnit.health < srcUnit.health;

                case ESkillTargetStatisticCondition.Maximum_Hp:
                    return targetUnit.health > srcUnit.health;

                case ESkillTargetStatisticCondition.Minimum_Atk:
                    {
                        UnitDataRow unitDataRow21 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow22 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addAtk + unitDataRow22.attackDamage < srcUnit._addAtk + unitDataRow21.attackDamage;
                    }
                case ESkillTargetStatisticCondition.Maximum_Atk:
                    {
                        UnitDataRow unitDataRow19 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow20 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addAtk + unitDataRow20.attackDamage > srcUnit._addAtk + unitDataRow19.attackDamage;
                    }
                case ESkillTargetStatisticCondition.Minimum_Aim:
                    {
                        UnitDataRow unitDataRow17 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow18 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addAim + unitDataRow18.accuracy < srcUnit._addAim + unitDataRow17.accuracy;
                    }
                case ESkillTargetStatisticCondition.Maximum_Aim:
                    {
                        UnitDataRow unitDataRow27 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow28 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addAim + unitDataRow28.accuracy > srcUnit._addAim + unitDataRow27.accuracy;
                    }
                case ESkillTargetStatisticCondition.Minimum_Luk:
                    {
                        UnitDataRow unitDataRow25 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow26 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addLuck + unitDataRow26.luck < srcUnit._addLuck + unitDataRow25.luck;
                    }
                case ESkillTargetStatisticCondition.Maximum_Luk:
                    {
                        UnitDataRow unitDataRow23 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow24 = rg.unitDtbl[targetUnit.dri];
                        return targetUnit._addLuck + unitDataRow24.luck > srcUnit._addLuck + unitDataRow23.luck;
                    }
                case ESkillTargetStatisticCondition.Minimum_Active_Sp:
                    if (!targetUnit.hasActiveSkill)
                    {
                        return false;
                    }
                    if (!srcUnit.hasActiveSkill)
                    {
                        return true;
                    }
                    return targetUnit.skills[targetUnit._activeSkillIdx].sp < srcUnit.skills[srcUnit._activeSkillIdx].sp;

                case ESkillTargetStatisticCondition.Maximum_Active_Sp:
                    if (!targetUnit.hasActiveSkill)
                    {
                        return false;
                    }
                    if (!srcUnit.hasActiveSkill)
                    {
                        return true;
                    }
                    return targetUnit.skills[targetUnit._activeSkillIdx].sp > srcUnit.skills[srcUnit._activeSkillIdx].sp;

                case ESkillTargetStatisticCondition.Minimum_Atk_With_Buff:
                    {
                        UnitDataRow unitDataRow15 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow16 = rg.unitDtbl[targetUnit.dri];
                        int num15 = (unitDataRow15.attackDamage + srcUnit._addAtk) * (100 + srcUnit.attackDamageBonus) / 100;
                        int num16 = (unitDataRow16.attackDamage + targetUnit._addAtk) * (100 + targetUnit.attackDamageBonus) / 100;
                        return num16 < num15;
                    }
                case ESkillTargetStatisticCondition.Maximum_Atk_With_Buff:
                    {
                        UnitDataRow unitDataRow13 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow14 = rg.unitDtbl[targetUnit.dri];
                        int num13 = (unitDataRow13.attackDamage + srcUnit._addAtk) * (100 + srcUnit.attackDamageBonus) / 100;
                        int num14 = (unitDataRow14.attackDamage + targetUnit._addAtk) * (100 + targetUnit.attackDamageBonus) / 100;
                        return num14 > num13;
                    }
                case ESkillTargetStatisticCondition.Minimum_Aim_With_Buff:
                    {
                        UnitDataRow unitDataRow11 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow12 = rg.unitDtbl[targetUnit.dri];
                        int num11 = (unitDataRow11.accuracy + srcUnit._addAim) * (100 + srcUnit.accuracyBonus) / 100;
                        int num12 = (unitDataRow12.accuracy + targetUnit._addAim) * (100 + targetUnit.accuracyBonus) / 100;
                        return num12 < num11;
                    }
                case ESkillTargetStatisticCondition.Maximum_Aim_With_Buff:
                    {
                        UnitDataRow unitDataRow9 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow10 = rg.unitDtbl[targetUnit.dri];
                        int num9 = (unitDataRow9.accuracy + srcUnit._addAim) * (100 + srcUnit.accuracyBonus) / 100;
                        int num10 = (unitDataRow10.accuracy + targetUnit._addAim) * (100 + targetUnit.accuracyBonus) / 100;
                        return num10 > num9;
                    }
                case ESkillTargetStatisticCondition.Minimum_Luk_With_Buff:
                    {
                        UnitDataRow unitDataRow7 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow8 = rg.unitDtbl[targetUnit.dri];
                        int num7 = (unitDataRow7.luck + srcUnit._addLuck) * (100 + srcUnit.luckBonus) / 100;
                        int num8 = (unitDataRow8.luck + targetUnit._addLuck) * (100 + targetUnit.luckBonus) / 100;
                        return num8 < num7;
                    }
                case ESkillTargetStatisticCondition.Maximum_Luk_With_Buff:
                    {
                        UnitDataRow unitDataRow5 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow6 = rg.unitDtbl[targetUnit.dri];
                        int num5 = (unitDataRow5.luck + srcUnit._addLuck) * (100 + srcUnit.luckBonus) / 100;
                        int num6 = (unitDataRow6.luck + targetUnit._addLuck) * (100 + targetUnit.luckBonus) / 100;
                        return num6 > num5;
                    }
                case ESkillTargetStatisticCondition.Minimum_Def_With_Buff:
                    {
                        UnitDataRow unitDataRow3 = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow4 = rg.unitDtbl[targetUnit.dri];
                        int num3 = (unitDataRow3.defense + srcUnit._addDef) * (100 + srcUnit.defenseBonus) / 100;
                        int num4 = (unitDataRow4.defense + targetUnit._addDef) * (100 + targetUnit.defenseBonus) / 100;
                        return num4 < num3;
                    }
                case ESkillTargetStatisticCondition.Maximum_Def_With_Buff:
                    {
                        UnitDataRow unitDataRow = rg.unitDtbl[srcUnit.dri];
                        UnitDataRow unitDataRow2 = rg.unitDtbl[targetUnit.dri];
                        int num = (unitDataRow.defense + srcUnit._addDef) * (100 + srcUnit.defenseBonus) / 100;
                        int num2 = (unitDataRow2.defense + targetUnit._addDef) * (100 + targetUnit.defenseBonus) / 100;
                        return num2 > num;
                    }
                default:
                    return false;
            }
        }

        protected bool IsHighJobCondition(Regulation.Regulation rg, ESkillTargetJobCondition jobCondition, Unit targetUnit)
        {
            UnitDataRow unitDataRow = rg.unitDtbl[targetUnit.dri];
            switch (jobCondition)
            {
                case ESkillTargetJobCondition.None:
                    return true;

                case ESkillTargetJobCondition.Defender_Supporter_Attacker:
                case ESkillTargetJobCondition.Defender_Attacker_Supporter:
                    return unitDataRow.job == EJob.Defense;

                case ESkillTargetJobCondition.Supporter_Attacker_Defender:
                case ESkillTargetJobCondition.Supporter_Defender_Attacker:
                    return unitDataRow.job == EJob.Support;

                case ESkillTargetJobCondition.Attacker_Defender_Supporter:
                case ESkillTargetJobCondition.Attacker_Supporter_Defender:
                    return unitDataRow.job == EJob.Attack;

                default:
                    return false;
            }
        }

        protected int JobCondition(Regulation.Regulation rg, ESkillTargetJobCondition jobCondition, Unit srcUnit, Unit targetUnit)
        {
            UnitDataRow unitDataRow = rg.unitDtbl[srcUnit.dri];
            UnitDataRow unitDataRow2 = rg.unitDtbl[targetUnit.dri];
            if (unitDataRow.job == unitDataRow2.job)
            {
                return 0;
            }
            switch (jobCondition)
            {
                case ESkillTargetJobCondition.None:
                    return -1;

                case ESkillTargetJobCondition.Defender_Supporter_Attacker:
                    if (unitDataRow2.job == EJob.Defense)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Support && unitDataRow.job != EJob.Defense)
                    {
                        return 1;
                    }
                    return -1;

                case ESkillTargetJobCondition.Defender_Attacker_Supporter:
                    if (unitDataRow2.job == EJob.Defense)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Attack && unitDataRow.job != EJob.Defense)
                    {
                        return 1;
                    }
                    return -1;

                case ESkillTargetJobCondition.Supporter_Attacker_Defender:
                    if (unitDataRow2.job == EJob.Support)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Attack && unitDataRow.job != EJob.Support)
                    {
                        return 1;
                    }
                    return -1;

                case ESkillTargetJobCondition.Supporter_Defender_Attacker:
                    if (unitDataRow2.job == EJob.Support)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Defense && unitDataRow.job != EJob.Support)
                    {
                        return 1;
                    }
                    return -1;

                case ESkillTargetJobCondition.Attacker_Defender_Supporter:
                    if (unitDataRow2.job == EJob.Attack)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Defense && unitDataRow.job != EJob.Attack)
                    {
                        return 1;
                    }
                    return -1;

                case ESkillTargetJobCondition.Attacker_Supporter_Defender:
                    if (unitDataRow2.job == EJob.Attack)
                    {
                        return 1;
                    }
                    if (unitDataRow2.job == EJob.Support && unitDataRow.job != EJob.Attack)
                    {
                        return 1;
                    }
                    return -1;

                default:
                    return -1;
            }
        }

        public bool IsTargetStatusCondition(Unit targetUnit, ESkillTargetStatusCondition condition, int conditionVal = 0)
        {
            switch (condition)
            {
                case ESkillTargetStatusCondition.None:
                    return true;

                case ESkillTargetStatusCondition.StatusUnbeatable:
                    return targetUnit.unbeatableVal > 0;

                case ESkillTargetStatusCondition.StatusSilence:
                    return targetUnit.silenceVal > 0;

                case ESkillTargetStatusCondition.StatusStun:
                    return targetUnit.stun > 0;

                case ESkillTargetStatusCondition.StatusAggro:
                    return targetUnit.aggro > 0;

                case ESkillTargetStatusCondition.StatusShield:
                    return targetUnit.shiled > 0;

                case ESkillTargetStatusCondition.StatusBuff:
                    return targetUnit.maxHealthBonus > 0 || targetUnit.speedBonus > 0 || targetUnit.accuracyBonus > 0 || targetUnit.luckBonus > 0 || targetUnit.attackDamageBonus > 0 || targetUnit.defenseBonus > 0 || targetUnit.criticalChanceBonus > 0 || targetUnit.criticalDamageBonus > 0;

                case ESkillTargetStatusCondition.StatusMinHpRate:
                    {
                        int num2 = (int)(targetUnit.health * 100L / targetUnit.maxHealth);
                        return num2 <= conditionVal;
                    }
                case ESkillTargetStatusCondition.StatusMaxHpRate:
                    {
                        int num = (int)(targetUnit.health * 100L / targetUnit.maxHealth);
                        return num >= conditionVal;
                    }
                case ESkillTargetStatusCondition.StatusDotDamage:
                    return targetUnit.dotDamangeVal > 0;

                default:
                    return false;
            }
        }

        public List<int> FindSkillTargetCandidates(Regulation.Regulation rg, int unitIndex, int skillIndex)
        {
            Skill skill = _units[unitIndex]?._skills[skillIndex];
            if (skill is null)
            {
                return new List<int>();
            }
            SkillDataRow skillDataRow = rg.skillDtbl[skill.dri];
            return skillDataRow.targetType switch
            {
                ESkillTargetType.Friend => FindFriendTargetCandidates(unitIndex),
                ESkillTargetType.Enemy => FindEnemyTargetCandidates(unitIndex, shouldIgnoreBlocking: true),
                _ => FindEnemyTargetCandidates(unitIndex),
            };
        }

        public List<int> FindFriendTargetCandidates(int unitIndex)
        {
            int targetTroopStartIndex = _rhsTroopStartIndex;
            if (!IsRhsUnitInBattle(unitIndex))
            {
                targetTroopStartIndex = _lhsTroopStartIndex;
            }
            return _FindTargetCandidates(unitIndex, targetTroopStartIndex, shouldIgnoreBlocking: true);
        }

        public List<int> FindEnemyTargetCandidates(int unitIndex, bool shouldIgnoreBlocking = false)
        {
            int targetTroopStartIndex = _rhsTroopStartIndex;
            if (IsRhsUnitInBattle(unitIndex))
            {
                targetTroopStartIndex = _lhsTroopStartIndex;
            }
            return _FindTargetCandidates(unitIndex, targetTroopStartIndex, shouldIgnoreBlocking: true);
        }

        private int[,] GetRandomPriorityTable()
        {
            Random random = new(_randomSeed);
            return random.Next(0, 9) switch
            {
                0 => _PriorityTable036,
                1 => _PriorityTable258,
                2 => _PriorityTable147,
                3 => _PriorityFrontTable036,
                4 => _PriorityFrontTable258,
                5 => _PriorityFrontTable147,
                6 => _PriorityBackTable036,
                7 => _PriorityBackTable258,
                8 => _PriorityBackTable147,
                _ => _PriorityTable036,
            };
        }

        private List<int> _FindTargetCandidates(int unitIndex, int targetTroopStartIndex, bool shouldIgnoreBlocking)
        {
            int num = unitIndex % 9;
            List<int> list = [];
            int[,] array = _PriorityTable147;
            switch (num)
            {
                case 0:
                case 3:
                case 6:
                    array = _PriorityTable036;
                    break;

                case 2:
                case 5:
                case 8:
                    array = _PriorityTable258;
                    break;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int num2 = array[i, j];
                    int num3 = targetTroopStartIndex + num2;
                    if (num3 < 0 || num3 >= _units.Count)
                    {
                        continue;
                    }
                    Unit unit = _units[num3];
                    if (unit is not null && unit.health > 0)
                    {
                        list.Add(num3);
                        if (!shouldIgnoreBlocking)
                        {
                            break;
                        }
                    }
                }
            }
            return list;
        }

        public int FindActivatableEventSkill(Regulation.Regulation rg, EventSkillType type, int unitIndex)
        {
            Unit unit = _units[unitIndex];
            if (unit is null)
            {
                return -1;
            }
            for (int i = 0; i < unit._skills.Count; i++)
            {
                Skill skill = unit._skills[i];
                if (skill is not null && skill.remainedMotionTime <= 0)
                {
                    SkillDataRow skillDataRow = rg.skillDtbl[skill.dri];
                    if (IsEnableEventSkillType(type, skillDataRow) && skill.sp >= skillDataRow.maxSp)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        protected bool IsEnableEventSkillType(EventSkillType type, SkillDataRow dr)
        {
            return type switch
            {
                EventSkillType.OnBattleEnter => dr.spCostOnEnter > 0,
                EventSkillType.OnBeHit => dr.spCostOnBeHit > 0,
                EventSkillType.OnCombo => dr.spCostOnCombo > 0,
                EventSkillType.OnHealthRate => dr.remainedHealthRate >= 0,
                _ => false,
            };
        }

        public bool CanUseSkill(Option option)
        {
            if (!option.canInterfereSkill && _hasSkillActionUnit)
            {
                return false;
            }
            return true;
        }
    }
}