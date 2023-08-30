using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject]
    public class Status
    {
        private Status()
        {
        }
        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
        }
        public int Dri
        {
            get
            {
                return _dri;
            }
        }
        public int ElapsedTimeTick
        {
            get
            {
                return _elapsedTimeTick;
            }
        }
        public int RemainedTimeTick
        {
            get
            {
                return _clingingTimeTick - _elapsedTimeTick;
            }
        }
        public int RemainedTurn
        {
            get
            {
                return _clingingTurn - _elapsedTurn;
            }
        }
        //public int group
        //{
        //	get
        //	{
        //		return _dataRow.group;
        //	}
        //}
        public int UnbeatableVal
        {
            get
            {
                return _unbeatableVal;
            }
        }
        public int SilenceVal
        {
            get
            {
                return _silenceVal;
            }
        }
        public int StunVal
        {
            get
            {
                return _stunVal;
            }
        }
        public int AggroVal
        {
            get
            {
                return _aggroVal;
            }
        }
        public int Shield
        {
            get
            {
                return _shield;
            }
        }
        public int ShieldCount
        {
            get
            {
                return _shieldCount;
            }
        }
        public bool AttackPoint
        {
            get
            {
                return _attackPoint;
            }
        }
        public int SpVal
        {
            get
            {
                return _spVal;
            }
        }
        public int MaxHealthBonus
        {
            get
            {
                return _maxHealthBonus;
            }
        }
        public int SpeedBonus
        {
            get
            {
                return _speedBonus;
            }
        }
        public int AccuracyBonus
        {
            get
            {
                return _accuracyBonus;
            }
        }
        public int LuckBonus
        {
            get
            {
                return _luckBonus;
            }
        }
        public int AttackDamageBonus
        {
            get
            {
                return _attackDamageBonus;
            }
        }
        public int DefenseBonus
        {
            get
            {
                return _defenseBonus;
            }
        }
        public int CriticalChanceBonus
        {
            get
            {
                return _criticalChanceBonus;
            }
        }
        public int CriticalDamageBonus
        {
            get
            {
                return _criticalDamageBonus;
            }
        }
        public int RecvHealBonus
        {
            get
            {
                return _recvHealBonus;
            }
        }
        public int FixedEvasionRate
        {
            get
            {
                return _fixedEvasionRate;
            }
        }
        public int DamageCutRate
        {
            get
            {
                return _damageCutRate;
            }
        }
        public int DamageRecoveryRate
        {
            get
            {
                return _damageRecoveryRate;
            }
        }
        public int RemoveStatusCount
        {
            get
            {
                return _removeStatusCount;
            }
        }
        //public int RemoveStatusGroup
        //{
        //	get
        //	{
        //		return _dataRow.removeStatusGroup;
        //	}
        //}
        public int RemoveStatusTurn
        {
            get
            {
                return _removeStatusTurn;
            }
        }
        //public int RemoveStatusSteal
        //{
        //	get
        //	{
        //		return _dataRow.removeStatusSteal;
        //	}
        //}
        //public int RemoveStatusStealTurn
        //{
        //	get
        //	{
        //		return _dataRow.removeStatusStealTurn;
        //	}
        //}
        //public int preventStatusGroup
        //{
        //	get
        //	{
        //		return _dataRow.preventStatusGroup;
        //	}
        //}
        public int preventStatusRate
        {
            get
            {
                return _preventStatusRate;
            }
        }

        //public StatusEffectDataRow DataRow
        //{
        //	get
        //	{
        //		return _dataRow;
        //	}
        //}

        //public void SetTargetBuffScale(Regulation rg, Unit unit)
        //{
        //	UnitDataRow unitDataRow = rg.unitDtbl[unit.dri];
        //	int num = 100;
        //	int num2 = 0;
        //	int num3 = 0;
        //	int num4 = 0;
        //	int num5 = 0;
        //	int num6 = 0;
        //	int num7 = 0;
        //	switch (unitDataRow.job)
        //	{
        //	case EJob.Attack:
        //	case EJob.Attack_x:
        //	{
        //		int num8 = (_isWeaponStatus ? 0 : (_dataRow.targetAttackerScale * _skillLvFormal.BuffTargetAttackerScale / 1000));
        //		num = _dataRow.targetAttackerScale + num8;
        //		break;
        //	}
        //	case EJob.Defense:
        //	case EJob.Defense_x:
        //	{
        //		int num9 = (_isWeaponStatus ? 0 : (_dataRow.targetDefenderScale * _skillLvFormal.BuffTargetDefenderScale / 1000));
        //		num = _dataRow.targetDefenderScale + num9;
        //		break;
        //	}
        //	case EJob.Support:
        //	case EJob.Support_x:
        //	{
        //		int num10 = (_isWeaponStatus ? 0 : (_dataRow.targetSupporterScale * _skillLvFormal.BuffTargetSupporterScale / 1000));
        //		num = _dataRow.targetSupporterScale + num10;
        //		break;
        //	}
        //	}
        //	if (!_isWeaponStatus)
        //	{
        //		num2 = _dataRow.accuracyBonus * _skillLvFormal.AccuracyBonus / 1000;
        //		num3 = _dataRow.luckBonus * _skillLvFormal.LuckBonus / 1000;
        //		num4 = _dataRow.attackDamageBonus * _skillLvFormal.AttackDamageBonus / 1000;
        //		num5 = _dataRow.defenseBonus * _skillLvFormal.DefenseBonus / 1000;
        //		num6 = _dataRow.criticalChanceBonus * _skillLvFormal.CriticalChanceBonus / 1000;
        //		num7 = _dataRow.criticalDamageBonus * _skillLvFormal.CriticalDamageBonus / 1000;
        //	}
        //	_accuracyBonus = _dataRow.accuracyBonus + num2;
        //	_accuracyBonus = _accuracyBonus * num / 100;
        //	_luckBonus = _dataRow.luckBonus + num3;
        //	_luckBonus = _luckBonus * num / 100;
        //	_attackDamageBonus = _dataRow.attackDamageBonus + num4;
        //	_attackDamageBonus = _attackDamageBonus * num / 100;
        //	_defenseBonus = _dataRow.defenseBonus + num5;
        //	_defenseBonus = _defenseBonus * num / 100;
        //	_criticalChanceBonus = _dataRow.criticalChanceBonus + num6;
        //	_criticalChanceBonus = _criticalChanceBonus * num / 100;
        //	_criticalDamageBonus = _dataRow.criticalDamageBonus + num7;
        //	_criticalDamageBonus = _criticalDamageBonus * num / 100;
        //}

        //internal static Status _Create(Regulation rg, int ownerUnitIdx, int statusDri, int createdTurn, int clingingTurn, int clingingTimeTick, SkillLevelFormal skillLvFormal, bool isWeapon)
        //{
        //	StatusEffectDataRow statusEffectDataRow = rg.statusEffectDtbl[statusDri];
        //	Status status = new Status();
        //	status._isWeaponStatus = isWeapon;
        //	status._skillLvFormal = skillLvFormal;
        //	status._dri = statusDri;
        //	status._dataRow = statusEffectDataRow;
        //	status._ownerUnitIdx = ownerUnitIdx;
        //	status._elapsedTimeTick = -66;
        //	status._elapsedTurn = 0;
        //	status._createdTurn = createdTurn;
        //	status._clingingTurn = clingingTurn;
        //	status._clingingTimeTick = clingingTimeTick;
        //	status._isAlive = true;
        //	status._unbeatableVal = statusEffectDataRow.unbeatableVal;
        //	status._silenceVal = statusEffectDataRow.silenceVal;
        //	status._stunVal = statusEffectDataRow.stunVal;
        //	status._aggroVal = ((statusEffectDataRow.aggroVal <= 0) ? 0 : 1);
        //	status._attackPoint = statusEffectDataRow.attackPoint;
        //	int num = 0;
        //	int num2 = 0;
        //	int num3 = 0;
        //	int num4 = 0;
        //	int num5 = 0;
        //	int num6 = 0;
        //	int num7 = 0;
        //	int num8 = 0;
        //	int num9 = 0;
        //	int num10 = 0;
        //	int num11 = 0;
        //	int num12 = 0;
        //	int num13 = 0;
        //	int num14 = 0;
        //	int num15 = 0;
        //	int num16 = 0;
        //	int num17 = 0;
        //	int num18 = 0;
        //	int num19 = 0;
        //	if (!status._isWeaponStatus)
        //	{
        //		num = statusEffectDataRow.shield * skillLvFormal.Shield / 1000;
        //		num2 = statusEffectDataRow.shieldCount * skillLvFormal.ShieldCount / 1000;
        //		num3 = statusEffectDataRow.spVal * skillLvFormal.SpVal / 1000;
        //		num4 = statusEffectDataRow.dotDamage * skillLvFormal.DotDamage / 1000;
        //		num5 = statusEffectDataRow.maxHealthBonus * skillLvFormal.MaxHealthBonus / 1000;
        //		num6 = statusEffectDataRow.speedBonus * skillLvFormal.SpeedBonus / 1000;
        //		num7 = statusEffectDataRow.accuracyBonus * skillLvFormal.AccuracyBonus / 1000;
        //		num8 = statusEffectDataRow.luckBonus * skillLvFormal.LuckBonus / 1000;
        //		num9 = statusEffectDataRow.attackDamageBonus * skillLvFormal.AttackDamageBonus / 1000;
        //		num10 = statusEffectDataRow.defenseBonus * skillLvFormal.DefenseBonus / 1000;
        //		num11 = statusEffectDataRow.criticalChanceBonus * skillLvFormal.CriticalChanceBonus / 1000;
        //		num12 = statusEffectDataRow.criticalDamageBonus * skillLvFormal.CriticalDamageBonus / 1000;
        //		num13 = statusEffectDataRow.recvHealBonus * skillLvFormal.RecvHealBonus / 1000;
        //		num14 = statusEffectDataRow.removeStatusCount * skillLvFormal.RemoveStatusCount / 1000;
        //		num15 = statusEffectDataRow.removeStatusTurn * skillLvFormal.RemoveStatusTurn / 1000;
        //		num16 = statusEffectDataRow.dotHealing * skillLvFormal.DotHealing / 1000;
        //		num17 = statusEffectDataRow.fixedEvasionRate * skillLvFormal.FixedEvasionRate / 1000;
        //		num18 = statusEffectDataRow.preventStatusRate * skillLvFormal.PreventStatusRate / 1000;
        //		num19 = statusEffectDataRow.damageRecoveryRate * skillLvFormal.DamageRecoveryRate / 1000;
        //	}
        //	status._shield = statusEffectDataRow.shield + num;
        //	status._shieldCount = statusEffectDataRow.shieldCount + num2;
        //	status._spVal = statusEffectDataRow.spVal + num3;
        //	status._dotDamage = statusEffectDataRow.dotDamage + num4;
        //	status._dotHealing = statusEffectDataRow.dotHealing + num16;
        //	status._maxHealthBonus = statusEffectDataRow.maxHealthBonus + num5;
        //	status._speedBonus = statusEffectDataRow.speedBonus + num6;
        //	status._accuracyBonus = statusEffectDataRow.accuracyBonus + num7;
        //	status._luckBonus = statusEffectDataRow.luckBonus + num8;
        //	status._attackDamageBonus = statusEffectDataRow.attackDamageBonus + num9;
        //	status._defenseBonus = statusEffectDataRow.defenseBonus + num10;
        //	status._criticalChanceBonus = statusEffectDataRow.criticalChanceBonus + num11;
        //	status._criticalDamageBonus = statusEffectDataRow.criticalDamageBonus + num12;
        //	status._recvHealBonus = statusEffectDataRow.recvHealBonus + num13;
        //	status._fixedEvasionRate = statusEffectDataRow.fixedEvasionRate + num17;
        //	status._removeStatusCount = statusEffectDataRow.removeStatusCount + num14;
        //	status._removeStatusTurn = statusEffectDataRow.removeStatusTurn + num15;
        //	status._preventStatusRate = statusEffectDataRow.preventStatusRate + num18;
        //	status._damageCutRate = statusEffectDataRow.damageCutRate;
        //	status._damageRecoveryRate = statusEffectDataRow.damageRecoveryRate + num19;
        //	return status;
        //}

        //internal static Status _Copy(Status src)
        //{
        //	return new Status
        //	{
        //		_isWeaponStatus = src._isWeaponStatus,
        //		_skillLvFormal = src._skillLvFormal,
        //		_dataRow = src._dataRow,
        //		_dri = src._dri,
        //		_ownerUnitIdx = src._ownerUnitIdx,
        //		_elapsedTimeTick = src._elapsedTimeTick,
        //		_elapsedTurn = src._elapsedTurn,
        //		_createdTurn = src._createdTurn,
        //		_clingingTurn = src._clingingTurn,
        //		_clingingTimeTick = src._clingingTimeTick,
        //		_isAlive = src._isAlive,
        //		_unbeatableVal = src._unbeatableVal,
        //		_silenceVal = src._silenceVal,
        //		_stunVal = src._stunVal,
        //		_aggroVal = src._aggroVal,
        //		_attackPoint = src._attackPoint,
        //		_spVal = src._spVal,
        //		_shield = src._shield,
        //		_shieldCount = src._shieldCount,
        //		_dotDamage = src._dotDamage,
        //		_dotHealing = src._dotHealing,
        //		_maxHealthBonus = src._maxHealthBonus,
        //		_speedBonus = src._speedBonus,
        //		_accuracyBonus = src._accuracyBonus,
        //		_luckBonus = src._luckBonus,
        //		_attackDamageBonus = src._attackDamageBonus,
        //		_defenseBonus = src._defenseBonus,
        //		_criticalChanceBonus = src._criticalChanceBonus,
        //		_criticalDamageBonus = src._criticalDamageBonus,
        //		_recvHealBonus = src._recvHealBonus,
        //		_fixedEvasionRate = src._fixedEvasionRate,
        //		_removeStatusCount = src._removeStatusCount,
        //		_removeStatusTurn = src._removeStatusTurn,
        //		_damageCutRate = src._damageCutRate,
        //		_damageRecoveryRate = src._damageRecoveryRate
        //	};
        //}

        internal bool _isAlive;

        internal bool _isWeaponStatus;

        internal int _dri;

        internal int _ownerUnitIdx;

        internal int _elapsedTimeTick;

        internal int _elapsedTurn;

        internal int _createdTurn;

        internal int _clingingTurn;

        internal int _clingingTimeTick;

        internal int _unbeatableVal;

        internal int _silenceVal;

        internal int _stunVal;

        internal int _aggroVal;

        internal int _spVal;

        internal int _shield;

        internal int _shieldCount;

        internal bool _attackPoint;

        internal int _dotDamage;

        internal int _dotHealing;

        internal int _removeStatusCount;

        internal int _removeStatusTurn;

        internal int _preventStatusRate;

        internal int _maxHealthBonus;

        internal int _speedBonus;

        internal int _accuracyBonus;

        internal int _luckBonus;

        internal int _attackDamageBonus;

        internal int _defenseBonus;

        internal int _criticalChanceBonus;

        internal int _criticalDamageBonus;

        internal int _recvHealBonus;

        internal int _fixedEvasionRate;

        internal int _damageCutRate;

        internal int _damageRecoveryRate;

        //internal StatusEffectDataRow _dataRow;

        internal SkillLevelFormal _skillLvFormal;
    }
}
