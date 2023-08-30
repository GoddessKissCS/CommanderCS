using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GroupMemberDataRow : DataRow
	{
		private GroupMemberDataRow()
		{
		}

		public string gidx { get; set; }

		public string idx { get; set; }

		public int memberType { get; set; }

		public int grade { get; set; }

		public string memberIdx { get; set; }

		public string GetKey()
		{
			return gidx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
