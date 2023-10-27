using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGKLibrary.BattleSimulator
{
	[JsonObject(MemberSerialization.OptIn)]
	public class RaidData
	{
		public int raidId
		{
			get
			{
				return _raidId;
			}
		}

		public float Amount
		{
			get
			{
				return (float)((_raidEndTime - _raidStartTime) / (_raidEndTime - _raidCurTime));
			}
		}

		public static RaidData Create(int raidId, double startTime, double endTime, double curTime)
		{
			return new RaidData
			{
				_raidId = raidId,
				_raidStartTime = startTime,
				_raidEndTime = endTime,
				_raidCurTime = curTime
			};
		}

		public static RaidData Copy(RaidData src)
		{
			if (src == null)
			{
				return null;
			}
			return new RaidData
			{
				_raidId = src._raidId,
				_raidStartTime = src._raidStartTime,
				_raidEndTime = src._raidEndTime,
				_raidCurTime = src._raidCurTime
			};
		}

		public static explicit operator JToken(RaidData value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			return new JArray { value._raidId, value._raidStartTime, value._raidEndTime, value._raidCurTime };
		}

		public static explicit operator RaidData(JToken value)
		{
			if (value.Type != JTokenType.Array)
			{
				return null;
			}
			return new RaidData
			{
				_raidId = (int)value[0],
				_raidStartTime = (double)value[1],
				_raidEndTime = (double)value[2],
				_raidCurTime = (double)value[3]
			};
		}

		public static int delayActiveTime = 4000;

		[JsonProperty("rid")]
		internal int _raidId;

		[JsonProperty("stm")]
		internal double _raidStartTime;

		[JsonProperty("etm")]
		internal double _raidEndTime;

		[JsonProperty("ctm")]
		internal double _raidCurTime;
	}
}
