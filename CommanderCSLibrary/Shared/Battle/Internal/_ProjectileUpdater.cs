using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;

namespace CommanderCSLibrary.Shared.Battle.Internal;

public class _ProjectileUpdater : FrameAccessor
{
	private Random _random;

	private List<Projectile> _aliveProjectiles;

	private bool _bFirstAtk;

	private bool _bFirstDmg;

	private bool _hasProjectile;

	private bool _hasAliveProjectile;

	private Shared.Regulation.Regulation _rg;

	internal _ProjectileUpdater()
	{
	}

	internal _ProjectileUpdater(Random random)
	{
		SetRandom(random);
	}

	public void SetRandom(Random random)
	{
		_random = random;
	}

	public override bool OnFrameAccessStart()
	{
		_rg = base.simulator.regulation;
		return true;
	}

	public override bool OnUnitAccessStart()
	{
		if (!base.frame.IsUnitInBattle(base.unitIndex))
		{
			return false;
		}
		return true;
	}

	public override bool OnSkillAccessStart()
	{
		_hasProjectile = false;
		_hasAliveProjectile = false;
		return true;
	}

	public override void OnSkillAccessEnd()
	{
		if (_hasProjectile)
		{
			base.unit._playingActionIndex = base.skillIndex;
			if (!_hasAliveProjectile && base.skill.returnMotionDri >= 0)
			{
				UnitMotionDataRow unitMotionDataRow = _rg.unitMotionDtbl[base.skill.returnMotionDri];
				base.skill._remainedReturnMotionTime = unitMotionDataRow.playTime;
				base.frame._isWaitingNextTurn = false;
			}
		}
	}

	public override bool OnFirePointAccessStart()
	{
		_aliveProjectiles = new List<Projectile>();
		return true;
	}

	public override void OnFirePointAccessEnd()
	{
		base.firePoint._projectiles = _aliveProjectiles;
	}

	public override void OnProjectileAccessStart()
	{
		_hasProjectile = true;
		if (base.projectile._elapsedTime < base.projectileHitTime)
		{
			base.frame._isWaitingNextTurn = false;
		}
		base.projectile._elapsedTime += 66;
		bool flag = Simulator.HasTimeEvent(base.projectileHitTime, base.projectile.elapsedTime);
		if (flag)
		{
			Unit target = base.frame._units[base.projectile.targetIndex];
			_ApplyHit(target);
		}
		if (base.projectile.elapsedTime < base.projectileMotionDuration || flag)
		{
			_hasAliveProjectile = true;
			if (base.skill.isActiveSkill)
			{
				base.frame._hasSkillActionUnit = true;
				base.frame._isWaitingNextTurn = false;
			}
			if (base.skill.returnMotionDri >= 0)
			{
				base.frame._isWaitingNextTurn = false;
			}
			if (base.projectile.elapsedTime <= base.simulator.option.delayTurnChangeTime)
			{
				base.frame._isWaitingNextTurn = false;
			}
			_aliveProjectiles.Add(Projectile._Copy(base.projectile));
		}
	}

	private void _ApplyHit(Unit target)
	{
		if (base.unit.side != target.side)
		{
			target._beHitCount++;
		}
		if (base.isMissedProjectile)
		{
			_ApplyMissDamage(target);
			return;
		}
		if (base.skillDr.healing > 0)
		{
			_ApplyHealing(target);
		}
		else
		{
			_ApplyHitDamage(target);
		}
		_ApplySkillEffect(target);
		_ApplyWeaponEffect(target);
	}

	private void _ApplyMissDamage(Unit target)
	{
		target._avoidanceCount++;
		base.unit._hitCount++;
		int num = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
		long num2 = (long)base.skill.attackDamage * (long)base.projectileDr.attackDamageScale / (num * 100);
		UnitDataRow unitDataRow = _rg.unitDtbl[target.dri];
		if (base.unitDr.typeDown == unitDataRow.type)
		{
			num2 = num2 * base.unitDr.typeHandicap / 100;
		}
		if (base.unitDr.typeUpper == unitDataRow.type)
		{
			num2 = num2 * base.unitDr.typeBonus / 100;
		}
		int num3 = (target.defense + target._addDef) * (100 + target.defenseBonus) / 100;
		if (num3 < 0)
		{
			num3 = 0;
		}
		num2 = num2 * 100 / (100 + num3);
		target._statsDefense += num2;
	}

