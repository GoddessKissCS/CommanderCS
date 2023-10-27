using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderTrainingTicketDataRow : DataRow
	{
		public ETrainingTicketType type { get; private set; }

		public int gold { get; private set; }

		public int exp { get; private set; }

		public string GetKey()
		{
			return type.ToString();
		}

	}
}
