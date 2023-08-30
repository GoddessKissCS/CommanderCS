namespace StellarGKLibrary.Shared.Battle.Internal
{
    public class _ProjectileUpdater : FrameAccessor
    {
        internal _ProjectileUpdater()
        {
        }

        internal _ProjectileUpdater(Random random)
        {
            this.SetRandom(random);
        }

        public void SetRandom(Random random)
        {
            this._random = random;
        }

        //public override bool OnFrameAccessStart()
        //{
        //	this._rg = base.simulator.regulation;
        //	return true;
        //}

        public override bool OnUnitAccessStart()
        {
            return base.frame.IsUnitInBattle(base.unitIndex);
        }

        public override bool OnSkillAccessStart()
        {
            this._hasProjectile = false;
            this._hasAliveProjectile = false;
            return true;
        }

        //public override void OnSkillAccessEnd()
        //{
        //	if (this._hasProjectile)
        //	{
        //		base.unit._playingActionIndex = base.skillIndex;
        //		if (!this._hasAliveProjectile && base.skill.returnMotionDri >= 0)
        //		{
        //			UnitMotionDataRow unitMotionDataRow = this._rg.unitMotionDtbl[base.skill.returnMotionDri];
        //			base.skill._remainedReturnMotionTime = unitMotionDataRow.playTime;
        //			base.frame._isWaitingNextTurn = false;
        //		}
        //	}
        //}

        public override bool OnFirePointAccessStart()
        {
            this._aliveProjectiles = new List<Projectile>();
            return true;
        }

        public override void OnFirePointAccessEnd()
        {
            base.firePoint._projectiles = this._aliveProjectiles;
        }

        //public override void OnProjectileAccessStart()
        //{
        //	this._hasProjectile = true;
        //	if (base.projectile._elapsedTime < base.projectileHitTime)
        //	{
        //		base.frame._isWaitingNextTurn = false;
        //	}
        //	base.projectile._elapsedTime += 66;
        //	bool flag = Simulator.HasTimeEvent(base.projectileHitTime, base.projectile.elapsedTime);
        //	if (flag)
        //	{
        //		Unit unit = base.frame._units[base.projectile.targetIndex];
        //		this._ApplyHit(unit);
        //	}
        //	if (base.projectile.elapsedTime < base.projectileMotionDuration || flag)
        //	{
        //		this._hasAliveProjectile = true;
        //		if (base.skill.isActiveSkill)
        //		{
        //			base.frame._hasSkillActionUnit = true;
        //			base.frame._isWaitingNextTurn = false;
        //		}
        //		if (base.skill.returnMotionDri >= 0)
        //		{
        //			base.frame._isWaitingNextTurn = false;
        //		}
        //		if (base.projectile.elapsedTime <= base.simulator.option.delayTurnChangeTime)
        //		{
        //			base.frame._isWaitingNextTurn = false;
        //		}
        //		this._aliveProjectiles.Add(Projectile._Copy(base.projectile));
        //	}
        //}

        //private void _ApplyHit(Unit target)
        //{
        //	if (base.unit.side != target.side)
        //	{
        //		target._beHitCount++;
        //	}
        //	if (base.isMissedProjectile)
        //	{
        //		this._ApplyMissDamage(target);
        //	}
        //	else
        //	{
        //		if (base.skillDr.healing > 0)
        //		{
        //			this._ApplyHealing(target);
        //		}
        //		else
        //		{
        //			this._ApplyHitDamage(target);
        //		}
        //		this._ApplySkillEffect(target);
        //		this._ApplyWeaponEffect(target);
        //	}
        //}

        //private void _ApplyMissDamage(Unit target)
        //{
        //	target._avoidanceCount++;
        //	base.unit._hitCount++;
        //	int num = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
        //	long num2 = (long)base.skill.attackDamage * (long)base.projectileDr.attackDamageScale / (long)(num * 100);
        //	UnitDataRow unitDataRow = this._rg.unitDtbl[target.dri];
        //	if (base.unitDr.typeDown == unitDataRow.type)
        //	{
        //		num2 = num2 * (long)base.unitDr.typeHandicap / 100L;
        //	}
        //	if (base.unitDr.typeUpper == unitDataRow.type)
        //	{
        //		num2 = num2 * (long)base.unitDr.typeBonus / 100L;
        //	}
        //	int num3 = (target.defense + target._addDef) * (100 + target.defenseBonus) / 100;
        //	if (num3 < 0)
        //	{
        //		num3 = 0;
        //	}
        //	num2 = num2 * 100L / (long)(100 + num3);
        //	target._statsDefense += num2;
        //}

        //private void _ApplyHitDamage(Unit target)
        //{
        //	if (!base.skill.isDamageSkill(base.firePointSubIndex))
        //	{
        //		return;
        //	}
        //	int num = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
        //	long num2;
        //	int num3;
        //	if (base.projectile.isCritical)
        //	{
        //		num2 = (long)base.skill.criticalDamage;
        //		num3 = 2;
        //	}
        //	else
        //	{
        //		num2 = (long)base.skill.attackDamage;
        //		num3 = 1;
        //	}
        //	UnitDataRow unitDataRow = this._rg.unitDtbl[target.dri];
        //	num2 = num2 * (long)base.projectileDr.attackDamageScale / (long)(num * 100);
        //	if (base.projectileDr.targetScaleType == EProjectileTargetScaleType.Attack)
        //	{
        //		int projectileTargetScaleValue = this.GetProjectileTargetScaleValue(unitDataRow.job);
        //		num2 = num2 * (long)projectileTargetScaleValue / 100L;
        //	}
        //	if (base.unitDr.typeDown == unitDataRow.type)
        //	{
        //		num2 = num2 * (long)base.unitDr.typeHandicap / 100L;
        //	}
        //	if (base.unitDr.typeUpper == unitDataRow.type)
        //	{
        //		num2 = num2 * (long)base.unitDr.typeBonus / 100L;
        //	}
        //	int num4 = (target.defense + target._addDef) * (100 + target.defenseBonus) / 100;
        //	if (base.skillDr.defensePenetrationRate > 0)
        //	{
        //		int num5 = base.skillDr.defensePenetrationRate * base.skill.SkillLevelFormal.DefensePenetrationRate / 1000;
        //		int num6 = base.skillDr.defensePenetrationRate + num5;
        //		if (num6 > 0)
        //		{
        //			num4 = num4 * (100 - num6) / 100;
        //		}
        //	}
        //	if (num4 < 0)
        //	{
        //		num4 = 0;
        //	}
        //	long num7 = num2;
        //	num2 = num2 * 100L / (long)(100 + num4);
        //	int num8 = base.skillDr.attackDamageIgnoreDefense * base.skill.SkillLevelFormal.AttackDamageIgnoreDefense / 1000;
        //	int num9 = base.skillDr.attackDamageIgnoreDefense + num8;
        //	num2 += (long)(num9 / num);
        //	if (base.projectileDr.damagePattern > 0)
        //	{
        //		SkillDamagePattern skillDamagePattern = this._rg.skillDamagePattern.Get(base.projectileDr.damagePattern);
        //		if (skillDamagePattern != null)
        //		{
        //			int num10 = (int)((long)base.unit._health * 100L / (long)base.unit._maxHealth);
        //			SkillDamagePatternDataRow skillDamagePatternDataRow = skillDamagePattern.Get(num10);
        //			if (skillDamagePatternDataRow != null)
        //			{
        //				num2 = num2 * (long)skillDamagePatternDataRow.damageScale / 100L;
        //			}
        //		}
        //	}
        //	if (target._damageCutRate > 0)
        //	{
        //		num2 = num2 * (long)(100 - target._damageCutRate) / 100L;
        //	}
        //	if (num2 < (long)num3)
        //	{
        //		num2 = (long)num3;
        //	}
        //	if (base.unit.side != target.side)
        //	{
        //		if (target.unbeatableVal > 0)
        //		{
        //			if (num7 > 0L)
        //			{
        //				target._statsDefense += num7;
        //			}
        //			num2 = 0L;
        //		}
        //		else if (target.shiledCount > 0)
        //		{
        //			if (num7 > 0L)
        //			{
        //				target._statsDefense += num7;
        //			}
        //			num2 = 0L;
        //			target._shiledCount--;
        //			if (target._shiledCount <= 0)
        //			{
        //				target._shiledCount = 0;
        //				Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
        //				while (statusItr.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair = statusItr.Current;
        //					if (keyValuePair.Value.ShieldCount > 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair2 = statusItr.Current;
        //						keyValuePair2.Value._shieldCount = 0;
        //						KeyValuePair<int, Status> keyValuePair3 = statusItr.Current;
        //						keyValuePair3.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair4 = statusItr.Current;
        //						keyValuePair4.Value._clingingTurn = 0;
        //					}
        //				}
        //			}
        //		}
        //		else if (num7 > 0L)
        //		{
        //			target._statsDefense += num7 - num2;
        //		}
        //	}
        //	if (num2 > 0L)
        //	{
        //		if (base.skillDr.bloodsucking > 0)
        //		{
        //			int num11 = base.skillDr.bloodsucking * base.skill.SkillLevelFormal.Bloodsucking / 1000;
        //			int num12 = base.skillDr.bloodsucking + num11;
        //			long num13 = num2 * (long)num12 / 100L;
        //			if (base.projectile.isCritical)
        //			{
        //				base.unit._takenCriticalHealing += num13;
        //			}
        //			else
        //			{
        //				base.unit._takenHealing += num13;
        //			}
        //			base.unit._statsHealing += num13;
        //		}
        //		if (target._damageRecoveryRate > 0)
        //		{
        //			target._takenDamageRecovery += num2 * (long)target._damageRecoveryRate / 100L;
        //		}
        //		if (base.projectile.isCritical)
        //		{
        //			base.unit._dealtCriticalDamage += num2;
        //			target._takenCriticalDamage += num2;
        //		}
        //		else
        //		{
        //			base.unit._dealtDamage += num2;
        //			target._takenDamage += num2;
        //		}
        //		base.unit._statsAttack += num2;
        //	}
        //	else
        //	{
        //		target._avoidanceCount++;
        //	}
        //	if (base.projectile.isCritical)
        //	{
        //		base.unit._criticalHitCount++;
        //	}
        //	else
        //	{
        //		base.unit._hitCount++;
        //	}
        //	target._enemyAttackerUnitIdx = base.unitIndex;
        //}

        //private void _ApplyHealing(Unit target)
        //{
        //	int num = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
        //	long num2;
        //	int num3;
        //	if (base.projectile.isCritical)
        //	{
        //		num2 = (long)base.skill.criticalDamage;
        //		num3 = 2;
        //	}
        //	else
        //	{
        //		num2 = (long)base.skill.attackDamage;
        //		num3 = 1;
        //	}
        //	num2 = num2 * (long)base.projectileDr.attackDamageScale / (long)(num * 100);
        //	if (base.projectileDr.damagePattern > 0)
        //	{
        //		SkillDamagePattern skillDamagePattern = this._rg.skillDamagePattern.Get(base.projectileDr.damagePattern);
        //		if (skillDamagePattern != null)
        //		{
        //			int num4 = (int)((long)base.unit._health * 100L / (long)base.unit._maxHealth);
        //			SkillDamagePatternDataRow skillDamagePatternDataRow = skillDamagePattern.Get(num4);
        //			if (skillDamagePatternDataRow != null)
        //			{
        //				num2 = num2 * (long)skillDamagePatternDataRow.damageScale / 100L;
        //			}
        //		}
        //	}
        //	if (num2 < (long)num3)
        //	{
        //		num2 = (long)num3;
        //	}
        //	int num5 = base.skillDr.healing * base.skill.SkillLevelFormal.Healing / 1000;
        //	int num6 = base.skillDr.healing + num5;
        //	num2 = num2 * (long)num6 / 100L * (long)base.projectileDr.healingScale / 100L;
        //	UnitDataRow unitDataRow = this._rg.unitDtbl[target.dri];
        //	if (base.projectileDr.targetScaleType == EProjectileTargetScaleType.Healing)
        //	{
        //		int projectileTargetScaleValue = this.GetProjectileTargetScaleValue(unitDataRow.job);
        //		num2 = num2 * (long)projectileTargetScaleValue / 100L;
        //	}
        //	if (base.projectile.isCritical)
        //	{
        //		target._takenCriticalHealing += num2;
        //	}
        //	else
        //	{
        //		target._takenHealing += num2;
        //	}
        //	base.unit._statsHealing += num2;
        //}

        //private void _ApplySkillEffect(Unit target)
        //{
        //	if (base.statusEffectDrs.Count <= 0)
        //	{
        //		return;
        //	}
        //	for (int i = 0; i < base.statusEffectDrs.Count; i++)
        //	{
        //		this._ApplyStatusEffect(target, base.statusEffectDrs[i], base.projectileDr.clingingTurns[i], base.projectileDr.clingingTime * 1000, false);
        //	}
        //}

        //private void _ApplyWeaponEffect(Unit target)
        //{
        //	if (base.firePointSubIndex != 0)
        //	{
        //		return;
        //	}
        //	if (base.skill._weaponEffects.Count <= 0)
        //	{
        //		return;
        //	}
        //	for (int i = 0; i < base.skill._weaponEffects.Count; i++)
        //	{
        //		this._ApplyStatusEffect(target, base.skill._weaponEffects[i]._statusDri, base.skill._weaponEffects[i]._clingingTurn, 0, true);
        //	}
        //}

        //private void _ApplyStatusEffect(Unit target, int statusDri, int clingingTurn, int clingingTime, bool isWeapon)
        //{
        //	StatusEffectDataRow statusEffectDataRow = this._rg.statusEffectDtbl[statusDri];
        //	string sid = string.Format("{0}_{1}_{2}", base.unitIndex, base.skillIndex, statusEffectDataRow.key);
        //	if (target._takenProjectilesOnTurn.FindIndex((string x) => x == sid) < 0)
        //	{
        //		target._takenProjectilesOnTurn.Add(sid);
        //		if (statusEffectDataRow.chance < 100 && statusEffectDataRow.chance < this._random.Next(1, 101))
        //		{
        //			return;
        //		}
        //		UnitDataRow unitDataRow = this._rg.unitDtbl[target.dri];
        //		if (!Skill.IsTargetJobType(unitDataRow.job, statusEffectDataRow.targetJobType))
        //		{
        //			return;
        //		}
        //		if (target.unbeatableVal > 0)
        //		{
        //			if (statusEffectDataRow.removeStatusCount <= 0)
        //			{
        //				return;
        //			}
        //			if ((statusEffectDataRow.removeStatusGroup & 128) == 0)
        //			{
        //				return;
        //			}
        //		}
        //		bool flag = false;
        //		Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
        //		while (statusItr.MoveNext())
        //		{
        //			KeyValuePair<int, Status> keyValuePair = statusItr.Current;
        //			if ((keyValuePair.Value.preventStatusGroup & statusEffectDataRow.group) != 0)
        //			{
        //				KeyValuePair<int, Status> keyValuePair2 = statusItr.Current;
        //				if (keyValuePair2.Value.preventStatusRate > this._random.Next(0, 100))
        //				{
        //					flag = true;
        //					break;
        //				}
        //			}
        //		}
        //		if (flag)
        //		{
        //			return;
        //		}
        //		Status status = Status._Create(this._rg, base.unitIndex, statusDri, target._turn, clingingTurn, clingingTime * 1000, base.skill.SkillLevelFormal, isWeapon);
        //		this._ApplyStatusEffect(target, status);
        //	}
        //}

        //public void _ApplyStatusEffect(Unit target, Status status)
        //{
        //	status.SetTargetBuffScale(this._rg, target);
        //	if (status.SpVal != 0)
        //	{
        //		for (int i = 1; i < target.skills.Count; i++)
        //		{
        //			if (target.skills[i] != null)
        //			{
        //				target._hasEnabledSkill = false;
        //				target.skills[i]._activeState = false;
        //				target.skills[i]._sp += status.SpVal;
        //				if (target.skills[i]._sp >= target.skills[i].SkillDataRow.maxSp)
        //				{
        //					target.skills[i]._sp = target.skills[i].SkillDataRow.maxSp;
        //					if (target.skills[i]._sp == target.skills[i]._curSp)
        //					{
        //						target._hasEnabledSkill = true;
        //						target.skills[i]._activeState = true;
        //					}
        //				}
        //				else if (target.skills[i]._sp < 0)
        //				{
        //					target.skills[i]._sp = 0;
        //				}
        //				if (i > 1)
        //				{
        //					target.skills[i]._curSp = target.skills[i]._sp;
        //				}
        //			}
        //		}
        //	}
        //	if (status.RemoveStatusCount > 0)
        //	{
        //		int num = 0;
        //		List<Status> list = new List<Status>();
        //		Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
        //		while (statusItr.MoveNext())
        //		{
        //			bool removeStatusGroup = status.RemoveStatusGroup != 0;
        //			KeyValuePair<int, Status> keyValuePair = statusItr.Current;
        //			if (((removeStatusGroup ? 1 : 0) & keyValuePair.Value.group) != 0)
        //			{
        //				bool flag = true;
        //				if (status._elapsedTimeTick >= status._clingingTimeTick && status._elapsedTurn > status._clingingTurn)
        //				{
        //					flag = false;
        //				}
        //				if (flag)
        //				{
        //					if (status.RemoveStatusSteal == 1)
        //					{
        //						Dictionary<int, Status> status2 = base.unit._status;
        //						KeyValuePair<int, Status> keyValuePair2 = statusItr.Current;
        //						if (status2.ContainsKey(keyValuePair2.Value.Dri))
        //						{
        //							List<Status> list2 = list;
        //							KeyValuePair<int, Status> keyValuePair3 = statusItr.Current;
        //							list2.Add(keyValuePair3.Value);
        //							continue;
        //						}
        //						KeyValuePair<int, Status> keyValuePair4 = statusItr.Current;
        //						Status status3 = Status._Copy(keyValuePair4.Value);
        //						status3._ownerUnitIdx = base.unitIndex;
        //						status3._createdTurn = base.unit._turn;
        //						status3._clingingTurn = status.RemoveStatusStealTurn;
        //						status3._clingingTimeTick = 0;
        //						status3._isAlive = true;
        //						status3._elapsedTurn = 0;
        //						status3._elapsedTimeTick = -66;
        //						this._ApplyStatusEffect(base.unit, status3);
        //					}
        //					KeyValuePair<int, Status> keyValuePair5 = statusItr.Current;
        //					keyValuePair5.Value._clingingTurn -= status.RemoveStatusTurn;
        //					KeyValuePair<int, Status> keyValuePair6 = statusItr.Current;
        //					if (keyValuePair6.Value._clingingTurn < 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair7 = statusItr.Current;
        //						keyValuePair7.Value._clingingTurn = 0;
        //					}
        //					if (++num >= status.RemoveStatusCount)
        //					{
        //						break;
        //					}
        //				}
        //			}
        //		}
        //		if (status.RemoveStatusSteal == 1 && num < status.RemoveStatusCount)
        //		{
        //			for (int j = 0; j < list.Count; j++)
        //			{
        //				list[j]._clingingTurn -= status.RemoveStatusTurn;
        //				if (list[j]._clingingTurn < 0)
        //				{
        //					list[j]._clingingTurn = 0;
        //				}
        //				Status status4 = Status._Copy(base.unit._status[list[j].Dri]);
        //				status4._ownerUnitIdx = base.unitIndex;
        //				status4._createdTurn = base.unit._turn;
        //				status4._clingingTurn = status.RemoveStatusStealTurn;
        //				status4._clingingTimeTick = 0;
        //				status4._isAlive = true;
        //				status4._elapsedTurn = 0;
        //				status4._elapsedTimeTick = -66;
        //				this._ApplyStatusEffect(base.unit, status4);
        //				if (++num >= status.RemoveStatusCount)
        //				{
        //					break;
        //				}
        //			}
        //		}
        //	}
        //	if (status.RemainedTurn > 0 || status.RemainedTimeTick > 0)
        //	{
        //		if (target._status.ContainsKey(status.Dri))
        //		{
        //			if (status.ShieldCount > 0)
        //			{
        //				Dictionary<int, Status>.Enumerator statusItr2 = target.StatusItr;
        //				while (statusItr2.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair8 = statusItr2.Current;
        //					if (keyValuePair8.Value.ShieldCount > 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair9 = statusItr2.Current;
        //						keyValuePair9.Value._shieldCount = 0;
        //						KeyValuePair<int, Status> keyValuePair10 = statusItr2.Current;
        //						keyValuePair10.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair11 = statusItr2.Current;
        //						keyValuePair11.Value._clingingTurn = 0;
        //					}
        //				}
        //				target._shiledCount = status.ShieldCount;
        //			}
        //			if (status.FixedEvasionRate > 0)
        //			{
        //				Dictionary<int, Status>.Enumerator statusItr3 = target.StatusItr;
        //				while (statusItr3.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair12 = statusItr3.Current;
        //					if (keyValuePair12.Value.FixedEvasionRate > 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair13 = statusItr3.Current;
        //						keyValuePair13.Value._fixedEvasionRate = 0;
        //						KeyValuePair<int, Status> keyValuePair14 = statusItr3.Current;
        //						keyValuePair14.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair15 = statusItr3.Current;
        //						keyValuePair15.Value._clingingTurn = 0;
        //					}
        //				}
        //				target._fixedEvasionRate = status.FixedEvasionRate;
        //			}
        //			if (status.DamageCutRate > 0)
        //			{
        //				Dictionary<int, Status>.Enumerator statusItr4 = target.StatusItr;
        //				while (statusItr4.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair16 = statusItr4.Current;
        //					if (keyValuePair16.Value.DamageCutRate > 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair17 = statusItr4.Current;
        //						keyValuePair17.Value._damageCutRate = 0;
        //						KeyValuePair<int, Status> keyValuePair18 = statusItr4.Current;
        //						keyValuePair18.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair19 = statusItr4.Current;
        //						keyValuePair19.Value._clingingTurn = 0;
        //					}
        //				}
        //				target._damageCutRate = status.DamageCutRate;
        //			}
        //			if (status.DamageRecoveryRate > 0)
        //			{
        //				Dictionary<int, Status>.Enumerator statusItr5 = target.StatusItr;
        //				while (statusItr5.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair20 = statusItr5.Current;
        //					if (keyValuePair20.Value.DamageRecoveryRate > 0)
        //					{
        //						KeyValuePair<int, Status> keyValuePair21 = statusItr5.Current;
        //						keyValuePair21.Value._damageRecoveryRate = 0;
        //						KeyValuePair<int, Status> keyValuePair22 = statusItr5.Current;
        //						keyValuePair22.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair23 = statusItr5.Current;
        //						keyValuePair23.Value._clingingTurn = 0;
        //					}
        //				}
        //				target._damageRecoveryRate = status.DamageRecoveryRate;
        //			}
        //			if (status.AttackPoint)
        //			{
        //				Dictionary<int, Status>.Enumerator statusItr6 = target.StatusItr;
        //				while (statusItr6.MoveNext())
        //				{
        //					KeyValuePair<int, Status> keyValuePair24 = statusItr6.Current;
        //					if (keyValuePair24.Value.AttackPoint)
        //					{
        //						KeyValuePair<int, Status> keyValuePair25 = statusItr6.Current;
        //						keyValuePair25.Value._attackPoint = false;
        //						KeyValuePair<int, Status> keyValuePair26 = statusItr6.Current;
        //						keyValuePair26.Value._clingingTimeTick = 0;
        //						KeyValuePair<int, Status> keyValuePair27 = statusItr6.Current;
        //						keyValuePair27.Value._clingingTurn = 0;
        //					}
        //				}
        //				target._attackPoint = status.AttackPoint;
        //			}
        //			if (status.Shield > 0)
        //			{
        //				target._maxShiled = status.Shield;
        //				target._shiled = status.Shield;
        //			}
        //			if (target._status[status.Dri].RemainedTimeTick <= status.RemainedTimeTick && target._status[status.Dri].RemainedTurn <= status.RemainedTurn)
        //			{
        //				target._status[status.Dri] = status;
        //			}
        //			return;
        //		}
        //		UnitDataRow unitDataRow = this._rg.unitDtbl[target.dri];
        //		if (unitDataRow.stateAllImmunity > 0)
        //		{
        //			if (status.StunVal > 0)
        //			{
        //				return;
        //			}
        //			if (status.AggroVal > 0)
        //			{
        //				return;
        //			}
        //			if (status.SilenceVal > 0)
        //			{
        //				return;
        //			}
        //		}
        //		if (status.StunVal > 0)
        //		{
        //			target._stun++;
        //		}
        //		if (status.AggroVal > 0)
        //		{
        //			target._aggro += status.AggroVal;
        //			target._aggroUnitIdx = status._ownerUnitIdx;
        //		}
        //		if (status.SilenceVal > 0)
        //		{
        //			target._silenceVal++;
        //		}
        //		if (status.MaxHealthBonus > 0)
        //		{
        //			target._maxHealthBonus += status.MaxHealthBonus;
        //			long num2 = (long)(unitDataRow.maxHealth + target._addHp) * (100L + (long)target.maxHealthBonus) / 100L;
        //			long num3 = num2 - (long)target.maxHealth;
        //			target._takenHealing += num3;
        //			if (target._takenHealing < 0L)
        //			{
        //				target._takenHealing = 0L;
        //			}
        //		}
        //		target._speedBonus += status.SpeedBonus;
        //		target._luckBonus += status.LuckBonus;
        //		target._attackDamageBonus += status.AttackDamageBonus;
        //		target._defenseBonus += status.DefenseBonus;
        //		target._criticalChanceBonus += status.CriticalChanceBonus;
        //		target._criticalDamageBonus += status.CriticalDamageBonus;
        //		target._recvHealBonus += status.RecvHealBonus;
        //		target._accuracyBonus += status.AccuracyBonus;
        //		if (status.UnbeatableVal > 0)
        //		{
        //			target._unbeatableVal++;
        //		}
        //		if (status.Shield > 0)
        //		{
        //			target._statusShieldVal++;
        //			target._maxShiled = status.Shield;
        //			target._shiled = status.Shield;
        //		}
        //		if (status.ShieldCount > 0)
        //		{
        //			Dictionary<int, Status>.Enumerator statusItr7 = target.StatusItr;
        //			while (statusItr7.MoveNext())
        //			{
        //				KeyValuePair<int, Status> keyValuePair28 = statusItr7.Current;
        //				if (keyValuePair28.Value.ShieldCount > 0)
        //				{
        //					KeyValuePair<int, Status> keyValuePair29 = statusItr7.Current;
        //					keyValuePair29.Value._shieldCount = 0;
        //					KeyValuePair<int, Status> keyValuePair30 = statusItr7.Current;
        //					keyValuePair30.Value._clingingTimeTick = 0;
        //					KeyValuePair<int, Status> keyValuePair31 = statusItr7.Current;
        //					keyValuePair31.Value._clingingTurn = 0;
        //				}
        //			}
        //			target._shiledCount = status.ShieldCount;
        //		}
        //		if (status.FixedEvasionRate > 0)
        //		{
        //			Dictionary<int, Status>.Enumerator statusItr8 = target.StatusItr;
        //			while (statusItr8.MoveNext())
        //			{
        //				KeyValuePair<int, Status> keyValuePair32 = statusItr8.Current;
        //				if (keyValuePair32.Value.FixedEvasionRate > 0)
        //				{
        //					KeyValuePair<int, Status> keyValuePair33 = statusItr8.Current;
        //					keyValuePair33.Value._fixedEvasionRate = 0;
        //					KeyValuePair<int, Status> keyValuePair34 = statusItr8.Current;
        //					keyValuePair34.Value._clingingTimeTick = 0;
        //					KeyValuePair<int, Status> keyValuePair35 = statusItr8.Current;
        //					keyValuePair35.Value._clingingTurn = 0;
        //				}
        //			}
        //			target._fixedEvasionRate = status.FixedEvasionRate;
        //		}
        //		if (status.DamageCutRate > 0)
        //		{
        //			Dictionary<int, Status>.Enumerator statusItr9 = target.StatusItr;
        //			while (statusItr9.MoveNext())
        //			{
        //				KeyValuePair<int, Status> keyValuePair36 = statusItr9.Current;
        //				if (keyValuePair36.Value.DamageCutRate > 0)
        //				{
        //					KeyValuePair<int, Status> keyValuePair37 = statusItr9.Current;
        //					keyValuePair37.Value._damageCutRate = 0;
        //					KeyValuePair<int, Status> keyValuePair38 = statusItr9.Current;
        //					keyValuePair38.Value._clingingTimeTick = 0;
        //					KeyValuePair<int, Status> keyValuePair39 = statusItr9.Current;
        //					keyValuePair39.Value._clingingTurn = 0;
        //				}
        //			}
        //			target._damageCutRate = status.DamageCutRate;
        //		}
        //		if (status.DamageRecoveryRate > 0)
        //		{
        //			Dictionary<int, Status>.Enumerator statusItr10 = target.StatusItr;
        //			while (statusItr10.MoveNext())
        //			{
        //				KeyValuePair<int, Status> keyValuePair40 = statusItr10.Current;
        //				if (keyValuePair40.Value.DamageRecoveryRate > 0)
        //				{
        //					KeyValuePair<int, Status> keyValuePair41 = statusItr10.Current;
        //					keyValuePair41.Value._damageRecoveryRate = 0;
        //					KeyValuePair<int, Status> keyValuePair42 = statusItr10.Current;
        //					keyValuePair42.Value._clingingTimeTick = 0;
        //					KeyValuePair<int, Status> keyValuePair43 = statusItr10.Current;
        //					keyValuePair43.Value._clingingTurn = 0;
        //				}
        //			}
        //			target._damageRecoveryRate = status.DamageRecoveryRate;
        //		}
        //		if (status.AttackPoint)
        //		{
        //			Dictionary<int, Status>.Enumerator statusItr11 = target.StatusItr;
        //			while (statusItr11.MoveNext())
        //			{
        //				KeyValuePair<int, Status> keyValuePair44 = statusItr11.Current;
        //				if (keyValuePair44.Value.AttackPoint)
        //				{
        //					KeyValuePair<int, Status> keyValuePair45 = statusItr11.Current;
        //					keyValuePair45.Value._attackPoint = false;
        //					KeyValuePair<int, Status> keyValuePair46 = statusItr11.Current;
        //					keyValuePair46.Value._clingingTimeTick = 0;
        //					KeyValuePair<int, Status> keyValuePair47 = statusItr11.Current;
        //					keyValuePair47.Value._clingingTurn = 0;
        //				}
        //			}
        //			target._attackPoint = status.AttackPoint;
        //		}
        //		if (status._dotDamage > 0)
        //		{
        //			target._dotDamangeVal++;
        //		}
        //		target._status.Add(status.Dri, status);
        //	}
        //}

        //public int GetProjectileTargetScaleValue(EJob job)
        //{
        //	switch (job)
        //	{
        //	case EJob.Attack:
        //	case EJob.Attack_x:
        //	{
        //		int num = base.projectileDr.targetAttackerScale * base.skill.SkillLevelFormal.ProjectileTargetAttackerScale / 1000;
        //		return base.projectileDr.targetAttackerScale + num;
        //	}
        //	case EJob.Defense:
        //	case EJob.Defense_x:
        //	{
        //		int num2 = base.projectileDr.targetDefenderScale * base.skill.SkillLevelFormal.ProjectileTargetDefenderScale / 1000;
        //		return base.projectileDr.targetDefenderScale + num2;
        //	}
        //	case EJob.Support:
        //	case EJob.Support_x:
        //	{
        //		int num3 = base.projectileDr.targetSupporterScale * base.skill.SkillLevelFormal.ProjectileTargetSupporterScale / 1000;
        //		return base.projectileDr.targetSupporterScale + num3;
        //	}
        //	default:
        //		return 100;
        //	}
        //}

        private Random _random;

        private List<Projectile> _aliveProjectiles;

        private bool _bFirstAtk;

        private bool _bFirstDmg;

        private bool _hasProjectile;

        private bool _hasAliveProjectile;

        //private Regulation _rg;
    }
}
