using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GoodsComposeDataRow : DataRow
	{
		public string idx { get; private set; }

		public string composeIdx { get; private set; }

		public int value { get; private set; }

		public string rewardIdx { get; private set; }

		public int rewardValue { get; private set; }

		public string GetKey()
		{
			return composeIdx;
		}

	}
}
