using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderLevelDataRow : DataRow
	{
		public int level { get; private set; }

		public int exp { get; private set; }

		public int aexp { get; private set; }

		public int AddLeadership { get; private set; }

		public string GetKey()
		{
			return level.ToString();
		}

	}
}
