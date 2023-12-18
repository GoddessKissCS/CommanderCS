using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class SkillCostDataRow : DataRow
{
	public List<int> typeCost;

	public List<int> typeLimitLevel;

	public int level { get; private set; }

	public string GetKey()
	{
		return level.ToString();
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
