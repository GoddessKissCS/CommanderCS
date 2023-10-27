using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EquipItemUpgradeDataRow : DataRow
	{
		public EItemStatType upgradeType { get; private set; }

		public int level { get; private set; }

		public string upgradeMaterial1 { get; private set; }

		public int upgradeMaterial1Volume { get; private set; }

		public string upgradeMaterial2 { get; private set; }

		public int upgradeMaterial2Volume { get; private set; }

		public string upgradeMaterial3 { get; private set; }

		public int upgradeMaterial3Volume { get; private set; }

		public string upgradeMaterial4 { get; private set; }

		public int upgradeMaterial4Volume { get; private set; }

		public string upgradeMaterial5 { get; private set; }

		public int upgradeMaterial5Volume { get; private set; }

		public string upgradeGoodsIdx { get; private set; }

		public int upgradeGoodsVolume { get; private set; }

		public string GetKey()
		{
			return upgradeType + level.ToString();
		}
	}
}
