using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class DropGoldPatternDataRow : DataRow
	{
		public int key { get; private set; }

		public int levelStep { get; private set; }

		public int goldStep { get; private set; }

		public string GetKey()
		{
			return key.ToString();
		}

	}
}
