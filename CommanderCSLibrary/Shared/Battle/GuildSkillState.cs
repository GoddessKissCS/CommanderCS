using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class GuildSkillState
{
	[JsonProperty("id")]
	internal int _id;

	[JsonProperty("lv")]
	internal int _skillLevel;

	[JsonIgnore]
	internal GuildSkillDataRow _dr;

	[JsonIgnore]
	public GuildSkillDataRow dr => _dr;

	public static GuildSkillState Create(int id, int level, GuildSkillDataRow dr)
	{
		GuildSkillState guildSkillState = new GuildSkillState();
		guildSkillState._id = id;
		guildSkillState._skillLevel = level;
		guildSkillState._dr = dr;
		return guildSkillState;
	}

	public static GuildSkillState Copy(GuildSkillState src)
	{
		GuildSkillState guildSkillState = new GuildSkillState();
		guildSkillState._id = src._id;
		guildSkillState._skillLevel = src._skillLevel;
		return guildSkillState;
	}

	public static explicit operator JToken(GuildSkillState value)
	{
		JArray jArray = new JArray();
		jArray.Add(value._id);
		jArray.Add(value._skillLevel);
		return jArray;
	}

	public static explicit operator GuildSkillState(JToken value)
	{
		GuildSkillState guildSkillState = new GuildSkillState();
		guildSkillState._id = (int)value[0];
		guildSkillState._skillLevel = (int)value[1];
		return guildSkillState;
	}
}
