using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventBattleScenarioDataRow : DataRow
	{
		public string eventIdx { get; set; }

		public int playTurn { get; set; }

		public string eventType { get; set; }

		public EventScenarioTimingType timing { get; set; }

		public string scenarioIdx { get; set; }

		public string title { get; set; }

		public int mapClear { get; set; }

		public int sort { get; set; }

		public string GetKey()
		{
			return eventIdx + playTurn.ToString();
		}
	}
}
