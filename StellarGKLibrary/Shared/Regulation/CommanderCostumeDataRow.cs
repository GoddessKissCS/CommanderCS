using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderCostumeDataRow : DataRow
	{
		public int ctid { get; set; }

		public int cid { get; set; }

		public string name { get; set; }

		public string Desc { get; set; }

		public int sell { get; set; }

		public EPriceType gid { get; set; }

		public int sellPrice { get; set; }

		public string skinName { get; set; }

		public int order { get; set; }

		public StatType statType1 { get; set; }

		public int stat1 { get; set; }

		public StatType statType2 { get; set; }

		public int stat2 { get; set; }

		public StatType statType3 { get; set; }

		public int stat3 { get; set; }

		public int atlasNumber { get; set; }

		public string GetKey()
		{
			return ctid.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
