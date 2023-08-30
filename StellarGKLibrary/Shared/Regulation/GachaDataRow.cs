using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GachaDataRow : DataRow
	{
		public string type { get; set; }

		public int ui { get; set; }

		public string name { get; set; }

		public string img { get; set; }

		public string banner { get; set; }

		public int sort { get; set; }

		public int resetTime { get; set; }

		public int count { get; set; }

		public int bonusCount { get; set; }

		public string eventComment { get; set; }

		public string mainReward { get; set; }

		public string GetKey()
		{
			return type;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
