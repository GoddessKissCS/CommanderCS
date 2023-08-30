using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderGiftDataRow : DataRow
	{
		public int idx { get; set; }

		public int type { get; set; }

		public int favorPoint { get; set; }

		public string GetKey()
		{
			return idx.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
