using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventBattleFieldDataRow : DataRow
	{
		public int eventIdx { get; set; }

		public int idx { get; set; }

		public string name { get; set; }

		public string thumbnail { get; set; }

		public string explanation { get; set; }

		public EJob job { get; set; }

		public int weWave { get; set; }

		public int helper { get; set; }

		public string enemy { get; set; }

		public int endTurn { get; set; }

		public string battleMap { get; set; }

		public string enemyMap { get; set; }

		public string bgm { get; set; }

		public int bullet { get; set; }

		[JsonProperty("getStar01")]
		public EBattleClearCondition clearCondition1 { get; set; }

		[JsonProperty("getStar01Count")]
		public string clearCondition1_Value { get; set; }

		[JsonProperty("getStar02")]
		public EBattleClearCondition clearCondition2 { get; set; }

		[JsonProperty("getStar02Count")]
		public string clearCondition2_Value { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", eventIdx, idx);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
