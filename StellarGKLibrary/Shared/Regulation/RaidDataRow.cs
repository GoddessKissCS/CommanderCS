using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class RaidDataRow : DataRow
	{
		private RaidDataRow()
		{
		}

		public int index { get; set; }

		public int key { get; set; }

		public int phase { get; set; }

		public int attackIncrease { get; set; }

		public int defenseIncrease { get; set; }

		public int accuracyIncrease { get; set; }

		public int luckIncrease { get; set; }

		public int criticalIncrease { get; set; }

		public int criticalDmgIncrease { get; set; }

		public int speedIncrease { get; set; }

		public string effectName { get; set; }

		public int pos { get; set; }

		public int health { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", key, phase, pos);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
