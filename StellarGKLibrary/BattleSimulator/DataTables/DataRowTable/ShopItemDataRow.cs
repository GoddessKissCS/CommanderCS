using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ShopItemDataRow : DataRow
	{
		private ShopItemDataRow()
		{
		}

		public string id { get; private set; }

		public string resourceId { get; private set; }

		public string marketItemId { get; private set; }

		public EShopItemType type { get; private set; }

		public int gold { get; private set; }

		public int cash { get; private set; }

		public string description { get; private set; }

		public string GetKey()
		{
			return id;
		}

	}
}
