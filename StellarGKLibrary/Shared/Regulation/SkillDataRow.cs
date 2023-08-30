using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class SkillDataRow : DataRow
	{
		private SkillDataRow()
		{
		}

		public string key { get; set; }

		public int openGrade { get; set; }

		public string thumbnail { get; set; }

		[JsonProperty("rangetype")]
		public ESkillType skillType { get; set; }

		public string rangeicon { get; set; }

		public string skillDescription { get; set; }

		public string cutInEffectId { get; set; }

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
		public IList<string> firePatterns
		{
			get
			{
				return _firePatterns.AsReadOnly();
			}
		}

		[JsonIgnore]
		public IList<string> projectileDrks
		{
			get
			{
				return _projectileDrks.AsReadOnly();
			}
		}

		[JsonProperty("actionEffSound")]
		public string actionEffSound { get; set; }

		[JsonProperty("actionEffWithFire")]
		public EActionEffWithFireType actionEffWithFireType { get; set; }

		[JsonProperty("actionSound")]
		public string actionSound { get; set; }

		[JsonProperty("actionSoundDelay")]
		public int actionSoundDelay { get; set; }

		[JsonProperty("fireSound")]
		public string fireSound { get; set; }

		[JsonProperty("hitSoundtype")]
		public EHitSoundType hitSoundType { get; set; }

		[JsonProperty("hitSoundDelay")]
		public int hitSoundDelay { get; set; }

		[JsonProperty("hitSound")]
		public string hitSound { get; set; }

		[JsonProperty("beHitSound")]
		public string beHitSound { get; set; }

		[JsonProperty("beMissSound")]
		public string beMissSound { get; set; }

		[JsonProperty("targetType")]
		public ESkillTargetType targetType { get; set; }

		[JsonProperty("targetPattern")]
		public ESkillTargetPattern targetPattern { get; set; }

		[JsonProperty("conditionType")]
		public ESkillConditionType conditionType { get; set; }

		[JsonProperty("highCondition")]
		public ESkillTargetStatusCondition targetStatusCondition { get; set; }

		[JsonProperty("conditionValue")]
		public int statusConditionValue { get; set; }

		[JsonProperty("midCondition")]
		public ESkillTargetJobCondition targetJobCondition { get; set; }

		[JsonProperty("lowCondition")]
		public ESkillTargetStatisticCondition targetStatisticCondition { get; set; }

		public int accuracy { get; set; }

		public int coercionAccuracy { get; set; }

		public int attackDamage { get; set; }

		[JsonProperty("atkDmIgDfn")]
		public int attackDamageIgnoreDefense { get; set; }

		[JsonProperty("IgDfnRate")]
		public int defensePenetrationRate { get; set; }

		[JsonProperty("consmHp")]
		public int consumeHpRate { get; set; }

		public int criticalChance { get; set; }

		public int criticalDamageBonus { get; set; }

		public int depletion { get; set; }

		public int healing { get; set; }

		public int bloodsucking { get; set; }

		public int unitLife { get; set; }

		public int remainedHealthRate { get; set; }

		public int initSp { get; set; }

		public int maxSp { get; set; }

		public int spCostOnEnter { get; set; }

		public int spCostOnTurn { get; set; }

		public bool isActiveSkillType
		{
			get
			{
				return spCostOnTurn > 0;
			}
		}

		[JsonProperty("passiveChance")]
		public int occurrenceProbability { get; set; }

		public int spCostOnBeHit { get; set; }

		public int spCostOnCombo { get; set; }

		public int spOnHit { get; set; }

		public int spOnCriticalHit { get; set; }

		public int spOnSkillUse { get; set; }

		public int spOnBeHit { get; set; }

		public int spOnDestroy { get; set; }

		public int startBonus { get; set; }

		public int lvBonus { get; set; }

		public int targetJobType { get; set; }

		public void InitializeData()
		{
			if (_initializeSubInfo)
			{
				return;
			}
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

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			int num = 3;
			Regulation.FillList<string>(ref _firePatterns, num);
			Regulation.FillList<string>(ref _projectileDrks, num);
			Regulation.FillList<ESkillType>(ref fireSubType, 2);
			Regulation.FillList<string>(ref fireSubPatterns, 2);
			Regulation.FillList<string>(ref fireSubProjectileDrks, 2);
			Regulation.FillList<ESkillTargetType>(ref _subTargetTypes, 2);
			Regulation.FillList<ESkillTargetPattern>(ref _subTargetPatterns, 2);
			Regulation.FillList<ESkillConditionType>(ref _subConditionTypes, 2);
			Regulation.FillList<ESkillTargetStatusCondition>(ref _subTargetStatusConditions, 2);
			Regulation.FillList<int>(ref _subStatusConditionValues, 2);
			Regulation.FillList<ESkillTargetJobCondition>(ref _subTargetJobConditions, 2);
			Regulation.FillList<ESkillTargetStatisticCondition>(ref _subTargetStatisticConditions, 2);
			hasReturnMotion = true;
			if (string.IsNullOrEmpty(returnMotionDrk) || returnMotionDrk == "-")
			{
				hasReturnMotion = false;
			}
		}

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
	}
}
