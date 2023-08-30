using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryBodyCostumeDataRow : DataRow
	{
		[JsonProperty("ctid")]
		public string id { get; set; }

		public string name { get; set; }

		[JsonProperty("desc")]
		public string description { get; set; }

		public int atlasNumber { get; set; }

		[JsonProperty("skinSort")]
		public int sort { get; set; }

		public string thumbnail { get; set; }

		public string resource { get; set; }

		public string decoIdx { get; set; }

		public ItemExchangeDataRow itemExchangeDr
		{
			get
			{
				if (_itemExchangeDr == null)
				{
					_itemExchangeDr = Regulation.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryCostume);
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
