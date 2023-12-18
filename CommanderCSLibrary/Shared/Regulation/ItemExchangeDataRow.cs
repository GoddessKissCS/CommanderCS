using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class ItemExchangeDataRow : DataRow
{
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

	private ItemExchangeDataRow()
	{
	}

	public List<Protocols.NavigatorInfo> navigatorInfo()
	{
		List<Protocols.NavigatorInfo> list = new List<Protocols.NavigatorInfo>();
		if (navigatortype1 != 0)
		{
			list.Add(new Protocols.NavigatorInfo(navigatortype1, position1));
		}
		if (navigatortype2 != 0)
		{
			list.Add(new Protocols.NavigatorInfo(navigatortype2, position2));
		}
		if (navigatortype3 != 0)
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
