using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WeaponSetDataRow : DataRow
	{
		public string type { get; set; }

		public EItemSetType weaponSetStatType { get; set; }

		public int weaponSetStatAddPoint { get; set; }

		public string GetKey()
		{
			return type;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public static int GetStatPoint(int level, int basePoint, int addPoint)
		{
			return basePoint + level * addPoint;
		}

		public const int StatPointCount = 4;
	}
}
