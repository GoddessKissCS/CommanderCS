using System;
using System.Collections.Generic;
using GPresto.Protector.Variables;
using Newtonsoft.Json;
using Shared;
using Shared.Regulation;
using UnityEngine;

[JsonObject]
public class RoCommander
{
	public RoCommander()
	{
		skillList = new List<int>();
		for (int i = 0; i < 5; i++)
		{
			skillList.Add(1);
		}
	}

	public string id
	{
		get
		{
			return _id;
		}
		set
		{
			if (_id != value)
			{
				_id = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public GPInt level
	{
		get
		{
			return _level;
		}
		set
		{
			if (_level != value)
			{
				_level = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public GPInt cls
	{
		get
		{
			return _cls;
		}
		set
		{
			if (_cls != value)
			{
				_cls = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public GPInt exp
	{
		get
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(level);
			return aExp - commanderLevelDataRow.aexp;
		}
	}

	public GPInt aExp
	{
		get
		{
			return _aExp;
		}
		set
		{
			_aExp = value;
			Regulation regulation = RemoteObjectManager.instance.regulation;
			level = regulation.FindLevel(_aExp);
		}
	}

	public GPInt maxExp
	{
		get
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(level);
			CommanderLevelDataRow commanderLevelDataRow2 = regulation.GetCommanderLevelDataRow(level + 1);
			return commanderLevelDataRow2.aexp - commanderLevelDataRow.aexp;
		}
	}

	public GPInt rank
	{
		get
		{
			return _rank;
		}
		set
		{
			if (_rank != value)
			{
				_rank = value;
				currLevelUnitReg = null;
			}
		}
	}

	public GPInt sp
	{
		get
		{
			return _sp;
		}
		set
		{
			_sp = value;
		}
	}

	public bool isAdvancePossible
	{
		get
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			int num = int.Parse(regulation.defineDtbl["ANNIHILATE_PILOT_CLASS_LIMIT"].value);
			return cls >= num;
		}
	}

	public GPInt maxSp
	{
		get
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			SkillDataRow skillDataRow = regulation.skillDtbl[unitReg.skillDrks[1]];
			return skillDataRow.maxSp;
		}
	}

	public GPInt hp
	{
		get
		{
			return currLevelUnitReg.maxHealth - dmgHp;
		}
	}

	public GPInt dmgHp { get; set; }

	public TimeData rankUpTime { get; set; }

	public UnitDataRow currLevelUnitReg
	{
		get
		{
			if (_currLevelUnitReg == null)
			{
				_currLevelUnitReg = RoCommander.InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, EquipItem, completeSetItemEquip, WeaponItem, true);
			}
			return _currLevelUnitReg;
		}
		private set
		{
			_currLevelUnitReg = value;
		}
	}

	public void DeleteCurrLevelUnitReg()
	{
		if (_currLevelUnitReg != null)
		{
			_currLevelUnitReg = null;
		}
	}

	public UnitDataRow unitReg
	{
		get
		{
			if (_unitReg == null)
			{
				if (string.IsNullOrEmpty(unitId))
				{
					return null;
				}
				DataTable<UnitDataRow> unitDtbl = RemoteObjectManager.instance.regulation.unitDtbl;
				if (!unitDtbl.ContainsKey(unitId))
				{
					return null;
				}
				_unitReg = unitDtbl[unitId];
			}
			return _unitReg;
		}
		private set
		{
			_unitReg = value;
		}
	}

	public CommanderDataRow reg
	{
		get
		{
			DataTable<CommanderDataRow> commanderDtbl = RemoteObjectManager.instance.regulation.commanderDtbl;
			if (!commanderDtbl.ContainsKey(id))
			{
				return null;
			}
			return commanderDtbl[id];
		}
	}

	public EBranch branch
	{
		get
		{
			return unitReg.branch;
		}
	}

	public EJob job
	{
		get
		{
			return unitReg.job;
		}
	}

	public string unitId
	{
		get
		{
			return reg.unitId;
		}
	}

	public string nickname
	{
		get
		{
			return reg.nickname;
		}
	}

	public GPInt leadership
	{
		get
		{
			int num = 0;
			for (int i = 1; i < level; i++)
			{
				CommanderLevelDataRow commanderLevelDataRow = RemoteObjectManager.instance.regulation.commanderLevelDtbl[i];
				num += commanderLevelDataRow.AddLeadership;
			}
			return reg.leadership + num;
		}
	}

	public string unitResourceId
	{
		get
		{
			return unitReg.resourceName;
		}
	}

	public string resourceId
	{
		get
		{
			return reg.resourceId;
		}
	}

	public bool npc { get; set; }

	public bool newFace { get; set; }

	public string role { get; set; }

	public bool attacker
	{
		get
		{
			return string.Equals(role, "A");
		}
	}

	public bool defender
	{
		get
		{
			return string.Equals(role, "D");
		}
	}

	public bool scramble
	{
		get
		{
			return string.Equals(role, "S");
		}
	}

	public bool occupation
	{
		get
		{
			return string.Equals(role, "O");
		}
	}

	public bool product
	{
		get
		{
			return string.Equals(role, "P");
		}
	}

	public int GetdispatchGold
	{
		get
		{
			return (int)((float)((level + cls) * rank) / 11f * 60f);
		}
	}

	public float GetdispatchFloatGold
	{
		get
		{
			return (float)((level + cls) * rank) / 11f * 60f;
		}
	}

	public ECommanderState state { get; set; }

	public int medal
	{
		get
		{
			RoLocalUser localUser = RemoteObjectManager.instance.localUser;
			Regulation regulation = RemoteObjectManager.instance.regulation;
			if (state != ECommanderState.Nomal)
			{
				return aMedal;
			}
			return aMedal;
		}
	}

	public int aMedal { get; set; }

	public int maxMedal
	{
		get
		{
			Regulation regulation = RemoteObjectManager.instance.regulation;
			CommanderRankDataRow commanderRankDataRow = regulation.GetCommanderRankDataRow(rank);
			if (state != ECommanderState.Nomal)
			{
				return commanderRankDataRow.medal;
			}
			CommanderRankDataRow commanderRankDataRow2 = regulation.GetCommanderRankDataRow(rank + 1);
			return commanderRankDataRow2.medal - commanderRankDataRow.medal;
		}
	}

	private void InitWeaponItem()
	{
		for (int i = 1; i < 6; i++)
		{
			WeaponItem.Add(i, null);
		}
	}

	public void EquipWeaponItem(RoWeapon weapon)
	{
		int slotType = weapon.data.slotType;
		if (WeaponItem == null)
		{
			WeaponItem = new Dictionary<int, RoWeapon>();
		}
		if (!WeaponItem.ContainsKey(slotType))
		{
			WeaponItem.Add(slotType, null);
		}
		else
		{
			if (WeaponItem[slotType] != null)
			{
				WeaponItem[slotType].DeleteWeapon();
			}
			WeaponItem[slotType] = null;
		}
		WeaponItem[slotType] = weapon;
		weapon.EquipWeapon(id);
		RoCommander.InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem, true);
	}

	public void RemoveWeaponItem(int slotType)
	{
		if (WeaponItem == null && !WeaponItem.ContainsKey(slotType))
		{
			return;
		}
		WeaponItem[slotType].DeleteWeapon();
		WeaponItem[slotType] = null;
		RoCommander.InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem, true);
	}

	public RoWeapon FindWeaponItem(int slotType)
	{
		RoWeapon roWeapon = null;
		if (WeaponItem != null && WeaponItem.ContainsKey(slotType))
		{
			roWeapon = WeaponItem[slotType];
		}
		return roWeapon;
	}

	public bool isEmptyWeapon()
	{
		if (WeaponItem == null && WeaponItem.Count == 0)
		{
			return true;
		}
		foreach (KeyValuePair<int, RoWeapon> keyValuePair in WeaponItem)
		{
			if (keyValuePair.Value != null)
			{
				return false;
			}
		}
		return true;
	}

	public string GetWeaponSkillId(int slotType)
	{
		string text = string.Empty;
		if (WeaponItem.ContainsKey(slotType) && WeaponItem[slotType] != null)
		{
			RoWeapon roWeapon = WeaponItem[slotType];
			if (roWeapon.data.privateWeapon != 0 || roWeapon.data.skillIdx != "0")
			{
				text = roWeapon.data.skillIdx;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			if (slotType == 2)
			{
				text = unitReg.skillDrks[1];
			}
			if (slotType == 3)
			{
				text = unitReg.skillDrks[0];
			}
			if (slotType == 4)
			{
				text = unitReg.skillDrks[2];
			}
			if (slotType == 5)
			{
				text = unitReg.skillDrks[3];
			}
		}
		return text;
	}

	public string GetWeaponOriginalSkillId(int slotType)
	{
		string text = string.Empty;
		if (slotType == 2)
		{
			text = unitReg.skillDrks[1];
		}
		if (slotType == 3)
		{
			text = unitReg.skillDrks[0];
		}
		if (slotType == 4)
		{
			text = unitReg.skillDrks[2];
		}
		if (slotType == 5)
		{
			text = unitReg.skillDrks[3];
		}
		return text;
	}

	public int GetWeaponSkillLevel(int slotType)
	{
		int num = 0;
		if (slotType == 1)
		{
			num = skillList[4];
		}
		else if (slotType == 2)
		{
			num = skillList[1];
		}
		else if (slotType == 3)
		{
			num = skillList[0];
		}
		else if (slotType == 4)
		{
			num = skillList[2];
		}
		else if (slotType == 5)
		{
			num = skillList[3];
		}
		return num;
	}

	public int EnableWeaponSet(string type)
	{
		int num = 0;
		foreach (KeyValuePair<int, RoWeapon> keyValuePair in WeaponItem)
		{
			if (keyValuePair.Value != null)
			{
				if (keyValuePair.Value.data.weaponSetType == type)
				{
					num++;
				}
			}
		}
		return num;
	}

	public bool EnableWeaponSet()
	{
		int num = 0;
		string text = string.Empty;
		foreach (RoWeapon roWeapon in WeaponItem.Values)
		{
			if (roWeapon != null)
			{
				if (roWeapon.data.weaponSetType != "0")
				{
					if (roWeapon.data.weaponSetType != text)
					{
						num = 1;
						text = roWeapon.data.weaponSetType;
					}
					else
					{
						num++;
					}
				}
			}
		}
		return num == 5;
	}

	public void SetEquipItem(int pointType, RoItem item)
	{
		if (EquipItem == null)
		{
			EquipItem = new Dictionary<int, RoItem>();
		}
		if (!EquipItem.ContainsKey(pointType))
		{
			EquipItem.Add(pointType, item);
		}
		else
		{
			EquipItem[pointType] = item;
		}
		RoCommander.InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem, true);
	}

	public void ClearEquipItem(int pointType, RoItem item)
	{
		if (EquipItem == null)
		{
			return;
		}
		if (EquipItem.ContainsKey(pointType))
		{
			EquipItem[pointType].isEquip = false;
			EquipItem[pointType].currEquipCommanderId = string.Empty;
			EquipItem.Remove(pointType);
		}
		RoCommander.InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem, true);
	}

	public RoItem FindEquipItem(int pointType)
	{
		if (EquipItem == null)
		{
			return null;
		}
		if (EquipItem.ContainsKey(pointType))
		{
			return EquipItem[pointType];
		}
		return null;
	}

	public bool completeSetItemEquip
	{
		get
		{
			return EquipItem != null && EquipItem.Count == 4 && (EquipItem[1].setType == EquipItem[2].setType && EquipItem[2].setType == EquipItem[3].setType) && EquipItem[3].setType == EquipItem[4].setType;
		}
	}

	public bool checkCompleteSetItem(EItemSetType setType)
	{
		if (EquipItem == null)
		{
			return false;
		}
		if (EquipItem.Count == 3)
		{
			using (Dictionary<int, RoItem>.Enumerator enumerator = EquipItem.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, RoItem> keyValuePair = enumerator.Current;
					if (setType != keyValuePair.Value.setType)
					{
						return false;
					}
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public Dictionary<int, RoItem> GetEquipItemList()
	{
		return EquipItem;
	}

	public bool isBasicCostume
	{
		get
		{
			return PlayerPrefs.HasKey(id);
		}
	}

	public string currentViewCostume
	{
		get
		{
			if (isBasicCostume)
			{
				return PlayerPrefs.GetString(id);
			}
			return currentCostume.ToString();
		}
	}

	public void SetBasicCostumeKey(string ctid)
	{
		if (!PlayerPrefs.HasKey(id))
		{
			CommanderCostumeDataRow commanderCostumeDataRow = RemoteObjectManager.instance.regulation.FindCostumeData(int.Parse(ctid));
			if (commanderCostumeDataRow != null)
			{
				PlayerPrefs.SetString(id, commanderCostumeDataRow.skinName);
			}
		}
	}

	public void Die()
	{
		isDie = true;
		dmgHp = currLevelUnitReg.maxHealth;
	}

	public void SetSp(float fer)
	{
		sp = (int)((float)maxSp * fer * 0.01f);
	}

	public List<int> skillList { get; set; }

	public static RoCommander Create(string id, int level, int rank, int cls, int costume, int favorRewardStep, int marry, List<int> transcendence, string role = "N")
	{
		return new RoCommander
		{
			id = id,
			level = level,
			rank = rank,
			cls = cls,
			currentCostume = costume,
			favorRewardStep = favorRewardStep,
			marry = marry,
			transcendence = transcendence,
			role = role,
			state = ECommanderState.Undefined,
			rankUpTime = TimeData.Create(),
			isAdvance = false,
			isDie = false,
			isDispatch = false,
			isExploration = false,
			sp = 0,
			dmgHp = 0,
			isEngaged = 1
		};
	}

	public static UnitDataRow InvokeLevel(UnitDataRow pureUnitReg, int rank, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, Dictionary<int, RoItem> EquipItem = null, bool isSetItem = false, Dictionary<int, RoWeapon> weaponItem = null, bool isWeaponSet = true)
	{
		UnitDataRow unitDataRow = pureUnitReg.Clone();
		unitDataRow.InvokeLevel(rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, EquipItem, isSetItem, weaponItem, isWeaponSet);
		return unitDataRow;
	}

	public RoCommander CreateNextLevel()
	{
		return RoCommander.Create(id, level + 1, rank, cls, currentCostume, favorRewardStep, marry, transcendence, "N");
	}

	public RoCommander CreateNextRank()
	{
		return RoCommander.Create(id, level, rank + 1, cls, currentCostume, favorRewardStep, marry, transcendence, "N");
	}

	public RoCommander CreateBeforeLevel()
	{
		return RoCommander.Create(id, level - 1, rank, cls, currentCostume, favorRewardStep, marry, transcendence, "N");
	}

	public RoCommander CreateOriginCommander()
	{
		RoCommander roCommander = RoCommander.Create(id, level, rank, cls, currentCostume, favorRewardStep, marry, transcendence, "N");
		roCommander.EquipItem = GetEquipItemList();
		return roCommander;
	}

	public RoCommander CreateBeforeRank()
	{
		return RoCommander.Create(id, level, rank - 1, cls, currentCostume, favorRewardStep, marry, transcendence, "N");
	}

	public RoCommander CreateBeforeClass()
	{
		return RoCommander.Create(id, level, rank, cls - 1, currentCostume, favorRewardStep, marry, transcendence, "N");
	}

	public bool TrainingEnable(ETrainingTicketType ticket)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
		CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
		CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
		int num = aExp;
		num += commanderTrainingTicketDataRow.exp;
		return num < commanderLevelDataRow.aexp && localUser.resourceList[ticket.ToString()] > 0 && localUser.gold >= commanderTrainingTicketDataRow.gold;
	}

	public int GetTrainingMaximumCount(ETrainingTicketType ticket)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
		CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
		CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
		int num = commanderLevelDataRow.aexp - aExp - 1;
		if (num < 1)
		{
			return 0;
		}
		return num / commanderTrainingTicketDataRow.exp + ((num % commanderTrainingTicketDataRow.exp <= 0) ? 0 : 1);
	}

	public CommanderTrainingResult Training(ETrainingTicketType ticket, int count = 1)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
		CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
		CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
		int num = commanderTrainingTicketDataRow.exp * count;
		int num2 = aExp;
		int num3 = level;
		num2 += commanderTrainingTicketDataRow.exp * count;
		if (num2 >= commanderLevelDataRow.aexp && num2 - commanderLevelDataRow.aexp < num - 1)
		{
			num = commanderLevelDataRow.aexp - aExp - 1;
			num2 = commanderLevelDataRow.aexp - 1;
		}
		if (num2 >= commanderLevelDataRow.aexp || localUser.resourceList[ticket.ToString()] <= 0)
		{
			return CommanderTrainingResult.Fail;
		}
		aExp += num;
		Dictionary<string, int> resourceList;
		string text;
		(resourceList = localUser.resourceList)[text = ticket.ToString()] = resourceList[text] - count;
		if (num3 != level)
		{
			return CommanderTrainingResult.LevelUp;
		}
		return CommanderTrainingResult.Success;
	}

	public bool UpgradeLevel()
	{
		int num = level + 1;
		Regulation regulation = RemoteObjectManager.instance.regulation;
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		int num2 = aExp;
		CommanderLevelDataRow commanderLevelDataRow;
		for (;;)
		{
			commanderLevelDataRow = regulation.GetCommanderLevelDataRow(num);
			if (commanderLevelDataRow == null)
			{
				break;
			}
			if (commanderLevelDataRow.aexp > num2)
			{
				goto Block_2;
			}
			num++;
		}
		goto IL_6B;
		Block_2:
		commanderLevelDataRow = regulation.GetCommanderLevelDataRow(num - 1);
		IL_6B:
		if (commanderLevelDataRow == null || commanderLevelDataRow.aexp > aExp || commanderLevelDataRow.level > localUser.level)
		{
			return false;
		}
		level = commanderLevelDataRow.level;
		return true;
	}

	public void StartRankUp()
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		CommanderRankDataRow commanderRankDataRow = regulation.GetCommanderRankDataRow(rank + 1);
		if (commanderRankDataRow == null)
		{
			return;
		}
		rankUpTime.SetByDuration((double)commanderRankDataRow.time);
	}

