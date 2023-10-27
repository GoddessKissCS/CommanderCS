using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EnemyCommanderDataRow : DataRow
	{
		private EnemyCommanderDataRow()
		{
		}

		public int index { get; private set; }

		public string id { get; private set; }

		public int wave { get; private set; }

		public string commanderId { get; private set; }

		public int commanderRank { get; private set; }

		public string name { get; private set; }

		public int power { get; private set; }

		public string GetKey()
		{
			return id;
		}
	}
}
