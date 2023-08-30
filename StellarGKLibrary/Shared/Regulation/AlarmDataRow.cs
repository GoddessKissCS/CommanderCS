using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class AlarmDataRow : DataRow
	{
		private AlarmDataRow()
		{
		}

		public string idx { get; set; }

		public string key { get; set; }

		public string title { get; set; }

		public string description { get; set; }

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
