using CommanderCSLibrary.Shared.Battle;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Ro;

[JsonObject(MemberSerialization.OptIn)]
public class RoBattleResult
{
	[JsonProperty]
	public double timestamp { get; private set; }

	[JsonProperty]
	public string areaId { get; private set; }

	[JsonProperty]
	public Record record { get; private set; }

	public RoBattleResult(double timestamp, string areaId, Record record)
	{
		this.timestamp = timestamp;
		this.areaId = areaId;
		this.record = record;
	}
}
