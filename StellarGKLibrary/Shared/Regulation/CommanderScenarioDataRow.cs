using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderScenarioDataRow : DataRow
	{
		public int csid { get; set; }

		public string cid { get; set; }

		public int order { get; set; }

		public string name { get; set; }

		public string desc { get; set; }

		public int level { get; set; }

		public int grade { get; set; }

		public int cls { get; set; }

		public int favor { get; set; }

		public int mapClear { get; set; }

		public int commander { get; set; }

		public int scenarioClear { get; set; }

		public int heart { get; set; }

		public string GetKey()
		{
			return csid.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
