using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class SweepDataRow : DataRow
	{
		public int type { get; set; }

		public int level { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public int minLevel { get; set; }

		public EGoods gid { get; set; }

		public int useValue { get; set; }

		public int battleType { get; set; }

		public string helper { get; set; }

		public string uid { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		public string bgm { get; set; }

		public int endTurn { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", type, level);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public int index;
	}
}
