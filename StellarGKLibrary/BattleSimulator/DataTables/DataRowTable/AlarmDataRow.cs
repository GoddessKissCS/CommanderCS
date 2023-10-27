using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class AlarmDataRow : DataRow
	{
		private AlarmDataRow()
		{
		}

		public string idx { get; private set; }

		public string key { get; private set; }

		public string title { get; private set; }

		public string description { get; private set; }

		public string GetKey()
		{
			return key;
		}

	}
}
