using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EventRemaingTimeDataRow : DataRow
	{
		public string idx { get; private set; }

		public string name { get; private set; }

		public int sort { get; private set; }

		public string img { get; private set; }

		public string metro { get; private set; }

		public int xaxis { get; private set; }

		public int yaxis { get; private set; }

		public string GetKey()
		{
			return idx;
		}

	}
}
