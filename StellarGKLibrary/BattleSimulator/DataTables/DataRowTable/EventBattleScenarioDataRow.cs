using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EventBattleScenarioDataRow : DataRow
	{
		public string eventIdx { get; private set; }

		public int playTurn { get; private set; }

		public string eventType { get; private set; }

		public EventScenarioTimingType timing { get; private set; }

		public string scenarioIdx { get; private set; }

		public string title { get; private set; }

		public int mapClear { get; private set; }

		public int sort { get; private set; }

		public string GetKey()
		{
			return eventIdx + playTurn.ToString();
		}
	}
}
