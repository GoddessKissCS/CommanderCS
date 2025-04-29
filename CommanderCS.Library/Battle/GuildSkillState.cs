using CommanderCS.Library.Regulation.DataRows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Library.Battle
{
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
            GuildSkillState guildSkillState = new()
            {
                _id = id,
                _skillLevel = level,
                _dr = dr
            };
            return guildSkillState;
        }

        public static GuildSkillState Copy(GuildSkillState src)
        {
            GuildSkillState guildSkillState = new()
            {
                _id = src._id,
                _skillLevel = src._skillLevel
            };
            return guildSkillState;
        }

        public static explicit operator JToken(GuildSkillState value)
        {
            JArray jArray = [value._id, value._skillLevel];
            return jArray;
        }

        public static explicit operator GuildSkillState(JToken value)
        {
            GuildSkillState guildSkillState = new()
            {
                _id = (int)value[0],
                _skillLevel = (int)value[1]
            };
            return guildSkillState;
        }
    }
}