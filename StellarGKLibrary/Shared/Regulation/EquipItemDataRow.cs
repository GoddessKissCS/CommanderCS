using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EquipItemDataRow : DataRow
	{
		public string key { get; set; }

		public int pointType { get; set; }

		public EItemSetType setItemType { get; set; }

		public int statEffect { get; set; }

		public EItemStatType statType { get; set; }

		public int statBasePoint { get; set; }

		public int statAddPoint { get; set; }

		public EItemStatType UpgradeType { get; set; }

		public EItemStatType disassembleType { get; set; }

		public string equipItemIcon { get; set; }

		public string equipItemName { get; set; }

		public string equipItemSubText { get; set; }

		public string GetKey()
		{
			return key;
		}

		public int GetStatPoint(int level)
		{
			return statBasePoint + (level - 1) * statAddPoint;
		}
	}
}
