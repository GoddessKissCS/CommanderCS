using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ScenarioQuarterDataRow : DataRow
	{
		public string GetKey()
		{
			return quarter.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public string csid;

		public string quarter;
	}
}
