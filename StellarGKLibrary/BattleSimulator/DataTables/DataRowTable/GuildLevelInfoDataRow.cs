using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GuildLevelInfoDataRow : DataRow
	{
		public int level { get; private set; }

		public int maxcount { get; private set; }

		public int cost { get; private set; }

		public string GetKey()
		{
			return level.ToString();
		}
	}
}
