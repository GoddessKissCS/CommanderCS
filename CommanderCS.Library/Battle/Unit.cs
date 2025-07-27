using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation.DataRows;
using Newtonsoft.Json;

namespace CommanderCS.Library.Battle
{
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
            if (skill is null)
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

        internal static Unit _Create(Regulation.Regulation rg, string id)
        {
            int num = rg.unitDtbl.FindIndex(id);
            if (num < 0)
            {
                throw new ArgumentException("drk " + id);
            }
            UnitDataRow unitDataRow = rg.unitDtbl[num];
            Unit unit = new()
            {
                _dri = num,
                _cdri = -1,
                _ctdri = -1,
                _isTurn = false,
                _turn = 0,
                _isDead = false,
                _enableEventSkill = false,
                _eventSkillType = EventSkillType.Unknown,
                _eventSkillIndex = -1,
                _eventSkillTargetUnitIndex = -1,
                _hasEventComboSkill = false,
                _hasEventCounterSkill = false,
                _hasEventHpSkill = false,
                _hasEventDeathSkill = false,
                _isEventMeleeDeathSkill = false,
                _hasEventEnterSkill = false,
                _activeSkillIdx = -1,
                _hasEnabledSkill = false,
                _playingActionIndex = -1,
                _readyFatal = false,
                _bFatal = false,
                _dropGold = 0,
                _dropItemCnt = 0,
                _onDead = false,
                _delayActiveTime = 0,
                _initIncreaseSp = 0,
                _luck = unitDataRow.luck,
                _defense = unitDataRow.defense,
                _speed = unitDataRow.speed,
                _side = EBattleSide.Left,
                _charType = ECharacterType.None,
                _scale = 1f,
                _cls = 0,
                _rank = 0,
                _level = 0,
                _health = 0,
                _cid = string.Empty,
                _ctid = string.Empty,
                _favorRewardStep = 0,
                _marry = 0,
                _partIdx = 0,
                _mainIdx = 0,
                _addHp = 0,
                _addAtk = 0,
                _addDef = 0,
                _addAim = 0,
                _addLuck = 0,
                _addCitr = 0,
                _addCitDmg = 0,
                _addSpeed = 0,
                _shiled = 0,
                _shiledCount = 0,
                _fixedEvasionRate = 0,
                _damageCutRate = 0,
                _damageRecoveryRate = 0,
                _attackPoint = false,
                _statusShieldVal = 0,
                _statsAttack = 0L,
                _statsHealing = 0L,
                _statsDefense = 0L,
                _skills = [],
                _status = [],
                _takenProjectilesOnTurn = [],
                _deathSkillIndex = -1
            };
            return unit;
        }

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
                _skills = []
            };
            for (int i = 0; i < src._skills.Count; i++)
            {
                Skill skill = src._skills[i];
                if (skill is null)
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
}