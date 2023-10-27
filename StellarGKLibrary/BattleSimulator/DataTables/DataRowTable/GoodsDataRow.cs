using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GoodsDataRow : DataRow
	{
		private GoodsDataRow()
		{
		}

		public string type { get; private set; }

		[JsonIgnore]
		public EGoods gType { get; private set; }

		public int max { get; private set; }

		public EGoodsRechargeType rechargeType { get; private set; }

		public int rechargeMax { get; private set; }

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

		public string serverFieldName { get; private set; }

		public string name { get; private set; }

		public string description { get; private set; }

		public bool storage { get; private set; }

		public int rechargeTime { get; private set; }

		public string icon { get; private set; }

		public int openType { get; private set; }

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


		private void OnDeserialized(StreamingContext context)
		{
			Regulation.FillList<int>(ref _rechargeCost, 15);
		}

		[JsonProperty("rechargeCost")]
		private List<int> _rechargeCost;
	}
}
