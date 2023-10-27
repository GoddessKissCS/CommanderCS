using System;
using Newtonsoft.Json;

namespace BattleSimulator.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Input
	{
		internal Input()
		{
		}

		public Input(int unitIndex, int skillIndex, int targetIndex)
		{
			_unitIndex = unitIndex;
			_skillIndex = skillIndex;
			_targetIndex = targetIndex;
			_result = false;
		}

		public int unitIndex
		{
			get
			{
				return _unitIndex;
			}
		}

		public int skillIndex
		{
			get
			{
				return _skillIndex;
			}
		}

		public int targetIndex
		{
			get
			{
				return _targetIndex;
			}
		}

		public bool result
		{
			get
			{
				return _result;
			}
		}

		public static Input Copy(Input src)
		{
			return new()
			{
				_unitIndex = src._unitIndex,
				_skillIndex = src._skillIndex,
				_targetIndex = src._targetIndex,
				_result = src._result
			};
		}

		public static bool IsSame(Input f1, Input f2)
		{
			return f1 == f2 || (f1.unitIndex == f2.unitIndex && f1.skillIndex == f2.skillIndex && f1.targetIndex == f2.targetIndex && f1._result == f2._result);
		}

		[JsonProperty("uidx")]
		internal int _unitIndex;

		[JsonProperty("sidx")]
		internal int _skillIndex;

		[JsonProperty("tidx")]
		internal int _targetIndex;

		[JsonIgnore]
		internal bool _result;
	}
}
