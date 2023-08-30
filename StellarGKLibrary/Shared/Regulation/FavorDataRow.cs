using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class FavorDataRow : DataRow
	{
		public int cid { get; set; }

		public int step { get; set; }

		public string profile { get; set; }

		public StatType statType { get; set; }

		public int stat { get; set; }

		public string GetKey()
		{
			return cid.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
