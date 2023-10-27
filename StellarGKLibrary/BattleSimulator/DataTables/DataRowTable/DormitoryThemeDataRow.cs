using System;
using Newtonsoft.Json;
using RoomDecorator;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DormitoryThemeDataRow : DataRow
	{
		[JsonProperty("setIdx")]
		public string id { get; private set; }

		public EDormitoryItemType type { get; private set; }

		[JsonProperty("idx")]
		public string itemId { get; private set; }

		public int amount { get; private set; }

		[JsonProperty("themeSetName")]
		public string name { get; private set; }

		public string thumbnail { get; private set; }

		public int atlasNumber { get; private set; }

		public string GetKey()
		{
			return id;
		}
	}
}
