using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EventRaidDataRow : DataRow
	{
		public string idx { get; private set; }

		public string eventIdx { get; private set; }

		public string raidIdx { get; private set; }

		public int endTurn { get; private set; }

		public string battleMap { get; private set; }

		public string enemyMap { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", eventIdx, raidIdx);
		}

	}
}
