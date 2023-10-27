using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class RewardDataRow : DataRow
	{
		public ERewardCategory category { get; private set; }

		public int type { get; private set; }

		public int typeIndex { get; private set; }

		public ERewardType rewardType { get; private set; }

		public int rewardIdx { get; private set; }

		public int minCount { get; private set; }

		public int maxCount { get; private set; }

		public int rate { get; private set; }

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
	}
}
