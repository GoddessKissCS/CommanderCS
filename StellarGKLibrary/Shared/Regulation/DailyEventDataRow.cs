using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DailyEventDataRow : DataRow
	{
		public string id { get; set; }

		public EWeekType week { get; set; }

		public string start { get; set; }

		public int time { get; set; }

		public int type { get; set; }

		public string name { get; set; }

		public string GetKey()
		{
			return ((int)week).ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
