using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Unit
    {
        private Unit()
        {
        }
        public bool hasEventSkill
        {
            get
            {
                return _eventSkillIndex >= 0;
            }
        }
        public bool hasActiveSkill
        {
            get
            {
                return _activeSkillIdx >= 0;
            }
        }

        //[JsonIgnore]
        //internal bool activeSkillEnableState
        //{
        //	get
        //	{
        //		return _activeSkillIdx >= 0 && skills[_activeSkillIdx].CanUse;
        //	}
        //}
        public bool isPlayingAction
        {
            get
            {
                return _playingActionIndex >= 0;
            }
        }
        public bool isWaitingReturnMotion
        {
            get
            {
                return _playingActionIndex >= 0 && skills[_playingActionIndex].returnMotionDri >= 0;
            }
        }
        public bool isUsingSkill
        {
            get
            {
                return _playingActionIndex > 0;
            }
        }
        public bool isPlayingFire
        {
            get
            {
                return _isPlayingFire;
            }
        }

        //public bool CanSkillAction(int skillIdx)
        //{
        //	if (skillIdx >= skills.Count)
        //	{
        //		return false;
        //	}
        //	Skill skill = skills[skillIdx];
        //	if (skill == null)
        //	{
        //		return false;
        //	}
        //	if (_cls < skill.SkillDataRow.openGrade)
        //	{
        //		return false;
        //	}
        //	if (!skill.CanUse)
        //	{
        //		return false;
        //	}
        //	if (isDead)
        //	{
        //		if (!skill.isIgnoreDeathType)
        //		{
        //			return false;
        //		}
        //	}
        //	else
        //	{
        //		if (isStatusStun)
        //		{
        //			return false;
        //		}
        //		if (isStatusSilence && skillIdx != 0)
        //		{
        //			return false;
        //		}
        //		if (isStatusAggro && (skill.SkillDataRow.targetType == ESkillTargetType.Own || skill.SkillDataRow.targetType == ESkillTargetType.Friend))
        //		{
        //			return false;
        //		}
        //	}
        //	return true;
        //}
        public int dri
        {
            get
            {
                return _dri;
            }
        }
        public bool isEnableEventSkill
        {
            get
            {
                return _enableEventSkill;
            }
        }
        public EventSkillType eventSkillType
        {
            get
            {
                return _eventSkillType;
            }
        }
        public int eventSkillIndex
        {
            get
            {
                return _eventSkillIndex;
            }
        }
        public bool isEnteredNow
        {
            get
            {
                return _isEnteredNow;
            }
        }
        public bool isTurn
        {
            get
            {
                return _isTurn;
            }
        }
        public int level
        {
            get
            {
                return _level;
            }
        }
        public int rank
        {
            get
            {
                return _rank;
            }
        }
        public string cid
        {
            get
            {
                return _cid;
            }
        }
        public int cls
        {
            get
            {
                return _cls;
            }
        }
        public string ctid
        {
            get
            {
                return _ctid;
            }
        }
        public int favorRewardStep
        {
            get
            {
                return _favorRewardStep;
            }
        }
        public int marry
        {
            get
            {
                return _marry;
            }
        }
        public bool isDead
        {
            get
            {
                return _isDead;
            }
        }
        public int maxHealth
        {
            get
            {
                return _maxHealth;
            }
        }
        public int health
        {
            get
            {
                return _health;
            }
        }
        public int maxShield
        {
            get
            {
                return _maxShiled;
            }
        }
        public int shiled
        {
            get
            {
                return _shiled;
            }
        }
        public int speed
        {
            get
            {
                return _speed;
            }
        }
        public int defense
        {
            get
            {
                return _defense;
            }
        }
        public int luck
        {
            get
            {
                return _luck;
            }
        }
        public long takenDamage
        {
            get
            {
                return _takenDamage;
            }
        }
        public long takenCriticalDamage
        {
            get
            {
                return _takenCriticalDamage;
            }
        }
        public long dealtDamage
        {
            get
            {
                return _dealtDamage;
            }
        }
        public long dealtCriticalDamage
        {
            get
            {
                return _dealtCriticalDamage;
            }
        }
        public long takenHealing
        {
            get
            {
                return _takenHealing;
            }
        }
        public long takenCriticalHealing
        {
            get
            {
                return _takenCriticalHealing;
            }
        }
        public long takenDamageRecovery
        {
            get
            {
                return _takenDamageRecovery;
            }
        }
        public long uiTakenDamage
        {
            get
            {
                return _uiTakenDamage;
            }
        }
        public long uiTakenHealing
        {
            get
            {
                return _uiTakenHealing;
            }
        }
        public int hitCount
        {
            get
            {
                return _hitCount;
            }
        }
        public int criticalHitCount
        {
            get
            {
                return _criticalHitCount;
            }
        }
        public int avoidanceCount
        {
            get
            {
                return _avoidanceCount;
            }
        }
        public int beHitCount
        {
            get
            {
                return _beHitCount;
            }
        }
        public int dropGold
        {
            get
            {
                return _dropGold;
            }
        }
        public int dropItemCnt
        {
            get
            {
                return _dropItemCnt;
            }
        }
        public int enemyAttackerUnitIdx
        {
            get
            {
                return _enemyAttackerUnitIdx;
            }
        }
        public int maxHealthBonus
        {
            get
            {
                return _maxHealthBonus;
            }
        }
        public int speedBonus
        {
            get
            {
                return _speedBonus;
            }
        }
        public int accuracyBonus
        {
            get
            {
                return _accuracyBonus;
            }
        }
        public int luckBonus
        {
            get
            {
                return _luckBonus;
            }
        }
        public int attackDamageBonus
        {
            get
            {
                return _attackDamageBonus;
            }
        }
        public int defenseBonus
        {
            get
            {
                return _defenseBonus;
            }
        }
        public int criticalChanceBonus
        {
            get
            {
                return _criticalChanceBonus;
            }
        }
        public int criticalDamageBonus
        {
            get
            {
                return _criticalDamageBonus;
            }
        }
        public int shiledCount
        {
            get
            {
                return _shiledCount;
            }
        }
        public bool attackPoint
        {
            get
            {
                return _attackPoint;
            }
        }
        public int stun
        {
            get
            {
                return _stun;
            }
        }
        public bool isStatusStun
        {
            get
            {
                return _stun > 0;
            }
        }
        public int aggro
        {
            get
            {
                return _aggro;
            }
        }
        public int aggroUnitIdx
        {
            get
            {
                return _aggroUnitIdx;
            }
        }
        public bool isStatusAggro
        {
            get
            {
                return _aggro > 0;
            }
        }
        public int unbeatableVal
        {
            get
            {
                return _unbeatableVal;
            }
        }
        public bool isStatusUnbeatable
        {
            get
            {
                return _unbeatableVal > 0;
            }
        }
        public int silenceVal
        {
            get
            {
                return _silenceVal;
            }
        }
        public bool isStatusSilence
        {
            get
            {
                return _silenceVal > 0;
            }
        }
        public int dotDamangeVal
        {
            get
            {
                return _dotDamangeVal;
            }
        }
        public bool isStatusDotDamage
        {
            get
            {
                return _dotDamangeVal > 0;
            }
        }
        public bool takenRevival
        {
            get
            {
                return _takenRevival;
            }
        }
        public int statusShieldVal
        {
            get
            {
                return _statusShieldVal;
            }
        }
        public long statsAttack
        {
            get
            {
                return _statsAttack;
            }
        }
        public long statsHealing
        {
            get
            {
                return _statsHealing;
            }
        }
        public long statsDefense
        {
            get
            {
                return _statsDefense;
            }
        }
        public EBattleSide side
        {
            get
            {
                return _side;
            }
        }
        public bool isEnemyType
        {
            get
            {
                return side == EBattleSide.Right;
            }
        }
        public IList<Skill> skills
        {
            get
            {
                return _skills.AsReadOnly();
            }
        }

        public Dictionary<int, Status>.Enumerator StatusItr
        {
            get
            {
                return _status.GetEnumerator();
            }
        }
        public static bool IsSame(Unit arg1, Unit arg2)
        {
            return arg1 == arg2 || (arg1.isDead == arg2.isDead && arg1.maxHealth == arg2.maxHealth && arg1.health == arg2.health && arg1.level == arg2.level && arg1.takenDamage == arg2.takenDamage && arg1.takenCriticalDamage == arg2.takenCriticalDamage && arg1.takenHealing == arg2.takenHealing && arg1.takenCriticalHealing == arg2.takenCriticalHealing);
        }

        //internal static Unit _Create(Regulation rg, string id)
        //{
        //	int num = rg.unitDtbl.FindIndex(id);
        //	if (num < 0)
        //	{
        //		throw new ArgumentException("drk " + id);
        //	}
        //	UnitDataRow unitDataRow = rg.unitDtbl[num];
        //	return new Unit
        //	{
        //		_dri = num,
        //		_cdri = -1,
        //		_ctdri = -1,
        //		_isTurn = false,
        //		_turn = 0,
        //		_isDead = false,
        //		_enableEventSkill = false,
        //		_eventSkillType = EventSkillType.Unknown,
        //		_eventSkillIndex = -1,
        //		_eventSkillTargetUnitIndex = -1,
        //		_hasEventComboSkill = false,
        //		_hasEventCounterSkill = false,
        //		_hasEventHpSkill = false,
        //		_hasEventDeathSkill = false,
        //		_isEventMeleeDeathSkill = false,
        //		_hasEventEnterSkill = false,
        //		_activeSkillIdx = -1,
        //		_hasEnabledSkill = false,
        //		_playingActionIndex = -1,
        //		_readyFatal = false,
        //		_bFatal = false,
        //		_dropGold = 0,
        //		_dropItemCnt = 0,
        //		_onDead = false,
        //		_delayActiveTime = 0,
        //		_initIncreaseSp = 0,
        //		_luck = unitDataRow.luck,
        //		_defense = unitDataRow.defense,
        //		_speed = unitDataRow.speed,
        //		_side = EBattleSide.Left,
        //		_charType = ECharacterType.None,
        //		_scale = 1f,
        //		_cls = 0,
        //		_rank = 0,
        //		_level = 0,
        //		_health = 0,
        //		_cid = string.Empty,
        //		_ctid = string.Empty,
        //		_favorRewardStep = 0,
        //		_marry = 0,
        //		_partIdx = 0,
        //		_mainIdx = 0,
        //		_addHp = 0,
        //		_addAtk = 0,
        //		_addDef = 0,
        //		_addAim = 0,
        //		_addLuck = 0,
        //		_addCitr = 0,
        //		_addCitDmg = 0,
        //		_addSpeed = 0,
        //		_shiled = 0,
        //		_shiledCount = 0,
        //		_fixedEvasionRate = 0,
        //		_damageCutRate = 0,
        //		_damageRecoveryRate = 0,
        //		_attackPoint = false,
        //		_statusShieldVal = 0,
        //		_statsAttack = 0L,
        //		_statsHealing = 0L,
        //		_statsDefense = 0L,
        //		_skills = new List<Skill>(),
        //		_status = new Dictionary<int, Status>(),
        //		_takenProjectilesOnTurn = new List<string>(),
        //		_deathSkillIndex = -1
        //	};
        //}

        internal static Unit _Copy(Unit src)
        {
            Unit unit = new()
            {
                _dri = src._dri,
                _isTurn = src._isTurn,
                _turn = src._turn,
                _enableEventSkill = src._enableEventSkill,
                _eventSkillType = src._eventSkillType,
                _eventSkillIndex = src._eventSkillIndex,
                _eventSkillTargetUnitIndex = src._eventSkillTargetUnitIndex,
                _activeSkillIdx = src._activeSkillIdx,
                _playingActionIndex = src._playingActionIndex,
                _hasEnabledSkill = src._hasEnabledSkill,
                _scale = src._scale,
                _charType = src._charType,
                _cid = src._cid,
                _cls = src._cls,
                _ctid = src._ctid,
                _favorRewardStep = src._favorRewardStep,
                _marry = src._marry,
                _cdri = src._cdri,
                _ctdri = src._ctdri,
                _readyFatal = src._readyFatal,
                _bFatal = src._bFatal,
                _delayActiveTime = src._delayActiveTime,
                _initIncreaseSp = src._initIncreaseSp,
                _isEnteredNow = src._isEnteredNow,
                _hasEventComboSkill = src._hasEventComboSkill,
                _hasEventCounterSkill = src._hasEventCounterSkill,
                _hasEventHpSkill = src._hasEventHpSkill,
                _hasEventDeathSkill = src._hasEventDeathSkill,
                _deathSkillIndex = src._deathSkillIndex,
                _isEventMeleeDeathSkill = src._isEventMeleeDeathSkill,
                _hasEventEnterSkill = src._hasEventEnterSkill,
                _level = src._level,
                _rank = src._rank,
                _maxHealth = src._maxHealth,
                _health = src._health,
                _maxShiled = src._maxShiled,
                _shiled = src._shiled,
                _shiledCount = src._shiledCount,
                _attackPoint = src._attackPoint,
                _speed = src._speed,
                _defense = src._defense,
                _luck = src._luck,
                _takenDamage = src._takenDamage,
                _takenCriticalDamage = src._takenCriticalDamage,
                _dealtDamage = src._dealtDamage,
                _dealtCriticalDamage = src._dealtCriticalDamage,
                _takenHealing = src._takenHealing,
                _takenCriticalHealing = src._takenCriticalHealing,
                _takenDamageRecovery = src._takenDamageRecovery,
                _uiTakenDamage = src._uiTakenDamage,
                _uiTakenHealing = src._uiTakenHealing,
                _hitCount = src._hitCount,
                _criticalHitCount = src._criticalHitCount,
                _avoidanceCount = src._avoidanceCount,
                _dropGold = src._dropGold,
                _dropItemCnt = src._dropItemCnt,
                _addHp = src._addHp,
                _addAtk = src._addAtk,
                _addDef = src._addDef,
                _addAim = src._addAim,
                _addLuck = src._addLuck,
                _addCitr = src._addCitr,
                _addCitDmg = src._addCitDmg,
                _addSpeed = src._addSpeed,
                _maxHealthBonus = src._maxHealthBonus,
                _speedBonus = src._speedBonus,
                _accuracyBonus = src._accuracyBonus,
                _luckBonus = src._luckBonus,
                _attackDamageBonus = src._attackDamageBonus,
                _defenseBonus = src._defenseBonus,
                _criticalChanceBonus = src._criticalChanceBonus,
                _criticalDamageBonus = src._criticalDamageBonus,
                _recvHealBonus = src._recvHealBonus,
                _fixedEvasionRate = src._fixedEvasionRate,
                _damageCutRate = src._damageCutRate,
                _damageRecoveryRate = src._damageRecoveryRate,
                _stun = src._stun,
                _statusShieldVal = src._statusShieldVal,
                _takenRevival = src._takenRevival,
                _statsAttack = src._statsAttack,
                _statsHealing = src._statsHealing,
                _statsDefense = src._statsDefense,
                _takenProjectilesOnTurn = src._takenProjectilesOnTurn,
                _onDead = src._onDead,
                _skills = new List<Skill>()
            };
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
    }
}
