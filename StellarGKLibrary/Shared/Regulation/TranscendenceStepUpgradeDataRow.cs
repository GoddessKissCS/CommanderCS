using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class TranscendenceStepUpgradeDataRow : DataRow
	{
		public int step { get; set; }

		public int stepPoint { get; set; }

		public StatType stat { get; set; }

		public int statAddMeasure { get; set; }

		public int statAddVolume { get; set; }

		public string addString { get; set; }

		public string GetKey()
		{
			return step.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
