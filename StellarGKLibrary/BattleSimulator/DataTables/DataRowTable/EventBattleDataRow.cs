using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EventBattleDataRow : DataRow
	{
		public string eventIdx { get; private set; }

		public string goodsIdx { get; private set; }

		public int goodsAmount { get; private set; }

		public string eventImg { get; private set; }

		public string eventLogo { get; private set; }

		public ERewardType mainRewardType { get; private set; }

		public string mainRewardIdx { get; private set; }

		public int mainRewardAmount { get; private set; }

		public string eventPointIdx { get; private set; }

		public int gachaOneTimeAmount { get; private set; }

		public string GetKey()
		{
			return eventIdx;
		}

	}
}
