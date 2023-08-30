using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EquipItemUpgradeDataRow : DataRow
	{
		public EItemStatType upgradeType { get; set; }

		public int level { get; set; }

		public string upgradeMaterial1 { get; set; }

		public int upgradeMaterial1Volume { get; set; }

		public string upgradeMaterial2 { get; set; }

		public int upgradeMaterial2Volume { get; set; }

		public string upgradeMaterial3 { get; set; }

		public int upgradeMaterial3Volume { get; set; }

		public string upgradeMaterial4 { get; set; }

		public int upgradeMaterial4Volume { get; set; }

		public string upgradeMaterial5 { get; set; }

		public int upgradeMaterial5Volume { get; set; }

		public string upgradeGoodsIdx { get; set; }

		public int upgradeGoodsVolume { get; set; }

		public string GetKey()
		{
			return upgradeType + level.ToString();
		}
	}
}
