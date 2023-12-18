using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class GachaRewardDataRow : DataRow
{
	public string gachaType { get; private set; }

	public ERewardType rewardType { get; private set; }

	public string rewardId { get; private set; }

	public int rewardCount { get; private set; }

	public int effectType { get; private set; }

	public string GetKey()
	{
		return gachaType;
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
