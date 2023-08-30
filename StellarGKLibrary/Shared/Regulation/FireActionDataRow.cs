using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class FireActionDataRow : DataRow
	{
		public FireActionDataRow()
		{
			on = new FireActionDataRow.TimeSet();
			off = new FireActionDataRow.TimeSet();
		}

		public string key { get; set; }

		public FireActionDataRow.TimeSet on { get; set; }

		public FireActionDataRow.TimeSet off { get; set; }

		public string GetKey()
		{
			return key;
		}

		public FireActionDataRow.TimeSet GetTimeSet(bool enableEffect)
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
			public int duration { get; set; }

			public int eventTime { get; set; }

			public int fireDelayTime { get; set; }

			public int hitDelayTime { get; set; }

			public bool timeSleepDuringFire { get; set; }
		}
	}
}
