using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
public class UnitDataRow : DataRow
{
	public const int SkillCount = 4;

	public static readonly string PrefabHome = "Assets/Resources/Prefabs/Cache/Units";

	public static readonly string ResourceIdFormat = "Unit-{0:0000}";

	public static readonly string ResourceIdPrefix = "Unit-";

	[JsonProperty("skillDrks")]
	private List<string> _skillDrks;

	public string key { get; private set; }

	public string nameKey { get; private set; }

	public string prefabId { get; private set; }

	public string resourceName { get; private set; }

	[JsonIgnore]
	public int modelType { get; private set; }

	public string unitSmallIconName => resourceName + "_Small";

	public int maxHealth { get; private set; }

	public int speed { get; private set; }

	public EBranch branch { get; private set; }

	public EUnitType type { get; private set; }

	public EUnitType typeUpper { get; private set; }

	public EUnitType typeDown { get; private set; }

	public int typeBonus { get; private set; }

	public int typeHandicap { get; private set; }

	public bool isCommander => type == EUnitType.Commander;

	public int gold { get; private set; }

	public int leadership { get; private set; }

	public int attackDamage { get; private set; }

	public int defense { get; private set; }

	public int accuracy { get; private set; }

	public int criticalChance { get; private set; }

	public int criticalDamageBonus { get; private set; }

	public int unlockLevel { get; private set; }

	public int luck { get; private set; }

	public bool isHidden => unlockLevel <= 0;

	public string dropGoldPattern { get; private set; }

	public string levelPattern { get; set; }

	public string classPattern { get; set; }

	public string afterLevelPattern { get; set; }

	public string afterClassPattern { get; set; }

	public EJob job { get; private set; }

	public int stateAllImmunity { get; private set; }

	public string explanation { get; private set; }

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
	public IList<string> skillDrks => _skillDrks.AsReadOnly();

	public int originAttackDamage { get; private set; }

	public int originDefense { get; private set; }

	public int originAccuracy { get; private set; }

	public int originCriticalChance { get; private set; }

	public int originCriticalDamageBonus { get; private set; }

	public int originSpeed { get; private set; }

	public int originLuck { get; private set; }

	public int originMaxHealth { get; private set; }

	public int partHead { get; private set; }

	public int partRightHand { get; private set; }

	public int partLeftHand { get; private set; }

	public int partBody { get; private set; }

	public int partSpecial { get; private set; }

	private UnitDataRow()
	{
	}

