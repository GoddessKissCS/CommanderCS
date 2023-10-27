using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class MetroBankLuckDataRow : DataRow
	{
		public string Luck { get; private set; }

		public int ChipPercent { get; private set; }

		public string GetKey()
		{
			return Luck;
		}
	}
}
