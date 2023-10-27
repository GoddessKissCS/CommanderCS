using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class FavorStepDataRow : DataRow
	{
		public int step { get; private set; }

		public int favor { get; private set; }

		public string GetKey()
		{
			return step.ToString();
		}

	}
}
