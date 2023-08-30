using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class InAppProductDataRow : DataRow
	{
		public int iapidx { get; set; }

		public string googlePlayID { get; set; }

		public int sort { get; set; }

		public int cash { get; set; }

		public string wonPrice { get; set; }

		public string dollarPrice { get; set; }

		public ECashRechargeType type { get; set; }

		public string stringidx { get; set; }

		public string explanation { get; set; }

		public string stringidxEvent { get; set; }

		public string explanationEvent { get; set; }

		public string explanationFirst { get; set; }

		public string icon { get; set; }

		public int isSell { get; set; }

		public int uiType { get; set; }

		public int count { get; set; }

		public int availableLevel { get; set; }

		public string GetKey()
		{
			return googlePlayID;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
