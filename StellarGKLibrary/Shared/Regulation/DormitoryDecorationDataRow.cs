using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryDecorationDataRow : DataRow
	{
		[JsonProperty("type")]
		public string id { get; set; }

		[JsonProperty("decoName")]
		public string name { get; set; }

		public bool action { get; set; }

		[JsonProperty("class")]
		public int advanced { get; set; }

		[JsonProperty("image")]
		public string resource { get; set; }

		public string thumbnail { get; set; }

		public int atlasNumber { get; set; }

		public int fixedSkin { get; set; }

		public int actionRate { get; set; }

		[JsonProperty("desc")]
		public string description { get; set; }

		public string decoIdx { get; set; }

		public int xSize { get; set; }

		public int ySize { get; set; }

		public ItemExchangeDataRow itemExchangeDr
		{
			get
			{
				if (_itemExchangeDr == null)
				{
					_itemExchangeDr = Regulation.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryFurniture);
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
