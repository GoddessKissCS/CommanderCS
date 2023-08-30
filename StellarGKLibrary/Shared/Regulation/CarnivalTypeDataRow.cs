using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CarnivalTypeDataRow : DataRow
	{
		private CarnivalTypeDataRow()
		{
		}

		public string idx { get; set; }

		public string name { get; set; }

		public int sort { get; set; }

		public ECarnivalType Type { get; set; }

		public string startDate { get; set; }

		public string startTime { get; set; }

		public string endDate { get; set; }

		public string endTime { get; set; }

		public int startLevel { get; set; }

		public int endLevel { get; set; }

		public int etc { get; set; }

		public string img { get; set; }

		public ECarnivalCategory categoryType { get; set; }

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
