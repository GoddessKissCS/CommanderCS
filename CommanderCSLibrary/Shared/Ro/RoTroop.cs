using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;
using CommanderCSLibrary.Shared.Protocols;
using Newtonsoft.Json;
using CommanderCSLibrary.Shared.Ro;

namespace CommanderCSLibrary.Shared.Ro;

[JsonObject]
public class RoTroop
{
	public class Ability
	{
		[JsonProperty]
		public string id { get; set; }

		[JsonProperty]
		public int point { get; set; }

		public Ability()
		{
			id = string.Empty;
			point = 0;
		}
	}

	[JsonObject]
	public class Slot
	{
		public List<Troop.Slot.Skill> skills;

		public int slotNum { get; set; }

		public string unitId { get; set; }

		public int unitLevel { get; set; }

		public int unitRank { get; set; }

		public int exp { get; set; }

		public int unitCls { get; set; }

		public int unitCostume { get; set; }

		public int favorRewardStep { get; set; }

		public int marry { get; set; }

		public List<int> transcendence { get; set; }

		public int health { get; set; }

		public int position { get; set; }

		public string commanderId { get; set; }

		public float scale { get; set; }

		public ECharacterType charType { get; set; }

		public string userName { get; set; }

		public int userIdx { get; set; }

		public int existEngage { get; set; }

		public Dictionary<int, RoItem> equipItem { get; set; }

		public Dictionary<int, RoWeapon> weaponItem { get; set; }

		public Slot()
		{
			unitId = string.Empty;
			skills = new List<Troop.Slot.Skill>();
			unitLevel = 1;
			unitRank = 1;
			unitCls = 1;
			unitCostume = 0;
			favorRewardStep = 0;
			marry = 0;
			transcendence = new List<int>();
			exp = 0;
			position = -1;
			scale = 1f;
			commanderId = string.Empty;
			charType = ECharacterType.None;
			userName = string.Empty;
			userIdx = 0;
			existEngage = -1;
			equipItem = new Dictionary<int, RoItem>();
			weaponItem = new Dictionary<int, RoWeapon>();
		}

		public void Set(Slot s)
		{
			unitId = s.unitId;
			health = s.health;
			position = s.position;
			skills = s.skills;
			unitLevel = s.unitLevel;
			unitRank = s.unitRank;
			unitCls = s.unitCls;
			unitCostume = s.unitCostume;
			favorRewardStep = s.favorRewardStep;
			marry = s.marry;
			transcendence = s.transcendence;
			position = s.position;
			commanderId = s.commanderId;
			scale = s.scale;
			charType = s.charType;
			userName = s.userName;
			userIdx = s.userIdx;
			existEngage = s.existEngage;
			equipItem = s.equipItem;
			weaponItem = s.weaponItem;
		}

		public bool IsEmptyUnitId()
		{
			return string.IsNullOrEmpty(unitId);
		}

		public bool IsValidId()
		{
			if (string.IsNullOrEmpty(unitId))
			{
				return false;
			}
			return true;
		}

		public bool IsValid()
		{
			if (!IsValidId())
			{
				return false;
			}
			return true;
		}

		public void ResetSlot()
		{
			unitId = string.Empty;
			skills = new List<Troop.Slot.Skill>();
			unitLevel = 1;
			unitRank = 1;
			unitCls = 1;
			unitCostume = 0;
			favorRewardStep = 0;
			marry = 0;
			transcendence = new List<int>();
			position = -1;
			commanderId = string.Empty;
			scale = 1f;
			charType = ECharacterType.None;
			userName = string.Empty;
			userIdx = 0;
			existEngage = -1;
			equipItem = null;
			weaponItem = null;
			health = 0;
		}
	}

	public static class Sort
	{
		public static int ByRankAscending(RoTroop a, RoTroop b)
		{
			return 0;
		}

		public static int ByRankDescending(RoTroop a, RoTroop b)
		{
			return 0;
		}
	}

	public const int Rate100 = 10000;

	public const int RowCount = 3;

	public const int ColCount = 3;

	public const int SlotCount = 9;

	public const int CommanderSlotIndex = 7;

	public const int RaidSlotIndex = 4;

	public const int CommonUnitSlotCount = 5;

	public int conquestSlotNo;

	public string stationedStageId { get; set; }

	private static Regulation.Regulation _reg => Constants.regulation;

	public string id { get; private set; }

	public EBranch branch => RoCommander.Create(commanderId, 1, 1, 1, 0, 0, 0, new List<int>())?.branch ?? EBranch.Undefined;

	public int number { get; set; }

	public string nickname { get; set; }

	public string userId { get; set; }

	public string commanderId { get; set; }

	public Slot[] slots { get; set; }

