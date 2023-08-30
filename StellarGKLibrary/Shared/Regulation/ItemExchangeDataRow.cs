using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ItemExchangeDataRow : DataRow
	{
		private ItemExchangeDataRow()
		{
		}

		public string idx { get; set; }

		public EStorageType type { get; set; }

		public string typeidx { get; set; }

		public int display { get; set; }

		public EStorageType pricetype { get; set; }

		public string pricetypeidx { get; set; }

		public int price { get; set; }

		public ENavigatorType navigatortype1 { get; set; }

		public int position1 { get; set; }

		public ENavigatorType navigatortype2 { get; set; }

		public int position2 { get; set; }

		public ENavigatorType navigatortype3 { get; set; }

		public int position3 { get; set; }

		public List<Protocols.NavigatorInfo> navigatorInfo()
		{
			List<Protocols.NavigatorInfo> list = new List<Protocols.NavigatorInfo>();
			if (navigatortype1 != ENavigatorType.None)
			{
				list.Add(new Protocols.NavigatorInfo(navigatortype1, position1));
			}
			if (navigatortype2 != ENavigatorType.None)
			{
				list.Add(new Protocols.NavigatorInfo(navigatortype2, position2));
			}
			if (navigatortype3 != ENavigatorType.None)
			{
				list.Add(new Protocols.NavigatorInfo(navigatortype3, position3));
			}
			return list;
		}

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
