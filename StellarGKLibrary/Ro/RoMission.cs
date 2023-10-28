using System;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class RoMission
{
	[JsonProperty]
	public string idx { get; set; }

	[JsonProperty]
	public string title { get; set; }

	[JsonProperty]
	public string description { get; set; }

	[JsonProperty]
	public int count { get; set; }

	[JsonProperty]
	public int count1 { get; set; }

	[JsonProperty]
	public string link { get; set; }

	[JsonProperty]
	public string startTime { get; set; }

	[JsonProperty]
	public string endTime { get; set; }

	[JsonProperty]
	public int sort { get; set; }

	[JsonProperty]
	public int type { get; set; }

	[JsonProperty]
	public string icon { get; set; }

	[JsonProperty]
	public int level { get; set; }

	[JsonProperty]
	public int VipCount { get; set; }

	[JsonProperty]
	public bool combleted { get; set; }

	[JsonProperty]
	public bool received { get; set; }

	[JsonProperty]
	public int conditionCount { get; set; }

	[JsonProperty]
	public double completeTime { get; set; }

	public string completeTimeString
	{
		get
		{
			return Utility.GetStringToDay(completeTime);
		}
	}

	public bool bListShow { get; set; }
}
