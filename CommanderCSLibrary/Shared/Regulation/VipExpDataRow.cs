using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class VipExpDataRow : DataRow
{
	public int Idx { get; private set; }

	public int exp { get; private set; }

	public int favormax { get; private set; }

	public int maxSkill { get; private set; }

	public string GetKey()
	{
		return Idx.ToString();
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
