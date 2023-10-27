using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DailyBonusDataRow : DataRow
	{
		private DailyBonusDataRow()
		{
		}

		public int index { get; private set; }

		public string version { get; private set; }

		public ERewardType rewardType { get; private set; }

		public int day { get; private set; }

		public string goodsId { get; private set; }

		public int goodsCount { get; private set; }

		public int vipLevel { get; private set; }

		public int multiply { get; private set; }

		public string startTimeString { get; private set; }

		[JsonIgnore]
		public DateTime startTime
		{
			get
			{
				if (string.IsNullOrEmpty(startTimeString))
				{
					return default(DateTime);
				}
				return Utility.ConvertToDateTime(startTimeString);
			}
		}

		public string endTimeString { get; private set; }

		[JsonIgnore]
		public DateTime endTime
		{
			get
			{
				if (string.IsNullOrEmpty(endTimeString))
				{
					return default(DateTime);
				}
				return Utility.ConvertToDateTime(endTimeString);
			}
		}

		public string GetKey()
		{
			return index.ToString();
		}
	}
}
