using System.Collections.Generic;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;
using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;

[JsonObject]
public class RoCommander
{
	public static class Sort
	{
		public static int ByRankAscending(RoCommander a, RoCommander b)
		{
			return _ByRank(a, b);
		}

		public static int ByRankDescending(RoCommander a, RoCommander b)
		{
			return _ByRank(a, b, -1);
		}

		private static int _ByRank(RoCommander a, RoCommander b, int dir = 1)
		{
			if ((int)a.rank == (int)b.rank)
			{
				return ((int)a.level - (int)b.level) * dir;
			}
			return ((int)a.rank - (int)b.rank) * dir;
		}
	}

	[JsonIgnore]
	private string _id;

	[JsonIgnore]
	private int _level = 0;

	[JsonIgnore]
	private int _cls = 0;

	[JsonIgnore]
	private int _aExp = 0;

	[JsonIgnore]
	private int _rank;

	private int _sp;

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
	private int _currentCostume = 0;

	[JsonIgnore]
	private int _favorRewardStep = 0;

	[JsonIgnore]
	private int _marry = 0;

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

	public int level
	{
		get
		{
			return _level;
		}
		set
		{
			if ((int)_level != (int)value)
			{
				_level = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public int cls
	{
		get
		{
			return _cls;
		}
		set
		{
			if ((int)_cls != (int)value)
			{
				_cls = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public int exp
	{
		get
		{
			Regulation regulation = Constants.regulation;
			CommanderLevelDataRow commanderLevelDataRow = null;
			commanderLevelDataRow = regulation.GetCommanderLevelDataRow(level);
			return (int)aExp - commanderLevelDataRow.aexp;
		}
	}

	public int aExp
	{
		get
		{
			return _aExp;
		}
		set
		{
			_aExp = value;
			Regulation regulation = Constants.regulation;
			level = regulation.FindLevel(_aExp);
		}
	}

	public int maxExp
	{
		get
		{
			Regulation regulation = Constants.regulation;
			CommanderLevelDataRow commanderLevelDataRow = null;
			CommanderLevelDataRow commanderLevelDataRow2 = null;
			commanderLevelDataRow = regulation.GetCommanderLevelDataRow(level);
			commanderLevelDataRow2 = regulation.GetCommanderLevelDataRow((int)level + 1);
			return commanderLevelDataRow2.aexp - commanderLevelDataRow.aexp;
		}
	}

	public int rank
	{
		get
		{
			return _rank;
		}
		set
		{
			if ((int)_rank != (int)value)
			{
				_rank = value;
				currLevelUnitReg = null;
			}
		}
	}

	public int sp
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
			Regulation regulation = Constants.regulation;
			int num = int.Parse(regulation.defineDtbl["ANNIHILATE_PILOT_CLASS_LIMIT"].value);
			return (int)cls >= num;
		}
	}

	public int maxSp
	{
		get
		{
			Regulation regulation = Constants.regulation;
			SkillDataRow skillDataRow = regulation.skillDtbl[unitReg.skillDrks[1]];
			return skillDataRow.maxSp;
		}
	}

	public int hp => currLevelUnitReg.maxHealth - (int)dmgHp;

	public int dmgHp { get; set; }

	public TimeData rankUpTime { get; set; }

	public UnitDataRow currLevelUnitReg
	{
		get
		{
			if (_currLevelUnitReg == null)
			{
				_currLevelUnitReg = InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, EquipItem, completeSetItemEquip, WeaponItem);
			}
			return _currLevelUnitReg;
		}
		private set
		{
			_currLevelUnitReg = value;
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
				DataTable<UnitDataRow> unitDtbl = Constants.regulation.unitDtbl;
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
			DataTable<CommanderDataRow> commanderDtbl = Constants.regulation.commanderDtbl;
			if (!commanderDtbl.ContainsKey(id))
			{
				return null;
			}
			return commanderDtbl[id];
		}
	}

	public EBranch branch => unitReg.branch;

	public EJob job => unitReg.job;

	public string unitId => reg.unitId;

	public string nickname => reg.nickname;

	public int leadership
	{
		get
		{
			int num = 0;
			for (int i = 1; i < (int)level; i++)
			{
				CommanderLevelDataRow commanderLevelDataRow = Constants.regulation.commanderLevelDtbl[i];
				num += commanderLevelDataRow.AddLeadership;
			}
			return reg.leadership + num;
		}
	}

	public string unitResourceId => unitReg.resourceName;

	public string resourceId => reg.resourceId;

	public bool npc { get; set; }

	public bool newFace { get; set; }

	public string role { get; set; }

	public bool attacker => string.Equals(role, "A");

	public bool defender => string.Equals(role, "D");

	public bool scramble => string.Equals(role, "S");

	public bool occupation => string.Equals(role, "O");

	public bool product => string.Equals(role, "P");

	public int GetdispatchGold => (int)((float)(((int)level + (int)cls) * (int)rank) / 11f * 60f);

	public float GetdispatchFloatGold => (float)(((int)level + (int)cls) * (int)rank) / 11f * 60f;

	public ECommanderState state { get; set; }

	public int medal
	{
		get
		{
			//RoLocalUser localUser = RemoteObjectManager.instance.localUser;
			Regulation regulation = Constants.regulation;
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
			Regulation regulation = Constants.regulation;
			CommanderRankDataRow commanderRankDataRow = regulation.GetCommanderRankDataRow(rank);
			if (state != ECommanderState.Nomal)
			{
				return commanderRankDataRow.medal;
			}
			CommanderRankDataRow commanderRankDataRow2 = regulation.GetCommanderRankDataRow((int)rank + 1);
			return commanderRankDataRow2.medal - commanderRankDataRow.medal;
		}
	}

	public bool completeSetItemEquip
	{
		get
		{
			if (EquipItem == null)
			{
				return false;
			}
			if (EquipItem.Count == 4)
			{
				return EquipItem[1].setType == EquipItem[2].setType && EquipItem[2].setType == EquipItem[3].setType && EquipItem[3].setType == EquipItem[4].setType;
			}
			return false;
		}
	}

	//public bool isBasicCostume => PlayerPrefs.HasKey(id);

	//public string currentViewCostume
	//{
	//	get
	//	{
	//		if (isBasicCostume)
	//		{
	//			return PlayerPrefs.GetString(id);
	//		}
	//		return currentCostume.ToString();
	//	}
	//}

	public List<int> skillList { get; set; }

	public int currentCostume
	{
		get
		{
			return _currentCostume;
		}
		set
		{
			if ((int)_currentCostume != (int)value)
			{
				_currentCostume = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public List<int> haveCostumeList { get; set; }

	public Dictionary<int, int> eventCostume { get; set; }

	public int favorStep { get; set; }

	public int favorPoint { get; set; }

	public int favorRewardStep
	{
		get
		{
			return _favorRewardStep;
		}
		set
		{
			if ((int)_favorRewardStep != (int)value)
			{
				_favorRewardStep = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public int MaxFavorCount => reg.favormax;

	public int FavorCount { get; set; }

	public int FavorStep { get; set; }

	public int TempFaverUpCount { get; set; }

	public bool possibleMarry => reg.marry == 1;

	public int marry
	{
		get
		{
			return _marry;
		}
		set
		{
			if ((int)_marry != (int)value)
			{
				_marry = value;
				unitReg = null;
				currLevelUnitReg = null;
			}
		}
	}

	public List<int> transcendence { get; set; }

	public RoCommander()
	{
		skillList = new List<int>();
		for (int i = 0; i < 5; i++)
		{
			skillList.Add(1);
		}
	}

	public void DeleteCurrLevelUnitReg()
	{
		if (_currLevelUnitReg != null)
		{
			_currLevelUnitReg = null;
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
		InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem);
	}

	public void RemoveWeaponItem(int slotType)
	{
		if (WeaponItem != null || WeaponItem.ContainsKey(slotType))
		{
			WeaponItem[slotType].DeleteWeapon();
			WeaponItem[slotType] = null;
			InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem);
		}
	}

	public RoWeapon FindWeaponItem(int slotType)
	{
		RoWeapon result = null;
		if (WeaponItem != null && WeaponItem.ContainsKey(slotType))
		{
			result = WeaponItem[slotType];
		}
		return result;
	}

	public bool isEmptyWeapon()
	{
		if (WeaponItem == null && WeaponItem.Count == 0)
		{
			return true;
		}
		foreach (KeyValuePair<int, RoWeapon> item in WeaponItem)
		{
			if (item.Value != null)
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
		string result = string.Empty;
		if (slotType == 2)
		{
			result = unitReg.skillDrks[1];
		}
		if (slotType == 3)
		{
			result = unitReg.skillDrks[0];
		}
		if (slotType == 4)
		{
			result = unitReg.skillDrks[2];
		}
		if (slotType == 5)
		{
			result = unitReg.skillDrks[3];
		}
		return result;
	}

	public int GetWeaponSkillLevel(int slotType)
	{
		int result = 0;
		switch (slotType)
		{
		case 1:
			result = skillList[4];
			break;
		case 2:
			result = skillList[1];
			break;
		case 3:
			result = skillList[0];
			break;
		case 4:
			result = skillList[2];
			break;
		case 5:
			result = skillList[3];
			break;
		}
		return result;
	}

	public int EnableWeaponSet(string type)
	{
		int num = 0;
		foreach (KeyValuePair<int, RoWeapon> item in WeaponItem)
		{
			if (item.Value != null && item.Value.data.weaponSetType == type)
			{
				num++;
			}
		}
		return num;
	}

	public bool EnableWeaponSet()
	{
		int num = 0;
		string text = string.Empty;
		foreach (RoWeapon value in WeaponItem.Values)
		{
			if (value != null && value.data.weaponSetType != "0")
			{
				if (value.data.weaponSetType != text)
				{
					num = 1;
					text = value.data.weaponSetType;
				}
				else
				{
					num++;
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
		InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem);
	}

	public void ClearEquipItem(int pointType, RoItem item)
	{
		if (EquipItem != null)
		{
			if (EquipItem.ContainsKey(pointType))
			{
				EquipItem[pointType].isEquip = false;
				EquipItem[pointType].currEquipCommanderId = string.Empty;
				EquipItem.Remove(pointType);
			}
			InvokeLevel(unitReg, rank, level, cls, currentCostume, id, favorRewardStep, marry, transcendence, GetEquipItemList(), completeSetItemEquip, WeaponItem);
		}
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

	public bool checkCompleteSetItem(EItemSetType setType)
	{
		if (EquipItem == null)
		{
			return false;
		}
		if (EquipItem.Count == 3)
		{
			using Dictionary<int, RoItem>.Enumerator enumerator = EquipItem.GetEnumerator();
			if (enumerator.MoveNext())
			{
				if (setType != enumerator.Current.Value.setType)
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}

	public Dictionary<int, RoItem> GetEquipItemList()
	{
		return EquipItem;
	}

	//public void SetBasicCostumeKey(string ctid)
	//{
	//	if (!PlayerPrefs.HasKey(id))
	//	{
	//		CommanderCostumeDataRow commanderCostumeDataRow = Constants.regulation.FindCostumeData(int.Parse(ctid));
	//		if (commanderCostumeDataRow != null)
	//		{
	//			PlayerPrefs.SetString(id, commanderCostumeDataRow.skinName);
	//		}
	//	}
	//}

	public void Die()
	{
		isDie = true;
		dmgHp = currLevelUnitReg.maxHealth;
	}

	public void SetSp(float fer)
	{
		sp = (int)((float)(int)maxSp * fer * 0.01f);
	}

	public static RoCommander Create(string id, int level, int rank, int cls, int costume, int favorRewardStep, int marry, List<int> transcendence, string role = "N")
	{
		RoCommander roCommander = new RoCommander();
		roCommander.id = id;
		roCommander.level = level;
		roCommander.rank = rank;
		roCommander.cls = cls;
		roCommander.currentCostume = costume;
		roCommander.favorRewardStep = favorRewardStep;
		roCommander.marry = marry;
		roCommander.transcendence = transcendence;
		roCommander.role = role;
		roCommander.state = ECommanderState.Undefined;
		roCommander.rankUpTime = TimeData.Create();
		roCommander.isAdvance = false;
		roCommander.isDie = false;
		roCommander.isDispatch = false;
		roCommander.isExploration = false;
		roCommander.sp = 0;
		roCommander.dmgHp = 0;
		roCommander.isEngaged = 1;
		return roCommander;
	}

	public static UnitDataRow InvokeLevel(UnitDataRow pureUnitReg, int rank, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, Dictionary<int, RoItem> EquipItem = null, bool isSetItem = false, Dictionary<int, RoWeapon> weaponItem = null, bool isWeaponSet = true)
	{
		UnitDataRow unitDataRow = pureUnitReg.Clone();
		//unitDataRow.InvokeLevel(rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, EquipItem, isSetItem, weaponItem, isWeaponSet);
		return unitDataRow;
	}

	public RoCommander CreateNextLevel()
	{
		return Create(id, (int)level + 1, rank, cls, currentCostume, favorRewardStep, marry, transcendence);
	}

	public RoCommander CreateNextRank()
	{
		return Create(id, level, (int)rank + 1, cls, currentCostume, favorRewardStep, marry, transcendence);
	}

	public RoCommander CreateBeforeLevel()
	{
		return Create(id, (int)level - 1, rank, cls, currentCostume, favorRewardStep, marry, transcendence);
	}

	public RoCommander CreateOriginCommander()
	{
		RoCommander roCommander = Create(id, level, rank, cls, currentCostume, favorRewardStep, marry, transcendence);
		roCommander.EquipItem = GetEquipItemList();
		return roCommander;
	}

	public RoCommander CreateBeforeRank()
	{
		return Create(id, level, (int)rank - 1, cls, currentCostume, favorRewardStep, marry, transcendence);
	}

	public RoCommander CreateBeforeClass()
	{
		return Create(id, level, rank, (int)cls - 1, currentCostume, favorRewardStep, marry, transcendence);
	}

	//public bool TrainingEnable(ETrainingTicketType ticket)
	//{
	//	Regulation regulation = Constants.regulation;
	//	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//	DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
	//	CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
	//	CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
	//	int num = aExp;
	//	num += commanderTrainingTicketDataRow.exp;
	//	if (num < commanderLevelDataRow.aexp && localUser.resourceList[ticket.ToString()] > 0 && localUser.gold >= commanderTrainingTicketDataRow.gold)
	//	{
	//		return true;
	//	}
	//	return false;
	//}

	//public int GetTrainingMaximumCount(ETrainingTicketType ticket)
	//{
	//	Regulation regulation = Constants.regulation;
	//	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//	DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
	//	CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
	//	CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
	//	int num = commanderLevelDataRow.aexp - (int)aExp - 1;
	//	if (num < 1)
	//	{
	//		return 0;
	//	}
	//	return num / commanderTrainingTicketDataRow.exp + ((num % commanderTrainingTicketDataRow.exp > 0) ? 1 : 0);
	//}

	//public CommanderTrainingResult Training(ETrainingTicketType ticket, int count = 1)
	//{
	//	Regulation regulation = Constants.regulation;
	//	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//	DataTable<CommanderTrainingTicketDataRow> commanderTrainingTicketDtbl = regulation.commanderTrainingTicketDtbl;
	//	CommanderTrainingTicketDataRow commanderTrainingTicketDataRow = commanderTrainingTicketDtbl[ticket.ToString()];
	//	CommanderLevelDataRow commanderLevelDataRow = regulation.GetCommanderLevelDataRow(localUser.level + 1);
	//	int num = commanderTrainingTicketDataRow.exp * count;
	//	int num2 = aExp;
	//	int num3 = level;
	//	num2 += commanderTrainingTicketDataRow.exp * count;
	//	if (num2 >= commanderLevelDataRow.aexp && num2 - commanderLevelDataRow.aexp < num - 1)
	//	{
	//		num = commanderLevelDataRow.aexp - (int)aExp - 1;
	//		num2 = commanderLevelDataRow.aexp - 1;
	//	}
	//	if (num2 < commanderLevelDataRow.aexp && localUser.resourceList[ticket.ToString()] > 0)
	//	{
	//		aExp = (int)aExp + num;
	//		localUser.resourceList[ticket.ToString()] -= count;
	//		if (num3 != (int)level)
	//		{
	//			return CommanderTrainingResult.LevelUp;
	//		}
	//		return CommanderTrainingResult.Success;
	//	}
	//	return CommanderTrainingResult.Fail;
	//}

	//public bool UpgradeLevel()
	//{
	//	int num = (int)level + 1;
	//	Regulation regulation = Constants.regulation;
	//	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//	CommanderLevelDataRow commanderLevelDataRow = null;
	//	int num2 = aExp;
	//	while (true)
	//	{
	//		commanderLevelDataRow = regulation.GetCommanderLevelDataRow(num);
	//		if (commanderLevelDataRow == null)
	//		{
	//			break;
	//		}
	//		if (commanderLevelDataRow.aexp > num2)
	//		{
	//			commanderLevelDataRow = regulation.GetCommanderLevelDataRow(num - 1);
	//			break;
	//		}
	//		num++;
	//	}
	//	if (commanderLevelDataRow == null || commanderLevelDataRow.aexp > (int)aExp || commanderLevelDataRow.level > localUser.level)
	//	{
	//		return false;
	//	}
	//	level = commanderLevelDataRow.level;
	//	return true;
	//}

	public void StartRankUp()
	{
		Regulation regulation = Constants.regulation;
		CommanderRankDataRow commanderRankDataRow = regulation.GetCommanderRankDataRow((int)rank + 1);
		if (commanderRankDataRow != null)
		{
			rankUpTime.SetByDuration(commanderRankDataRow.time);
		}
	}

	public void StatusReset()
	{
		sp = 0;
		dmgHp = 0;
		isDie = false;
	}

	public void EndRankUp()
	{
		++rank;
	}

	public void SkillLevelUp(int idx)
	{
		skillList[idx - 1]++;
	}

	public void SkillLevelUp(int idx, int cnt)
	{
		skillList[idx - 1] += cnt;
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
		RoWeapon roWeapon = null;
		string empty = string.Empty;
		roWeapon = FindWeaponItem(3);
		empty = ((roWeapon == null || roWeapon.data.privateWeapon != 1 || roWeapon.data.skillPoint == EWeaponSkill.None) ? unitReg.skillDrks[0] : roWeapon.data.skillIdx);
		list.Add(empty);
		roWeapon = FindWeaponItem(2);
		empty = ((roWeapon == null || roWeapon.data.privateWeapon != 1 || roWeapon.data.skillPoint == EWeaponSkill.None) ? unitReg.skillDrks[1] : roWeapon.data.skillIdx);
		list.Add(empty);
		roWeapon = FindWeaponItem(4);
		empty = ((roWeapon == null || roWeapon.data.privateWeapon != 1 || roWeapon.data.skillPoint == EWeaponSkill.None) ? unitReg.skillDrks[2] : roWeapon.data.skillIdx);
		list.Add(empty);
		roWeapon = FindWeaponItem(5);
		empty = ((roWeapon == null || roWeapon.data.privateWeapon != 1 || roWeapon.data.skillPoint == EWeaponSkill.None) ? unitReg.skillDrks[3] : roWeapon.data.skillIdx);
		list.Add(empty);
		roWeapon = FindWeaponItem(1);
		if (roWeapon != null && roWeapon.data.privateWeapon == 1 && roWeapon.data.skillPoint != 0)
		{
			empty = roWeapon.data.skillIdx;
			list.Add(empty);
		}
		return list;
	}

	//public bool IsClassUp(bool isGoldCheck = true)
	//{
	//	if (ImPossibleClassUp(isGoldCheck) != 0)
	//	{
	//		return false;
	//	}
	//	return true;
	//}

	//public int ImPossibleClassUp(bool isGoldCheck = true)
	//{
	//	RoLocalUser localUser = RemoteObjectManager.instance.localUser;
	//	CommanderClassDataRow commanderClassDataRow = Constants.regulation.commanderClassDtbl.Find((CommanderClassDataRow list) => list.index == int.Parse(id) && list.cls == (int)cls);
	//	if (commanderClassDataRow == null)
	//	{
	//		return 1;
	//	}
	//	for (int i = 1; i <= commanderClassDataRow.pidx.Count; i++)
	//	{
	//		int num = commanderClassDataRow.pidx[i.ToString()];
	//		int num2 = commanderClassDataRow.pvalue[i.ToString()];
	//		if (num != 0 && localUser.FindPart(num.ToString()).count < num2)
	//		{
	//			return 2;
	//		}
	//	}
	//	if (commanderClassDataRow.level > (int)level)
	//	{
	//		return 100 + commanderClassDataRow.level;
	//	}
	//	if (isGoldCheck && commanderClassDataRow.gold > localUser.gold)
	//	{
	//		return 999;
	//	}
	//	return 0;
	//}

	public Dictionary<int, int[]> GetClassUpMaterial()
	{
		materialDiction.Clear();
		CommanderClassDataRow commanderClassDataRow = Constants.regulation.commanderClassDtbl.Find((CommanderClassDataRow list) => list.index == int.Parse(id) && list.cls == (int)cls);
		if (commanderClassDataRow != null)
		{
			for (int i = 1; i <= commanderClassDataRow.pidx.Count; i++)
			{
				int num = commanderClassDataRow.pidx[i.ToString()];
				int num2 = commanderClassDataRow.pvalue[i.ToString()];
				int[] value = new int[2] { num, num2 };
				materialDiction.Add(i, value);
			}
		}
		else
		{
			int[] value2 = new int[2];
			materialDiction.Add(1, value2);
			materialDiction.Add(2, value2);
			materialDiction.Add(3, value2);
			materialDiction.Add(4, value2);
			materialDiction.Add(5, value2);
			materialDiction.Add(6, value2);
		}
		return materialDiction;
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
		return Constants.regulation.FindFavorData(int.Parse(id));
	}

	public FavorDataRow GetFavorData(int step)
	{
		List<FavorDataRow> list = Constants.regulation.FindFavorData(int.Parse(id));
		return list.Find((FavorDataRow row) => row.step == step);
	}

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
		int result = 0;
		TranscendenceStepUpgradeDataRow transcendenceStepUpgradeDataRow = Constants.regulation.FindTranscendenceStepUpgrade(CurrentTranscendenceStep() + 1);
		if (transcendenceStepUpgradeDataRow != null)
		{
			result = transcendenceStepUpgradeDataRow.stepPoint;
		}
		return result;
	}

	public int CurrentTranscendenceStep()
	{
		List<TranscendenceStepUpgradeDataRow> list = Constants.regulation.FindTranscendenceStepUpgradeListPoint(GetTranscendenceCount());
		return list.Count;
	}

	public bool IsTranscendenceSkillUp()
	{
		int num = ((reg.vip != 1) ? int.Parse(Constants.regulation.defineDtbl["TRANSCRNDENCE_MEDALS_VALUE"].value) : int.Parse(Constants.regulation.defineDtbl["TRANSCRNDENCE_MEDALS_VALUE_VIP"].value));
		if (medal >= num)
		{
			return true;
		}
		return false;
	}

	public RoTroop.Slot ToSlot(int position)
	{
		Regulation regulation = Constants.regulation;
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
}
