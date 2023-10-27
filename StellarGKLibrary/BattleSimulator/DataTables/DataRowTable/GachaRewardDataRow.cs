using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GachaRewardDataRow : DataRow
	{
		public string gachaType { get; private set; }

		public ERewardType rewardType { get; private set; }

		public string rewardId { get; private set; }

		public int rewardCount { get; private set; }

		public int effectType { get; private set; }

		public string GetKey()
		{
			return gachaType;
		}

	}
}
