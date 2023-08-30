namespace StellarGKLibrary.Shared.Battle.Internal
{
    public class _SkillUpdater : FrameAccessor
    {
        //internal _SkillUpdater()
        //{
        //}

        //internal _SkillUpdater(Random random)
        //{
        //	this.SetRandom(random);
        //}

        //public void SetRandom(Random random)
        //{
        //	this._random = random;
        //}

        //public override bool OnFrameAccessStart()
        //{
        //	this._rg = base.simulator.regulation;
        //	base.frame._hasSkillActionUnit = false;
        //	return true;
        //}

        //public override bool OnUnitAccessStart()
        //{
        //	if (!base.frame.IsUnitInBattle(base.unitIndex))
        //	{
        //		return false;
        //	}
        //	base.unit._hasEnabledSkill = false;
        //	base.unit._isPlayingFire = false;
        //	this._subFireFirst = false;
        //	this._subFireSecond = false;
        //	return true;
        //}

        //public override bool OnSkillAccessStart()
        //{
        //	this._subFireFirst = false;
        //	this._subFireSecond = false;
        //	int num = base.skill._sp - base.skill._curSp;
        //	if (num > 0)
        //	{
        //		base.skill._curSp += base.skill._perCurSp;
        //		if (base.skill._curSp > base.skill._sp)
        //		{
        //			base.skill._curSp = base.skill._sp;
        //		}
        //	}
        //	else if (num < 0)
        //	{
        //		base.skill._curSp -= base.skill._perCurSp;
        //		if (base.skill._curSp < base.skill._sp)
        //		{
        //			base.skill._curSp = base.skill._sp;
        //		}
        //	}
        //	if (base.skill._curSp == base.skill._sp)
        //	{
        //		base.skill._activeState = true;
        //		if (base.skillIndex > 0)
        //		{
        //			base.unit._hasEnabledSkill = true;
        //		}
        //	}
        //	if (base.skill._remainedReturnMotionTime > 0)
        //	{
        //		base.frame._isWaitingNextTurn = false;
        //		base.skill._remainedReturnMotionTime -= 66;
        //		base.unit._playingActionIndex = base.skillIndex;
        //	}
        //	if (base.skill.remainedMotionTime > 0)
        //	{
        //		if (base.skill._initMotionTime == base.skill.remainedMotionTime)
        //		{
        //			this._subFireFirst = true;
        //		}
        //		base.frame._isWaitingNextWave = false;
        //		base.frame._isWaitingNextTurn = false;
        //		if (base.unit.isDead)
        //		{
        //			if (!base.skill.isIgnoreDeathType)
        //			{
        //				base.skill._remainedMotionTime = 0;
        //				return false;
        //			}
        //		}
        //		else
        //		{
        //			if (base.unit.isStatusStun)
        //			{
        //				base.skill._remainedMotionTime = 0;
        //				return false;
        //			}
        //			if (base.unit.isStatusSilence && base.skillIndex != 0)
        //			{
        //				base.skill._remainedMotionTime = 0;
        //				return false;
        //			}
        //		}
        //		base.skill._remainedMotionTime -= 66;
        //		base.unit._playingActionIndex = base.skillIndex;
        //		return true;
        //	}
        //	return false;
        //}

        //public bool OnMainFirePointAccessStart()
        //{
        //	int num = base.skill.remainedMotionTime + 66;
        //	for (int i = 0; i < 20; i++)
        //	{
        //		FireEvent fireEvent = base.unitMotionDr.fireEvents[i];
        //		if (fireEvent == null)
        //		{
        //			break;
        //		}
        //		if (fireEvent.firePointTypeIndex == base.firePointIndex)
        //		{
        //			int num2 = base.unitMotionDr.playTime - fireEvent.time;
        //			if (num2 < num)
        //			{
        //				if (num2 < base.skill.remainedMotionTime)
        //				{
        //					if (base.skill.isActiveSkill)
        //					{
        //						base.frame._hasSkillActionUnit = true;
        //					}
        //					if (i == 0)
        //					{
        //						base.unit._isPlayingFire = true;
        //					}
        //				}
        //				else
        //				{
        //					if (i + 1 == base.unitMotionDr.totalFireCount)
        //					{
        //						this._subFireSecond = true;
        //					}
        //					if (base.skill.isActiveSkill)
        //					{
        //						base.frame._hasSkillActionUnit = true;
        //					}
        //					if (i == 0)
        //					{
        //						base.unit._isPlayingFire = true;
        //					}
        //					if (base.skill.targetIndex >= 0)
        //					{
        //						Projectile projectile = this._CreateProjectile(i, base.skill.targetIndex);
        //						this._ApplyFirePattern(projectile, base.skillDr.firePatterns[base.firePointIndex]);
        //						List<Projectile> list = this._CreateSplashes(projectile, base.projectileDr.splashPattern);
        //						this._newProjectiles.Add(projectile);
        //						foreach (Projectile projectile2 in list)
        //						{
        //							this._newProjectiles.Add(projectile2);
        //						}
        //					}
        //				}
        //			}
        //		}
        //	}
        //	return false;
        //}

        //public bool OnSubFirePointAccessStart()
        //{
        //	bool flag = false;
        //	if (this._subFireFirst && base.firePointSubIndex == 1)
        //	{
        //		int num = base.frame.FindSkillTarget(this._rg, base.unitIndex, base.skillIndex, base.firePointSubIndex);
        //		if (num >= 0)
        //		{
        //			Projectile projectile = this._CreateProjectile(0, num);
        //			this._ApplyFirePattern(projectile, base.firePoint.firePattern);
        //			List<Projectile> list = this._CreateSplashes(projectile, base.projectileDr.splashPattern);
        //			this._newProjectiles.Add(projectile);
        //			foreach (Projectile projectile2 in list)
        //			{
        //				this._newProjectiles.Add(projectile2);
        //			}
        //			flag = true;
        //		}
        //	}
        //	if (this._subFireSecond && base.firePointSubIndex == 2)
        //	{
        //		int num2 = base.frame.FindSkillTarget(this._rg, base.unitIndex, base.skillIndex, base.firePointSubIndex);
        //		if (num2 >= 0)
        //		{
        //			Projectile projectile3 = this._CreateProjectile(0, num2);
        //			this._ApplyFirePattern(projectile3, base.firePoint.firePattern);
        //			List<Projectile> list2 = this._CreateSplashes(projectile3, base.projectileDr.splashPattern);
        //			this._newProjectiles.Add(projectile3);
        //			foreach (Projectile projectile4 in list2)
        //			{
        //				this._newProjectiles.Add(projectile4);
        //			}
        //			flag = true;
        //		}
        //	}
        //	return flag;
        //}

        //public override bool OnFirePointAccessStart()
        //{
        //	this._newProjectiles = new List<Projectile>();
        //	if (base.firePointSubIndex != 0)
        //	{
        //		return this.OnSubFirePointAccessStart();
        //	}
        //	return this.OnMainFirePointAccessStart();
        //}

        //public override void OnFirePointAccessEnd()
        //{
        //	if (this._newProjectiles == null || this._newProjectiles.Count == 0)
        //	{
        //		return;
        //	}
        //	base.firePoint._projectiles.AddRange(this._newProjectiles);
        //}

        //private Projectile _CreateProjectile(int fireEventIndex, int targetIndex)
        //{
        //	bool flag = false;
        //	if (base.skillDr.targetJobType != 0)
        //	{
        //		Unit unit = base.frame._units[targetIndex];
        //		UnitDataRow unitDataRow = this._rg.unitDtbl[unit.dri];
        //		flag = !Skill.IsTargetJobType(unitDataRow.job, base.skillDr.targetJobType);
        //	}
        //	if (!flag)
        //	{
        //		if (base.skillDr.coercionAccuracy > 0)
        //		{
        //			flag = base.skillDr.coercionAccuracy < this._random.Next(1, 101);
        //		}
        //		else if (base.skill.isDamageSkill(base.firePointSubIndex))
        //		{
        //			Unit unit2 = base.frame._units[targetIndex];
        //			if (unit2._fixedEvasionRate > 0)
        //			{
        //				flag = unit2._fixedEvasionRate > this._random.Next(0, 100);
        //			}
        //			else
        //			{
        //				int accuracy = base.skill.accuracy;
        //				int accuracyScale = base.projectileDr.accuracyScale;
        //				int num = (unit2.luck + unit2._addLuck) * (100 + unit2.luckBonus) / 100;
        //				if (num < 0)
        //				{
        //					num = 0;
        //				}
        //				int num2 = accuracy + num;
        //				if (num2 <= 0)
        //				{
        //					num2 = 1;
        //				}
        //				int num3 = accuracy * accuracyScale / num2;
        //				flag = num3 < this._random.Next(1, 101);
        //			}
        //		}
        //	}
        //	string motionSetId = base.projectileDr.motionSetId;
        //	DataTable<ProjectileMotionPhaseDataRow> projectileMotionPhaseDtbl = this._rg.projectileMotionPhaseDtbl;
        //	string text = motionSetId + "/FirePhase";
        //	int num4 = projectileMotionPhaseDtbl.FindIndex(text);
        //	if (num4 == -1)
        //	{
        //		throw new ArgumentException("projectileMotionPhaseDtbl Not Found Idx : " + text);
        //	}
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow = projectileMotionPhaseDtbl[num4];
        //	num4 += this._random.Next(0, projectileMotionPhaseDataRow.patternCount) + 1;
        //	string text2 = motionSetId + ((!flag) ? "/HitPhase" : "/MissPhase");
        //	int num5 = projectileMotionPhaseDtbl.FindIndex(text2);
        //	if (num5 == -1)
        //	{
        //		throw new ArgumentException("projectileMotionPhaseDtbl Not Found Idx : " + text2);
        //	}
        //	ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow2 = projectileMotionPhaseDtbl[num5];
        //	num5 += this._random.Next(0, projectileMotionPhaseDataRow2.patternCount) + 1;
        //	string text3 = motionSetId + "/BeHitPhase";
        //	int num6 = projectileMotionPhaseDtbl.FindIndex(text3);
        //	if (num6 >= 0)
        //	{
        //		ProjectileMotionPhaseDataRow projectileMotionPhaseDataRow3 = projectileMotionPhaseDtbl[num6];
        //		num6 += this._random.Next(0, projectileMotionPhaseDataRow3.patternCount) + 1;
        //	}
        //	int num7 = num4 * 100000 + num5;
        //	Projectile projectile = Projectile._Create(num7, targetIndex, fireEventIndex, base.frame.turn);
        //	projectile._beHitId = num6;
        //	projectile._fireKey = projectileMotionPhaseDtbl[num4].key;
        //	projectile._hitKey = projectileMotionPhaseDtbl[num5].key;
        //	projectile._beHitKey = ((num6 < 0) ? string.Empty : projectileMotionPhaseDtbl[num6].key);
        //	int criticalChance = base.skill.criticalChance;
        //	int criticalChanceScale = base.projectileDr.criticalChanceScale;
        //	int num8 = criticalChance * criticalChanceScale / 100;
        //	projectile._isCritical = num8 > this._random.Next(0, 100);
        //	return projectile;
        //}

        //private void _ApplyFirePattern(Projectile projectile, string pattern)
        //{
        //	if (string.IsNullOrEmpty(pattern))
        //	{
        //		return;
        //	}
        //	List<int> list = new List<int>();
        //	int num = projectile.targetIndex;
        //	int num2 = pattern.IndexOf("P");
        //	if (num2 < 0)
        //	{
        //		if (base.frame.IsLhsUnitInBattle(num))
        //		{
        //			num = base.frame._lhsTroopStartIndex + 4;
        //		}
        //		else
        //		{
        //			num = base.frame._rhsTroopStartIndex + 4;
        //		}
        //		num2 = 4;
        //	}
        //	int num3 = num2 % 3;
        //	int num4 = num2 / 3;
        //	int num5 = Math.Min(9, pattern.Length);
        //	for (int i = 0; i < num5; i++)
        //	{
        //		if (pattern[i] == '1')
        //		{
        //			int num6 = i % 3 - num3;
        //			int num7 = i / 3 - num4;
        //			int unitIndexByOffset = base.simulator.GetUnitIndexByOffset(num, num6, num7);
        //			if (unitIndexByOffset >= 0)
        //			{
        //				Unit unit = base.simulator.frame._units[unitIndexByOffset];
        //				if (unit != null && unit.health > 0)
        //				{
        //					list.Add(unitIndexByOffset);
        //				}
        //			}
        //		}
        //	}
        //	if (list.Count > 0)
        //	{
        //		this._random.Shuffle<int>(list);
        //		projectile._targetIndex = list[0];
        //	}
        //}

        //private List<Projectile> _CreateSplashes(Projectile projectile, string pattern)
        //{
        //	if (string.IsNullOrEmpty(pattern))
        //	{
        //		return new List<Projectile>();
        //	}
        //	List<Projectile> list = new List<Projectile>();
        //	int num = projectile.targetIndex;
        //	int num2 = pattern.IndexOf("P");
        //	if (num2 < 0)
        //	{
        //		if (base.frame.IsLhsUnitInBattle(num))
        //		{
        //			num = base.frame._lhsTroopStartIndex + 4;
        //		}
        //		else
        //		{
        //			num = base.frame._rhsTroopStartIndex + 4;
        //		}
        //		num2 = 12;
        //	}
        //	int num3 = num2 % 5;
        //	int num4 = num2 / 5;
        //	int length = pattern.Length;
        //	for (int i = 0; i < length; i++)
        //	{
        //		if (pattern[i] == '1')
        //		{
        //			int num5 = i % 5 - num3;
        //			int num6 = i / 5 - num4;
        //			int unitIndexByOffset = base.simulator.GetUnitIndexByOffset(num, num5, num6);
        //			if (unitIndexByOffset >= 0 && projectile.targetIndex != unitIndexByOffset)
        //			{
        //				Unit unit = base.simulator.frame._units[unitIndexByOffset];
        //				if (unit != null && unit.health > 0)
        //				{
        //					Projectile projectile2 = this._CreateProjectile(projectile.fireEventIndex, unitIndexByOffset);
        //					projectile2._isSplash = true;
        //					projectile2._targetIndex = unitIndexByOffset;
        //					list.Add(projectile2);
        //				}
        //			}
        //		}
        //	}
        //	return list;
        //}

        //private Random _random;

        //private List<Projectile> _newProjectiles;

        //private bool _subFireFirst;

        //private bool _subFireSecond;

        //private Regulation _rg;
    }
}
