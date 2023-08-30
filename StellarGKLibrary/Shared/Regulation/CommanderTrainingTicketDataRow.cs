using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderTrainingTicketDataRow : DataRow
	{
		public ETrainingTicketType type { get; set; }

		public int gold { get; set; }

		public int exp { get; set; }

		public string GetKey()
		{
			return type.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
