using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GuildSkillState
    {
        //[JsonIgnore]
        //public GuildSkillDataRow dr
        //{
        //	get
        //	{
        //		return _dr;
        //	}
        //}

        //public static GuildSkillState Create(int id, int level, GuildSkillDataRow dr)
        //{
        //	return new GuildSkillState
        //	{
        //		_id = id,
        //		_skillLevel = level,
        //		_dr = dr
        //	};
        //}

        public static GuildSkillState Copy(GuildSkillState src)
        {
            return new GuildSkillState
            {
                _id = src._id,
                _skillLevel = src._skillLevel
            };
        }

        public static explicit operator JToken(GuildSkillState value)
        {
            return new JArray { value._id, value._skillLevel };
        }

        public static explicit operator GuildSkillState(JToken value)
        {
            return new GuildSkillState
            {
                _id = (int)value[0],
                _skillLevel = (int)value[1]
            };
        }

        [JsonProperty("id")]
        internal int _id;

        [JsonProperty("lv")]
        internal int _skillLevel;

        //[JsonIgnore]
        //internal GuildSkillDataRow _dr;
    }
}
