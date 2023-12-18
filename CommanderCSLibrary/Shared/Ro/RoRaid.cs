using System.Collections.Generic;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Ro;

[JsonObject(MemberSerialization.OptIn)]
public class RoRaid
{
	public int raidId;

	public double raidStartTime;

	public double raidEndTime;

	public double raidCurTime;

	public RoCommander commander;

	public string commanderId => commander.id;

	public static RoRaid Create(int raidId, double startTime, double endTime, double curTime)
	{
		RoRaid roRaid = new RoRaid();
		roRaid.raidId = raidId;
		roRaid.raidStartTime = startTime;
		roRaid.raidEndTime = endTime;
		roRaid.raidCurTime = curTime;
		RaidChallengeDataRow raidChallengeDataRow = Constants.regulation.raidChallengeDtbl[raidId.ToString()];
		roRaid.commander = RoCommander.Create(raidChallengeDataRow.commanderId, 1, 1, 1, 0, 0, 0, new List<int>());
		return roRaid;
	}

	public RaidData ToBattleRaidData()
	{
		return RaidData.Create(raidId, raidStartTime, raidEndTime, raidCurTime);
	}
}
