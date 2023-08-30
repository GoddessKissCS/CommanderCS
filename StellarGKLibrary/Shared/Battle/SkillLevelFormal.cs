using Newtonsoft.Json;


namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SkillLevelFormal
    {
        private SkillLevelFormal()
        {
        }

        public int Dri
        {
            get
            {
                return _dri;
            }
        }

        public int AttackDamage
        {
            get
            {
                return _attackDamage;
            }
        }

        public int AttackDamageIgnoreDefense
        {
            get
            {
                return _attackDamageIgnoreDefense;
            }
        }

        public int DefensePenetrationRate
        {
            get
            {
                return _defensePenetrationRate;
            }
        }

        public int Healing
        {
            get
            {
                return _healing;
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

        public int Bloodsucking
        {
            get
            {
                return _bloodsucking;
            }
        }

        public int RemoveStatusCount
        {
            get
            {
                return _removeStatusCount;
            }
        }

        public int RemoveStatusTurn
        {
            get
            {
                return _removeStatusTurn;
            }
        }

        public int PreventStatusRate
        {
            get
            {
                return _preventStatusRate;
            }
        }

        public int SpVal
        {
            get
            {
                return _spVal;
            }
        }

        public int DotDamage
        {
            get
            {
                return _dotDamage;
            }
        }

        public int DotHealing
        {
            get
            {
                return _dotHealing;
            }
        }

        public int AttackDamageBonus
        {
            get
            {
                return _attackDamageBonus;
            }
        }

        public int RecvHealBonus
        {
            get
            {
                return _recvHealBonus;
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

        public int FixedEvasionRate
        {
            get
            {
                return _fixedEvasionRate;
            }
        }

        public int DamageRecoveryRate
        {
            get
            {
                return _damageRecoveryRate;
            }
        }

        public int ProjectileTargetAttackerScale
        {
            get
            {
                return _projectileTargetAttackerScale;
            }
        }

        public int ProjectileTargetDefenderScale
        {
            get
            {
                return _projectileTargetDefenderScale;
            }
        }

        public int ProjectileTargetSupporterScale
        {
            get
            {
                return _projectileTargetSupporterScale;
            }
        }

        public int BuffTargetAttackerScale
        {
            get
            {
                return _buffTargetAttackerScale;
            }
        }

        public int BuffTargetDefenderScale
        {
            get
            {
                return _buffTargetDefenderScale;
            }
        }

        public int BuffTargetSupporterScale
        {
            get
            {
                return _buffTargetSupporterScale;
            }
        }

        //public SkillUpgradeDataRow SkillUpgradeDataRow
        //{
        //	get
        //	{
        //		return _skillUpgradeDataRow;
        //	}
        //}

        //internal static SkillLevelFormal _Create(Regulation rg, string drk)
        //{
        //	int num = rg.skillUpgradeDtbl.FindIndex(drk);
        //	SkillLevelFormal skillLevelFormal = new SkillLevelFormal();
        //	skillLevelFormal._dri = num;
        //	if (num > 0)
        //	{
        //		skillLevelFormal._skillUpgradeDataRow = rg.skillUpgradeDtbl[num];
        //	}
        //	skillLevelFormal._attackDamage = 0;
        //	skillLevelFormal._attackDamageIgnoreDefense = 0;
        //	skillLevelFormal._defensePenetrationRate = 0;
        //	skillLevelFormal._healing = 0;
        //	skillLevelFormal._shield = 0;
        //	skillLevelFormal._shieldCount = 0;
        //	skillLevelFormal._bloodsucking = 0;
        //	skillLevelFormal._removeStatusCount = 0;
        //	skillLevelFormal._removeStatusTurn = 0;
        //	skillLevelFormal._preventStatusRate = 0;
        //	skillLevelFormal._spVal = 0;
        //	skillLevelFormal._dotDamage = 0;
        //	skillLevelFormal._dotHealing = 0;
        //	skillLevelFormal._attackDamageBonus = 0;
        //	skillLevelFormal._recvHealBonus = 0;
        //	skillLevelFormal._maxHealthBonus = 0;
        //	skillLevelFormal._speedBonus = 0;
        //	skillLevelFormal._accuracyBonus = 0;
        //	skillLevelFormal._luckBonus = 0;
        //	skillLevelFormal._defenseBonus = 0;
        //	skillLevelFormal._criticalChanceBonus = 0;
        //	skillLevelFormal._criticalDamageBonus = 0;
        //	skillLevelFormal._fixedEvasionRate = 0;
        //	skillLevelFormal._damageRecoveryRate = 0;
        //	skillLevelFormal._projectileTargetAttackerScale = 0;
        //	skillLevelFormal._projectileTargetDefenderScale = 0;
        //	skillLevelFormal._projectileTargetSupporterScale = 0;
        //	skillLevelFormal._buffTargetAttackerScale = 0;
        //	skillLevelFormal._buffTargetDefenderScale = 0;
        //	skillLevelFormal._buffTargetSupporterScale = 0;
        //	return skillLevelFormal;
        //}

        //internal static SkillLevelFormal _Copy(SkillLevelFormal src)
        //{
        //	return new SkillLevelFormal
        //	{
        //		_dri = src._dri,
        //		_skillUpgradeDataRow = src._skillUpgradeDataRow,
        //		_attackDamage = src._attackDamage,
        //		_attackDamageIgnoreDefense = src._attackDamageIgnoreDefense,
        //		_defensePenetrationRate = src._defensePenetrationRate,
        //		_healing = src._healing,
        //		_shield = src._shield,
        //		_shieldCount = src._shieldCount,
        //		_bloodsucking = src._bloodsucking,
        //		_removeStatusCount = src._removeStatusCount,
        //		_removeStatusTurn = src._removeStatusTurn,
        //		_preventStatusRate = src._preventStatusRate,
        //		_spVal = src._spVal,
        //		_dotDamage = src._dotDamage,
        //		_dotHealing = src._dotHealing,
        //		_attackDamageBonus = src._attackDamageBonus,
        //		_recvHealBonus = src._recvHealBonus,
        //		_maxHealthBonus = src._maxHealthBonus,
        //		_speedBonus = src._speedBonus,
        //		_accuracyBonus = src._accuracyBonus,
        //		_luckBonus = src._luckBonus,
        //		_defenseBonus = src._defenseBonus,
        //		_criticalChanceBonus = src._criticalChanceBonus,
        //		_criticalDamageBonus = src._criticalDamageBonus,
        //		_fixedEvasionRate = src._fixedEvasionRate,
        //		_damageRecoveryRate = src._damageRecoveryRate,
        //		_projectileTargetAttackerScale = src._projectileTargetAttackerScale,
        //		_projectileTargetDefenderScale = src._projectileTargetDefenderScale,
        //		_projectileTargetSupporterScale = src._projectileTargetSupporterScale,
        //		_buffTargetAttackerScale = src._buffTargetAttackerScale,
        //		_buffTargetDefenderScale = src._buffTargetDefenderScale,
        //		_buffTargetSupporterScale = src._buffTargetSupporterScale
        //	};
        //}

        //public void SetLevelFormal(int skillLv)
        //{
        //	if (_skillUpgradeDataRow == null)
        //	{
        //		return;
        //	}
        //	skillLv--;
        //	if (skillLv < 0)
        //	{
        //		skillLv = 0;
        //	}
        //	_attackDamage = skillLv * _skillUpgradeDataRow.attackDamage;
        //	_attackDamageIgnoreDefense = skillLv * _skillUpgradeDataRow.attackDamageIgnoreDefense;
        //	_defensePenetrationRate = skillLv * _skillUpgradeDataRow.defensePenetrationRate;
        //	_healing = skillLv * _skillUpgradeDataRow.healing;
        //	_shield = skillLv * _skillUpgradeDataRow.shieldBonus;
        //	_shieldCount = skillLv * _skillUpgradeDataRow.shieldCount;
        //	_bloodsucking = skillLv * _skillUpgradeDataRow.bloodsucking;
        //	_removeStatusCount = skillLv * _skillUpgradeDataRow.removeStatusCount;
        //	_removeStatusTurn = skillLv * _skillUpgradeDataRow.removeStatusTurn;
        //	_preventStatusRate = skillLv * _skillUpgradeDataRow.preventStatusRate;
        //	_spVal = skillLv * _skillUpgradeDataRow.spVal;
        //	_dotDamage = skillLv * _skillUpgradeDataRow.dotDamage;
        //	_dotHealing = skillLv * _skillUpgradeDataRow.dotHealing;
        //	_attackDamageBonus = skillLv * _skillUpgradeDataRow.attackDamageBonus;
        //	_recvHealBonus = skillLv * _skillUpgradeDataRow.recvHealBonus;
        //	_maxHealthBonus = skillLv * _skillUpgradeDataRow.maxHealthBonus;
        //	_speedBonus = skillLv * _skillUpgradeDataRow.speedBonus;
        //	_accuracyBonus = skillLv * _skillUpgradeDataRow.accuracyBonus;
        //	_luckBonus = skillLv * _skillUpgradeDataRow.luckBonus;
        //	_defenseBonus = skillLv * _skillUpgradeDataRow.defenseBonus;
        //	_criticalChanceBonus = skillLv * _skillUpgradeDataRow.criticalChanceBonus;
        //	_criticalDamageBonus = skillLv * _skillUpgradeDataRow.criticalDamageBonus;
        //	_fixedEvasionRate = skillLv * _skillUpgradeDataRow.fixedEvasionRate;
        //	_damageRecoveryRate = skillLv * _skillUpgradeDataRow.damageRecoveryRate;
        //	_projectileTargetAttackerScale = skillLv * _skillUpgradeDataRow.projectileTargetAttackerScale;
        //	_projectileTargetDefenderScale = skillLv * _skillUpgradeDataRow.projectileTargetDefenderScale;
        //	_projectileTargetSupporterScale = skillLv * _skillUpgradeDataRow.projectileTargetSupporterScale;
        //	_buffTargetAttackerScale = skillLv * _skillUpgradeDataRow.buffTargetAttackerScale;
        //	_buffTargetDefenderScale = skillLv * _skillUpgradeDataRow.buffTargetDefenderScale;
        //	_buffTargetSupporterScale = skillLv * _skillUpgradeDataRow.buffTargetSupporterScale;
        //}

        internal int _dri;

        internal int _attackDamage;

        internal int _attackDamageIgnoreDefense;

        internal int _defensePenetrationRate;

        internal int _healing;

        internal int _spVal;

        internal int _dotDamage;

        internal int _dotHealing;

        internal int _shield;

        internal int _shieldCount;

        internal int _bloodsucking;

        internal int _removeStatusCount;

        internal int _removeStatusTurn;

        internal int _preventStatusRate;

        internal int _attackDamageBonus;

        internal int _recvHealBonus;

        internal int _maxHealthBonus;

        internal int _speedBonus;

        internal int _accuracyBonus;

        internal int _luckBonus;

        internal int _defenseBonus;

        internal int _criticalChanceBonus;

        internal int _criticalDamageBonus;

        internal int _fixedEvasionRate;

        internal int _damageRecoveryRate;

        internal int _projectileTargetAttackerScale;

        internal int _projectileTargetDefenderScale;

        internal int _projectileTargetSupporterScale;

        internal int _buffTargetAttackerScale;

        internal int _buffTargetDefenderScale;

        internal int _buffTargetSupporterScale;

        //internal SkillUpgradeDataRow _skillUpgradeDataRow;
    }
}
