using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ShopDataRow : DataRow
	{
		private ShopDataRow()
		{
		}

		public string id { get; private set; }

		public EShopType type { get; private set; }

		public int grade { get; private set; }

		public string g_idx { get; private set; }

		public int startRechargePrice { get; private set; }

		public int numberMeasure { get; private set; }

		public string priceAddPercent { get; private set; }

		public List<string> openTime { get; private set; }

		public string GetKey()
		{
			return id;
		}

	}
}
