using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class InteractionDataRow : DataRow
	{
		public string resourceId { get; set; }

		public InteractionType type { get; set; }

		public int count { get; set; }

		public string emotion { get; set; }

		public string emoticon { get; set; }

		public int balloon { get; set; }

		public string S_Idx { get; set; }

		public string sound { get; set; }

		public int favorup { get; set; }

		private string dialogue { get; set; }

		public string GetKey()
		{
			return resourceId.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (sound == "-")
			{
				sound = string.Empty;
			}
		}
	}
}
