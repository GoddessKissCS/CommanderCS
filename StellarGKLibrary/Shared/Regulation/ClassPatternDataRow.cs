using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ClassPatternDataRow : DataRow
	{
		public int key { get; set; }

		public int tier { get; set; }

		public int hp { get; set; }

		public int atk { get; set; }

		public int def { get; set; }

		public int aim { get; set; }

		public int luck { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", key, tier);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