	public void StatusReset()
	{
		sp = 0;
		dmgHp = 0;
		isDie = false;
	}

	public void EndRankUp()
	{
		rank = GPInt.op_Increment(rank);
	}

	public void SkillLevelUp(int idx)
	{
		List<int> skillList;
		int num;
		(skillList = skillList)[num = idx - 1] = skillList[num] + 1;
	}

	public void SkillLevelUp(int idx, int cnt)
	{
		List<int> skillList;
		int num;
		(skillList = skillList)[num = idx - 1] = skillList[num] + cnt;
	}

	public void SetSkillLevel(int idx, int level)
	{
		skillList[idx - 1] = level;
	}

	public int GetSkillLevel(int idx)
	{
		if (skillList.Count == 0)
		{
			return 1;
		}
		return skillList[idx - 1];
	}

	public int GetSkillIndex(string id)
	{
		List<string> skillIdList = GetSkillIdList();
		for (int i = 0; i < skillIdList.Count; i++)
		{
			if (string.Equals(id, skillIdList[i]))
			{
				return i + 1;
			}
		}
		return 0;
	}

	public string GetSkillId(int skillPoint)
	{
		List<string> skillIdList = GetSkillIdList();
		if (skillIdList.Count < skillPoint)
		{
			return "0";
		}
		return skillIdList[skillPoint - 1];
	}

