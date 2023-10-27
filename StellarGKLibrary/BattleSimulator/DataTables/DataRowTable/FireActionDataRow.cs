using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class FireActionDataRow : DataRow
	{
		public FireActionDataRow()
		{
			on = new();
			off = new();
		}

		public string key { get; private set; }

		public TimeSet on { get; private set; }

		public TimeSet off { get; private set; }

		public string GetKey()
		{
			return key;
		}

		public TimeSet GetTimeSet(bool enableEffect)
		{
			if (enableEffect)
			{
				return on;
			}
			return off;
		}

		[JsonObject]
		[Serializable]
		public class TimeSet
		{
			public int duration { get; private set; }

			public int eventTime { get; private set; }

			public int fireDelayTime { get; private set; }

			public int hitDelayTime { get; private set; }

			public bool timeSleepDuringFire { get; private set; }
		}
	}
}
