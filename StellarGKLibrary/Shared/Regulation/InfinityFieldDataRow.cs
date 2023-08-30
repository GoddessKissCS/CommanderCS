using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class InfinityFieldDataRow : DataRow
	{
		public string infinityFieldIdx { get; set; }

		public EInfinityStageType type { get; set; }

		public string name { get; set; }

		public string explanation { get; set; }

		public int scenarioIdx { get; set; }

		public string enemy { get; set; }

		public int endTurn { get; set; }

		public string battleMap { get; set; }

		public string enemyMap { get; set; }

		public string bgm { get; set; }

		public EBattleClearCondition clearMission01 { get; set; }

		public string clearMission01Count { get; set; }

		public EBattleClearCondition clearMission02 { get; set; }

		public string clearMission02Count { get; set; }

		public string GetKey()
		{
			return infinityFieldIdx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
