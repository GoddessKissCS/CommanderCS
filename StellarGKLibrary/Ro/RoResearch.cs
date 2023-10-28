using System;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class RoResearch
{
	[JsonProperty]
	public string id { get; private set; }

	public static RoResearch Create(string id)
	{
		return new RoResearch
		{
			id = id
		};
	}
}
