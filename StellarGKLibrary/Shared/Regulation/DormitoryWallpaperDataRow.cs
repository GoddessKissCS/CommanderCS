using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryWallpaperDataRow : DataRow
	{
		[JsonProperty("type")]
		public string id { get; set; }

		[JsonProperty("wallpaperName")]
		public string name { get; set; }

		[JsonProperty("image")]
		public string resource { get; set; }

		public string thumbnail { get; set; }

		public int atlasNumber { get; set; }

		[JsonProperty("desc")]
		public string description { get; set; }

		public ItemExchangeDataRow itemExchangeDr
		{
			get
			{
				if (_itemExchangeDr == null)
				{
					_itemExchangeDr = Utility.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryWallpaper);
				}
				return _itemExchangeDr;
			}
		}

		public string GetKey()
		{
			return id;
		}

		private ItemExchangeDataRow _itemExchangeDr;
	}
}