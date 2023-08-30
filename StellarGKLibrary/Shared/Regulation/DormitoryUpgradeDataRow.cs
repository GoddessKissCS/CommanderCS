using StellarGKLibrary.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DormitoryUpgradeDataRow : DataRow
	{
		[JsonProperty("floor")]
		public string floorId { get; set; }

		[JsonProperty("level")]
		public int userLevel { get; set; }

		[JsonProperty("immeCash")]
		public int immediateCash { get; set; }

		[JsonProperty("prodTime")]
		public int productionTime { get; set; }

		public List<GoodsDataRow> goods
		{
			get
			{
				if (_goods == null)
				{
					_goods = new List<GoodsDataRow>();
					for (int i = 0; i < goodsIdxs.Count; i++)
					{
						if (goodsIdxs[i] == "0")
						{
							_goods.Add(null);
						}
						else
						{
							_goods.Add(Utility.regulation.goodsDtbl[goodsIdxs[i]]);
						}
					}
				}
				return _goods;
			}
		}

		public string GetKey()
		{
			return floorId;
		}

		[JsonProperty("idx")]
		public List<string> goodsIdxs;

		[JsonProperty("value")]
		public List<int> goodsValue;

		private List<GoodsDataRow> _goods;
	}
}
