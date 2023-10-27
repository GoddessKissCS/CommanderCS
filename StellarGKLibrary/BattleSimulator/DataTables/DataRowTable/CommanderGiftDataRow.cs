using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderGiftDataRow : DataRow
	{
		public int idx { get; private set; }

		public int type { get; private set; }

		public int favorPoint { get; private set; }

		public string GetKey()
		{
			return idx.ToString();
		}

	}
}
