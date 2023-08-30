using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class UnitDataRow : DataRow
	{
		private UnitDataRow()
		{
		}

		public string key { get; set; }

		public string nameKey { get; set; }

		public string prefabId { get; set; }

		public string resourceName { get; set; }

		[JsonIgnore]
		public int modelType { get; set; }

		public string unitSmallIconName
		{
			get
			{
				return resourceName + "_Small";
			}
		}

		public int maxHealth { get; set; }

		public int speed { get; set; }

		public EBranch branch { get; set; }

		public EUnitType type { get; set; }

		public EUnitType typeUpper { get; set; }

		public EUnitType typeDown { get; set; }

		public int typeBonus { get; set; }

		public int typeHandicap { get; set; }

		public bool isCommander
		{
			get
			{
				return type == EUnitType.Commander;
			}
		}

		public int gold { get; set; }

		public int leadership { get; set; }

		public int attackDamage { get; set; }

		public int defense { get; set; }

		public int accuracy { get; set; }

		public int criticalChance { get; set; }

		public int criticalDamageBonus { get; set; }

		public int unlockLevel { get; set; }

		public int luck { get; set; }

		public bool isHidden
		{
			get
			{
				return unlockLevel <= 0;
			}
		}

		public string dropGoldPattern { get; set; }

		public string levelPattern { get; set; }

		public string classPattern { get; set; }

		public string afterLevelPattern { get; set; }

		public string afterClassPattern { get; set; }

		public EJob job { get; set; }

		public int stateAllImmunity { get; set; }

		public string explanation { get; set; }

		private string _branch
		{
			get
			{
				return branch.ToString();
			}
			set
			{
				branch = Regulation.ParseEBranch(value);
			}
		}

		[JsonIgnore]
		public int evasion
		{
			get
			{
				return luck;
			}
			set
			{
				luck = value;
			}
		}

		[JsonIgnore]
		public int criticalDamage
		{
			get
			{
				return criticalDamageBonus;
			}
			set
			{
				criticalDamageBonus = value;
			}
		}

		[JsonIgnore]
		public int reloadSpeed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		[JsonIgnore]
		public IList<string> skillDrks
		{
			get
			{
				return _skillDrks.AsReadOnly();
			}
		}

		public int originAttackDamage { get; set; }

		public int originDefense { get; set; }

		public int originAccuracy { get; set; }

		public int originCriticalChance { get; set; }

		public int originCriticalDamageBonus { get; set; }

		public int originSpeed { get; set; }

		public int originLuck { get; set; }

		public int originMaxHealth { get; set; }

		public int partHead { get; set; }

		public int partRightHand { get; set; }

		public int partLeftHand { get; set; }

		public int partBody { get; set; }

		public int partSpecial { get; set; }

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Regulation.FillList<string>(ref _skillDrks, 4);
		}

		public UnitDataRow Clone()
		{
			return JsonConvert.DeserializeObject<UnitDataRow>(JsonConvert.SerializeObject(this), Regulation.SerializerSettings);
		}

		public int GetTotalPower()
		{
			int num = criticalChance / 100;
			int num2 = criticalDamageBonus / 100;
			int num3 = accuracy * 180 / 100;
			int num4 = defense * 808 / 100;
			int num5 = luck * 253 / 100;
			return attackDamage + attackDamage * num * num2 + num3 + num4 + num5 + maxHealth;
		}

		public int GetOriginTotalPower()
		{
			int num = originCriticalChance / 100;
			int num2 = originCriticalDamageBonus / 100;
			int num3 = originAccuracy * 180 / 100;
			int num4 = originDefense * 808 / 100;
			int num5 = originLuck * 253 / 100;
			return originAttackDamage + originAttackDamage * num * num2 + num3 + num4 + num5 + originMaxHealth;
		}

		//private int AddTranscendenceHealth(int tsdcCount)
		//{
		//	int num = 0;
		//	if (tsdcCount > 0)
		//	{
		//		int num2 = 0;
		//		int num3 = tsdcCount;
		//		for (int i = 0; i < RUtility.regulation.transcendenceStepUpgradeDtbl.length; i++)
		//		{
		//			if (num3 <= 0)
		//			{
		//				break;
		//			}
		//			TranscendenceStepUpgradeDataRow transcendenceStepUpgradeDataRow = RUtility.regulation.transcendenceStepUpgradeDtbl[i];
		//			int num4 = transcendenceStepUpgradeDataRow.stepPoint - num2;
		//			int num5 = ((num3 >= num4) ? num4 : num3);
		//			int num6 = num5 / transcendenceStepUpgradeDataRow.statAddMeasure * transcendenceStepUpgradeDataRow.statAddVolume;
		//			num += num6;
		//			num3 -= num5;
		//			num2 = transcendenceStepUpgradeDataRow.stepPoint;
		//		}
		//	}
		//	return num;
		//}

		//private int CurrentTranscendenceStep(int tsdcCount)
		//{
		//	List<TranscendenceStepUpgradeDataRow> list = RUtility.regulation.FindTranscendenceStepUpgradeListPoint(tsdcCount);
		//	return list.Count;
		//}

		//public void InvokeLevel(int rank, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> EquipItem = null, bool isSetItem = false, Dictionary<int, RoWeapon> weaponItem = null, bool isWeaponSet = true)
		//{
		//	Regulation regulation = RemoteObjectManager.instance.regulation;
		//	string text = string.Format("{0}_{1}", (marry != 1) ? levelPattern : afterLevelPattern, rank);
		//	int num = regulation.levelPatternDtbl.FindIndex(text);
		//	if (num == -1)
		//	{
		//		return;
		//	}
		//	LevelPatternDataRow levelPatternDataRow = regulation.levelPatternDtbl[num];
		//	int num2 = level * levelPatternDataRow.hp;
		//	int num3 = level * levelPatternDataRow.atk;
		//	int num4 = level * levelPatternDataRow.def;
		//	int num5 = level * levelPatternDataRow.aim;
		//	int num6 = level * levelPatternDataRow.luck;
		//	maxHealth += num2;
		//	attackDamage += num3;
		//	defense += num4;
		//	accuracy += num5;
		//	luck += num6;
		//	string text2 = string.Format("{0}_{1}", (marry != 1) ? classPattern : afterClassPattern, cls);
		//	int num7 = regulation.classPatternDtbl.FindIndex(text2);
		//	if (num7 == -1)
		//	{
		//		return;
		//	}
		//	ClassPatternDataRow classPatternDataRow = regulation.classPatternDtbl[num7];
		//	maxHealth += classPatternDataRow.hp;
		//	attackDamage += classPatternDataRow.atk;
		//	defense += classPatternDataRow.def;
		//	accuracy += classPatternDataRow.aim;
		//	luck += classPatternDataRow.luck;
		//	originAttackDamage = attackDamage;
		//	originDefense = defense;
		//	originAccuracy = accuracy;
		//	originCriticalChance = criticalChance;
		//	originCriticalDamageBonus = criticalDamage;
		//	originSpeed = speed;
		//	originLuck = luck;
		//	originMaxHealth = maxHealth;
		//	if (EquipItem != null && EquipItem.Count > 0)
		//	{
		//		foreach (KeyValuePair<int, RoItem> keyValuePair in EquipItem)
		//		{
		//			switch (keyValuePair.Value.statType)
		//			{
		//			case EItemStatType.ATK:
		//				attackDamage += keyValuePair.Value.statPoint;
		//				break;
		//			case EItemStatType.DEF:
		//				defense += keyValuePair.Value.statPoint;
		//				break;
		//			case EItemStatType.ACCUR:
		//				accuracy += keyValuePair.Value.statPoint;
		//				break;
		//			case EItemStatType.LUCK:
		//				luck += keyValuePair.Value.statPoint;
		//				break;
		//			}
		//		}
		//	}
		//	if (transcendence != null)
		//	{
		//		int num8 = 0;
		//		for (int i = 0; i < transcendence.Count; i++)
		//		{
		//			TranscendenceSlotDataRow transcendenceSlotDataRow = regulation.FindTranscendenceSlot(i + 1);
		//			if (transcendenceSlotDataRow != null)
		//			{
		//				if (transcendenceSlotDataRow.stat == StatType.ATK)
		//				{
		//					attackDamage += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.DEF)
		//				{
		//					defense += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.HP)
		//				{
		//					maxHealth += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.ACCUR)
		//				{
		//					accuracy += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.LUCK)
		//				{
		//					luck += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.CRITR)
		//				{
		//					criticalChance += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.CRITDMG)
		//				{
		//					criticalDamage += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//				else if (transcendenceSlotDataRow.stat == StatType.MOB)
		//				{
		//					speed += transcendence[i] * transcendenceSlotDataRow.addStat;
		//				}
		//			}
		//			num8 += transcendence[i];
		//		}
		//		maxHealth += AddTranscendenceHealth(num8);
		//	}
		//	CommanderCostumeDataRow commanderCostumeDataRow = regulation.FindCostumeData(costume);
		//	if (commanderCostumeDataRow != null)
		//	{
		//		if (commanderCostumeDataRow.statType1 == StatType.ATK)
		//		{
		//			attackDamage += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.DEF)
		//		{
		//			defense += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.HP)
		//		{
		//			maxHealth += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.ACCUR)
		//		{
		//			accuracy += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.LUCK)
		//		{
		//			luck += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.CRITR)
		//		{
		//			criticalChance += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.CRITDMG)
		//		{
		//			criticalDamage += commanderCostumeDataRow.stat1;
		//		}
		//		else if (commanderCostumeDataRow.statType1 == StatType.MOB)
		//		{
		//			speed += commanderCostumeDataRow.stat1;
		//		}
		//		if (commanderCostumeDataRow.statType2 == StatType.ATK)
		//		{
		//			attackDamage += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.DEF)
		//		{
		//			defense += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.HP)
		//		{
		//			maxHealth += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.ACCUR)
		//		{
		//			accuracy += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.LUCK)
		//		{
		//			luck += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.CRITR)
		//		{
		//			criticalChance += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.CRITDMG)
		//		{
		//			criticalDamage += commanderCostumeDataRow.stat2;
		//		}
		//		else if (commanderCostumeDataRow.statType2 == StatType.MOB)
		//		{
		//			speed += commanderCostumeDataRow.stat2;
		//		}
		//		if (commanderCostumeDataRow.statType3 == StatType.ATK)
		//		{
		//			attackDamage += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.DEF)
		//		{
		//			defense += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.HP)
		//		{
		//			maxHealth += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.ACCUR)
		//		{
		//			accuracy += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.LUCK)
		//		{
		//			luck += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.CRITR)
		//		{
		//			criticalChance += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.CRITDMG)
		//		{
		//			criticalDamage += commanderCostumeDataRow.stat3;
		//		}
		//		else if (commanderCostumeDataRow.statType3 == StatType.MOB)
		//		{
		//			speed += commanderCostumeDataRow.stat3;
		//		}
		//	}
		//	if (isSetItem)
		//	{
		//		EquipItemDataRow equipItemDataRow = regulation.equipItemDtbl.Find((EquipItemDataRow row) => row.key == EquipItem[1].id);
		//		switch (equipItemDataRow.setItemType)
		//		{
		//		case EItemSetType.ATK:
		//			attackDamage += equipItemDataRow.statEffect;
		//			break;
		//		case EItemSetType.DEF:
		//			defense += equipItemDataRow.statEffect;
		//			break;
		//		case EItemSetType.ACCUR:
		//			accuracy += equipItemDataRow.statEffect;
		//			break;
		//		case EItemSetType.LUCK:
		//			luck += equipItemDataRow.statEffect;
		//			break;
		//		case EItemSetType.CRITR:
		//			criticalChance += equipItemDataRow.statEffect;
		//			break;
		//		case EItemSetType.CRITDMG:
		//			criticalDamage += equipItemDataRow.statEffect;
		//			break;
		//		}
		//	}
		//	int num9 = 0;
		//	string weaponSetType = string.Empty;
		//	if (weaponItem != null && weaponItem.Count > 0)
		//	{
		//		foreach (RoWeapon roWeapon in weaponItem.Values)
		//		{
		//			if (roWeapon != null)
		//			{
		//				int num10 = 100;
		//				if (roWeapon.data.slotType == 1)
		//				{
		//					num10 = partHead;
		//				}
		//				else if (roWeapon.data.slotType == 2)
		//				{
		//					num10 = partRightHand;
		//				}
		//				else if (roWeapon.data.slotType == 3)
		//				{
		//					num10 = partLeftHand;
		//				}
		//				else if (roWeapon.data.slotType == 4)
		//				{
		//					num10 = partBody;
		//				}
		//				else if (roWeapon.data.slotType == 5)
		//				{
		//					num10 = partSpecial;
		//				}
		//				foreach (KeyValuePair<EItemStatType, int> keyValuePair2 in roWeapon.addStatPoint)
		//				{
		//					switch (keyValuePair2.Key)
		//					{
		//					case EItemStatType.ATK:
		//						attackDamage += keyValuePair2.Value * num10 / 100;
		//						break;
		//					case EItemStatType.DEF:
		//						defense += keyValuePair2.Value * num10 / 100;
		//						break;
		//					case EItemStatType.ACCUR:
		//						accuracy += keyValuePair2.Value * num10 / 100;
		//						break;
		//					case EItemStatType.LUCK:
		//						luck += keyValuePair2.Value * num10 / 100;
		//						break;
		//					case EItemStatType.CRITDMG:
		//						criticalDamage += keyValuePair2.Value * num10 / 100;
		//						break;
		//					case EItemStatType.MOB:
		//						speed += keyValuePair2.Value * num10 / 100;
		//						break;
		//					}
		//				}
		//				if (roWeapon.data.weaponSetType != "0")
		//				{
		//					if (roWeapon.data.weaponSetType != weaponSetType)
		//					{
		//						num9 = 1;
		//						weaponSetType = roWeapon.data.weaponSetType;
		//					}
		//					else
		//					{
		//						num9++;
		//					}
		//				}
		//			}
		//		}
		//	}
		//	if (num9 == 5 && isWeaponSet)
		//	{
		//		WeaponSetDataRow weaponSetDataRow = regulation.weaponSetDtbl.Find((WeaponSetDataRow row) => row.type == weaponSetType);
		//		if (weaponSetDataRow != null)
		//		{
		//			switch (weaponSetDataRow.weaponSetStatType)
		//			{
		//			case EItemSetType.ATK:
		//				attackDamage += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			case EItemSetType.DEF:
		//				defense += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			case EItemSetType.ACCUR:
		//				accuracy += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			case EItemSetType.LUCK:
		//				luck += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			case EItemSetType.CRITR:
		//				criticalChance += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			case EItemSetType.CRITDMG:
		//				criticalDamage += weaponSetDataRow.weaponSetStatAddPoint;
		//				break;
		//			}
		//		}
		//	}
		//	if (!string.IsNullOrEmpty(commanderId))
		//	{
		//		List<FavorDataRow> list = regulation.favorDtbl.FindAll((FavorDataRow row) => row.cid == int.Parse(commanderId) && row.step <= favorRewardStep);
		//		if (list != null)
		//		{
		//			foreach (FavorDataRow favorDataRow in list)
		//			{
		//				if (favorDataRow.statType == StatType.ATK)
		//				{
		//					attackDamage += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.DEF)
		//				{
		//					defense += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.HP)
		//				{
		//					maxHealth += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.ACCUR)
		//				{
		//					accuracy += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.LUCK)
		//				{
		//					luck += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.CRITR)
		//				{
		//					criticalChance += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.CRITDMG)
		//				{
		//					criticalDamage += favorDataRow.stat;
		//				}
		//				else if (favorDataRow.statType == StatType.MOB)
		//				{
		//					speed += favorDataRow.stat;
		//				}
		//			}
		//		}
		//	}
		//	if (battleType == EBattleType.Undefined)
		//	{
		//		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		//		if (localUser.IsExistGuild() && localUser.guildInfo.idx != 0)
		//		{
		//			foreach (RoGuildSkill roGuildSkill in localUser.guildSkillList)
		//			{
		//				if (roGuildSkill.idx == 1)
		//				{
		//					attackDamage += attackDamage * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 2)
		//				{
		//					defense += defense * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 3)
		//				{
		//					maxHealth += maxHealth * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 4)
		//				{
		//					accuracy += accuracy * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 5)
		//				{
		//					luck += luck * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 6)
		//				{
		//					criticalChance += criticalChance * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 7)
		//				{
		//					criticalDamage += criticalDamage * roGuildSkill.reg.value / 100;
		//				}
		//				else if (roGuildSkill.idx == 8)
		//				{
		//					speed += roGuildSkill.reg.value;
		//				}
		//				else if (roGuildSkill.idx != 9)
		//				{
		//					if (roGuildSkill.idx == 10)
		//					{
		//					}
		//				}
		//			}
		//		}
		//	}
		//	if (battleType == EBattleType.Duel || battleType == EBattleType.WaveDuel || battleType == EBattleType.WorldDuel)
		//	{
		//		RoLocalUser localUser2 = RemoteObjectManager.instance.localUser;
		//		if (RemoteObjectManager.instance.localUser.duelTargetList.ContainsKey(localUser2.duelTargetIdx))
		//		{
		//			RoUser roUser = RemoteObjectManager.instance.localUser.duelTargetList[localUser2.duelTargetIdx];
		//			if (roUser != null)
		//			{
		//				foreach (RoGuildSkill roGuildSkill2 in roUser.guildSkillList)
		//				{
		//					if (roGuildSkill2.idx == 1)
		//					{
		//						attackDamage += attackDamage * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 2)
		//					{
		//						defense += defense * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 3)
		//					{
		//						maxHealth += maxHealth * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 4)
		//					{
		//						accuracy += accuracy * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 5)
		//					{
		//						luck += luck * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 6)
		//					{
		//						criticalChance += criticalChance * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 7)
		//					{
		//						criticalDamage += criticalDamage * roGuildSkill2.reg.value / 100;
		//					}
		//					else if (roGuildSkill2.idx == 8)
		//					{
		//						speed += roGuildSkill2.reg.value;
		//					}
		//					else if (roGuildSkill2.idx != 9)
		//					{
		//						if (roGuildSkill2.idx == 10)
		//						{
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}
		//	if (battleType == EBattleType.Undefined)
		//	{
		//		RoLocalUser localUser3 = RemoteObjectManager.instance.localUser;
		//		if (localUser3.completeRewardGroupList != null)
		//		{
		//			using (List<int>.Enumerator enumerator7 = localUser3.completeRewardGroupList.GetEnumerator())
		//			{
		//				while (enumerator7.MoveNext())
		//				{
		//					int group2 = enumerator7.Current;
		//					bool flag = false;
		//					GroupInfoDataRow groupInfoDataRow = Utility.regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => data.groupIdx == group2.ToString() && data.rewardType >= ERewardType.GroupEff_1 && data.rewardType <= ERewardType.GroupEff_8);
		//					if (groupInfoDataRow != null)
		//					{
		//						if (groupInfoDataRow.rewardIdx == 1001)
		//						{
		//							if (job == EJob.Attack)
		//							{
		//								flag = true;
		//							}
		//						}
		//						else if (groupInfoDataRow.rewardIdx == 1002)
		//						{
		//							if (job == EJob.Defense)
		//							{
		//								flag = true;
		//							}
		//						}
		//						else if (groupInfoDataRow.rewardIdx == 1003)
		//						{
		//							if (job == EJob.Support)
		//							{
		//								flag = true;
		//							}
		//						}
		//						else if (groupInfoDataRow.rewardIdx == 1004)
		//						{
		//							GroupMemberDataRow groupMemberDataRow = RUtility.regulation.groupMemberDtbl.Find((GroupMemberDataRow row) => row.gidx == group2.ToString() && row.memberType == 1 && row.memberIdx == commanderId);
		//							if (groupMemberDataRow != null)
		//							{
		//								flag = true;
		//							}
		//						}
		//						else if (groupInfoDataRow.rewardIdx == 1005)
		//						{
		//							flag = true;
		//						}
		//						else if (commanderId == groupInfoDataRow.rewardIdx.ToString())
		//						{
		//							flag = true;
		//						}
		//						if (flag)
		//						{
		//							if (groupInfoDataRow.typeIndex == 1)
		//							{
		//								if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
		//								{
		//									attackDamage += attackDamage * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
		//								{
		//									defense += defense * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
		//								{
		//									maxHealth += maxHealth * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
		//								{
		//									accuracy += accuracy * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
		//								{
		//									luck += luck * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
		//								{
		//									criticalChance += criticalChance * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
		//								{
		//									criticalDamage += criticalDamage * groupInfoDataRow.minCount / 100;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
		//								{
		//									speed += speed * groupInfoDataRow.minCount / 100;
		//								}
		//							}
		//							else if (groupInfoDataRow.typeIndex == 2)
		//							{
		//								if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
		//								{
		//									attackDamage += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
		//								{
		//									defense += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
		//								{
		//									maxHealth += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
		//								{
		//									accuracy += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
		//								{
		//									luck += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
		//								{
		//									criticalChance += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
		//								{
		//									criticalDamage += groupInfoDataRow.minCount;
		//								}
		//								else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
		//								{
		//									speed += groupInfoDataRow.minCount;
		//								}
		//							}
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}
		//	if (battleType == EBattleType.Duel || battleType == EBattleType.WaveDuel || battleType == EBattleType.WorldDuel)
		//	{
		//		RoLocalUser localUser4 = RemoteObjectManager.instance.localUser;
		//		if (RemoteObjectManager.instance.localUser.duelTargetList.ContainsKey(localUser4.duelTargetIdx))
		//		{
		//			RoUser roUser2 = RemoteObjectManager.instance.localUser.duelTargetList[localUser4.duelTargetIdx];
		//			if (roUser2 != null && roUser2.completeRewardGroupList != null)
		//			{
		//				using (List<int>.Enumerator enumerator8 = roUser2.completeRewardGroupList.GetEnumerator())
		//				{
		//					while (enumerator8.MoveNext())
		//					{
		//						int group = enumerator8.Current;
		//						bool flag2 = false;
		//						GroupInfoDataRow groupInfoDataRow2 = RUtility.regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => data.groupIdx == group.ToString() && data.rewardType >= ERewardType.GroupEff_1 && data.rewardType <= ERewardType.GroupEff_8);
		//						if (groupInfoDataRow2 != null)
		//						{
		//							if (groupInfoDataRow2.rewardIdx == 1001)
		//							{
		//								if (job == EJob.Attack)
		//								{
		//									flag2 = true;
		//								}
		//							}
		//							else if (groupInfoDataRow2.rewardIdx == 1002)
		//							{
		//								if (job == EJob.Defense)
		//								{
		//									flag2 = true;
		//								}
		//							}
		//							else if (groupInfoDataRow2.rewardIdx == 1003)
		//							{
		//								if (job == EJob.Support)
		//								{
		//									flag2 = true;
		//								}
		//							}
		//							else if (groupInfoDataRow2.rewardIdx == 1004)
		//							{
		//								GroupMemberDataRow groupMemberDataRow2 = RUtility.regulation.groupMemberDtbl.Find((GroupMemberDataRow row) => row.gidx == group.ToString() && row.memberType == 1 && row.memberIdx == commanderId);
		//								if (groupMemberDataRow2 != null)
		//								{
		//									flag2 = true;
		//								}
		//							}
		//							else if (groupInfoDataRow2.rewardIdx == 1005)
		//							{
		//								flag2 = true;
		//							}
		//							else if (commanderId == groupInfoDataRow2.rewardIdx.ToString())
		//							{
		//								flag2 = true;
		//							}
		//							if (flag2)
		//							{
		//								if (groupInfoDataRow2.typeIndex == 1)
		//								{
		//									if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_1)
		//									{
		//										attackDamage += attackDamage * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_2)
		//									{
		//										defense += defense * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_3)
		//									{
		//										maxHealth += maxHealth * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_4)
		//									{
		//										accuracy += accuracy * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_5)
		//									{
		//										luck += luck * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_6)
		//									{
		//										criticalChance += criticalChance * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_7)
		//									{
		//										criticalDamage += criticalDamage * groupInfoDataRow2.minCount / 100;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_8)
		//									{
		//										speed += speed * groupInfoDataRow2.minCount / 100;
		//									}
		//								}
		//								else if (groupInfoDataRow2.typeIndex == 2)
		//								{
		//									if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_1)
		//									{
		//										attackDamage += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_2)
		//									{
		//										defense += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_3)
		//									{
		//										maxHealth += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_4)
		//									{
		//										accuracy += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_5)
		//									{
		//										luck += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_6)
		//									{
		//										criticalChance += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_7)
		//									{
		//										criticalDamage += groupInfoDataRow2.minCount;
		//									}
		//									else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_8)
		//									{
		//										speed += groupInfoDataRow2.minCount;
		//									}
		//								}
		//							}
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}
		//}

		public static UnitDataRow Sum(List<UnitDataRow> unitDataList, bool includeCommanderUnit = false)
		{
			UnitDataRow result = new UnitDataRow();
			unitDataList.ForEach(delegate(UnitDataRow data)
			{
				result.maxHealth += data.maxHealth;
				result.attackDamage += data.attackDamage;
				result.accuracy += data.accuracy;
				result.gold += data.gold;
				result.evasion += data.evasion;
				result.criticalChance += data.criticalChance;
				result.criticalDamage += data.criticalDamage;
				result.reloadSpeed += data.reloadSpeed;
				result.defense += data.defense;
				if (includeCommanderUnit || !data.isCommander)
				{
					result.leadership += data.leadership;
				}
			});
			return result;
		}

		public const int SkillCount = 4;

		public static readonly string PrefabHome = "Assets/Resources/Prefabs/Cache/Units";

		public static readonly string ResourceIdFormat = "Unit-{0:0000}";

		public static readonly string ResourceIdPrefix = "Unit-";

		[JsonProperty("skillDrks")]
		private List<string> _skillDrks;
	}
}
