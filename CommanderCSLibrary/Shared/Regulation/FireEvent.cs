using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class FireEvent
{
	public int time { get; private set; }

	public int firePointTypeIndex { get; private set; }

	public string firePointBonePath { get; private set; }

	public FireEvent(int time, int firePointTypeIndex, string firePointBonePath)
	{
		this.time = time;
		this.firePointTypeIndex = firePointTypeIndex;
		this.firePointBonePath = firePointBonePath;
	}
}
