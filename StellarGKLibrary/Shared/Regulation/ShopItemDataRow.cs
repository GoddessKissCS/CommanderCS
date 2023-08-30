using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ShopItemDataRow : DataRow
	{
		private ShopItemDataRow()
		{
		}

		public string id { get; set; }

		public string resourceId { get; set; }

		public string marketItemId { get; set; }

		public EShopItemType type { get; set; }

		public int gold { get; set; }

		public int cash { get; set; }

		public string description { get; set; }

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
