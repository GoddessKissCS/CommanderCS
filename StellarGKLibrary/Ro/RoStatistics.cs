using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[JsonObject]
public class RoStatistics
{
	private RoStatistics()
	{
		touchCountDict = new Dictionary<string, int>();
		stageClearCountDict = new Dictionary<string, int>();
	}

	[JsonIgnore]
	public int always
	{
		get
		{
			return 0;
		}
	}

	public double totalPlayTime { get; set; }

	public long totalGold { get; set; }

	public long totalCash { get; set; }

	public int hireCount { get; set; }

	public int totalCommanderLevel { get; set; }

	public int totalCommanderCount { get; set; }

	public long totalPlunderGold { get; set; }

	public int vipShop { get; set; }

	public int vipShopResetTime
	{
		get
		{
			return (int)vipShopResetTime_Data.GetRemain();
		}
		set
		{
			if (vipShopResetTime_Data == null)
			{
				vipShopResetTime_Data = TimeData.Create();
			}
			vipShopResetTime_Data.SetByDuration((double)value);
		}
	}

	public TimeData vipShopResetTime_Data { get; set; }

	public bool vipShopisFloating { get; set; }

	public bool isBuyVipShop { get; set; }

	public int perfectDailyMission
	{
		get
		{
			return _CheckPerfectClear(EReward.DailyMission, "perfectDailyMission");
		}
	}

	public int perfectWeeklyMission
	{
		get
		{
			return _CheckPerfectClear(EReward.WeeklyMission, "perfectWeeklyMission");
		}
	}

	public int perfectMonthlyMission
	{
		get
		{
			return _CheckPerfectClear(EReward.MonthlyMission, "perfectMonthlyMission");
		}
	}

	private int _CheckPerfectClear(EReward type, string excludeConditionId)
	{
		RoLocalUser localUser = RemoteObjectManager.instance.localUser;
		List<RoReward> rewardList = localUser.GetRewardList(type);
		bool flag = true;
		int num = 0;
		while (flag && num < rewardList.Count)
		{
			RoReward roReward = rewardList[num];
			flag &= roReward.IsCompleted();
			num++;
		}
		if (flag)
		{
			return 1;
		}
		return 0;
	}

	public Dictionary<string, int> stageClearCountDict { get; private set; }

	public Dictionary<string, int> touchCountDict { get; private set; }

	public int pveWinCount { get; set; }

	public int pveLoseCount { get; set; }

	public int pvpWinCount { get; set; }

	public int pvpLoseCount { get; set; }

	public int armyCommanderDestroyCount { get; set; }

	public int armyUnitDestroyCount { get; set; }

	public int navyCommanderDestroyCount { get; set; }

	public int navyUnitDestroyCount { get; set; }

	public int winStreak { get; set; }

	public int winMostStreak { get; set; }

	public int preWinStreak { get; set; }

	public int arenaHighRank { get; set; }

	public int raidHighRank { get; set; }

	public int raidHighScore { get; set; }

	public int normalGachaCount { get; set; }

	public int premiumGachaCount { get; set; }

	public int stageClearCount { get; set; }

	public int sweepClearCount { get; set; }

	public int unitDestroyCount { get; set; }

	public int commanderDestroyCount { get; set; }

	public int weaponMakeSlotCount { get; set; }

	public int weaponInventoryCount { get; set; }

	public int predeckCount { get; set; }

	public int firstPayment
	{
		get
		{
			bool flag = false;
			if (RemoteObjectManager.instance.regulation.defineDtbl.ContainsKey("FIRST_PAYMENT_OPEN"))
			{
				flag = int.Parse(RemoteObjectManager.instance.regulation.defineDtbl["FIRST_PAYMENT_OPEN"].value) == 1;
			}
			if (flag)
			{
				return _firstPayment;
			}
			return 2;
		}
		set
		{
			_firstPayment = value;
		}
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (touchCountDict == null)
		{
			touchCountDict = new Dictionary<string, int>();
		}
	}

	public static RoStatistics Create()
	{
		return new RoStatistics();
	}

	public bool CheckCondition(string target, int val)
	{
		int value = GetValue(target);
		return value >= val;
	}

	public void AddValue(string target, int addVal)
	{
		int value = GetValue(target);
		SetValue(target, value + addVal);
	}

	public void SetValue(string target, int value)
	{
		if (string.IsNullOrEmpty(target))
		{
			return;
		}
		if (target.Contains("."))
		{
			string[] array = target.Split(new char[] { '.' });
			if (array.Length > 2)
			{
				return;
			}
			Dictionary<string, int> propertyValue = Utility.GetPropertyValue<Dictionary<string, int>>(this, array[0], null);
			if (!propertyValue.ContainsKey(array[1]))
			{
				propertyValue.Add(array[1], value);
				return;
			}
			propertyValue[array[1]] = value;
		}
		else
		{
			Utility.SetPropertyValue(this, target, value, null);
		}
	}

	public int GetValue(string target)
	{
		if (string.IsNullOrEmpty(target))
		{
			return 0;
		}
		int num;
		if (target.Contains("."))
		{
			string[] array = target.Split(new char[] { '.' });
			if (array.Length > 2)
			{
				return 0;
			}
			Dictionary<string, int> propertyValue = Utility.GetPropertyValue<Dictionary<string, int>>(this, array[0], null);
			if (!propertyValue.ContainsKey(array[1]))
			{
				propertyValue.Add(array[1], 0);
				return 0;
			}
			num = propertyValue[array[1]];
		}
		else
		{
			num = Utility.GetPropertyValue<int>(this, target, null);
		}
		return num;
	}

	private int _firstPayment;
}
