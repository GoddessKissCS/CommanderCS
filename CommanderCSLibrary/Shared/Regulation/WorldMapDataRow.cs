using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class WorldMapDataRow : DataRow
{
	public string id { get; private set; }

	public string name { get; private set; }

	public string resourceId { get; private set; }

	public string c_idx { get; private set; }

	public string backgroundImageId => "Texture/WorldMap/" + resourceId;

	public int unlockUserLevel { get; private set; }

	public string bgm { get; private set; }

	public string listImg { get; private set; }

	public string GetKey()
	{
		return id;
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
