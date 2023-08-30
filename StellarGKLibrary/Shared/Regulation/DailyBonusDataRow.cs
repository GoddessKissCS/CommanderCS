using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DailyBonusDataRow : DataRow
	{
		private DailyBonusDataRow()
		{
		}

		public int index { get; set; }

		public string version { get; set; }

		public ERewardType rewardType { get; set; }

		public int day { get; set; }

		public string goodsId { get; set; }

		public int goodsCount { get; set; }

		public int vipLevel { get; set; }

		public int multiply { get; set; }

		public string startTimeString { get; set; }

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

		public string endTimeString { get; set; }

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
