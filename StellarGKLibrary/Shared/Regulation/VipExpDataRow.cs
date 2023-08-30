using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class VipExpDataRow : DataRow
	{
		public int Idx { get; set; }

		public int exp { get; set; }

		public int favormax { get; set; }

		public int maxSkill { get; set; }

		public string GetKey()
		{
			return Idx.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
