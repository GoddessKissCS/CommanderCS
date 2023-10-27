using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GuildSkillDataRow : DataRow
	{
		public int idx { get; private set; }

		public int skilllevel { get; private set; }

		public int value { get; private set; }

		public int level { get; private set; }

		public int cost { get; private set; }

		public string name { get; private set; }

		public string description { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", idx, skilllevel);
		}
	}
}
