using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EventBattleGachaRewardDataRow : DataRow
	{
		public int eventIdx { get; private set; }

		public int count { get; private set; }

		public int idx { get; private set; }

		public int mainReward { get; private set; }

		public ERewardType rewardType { get; private set; }

		public string rewardIdx { get; private set; }

		public int rewardAmount { get; private set; }

		public int rewardCount { get; private set; }

		public int effect { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", eventIdx, count, idx);
		}
	}
}
