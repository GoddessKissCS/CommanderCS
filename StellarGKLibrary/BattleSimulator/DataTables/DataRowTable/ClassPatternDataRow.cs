using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ClassPatternDataRow : DataRow
	{
		public int key { get; private set; }

		public int tier { get; private set; }

		public int hp { get; private set; }

		public int atk { get; private set; }

		public int def { get; private set; }

		public int aim { get; private set; }

		public int luck { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", key, tier);
		}

	}
}
