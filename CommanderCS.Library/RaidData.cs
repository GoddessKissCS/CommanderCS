using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Library
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RaidData
    {
        public static int delayActiveTime = 4000;

        [JsonProperty("rid")]
        internal int _raidId;

        [JsonProperty("stm")]
        internal double _raidStartTime;

        [JsonProperty("etm")]
        internal double _raidEndTime;

        [JsonProperty("ctm")]
        internal double _raidCurTime;

        public int raidId => _raidId;

        public float Amount => (float)((_raidEndTime - _raidStartTime) / (_raidEndTime - _raidCurTime));

        public static RaidData Create(int raidId, double startTime, double endTime, double curTime)
        {
            RaidData raidData = new()
            {
                _raidId = raidId,
                _raidStartTime = startTime,
                _raidEndTime = endTime,
                _raidCurTime = curTime
            };
            return raidData;
        }

        public static RaidData Copy(RaidData src)
        {
            if (src is null)
            {
                return null;
            }
            RaidData raidData = new()
            {
                _raidId = src._raidId,
                _raidStartTime = src._raidStartTime,
                _raidEndTime = src._raidEndTime,
                _raidCurTime = src._raidCurTime
            };
            return raidData;
        }

        public static explicit operator JToken(RaidData value)
        {
            if (value is null)
            {
                return string.Empty;
            }
            JArray jArray = [value._raidId, value._raidStartTime, value._raidEndTime, value._raidCurTime];
            return jArray;
        }

        public static explicit operator RaidData(JToken value)
        {
            if (value.Type != JTokenType.Array)
            {
                return null;
            }
            RaidData raidData = new()
            {
                _raidId = (int)value[0],
                _raidStartTime = (double)value[1],
                _raidEndTime = (double)value[2],
                _raidCurTime = (double)value[3]
            };
            return raidData;
        }
    }
}