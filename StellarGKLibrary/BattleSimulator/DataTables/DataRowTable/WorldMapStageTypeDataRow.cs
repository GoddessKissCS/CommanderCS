using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class WorldMapStageTypeDataRow : DataRow
	{
		public string id { get; private set; }

		public string resourceId { get; private set; }

		public int battleCount { get; private set; }

		public string bgm { get; private set; }

		public string GetKey()
		{
			return id;
		}

	}
}
