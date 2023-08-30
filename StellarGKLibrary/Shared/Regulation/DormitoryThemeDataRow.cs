using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryThemeDataRow : DataRow
	{
		[JsonProperty("setIdx")]
		public string id { get; set; }

		public EDormitoryItemType type { get; set; }

		[JsonProperty("idx")]
		public string itemId { get; set; }

		public int amount { get; set; }

		[JsonProperty("themeSetName")]
		public string name { get; set; }

		public string thumbnail { get; set; }

		public int atlasNumber { get; set; }

		public string GetKey()
		{
			return id;
		}
	}
}
