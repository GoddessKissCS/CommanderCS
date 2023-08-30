using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventRemaingTimeDataRow : DataRow
	{
		public string idx { get; set; }

		public string name { get; set; }

		public int sort { get; set; }

		public string img { get; set; }

		public string metro { get; set; }

		public int xaxis { get; set; }

		public int yaxis { get; set; }

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