	private void _ApplyHitDamage(Unit target)
	{
		if (!base.skill.isDamageSkill(base.firePointSubIndex))
		{
			return;
		}
		long num = 0L;
		int num2 = 0;
		int num3 = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
		if (base.projectile.isCritical)
		{
			num = base.skill.criticalDamage;
			num2 = 2;
		}
		else
		{
			num = base.skill.attackDamage;
			num2 = 1;
		}
		UnitDataRow unitDataRow = _rg.unitDtbl[target.dri];
		num = num * base.projectileDr.attackDamageScale / (num3 * 100);
		if (base.projectileDr.targetScaleType == EProjectileTargetScaleType.Attack)
		{
			int projectileTargetScaleValue = GetProjectileTargetScaleValue(unitDataRow.job);
			num = num * projectileTargetScaleValue / 100;
		}
		if (base.unitDr.typeDown == unitDataRow.type)
		{
			num = num * base.unitDr.typeHandicap / 100;
		}
		if (base.unitDr.typeUpper == unitDataRow.type)
		{
			num = num * base.unitDr.typeBonus / 100;
		}
		int num4 = (target.defense + target._addDef) * (100 + target.defenseBonus) / 100;
		if (base.skillDr.defensePenetrationRate > 0)
		{
			int num5 = base.skillDr.defensePenetrationRate * base.skill.SkillLevelFormal.DefensePenetrationRate / 1000;
			int num6 = base.skillDr.defensePenetrationRate + num5;
			if (num6 > 0)
			{
				num4 = num4 * (100 - num6) / 100;
			}
		}
		if (num4 < 0)
		{
			num4 = 0;
		}
		long num7 = num;
		num = num * 100 / (100 + num4);
		int num8 = base.skillDr.attackDamageIgnoreDefense * base.skill.SkillLevelFormal.AttackDamageIgnoreDefense / 1000;
		int num9 = base.skillDr.attackDamageIgnoreDefense + num8;
		num += num9 / num3;
		if (base.projectileDr.damagePattern > 0)
		{
			SkillDamagePattern skillDamagePattern = _rg.skillDamagePattern.Get(base.projectileDr.damagePattern);
			if (skillDamagePattern != null)
			{
				int hpRate = (int)((long)base.unit._health * 100L / base.unit._maxHealth);
				SkillDamagePatternDataRow skillDamagePatternDataRow = skillDamagePattern.Get(hpRate);
				if (skillDamagePatternDataRow != null)
				{
					num = num * skillDamagePatternDataRow.damageScale / 100;
				}
			}
		}
		if (target._damageCutRate > 0)
		{
			num = num * (100 - target._damageCutRate) / 100;
		}
		if (num < num2)
		{
			num = num2;
		}
		if (base.unit.side != target.side)
		{
			if (target.unbeatableVal > 0)
			{
				if (num7 > 0)
				{
					target._statsDefense += num7;
				}
				num = 0L;
			}
			else if (target.shiledCount > 0)
			{
				if (num7 > 0)
				{
					target._statsDefense += num7;
				}
				num = 0L;
				target._shiledCount--;
				if (target._shiledCount <= 0)
				{
					target._shiledCount = 0;
					Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
					while (statusItr.MoveNext())
					{
						if (statusItr.Current.Value.ShieldCount > 0)
						{
							statusItr.Current.Value._shieldCount = 0;
							statusItr.Current.Value._clingingTimeTick = 0;
							statusItr.Current.Value._clingingTurn = 0;
						}
					}
				}
			}
			else if (num7 > 0)
			{
				target._statsDefense += num7 - num;
			}
		}
		if (num > 0)
		{
			if (base.skillDr.bloodsucking > 0)
			{
				int num10 = base.skillDr.bloodsucking * base.skill.SkillLevelFormal.Bloodsucking / 1000;
				int num11 = base.skillDr.bloodsucking + num10;
				long num12 = num * num11 / 100;
				if (base.projectile.isCritical)
				{
					base.unit._takenCriticalHealing += num12;
				}
				else
				{
					base.unit._takenHealing += num12;
				}
				base.unit._statsHealing += num12;
			}
			if (target._damageRecoveryRate > 0)
			{
				target._takenDamageRecovery += num * target._damageRecoveryRate / 100;
			}
			if (base.projectile.isCritical)
			{
				base.unit._dealtCriticalDamage += num;
				target._takenCriticalDamage += num;
			}
			else
			{
				base.unit._dealtDamage += num;
				target._takenDamage += num;
			}
			base.unit._statsAttack += num;
		}
		else
		{
			target._avoidanceCount++;
		}
		if (base.projectile.isCritical)
		{
			base.unit._criticalHitCount++;
		}
		else
		{
			base.unit._hitCount++;
		}
		target._enemyAttackerUnitIdx = base.unitIndex;
	}

