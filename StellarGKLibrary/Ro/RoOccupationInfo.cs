using System;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class RoOccupationInfo
{
	[JsonProperty]
	public string troopId { get; private set; }

	[JsonProperty]
	public string userId { get; private set; }

	[JsonProperty]
	public string routeId { get; private set; }

	[JsonProperty]
	public int routeStep { get; private set; }

	[JsonProperty]
	public double repairEndTime { get; private set; }

	[JsonProperty]
	public RoTroop.Slot[] slots { get; private set; }
}
