using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DefineDataRow : DataRow
	{
		public string key { get; set; }

		public string value { get; set; }

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
