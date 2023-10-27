using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GachaCostDataRow : DataRow
	{
		public string index { get; private set; }

		public string type { get; private set; }

		public int count { get; private set; }

		public EGoods priceType { get; private set; }

		public int cost { get; private set; }

		public string GetKey()
		{
			return index;
		}

	}
}
