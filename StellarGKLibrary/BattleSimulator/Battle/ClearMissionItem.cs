using StellarGKLibrary.Enum;
using System;

namespace BattleSimulator.Battle
{
	public class ClearMissionItem
	{
		public ClearMissionItem(EBattleClearCondition condition, int id, string conditionValue = "0")
		{
			id = id;
			_finish = false;
			_success = true;
			_condition = condition;
			_conditionValue = conditionValue;
		}

		public bool isFinish
		{
			get
			{
				return _finish;
			}
			set
			{
				_finish = value;
			}
		}

		public bool isSuccess
		{
			get
			{
				return _success;
			}
			set
			{
				_success = value;
			}
		}

		public EBattleClearCondition condition
		{
			get
			{
				return _condition;
			}
		}

		public string conditionValue
		{
			get
			{
				return _conditionValue;
			}
		}

		public int id;

		private bool _finish;

		private bool _success = true;

		private EBattleClearCondition _condition;

		private string _conditionValue;
	}
}
