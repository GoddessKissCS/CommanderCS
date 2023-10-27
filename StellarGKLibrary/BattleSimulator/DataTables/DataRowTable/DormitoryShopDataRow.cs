using System;
using Newtonsoft.Json;
using RoomDecorator;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DormitoryShopDataRow : DataRow
	{
		public EDormitoryItemType type { get; private set; }

		[JsonProperty("idx")]
		public string id { get; private set; }

		public int priceType { get; private set; }

		public EDormitoryShopSellType sellType { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", type, id);
		}
	}
}
