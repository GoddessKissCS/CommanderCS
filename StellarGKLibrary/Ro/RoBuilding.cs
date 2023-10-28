using System;
using Newtonsoft.Json;
using Shared.Regulation;

[JsonObject]
public class RoBuilding
{
	private RoBuilding()
	{
	}

	public EBuilding type { get; set; }

	public UIBuilding uiBuilding
	{
		get
		{
			return GetUIBuilding();
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
			if (_level != value)
			{
				_level = value;
				_reg = null;
				_nextLevelReg = null;
			}
		}
	}

	public TimeData upgradeTime { get; private set; }

	public bool isMaxLevel
	{
		get
		{
			return nextLevelReg == null;
		}
	}

	public bool isUpgrading
	{
		get
		{
			return upgradeTime.IsValid() && upgradeTime.IsEnd();
		}
	}

	public bool isEndUpgrade
	{
		get
		{
			return upgradeTime.IsEnd();
		}
	}

	public EBuildingState state { get; set; }

	public static RoBuilding Create(EBuilding type, int level = 1)
	{
		return new RoBuilding
		{
			type = type,
			level = level,
			upgradeTime = TimeData.Create()
		};
	}

	public string regulationId
	{
		get
		{
			return string.Format("{0}-{1:00}", type, level);
		}
	}

	public string nextLevelRegulationId
	{
		get
		{
			return string.Format("{0}-{1:00}", type, level + 1);
		}
	}

	public BuildingLevelDataRow reg
	{
		get
		{
			if (_reg == null)
			{
				_reg = _GetReguilation(level);
			}
			return _reg;
		}
	}

	public BuildingLevelDataRow nextLevelReg
	{
		get
		{
			if (_nextLevelReg == null)
			{
				_nextLevelReg = _GetReguilation(level + 1);
			}
			return _nextLevelReg;
		}
	}

	public BuildingLevelDataRow firstLevelReg
	{
		get
		{
			if (_firstLevelReg == null)
			{
				_firstLevelReg = _GetReguilation(1);
			}
			return _firstLevelReg;
		}
	}

	private BuildingLevelDataRow _GetReguilation(int level)
	{
		RemoteObjectManager instance = RemoteObjectManager.instance;
		return instance.regulation.buildingLevelDtbl.Find((BuildingLevelDataRow row) => row.type == type && row.level == level);
	}

	public UIBuilding GetUIBuilding()
	{
		if (type == EBuilding.Undefined)
		{
			return null;
		}
		string text = type.ToString();
		UIItemBase uiitemBase = UIManager.instance.world.camp.buildingListView.FindItem(text);
		return uiitemBase as UIBuilding;
	}

	private int _level;

	private BuildingLevelDataRow _reg;

	private BuildingLevelDataRow _nextLevelReg;

	private BuildingLevelDataRow _firstLevelReg;
}
