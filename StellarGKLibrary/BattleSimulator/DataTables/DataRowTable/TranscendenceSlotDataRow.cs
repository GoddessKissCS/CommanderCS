using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class TranscendenceSlotDataRow : DataRow
	{
		public int slot { get; private set; }

		public StatType stat { get; private set; }

		public int addStat { get; private set; }

		public int firstStepLimit { get; private set; }

		public int addStepLimit { get; private set; }

		public string statString { get; private set; }

		public string icon { get; private set; }

		public string tip { get; private set; }

		public string tipTitle { get; private set; }

		public string GetKey()
		{
			return slot.ToString();
		}

	}
}
