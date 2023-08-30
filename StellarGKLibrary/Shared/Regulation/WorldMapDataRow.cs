using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WorldMapDataRow : DataRow
	{
		public string id { get; set; }

		public string name { get; set; }

		public string resourceId { get; set; }

		public string c_idx { get; set; }

		public string backgroundImageId
		{
			get
			{
				return "Texture/WorldMap/" + resourceId;
			}
		}

		public int unlockUserLevel { get; set; }

		public string bgm { get; set; }

		public string listImg { get; set; }

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
