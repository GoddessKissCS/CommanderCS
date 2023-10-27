using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ScenarioQuarterDataRow : DataRow
	{
		public string GetKey()
		{
			return quarter.ToString();
		}

		public string csid;

		public string quarter;
	}
}