	private void _ApplyHealing(Unit target)
	{
		long num = 0L;
		int num2 = 0;
		int num3 = ((base.firePointSubIndex != 0) ? 1 : base.unitMotionDr.totalFireCount);
		if (base.projectile.isCritical)
		{
			num = base.skill.criticalDamage;
			num2 = 2;
		}
		else
		{
			num = base.skill.attackDamage;
			num2 = 1;
		}
		num = num * base.projectileDr.attackDamageScale / (num3 * 100);
		if (base.projectileDr.damagePattern > 0)
		{
			SkillDamagePattern skillDamagePattern = _rg.skillDamagePattern.Get(base.projectileDr.damagePattern);
			if (skillDamagePattern != null)
			{
				int hpRate = (int)((long)base.unit._health * 100L / base.unit._maxHealth);
				SkillDamagePatternDataRow skillDamagePatternDataRow = skillDamagePattern.Get(hpRate);
				if (skillDamagePatternDataRow != null)
				{
					num = num * skillDamagePatternDataRow.damageScale / 100;
				}
			}
		}
		if (num < num2)
		{
			num = num2;
		}
		int num4 = base.skillDr.healing * base.skill.SkillLevelFormal.Healing / 1000;
		int num5 = base.skillDr.healing + num4;
		num = num * num5 / 100 * base.projectileDr.healingScale / 100;
		UnitDataRow unitDataRow = _rg.unitDtbl[target.dri];
		if (base.projectileDr.targetScaleType == EProjectileTargetScaleType.Healing)
		{
			int projectileTargetScaleValue = GetProjectileTargetScaleValue(unitDataRow.job);
			num = num * projectileTargetScaleValue / 100;
		}
		if (base.projectile.isCritical)
		{
			target._takenCriticalHealing += num;
		}
		else
		{
			target._takenHealing += num;
		}
		base.unit._statsHealing += num;
	}

	private void _ApplySkillEffect(Unit target)
	{
		if (base.statusEffectDrs.Count > 0)
		{
			for (int i = 0; i < base.statusEffectDrs.Count; i++)
			{
				_ApplyStatusEffect(target, base.statusEffectDrs[i], base.projectileDr.clingingTurns[i], base.projectileDr.clingingTime * 1000, isWeapon: false);
			}
		}
	}

	private void _ApplyWeaponEffect(Unit target)
	{
		if (base.firePointSubIndex == 0 && base.skill._weaponEffects.Count > 0)
		{
			for (int i = 0; i < base.skill._weaponEffects.Count; i++)
			{
				_ApplyStatusEffect(target, base.skill._weaponEffects[i]._statusDri, base.skill._weaponEffects[i]._clingingTurn, 0, isWeapon: true);
			}
		}
	}

