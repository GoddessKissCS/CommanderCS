using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class WeaponSetDataRow : DataRow
	{
		public string type { get; private set; }

		public EItemSetType weaponSetStatType { get; private set; }

		public int weaponSetStatAddPoint { get; private set; }

		public string GetKey()
		{
			return type;
		}

		public static int GetStatPoint(int level, int basePoint, int addPoint)
		{
			return basePoint + level * addPoint;
		}

		public const int StatPointCount = 4;
	}
}
