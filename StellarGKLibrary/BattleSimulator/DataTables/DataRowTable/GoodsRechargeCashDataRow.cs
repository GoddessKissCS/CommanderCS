using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GoodsRechargeCashDataRow : DataRow
	{
		public int index { get; private set; }

		public EGoods goods { get; private set; }

		public int repeatCount { get; private set; }

		public int cash { get; private set; }

		public string GetKey()
		{
			return index.ToString();
		}

	}
}
