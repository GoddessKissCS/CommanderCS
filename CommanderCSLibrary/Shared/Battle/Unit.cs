using System;
using System.Collections.Generic;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class Unit
{
	public const int WeaponSkillCount = 1;

	public const int WeaponSkillStartIdx = 4;

	public const int SkillCount = 5;

	[JsonIgnore]
	internal int _unitIdx;

	[JsonIgnore]
	internal int _dri;

	[JsonIgnore]
	internal bool _readyFatal;

	[JsonIgnore]
	internal bool _bFatal;

	[JsonIgnore]
	internal float _scale;

	[JsonIgnore]
	internal ECharacterType _charType;

	[JsonIgnore]
	internal int _mainIdx;

	[JsonIgnore]
	internal int _partIdx;

	[JsonIgnore]
	internal int _delayActiveTime;

	[JsonIgnore]
	internal int _initIncreaseSp;

	[JsonProperty]
	internal bool _isEnteredNow;

	[JsonProperty]
	internal EventSkillType _eventSkillType;

	[JsonProperty]
	internal int _eventSkillIndex;

	[JsonIgnore]
	internal int _eventSkillTargetUnitIndex;

	[JsonProperty]
	internal bool _enableEventSkill;

	[JsonIgnore]
	internal bool _hasEventComboSkill;

	[JsonIgnore]
	internal bool _hasEventCounterSkill;

	[JsonIgnore]
	internal bool _hasEventHpSkill;

	[JsonIgnore]
	internal bool _hasEventEnterSkill;

	[JsonIgnore]
	internal bool _hasEventDeathSkill;

	[JsonIgnore]
	internal bool _isEventMeleeDeathSkill;

	[JsonIgnore]
	internal int _deathSkillIndex;

	[JsonProperty]
	internal bool _isTurn;

	[JsonProperty]
	internal bool _isDead;

	[JsonProperty]
	internal int _turn;

	[JsonProperty]
	internal int _level;

	[JsonProperty]
	internal int _rank;

	[JsonProperty]
	internal int _maxHealth;

	[JsonProperty]
	internal int _health;

	[JsonProperty]
	internal int _maxShiled;

	[JsonProperty]
	internal int _shiled;

	[JsonProperty]
	internal int _speed;

	[JsonProperty]
	internal int _defense;

	[JsonProperty]
	internal int _luck;

	[JsonProperty]
	internal long _takenDamage;

	[JsonProperty]
	internal long _takenCriticalDamage;

	[JsonProperty]
	internal long _dealtDamage;

	[JsonProperty]
	internal long _dealtCriticalDamage;

	[JsonProperty]
	internal long _takenHealing;

	[JsonProperty]
	internal long _takenCriticalHealing;

	[JsonProperty]
	internal long _takenDamageRecovery;

	internal long _uiTakenDamage;

	internal long _uiTakenHealing;

	[JsonProperty]
	internal int _hitCount;

	[JsonProperty]
	internal int _criticalHitCount;

	[JsonProperty]
	internal int _avoidanceCount;

	[JsonProperty]
	internal int _beHitCount;

	[JsonProperty]
	internal int _enemyAttackerUnitIdx;

	[JsonProperty]
	internal int _dropGold;

	[JsonIgnore]
	internal int _dropItemCnt;

	[JsonIgnore]
	internal int _addHp;

	[JsonIgnore]
	internal int _addAtk;

	[JsonIgnore]
	internal int _addDef;

	[JsonIgnore]
	internal int _addAim;

	[JsonIgnore]
	internal int _addLuck;

	[JsonIgnore]
	internal int _addCitr;

	[JsonIgnore]
	internal int _addCitDmg;

	[JsonIgnore]
	internal int _addSpeed;

	[JsonProperty]
	internal int _maxHealthBonus;

	[JsonProperty]
	internal int _speedBonus;

	[JsonProperty]
	internal int _accuracyBonus;

	[JsonProperty]
	internal int _luckBonus;

	[JsonProperty]
	internal int _attackDamageBonus;

	[JsonProperty]
	internal int _defenseBonus;

	[JsonProperty]
	internal int _criticalChanceBonus;

	[JsonProperty]
	internal int _criticalDamageBonus;

	[JsonProperty]
	internal int _recvHealBonus;

	[JsonProperty]
	internal int _fixedEvasionRate;

	[JsonProperty]
	internal int _damageCutRate;

	[JsonProperty]
	public int _damageRecoveryRate;

	[JsonProperty]
	internal int _stun;

	[JsonProperty]
	internal int _aggro;

	[JsonProperty]
	internal int _aggroUnitIdx;

	[JsonProperty]
	internal int _shiledCount;

	[JsonProperty]
	internal bool _attackPoint;

	[JsonProperty]
	internal int _unbeatableVal;

	[JsonProperty]
	internal int _silenceVal;

	[JsonProperty]
	internal int _dotDamangeVal;

	[JsonProperty]
	internal bool _takenRevival;

	[JsonProperty]
	internal int _statusShieldVal;

	[JsonIgnore]
	internal long _statsAttack;

	[JsonIgnore]
	internal long _statsHealing;

	[JsonIgnore]
	internal long _statsDefense;

	internal string _cid;

	internal int _cdri;

	internal int _cls;

	[JsonIgnore]
	internal string _ctid;

	[JsonIgnore]
	internal int _ctdri;

	[JsonIgnore]
	public int _favorRewardStep;

	[JsonIgnore]
	public int _marry;

	[JsonIgnore]
	internal EBattleSide _side;

	[JsonIgnore]
	internal List<Skill> _skills;

	[JsonIgnore]
	internal Dictionary<int, Status> _status;

	[JsonIgnore]
	internal List<string> _takenProjectilesOnTurn;

	[JsonIgnore]
	internal bool _onDead;

	[JsonIgnore]
	internal int _activeSkillIdx;

	[JsonIgnore]
	internal bool _hasEnabledSkill;

	[JsonIgnore]
	internal int _playingActionIndex;

	[JsonIgnore]
	internal bool _isPlayingFire;

	public bool hasEventSkill => _eventSkillIndex >= 0;

	public bool hasActiveSkill => _activeSkillIdx >= 0;

	[JsonIgnore]
	internal bool activeSkillEnableState
	{
		get
		{
			if (_activeSkillIdx < 0)
			{
				return false;
			}
			if (!skills[_activeSkillIdx].CanUse)
			{
				return false;
			}
			return true;
		}
	}

	public bool isPlayingAction => _playingActionIndex >= 0;

	public bool isWaitingReturnMotion
	{
		get
		{
			if (_playingActionIndex >= 0 && skills[_playingActionIndex].returnMotionDri >= 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool isUsingSkill => _playingActionIndex > 0;

	public bool isPlayingFire => _isPlayingFire;

	public int dri => _dri;

	public bool isEnableEventSkill => _enableEventSkill;

	public EventSkillType eventSkillType => _eventSkillType;

	public int eventSkillIndex => _eventSkillIndex;

	public bool isEnteredNow => _isEnteredNow;

	public bool isTurn => _isTurn;

	public int level => _level;

	public int rank => _rank;

	public string cid => _cid;

	public int cls => _cls;

	public string ctid => _ctid;

	public int favorRewardStep => _favorRewardStep;

	public int marry => _marry;

	public bool isDead => _isDead;

	public int maxHealth => _maxHealth;

	public int health => _health;

	public int maxShield => _maxShiled;

	public int shiled => _shiled;

	public int speed => _speed;

	public int defense => _defense;

	public int luck => _luck;

	public long takenDamage => _takenDamage;

	public long takenCriticalDamage => _takenCriticalDamage;

	public long dealtDamage => _dealtDamage;

	public long dealtCriticalDamage => _dealtCriticalDamage;

	public long takenHealing => _takenHealing;

	public long takenCriticalHealing => _takenCriticalHealing;

	public long takenDamageRecovery => _takenDamageRecovery;

	public long uiTakenDamage => _uiTakenDamage;

	public long uiTakenHealing => _uiTakenHealing;

	public int hitCount => _hitCount;

	public int criticalHitCount => _criticalHitCount;

	public int avoidanceCount => _avoidanceCount;

	public int beHitCount => _beHitCount;

	public int dropGold => _dropGold;

	public int dropItemCnt => _dropItemCnt;

	public int enemyAttackerUnitIdx => _enemyAttackerUnitIdx;

	public int maxHealthBonus => _maxHealthBonus;

	public int speedBonus => _speedBonus;

	public int accuracyBonus => _accuracyBonus;

	public int luckBonus => _luckBonus;

	public int attackDamageBonus => _attackDamageBonus;

	public int defenseBonus => _defenseBonus;

	public int criticalChanceBonus => _criticalChanceBonus;

	public int criticalDamageBonus => _criticalDamageBonus;

	public int shiledCount => _shiledCount;

	public bool attackPoint => _attackPoint;

	public int stun => _stun;

	public bool isStatusStun => _stun > 0;

	public int aggro => _aggro;

	public int aggroUnitIdx => _aggroUnitIdx;

	public bool isStatusAggro => _aggro > 0;

	public int unbeatableVal => _unbeatableVal;

	public bool isStatusUnbeatable => _unbeatableVal > 0;

	public int silenceVal => _silenceVal;

	public bool isStatusSilence => _silenceVal > 0;

	public int dotDamangeVal => _dotDamangeVal;

	public bool isStatusDotDamage => _dotDamangeVal > 0;

	public bool takenRevival => _takenRevival;

	public int statusShieldVal => _statusShieldVal;

	public long statsAttack => _statsAttack;

	public long statsHealing => _statsHealing;

	public long statsDefense => _statsDefense;

	public EBattleSide side => _side;

	public bool isEnemyType => side == EBattleSide.Right;

	public IList<Skill> skills => _skills.AsReadOnly();

	public Dictionary<int, Status>.Enumerator StatusItr => _status.GetEnumerator();

	private Unit()
	{
	}

	public bool CanSkillAction(int skillIdx)
	{
		if (skillIdx >= skills.Count)
		{
			return false;
		}
		Skill skill = skills[skillIdx];
		if (skill == null)
		{
			return false;
		}
		if (_cls < skill.SkillDataRow.openGrade)
		{
			return false;
		}
		if (!skill.CanUse)
		{
			return false;
		}
		if (isDead)
		{
			if (!skill.isIgnoreDeathType)
			{
				return false;
			}
		}
		else
		{
			if (isStatusStun)
			{
				return false;
			}
			if (isStatusSilence && skillIdx != 0)
			{
				return false;
			}
			if (isStatusAggro && (skill.SkillDataRow.targetType == ESkillTargetType.Own || skill.SkillDataRow.targetType == ESkillTargetType.Friend))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsSame(Unit arg1, Unit arg2)
	{
		if (arg1 == arg2)
		{
			return true;
		}
		if (arg1.isDead != arg2.isDead)
		{
			return false;
		}
		if (arg1.maxHealth != arg2.maxHealth)
		{
			return false;
		}
		if (arg1.health != arg2.health)
		{
			return false;
		}
		if (arg1.level != arg2.level)
		{
			return false;
		}
		if (arg1.takenDamage != arg2.takenDamage)
		{
			return false;
		}
		if (arg1.takenCriticalDamage != arg2.takenCriticalDamage)
		{
			return false;
		}
		if (arg1.takenHealing != arg2.takenHealing)
		{
			return false;
		}
		if (arg1.takenCriticalHealing != arg2.takenCriticalHealing)
		{
			return false;
		}
		return true;
	}

	internal static Unit _Create(Shared.Regulation.Regulation rg, string id)
	{
		int num = rg.unitDtbl.FindIndex(id);
		if (num < 0)
		{
			throw new ArgumentException("drk " + id);
		}
		UnitDataRow unitDataRow = rg.unitDtbl[num];
		Unit unit = new Unit();
		unit._dri = num;
		unit._cdri = -1;
		unit._ctdri = -1;
		unit._isTurn = false;
		unit._turn = 0;
		unit._isDead = false;
		unit._enableEventSkill = false;
		unit._eventSkillType = EventSkillType.Unknown;
		unit._eventSkillIndex = -1;
		unit._eventSkillTargetUnitIndex = -1;
		unit._hasEventComboSkill = false;
		unit._hasEventCounterSkill = false;
		unit._hasEventHpSkill = false;
		unit._hasEventDeathSkill = false;
		unit._isEventMeleeDeathSkill = false;
		unit._hasEventEnterSkill = false;
		unit._activeSkillIdx = -1;
		unit._hasEnabledSkill = false;
		unit._playingActionIndex = -1;
		unit._readyFatal = false;
		unit._bFatal = false;
		unit._dropGold = 0;
		unit._dropItemCnt = 0;
		unit._onDead = false;
		unit._delayActiveTime = 0;
		unit._initIncreaseSp = 0;
		unit._luck = unitDataRow.luck;
		unit._defense = unitDataRow.defense;
		unit._speed = unitDataRow.speed;
		unit._side = EBattleSide.Left;
		unit._charType = ECharacterType.None;
		unit._scale = 1f;
		unit._cls = 0;
		unit._rank = 0;
		unit._level = 0;
		unit._health = 0;
		unit._cid = string.Empty;
		unit._ctid = string.Empty;
		unit._favorRewardStep = 0;
		unit._marry = 0;
		unit._partIdx = 0;
		unit._mainIdx = 0;
		unit._addHp = 0;
		unit._addAtk = 0;
		unit._addDef = 0;
		unit._addAim = 0;
		unit._addLuck = 0;
		unit._addCitr = 0;
		unit._addCitDmg = 0;
		unit._addSpeed = 0;
		unit._shiled = 0;
		unit._shiledCount = 0;
		unit._fixedEvasionRate = 0;
		unit._damageCutRate = 0;
		unit._damageRecoveryRate = 0;
		unit._attackPoint = false;
		unit._statusShieldVal = 0;
		unit._statsAttack = 0L;
		unit._statsHealing = 0L;
		unit._statsDefense = 0L;
		unit._skills = new List<Skill>();
		unit._status = new Dictionary<int, Status>();
		unit._takenProjectilesOnTurn = new List<string>();
		unit._deathSkillIndex = -1;
		return unit;
	}

	internal static Unit _Copy(Unit src)
	{
		Unit unit = new Unit();
		unit._dri = src._dri;
		unit._isTurn = src._isTurn;
		unit._turn = src._turn;
		unit._enableEventSkill = src._enableEventSkill;
		unit._eventSkillType = src._eventSkillType;
		unit._eventSkillIndex = src._eventSkillIndex;
		unit._eventSkillTargetUnitIndex = src._eventSkillTargetUnitIndex;
		unit._activeSkillIdx = src._activeSkillIdx;
		unit._playingActionIndex = src._playingActionIndex;
		unit._hasEnabledSkill = src._hasEnabledSkill;
		unit._scale = src._scale;
		unit._charType = src._charType;
		unit._cid = src._cid;
		unit._cls = src._cls;
		unit._ctid = src._ctid;
		unit._favorRewardStep = src._favorRewardStep;
		unit._marry = src._marry;
		unit._cdri = src._cdri;
		unit._ctdri = src._ctdri;
		unit._readyFatal = src._readyFatal;
		unit._bFatal = src._bFatal;
		unit._delayActiveTime = src._delayActiveTime;
		unit._initIncreaseSp = src._initIncreaseSp;
		unit._isEnteredNow = src._isEnteredNow;
		unit._hasEventComboSkill = src._hasEventComboSkill;
		unit._hasEventCounterSkill = src._hasEventCounterSkill;
		unit._hasEventHpSkill = src._hasEventHpSkill;
		unit._hasEventDeathSkill = src._hasEventDeathSkill;
		unit._deathSkillIndex = src._deathSkillIndex;
		unit._isEventMeleeDeathSkill = src._isEventMeleeDeathSkill;
		unit._hasEventEnterSkill = src._hasEventEnterSkill;
		unit._level = src._level;
		unit._rank = src._rank;
		unit._maxHealth = src._maxHealth;
		unit._health = src._health;
		unit._maxShiled = src._maxShiled;
		unit._shiled = src._shiled;
		unit._shiledCount = src._shiledCount;
		unit._attackPoint = src._attackPoint;
		unit._speed = src._speed;
		unit._defense = src._defense;
		unit._luck = src._luck;
		unit._takenDamage = src._takenDamage;
		unit._takenCriticalDamage = src._takenCriticalDamage;
		unit._dealtDamage = src._dealtDamage;
		unit._dealtCriticalDamage = src._dealtCriticalDamage;
		unit._takenHealing = src._takenHealing;
		unit._takenCriticalHealing = src._takenCriticalHealing;
		unit._takenDamageRecovery = src._takenDamageRecovery;
		unit._uiTakenDamage = src._uiTakenDamage;
		unit._uiTakenHealing = src._uiTakenHealing;
		unit._hitCount = src._hitCount;
		unit._criticalHitCount = src._criticalHitCount;
		unit._avoidanceCount = src._avoidanceCount;
		unit._dropGold = src._dropGold;
		unit._dropItemCnt = src._dropItemCnt;
		unit._addHp = src._addHp;
		unit._addAtk = src._addAtk;
		unit._addDef = src._addDef;
		unit._addAim = src._addAim;
		unit._addLuck = src._addLuck;
		unit._addCitr = src._addCitr;
		unit._addCitDmg = src._addCitDmg;
		unit._addSpeed = src._addSpeed;
		unit._maxHealthBonus = src._maxHealthBonus;
		unit._speedBonus = src._speedBonus;
		unit._accuracyBonus = src._accuracyBonus;
		unit._luckBonus = src._luckBonus;
		unit._attackDamageBonus = src._attackDamageBonus;
		unit._defenseBonus = src._defenseBonus;
		unit._criticalChanceBonus = src._criticalChanceBonus;
		unit._criticalDamageBonus = src._criticalDamageBonus;
		unit._recvHealBonus = src._recvHealBonus;
		unit._fixedEvasionRate = src._fixedEvasionRate;
		unit._damageCutRate = src._damageCutRate;
		unit._damageRecoveryRate = src._damageRecoveryRate;
		unit._stun = src._stun;
		unit._statusShieldVal = src._statusShieldVal;
		unit._takenRevival = src._takenRevival;
		unit._statsAttack = src._statsAttack;
		unit._statsHealing = src._statsHealing;
		unit._statsDefense = src._statsDefense;
		unit._takenProjectilesOnTurn = src._takenProjectilesOnTurn;
		unit._onDead = src._onDead;
		unit._skills = new List<Skill>();
		for (int i = 0; i < src._skills.Count; i++)
		{
			Skill skill = src._skills[i];
			if (skill == null)
			{
				unit._skills.Add(null);
			}
			else
			{
				unit._skills.Add(Skill._Copy(skill));
			}
		}
		return unit;
	}

	public bool IsCondition(ESkillTargetStatusCondition condition, int conditionVal = 0)
	{
		return true;
	}
}