	public List<string> GetSkillIdList()
	{
		List<string> list = new List<string>();
		string text = string.Empty;
		RoWeapon roWeapon = FindWeaponItem(3);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != EWeaponSkill.None)
		{
			text = roWeapon.data.skillIdx;
		}
		else
		{
			text = unitReg.skillDrks[0];
		}
		list.Add(text);
		roWeapon = FindWeaponItem(2);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != EWeaponSkill.None)
		{
			text = roWeapon.data.skillIdx;
		}
		else
		{
			text = unitReg.skillDrks[1];
		}
		list.Add(text);
		roWeapon = FindWeaponItem(4);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != EWeaponSkill.None)
		{
			text = roWeapon.data.skillIdx;
		}
		else
		{
			text = unitReg.skillDrks[2];
		}
		list.Add(text);
		roWeapon = FindWeaponItem(5);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != EWeaponSkill.None)
		{
			text = roWeapon.data.skillIdx;
		}
		else
		{
			text = unitReg.skillDrks[3];
		}
		list.Add(text);
		roWeapon = FindWeaponItem(1);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != EWeaponSkill.None)
		{
			text = roWeapon.data.skillIdx;
			list.Add(text);
		}
		return list;
	}

	public bool IsClassUp(bool isGoldCheck = true)
	{
		return ImPossibleClassUp(isGoldCheck) == 0;
	}

	public int ImPossibleClassUp(bool isGoldCheck = true)
	{
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		CommanderClassDataRow commanderClassDataRow = RemoteObjectManager.instance.regulation.commanderClassDtbl.Find((CommanderClassDataRow list) => list.index == int.Parse(id) && list.cls == cls);
		if (commanderClassDataRow == null)
		{
			return 1;
		}
		for (int i = 1; i <= commanderClassDataRow.pidx.Count; i++)
		{
			int num = commanderClassDataRow.pidx[i.ToString()];
			int num2 = commanderClassDataRow.pvalue[i.ToString()];
			if (num != 0 && localUser.FindPart(num.ToString()).count < num2)
			{
				return 2;
			}
		}
		if (commanderClassDataRow.level > level)
		{
			return 100 + commanderClassDataRow.level;
		}
		if (isGoldCheck && commanderClassDataRow.gold > localUser.gold)
		{
			return 999;
		}
		return 0;
	}

	public Dictionary<int, int[]> GetClassUpMaterial()
	{
		materialDiction.Clear();
		CommanderClassDataRow commanderClassDataRow = RemoteObjectManager.instance.regulation.commanderClassDtbl.Find((CommanderClassDataRow list) => list.index == int.Parse(id) && list.cls == cls);
		if (commanderClassDataRow != null)
		{
			for (int i = 1; i <= commanderClassDataRow.pidx.Count; i++)
			{
				int num = commanderClassDataRow.pidx[i.ToString()];
				int num2 = commanderClassDataRow.pvalue[i.ToString()];
				int[] array = new int[] { num, num2 };
				materialDiction.Add(i, array);
			}
		}
		else
		{
			int[] array2 = new int[2];
			materialDiction.Add(1, array2);
			materialDiction.Add(2, array2);
			materialDiction.Add(3, array2);
			materialDiction.Add(4, array2);
			materialDiction.Add(5, array2);
			materialDiction.Add(6, array2);
		}
		return materialDiction;
	}

	public GPInt currentCostume
	{
		get
		{
			return _currentCostume;
		}
		set
		{
			if (_currentCostume != value)
			{
				_currentCostume = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public string getCurrentCostumeName()
	{
		return RemoteObjectManager.instance.regulation.GetCostumeName(currentCostume);
	}

	public CommanderCostumeDataRow getCostumeData(int ctid)
	{
		return RemoteObjectManager.instance.regulation.FindCostumeData(ctid);
	}

	public string getCurrentCostumeThumbnailName()
	{
		if (isBasicCostume)
		{
			return resourceId + "_" + currentViewCostume;
		}
		return resourceId + "_" + getCurrentCostumeName();
	}

	public List<int> haveCostumeList { get; set; }

	public List<CommanderCostumeDataRow> getCostumeList(bool isHave)
	{
		if (isHave)
		{
			List<CommanderCostumeDataRow> list = new List<CommanderCostumeDataRow>();
			for (int i = 0; i < haveCostumeList.Count; i++)
			{
				CommanderCostumeDataRow commanderCostumeDataRow = RemoteObjectManager.instance.regulation.FindCostumeData(haveCostumeList[i]);
				if (commanderCostumeDataRow != null)
				{
					list.Add(commanderCostumeDataRow);
				}
			}
			return list;
		}
		List<CommanderCostumeDataRow> list2 = RemoteObjectManager.instance.regulation.FindCommandCostumeData(id);
		for (int j = 0; j < haveCostumeList.Count; j++)
		{
			CommanderCostumeDataRow commanderCostumeDataRow2 = RemoteObjectManager.instance.regulation.FindCostumeData(haveCostumeList[j]);
			if (commanderCostumeDataRow2 != null)
			{
				list2.Remove(commanderCostumeDataRow2);
			}
		}
		return list2;
	}

	public Dictionary<int, int> eventCostume { get; set; }

	public void SetBaseCostume()
	{
		int ctid = RemoteObjectManager.instance.regulation.commanderCostumeDtbl.Find((CommanderCostumeDataRow row) => row.cid == int.Parse(id) && row.sell == 0).ctid;
		if (haveCostumeList == null)
		{
			haveCostumeList = new List<int>();
			haveCostumeList.Add(ctid);
		}
		currentCostume = ctid;
	}

	public void SetCostume(int ctid)
	{
		if (haveCostumeList == null)
		{
			haveCostumeList = new List<int>();
			haveCostumeList.Add(ctid);
		}
		currentCostume = ctid;
	}

	public List<FavorDataRow> GetFavorList()
	{
		return RemoteObjectManager.instance.regulation.FindFavorData(int.Parse(id));
	}

	public FavorDataRow GetFavorData(int step)
	{
		List<FavorDataRow> list = RemoteObjectManager.instance.regulation.FindFavorData(int.Parse(id));
		return list.Find((FavorDataRow row) => row.step == step);
	}

	public GPInt favorStep { get; set; }

	public GPInt favorPoint { get; set; }

	public GPInt favorRewardStep
	{
		get
		{
			return _favorRewardStep;
		}
		set
		{
			if (_favorRewardStep != value)
			{
				_favorRewardStep = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public int MaxFavorCount
	{
		get
		{
			return reg.favormax;
		}
	}

	public GPInt FavorCount { get; set; }

	public GPInt FavorStep { get; set; }

	public GPInt TempFaverUpCount { get; set; }

	public bool possibleMarry
	{
		get
		{
			return reg.marry == 1;
		}
	}

	public GPInt marry
	{
		get
		{
			return _marry;
		}
		set
		{
			if (_marry != value)
			{
				_marry = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public List<int> transcendence { get; set; }

	public int GetTranscendenceCount()
	{
		int num = 0;
		for (int i = 0; i < transcendence.Count; i++)
		{
			num += transcendence[i];
		}
		return num;
	}

	public int GetMaxTranscendenceCount()
	{
		int num = 0;
		TranscendenceStepUpgradeDataRow transcendenceStepUpgradeDataRow = RemoteObjectManager.instance.regulation.FindTranscendenceStepUpgrade(CurrentTranscendenceStep() + 1);
		if (transcendenceStepUpgradeDataRow != null)
		{
			num = transcendenceStepUpgradeDataRow.stepPoint;
		}
		return num;
	}

	public int CurrentTranscendenceStep()
	{
		List<TranscendenceStepUpgradeDataRow> list = RemoteObjectManager.instance.regulation.FindTranscendenceStepUpgradeListPoint(GetTranscendenceCount());
		return list.Count;
	}

	public bool IsTranscendenceSkillUp()
	{
		int num = ((reg.vip != 1) ? int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["TRANSCRNDENCE_MEDALS_VALUE"].value) : int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["TRANSCRNDENCE_MEDALS_VALUE_VIP"].value));
		return medal >= num;
	}

	public RoTroop.Slot ToSlot(int position)
	{
		Regulation regulation = RemoteObjectManager.instance.regulation;
		RoTroop.Slot slot = new RoTroop.Slot();
		slot.unitId = unitId;
		slot.unitLevel = level;
		slot.exp = aExp;
		slot.health = hp;
		slot.commanderId = id;
		slot.unitCls = cls;
		slot.unitCostume = currentCostume;
		slot.favorRewardStep = favorRewardStep;
		slot.marry = marry;
		slot.transcendence = transcendence;
		slot.unitRank = rank;
		slot.position = position;
		slot.charType = charType;
		slot.userIdx = userIdx;
		slot.equipItem = GetEquipItemList();
		slot.weaponItem = WeaponItem;
		for (int i = 0; i < unitReg.skillDrks.Count; i++)
		{
			Troop.Slot.Skill skill = new Troop.Slot.Skill();
			SkillDataRow skillDataRow = regulation.skillDtbl[unitReg.skillDrks[i]];
			if (skillDataRow.isActiveSkillType)
			{
				skill.sp = sp;
			}
			skill.id = unitReg.skillDrks[i];
			skill.lv = skillList[i];
			slot.skills.Add(skill);
		}
		return slot;
	}

	[JsonIgnore]
	private string _id;

	[JsonIgnore]
	private GPInt _level = 0;

	[JsonIgnore]
	private GPInt _cls = 0;

	[JsonIgnore]
	private GPInt _aExp = 0;

	[JsonIgnore]
	private GPInt _rank;

	private GPInt _sp;

	[JsonIgnore]
	private UnitDataRow _currLevelUnitReg;

	[JsonIgnore]
	private UnitDataRow _unitReg;

	public bool isAdvance;

	public bool isDie;

	public bool isDispatch;

	public bool isExploration;

	public int isEngaged;

	public string userName;

	public int userIdx;

	public ECharacterType charType;

	public int existEngaged;

	public int mercenaryHp;

	public int conquestDeckId;

	public Dictionary<int, RoWeapon> WeaponItem = new Dictionary<int, RoWeapon>();

	private Dictionary<int, RoItem> EquipItem;

	private Dictionary<int, int[]> materialDiction = new Dictionary<int, int[]>();

	[JsonIgnore]
	private GPInt _currentCostume = 0;

	[JsonIgnore]
	private GPInt _favorRewardStep = 0;

	[JsonIgnore]
	private GPInt _marry = 0;

	public static class Sort
	{
		public static int ByRankAscending(RoCommander a, RoCommander b)
		{
			return RoCommander.Sort._ByRank(a, b, 1);
		}

		public static int ByRankDescending(RoCommander a, RoCommander b)
		{
			return RoCommander.Sort._ByRank(a, b, -1);
		}

		private static int _ByRank(RoCommander a, RoCommander b, int dir = 1)
		{
			if (a.rank == b.rank)
			{
				return (a.level - b.level) * dir;
			}
			return (a.rank - b.rank) * dir;
		}
	}
}
