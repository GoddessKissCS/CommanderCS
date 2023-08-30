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
                return this._dri;
            }
        }

        public int AttackDamage
        {
            get
            {
                return this._attackDamage;
            }
        }

        public int AttackDamageIgnoreDefense
        {
            get
            {
                return this._attackDamageIgnoreDefense;
            }
        }

        public int DefensePenetrationRate
        {
            get
            {
                return this._defensePenetrationRate;
            }
        }

        public int Healing
        {
            get
            {
                return this._healing;
            }
        }

        public int Shield
        {
            get
            {
                return this._shield;
            }
        }

        public int ShieldCount
        {
            get
            {
                return this._shieldCount;
            }
        }

        public int Bloodsucking
        {
            get
            {
                return this._bloodsucking;
            }
        }

        public int RemoveStatusCount
        {
            get
            {
                return this._removeStatusCount;
            }
        }

        public int RemoveStatusTurn
        {
            get
            {
                return this._removeStatusTurn;
            }
        }

        public int PreventStatusRate
        {
            get
            {
                return this._preventStatusRate;
            }
        }

        public int SpVal
        {
            get
            {
                return this._spVal;
            }
        }

        public int DotDamage
        {
            get
            {
                return this._dotDamage;
            }
        }

        public int DotHealing
        {
            get
            {
                return this._dotHealing;
            }
        }

        public int AttackDamageBonus
        {
            get
            {
                return this._attackDamageBonus;
            }
        }

        public int RecvHealBonus
        {
            get
            {
                return this._recvHealBonus;
            }
        }

        public int MaxHealthBonus
        {
            get
            {
                return this._maxHealthBonus;
            }
        }

        public int SpeedBonus
        {
            get
            {
                return this._speedBonus;
            }
        }

        public int AccuracyBonus
        {
            get
            {
                return this._accuracyBonus;
            }
        }

        public int LuckBonus
        {
            get
            {
                return this._luckBonus;
            }
        }

        public int DefenseBonus
        {
            get
            {
                return this._defenseBonus;
            }
        }

        public int CriticalChanceBonus
        {
            get
            {
                return this._criticalChanceBonus;
            }
        }

        public int CriticalDamageBonus
        {
            get
            {
                return this._criticalDamageBonus;
            }
        }

        public int FixedEvasionRate
        {
            get
            {
                return this._fixedEvasionRate;
            }
        }

        public int DamageRecoveryRate
        {
            get
            {
                return this._damageRecoveryRate;
            }
        }

        public int ProjectileTargetAttackerScale
        {
            get
            {
                return this._projectileTargetAttackerScale;
            }
        }

        public int ProjectileTargetDefenderScale
        {
            get
            {
                return this._projectileTargetDefenderScale;
            }
        }

        public int ProjectileTargetSupporterScale
        {
            get
            {
                return this._projectileTargetSupporterScale;
            }
        }

        public int BuffTargetAttackerScale
        {
            get
            {
                return this._buffTargetAttackerScale;
            }
        }

        public int BuffTargetDefenderScale
        {
            get
            {
                return this._buffTargetDefenderScale;
            }
        }

        public int BuffTargetSupporterScale
        {
            get
            {
                return this._buffTargetSupporterScale;
            }
        }

        //public SkillUpgradeDataRow SkillUpgradeDataRow
        //{
        //	get
        //	{
        //		return this._skillUpgradeDataRow;
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
        //	if (this._skillUpgradeDataRow == null)
        //	{
        //		return;
        //	}
        //	skillLv--;
        //	if (skillLv < 0)
        //	{
        //		skillLv = 0;
        //	}
        //	this._attackDamage = skillLv * this._skillUpgradeDataRow.attackDamage;
        //	this._attackDamageIgnoreDefense = skillLv * this._skillUpgradeDataRow.attackDamageIgnoreDefense;
        //	this._defensePenetrationRate = skillLv * this._skillUpgradeDataRow.defensePenetrationRate;
        //	this._healing = skillLv * this._skillUpgradeDataRow.healing;
        //	this._shield = skillLv * this._skillUpgradeDataRow.shieldBonus;
        //	this._shieldCount = skillLv * this._skillUpgradeDataRow.shieldCount;
        //	this._bloodsucking = skillLv * this._skillUpgradeDataRow.bloodsucking;
        //	this._removeStatusCount = skillLv * this._skillUpgradeDataRow.removeStatusCount;
        //	this._removeStatusTurn = skillLv * this._skillUpgradeDataRow.removeStatusTurn;
        //	this._preventStatusRate = skillLv * this._skillUpgradeDataRow.preventStatusRate;
        //	this._spVal = skillLv * this._skillUpgradeDataRow.spVal;
        //	this._dotDamage = skillLv * this._skillUpgradeDataRow.dotDamage;
        //	this._dotHealing = skillLv * this._skillUpgradeDataRow.dotHealing;
        //	this._attackDamageBonus = skillLv * this._skillUpgradeDataRow.attackDamageBonus;
        //	this._recvHealBonus = skillLv * this._skillUpgradeDataRow.recvHealBonus;
        //	this._maxHealthBonus = skillLv * this._skillUpgradeDataRow.maxHealthBonus;
        //	this._speedBonus = skillLv * this._skillUpgradeDataRow.speedBonus;
        //	this._accuracyBonus = skillLv * this._skillUpgradeDataRow.accuracyBonus;
        //	this._luckBonus = skillLv * this._skillUpgradeDataRow.luckBonus;
        //	this._defenseBonus = skillLv * this._skillUpgradeDataRow.defenseBonus;
        //	this._criticalChanceBonus = skillLv * this._skillUpgradeDataRow.criticalChanceBonus;
        //	this._criticalDamageBonus = skillLv * this._skillUpgradeDataRow.criticalDamageBonus;
        //	this._fixedEvasionRate = skillLv * this._skillUpgradeDataRow.fixedEvasionRate;
        //	this._damageRecoveryRate = skillLv * this._skillUpgradeDataRow.damageRecoveryRate;
        //	this._projectileTargetAttackerScale = skillLv * this._skillUpgradeDataRow.projectileTargetAttackerScale;
        //	this._projectileTargetDefenderScale = skillLv * this._skillUpgradeDataRow.projectileTargetDefenderScale;
        //	this._projectileTargetSupporterScale = skillLv * this._skillUpgradeDataRow.projectileTargetSupporterScale;
        //	this._buffTargetAttackerScale = skillLv * this._skillUpgradeDataRow.buffTargetAttackerScale;
        //	this._buffTargetDefenderScale = skillLv * this._skillUpgradeDataRow.buffTargetDefenderScale;
        //	this._buffTargetSupporterScale = skillLv * this._skillUpgradeDataRow.buffTargetSupporterScale;
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
