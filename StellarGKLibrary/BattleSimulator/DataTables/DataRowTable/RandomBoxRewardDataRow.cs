using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class RandomBoxRewardDataRow : DataRow
	{
		private RandomBoxRewardDataRow()
		{
		}

		public string idx { get; private set; }

		public ERewardType rewardType { get; private set; }

		public string rewardIdx { get; private set; }

		public int rewardAmountMin { get; private set; }

		public int rewardAmountMax { get; private set; }

		public int giveType { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", idx, rewardType, rewardIdx);
		}

	}
}
