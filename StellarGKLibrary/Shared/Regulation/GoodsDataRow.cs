using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GoodsDataRow : DataRow
	{
		private GoodsDataRow()
		{
		}

		public string type { get; set; }

		[JsonIgnore]
		public EGoods gType { get; set; }

		public int max { get; set; }

		public EGoodsRechargeType rechargeType { get; set; }

		public int rechargeMax { get; set; }

		[JsonIgnore]
		public IList<int> rechargeCost
		{
			get
			{
				return _rechargeCost.AsReadOnly();
			}
		}

		public string resourceId
		{
			get
			{
				return type.ToString();
			}
		}

		public string serverFieldName { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public bool storage { get; set; }

		public int rechargeTime { get; set; }

		public string icon { get; set; }

		public int openType { get; set; }

		[JsonIgnore]
		public string iconId
		{
			get
			{
				return icon;
			}
		}

		[JsonIgnore]
		public bool isBox
		{
			get
			{
				return openType == 1;
			}
		}

		public string GetKey()
		{
			return type;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Regulation.FillList<int>(ref _rechargeCost, 15);
		}

		[JsonProperty("rechargeCost")]
		private List<int> _rechargeCost;
	}
}
