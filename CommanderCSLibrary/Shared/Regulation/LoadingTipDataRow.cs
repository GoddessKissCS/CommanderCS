using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class LoadingTipDataRow : DataRow
{
	public string idx { get; private set; }

	public int userstartlevel { get; private set; }

	public int userendlevel { get; private set; }

	public string commanderidx { get; private set; }

	public string backgroundimg { get; private set; }

	public string commanderjobicon { get; private set; }

	public string comjobsidx { get; private set; }

	public string comnamesidx { get; private set; }

	public string comunitnamesidx { get; private set; }

	public int type { get; private set; }

	private LoadingTipDataRow()
	{
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
