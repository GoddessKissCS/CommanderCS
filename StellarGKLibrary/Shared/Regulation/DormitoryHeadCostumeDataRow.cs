using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryHeadCostumeDataRow : DataRow
	{
		[JsonProperty("ctid")]
		public string id { get; set; }

		public string cid { get; set; }

		public string name { get; set; }

		[JsonProperty("desc")]
		public string description { get; set; }

		public int atlasNumber { get; set; }

		[JsonProperty("skinSort")]
		public int sort { get; set; }

		public string thumbnail { get; set; }

		public string resource { get; set; }

		public string priceType { get; set; }

		public int price { get; set; }

		public string accessory { get; set; }

		public GoodsDataRow goodsDr
		{
			get
			{
				if (_goodsDr == null)
				{
					_goodsDr = Regulation.regulation.goodsDtbl[priceType];
				}
				return _goodsDr;
			}
		}

		public string GetKey()
		{
			return id;
		}

		private GoodsDataRow _goodsDr;
	}
}
