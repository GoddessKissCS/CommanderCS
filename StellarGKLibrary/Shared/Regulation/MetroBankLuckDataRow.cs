using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class MetroBankLuckDataRow : DataRow
	{
		public string Luck { get; set; }

		public int ChipPercent { get; set; }

		public string GetKey()
		{
			return Luck;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
