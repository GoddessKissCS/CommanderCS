using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DormitoryDecorationDataRow : DataRow
	{
		[JsonProperty("type")]
		public string id { get; private set; }

		[JsonProperty("decoName")]
		public string name { get; private set; }

		public bool action { get; private set; }

		[JsonProperty("class")]
		public int advanced { get; private set; }

		[JsonProperty("image")]
		public string resource { get; private set; }

		public string thumbnail { get; private set; }

		public int atlasNumber { get; private set; }

		public int fixedSkin { get; private set; }

		public int actionRate { get; private set; }

		[JsonProperty("desc")]
		public string description { get; private set; }

		public string decoIdx { get; private set; }

		public int xSize { get; private set; }

		public int ySize { get; private set; }

		public ItemExchangeDataRow itemExchangeDr
		{
			get
			{
				if (_itemExchangeDr == null)
				{
					_itemExchangeDr = RemoteObjectManager.instance.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryFurniture);
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
