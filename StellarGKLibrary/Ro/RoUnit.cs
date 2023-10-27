using System;
using System.Collections.Generic;
using GPresto.Protector.Variables;
using Newtonsoft.Json;
using Shared.Regulation;

[JsonObject]
public class RoUnit
{
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
				currLevelReg = null;
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
				currLevelReg = null;
			}
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
				currLevelReg = null;
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
				currLevelReg = null;
			}
		}
	}

	public GPInt costume
	{
		get
		{
			return _costume;
		}
		set
		{
			if (_costume != value)
			{
				_costume = value;
				unitReg = null;
				currLevelReg = null;
			}
		}
	}

	public string commanderId { get; set; }

	public GPInt favorRewardStep { get; set; }

	public GPInt marry { get; set; }

	public List<int> transcendence { get; set; }

	public EBattleType battleType { get; set; }

	public TimeData trainingTime { get; set; }

	public UnitDataRow currLevelReg
	{
		get
		{
			if (_currLevelReg == null)
			{
				_currLevelReg = RoUnit.InvokeLevel(unitReg, rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, battleType, equipItem, isItemSet, weaponItem);
			}
			return _currLevelReg;
		}
		private set
		{
			_currLevelReg = value;
		}
	}

	public UnitDataRow prevLevelReg
	{
		get
		{
			if (_currLevelReg == null)
			{
				_prevLevelReg = RoUnit.InvokeLevel(unitReg, rank, level - 1, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
			}
			return _prevLevelReg;
		}
		private set
		{
			_prevLevelReg = value;
		}
	}

	public UnitDataRow unitReg
	{
		get
		{
			if (_unitReg == null)
			{
				if (string.IsNullOrEmpty(id))
				{
					return null;
				}
				DataTable<UnitDataRow> unitDtbl = RemoteObjectManager.instance.regulation.unitDtbl;
				if (!unitDtbl.ContainsKey(id))
				{
					return null;
				}
				_unitReg = unitDtbl[id];
			}
			return _unitReg;
		}
		private set
		{
			_unitReg = value;
		}
	}

	public UnitDataRow currClsReg
	{
		get
		{
			if (_currClsReg == null)
			{
				_currClsReg = RoUnit.InvokeLevel(unitReg, rank, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
			}
			return _currClsReg;
		}
		private set
		{
			_currClsReg = value;
		}
	}

	public UnitDataRow prevClsReg
	{
		get
		{
			if (_currClsReg == null)
			{
				_prevClsReg = RoUnit.InvokeLevel(unitReg, rank, level, cls - 1, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, equipItem, isItemSet, weaponItem);
			}
			return _prevClsReg;
		}
		private set
		{
			_prevClsReg = value;
		}
	}

	public string resourceId
	{
		get
		{
			return currLevelReg.resourceName;
		}
	}

	public bool unlocked
	{
		get
		{
			return unitReg != null && unitReg.unlockLevel <= RemoteObjectManager.instance.localUser.buildingDict[EBuilding.UnitResearch].level;
		}
	}

	public Dictionary<int, RoItem> equipItem { get; set; }

	public Dictionary<int, RoWeapon> weaponItem { get; set; }

	public bool isItemSet { get; set; }

	public static RoUnit Create(string id, int level, int rank, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> equipItem = null, Dictionary<int, RoWeapon> weaponItem = null)
	{
		RoUnit roUnit = new RoUnit();
		roUnit.id = id;
		roUnit.level = level;
		roUnit.cls = cls;
		roUnit.rank = rank;
		roUnit.costume = costume;
		roUnit.commanderId = commanderId;
		roUnit.favorRewardStep = favorRewardStep;
		roUnit.marry = marry;
		roUnit.transcendence = transcendence;
		roUnit.trainingTime = TimeData.Create(-1.0, -1.0);
		roUnit.battleType = battleType;
		roUnit.equipItem = equipItem;
		roUnit.weaponItem = weaponItem;
		if (equipItem != null && equipItem.Count == 4)
		{
			roUnit.isItemSet = equipItem[1].setType == equipItem[2].setType && equipItem[2].setType == equipItem[3].setType && equipItem[3].setType == equipItem[4].setType;
		}
		return roUnit;
	}

	public static UnitDataRow InvokeLevel(UnitDataRow pureUnitReg, int grade, int level, int cls, int costume, string commanderId, int favorRewardStep, int marry, List<int> transcendence, EBattleType battleType = EBattleType.Undefined, Dictionary<int, RoItem> equipItem = null, bool isItemSet = false, Dictionary<int, RoWeapon> weaponItem = null)
	{
		UnitDataRow unitDataRow = pureUnitReg.Clone();
		unitDataRow.InvokeLevel(grade, level, cls, costume, commanderId, favorRewardStep, marry, transcendence, battleType, equipItem, isItemSet, weaponItem, true);
		return unitDataRow;
	}

	public RoUnit CreateNextLevel()
	{
		return RoUnit.Create(id, level + 1, 1, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, null, null);
	}

	public RoUnit CreateNextGrade()
	{
		return RoUnit.Create(id, level, rank + 1, cls, costume, commanderId, favorRewardStep, marry, transcendence, EBattleType.Undefined, null, null);
	}

	public void StartLevelUp()
	{
		trainingTime.SetByDuration(5000.0);
	}

	public void EndLevelUp()
	{
		if (trainingTime.IsValid())
		{
			trainingTime.Set(-1.0, -1.0);
			level = GPInt.op_Increment(level);
		}
	}

	[JsonIgnore]
	private string _id;

	[JsonIgnore]
	private GPInt _level = 0;

	[JsonIgnore]
	private GPInt _rank;

	[JsonIgnore]
	private GPInt _cls = 0;

	[JsonIgnore]
	private GPInt _costume = 0;

	[JsonIgnore]
	private UnitDataRow _currLevelReg;

	[JsonIgnore]
	private UnitDataRow _prevLevelReg;

	[JsonIgnore]
	private UnitDataRow _unitReg;

	[JsonIgnore]
	private UnitDataRow _currClsReg;

	[JsonIgnore]
	private UnitDataRow _prevClsReg;
}
