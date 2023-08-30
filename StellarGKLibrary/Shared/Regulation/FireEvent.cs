using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class FireEvent
	{
		public FireEvent(int time, int firePointTypeIndex, string firePointBonePath)
		{
			time = time;
			firePointTypeIndex = firePointTypeIndex;
			firePointBonePath = firePointBonePath;
		}

		public int time { get; set; }

		public int firePointTypeIndex { get; set; }

		public string firePointBonePath { get; set; }
	}
}
