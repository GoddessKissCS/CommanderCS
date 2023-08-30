using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WorldMapStageTypeDataRow : DataRow
	{
		public string id { get; set; }

		public string resourceId { get; set; }

		public int battleCount { get; set; }

		public string bgm { get; set; }

		public string GetKey()
		{
			return id;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