	private void _ApplyStatusEffect(Unit target, int statusDri, int clingingTurn, int clingingTime, bool isWeapon)
	{
		StatusEffectDataRow statusEffectDataRow = _rg.statusEffectDtbl[statusDri];
		string sid = $"{base.unitIndex}_{base.skillIndex}_{statusEffectDataRow.key}";
		if (target._takenProjectilesOnTurn.FindIndex((string x) => x == sid) >= 0)
		{
			return;
		}
		target._takenProjectilesOnTurn.Add(sid);
		if (statusEffectDataRow.chance < 100 && statusEffectDataRow.chance < _random.Next(1, 101))
		{
			return;
		}
		UnitDataRow unitDataRow = _rg.unitDtbl[target.dri];
		if (!Skill.IsTargetJobType(unitDataRow.job, statusEffectDataRow.targetJobType) || (target.unbeatableVal > 0 && (statusEffectDataRow.removeStatusCount <= 0 || (statusEffectDataRow.removeStatusGroup & 0x80) == 0)))
		{
			return;
		}
		bool flag = false;
		Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
		while (statusItr.MoveNext())
		{
			if ((statusItr.Current.Value.preventStatusGroup & statusEffectDataRow.group) == 0 || statusItr.Current.Value.preventStatusRate <= _random.Next(0, 100))
			{
				continue;
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			Status status = Status._Create(_rg, base.unitIndex, statusDri, target._turn, clingingTurn, clingingTime * 1000, base.skill.SkillLevelFormal, isWeapon);
			_ApplyStatusEffect(target, status);
		}
	}

	public void _ApplyStatusEffect(Unit target, Status status)
	{
		status.SetTargetBuffScale(_rg, target);
		if (status.SpVal != 0)
		{
			for (int i = 1; i < target.skills.Count; i++)
			{
				if (target.skills[i] == null)
				{
					continue;
				}
				target._hasEnabledSkill = false;
				target.skills[i]._activeState = false;
				target.skills[i]._sp += status.SpVal;
				if (target.skills[i]._sp >= target.skills[i].SkillDataRow.maxSp)
				{
					target.skills[i]._sp = target.skills[i].SkillDataRow.maxSp;
					if (target.skills[i]._sp == target.skills[i]._curSp)
					{
						target._hasEnabledSkill = true;
						target.skills[i]._activeState = true;
					}
				}
				else if (target.skills[i]._sp < 0)
				{
					target.skills[i]._sp = 0;
				}
				if (i > 1)
				{
					target.skills[i]._curSp = target.skills[i]._sp;
				}
			}
		}
		if (status.RemoveStatusCount > 0)
		{
			int num = 0;
			List<Status> list = new List<Status>();
			Dictionary<int, Status>.Enumerator statusItr = target.StatusItr;
			while (statusItr.MoveNext())
			{
				if ((status.RemoveStatusGroup & statusItr.Current.Value.group) == 0)
				{
					continue;
				}
				bool flag = true;
				if (status._elapsedTimeTick >= status._clingingTimeTick && status._elapsedTurn > status._clingingTurn)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				if (status.RemoveStatusSteal == 1)
				{
					if (base.unit._status.ContainsKey(statusItr.Current.Value.Dri))
					{
						list.Add(statusItr.Current.Value);
						continue;
					}
					Status status2 = Status._Copy(statusItr.Current.Value);
					status2._ownerUnitIdx = base.unitIndex;
					status2._createdTurn = base.unit._turn;
					status2._clingingTurn = status.RemoveStatusStealTurn;
					status2._clingingTimeTick = 0;
					status2._isAlive = true;
					status2._elapsedTurn = 0;
					status2._elapsedTimeTick = -66;
					_ApplyStatusEffect(base.unit, status2);
				}
				statusItr.Current.Value._clingingTurn -= status.RemoveStatusTurn;
				if (statusItr.Current.Value._clingingTurn < 0)
				{
					statusItr.Current.Value._clingingTurn = 0;
				}
				if (++num < status.RemoveStatusCount)
				{
					continue;
				}
				break;
			}
			if (status.RemoveStatusSteal == 1 && num < status.RemoveStatusCount)
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[j]._clingingTurn -= status.RemoveStatusTurn;
					if (list[j]._clingingTurn < 0)
					{
						list[j]._clingingTurn = 0;
					}
					Status status3 = Status._Copy(base.unit._status[list[j].Dri]);
					status3._ownerUnitIdx = base.unitIndex;
					status3._createdTurn = base.unit._turn;
					status3._clingingTurn = status.RemoveStatusStealTurn;
					status3._clingingTimeTick = 0;
					status3._isAlive = true;
					status3._elapsedTurn = 0;
					status3._elapsedTimeTick = -66;
					_ApplyStatusEffect(base.unit, status3);
					if (++num >= status.RemoveStatusCount)
					{
						break;
					}
				}
			}
		}
		if (status.RemainedTurn <= 0 && status.RemainedTimeTick <= 0)
		{
			return;
		}
		if (target._status.ContainsKey(status.Dri))
		{
			if (status.ShieldCount > 0)
			{
				Dictionary<int, Status>.Enumerator statusItr2 = target.StatusItr;
				while (statusItr2.MoveNext())
				{
					if (statusItr2.Current.Value.ShieldCount > 0)
					{
						statusItr2.Current.Value._shieldCount = 0;
						statusItr2.Current.Value._clingingTimeTick = 0;
						statusItr2.Current.Value._clingingTurn = 0;
					}
				}
				target._shiledCount = status.ShieldCount;
			}
			if (status.FixedEvasionRate > 0)
			{
				Dictionary<int, Status>.Enumerator statusItr3 = target.StatusItr;
				while (statusItr3.MoveNext())
				{
					if (statusItr3.Current.Value.FixedEvasionRate > 0)
					{
						statusItr3.Current.Value._fixedEvasionRate = 0;
						statusItr3.Current.Value._clingingTimeTick = 0;
						statusItr3.Current.Value._clingingTurn = 0;
					}
				}
				target._fixedEvasionRate = status.FixedEvasionRate;
			}
			if (status.DamageCutRate > 0)
			{
				Dictionary<int, Status>.Enumerator statusItr4 = target.StatusItr;
				while (statusItr4.MoveNext())
				{
					if (statusItr4.Current.Value.DamageCutRate > 0)
					{
						statusItr4.Current.Value._damageCutRate = 0;
						statusItr4.Current.Value._clingingTimeTick = 0;
						statusItr4.Current.Value._clingingTurn = 0;
					}
				}
				target._damageCutRate = status.DamageCutRate;
			}
			if (status.DamageRecoveryRate > 0)
			{
				Dictionary<int, Status>.Enumerator statusItr5 = target.StatusItr;
				while (statusItr5.MoveNext())
				{
					if (statusItr5.Current.Value.DamageRecoveryRate > 0)
					{
						statusItr5.Current.Value._damageRecoveryRate = 0;
						statusItr5.Current.Value._clingingTimeTick = 0;
						statusItr5.Current.Value._clingingTurn = 0;
					}
				}
				target._damageRecoveryRate = status.DamageRecoveryRate;
			}
			if (status.AttackPoint)
			{
				Dictionary<int, Status>.Enumerator statusItr6 = target.StatusItr;
				while (statusItr6.MoveNext())
				{
					if (statusItr6.Current.Value.AttackPoint)
					{
						statusItr6.Current.Value._attackPoint = false;
						statusItr6.Current.Value._clingingTimeTick = 0;
						statusItr6.Current.Value._clingingTurn = 0;
					}
				}
				target._attackPoint = status.AttackPoint;
			}
			if (status.Shield > 0)
			{
				target._maxShiled = status.Shield;
				target._shiled = status.Shield;
			}
			if (target._status[status.Dri].RemainedTimeTick <= status.RemainedTimeTick && target._status[status.Dri].RemainedTurn <= status.RemainedTurn)
			{
				target._status[status.Dri] = status;
			}
			return;
		}
		UnitDataRow unitDataRow = _rg.unitDtbl[target.dri];
		if (unitDataRow.stateAllImmunity > 0 && (status.StunVal > 0 || status.AggroVal > 0 || status.SilenceVal > 0))
		{
			return;
		}
		if (status.StunVal > 0)
		{
			target._stun++;
		}
		if (status.AggroVal > 0)
		{
			target._aggro += status.AggroVal;
			target._aggroUnitIdx = status._ownerUnitIdx;
		}
		if (status.SilenceVal > 0)
		{
			target._silenceVal++;
		}
		if (status.MaxHealthBonus > 0)
		{
			target._maxHealthBonus += status.MaxHealthBonus;
			long num2 = (unitDataRow.maxHealth + target._addHp) * (100L + (long)target.maxHealthBonus) / 100;
			long num3 = num2 - target.maxHealth;
			target._takenHealing += num3;
			if (target._takenHealing < 0)
			{
				target._takenHealing = 0L;
			}
		}
		target._speedBonus += status.SpeedBonus;
		target._luckBonus += status.LuckBonus;
		target._attackDamageBonus += status.AttackDamageBonus;
		target._defenseBonus += status.DefenseBonus;
		target._criticalChanceBonus += status.CriticalChanceBonus;
		target._criticalDamageBonus += status.CriticalDamageBonus;
		target._recvHealBonus += status.RecvHealBonus;
		target._accuracyBonus += status.AccuracyBonus;
		if (status.UnbeatableVal > 0)
		{
			target._unbeatableVal++;
		}
		if (status.Shield > 0)
		{
			target._statusShieldVal++;
			target._maxShiled = status.Shield;
			target._shiled = status.Shield;
		}
		if (status.ShieldCount > 0)
		{
			Dictionary<int, Status>.Enumerator statusItr7 = target.StatusItr;
			while (statusItr7.MoveNext())
			{
				if (statusItr7.Current.Value.ShieldCount > 0)
				{
					statusItr7.Current.Value._shieldCount = 0;
					statusItr7.Current.Value._clingingTimeTick = 0;
					statusItr7.Current.Value._clingingTurn = 0;
				}
			}
			target._shiledCount = status.ShieldCount;
		}
		if (status.FixedEvasionRate > 0)
		{
			Dictionary<int, Status>.Enumerator statusItr8 = target.StatusItr;
			while (statusItr8.MoveNext())
			{
				if (statusItr8.Current.Value.FixedEvasionRate > 0)
				{
					statusItr8.Current.Value._fixedEvasionRate = 0;
					statusItr8.Current.Value._clingingTimeTick = 0;
					statusItr8.Current.Value._clingingTurn = 0;
				}
			}
			target._fixedEvasionRate = status.FixedEvasionRate;
		}
		if (status.DamageCutRate > 0)
		{
			Dictionary<int, Status>.Enumerator statusItr9 = target.StatusItr;
			while (statusItr9.MoveNext())
			{
				if (statusItr9.Current.Value.DamageCutRate > 0)
				{
					statusItr9.Current.Value._damageCutRate = 0;
					statusItr9.Current.Value._clingingTimeTick = 0;
					statusItr9.Current.Value._clingingTurn = 0;
				}
			}
			target._damageCutRate = status.DamageCutRate;
		}
		if (status.DamageRecoveryRate > 0)
		{
			Dictionary<int, Status>.Enumerator statusItr10 = target.StatusItr;
			while (statusItr10.MoveNext())
			{
				if (statusItr10.Current.Value.DamageRecoveryRate > 0)
				{
					statusItr10.Current.Value._damageRecoveryRate = 0;
					statusItr10.Current.Value._clingingTimeTick = 0;
					statusItr10.Current.Value._clingingTurn = 0;
				}
			}
			target._damageRecoveryRate = status.DamageRecoveryRate;
		}
		if (status.AttackPoint)
		{
			Dictionary<int, Status>.Enumerator statusItr11 = target.StatusItr;
			while (statusItr11.MoveNext())
			{
				if (statusItr11.Current.Value.AttackPoint)
				{
					statusItr11.Current.Value._attackPoint = false;
					statusItr11.Current.Value._clingingTimeTick = 0;
					statusItr11.Current.Value._clingingTurn = 0;
				}
			}
			target._attackPoint = status.AttackPoint;
		}
		if (status._dotDamage > 0)
		{
			target._dotDamangeVal++;
		}
		target._status.Add(status.Dri, status);
	}

	public int GetProjectileTargetScaleValue(EJob job)
	{
		switch (job)
		{
		case EJob.Attack:
		case EJob.Attack_x:
		{
			int num3 = base.projectileDr.targetAttackerScale * base.skill.SkillLevelFormal.ProjectileTargetAttackerScale / 1000;
			return base.projectileDr.targetAttackerScale + num3;
		}
		case EJob.Defense:
		case EJob.Defense_x:
		{
			int num2 = base.projectileDr.targetDefenderScale * base.skill.SkillLevelFormal.ProjectileTargetDefenderScale / 1000;
			return base.projectileDr.targetDefenderScale + num2;
		}
		case EJob.Support:
		case EJob.Support_x:
		{
			int num = base.projectileDr.targetSupporterScale * base.skill.SkillLevelFormal.ProjectileTargetSupporterScale / 1000;
			return base.projectileDr.targetSupporterScale + num;
		}
		default:
			return 100;
		}
	}
}
