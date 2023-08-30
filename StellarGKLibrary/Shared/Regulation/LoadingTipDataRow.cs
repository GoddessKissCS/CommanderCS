using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class LoadingTipDataRow : DataRow
	{
		private LoadingTipDataRow()
		{
		}

		public string idx { get; set; }

		public int userstartlevel { get; set; }

		public int userendlevel { get; set; }

		public string commanderidx { get; set; }

		public string backgroundimg { get; set; }

		public string commanderjobicon { get; set; }

		public string comjobsidx { get; set; }

		public string comnamesidx { get; set; }

		public string comunitnamesidx { get; set; }

		public int type { get; set; }

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
