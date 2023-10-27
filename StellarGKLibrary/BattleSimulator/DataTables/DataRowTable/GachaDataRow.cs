using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GachaDataRow : DataRow
	{
		public string type { get; private set; }

		public int ui { get; private set; }

		public string name { get; private set; }

		public string img { get; private set; }

		public string banner { get; private set; }

		public int sort { get; private set; }

		public int resetTime { get; private set; }

		public int count { get; private set; }

		public int bonusCount { get; private set; }

		public string eventComment { get; private set; }

		public string mainReward { get; private set; }

		public string GetKey()
		{
			return type;
		}

	}
}
