using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class SkillDataRow : DataRow
    {
        public const int FireSubCount = 2;

        public string skillName;

        [JsonProperty("unitMotionDrk")]
        private string _unitMotionDrk;

        [JsonProperty("returnMotion")]
        public string returnMotionDrk;

        [JsonIgnore]
        public bool hasReturnMotion;

        [JsonProperty("firePatterns")]
        private List<string> _firePatterns;

        [JsonProperty("projectileDrks")]
        public List<string> _projectileDrks;

        [JsonProperty("sTyp")]
        public List<ESkillType> fireSubType;

        [JsonProperty("sPtn")]
        public List<string> fireSubPatterns;

        [JsonProperty("sPDrk")]
        public List<string> fireSubProjectileDrks;

        [JsonProperty("sTTyp")]
        private List<ESkillTargetType> _subTargetTypes;

        [JsonProperty("sTPtn")]
        private List<ESkillTargetPattern> _subTargetPatterns;

        [JsonProperty("sCTyp")]
        private List<ESkillConditionType> _subConditionTypes;

        [JsonProperty("sCHigh")]
        private List<ESkillTargetStatusCondition> _subTargetStatusConditions;

        [JsonProperty("sCVal")]
        private List<int> _subStatusConditionValues;

        [JsonProperty("sCMid")]
        private List<ESkillTargetJobCondition> _subTargetJobConditions;

        [JsonProperty("sCLow")]
        private List<ESkillTargetStatisticCondition> _subTargetStatisticConditions;

        private bool _initializeSubInfo;

        [JsonIgnore]
        public List<ESkillType> fireTypes;

        [JsonIgnore]
        public List<ESkillTargetType> targetTypes;

        [JsonIgnore]
        public List<ESkillTargetPattern> targetPatterns;

        [JsonIgnore]
        public List<ESkillConditionType> conditionTypes;

        [JsonIgnore]
        public List<ESkillTargetStatusCondition> targetStatusConditions;

        [JsonIgnore]
        public List<int> conditionValues;

        [JsonIgnore]
        public List<ESkillTargetJobCondition> targetJobConditions;

        [JsonIgnore]
        public List<ESkillTargetStatisticCondition> targetStatisticConditions;

        public string key { get; private set; }

        public int openGrade { get; private set; }

        public string thumbnail { get; private set; }

        [JsonProperty("rangetype")]
        public ESkillType skillType { get; private set; }

        public string rangeicon { get; private set; }

        public string skillDescription { get; private set; }

        public string cutInEffectId { get; private set; }

        [JsonIgnore]
        public string unitMotionDrk
        {
            get
            {
                if (_unitMotionDrk.Contains("/"))
                {
                    return _unitMotionDrk;
                }
                return key + "/" + _unitMotionDrk;
            }
        }

        [JsonIgnore]
        public IList<string> firePatterns => _firePatterns.AsReadOnly();

        [JsonIgnore]
        public IList<string> projectileDrks => _projectileDrks.AsReadOnly();

        [JsonProperty("actionEffSound")]
        public string actionEffSound { get; private set; }

        [JsonProperty("actionEffWithFire")]
        public EActionEffWithFireType actionEffWithFireType { get; private set; }

        [JsonProperty("actionSound")]
        public string actionSound { get; private set; }

        [JsonProperty("actionSoundDelay")]
        public int actionSoundDelay { get; private set; }

        [JsonProperty("fireSound")]
        public string fireSound { get; private set; }

        [JsonProperty("hitSoundtype")]
        public EHitSoundType hitSoundType { get; private set; }

        [JsonProperty("hitSoundDelay")]
        public int hitSoundDelay { get; private set; }

        [JsonProperty("hitSound")]
        public string hitSound { get; private set; }

        [JsonProperty("beHitSound")]
        public string beHitSound { get; private set; }

        [JsonProperty("beMissSound")]
        public string beMissSound { get; private set; }

        [JsonProperty("targetType")]
        public ESkillTargetType targetType { get; private set; }

        [JsonProperty("targetPattern")]
        public ESkillTargetPattern targetPattern { get; private set; }

        [JsonProperty("conditionType")]
        public ESkillConditionType conditionType { get; private set; }

        [JsonProperty("highCondition")]
        public ESkillTargetStatusCondition targetStatusCondition { get; private set; }

        [JsonProperty("conditionValue")]
        public int statusConditionValue { get; private set; }

        [JsonProperty("midCondition")]
        public ESkillTargetJobCondition targetJobCondition { get; private set; }

        [JsonProperty("lowCondition")]
        public ESkillTargetStatisticCondition targetStatisticCondition { get; private set; }

        public int accuracy { get; private set; }

        public int coercionAccuracy { get; private set; }

        public int attackDamage { get; private set; }

        [JsonProperty("atkDmIgDfn")]
        public int attackDamageIgnoreDefense { get; private set; }

        [JsonProperty("IgDfnRate")]
        public int defensePenetrationRate { get; private set; }

        [JsonProperty("consmHp")]
        public int consumeHpRate { get; private set; }

        public int criticalChance { get; private set; }

        public int criticalDamageBonus { get; private set; }

        public int depletion { get; private set; }

        public int healing { get; private set; }

        public int bloodsucking { get; private set; }

        public int unitLife { get; private set; }

        public int remainedHealthRate { get; private set; }

        public int initSp { get; private set; }

        public int maxSp { get; private set; }

        public int spCostOnEnter { get; private set; }

        public int spCostOnTurn { get; private set; }

        public bool isActiveSkillType => spCostOnTurn > 0;

        [JsonProperty("passiveChance")]
        public int occurrenceProbability { get; private set; }

        public int spCostOnBeHit { get; private set; }

        public int spCostOnCombo { get; private set; }

        public int spOnHit { get; private set; }

        public int spOnCriticalHit { get; private set; }

        public int spOnSkillUse { get; private set; }

        public int spOnBeHit { get; private set; }

        public int spOnDestroy { get; private set; }

        public int startBonus { get; private set; }

        public int lvBonus { get; private set; }

        public int targetJobType { get; private set; }

        private SkillDataRow()
        {
        }

        public void InitializeData()
        {
            if (!_initializeSubInfo)
            {
                fireTypes = new List<ESkillType>();
                targetTypes = new List<ESkillTargetType>();
                targetPatterns = new List<ESkillTargetPattern>();
                conditionTypes = new List<ESkillConditionType>();
                targetStatusConditions = new List<ESkillTargetStatusCondition>();
                conditionValues = new List<int>();
                targetJobConditions = new List<ESkillTargetJobCondition>();
                targetStatisticConditions = new List<ESkillTargetStatisticCondition>();
                fireTypes.Add(skillType);
                targetTypes.Add(targetType);
                targetPatterns.Add(targetPattern);
                conditionTypes.Add(conditionType);
                targetStatusConditions.Add(targetStatusCondition);
                conditionValues.Add(statusConditionValue);
                targetJobConditions.Add(targetJobCondition);
                targetStatisticConditions.Add(targetStatisticCondition);
                for (int i = 0; i < 2; i++)
                {
                    fireTypes.Add(fireSubType[i]);
                    targetTypes.Add(_subTargetTypes[i]);
                    targetPatterns.Add(_subTargetPatterns[i]);
                    conditionTypes.Add(_subConditionTypes[i]);
                    targetStatusConditions.Add(_subTargetStatusConditions[i]);
                    conditionValues.Add(_subStatusConditionValues[i]);
                    targetJobConditions.Add(_subTargetJobConditions[i]);
                    targetStatisticConditions.Add(_subTargetStatisticConditions[i]);
                }
                _initializeSubInfo = true;
            }
        }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            int count = 3;
            Regulation.FillList(ref _firePatterns, count);
            Regulation.FillList(ref _projectileDrks, count);
            Regulation.FillList(ref fireSubType, 2);
            Regulation.FillList(ref fireSubPatterns, 2);
            Regulation.FillList(ref fireSubProjectileDrks, 2);
            Regulation.FillList(ref _subTargetTypes, 2);
            Regulation.FillList(ref _subTargetPatterns, 2);
            Regulation.FillList(ref _subConditionTypes, 2);
            Regulation.FillList(ref _subTargetStatusConditions, 2);
            Regulation.FillList(ref _subStatusConditionValues, 2);
            Regulation.FillList(ref _subTargetJobConditions, 2);
            Regulation.FillList(ref _subTargetStatisticConditions, 2);
            hasReturnMotion = true;
            if (string.IsNullOrEmpty(returnMotionDrk) || returnMotionDrk == "-")
            {
                hasReturnMotion = false;
            }
        }
    }

}