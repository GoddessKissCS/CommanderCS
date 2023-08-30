using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ShopDataRow : DataRow
	{
		private ShopDataRow()
		{
		}

		public string id { get; set; }

		public EShopType type { get; set; }

		public int grade { get; set; }

		public string g_idx { get; set; }

		public int startRechargePrice { get; set; }

		public int numberMeasure { get; set; }

		public string priceAddPercent { get; set; }

		public List<string> openTime { get; set; }

		public string GetKey()
		{
			return id;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
