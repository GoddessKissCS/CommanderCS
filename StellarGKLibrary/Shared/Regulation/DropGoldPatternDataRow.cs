using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class DropGoldPatternDataRow : DataRow
	{
		public int key { get; set; }

		public int levelStep { get; set; }

		public int goldStep { get; set; }

		public string GetKey()
		{
			return key.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
