using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class RankingRewardDataRow : DataRow
	{
		public int r_idx { get; private set; }

		public ERankingContentsType type { get; private set; }

		public string g_idx { get; private set; }

		public int rewardAmount { get; private set; }

		public ERankingType rankingMinType { get; private set; }

		public int rankingMin { get; private set; }

		public ERankingType rankingMaxType { get; private set; }

		public int rankingMax { get; private set; }

		public string icon { get; private set; }

		public string name { get; private set; }

		public string GetKey()
		{
			return r_idx.ToString();
		}

	}
}
