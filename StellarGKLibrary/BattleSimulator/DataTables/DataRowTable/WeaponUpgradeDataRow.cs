using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class WeaponUpgradeDataRow : DataRow
	{
		public int slotType { get; private set; }

		public int level { get; private set; }

		public int gold { get; private set; }

		public string pIdx { get; private set; }

		public int value { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}-{1}", slotType, level);
		}
	}
}
