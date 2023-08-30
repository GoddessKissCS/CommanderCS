using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class TranscendenceSlotDataRow : DataRow
	{
		public int slot { get; set; }

		public StatType stat { get; set; }

		public int addStat { get; set; }

		public int firstStepLimit { get; set; }

		public int addStepLimit { get; set; }

		public string statString { get; set; }

		public string icon { get; set; }

		public string tip { get; set; }

		public string tipTitle { get; set; }

		public string GetKey()
		{
			return slot.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
