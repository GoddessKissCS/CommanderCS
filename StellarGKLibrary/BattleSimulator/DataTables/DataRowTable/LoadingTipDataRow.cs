using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class LoadingTipDataRow : DataRow
	{
		private LoadingTipDataRow()
		{
		}

		public string idx { get; private set; }

		public int userstartlevel { get; private set; }

		public int userendlevel { get; private set; }

		public string commanderidx { get; private set; }

		public string backgroundimg { get; private set; }

		public string commanderjobicon { get; private set; }

		public string comjobsidx { get; private set; }

		public string comnamesidx { get; private set; }

		public string comunitnamesidx { get; private set; }

		public int type { get; private set; }

		public string GetKey()
		{
			return idx;
		}

	}
}
