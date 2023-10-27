using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderScenarioDataRow : DataRow
	{
		public int csid { get; private set; }

		public string cid { get; private set; }

		public int order { get; private set; }

		public string name { get; private set; }

		public string desc { get; private set; }

		public int level { get; private set; }

		public int grade { get; private set; }

		public int cls { get; private set; }

		public int favor { get; private set; }

		public int mapClear { get; private set; }

		public int commander { get; private set; }

		public int scenarioClear { get; private set; }

		public int heart { get; private set; }

		public string GetKey()
		{
			return csid.ToString();
		}

	}
}
