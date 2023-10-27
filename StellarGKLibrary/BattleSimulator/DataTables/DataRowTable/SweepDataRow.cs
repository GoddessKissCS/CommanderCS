using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class SweepDataRow : DataRow
	{
		public int type { get; private set; }

		public int level { get; private set; }

		public string name { get; private set; }

		public string description { get; private set; }

		public int minLevel { get; private set; }

		public EGoods gid { get; private set; }

		public int useValue { get; private set; }

		public int battleType { get; private set; }

		public string helper { get; private set; }

		public string uid { get; private set; }

		public string battlemap { get; private set; }

		public string enemymap { get; private set; }

		public string bgm { get; private set; }

		public int endTurn { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", type, level);
		}


		public int index;
	}
}
