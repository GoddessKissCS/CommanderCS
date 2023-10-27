using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DormitoryBodyCostumeDataRow : DataRow
	{
		[JsonProperty("ctid")]
		public string id { get; private set; }

		public string name { get; private set; }

		[JsonProperty("desc")]
		public string description { get; private set; }

		public int atlasNumber { get; private set; }

		[JsonProperty("skinSort")]
		public int sort { get; private set; }

		public string thumbnail { get; private set; }

		public string resource { get; private set; }

		public string decoIdx { get; private set; }

		public ItemExchangeDataRow itemExchangeDr
		{
			get
			{
				if (_itemExchangeDr == null)
				{
					_itemExchangeDr = RemoteObjectManager.instance.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryCostume);
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
