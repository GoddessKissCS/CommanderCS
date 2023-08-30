using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GuildLevelInfoDataRow : DataRow
	{
		public int level { get; set; }

		public int maxcount { get; set; }

		public int cost { get; set; }

		public string GetKey()
		{
			return level.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
