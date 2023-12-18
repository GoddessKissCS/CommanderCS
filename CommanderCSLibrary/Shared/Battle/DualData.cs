using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class DualData
{
	[JsonProperty("pnm")]
	internal string _playerName;

	[JsonProperty("pgnm")]
	internal string _playerGuildName;

	[JsonProperty("plv")]
	internal int _playerLevel;

	[JsonProperty("enm")]
	internal string _enemyName;

	[JsonProperty("egnm")]
	internal string _enemyGuildName;

	[JsonProperty("elv")]
	internal int _enemyLevel;

	[JsonProperty("ernk")]
	internal int _enemyRank;

	[JsonProperty("euno")]
	internal string _enemyUno;

	[JsonProperty("egskl", NullValueHandling = NullValueHandling.Ignore)]
	internal List<GuildSkillState> _enemyGuildSkills;

	[JsonProperty("egrp")]
	internal List<string> _enemyGroupBuffs;

	[JsonProperty("wldbf")]
	internal WorldDuelData _worldDuelData;

	public static DualData Copy(DualData src)
	{
		if (src == null)
		{
			return null;
		}
		DualData dualData = new DualData();
		dualData._playerName = src._playerName;
		dualData._playerLevel = src._playerLevel;
		dualData._playerGuildName = src._playerGuildName;
		dualData._enemyName = src._enemyName;
		dualData._enemyLevel = src._enemyLevel;
		dualData._enemyRank = src._enemyRank;
		dualData._enemyGuildName = src._enemyGuildName;
		dualData._enemyUno = src._enemyUno;
		if (src._enemyGuildSkills != null)
		{
			dualData._enemyGuildSkills = new List<GuildSkillState>();
			for (int i = 0; i < src._enemyGuildSkills.Count; i++)
			{
				dualData._enemyGuildSkills.Add(GuildSkillState.Copy(src._enemyGuildSkills[i]));
			}
		}
		if (src._enemyGroupBuffs != null)
		{
			dualData._enemyGroupBuffs = new List<string>();
			for (int j = 0; j < src._enemyGroupBuffs.Count; j++)
			{
				dualData._enemyGroupBuffs.Add(src._enemyGroupBuffs[j]);
			}
		}
		dualData._worldDuelData = WorldDuelData.Copy(src._worldDuelData);
		return dualData;
	}

	public static explicit operator JToken(DualData value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		JArray jArray = new JArray();
		jArray.Add(value._playerName);
		jArray.Add(value._playerLevel);
		jArray.Add(value._enemyName);
		jArray.Add(value._enemyLevel);
		jArray.Add(value._enemyRank);
		if (value._enemyGuildSkills != null)
		{
			JArray jArray2 = new JArray();
			for (int i = 0; i < value._enemyGuildSkills.Count; i++)
			{
				jArray2.Add((JToken)value._enemyGuildSkills[i]);
			}
			jArray.Add(jArray2);
		}
		else
		{
			jArray.Add(string.Empty);
		}
		jArray.Add(value._playerGuildName);
		jArray.Add(value._enemyGuildName);
		jArray.Add(value._enemyUno);
		if (value._enemyGroupBuffs != null)
		{
			JArray jArray3 = new JArray();
			for (int j = 0; j < value._enemyGroupBuffs.Count; j++)
			{
				jArray3.Add(value._enemyGroupBuffs[j]);
			}
			jArray.Add(jArray3);
		}
		else
		{
			jArray.Add(string.Empty);
		}
		jArray.Add((JToken)value._worldDuelData);
		return jArray;
	}

	public static explicit operator DualData(JToken value)
	{
		if (value.Type != JTokenType.Array)
		{
			return null;
		}
		DualData dualData = new DualData();
		dualData._playerName = (string)value[0];
		dualData._playerLevel = (int)value[1];
		dualData._enemyName = (string)value[2];
		dualData._enemyLevel = (int)value[3];
		dualData._enemyRank = (int)value[4];
		if (value[5].Type == JTokenType.Array)
		{
			JArray jArray = (JArray)value[5];
			if (jArray.Count > 0)
			{
				dualData._enemyGuildSkills = new List<GuildSkillState>();
				for (int i = 0; i < jArray.Count; i++)
				{
					dualData._enemyGuildSkills.Add((GuildSkillState)jArray[i]);
				}
			}
		}
		dualData._playerGuildName = (string)value[6];
		dualData._enemyGuildName = (string)value[7];
		dualData._enemyUno = (string)value[8];
		if (value[9].Type == JTokenType.Array)
		{
			JArray jArray2 = (JArray)value[9];
			if (jArray2.Count > 0)
			{
				dualData._enemyGroupBuffs = new List<string>();
				for (int j = 0; j < jArray2.Count; j++)
				{
					dualData._enemyGroupBuffs.Add((string)jArray2[j]);
				}
			}
		}
		dualData._worldDuelData = (WorldDuelData)value[10];
		return dualData;
	}
}
