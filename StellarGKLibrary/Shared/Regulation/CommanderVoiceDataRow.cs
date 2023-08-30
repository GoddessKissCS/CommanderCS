using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class CommanderVoiceDataRow : DataRow
	{
		private CommanderVoiceDataRow()
		{
		}

		public string index { get; set; }

		public ECommanderVoiceEventType type { get; set; }

		[JsonProperty("voicesound")]
		public string sound { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", index, (int)type);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
