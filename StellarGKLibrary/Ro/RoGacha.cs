using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[JsonObject(MemberSerialization.OptIn)]
public class RoGacha
{
	[JsonProperty]
	public string type { get; set; }

	[JsonProperty]
	public TimeData freeOpenTime { get; set; }

	[JsonProperty]
	public int remainCount { get; set; }

	[JsonProperty]
	public int pilotRate { get; set; }

	[JsonProperty]
	public Dictionary<ERewardType, Protocols.GachaRatingDataTypeA> gachaRatingTypeA { get; set; }

	[JsonProperty]
	public Dictionary<ERewardType, Protocols.GachaRatingDataTypeB> gachaRatingTypeB { get; set; }

	public bool canOpenFreeBox
	{
		get
		{
			return remainCount > 0 && !freeOpenTime.IsProgress();
		}
	}

	public static RoGacha Create()
	{
		return new RoGacha
		{
			freeOpenTime = TimeData.Create(),
			pilotRate = 0,
			gachaRatingTypeA = new Dictionary<ERewardType, Protocols.GachaRatingDataTypeA>(),
			gachaRatingTypeB = new Dictionary<ERewardType, Protocols.GachaRatingDataTypeB>()
		};
	}
}
