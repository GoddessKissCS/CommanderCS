using System.Collections.Generic;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;

namespace CommanderCSLibrary.Shared.Battle.Internal;

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
		base.frame._onTurn = false;
		base.frame._onWaveTurn = false;
		if (base.frame._isWaitingNextTurn)
		{
			if (base.frame._isWaitingInput)
			{
				Unit unit = base.frame.units[base.frame.turnUnitIndex];
				if (!unit.isDead && !unit.isStatusStun)
				{
					return false;
				}
			}
			if (!base.simulator.isEnded && (base.frame._lhsTimeLine == null || base.frame._lhsTimeLine.Count == 0) && (base.frame._rhsTimeLine == null || base.frame._rhsTimeLine.Count == 0))
			{
				if (base.frame._lhsTimeLine.Count == 0 && base.frame._rhsTimeLine.Count == 0)
				{
					int waveTurn = base.frame._waveTurn;
					base.frame._waveTurn++;
					base.frame._onWaveTurn = true;
				}
				base.frame._lhsTimeLine = new List<int>();
				base.frame._rhsTimeLine = new List<int>();
				int lhsTroopIndex = base.simulator.GetLhsTroopIndex(base.frame.lhsTroopStartIndex);
				int rhsTroopIndex = base.simulator.GetRhsTroopIndex(base.frame.rhsTroopStartIndex);
				if (lhsTroopIndex < 0 || rhsTroopIndex < 0)
				{
					base.frame._isLhsTimeLineTurn = false;
				}
				else if (base.simulator.lhsTroops[lhsTroopIndex]._speed >= base.simulator.rhsTroops[rhsTroopIndex]._speed)
				{
					base.frame._isLhsTimeLineTurn = true;
				}
				for (int i = 0; i < 9; i++)
				{
					if (base.frame.lhsTroopStartIndex >= 0)
					{
						int num = base.frame.lhsTroopStartIndex + i;
						Unit unit2 = base.frame.units[num];
						if (unit2 != null && !unit2.isDead)
						{
							base.frame._lhsTimeLine.Add(num);
						}
					}
					int num2 = base.frame.rhsTroopStartIndex + i;
					if (num2 >= base.frame.units.Count || !base.frame.IsUnitInBattle(num2))
					{
						continue;
					}
					Unit unit3 = base.frame.units[num2];
					if (unit3 == null)
					{
						continue;
					}
					if (base.simulator.initState.battleType == EBattleType.Raid && unit3._charType == ECharacterType.RaidPart)
					{
						string key = $"{base.simulator.initState.raidData.raidId}_{base.frame._waveTurn}_{unit3._unitIdx % 9}";
						int num3 = base.simulator.regulation.raidDtbl.FindIndex(key);
						if (num3 >= 0)
						{
							RaidDataRow raidDataRow = base.simulator.regulation.raidDtbl[num3];
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
								base.frame._rhsTimeLine.Add(num2);
							}
						}
						else
						{
							base.frame._rhsTimeLine.Add(num2);
						}
					}
					else if (!unit3.isDead)
					{
						base.frame._rhsTimeLine.Add(num2);
					}
				}
			}
			Unit unit4 = null;
			List<int> list = new List<int>();
			foreach (int item in base.frame._lhsTimeLine)
			{
				if (base.frame.IsUnitInBattle(item))
				{
					unit4 = base.frame._units[item];
					if (unit4 != null && unit4.health > 0)
					{
						list.Add(item);
					}
				}
			}
			base.frame._lhsTimeLine = list;
			list = new List<int>();
			foreach (int item2 in base.frame._rhsTimeLine)
			{
				if (base.frame.IsUnitInBattle(item2))
				{
					unit4 = base.frame._units[item2];
					if (unit4 != null && unit4.health > 0)
					{
						list.Add(item2);
					}
				}
			}
			base.frame._rhsTimeLine = list;
			if (base.frame._isLhsTimeLineTurn)
			{
				if (base.frame._lhsTimeLine.Count == 0 && base.frame._rhsTimeLine.Count > 0)
				{
					base.frame._isLhsTimeLineTurn = false;
				}
			}
			else if (base.frame._rhsTimeLine.Count == 0 && base.frame._lhsTimeLine.Count > 0)
			{
				base.frame._isLhsTimeLineTurn = true;
			}
			if (base.frame._isLhsTimeLineTurn)
			{
				int num4;
				Unit unit5;
				do
				{
					if (base.frame._lhsTimeLine.Count == 0)
					{
						return false;
					}
					num4 = base.frame._lhsTimeLine[0];
					base.frame._lhsTimeLine.RemoveAt(0);
					unit5 = base.frame._units[num4];
				}
				while (unit5 == null || unit5.health <= 0);
				base.frame._turnUnitIndex = num4;
			}
			else
			{
				int num5;
				Unit unit6;
				do
				{
					if (base.frame._rhsTimeLine.Count == 0)
					{
						return false;
					}
					num5 = base.frame._rhsTimeLine[0];
					base.frame._rhsTimeLine.RemoveAt(0);
					unit6 = base.frame._units[num5];
				}
				while (unit6 == null || unit6.health <= 0);
				base.frame._turnUnitIndex = num5;
			}
			base.frame._isLhsTimeLineTurn = !base.frame._isLhsTimeLineTurn;
			base.frame._isWaitingInput = true;
			base.frame._turn++;
			base.frame._onTurn = true;
			unit4 = base.frame._units[base.frame._turnUnitIndex];
			unit4._isTurn = true;
			unit4._turn++;
			Skill skill = unit4._skills[0];
			if (skill != null)
			{
				SkillDataRow skillDataRow = base.simulator.regulation.skillDtbl[skill.dri];
				skill._sp = skillDataRow.maxSp;
				skill._curSp = skill._sp;
				skill._activeState = true;
			}
		}
		return true;
	}

	public override bool OnUnitAccessStart()
	{
		if (!base.frame.IsUnitInBattle(base.unitIndex))
		{
			return false;
		}
		if (base.frame.onTurn)
		{
			if (base.simulator.initState.battleType == EBattleType.Raid)
			{
				string text = string.Empty;
				if (base.unit._charType == ECharacterType.Raid || base.unit._charType == ECharacterType.RaidPart)
				{
					if (!base.unit.isDead)
					{
						if (base.frame.turnUnitIndex == base.unitIndex)
						{
							text = $"{base.simulator.initState.raidData.raidId}_{base.frame._waveTurn}_{base.unit._unitIdx % 9}";
						}
					}
					else if (base.frame.onWaveTurn)
					{
						text = $"{base.simulator.initState.raidData.raidId}_{base.frame._waveTurn}_{base.unit._unitIdx % 9}";
					}
				}
				if (!string.IsNullOrEmpty(text) && base.simulator.regulation.raidDtbl.ContainsKey(text))
				{
					RaidDataRow raidDataRow = base.simulator.regulation.raidDtbl[text];
					base.unit._attackDamageBonus += raidDataRow.attackIncrease;
					base.unit._defenseBonus += raidDataRow.defenseIncrease;
					base.unit._accuracyBonus += raidDataRow.accuracyIncrease;
					base.unit._luckBonus += raidDataRow.luckIncrease;
					base.unit._criticalChanceBonus += raidDataRow.criticalIncrease;
					base.unit._criticalDamageBonus += raidDataRow.criticalDmgIncrease;
					base.unit._speedBonus += raidDataRow.speedIncrease;
				}
			}
			if (base.unit.criticalHitCount > 0)
			{
				for (int i = 1; i < base.unit.skills.Count; i++)
				{
					Skill skill = base.unit.skills[i];
					if (skill != null)
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
				base.unit._hitCount = 0;
				base.unit._criticalHitCount = 0;
			}
			else if (base.unit.hitCount > 0)
			{
				for (int j = 1; j < base.unit.skills.Count; j++)
				{
					Skill skill2 = base.unit.skills[j];
					if (skill2 != null)
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
				base.unit._hitCount = 0;
				base.unit._criticalHitCount = 0;
			}
			if (base.unit.beHitCount > 0)
			{
				for (int k = 1; k < base.unit.skills.Count; k++)
				{
					Skill skill3 = base.unit.skills[k];
					if (skill3 != null)
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
				base.unit._beHitCount = 0;
			}
			base.unit._takenProjectilesOnTurn.Clear();
		}
		UpdateUnitStatus();
		return false;
	}

	protected void UpdateUnitStatus()
	{
		if (!base.unit.isDead)
		{
			Dictionary<int, Status>.Enumerator statusItr = base.unit.StatusItr;
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
		status._elapsedTurn = base.unit._turn - status._createdTurn;
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
				Unit unit = base.frame.units[status._ownerUnitIdx];
				UnitDataRow unitDataRow = base.simulator.regulation.unitDtbl[status._ownerUnitIdx];
				if (unitDataRow.typeDown == base.unitDr.type)
				{
					num = num * unitDataRow.typeHandicap / 100;
				}
				if (unitDataRow.typeUpper == base.unitDr.type)
				{
					num = num * unitDataRow.typeBonus / 100;
				}
				int num2 = (base.unit.defense + base.unit._addDef) * (100 + base.unit.defenseBonus) / 100;
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
				base.unit._takenDamage += num;
				unit._statsAttack += num;
			}
			if (status._dotHealing > 0)
			{
				Unit unit2 = base.frame.units[status._ownerUnitIdx];
				int dotHealing = status._dotHealing;
				base.unit._takenHealing += dotHealing;
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
			int num2 = base.frame._units[timeLine[i]].speed * (100 + base.frame._units[timeLine[i]].speedBonus) / 100;
			while (num >= 0)
			{
				int num3 = base.frame._units[timeLine[num]].speed * (100 + base.frame._units[timeLine[num]].speedBonus) / 100;
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