	public int NotEmptySlotCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[i].IsValidId())
				{
					num++;
				}
			}
			return num;
		}
	}

	public static List<RoTroop> CreateCooperateBattleEnemy(string id)
	{
		CooperateBattleDataRow cooperateBattleDataRow = _reg.cooperateBattleDtbl[id];
		UnitDataRow unitDataRow = _reg.unitDtbl[cooperateBattleDataRow.enemy];
		List<RoTroop> list = new List<RoTroop>();
		RoTroop roTroop = Create("Enemy-" + id);
		Slot slot = null;
		slot = roTroop.slots[0];
		slot.unitId = cooperateBattleDataRow.enemy;
		slot.unitLevel = cooperateBattleDataRow.enemyLevel;
		slot.health = unitDataRow.maxHealth;
		slot.position = cooperateBattleDataRow.enemyrPos - 1;
		list.Add(roTroop);
		return list;
	}

	public static List<RoTroop> CreateBoss(string id)
	{
		CommanderDataRow commander = _reg.commanderDtbl.Find((CommanderDataRow row) => row.id == id);
		UnitDataRow unitDataRow = _reg.unitDtbl.Find((UnitDataRow row) => row.key == commander.unitId);
		List<RoTroop> list = new List<RoTroop>();
		RoTroop roTroop = Create("Enemy-" + commander.id, commander.id);
		Slot slot = null;
		slot = roTroop.slots[0];
		slot.unitId = commander.unitId;
		slot.unitLevel = 1;
		slot.health = unitDataRow.maxHealth;
		slot.position = 4;
		list.Add(roTroop);
		return list;
	}

	public static List<RoTroop> CreateEventBoss(CommanderCSLibrary.Shared.Protocols.EventRaidData data)
	{
		Regulation.Regulation regulation = Constants.regulation;
		EnemyUnitDataRow enemyUnitDataRow = _reg.enemyUnitDtbl.Find((EnemyUnitDataRow row) => row.id == data.enemy);
		List<RoTroop> list = new List<RoTroop>();
		RoTroop roTroop = Create("Enemy-" + data.enemy);
		Slot slot = roTroop.slots[0];
		slot.unitId = enemyUnitDataRow.unitId;
		slot.unitLevel = data.level;
		slot.charType = ECharacterType.EventRaid;
		slot.unitCls = enemyUnitDataRow.unitClass;
		slot.unitRank = enemyUnitDataRow.unitGrade;
		slot.health = data.hp - data.damage;
		slot.position = enemyUnitDataRow.unitPosition - 1;
		slot.scale = (float)enemyUnitDataRow.unitScale / 100f;
		UnitDataRow unitDataRow = regulation.unitDtbl[enemyUnitDataRow.unitId];
		if (unitDataRow != null)
		{
			for (int i = 0; i < unitDataRow.skillDrks.Count; i++)
			{
				Troop.Slot.Skill skill = new Troop.Slot.Skill();
				skill.id = unitDataRow.skillDrks[i];
				skill.lv = slot.unitLevel;
				slot.skills.Add(skill);
			}
		}
		list.Add(roTroop);
		return list;
	}

	public static List<RoTroop> CreateEnemy(string id)
	{
		List<EnemyCommanderDataRow> list = _reg.enemyCommanderDtbl.FindAll((EnemyCommanderDataRow row) => row.id == id);
		List<EnemyUnitDataRow> list2 = _reg.enemyUnitDtbl.FindAll((EnemyUnitDataRow row) => row.id == id);
		int wave = 1;
		List<RoTroop> list3 = new List<RoTroop>();
		while (list3.Count < list.Count)
		{
			EnemyCommanderDataRow enemyCommanderDataRow = list.Find((EnemyCommanderDataRow row) => row.wave == wave);
			List<EnemyUnitDataRow> list4 = list2.FindAll((EnemyUnitDataRow row) => row.wave == wave);
			RoTroop roTroop = Create("Enemy-" + id, null, wave);
			for (int i = 0; i < list4.Count; i++)
			{
				Slot slot = roTroop.slots[i];
				EnemyUnitDataRow enemyUnitDataRow = list4[i];
				slot.unitId = enemyUnitDataRow.unitId;
				slot.unitLevel = enemyUnitDataRow.unitLevel;
				slot.charType = ECharacterType.Enemy;
				slot.health = _reg.unitDtbl[slot.unitId].maxHealth;
				slot.position = enemyUnitDataRow.unitPosition - 1;
				slot.scale = (float)enemyUnitDataRow.unitScale / 100f;
			}
			list3.Add(roTroop);
			wave++;
		}
		return list3;
	}

	public Troop ToBattleTroop()
	{
		Troop troop = new Troop();
		troop._id = id;
		troop._slots = new List<Troop.Slot>();
		troop._slots.AddRange(new Troop.Slot[9]);
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (!slot.IsValid() || slot.position < 0)
			{
				continue;
			}
			Troop.Slot slot2 = new Troop.Slot();
			slot2.id = slot.unitId;
			slot2.health = slot.health;
			slot2.damagedHealth = 0;
			slot2.level = slot.unitLevel;
			slot2.exp = slot.exp;
			slot2.rank = slot.unitRank;
			slot2.cid = slot.commanderId;
			slot2.cls = slot.unitCls;
			slot2.costume = slot.unitCostume;
			slot2.favorRewardStep = slot.favorRewardStep;
			slot2.marry = slot.marry;
			if (slot.transcendence != null)
			{
				slot2.transcendence = slot.transcendence;
			}
			slot2.scale = slot.scale;
			slot2.skills = slot.skills;
			slot2.charType = (int)slot.charType;
			if (slot.equipItem != null)
			{
				Dictionary<int, RoItem>.Enumerator enumerator = slot.equipItem.GetEnumerator();
				while (enumerator.MoveNext())
				{
					slot2.equipItem.Add(enumerator.Current.Key, Troop.Slot.Item.Create(enumerator.Current.Value));
				}
			}
			slot2.weaponItem = new Dictionary<int, Troop.Slot.Item>();
			if (slot.weaponItem != null)
			{
				foreach (KeyValuePair<int, RoWeapon> item2 in slot.weaponItem)
				{
					RoWeapon value = item2.Value;
					if (value != null)
					{
						int num = Regulation.Regulation.ParseWeaponSkillIndex(value.data);
						if (num >= 0)
						{
							Troop.Slot.Item item = new Troop.Slot.Item();
							item.id = value.data.idx;
							item.lv = value.level;
							slot2.weaponItem.Add(num, item);
						}
					}
				}
			}
			troop._slots[slot.position] = slot2;
		}
		return troop;
	}

	public void FromBattleTroop(Troop troop)
	{
		if (troop.id != id)
		{
			return;
		}
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (!slot.IsValid())
			{
				continue;
			}
			Troop.Slot slot2 = troop.slots[slot.position];
			if (slot2 == null || slot2.isEmpty)
			{
				slot.health = 0;
				continue;
			}
			if (slot.unitId != slot2.id)
			{
			}
			slot.health = slot2.health;
			slot.unitLevel = slot2.level;
		}
	}

	public static RoTroop Create(string userId, string cid = null, int number = 1)
	{
		RoTroop roTroop = new RoTroop();
		roTroop.id = Guid.NewGuid().ToString();
		roTroop.commanderId = cid;
		roTroop.slots = CreateEmptySlots();
		roTroop.userId = userId;
		roTroop.number = number;
		return roTroop;
	}

	public RoTroop Clone()
	{
		string cid = commanderId;
		RoTroop roTroop = Create(userId, cid, number);
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = roTroop.slots[i];
			Slot slot2 = slots[i];
			slot.unitId = slot2.unitId;
			slot.commanderId = slot2.commanderId;
			slot.health = slot2.health;
			slot.position = slot2.position;
			slot.unitLevel = slot2.unitLevel;
			slot.unitRank = slot2.unitRank;
			slot.exp = slot2.exp;
			slot.skills = slot2.skills;
			slot.unitCls = slot2.unitCls;
			slot.unitCostume = slot2.unitCostume;
			slot.favorRewardStep = slot2.favorRewardStep;
			slot.marry = slot2.marry;
			slot.transcendence = slot2.transcendence;
			slot.charType = slot2.charType;
			slot.userName = slot2.userName;
			slot.userIdx = slot2.userIdx;
			slot.existEngage = slot2.existEngage;
			slot.equipItem = slot2.equipItem;
			slot.weaponItem = slot2.weaponItem;
		}
		return roTroop;
	}

	public static Slot[] CreateEmptySlots()
	{
		Slot[] array = new Slot[9];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Slot
			{
				health = 10000
			};
			array[i].slotNum = i + 1;
		}
		return array;
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (slots == null || slots.Length != 9)
		{
			slots = CreateEmptySlots();
		}
	}

	public Slot GetSlot(int index)
	{
		return slots[index];
	}

	public Slot GetNextEmptySlot(int findMax = 9)
	{
		for (int i = 0; i < slots.Length && i <= findMax; i++)
		{
			if (slots[i].IsEmptyUnitId())
			{
				return slots[i];
			}
		}
		return null;
	}

	public int GetNotEmptySlotPosition(int findMax = 9)
	{
		for (int i = 0; i < slots.Length && i <= findMax; i++)
		{
			if (slots[i].IsValidId())
			{
				return slots[i].position;
			}
		}
		return -1;
	}

	public Slot GetSlotByPosition(int pos)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (!slots[i].IsEmptyUnitId() && slots[i].position == pos)
			{
				return slots[i];
			}
		}
		return null;
	}

	public int GetSlotIndexByPosition(int pos)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (!slots[i].IsEmptyUnitId() && slots[i].position == pos)
			{
				return i;
			}
		}
		return -1;
	}

	public int GetSlotIndexByCommanderId(string commanderId)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (!slots[i].IsEmptyUnitId() && slots[i].commanderId == commanderId)
			{
				return i;
			}
		}
		return -1;
	}

	public void RemoveAllUnit()
	{
		for (int i = 1; i < slots.Length; i++)
		{
			slots[i].unitId = string.Empty;
		}
	}

	public bool IsEmpty()
	{
		for (int i = 0; i < 5; i++)
		{
			Slot slot = slots[i];
			if (!slot.IsEmptyUnitId())
			{
				return false;
			}
		}
		return true;
	}

	public bool IsAddSlotPossible()
	{
		for (int i = 0; i < 5; i++)
		{
			Slot slot = slots[i];
			if (slot.IsEmptyUnitId())
			{
				return true;
			}
		}
		return false;
	}

	public int GetOperatingCost()
	{
		int num = 0;
		DataTable<UnitDataRow> unitDtbl = Constants.regulation.unitDtbl;
		Slot[] array = slots;
		foreach (Slot slot in array)
		{
			if (slot.IsValid())
			{
				UnitDataRow unitDataRow = unitDtbl[slot.unitId];
				num += unitDataRow.gold;
			}
		}
		return num;
	}

	public List<Ability> GetAllAbilityList()
	{
		return new List<Ability>();
	}

	public int GetLeadershipUsage()
	{
		int num = 0;
		DataTable<UnitDataRow> unitDtbl = _reg.unitDtbl;
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (slot != null && slot.IsValidId())
			{
				UnitDataRow unitDataRow = unitDtbl[slot.unitId];
				num += unitDataRow.leadership;
			}
		}
		return num;
	}

	public void UpdateScrambleTroop(Dictionary<string, CommanderCSLibrary.Shared.Protocols.UserInformationResponse.Unit> deck)
	{
		foreach (KeyValuePair<string, CommanderCSLibrary.Shared.Protocols.UserInformationResponse.Unit> item in deck)
		{
			Slot slotByPosition = GetSlotByPosition(int.Parse(item.Key) - 1);
			if (slotByPosition == null)
			{
				break;
			}
			slotByPosition.health = item.Value.Hp;
			slotByPosition.skills.Clear();
			RoUnit roUnit = RoUnit.Create(slotByPosition.unitId, slotByPosition.unitLevel, 1, slotByPosition.unitCls, slotByPosition.unitCostume, slotByPosition.commanderId, slotByPosition.favorRewardStep, slotByPosition.marry, slotByPosition.transcendence);
			for (int i = 0; i < roUnit.currLevelReg.skillDrks.Count; i++)
			{
				Troop.Slot.Skill skill = new Troop.Slot.Skill();
				skill.id = roUnit.currLevelReg.skillDrks[i];
				skill.sp = ((i != 0 && !skill.id.Equals("0")) ? item.Value.spList[i - 1] : 0);
				if (!skill.id.Equals("0"))
				{
					slotByPosition.skills.Add(skill);
				}
			}
		}
	}

	public void ResetHpUnit()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null && !string.IsNullOrEmpty(slots[i].unitId))
			{
				RoUnit roUnit = RoUnit.Create(slots[i].unitId, slots[i].unitLevel, 1, slots[i].unitCls, slots[i].unitCostume, slots[i].commanderId, slots[i].favorRewardStep, slots[i].marry, slots[i].transcendence);
				slots[i].health = roUnit.currLevelReg.maxHealth;
			}
		}
	}

	public void ResetSlots()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null)
			{
				slots[i].ResetSlot();
			}
		}
	}

	public bool TrimSlot()
	{
		bool result = false;
		int num = 0;
		for (int i = 0; i < slots.Length; i++)
		{
			if (num > 0 && !string.IsNullOrEmpty(slots[i].commanderId))
			{
				Slot slot = slots[num - 1];
				slot.Set(slots[i]);
				num = 0;
				slots[i].ResetSlot();
				result = true;
			}
			if (string.IsNullOrEmpty(slots[i].commanderId))
			{
				num = slots[i].slotNum;
			}
		}
		return result;
	}

	public Slot GetSlotByUnitId(string id)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null && slots[i].unitId == id)
			{
				return slots[i];
			}
		}
		return null;
	}

	public Slot GetSlotByCommanderId(string id)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null && slots[i].commanderId == id)
			{
				return slots[i];
			}
		}
		return null;
	}

	public Slot GetSlotByCommanderId(string id, ECharacterType charType)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null && slots[i].commanderId == id && slots[i].charType == charType)
			{
				return slots[i];
			}
		}
		return null;
	}

	public ECharacterType GetSelectedTapByCommanderId(string id)
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i] != null && slots[i].commanderId == id)
			{
				return slots[i].charType;
			}
		}
		return ECharacterType.None;
	}

	public int GetRemainLeadershipUsage()
	{
		return 0;
	}

	public UnitDataRow GetTotalStatus()
	{
		List<UnitDataRow> list = new List<UnitDataRow>();
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (slot.IsValid())
			{
				RoUnit roUnit = RoUnit.Create(slot.unitId, slot.unitLevel, slot.unitRank, slot.unitCls, slot.unitCostume, slot.commanderId, slot.favorRewardStep, slot.marry, slot.transcendence, EBattleType.Undefined, slot.equipItem, slot.weaponItem);
				list.Add(roUnit.currLevelReg);
			}
		}
		return UnitDataRow.Sum(list);
	}

	public int GetTotalPower(EBattleType battleType = EBattleType.Undefined)
	{
		int num = 0;
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (slot.IsValid())
			{
				RoUnit roUnit = RoUnit.Create(slot.unitId, slot.unitLevel, slot.unitRank, slot.unitCls, slot.unitCostume, slot.commanderId, slot.favorRewardStep, slot.marry, slot.transcendence, battleType, slot.equipItem, slot.weaponItem);
				num += roUnit.currLevelReg.GetTotalPower();
			}
		}
		return num;
	}

	public int GetTotalSpeed(EBattleType battleType = EBattleType.Undefined)
	{
		int num = 0;
		for (int i = 0; i < slots.Length; i++)
		{
			Slot slot = slots[i];
			if (slot.IsValid())
			{
				RoUnit roUnit = RoUnit.Create(slot.unitId, slot.unitLevel, slot.unitRank, slot.unitCls, slot.unitCostume, slot.commanderId, slot.favorRewardStep, slot.marry, slot.transcendence, battleType, null, slot.weaponItem);
				num += roUnit.currLevelReg.speed;
			}
		}
		return num;
	}

	//public static RoTroop CreateRandomTroop(RoCommander commander, bool onlyUnlocked = false)
	//{
	//	RoTroop roTroop = Create(null, commander.id);
	//	int num = 5;
	//	EBranch eBranch = commander.branch;
	//	List<UnitDataRow> unitList = null;
	//	if (onlyUnlocked)
	//	{
	//		List<RoUnit> list = RemoteObjectManager.instance.localUser.FindUnlockedUnit(commander.branch);
	//		unitList = new List<UnitDataRow>();
	//		list.ForEach(delegate(RoUnit src)
	//		{
	//			unitList.Add(src.unitReg);
	//		});
	//	}
	//	else
	//	{
	//		unitList = _reg.GetUnitList(commander.branch, includeHidden: true);
	//	}
	//	int num2 = 0;
	//	for (int i = 0; i < num; i++)
	//	{
	//		Slot slot = roTroop.slots[i + 1];
	//		UnitDataRow unitDataRow = unitList[UnityEngine.Random.Range(0, unitList.Count)];
	//		num2 += unitDataRow.leadership;
	//		if (num2 > (int)commander.leadership)
	//		{
	//			break;
	//		}
	//		slot.unitId = unitDataRow.GetKey();
	//		slot.health = unitDataRow.maxHealth;
	//		slot.position = i;
	//	}
	//	roTroop.commanderId = commander.id;
	//	Slot slot2 = roTroop.slots[0];
	//	slot2.unitId = commander.reg.unitId;
	//	slot2.health = commander.currLevelUnitReg.maxHealth;
	//	slot2.position = 7;
	//	return roTroop;
	//}

	//public static RoTroop CreateRandomTroop(RoTroop _troop, bool onlyUnlocked = false)
	//{
	//	RoTroop roTroop = Create(null);
	//	int num = 5;
	//	EBranch eBranch = EBranch.Army;
	//	List<UnitDataRow> unitList = null;
	//	if (onlyUnlocked)
	//	{
	//		List<RoUnit> list = RemoteObjectManager.instance.localUser.FindUnlockedUnit(eBranch);
	//		unitList = new List<UnitDataRow>();
	//		list.ForEach(delegate(RoUnit src)
	//		{
	//			unitList.Add(src.unitReg);
	//		});
	//	}
	//	else
	//	{
	//		unitList = _reg.GetUnitList(eBranch, includeHidden: false);
	//	}
	//	for (int i = 0; i < num; i++)
	//	{
	//		Slot slot = roTroop.slots[i + 1];
	//		UnitDataRow unitDataRow = unitList[UnityEngine.Random.Range(0, unitList.Count)];
	//		slot.unitId = unitDataRow.GetKey();
	//		slot.health = unitDataRow.maxHealth;
	//		if (i == _troop.GetSlot(0).position)
	//		{
	//			slot.position = roTroop.slots[i].position + 2;
	//		}
	//		else
	//		{
	//			slot.position = roTroop.slots[i].position + 1;
	//		}
	//	}
	//	roTroop.commanderId = _troop.commanderId;
	//	roTroop.slots[0] = _troop.GetSlot(0);
	//	return roTroop;
	//}

	//public static RoTroop CreateTroop(List<Protocols.PvPDuelList.PvPDuelDeck> data)
	//{
	//	RoTroop roTroop = Create(null);
	//	Regulation regulation = RemoteObjectManager.instance.regulation;
	//	if (data.Count > 0)
	//	{
	//		for (int i = 0; i < data.Count; i++)
	//		{
	//			Protocols.PvPDuelList.PvPDuelDeck pvPDuelDeck = data[i];
	//			if (pvPDuelDeck.commanderId == 0)
	//			{
	//				continue;
	//			}
	//			Slot slot = roTroop.slots[i];
	//			CommanderDataRow commanderDataRow = regulation.commanderDtbl[pvPDuelDeck.commanderId.ToString()];
	//			UnitDataRow unitDataRow = regulation.unitDtbl[commanderDataRow.unitId];
	//			slot.unitId = commanderDataRow.unitId;
	//			slot.commanderId = commanderDataRow.id;
	//			slot.health = unitDataRow.maxHealth;
	//			slot.unitLevel = pvPDuelDeck.level;
	//			slot.unitCls = pvPDuelDeck.cls;
	//			slot.unitCostume = pvPDuelDeck.costume;
	//			slot.favorRewardStep = pvPDuelDeck.favorRewardStep;
	//			slot.marry = pvPDuelDeck.marry;
	//			slot.transcendence = pvPDuelDeck.transcendence;
	//			slot.unitRank = pvPDuelDeck.grade;
	//			for (int j = 0; j < unitDataRow.skillDrks.Count; j++)
	//			{
	//				Troop.Slot.Skill skill = new Troop.Slot.Skill();
	//				skill.id = unitDataRow.skillDrks[j];
	//				switch (j)
	//				{
	//				case 0:
	//					skill.lv = pvPDuelDeck.skill1;
	//					break;
	//				case 1:
	//					skill.lv = pvPDuelDeck.skill2;
	//					break;
	//				case 2:
	//					skill.lv = pvPDuelDeck.skill3;
	//					break;
	//				case 3:
	//					skill.lv = pvPDuelDeck.skill4;
	//					break;
	//				}
	//				slot.skills.Add(skill);
	//			}
	//			slot.position = pvPDuelDeck.position - 1;
	//			if (data[i].equipItem != null && data[i].equipItem.Count > 0)
	//			{
	//				foreach (KeyValuePair<string, int> pair in data[i].equipItem)
	//				{
	//					EquipItemDataRow equipItemDataRow = regulation.equipItemDtbl.Find((EquipItemDataRow item) => item.key == pair.Key);
	//					if (equipItemDataRow != null)
	//					{
	//						slot.equipItem.Add(equipItemDataRow.pointType, RoItem.Create(pair.Key, pair.Value, 1, commanderDataRow.id));
	//					}
	//				}
	//			}
	//			slot.weaponItem = new Dictionary<int, RoWeapon>();
	//			if (pvPDuelDeck.weaponItem == null || pvPDuelDeck.weaponItem.Count <= 0)
	//			{
	//				continue;
	//			}
	//			foreach (KeyValuePair<string, Protocols.WeaponData> item in pvPDuelDeck.weaponItem)
	//			{
	//				Protocols.WeaponData value = item.Value;
	//				if (value != null)
	//				{
	//					RoWeapon roWeapon = RoWeapon.Create("0", value.id, value.level);
	//					slot.weaponItem.Add(roWeapon.data.slotType, roWeapon);
	//				}
	//			}
	//		}
	//	}
	//	return roTroop;
	//}

	//public static List<Troop> CreateWaveBattleTroop(List<EnemyUnitDataRow> data)
	//{
	//	Regulation regulation = RemoteObjectManager.instance.regulation;
	//	List<Troop> list = new List<Troop>();
	//	Troop troop = new Troop();
	//	troop._slots = new List<Troop.Slot>();
	//	troop._slots.AddRange(new Troop.Slot[9]);
	//	for (int i = 0; i < data.Count; i++)
	//	{
	//		UnitDataRow unitDataRow = regulation.unitDtbl[data[i].unitId].Clone();
	//		unitDataRow.InvokeLevel(data[i].unitGrade, data[i].unitLevel, data[i].unitClass, 0, null, 0, 0, new List<int>(), EBattleType.WaveBattle);
	//		Troop.Slot slot = new Troop.Slot();
	//		slot.id = data[i].unitId;
	//		slot.level = data[i].unitLevel;
	//		slot.rank = data[i].unitGrade;
	//		slot.cls = data[i].unitClass;
	//		slot.pos = data[i].unitPosition;
	//		slot.health = unitDataRow.maxHealth;
	//		slot.scale = (float)data[i].unitScale / 100f;
	//		troop._slots[data[i].unitPosition - 1] = slot;
	//	}
	//	list.Add(troop);
	//	return list;
	//}

	//public static RoTroop CreateTroop(Protocols.ScrambleMapHistory.userData data)
	//{
	//	RoTroop roTroop = Create(null);
	//	int num = 0;
	//	if (data.troopSlots != null)
	//	{
	//		roTroop.nickname = data.troopName;
	//		foreach (KeyValuePair<int, Protocols.ScrambleMapHistory.Slot> _slot in data.troopSlots)
	//		{
	//			UnitDataRow unitDataRow = RemoteObjectManager.instance.regulation.unitDtbl.Find((UnitDataRow unit) => unit.key == _slot.Value.unitId);
	//			Slot slot;
	//			if (unitDataRow.isCommander)
	//			{
	//				slot = roTroop.slots[0];
	//			}
	//			else
	//			{
	//				slot = roTroop.slots[num + 1];
	//				num++;
	//			}
	//			slot.unitId = _slot.Value.unitId;
	//			slot.health = _slot.Value.unitHp;
	//			slot.unitLevel = _slot.Value.unitLevel;
	//			slot.position = _slot.Key - 1;
	//		}
	//	}
	//	RoCommander roCommander = RoCommander.Create(data.cid, data.level, data.grade, data.cls, data.costume, data.favorRewardStep, data.marry, data.transcendence);
	//	roTroop.commanderId = roCommander.id;
	//	return roTroop;
	//}

	//public static RoTroop CreateAnnihilationEnemyTroop(Dictionary<int, Protocols.AnnihilationMapInfo.CommanderData> commanderList, string mapIdx)
	//{
	//	RoTroop roTroop = Create(null);
	//	Regulation regulation = RemoteObjectManager.instance.regulation;
	//	AnnihilateBattleDataRow annihilateBattleDataRow = regulation.annihilateBattleDtbl[mapIdx];
	//	List<CommanderClassDataRow> list = regulation.commanderClassDtbl.FindAll((CommanderClassDataRow row) => row.index == 1);
	//	int num = 0;
	//	foreach (KeyValuePair<int, Protocols.AnnihilationMapInfo.CommanderData> commander in commanderList)
	//	{
	//		Slot slot = roTroop.slots[num];
	//		slot.charType = ECharacterType.Annihilation;
	//		slot.unitId = commander.Value.id;
	//		slot.unitLevel = commander.Value.level;
	//		slot.health = commander.Value.hp;
	//		if (slot.unitLevel > 1)
	//		{
	//			if (list[list.Count - 1].level <= slot.unitLevel)
	//			{
	//				slot.unitCls = list[list.Count - 1].cls + 1;
	//			}
	//			else
	//			{
	//				for (int i = 0; i < list.Count; i++)
	//				{
	//					if (list[i].level < slot.unitLevel)
	//					{
	//						slot.unitCls = list[i].cls + 1;
	//					}
	//				}
	//			}
	//		}
	//		else
	//		{
	//			slot.unitCls = list[0].cls;
	//		}
	//		slot.unitRank = annihilateBattleDataRow.enemyGrade;
	//		slot.unitCostume = annihilateBattleDataRow.enemyCostume;
	//		slot.favorRewardStep = annihilateBattleDataRow.enemyfavorRewardStep;
	//		slot.marry = annihilateBattleDataRow.enemyMarry;
	//		slot.transcendence = new List<int>();
	//		slot.scale = (float)annihilateBattleDataRow.scale / 100f;
	//		slot.position = commander.Key - 1;
	//		UnitDataRow unitDataRow = regulation.unitDtbl[commander.Value.id];
	//		if (unitDataRow != null)
	//		{
	//			for (int j = 0; j < unitDataRow.skillDrks.Count; j++)
	//			{
	//				Troop.Slot.Skill skill = new Troop.Slot.Skill();
	//				skill.id = unitDataRow.skillDrks[j];
	//				int lv = 1;
	//				if (annihilateBattleDataRow.enemySkill == 1)
	//				{
	//					lv = regulation.GetSkillMaxLevel(j, slot.unitLevel);
	//				}
	//				skill.lv = lv;
	//				slot.skills.Add(skill);
	//			}
	//		}
	//		num++;
	//	}
	//	return roTroop;
	//}

	//public static RoTroop CreateScenarioTroop(List<RoLocalUser.ScenarioBattleInfo> scenarioBattleInfo)
	//{
	//	RoTroop roTroop = Create(null);
	//	for (int i = 0; i < scenarioBattleInfo.Count; i++)
	//	{
	//		Slot slot = roTroop.slots[i];
	//		slot.unitId = scenarioBattleInfo[i]._unitId;
	//		slot.unitLevel = scenarioBattleInfo[i]._unitLevel;
	//		slot.unitRank = scenarioBattleInfo[i]._unitGrade;
	//		slot.unitCls = scenarioBattleInfo[i]._unitClass;
	//		slot.position = scenarioBattleInfo[i]._unitPosition;
	//		if (scenarioBattleInfo[i]._uType != 2)
	//		{
	//			slot.commanderId = _reg.GetCommanderByUnitId(scenarioBattleInfo[i]._unitId).id;
	//		}
	//		UnitDataRow unitDataRow = _reg.unitDtbl[scenarioBattleInfo[i]._unitId];
	//		if (unitDataRow != null)
	//		{
	//			int count = scenarioBattleInfo[i]._skillLevel.Count;
	//			for (int j = 0; j < count; j++)
	//			{
	//				Troop.Slot.Skill skill = new Troop.Slot.Skill();
	//				skill.id = unitDataRow.skillDrks[j];
	//				skill.lv = scenarioBattleInfo[i]._skillLevel[j];
	//				slot.skills.Add(skill);
	//			}
	//		}
	//	}
	//	return roTroop;
	//}

	//public static RoTroop CreateWaveBattleRoTroop(List<EnemyUnitDataRow> enemyList)
	//{
	//	RoTroop roTroop = Create(null);
	//	for (int i = 0; i < enemyList.Count; i++)
	//	{
	//		UnitDataRow unitDataRow = _reg.unitDtbl[enemyList[i].unitId];
	//		CommanderDataRow commanderByUnitId = RemoteObjectManager.instance.regulation.GetCommanderByUnitId(enemyList[i].unitId);
	//		RoCommander roCommander = RoCommander.Create(commanderByUnitId.id, enemyList[i].unitLevel, enemyList[i].unitGrade, enemyList[i].unitClass, 0, 0, 0, new List<int>());
	//		Slot slot = roTroop.slots[i];
	//		slot.unitId = enemyList[i].unitId;
	//		slot.unitLevel = enemyList[i].unitLevel;
	//		slot.unitRank = enemyList[i].unitGrade;
	//		slot.unitCls = enemyList[i].unitClass;
	//		slot.position = enemyList[i].unitPosition;
	//		slot.health = roCommander.currLevelUnitReg.maxHealth;
	//		if (unitDataRow != null)
	//		{
	//			int count = enemyList[i].skillLevel.Count;
	//			for (int j = 0; j < count; j++)
	//			{
	//				Troop.Slot.Skill skill = new Troop.Slot.Skill();
	//				skill.id = unitDataRow.skillDrks[j];
	//				skill.lv = enemyList[i].skillLevel[j];
	//				slot.skills.Add(skill);
	//			}
	//		}
	//	}
	//	return roTroop;
	//}

	//public static RoTroop CreateEventBattleTroop(List<EnemyUnitDataRow> enemyList)
	//{
	//	RoTroop roTroop = Create(null);
	//	for (int i = 0; i < enemyList.Count; i++)
	//	{
	//		UnitDataRow unitDataRow = _reg.unitDtbl[enemyList[i].unitId];
	//		CommanderDataRow commanderByUnitId = RemoteObjectManager.instance.regulation.GetCommanderByUnitId(enemyList[i].unitId);
	//		RoCommander roCommander = RoCommander.Create(commanderByUnitId.id, enemyList[i].unitLevel, enemyList[i].unitGrade, enemyList[i].unitClass, 0, 0, 0, new List<int>());
	//		Slot slot = roTroop.slots[i];
	//		slot.unitId = enemyList[i].unitId;
	//		slot.unitLevel = enemyList[i].unitLevel;
	//		slot.unitRank = enemyList[i].unitGrade;
	//		slot.unitCls = enemyList[i].unitClass;
	//		slot.position = enemyList[i].unitPosition;
	//		slot.health = roCommander.currLevelUnitReg.maxHealth;
	//		if (unitDataRow != null)
	//		{
	//			int count = enemyList[i].skillLevel.Count;
	//			for (int j = 0; j < count; j++)
	//			{
	//				Troop.Slot.Skill skill = new Troop.Slot.Skill();
	//				skill.id = unitDataRow.skillDrks[j];
	//				skill.lv = enemyList[i].skillLevel[j];
	//				slot.skills.Add(skill);
	//			}
	//		}
	//	}
	//	return roTroop;
	//}

	public static int GetTroopIndexContainCommander(List<RoTroop> troops, string commanderId)
	{
		if (troops == null)
		{
			return -1;
		}
		for (int i = 0; i < troops.Count; i++)
		{
			RoTroop roTroop = troops[i];
			if (roTroop != null && roTroop.GetSlotByCommanderId(commanderId) != null)
			{
				return i;
			}
		}
		return -1;
	}
}
