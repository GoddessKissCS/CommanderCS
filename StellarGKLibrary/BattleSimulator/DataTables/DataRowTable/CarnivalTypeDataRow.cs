using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CarnivalTypeDataRow : DataRow
	{
		private CarnivalTypeDataRow()
		{
		}

		public string idx { get; private set; }

		public string name { get; private set; }

		public int sort { get; private set; }

		public ECarnivalType Type { get; private set; }

		public string startDate { get; private set; }

		public string startTime { get; private set; }

		public string endDate { get; private set; }

		public string endTime { get; private set; }

		public int startLevel { get; private set; }

		public int endLevel { get; private set; }

		public int etc { get; private set; }

		public string img { get; private set; }

		public ECarnivalCategory categoryType { get; private set; }

		public string GetKey()
		{
			return idx;
		}

	}
}
