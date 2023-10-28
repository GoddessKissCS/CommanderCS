using System;
using Newtonsoft.Json;
using Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class RoBattleResult
{
	public RoBattleResult(double timestamp, string areaId, Record record)
	{
		timestamp = timestamp;
		areaId = areaId;
		record = record;
	}

	[JsonProperty]
	public double timestamp { get; private set; }

	[JsonProperty]
	public string areaId { get; private set; }

	[JsonProperty]
	public Record record { get; private set; }
}
