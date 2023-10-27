using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;
using StellarGKLibrary.Protocols;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ItemExchangeDataRow : DataRow
	{
		private ItemExchangeDataRow()
		{
		}

		public string idx { get; private set; }

		public EStorageType type { get; private set; }

		public string typeidx { get; private set; }

		public int display { get; private set; }

		public EStorageType pricetype { get; private set; }

		public string pricetypeidx { get; private set; }

		public int price { get; private set; }

		public ENavigatorType navigatortype1 { get; private set; }

		public int position1 { get; private set; }

		public ENavigatorType navigatortype2 { get; private set; }

		public int position2 { get; private set; }

		public ENavigatorType navigatortype3 { get; private set; }

		public int position3 { get; private set; }

		public List<NavigatorInfo> navigatorInfo()
		{
			List<NavigatorInfo> list = new List<NavigatorInfo>();
			if (navigatortype1 != ENavigatorType.None)
			{
				list.Add(new NavigatorInfo(navigatortype1, position1));
			}
			if (navigatortype2 != ENavigatorType.None)
			{
				list.Add(new NavigatorInfo(navigatortype2, position2));
			}
			if (navigatortype3 != ENavigatorType.None)
			{
				list.Add(new NavigatorInfo(navigatortype3, position3));
			}
			return list;
		}

		public string GetKey()
		{
			return idx;
		}

	}
}
