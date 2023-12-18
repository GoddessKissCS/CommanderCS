using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class SkillLevelFormal
{
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

    internal SkillUpgradeDataRow _skillUpgradeDataRow;

    public int Dri => _dri;

    public int AttackDamage => _attackDamage;

    public int AttackDamageIgnoreDefense => _attackDamageIgnoreDefense;

    public int DefensePenetrationRate => _defensePenetrationRate;

    public int Healing => _healing;

    public int Shield => _shield;

    public int ShieldCount => _shieldCount;

    public int Bloodsucking => _bloodsucking;

    public int RemoveStatusCount => _removeStatusCount;

    public int RemoveStatusTurn => _removeStatusTurn;

    public int PreventStatusRate => _preventStatusRate;

    public int SpVal => _spVal;

    public int DotDamage => _dotDamage;

    public int DotHealing => _dotHealing;

    public int AttackDamageBonus => _attackDamageBonus;

    public int RecvHealBonus => _recvHealBonus;

    public int MaxHealthBonus => _maxHealthBonus;

    public int SpeedBonus => _speedBonus;

    public int AccuracyBonus => _accuracyBonus;

    public int LuckBonus => _luckBonus;

    public int DefenseBonus => _defenseBonus;

    public int CriticalChanceBonus => _criticalChanceBonus;

    public int CriticalDamageBonus => _criticalDamageBonus;

    public int FixedEvasionRate => _fixedEvasionRate;

    public int DamageRecoveryRate => _damageRecoveryRate;

    public int ProjectileTargetAttackerScale => _projectileTargetAttackerScale;

    public int ProjectileTargetDefenderScale => _projectileTargetDefenderScale;

    public int ProjectileTargetSupporterScale => _projectileTargetSupporterScale;

    public int BuffTargetAttackerScale => _buffTargetAttackerScale;

    public int BuffTargetDefenderScale => _buffTargetDefenderScale;

    public int BuffTargetSupporterScale => _buffTargetSupporterScale;

    public SkillUpgradeDataRow SkillUpgradeDataRow => _skillUpgradeDataRow;

    private SkillLevelFormal()
    {
    }

    internal static SkillLevelFormal _Create(Regulation.Regulation rg, string drk)
    {
        int num = rg.skillUpgradeDtbl.FindIndex(drk);
        SkillLevelFormal skillLevelFormal = new()
        {
            _dri = num,
            _attackDamage = 0,
            _attackDamageIgnoreDefense = 0,
            _defensePenetrationRate = 0,
            _healing = 0,
            _shield = 0,
            _shieldCount = 0,
            _bloodsucking = 0,
            _removeStatusCount = 0,
            _removeStatusTurn = 0,
            _preventStatusRate = 0,
            _spVal = 0,
            _dotDamage = 0,
            _dotHealing = 0,
            _attackDamageBonus = 0,
            _recvHealBonus = 0,
            _maxHealthBonus = 0,
            _speedBonus = 0,
            _accuracyBonus = 0,
            _luckBonus = 0,
            _defenseBonus = 0,
            _criticalChanceBonus = 0,
            _criticalDamageBonus = 0,
            _fixedEvasionRate = 0,
            _damageRecoveryRate = 0,
            _projectileTargetAttackerScale = 0,
            _projectileTargetDefenderScale = 0,
            _projectileTargetSupporterScale = 0,
            _buffTargetAttackerScale = 0,
            _buffTargetDefenderScale = 0,
            _buffTargetSupporterScale = 0
        };
        if (num > 0)
        {
            skillLevelFormal._skillUpgradeDataRow = rg.skillUpgradeDtbl[num];
        }
        return skillLevelFormal;
    }

    internal static SkillLevelFormal _Copy(SkillLevelFormal src)
    {
        SkillLevelFormal skillLevelFormal = new()
        {
            _dri = src._dri,
            _skillUpgradeDataRow = src._skillUpgradeDataRow,
            _attackDamage = src._attackDamage,
            _attackDamageIgnoreDefense = src._attackDamageIgnoreDefense,
            _defensePenetrationRate = src._defensePenetrationRate,
            _healing = src._healing,
            _shield = src._shield,
            _shieldCount = src._shieldCount,
            _bloodsucking = src._bloodsucking,
            _removeStatusCount = src._removeStatusCount,
            _removeStatusTurn = src._removeStatusTurn,
            _preventStatusRate = src._preventStatusRate,
            _spVal = src._spVal,
            _dotDamage = src._dotDamage,
            _dotHealing = src._dotHealing,
            _attackDamageBonus = src._attackDamageBonus,
            _recvHealBonus = src._recvHealBonus,
            _maxHealthBonus = src._maxHealthBonus,
            _speedBonus = src._speedBonus,
            _accuracyBonus = src._accuracyBonus,
            _luckBonus = src._luckBonus,
            _defenseBonus = src._defenseBonus,
            _criticalChanceBonus = src._criticalChanceBonus,
            _criticalDamageBonus = src._criticalDamageBonus,
            _fixedEvasionRate = src._fixedEvasionRate,
            _damageRecoveryRate = src._damageRecoveryRate,
            _projectileTargetAttackerScale = src._projectileTargetAttackerScale,
            _projectileTargetDefenderScale = src._projectileTargetDefenderScale,
            _projectileTargetSupporterScale = src._projectileTargetSupporterScale,
            _buffTargetAttackerScale = src._buffTargetAttackerScale,
            _buffTargetDefenderScale = src._buffTargetDefenderScale,
            _buffTargetSupporterScale = src._buffTargetSupporterScale
        };
        return skillLevelFormal;
    }

    public void SetLevelFormal(int skillLv)
    {
        if (_skillUpgradeDataRow != null)
        {
            skillLv--;
            if (skillLv < 0)
            {
                skillLv = 0;
            }
            _attackDamage = skillLv * _skillUpgradeDataRow.attackDamage;
            _attackDamageIgnoreDefense = skillLv * _skillUpgradeDataRow.attackDamageIgnoreDefense;
            _defensePenetrationRate = skillLv * _skillUpgradeDataRow.defensePenetrationRate;
            _healing = skillLv * _skillUpgradeDataRow.healing;
            _shield = skillLv * _skillUpgradeDataRow.shieldBonus;
            _shieldCount = skillLv * _skillUpgradeDataRow.shieldCount;
            _bloodsucking = skillLv * _skillUpgradeDataRow.bloodsucking;
            _removeStatusCount = skillLv * _skillUpgradeDataRow.removeStatusCount;
            _removeStatusTurn = skillLv * _skillUpgradeDataRow.removeStatusTurn;
            _preventStatusRate = skillLv * _skillUpgradeDataRow.preventStatusRate;
            _spVal = skillLv * _skillUpgradeDataRow.spVal;
            _dotDamage = skillLv * _skillUpgradeDataRow.dotDamage;
            _dotHealing = skillLv * _skillUpgradeDataRow.dotHealing;
            _attackDamageBonus = skillLv * _skillUpgradeDataRow.attackDamageBonus;
            _recvHealBonus = skillLv * _skillUpgradeDataRow.recvHealBonus;
            _maxHealthBonus = skillLv * _skillUpgradeDataRow.maxHealthBonus;
            _speedBonus = skillLv * _skillUpgradeDataRow.speedBonus;
            _accuracyBonus = skillLv * _skillUpgradeDataRow.accuracyBonus;
            _luckBonus = skillLv * _skillUpgradeDataRow.luckBonus;
            _defenseBonus = skillLv * _skillUpgradeDataRow.defenseBonus;
            _criticalChanceBonus = skillLv * _skillUpgradeDataRow.criticalChanceBonus;
            _criticalDamageBonus = skillLv * _skillUpgradeDataRow.criticalDamageBonus;
            _fixedEvasionRate = skillLv * _skillUpgradeDataRow.fixedEvasionRate;
            _damageRecoveryRate = skillLv * _skillUpgradeDataRow.damageRecoveryRate;
            _projectileTargetAttackerScale = skillLv * _skillUpgradeDataRow.projectileTargetAttackerScale;
            _projectileTargetDefenderScale = skillLv * _skillUpgradeDataRow.projectileTargetDefenderScale;
            _projectileTargetSupporterScale = skillLv * _skillUpgradeDataRow.projectileTargetSupporterScale;
            _buffTargetAttackerScale = skillLv * _skillUpgradeDataRow.buffTargetAttackerScale;
            _buffTargetDefenderScale = skillLv * _skillUpgradeDataRow.buffTargetDefenderScale;
            _buffTargetSupporterScale = skillLv * _skillUpgradeDataRow.buffTargetSupporterScale;
        }
    }
}