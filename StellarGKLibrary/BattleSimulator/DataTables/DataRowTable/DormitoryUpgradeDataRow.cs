using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DormitoryUpgradeDataRow : DataRow
	{
		[JsonProperty("floor")]
		public string floorId { get; private set; }

		[JsonProperty("level")]
		public int userLevel { get; private set; }

		[JsonProperty("immeCash")]
		public int immediateCash { get; private set; }

		[JsonProperty("prodTime")]
		public int productionTime { get; private set; }

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
