using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WeaponUpgradeDataRow : DataRow
	{
		public int slotType { get; set; }

		public int level { get; set; }

		public int gold { get; set; }

		public string pIdx { get; set; }

		public int value { get; set; }

		public string GetKey()
		{
			return string.Format("{0}-{1}", slotType, level);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
