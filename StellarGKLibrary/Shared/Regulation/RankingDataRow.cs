using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class RankingDataRow : DataRow
	{
		public int r_idx { get; set; }

		public ERankingContentsType type { get; set; }

		public ERankingType rankingType1 { get; set; }

		public int ranking1 { get; set; }

		public ERankingType rankingType2 { get; set; }

		public int ranking2 { get; set; }

		public int rankingWin { get; set; }

		public int rankingLose { get; set; }

		public string icon { get; set; }

		public string name { get; set; }

		public string GetKey()
		{
			return r_idx.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