	public string GetKey()
	{
		return key;
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		Regulation.FillList(ref _skillDrks, 4);
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

	private int AddTranscendenceHealth(int tsdcCount)
	{
		int num = 0;
		if (tsdcCount > 0)
		{
			int num2 = 0;
			int num3 = tsdcCount;
			for (int i = 0; i < Constants.regulation.transcendenceStepUpgradeDtbl.length; i++)
			{
				if (num3 <= 0)
				{
					break;
				}
				TranscendenceStepUpgradeDataRow transcendenceStepUpgradeDataRow = Constants.regulation.transcendenceStepUpgradeDtbl[i];
				int num4 = transcendenceStepUpgradeDataRow.stepPoint - num2;
				int num5 = (num3 >= num4) ? num4 : num3;
				int num6 = num5 / transcendenceStepUpgradeDataRow.statAddMeasure * transcendenceStepUpgradeDataRow.statAddVolume;
				num += num6;
				num3 -= num5;
				num2 = transcendenceStepUpgradeDataRow.stepPoint;
			}
		}
		return num;
	}

	private int CurrentTranscendenceStep(int tsdcCount)
	{
		List<TranscendenceStepUpgradeDataRow> list = Constants.regulation.FindTranscendenceStepUpgradeListPoint(tsdcCount);
		return list.Count;
	}

	//public void InvokeLevel(int rank, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> EquipItem = null, bool isSetItem = false, Dictionary<int, RoWeapon> weaponItem = null, bool isWeaponSet = true)
	//{
	//	Regulation regulation = Constants.regulation;
	//	string text = $"{((marry != 1) ? levelPattern : afterLevelPattern)}_{rank}";
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
	//	string text2 = $"{((marry != 1) ? classPattern : afterClassPattern)}_{cls}";
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
	//		foreach (KeyValuePair<int, RoItem> item in EquipItem)
	//		{
	//			switch (item.Value.statType)
	//			{
	//				case EItemStatType.ATK:
	//					attackDamage += item.Value.statPoint;
	//					break;
	//				case EItemStatType.DEF:
	//					defense += item.Value.statPoint;
	//					break;
	//				case EItemStatType.ACCUR:
	//					accuracy += item.Value.statPoint;
	//					break;
	//				case EItemStatType.LUCK:
	//					luck += item.Value.statPoint;
	//					break;
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
	//				switch (transcendenceSlotDataRow.stat)
	//				{
	//					case StatType.ATK:
 //                           attackDamage += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
 //                       case StatType.DEF:
 //                           defense += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
	//					case StatType.HP:
 //                           maxHealth += transcendence[i] * transcendenceSlotDataRow.addStat;
	//						break;
 //                       case StatType.ACCUR:
 //                           accuracy += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
	//					case StatType.LUCK:
 //                           luck += transcendence[i] * transcendenceSlotDataRow.addStat;
	//						break;
 //                       case StatType.CRITR:
 //                           criticalChance += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
 //                       case StatType.CRITDMG:
 //                           criticalDamage += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
 //                       case StatType.MOB:
 //                           speed += transcendence[i] * transcendenceSlotDataRow.addStat;
 //                           break;
	//				}
	//			}
	//			num8 += transcendence[i];
	//		}
	//		maxHealth += AddTranscendenceHealth(num8);
	//	}
	//	CommanderCostumeDataRow commanderCostumeDataRow = regulation.FindCostumeData(costume);
	//	if (commanderCostumeDataRow != null)
	//	{
 //           switch (commanderCostumeDataRow.statType1)
 //           {
 //               case StatType.ATK:
 //                   attackDamage += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.DEF:
 //                   defense += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.HP:
	//				maxHealth += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.ACCUR:
 //                   accuracy += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.LUCK:
 //                   luck += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.CRITR:
 //                   criticalChance += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.CRITDMG:
 //                   criticalDamage += commanderCostumeDataRow.stat1;
 //                   break;
 //               case StatType.MOB:
 //                   speed += commanderCostumeDataRow.stat1;
 //                   break;
 //           }

 //           switch (commanderCostumeDataRow.statType2)
 //           {
 //               case StatType.ATK:
 //                   attackDamage += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.DEF:
 //                   defense += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.HP:
 //                   maxHealth += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.ACCUR:
 //                   accuracy += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.LUCK:
 //                   luck += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.CRITR:
 //                   criticalChance += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.CRITDMG:
 //                   criticalDamage += commanderCostumeDataRow.stat2;
 //                   break;
 //               case StatType.MOB:
 //                   speed += commanderCostumeDataRow.stat2;
 //                   break;
 //           }

 //           switch (commanderCostumeDataRow.statType3)
 //           {
 //               case StatType.ATK:
 //                   attackDamage += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.DEF:
 //                   defense += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.HP:
 //                   maxHealth += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.ACCUR:
 //                   accuracy += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.LUCK:
 //                   luck += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.CRITR:
 //                   criticalChance += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.CRITDMG:
 //                   criticalDamage += commanderCostumeDataRow.stat3;
 //                   break;
 //               case StatType.MOB:
 //                   speed += commanderCostumeDataRow.stat3;
 //                   break;	
 //           }

 //       }
	//	if (isSetItem)
	//	{
	//		EquipItemDataRow equipItemDataRow = regulation.equipItemDtbl.Find((EquipItemDataRow row) => row.key == EquipItem[1].id);
	//		switch (equipItemDataRow.setItemType)
	//		{
	//			case EItemSetType.ATK:
	//				attackDamage += equipItemDataRow.statEffect;
	//				break;
	//			case EItemSetType.DEF:
	//				defense += equipItemDataRow.statEffect;
	//				break;
	//			case EItemSetType.ACCUR:
	//				accuracy += equipItemDataRow.statEffect;
	//				break;
	//			case EItemSetType.LUCK:
	//				luck += equipItemDataRow.statEffect;
	//				break;
	//			case EItemSetType.CRITR:
	//				criticalChance += equipItemDataRow.statEffect;
	//				break;
	//			case EItemSetType.CRITDMG:
	//				criticalDamage += equipItemDataRow.statEffect;
	//				break;
	//		}
	//	}
	//	int num9 = 0;
	//	string weaponSetType = string.Empty;
	//	if (weaponItem != null && weaponItem.Count > 0)
	//	{
	//		foreach (RoWeapon value in weaponItem.Values)
	//		{
	//			if (value == null)
	//			{
	//				continue;
	//			}
	//			int num10 = 100;
	//			if (value.data.slotType == 1)
	//			{
	//				num10 = partHead;
	//			}
	//			else if (value.data.slotType == 2)
	//			{
	//				num10 = partRightHand;
	//			}
	//			else if (value.data.slotType == 3)
	//			{
	//				num10 = partLeftHand;
	//			}
	//			else if (value.data.slotType == 4)
	//			{
	//				num10 = partBody;
	//			}
	//			else if (value.data.slotType == 5)
	//			{
	//				num10 = partSpecial;
	//			}
	//			foreach (KeyValuePair<EItemStatType, int> item2 in value.addStatPoint)
	//			{
	//				switch (item2.Key)
	//				{
	//					case EItemStatType.ATK:
	//						attackDamage += item2.Value * num10 / 100;
	//						break;
	//					case EItemStatType.DEF:
	//						defense += item2.Value * num10 / 100;
	//						break;
	//					case EItemStatType.ACCUR:
	//						accuracy += item2.Value * num10 / 100;
	//						break;
	//					case EItemStatType.LUCK:
	//						luck += item2.Value * num10 / 100;
	//						break;
	//					case EItemStatType.MOB:
	//						speed += item2.Value * num10 / 100;
	//						break;
	//					case EItemStatType.CRITDMG:
	//						criticalDamage += item2.Value * num10 / 100;
	//						break;
	//				}
	//			}
	//			if (value.data.weaponSetType != "0")
	//			{
	//				if (value.data.weaponSetType != weaponSetType)
	//				{
	//					num9 = 1;
	//					weaponSetType = value.data.weaponSetType;
	//				}
	//				else
	//				{
	//					num9++;
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
	//				case EItemSetType.ATK:
	//					attackDamage += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//				case EItemSetType.DEF:
	//					defense += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//				case EItemSetType.ACCUR:
	//					accuracy += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//				case EItemSetType.LUCK:
	//					luck += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//				case EItemSetType.CRITR:
	//					criticalChance += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//				case EItemSetType.CRITDMG:
	//					criticalDamage += weaponSetDataRow.weaponSetStatAddPoint;
	//					break;
	//			}
	//		}
	//	}

	//	if (!string.IsNullOrEmpty(commanderId))
	//	{
	//		List<FavorDataRow> list = regulation.favorDtbl.FindAll((FavorDataRow row) => row.cid == int.Parse(commanderId) && row.step <= favorRewardStep);
	//		if (list != null)
	//		{
	//			foreach (FavorDataRow item3 in list)
	//			{
	//				if (item3.statType == StatType.ATK)
	//				{
	//					attackDamage += item3.stat;
	//				}
	//				else if (item3.statType == StatType.DEF)
	//				{
	//					defense += item3.stat;
	//				}
	//				else if (item3.statType == StatType.HP)
	//				{
	//					maxHealth += item3.stat;
	//				}
	//				else if (item3.statType == StatType.ACCUR)
	//				{
	//					accuracy += item3.stat;
	//				}
	//				else if (item3.statType == StatType.LUCK)
	//				{
	//					luck += item3.stat;
	//				}
	//				else if (item3.statType == StatType.CRITR)
	//				{
	//					criticalChance += item3.stat;
	//				}
	//				else if (item3.statType == StatType.CRITDMG)
	//				{
	//					criticalDamage += item3.stat;
	//				}
	//				else if (item3.statType == StatType.MOB)
	//				{
	//					speed += item3.stat;
	//				}
	//			}
	//		}
	//	}

	//	if (battleType == EBattleType.Undefined)
	//	{
	//		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//		if (localUser.IsExistGuild() && localUser.guildInfo.idx != 0)
	//		{
	//			foreach (RoGuildSkill guildSkill in localUser.guildSkillList)
	//			{
	//				if (guildSkill.idx == 1)
	//				{
	//					attackDamage += attackDamage * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 2)
	//				{
	//					defense += defense * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 3)
	//				{
	//					maxHealth += maxHealth * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 4)
	//				{
	//					accuracy += accuracy * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 5)
	//				{
	//					luck += luck * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 6)
	//				{
	//					criticalChance += criticalChance * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 7)
	//				{
	//					criticalDamage += criticalDamage * guildSkill.reg.value / 100;
	//				}
	//				else if (guildSkill.idx == 8)
	//				{
	//					speed += guildSkill.reg.value;
	//				}
	//				else if (guildSkill.idx != 9 && guildSkill.idx != 10)
	//				{
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
	//				foreach (RoGuildSkill guildSkill2 in roUser.guildSkillList)
	//				{
	//					if (guildSkill2.idx == 1)
	//					{
	//						attackDamage += attackDamage * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 2)
	//					{
	//						defense += defense * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 3)
	//					{
	//						maxHealth += maxHealth * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 4)
	//					{
	//						accuracy += accuracy * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 5)
	//					{
	//						luck += luck * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 6)
	//					{
	//						criticalChance += criticalChance * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 7)
	//					{
	//						criticalDamage += criticalDamage * guildSkill2.reg.value / 100;
	//					}
	//					else if (guildSkill2.idx == 8)
	//					{
	//						speed += guildSkill2.reg.value;
	//					}
	//					else if (guildSkill2.idx != 9 && guildSkill2.idx != 10)
	//					{
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
	//			foreach (int group2 in localUser3.completeRewardGroupList)
	//			{
	//				bool flag = false;
	//				GroupInfoDataRow groupInfoDataRow = Constants.regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => data.groupIdx == group2.ToString() && data.rewardType >= ERewardType.GroupEff_1 && data.rewardType <= ERewardType.GroupEff_8);
	//				if (groupInfoDataRow == null)
	//				{
	//					continue;
	//				}
	//				if (groupInfoDataRow.rewardIdx == 1001)
	//				{
	//					if (job == EJob.Attack)
	//					{
	//						flag = true;
	//					}
	//				}
	//				else if (groupInfoDataRow.rewardIdx == 1002)
	//				{
	//					if (job == EJob.Defense)
	//					{
	//						flag = true;
	//					}
	//				}
	//				else if (groupInfoDataRow.rewardIdx == 1003)
	//				{
	//					if (job == EJob.Support)
	//					{
	//						flag = true;
	//					}
	//				}
	//				else if (groupInfoDataRow.rewardIdx == 1004)
	//				{
	//					GroupMemberDataRow groupMemberDataRow = Constants.regulation.groupMemberDtbl.Find((GroupMemberDataRow row) => row.gidx == group2.ToString() && row.memberType == 1 && row.memberIdx == commanderId);
	//					if (groupMemberDataRow != null)
	//					{
	//						flag = true;
	//					}
	//				}
	//				else if (groupInfoDataRow.rewardIdx == 1005)
	//				{
	//					flag = true;
	//				}
	//				else if (commanderId == groupInfoDataRow.rewardIdx.ToString())
	//				{
	//					flag = true;
	//				}
	//				if (!flag)
	//				{
	//					continue;
	//				}
	//				if (groupInfoDataRow.typeIndex == 1)
	//				{
	//					if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
	//					{
	//						attackDamage += attackDamage * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
	//					{
	//						defense += defense * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
	//					{
	//						maxHealth += maxHealth * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
	//					{
	//						accuracy += accuracy * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
	//					{
	//						luck += luck * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
	//					{
	//						criticalChance += criticalChance * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
	//					{
	//						criticalDamage += criticalDamage * groupInfoDataRow.minCount / 100;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
	//					{
	//						speed += speed * groupInfoDataRow.minCount / 100;
	//					}
	//				}
	//				else if (groupInfoDataRow.typeIndex == 2)
	//				{
	//					if (groupInfoDataRow.rewardType == ERewardType.GroupEff_1)
	//					{
	//						attackDamage += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_2)
	//					{
	//						defense += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_3)
	//					{
	//						maxHealth += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_4)
	//					{
	//						accuracy += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_5)
	//					{
	//						luck += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_6)
	//					{
	//						criticalChance += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_7)
	//					{
	//						criticalDamage += groupInfoDataRow.minCount;
	//					}
	//					else if (groupInfoDataRow.rewardType == ERewardType.GroupEff_8)
	//					{
	//						speed += groupInfoDataRow.minCount;
	//					}
	//				}
	//			}
	//		}
	//	}

	//	if (battleType != EBattleType.Duel && battleType != EBattleType.WaveDuel && battleType != EBattleType.WorldDuel)
	//	{
	//		return;
	//	}
	//	RoLocalUser localUser4 = RemoteObjectManager.instance.localUser;
	//	if (!RemoteObjectManager.instance.localUser.duelTargetList.ContainsKey(localUser4.duelTargetIdx))
	//	{
	//		return;
	//	}
	//	RoUser roUser2 = RemoteObjectManager.instance.localUser.duelTargetList[localUser4.duelTargetIdx];
	//	if (roUser2 == null || roUser2.completeRewardGroupList == null)
	//	{
	//		return;
	//	}
	//	foreach (int group in roUser2.completeRewardGroupList)
	//	{
	//		bool flag2 = false;
	//		GroupInfoDataRow groupInfoDataRow2 = Constants.regulation.groupInfoDtbl.Find((GroupInfoDataRow data) => data.groupIdx == group.ToString() && data.rewardType >= ERewardType.GroupEff_1 && data.rewardType <= ERewardType.GroupEff_8);
	//		if (groupInfoDataRow2 == null)
	//		{
	//			continue;
	//		}
	//		if (groupInfoDataRow2.rewardIdx == 1001)
	//		{
	//			if (job == EJob.Attack)
	//			{
	//				flag2 = true;
	//			}
	//		}
	//		else if (groupInfoDataRow2.rewardIdx == 1002)
	//		{
	//			if (job == EJob.Defense)
	//			{
	//				flag2 = true;
	//			}
	//		}
	//		else if (groupInfoDataRow2.rewardIdx == 1003)
	//		{
	//			if (job == EJob.Support)
	//			{
	//				flag2 = true;
	//			}
	//		}
	//		else if (groupInfoDataRow2.rewardIdx == 1004)
	//		{
	//			GroupMemberDataRow groupMemberDataRow2 = Constants.regulation.groupMemberDtbl.Find((GroupMemberDataRow row) => row.gidx == group.ToString() && row.memberType == 1 && row.memberIdx == commanderId);
	//			if (groupMemberDataRow2 != null)
	//			{
	//				flag2 = true;
	//			}
	//		}
	//		else if (groupInfoDataRow2.rewardIdx == 1005)
	//		{
	//			flag2 = true;
	//		}
	//		else if (commanderId == groupInfoDataRow2.rewardIdx.ToString())
	//		{
	//			flag2 = true;
	//		}
	//		if (!flag2)
	//		{
	//			continue;
	//		}
	//		if (groupInfoDataRow2.typeIndex == 1)
	//		{
	//			if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_1)
	//			{
	//				attackDamage += attackDamage * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_2)
	//			{
	//				defense += defense * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_3)
	//			{
	//				maxHealth += maxHealth * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_4)
	//			{
	//				accuracy += accuracy * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_5)
	//			{
	//				luck += luck * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_6)
	//			{
	//				criticalChance += criticalChance * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_7)
	//			{
	//				criticalDamage += criticalDamage * groupInfoDataRow2.minCount / 100;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_8)
	//			{
	//				speed += speed * groupInfoDataRow2.minCount / 100;
	//			}
	//		}
	//		else if (groupInfoDataRow2.typeIndex == 2)
	//		{
	//			if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_1)
	//			{
	//				attackDamage += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_2)
	//			{
	//				defense += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_3)
	//			{
	//				maxHealth += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_4)
	//			{
	//				accuracy += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_5)
	//			{
	//				luck += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_6)
	//			{
	//				criticalChance += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_7)
	//			{
	//				criticalDamage += groupInfoDataRow2.minCount;
	//			}
	//			else if (groupInfoDataRow2.rewardType == ERewardType.GroupEff_8)
	//			{
	//				speed += groupInfoDataRow2.minCount;
	//			}
	//		}
	//	}
	//}

	public static UnitDataRow Sum(List<UnitDataRow> unitDataList, bool includeCommanderUnit = false)
	{
		UnitDataRow result = new();
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
}
