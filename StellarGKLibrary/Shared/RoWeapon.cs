using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;
using StellarGKLibrary.Shared.Regulation;
using StellarGKLibrary.Utils;

[JsonObject]
public class RoWeapon
{
	public int level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
			RefreshAddStat();
		}
	}

	public static RoWeapon Create(string idx, string wIdx, int lv, int commanderId = 0)
	{
		RoWeapon roWeapon = new RoWeapon();
		WeaponDataRow weaponDataRow = Utility.regulation.weaponDtbl.Find((WeaponDataRow row) => row.idx == wIdx);
		roWeapon.data = weaponDataRow;
		roWeapon.idx = idx;
		roWeapon.wIdx = wIdx;
		roWeapon.level = lv;
		roWeapon.currEquipCommanderId = commanderId;
		if (commanderId > 0)
		{
			roWeapon.isEquip = true;
		}
		else
		{
			roWeapon.isEquip = false;
		}
		return roWeapon;
	}

	public void RefreshAddStat()
	{
		addStatPoint.Clear();
		for (int i = 0; i < data.statType.Count; i++)
		{
			if (data.statType[i] != EItemStatType.EQUIPED)
			{
				addStatPoint.Add(data.statType[i], data.statBasePoint[i] + level * data.statAddPoint[i]);
			}
		}
	}

	public int GetAddStatPoint(EItemStatType type)
	{
		int num = 0;
		if (addStatPoint.ContainsKey(type))
		{
			num = addStatPoint[type];
		}
		return num;
	}

	public int GetTotalAddStatPoint()
	{
		int num = 0;
		foreach (KeyValuePair<EItemStatType, int> keyValuePair in addStatPoint)
		{
			num += keyValuePair.Value;
		}
		return num;
	}

	public void EquipWeapon(string commanderId)
	{
		currEquipCommanderId = int.Parse(commanderId);
		isEquip = true;
	}

	public void DeleteWeapon()
	{
		currEquipCommanderId = 0;
		isEquip = false;
	}

	public void SetItemLevel(string id, int curLevel)
	{
	}

	public string idx;

	public string wIdx;

	private int _level;

	public bool isEquip;

	public int statPoint;

	public int currEquipCommanderId;

	public WeaponDataRow data;

	public Dictionary<EItemStatType, int> addStatPoint = new Dictionary<EItemStatType, int>();
}
