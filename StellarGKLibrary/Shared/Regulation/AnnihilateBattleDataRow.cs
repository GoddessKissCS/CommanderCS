using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class AnnihilateBattleDataRow : DataRow
	{
		private AnnihilateBattleDataRow()
		{
		}

		public string idx { get; set; }

		public int positionX { get; set; }

		public int positionY { get; set; }

		public int enemyLevelGap { get; set; }

		public int enemyGrade { get; set; }

		public int enemyClass { get; set; }

		public int enemyCostume { get; set; }

		public int enemyfavorRewardStep { get; set; }

		public int enemyMarry { get; set; }

		public int enemySkill { get; set; }

		public int needSpeed { get; set; }

		public string reward { get; set; }

		public string battleMap { get; set; }

		public string enemyMap { get; set; }

		public int sp { get; set; }

		public string bmg { get; set; }

		public int scale { get; set; }

		public int endTurn { get; set; }

		public int battleWave { get; set; }

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
