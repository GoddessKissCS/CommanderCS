using CommanderCS.Library.Shared.Enum;

namespace CommanderCS.Library.Shared.Battle
{
    public class ClearMissionItem
    {
        public int id;

        private bool _finish;

        private bool _success = true;

        private EBattleClearCondition _condition;

        private string _conditionValue;

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

        public EBattleClearCondition condition => _condition;

        public string conditionValue => _conditionValue;

        public ClearMissionItem(EBattleClearCondition condition, int id, string conditionValue = "0")
        {
            this.id = id;
            _finish = false;
            _success = true;
            _condition = condition;
            _conditionValue = conditionValue;
        }
    }
}