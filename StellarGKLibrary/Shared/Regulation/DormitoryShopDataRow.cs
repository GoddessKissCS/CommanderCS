using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryShopDataRow : DataRow
	{
		public EDormitoryItemType type { get; set; }

		[JsonProperty("idx")]
		public string id { get; set; }

		public int priceType { get; set; }

		public EDormitoryShopSellType sellType { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", type, id);
		}
	}
}
