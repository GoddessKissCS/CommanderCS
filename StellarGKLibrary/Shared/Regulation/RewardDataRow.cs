using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class RewardDataRow : DataRow
	{
		public ERewardCategory category { get; set; }

		public int type { get; set; }

		public int typeIndex { get; set; }

		public ERewardType rewardType { get; set; }

		public int rewardIdx { get; set; }

		public int minCount { get; set; }

		public int maxCount { get; set; }

		public int rate { get; set; }

		public void AddCount(int maxCount, int minCount)
		{
			maxCount += maxCount;
			minCount += minCount;
		}

		public void Clone(RewardDataRow row)
		{
			rewardType = row.rewardType;
			rewardIdx = row.rewardIdx;
			maxCount = row.maxCount;
			minCount = row.minCount;
		}

		public string GetKey()
		{
			return category.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
