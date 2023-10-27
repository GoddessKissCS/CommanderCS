using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class FavorDataRow : DataRow
	{
		public int cid { get; private set; }

		public int step { get; private set; }

		public string profile { get; private set; }

		public StatType statType { get; private set; }

		public int stat { get; private set; }

		public string GetKey()
		{
			return cid.ToString();
		}

	}
}
