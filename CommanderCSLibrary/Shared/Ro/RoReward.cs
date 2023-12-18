using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Ro;

[JsonObject(MemberSerialization.OptIn)]
public class RoReward
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Condition
	{
		[JsonProperty]
		public string id { get; set; }

		[JsonProperty]
		public int count { get; set; }
	}

	[JsonIgnore]
	public int subType;

	[JsonProperty]
	public string id { get; set; }

	[JsonProperty]
	public bool received { get; set; }

	[JsonProperty]
	public EReward type { get; set; }

	[JsonProperty]
	public string title { get; set; }

	[JsonProperty]
	public string description { get; set; }

	[JsonProperty]
	public string resourceId { get; set; }

	[JsonProperty]
	public List<Condition> conditionList { get; set; }

	[JsonProperty]
	public string rewardId { get; set; }

	[JsonProperty]
	public int rewardCount { get; set; }

	[JsonProperty]
	public string rewardResourceId { get; set; }

	[JsonProperty]
	public string link { get; set; }

	[JsonProperty]
	public double completeTime { get; set; }

	[JsonProperty]
	public List<CommanderCSLibrary.Shared.Protocols.RewardInfo.RewardData> rewardItem { get; set; }

	public string completeTimeString => Utility.GetStringToDay(completeTime);

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
		if (conditionList == null)
		{
			conditionList = new List<Condition>();
		}
	}

	public RoReward Clone()
	{
		return JsonConvert.DeserializeObject<RoReward>(JsonConvert.SerializeObject(this));
	}

	//public bool IsCompleted()
	//{
	//	if (!IsExistCondition())
	//	{
	//		return true;
	//	}
	//	return GetCurrentConditionCount() >= GetTargetConditionCount();
	//}

	public bool IsExistCondition()
	{
		if (conditionList == null || conditionList.Count <= 0)
		{
			return false;
		}
		bool flag = true;
		for (int i = 0; i < conditionList.Count; i++)
		{
			if (flag && string.IsNullOrEmpty(conditionList[i].id))
			{
				return false;
			}
			flag = false;
		}
		return true;
	}

	//public int GetCurrentConditionCount()
	//{
	//	RoStatistics statistics = RemoteObjectManager.statistics;
	//	if (conditionList.Count == 1)
	//	{
	//		return statistics.GetValue(conditionList[0].id);
	//	}
	//	int num = 0;
	//	int num2 = 0;
	//	for (int i = 0; i < conditionList.Count; i++)
	//	{
	//		Condition condition = conditionList[i];
	//		if (string.IsNullOrEmpty(condition.id))
	//		{
	//			if (i == 1)
	//			{
	//				return num;
	//			}
	//			break;
	//		}
	//		num = statistics.GetValue(condition.id);
	//		if (num >= condition.count)
	//		{
	//			num2++;
	//		}
	//	}
	//	return num2;
	//}

	public int GetTargetConditionCount()
	{
		if (conditionList.Count <= 0)
		{
			return 0;
		}
		if (conditionList.Count == 1)
		{
			return conditionList[0].count;
		}
		for (int i = 0; i < conditionList.Count; i++)
		{
			Condition condition = conditionList[i];
			if (string.IsNullOrEmpty(condition.id))
			{
				if (i == 1)
				{
					return conditionList[0].count;
				}
				return i;
			}
		}
		return conditionList.Count;
	}

	public RoReward CreateMail()
	{
		RoReward roReward = Clone();
		roReward.id = Guid.NewGuid().ToString();
		roReward.conditionList.Clear();
		roReward.link = null;
		roReward.received = false;
		if (roReward.type == EReward.Achievement)
		{
			roReward.title = "업적 보상";
			roReward.description = "업적 완료 보상입니다.";
		}
		else if (roReward.type == EReward.DailyMission)
		{
			roReward.title = "일일 미션 보상";
			roReward.description = "일일 미션 보상입니다.";
		}
		else if (roReward.type == EReward.WeeklyMission)
		{
			roReward.title = "주간 미션 보상";
			roReward.description = "주간 미션 보상입니다.";
		}
		else if (roReward.type == EReward.MonthlyMission)
		{
			roReward.title = "월간 미션 보상";
			roReward.description = "월간 미션 보상입니다.";
		}
		else if (roReward.type == EReward.PerfectDailyMission)
		{
			roReward.title = "일일 미션 완료 보상";
			roReward.description = "일상생활을 내려놓고 미션을 완수한 공로를 치하함.";
		}
		else if (roReward.type == EReward.PerfectWeeklyMission)
		{
			roReward.title = "주간 미션 완료 보상";
			roReward.description = "일상생활을 포기하고 미션을 완수한 공로를 치하함.";
		}
		else if (roReward.type == EReward.PerfectMonthlyMission)
		{
			roReward.title = "월간 미션 완료 보상";
			roReward.description = "인생을 포기하고 미션을 완수한 공로를 치하함.";
		}
		roReward.type = EReward.Mail;
		return roReward;
	}
}
