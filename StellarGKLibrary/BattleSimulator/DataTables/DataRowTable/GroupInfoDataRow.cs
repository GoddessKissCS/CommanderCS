using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GroupInfoDataRow : DataRow
	{
		private GroupInfoDataRow()
		{
		}

		public string tabidx { get; private set; }

		public string tabname { get; private set; }

		public string groupIdx { get; private set; }

		public string groupName { get; private set; }

		public string groupComment { get; private set; }

		public int typeIndex { get; private set; }

		public ERewardType rewardType { get; private set; }

		public int rewardIdx { get; private set; }

		public int minCount { get; private set; }

		public string GetKey()
		{
			return groupIdx;
		}

	}
}
