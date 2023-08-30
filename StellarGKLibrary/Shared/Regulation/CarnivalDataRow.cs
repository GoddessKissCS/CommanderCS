using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CarnivalDataRow : DataRow
	{
		private CarnivalDataRow()
		{
		}

		public string key { get; set; }

		public string idx { get; set; }

		public string cTidx { get; set; }

		public string explanation { get; set; }

		public int checkType { get; set; }

		public int checkCount { get; set; }

		public string check2 { get; set; }

		public string link { get; set; }

		public int userVip { get; set; }

		public int userLevel { get; set; }

		public ERewardType commodityType { get; set; }

		public string commodityIdx { get; set; }

		public int commodityCount { get; set; }

		public string aidExplanation { get; set; }

		public EventCarnivalCheckType check2Type { get; set; }

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
